using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
            var wait = new WebDriverWait(this.Browser.Driver, timeout);
            try
            {
                return wait.Until(condition);
            }
            catch (WebDriverTimeoutException)
            {
                this.Browser.LogError(message ?? "Condition timed out.");
            }
            return default(T);
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

        public bool UntilContainsText(string text, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.ContainsText(text);
                },
                timeout, message);
        }

        public bool UntilDoesNotContainText(string text, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return !this.element.ContainsText(text);
                },
                timeout, message);
        }

        public bool UntilContainsElement(string locator, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.FindElement(locator, required: false) != null;
                },
                timeout, message);
        }

        public bool UntilDoesNotContainElement(string locator, TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.FindElement(locator, required: false) == null;
                },
                timeout, message);
        }

        public bool UntilVisible(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.IsVisible;
                },
                timeout, message);
        }

        public bool UntilNotVisible(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return !this.element.IsVisible;
                },
                timeout, message);
        }

        public bool UntilEnabled(TimeSpan timeout = default(TimeSpan), string message = null)
        {
            return this.Until(
                d =>
                {
                    return this.element.IsEnabled;
                },
                timeout, message);
        }
    }
}
