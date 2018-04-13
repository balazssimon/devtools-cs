using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DevToolsX.Testing.Selenium
{
    public class Wait
    {
        private static readonly object[] emptyObjectArray = new object[0];

        public Wait(Browser browser)
        {
            this.Browser = browser;
        }

        protected Browser Browser
        {
            get;
        }

        public void For(TimeSpan timeout)
        {
            Thread.Sleep(timeout);
        }

        public void For(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public T Until<T>(Func<IWebDriver,T> condition, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            if (timeout.TotalSeconds == 0)
            {
                T result = condition(this.Browser.Driver);
                if (message != null)
                {
                    bool? boolResult = result as bool?;
                    object objectResult = result as object;
                    bool success = (objectResult != null && boolResult == null) || (boolResult ?? false);
                    if (!success) this.Browser.LogError(message);
                }
                return result;
            }
            else
            {
                if (timeout.TotalSeconds < 0 || timeout.TotalDays > 365)
                {
                    timeout = TimeSpan.FromDays(365);
                }
                var wait = new WebDriverWait(this.Browser.Driver, timeout);
                try
                {
                    return wait.Until(condition);
                }
                catch (WebDriverTimeoutException)
                {
                    if (message != null)
                    {
                        this.Browser.LogError(message);
                    }
                }
                return default(T);
            }
        }

        public bool Until(string javaScriptCondition, object[] args = null, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            if (!this.Browser.JavaScript.IsSupported)
            {
                this.Browser.LogError("JavaScript is not supported.");
                return false;
            }
            return this.Until(
                d =>
                {
                    object result = this.Browser.JavaScript.Execute(javaScriptCondition, args ?? emptyObjectArray);
                    return result is bool && (bool)result;
                },
                timeout, message);
        }
    }

    public class ElementWait : Wait
    {
        private Element element;

        public ElementWait(Element element)
            : base(element.Browser)
        {
            this.element = element;
        }

        public bool UntilPageLoaded(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            string jsCondition = @"
try {
  if (document.readyState !== 'complete') {
    return false; // Page not loaded yet
  }
  if (window.jQuery) {
    if (window.jQuery.active) {
      return false;
    } else if (window.jQuery.ajax && window.jQuery.ajax.active) {
      return false;
    }
  }
  if (window.angular) {
    if (!window.qa) {
      // Used to track the render cycle finish after loading is complete
      window.qa = {
        doneRendering: false
      };
    }
    // Get the angular injector for this app (change element if necessary)
    var injector = window.angular.element('body').injector();
    // Store providers to use for these checks
    var $rootScope = injector.get('$rootScope');
    var $http = injector.get('$http');
    var $timeout = injector.get('$timeout');
    // Check if digest
    if ($rootScope.$$phase === '$apply' || $rootScope.$$phase === '$digest' || $http.pendingRequests.length !== 0) {
      window.qa.doneRendering = false;
      return false; // Angular digesting or loading data
    }
    if (!window.qa.doneRendering) {
      // Set timeout to mark angular rendering as finished
      $timeout(function() {
        window.qa.doneRendering = true;
      }, 0);
      return false;
    }
  }
  return true;
} catch (ex) {
  return false;
}
";
            return this.Until(jsCondition, null, timeout, message ?? string.Format("Page is not loaded in {0}.", timeout));
        }

        public bool UntilContainsText(string text, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.ContainsText(text);
                },
                timeout, message ?? string.Format("{0} still has no text '{1}' after {2}.", this.element.LogName, text, timeout));
        }

        public bool UntilDoesNotContainText(string text, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return !this.element.ContainsText(text);
                },
                timeout, message ?? string.Format("{0} still has text '{1}' after {2}.", this.element.LogName, text, timeout));
        }

        public bool UntilContainsElement(string locator, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.InternalFindElement(locator, required: false) != null;
                },
                timeout, message ?? string.Format("{0} still does not contain '{1}' after {2}.", this.element.LogName, locator, timeout));
        }

        public bool UntilDoesNotContainElement(string locator, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.InternalFindElement(locator, required: false) == null;
                },
                timeout, message ?? string.Format("{0} still contains '{1}' after {2}.", this.element.LogName, locator, timeout));
        }

        public bool UntilExists(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            var newElement = this.element.Parent.FindElement(this.element.Locator, this.element.TagKind, true);
            if (newElement.WebElement != null)
            {
                this.element.UpdateWebElement(newElement.WebElement);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UntilVisible(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.IsVisible;
                },
                timeout, message ?? string.Format("{0} is still not visible after {1}.", this.element.LogName, timeout));
        }

        public bool UntilNotVisible(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return !this.element.IsVisible;
                },
                timeout, message ?? string.Format("{0} is still visible after {1}.", this.element.LogName, timeout));
        }

        public bool UntilEnabled(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.IsEnabled;
                },
                timeout, message ?? string.Format("{0} is not enabled after {1}.", this.element.LogName, timeout));
        }

        public bool UntilDisabled(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return !this.element.IsEnabled;
                },
                timeout, message ?? string.Format("{0} is still not disabled after {1}.", this.element.LogName, timeout));
        }
    }
}
