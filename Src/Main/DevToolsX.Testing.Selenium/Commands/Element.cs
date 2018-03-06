using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class Element
    {
        public Element(Browser browser, Element parent, IWebElement webElement)
        {
            if (browser == null) throw new ArgumentNullException(nameof(browser));
            this.Browser = browser;
            this.Parent = parent;
            this.WebElement = webElement;
        }

        public Browser Browser { get; }
        public Element Parent { get; }
        public IWebElement WebElement { get; }

        public string Name
        {
            get
            {
                if (this.Parent == null) return "Page";
                else return this.WebElement?.TagName ?? "Element";
            }
        }

        private string CapitalName()
        {
            string name = this.Name;
            if (name.Length > 0)
            {
                name = name.Substring(0, 1).ToUpper() + name.Substring(1);
            }
            return name;
        }

        private string SmallName()
        {
            return this.Name.ToLower();
        }

        public Options Options
        {
            get { return this.Browser.Options; }
        }

        public ILogger Logger
        {
            get { return this.Browser.Logger; }
        }

        public string Text
        {
            get { return this.WebElement?.Text; }
        }

        public string Value
        {
            get { return this.WebElement?.GetAttribute("value"); }
        }

        public Element FindOne(string locator, string tag = null, bool required = true)
        {
            if (locator == null) throw new ArgumentException($"Invalid locator syntax '{locator}'. Locators should start with a registered locator prefix.");
            int colonIndex = locator.IndexOf(':');
            if (colonIndex < 0) throw new ArgumentException($"Invalid locator syntax '{locator}'. Locators should start with a registered locator prefix.");
            string prefix = locator.Substring(0, colonIndex).Trim();
            string value = locator.Substring(colonIndex + 1).Trim();
            return this.Options.CreateLocator(prefix, this.Browser, this).FindOne(value, tag, required);
        }

        public ImmutableArray<Element> Find(string locator, string tag = null, bool required = true)
        {
            if (locator == null) throw new ArgumentException($"Invalid locator syntax '{locator}'. Locators should start with a registered locator prefix.");
            int colonIndex = locator.IndexOf(':');
            if (colonIndex < 0) throw new ArgumentException($"Invalid locator syntax '{locator}'. Locators should start with a registered locator prefix.");
            string prefix = locator.Substring(0, colonIndex).Trim();
            string value = locator.Substring(colonIndex + 1).Trim();
            return this.Options.CreateLocator(prefix, this.Browser, this).Find(value, tag, required);
        }

        public bool IsEnabled
        {
            get
            {
                if (this.WebElement == null) return false;
                return this.WebElement.Enabled && this.WebElement.GetAttribute("readonly") == null && 
                    this.WebElement.GetAttribute("disabled") == null;
            }
        }

        public bool IsElementEnabled(string locator, string tag = null)
        {
            Element child = this.FindOne(locator, tag, false);
            return child != null && child.IsEnabled;
        }

        public bool IsVisible
        {
            get
            {
                if (this.WebElement == null) return false;
                return this.WebElement.Displayed;
            }
        }

        public bool IsElementVisible(string locator, string tag = null)
        {
            Element child = this.FindOne(locator, tag, false);
            return child != null && child.IsVisible;
        }

        public bool IsTextPresent(string text)
        {
            string locator = string.Format("xpath://*[contains(., {0})]", Utils.EscapeXpathValue(text));
            return this.FindOne(locator, null, false) != null;
        }

        public string LogElementSource(Microsoft.Extensions.Logging.LogLevel level = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            if (this.WebElement != null)
            {
                string source = this.WebElement.GetAttribute("innerHTML");
                this.Browser.Log(level, source);
                return source;
            }
            return null;
        }

        public AssertElementResult ShouldContainElement(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindOne(locator, tag, false);
            if (child == null)
            {
                this.LogElementSource(logLevel);
            }
            string successMessage = this.CapitalName() + " contains {0} '{1}'.";
            string failureMessage = message ?? this.CapitalName() + " should have contained {0} '{1}' but did not.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, tag ?? "element", locator);
        }

        public AssertElementResult ShouldNotContainElement(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindOne(locator, tag, false);
            if (child != null)
            {
                this.LogElementSource(logLevel);
            }
            string successMessage = this.CapitalName() + " does not contain {0} '{1}'.";
            string failureMessage = message ?? this.CapitalName() + " should not have contained {0} '{1}' but did not.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, tag ?? "element", locator);
        }

        public AssertionResult ShouldContainText(string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckElementContainsText(true, false, null, text, ignoreCase, message: message, logLevel: logLevel);
        }

        public AssertionResult ShouldNotContainText(string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckElementContainsText(false, false, null, text, ignoreCase, message: message, logLevel: logLevel);
        }

        public AssertionResult ElementShouldContainText(string locator, string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckElementContainsText(true, false, locator, text, ignoreCase, tag: null, message: message, logLevel: logLevel);
        }

        public AssertionResult ElementShouldNotContainText(string locator, string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckElementContainsText(false, false, locator, text, ignoreCase, tag: null, message: message, logLevel: logLevel);
        }

        public AssertionResult ShouldHaveText(string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckElementContainsText(true, true, null, text, ignoreCase, message: message, logLevel: logLevel);
        }

        public AssertionResult ShouldNotHaveText(string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckElementContainsText(false, true, null, text, ignoreCase, message: message, logLevel: logLevel);
        }

        public AssertionResult ElementShouldHaveText(string locator, string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckElementContainsText(true, true, locator, text, ignoreCase, tag: null, message: message, logLevel: logLevel);
        }

        public AssertionResult ElementShouldNotHaveText(string locator, string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckElementContainsText(false, true, locator, text, ignoreCase, tag: null, message: message, logLevel: logLevel);
        }

        private AssertionResult CheckElementContainsText(bool shouldContain, bool equals, string locator, string text, bool ignoreCase = false, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element element = null;
            string successMessage;
            string failureMessage;
            if (locator == null)
            {
                if (shouldContain)
                {
                    successMessage = this.CapitalName() + " contains text '{0}'.";
                    failureMessage = message ?? this.CapitalName() + " should have contained text '{0}' but its text was '{1}'.";
                }
                else
                {
                    successMessage = this.CapitalName() + " does not contain text '{0}'.";
                    failureMessage = message ?? this.CapitalName() + " should not have contained text '{0}' but its text was '{1}'.";
                }
                element = this;
            }
            else
            {
                if (shouldContain)
                {
                    successMessage = "{2} '{3}' contains text '{0}'.";
                    failureMessage = message ?? "{2} '{3}' should have contained text '{0}' but its text was '{1}'.";
                }
                else
                {
                    successMessage = "{2} '{3}' does not contain text '{0}'.";
                    failureMessage = message ?? "{2} '{3}' should not have contained text '{0}' but its text was '{1}'.";
                }
                var child = this.ShouldContainElement(locator, tag, logLevel: logLevel);
                if (child.Success)
                {
                    element = child.Element;
                }
                else
                {
                    return child;
                }
            }
            string elementText = element.Text;
            string actualText = elementText;
            string expectedText = text;
            if (ignoreCase)
            {
                actualText = actualText.ToLower();
                expectedText = expectedText.ToLower();
            }
            bool contains = equals ? expectedText == actualText : expectedText?.Contains(text) ?? false;
            bool success = (shouldContain && contains) || (!shouldContain && !contains);
            return this.Browser.AssertSuccess(success, successMessage, failureMessage, text, elementText, locator, tag);
        }

        public string GetAttribute(string name)
        {
            return this.WebElement?.GetAttribute(name);
        }

        public string GetElementAttribute(string locator, string name)
        {
            var child = this.FindOne(locator);
            return child?.GetAttribute(name);
        }

        public string GetCssValue(string name)
        {
            return this.WebElement?.GetCssValue(name);
        }

        public string GetElementCssValue(string locator, string name)
        {
            var child = this.FindOne(locator);
            return child?.GetCssValue(name);
        }

    }
}
