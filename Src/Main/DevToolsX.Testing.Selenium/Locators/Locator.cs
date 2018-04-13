using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public abstract class Locator
    {
        private static readonly Dictionary<string, TagInfo> tags = new Dictionary<string, TagInfo>();

        static Locator()
        {
            var link = new TagInfo("link", "a");
            tags.Add(link.Name, link);

            var partialLink = new TagInfo("partial link", "a");
            tags.Add(partialLink.Name, partialLink);

            var image = new TagInfo("image", "img");
            tags.Add(image.Name, image);

            var list = new TagInfo("list", "select");
            tags.Add(list.Name, list);

            var radioButton = new TagInfo("radio button", "input");
            radioButton.Attributes.Add("type", new string[] { "radio" });
            tags.Add(radioButton.Name, radioButton);

            var checkBox = new TagInfo("checkbox", "input");
            checkBox.Attributes.Add("type", new string[] { "checkbox" });
            tags.Add(checkBox.Name, checkBox);

            var textField = new TagInfo("text field", "input");
            textField.Attributes.Add("type", new string[] { "date", "datetime-local", "email", "month", "number", "password", "search", "tel", "text", "time", "url", "week", "file" });
            tags.Add(textField.Name, textField);

            var fileUpload = new TagInfo("file upload", "input");
            fileUpload.Attributes.Add("type", new string[] { "file" });
            tags.Add(fileUpload.Name, fileUpload);

            var textArea = new TagInfo("text area", "input");
            textArea.Attributes.Add("type", new string[] { "textarea" });
            tags.Add(textArea.Name, textArea);
        }

        public Locator(Browser browser, Element parent, string locatorText, string tag, bool required)
        {
            if (locatorText == null) throw new ArgumentException($"Invalid locator syntax '{locatorText}'. Locators should start with a registered locator prefix.");
            int colonIndex = locatorText.IndexOf(':');
            if (colonIndex < 0) throw new ArgumentException($"Invalid locator syntax '{locatorText}'. Locators should start with a registered locator prefix.");
            this.Browser = browser;
            this.Parent = parent;
            this.LocatorText = locatorText;
            this.Tag = tag;
            this.Required = required;
            this.Prefix = locatorText.Substring(0, colonIndex).Trim();
            this.Value = locatorText.Substring(colonIndex + 1).Trim();
        }

        public Browser Browser { get; private set; }
        public Element Parent { get; private set; }
        public string LocatorText { get; private set; }
        public string Prefix { get; private set; }
        public string Value { get; private set; }
        public string Tag { get; private set; }
        public bool Required { get; private set; }

        public IWebDriver Driver
        {
            get { return this.Browser.Driver; }
        }

        public Options Options
        {
            get { return this.Browser.Options; }
        }

        public ILogger Logger
        {
            get { return this.Browser.Logger; }
        }

        public IWebElement ParentWebElement
        {
            get { return this.Parent?.WebElement; }
        }

        protected ISearchContext SearchContext
        {
            get { return (ISearchContext)this.ParentWebElement ?? this.Browser.Driver; }
        }


        protected void LogTrace(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Trace, message, args);
        }

        protected void LogDebug(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Debug, message, args);
        }

        protected void LogInformation(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Information, message, args);
        }

        protected void LogWarning(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Warning, message, args);
        }

        protected void LogError(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Error, message, args);
        }

        protected void LogCritical(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Critical, message, args);
        }

        protected void Log(Microsoft.Extensions.Logging.LogLevel logLevel, string message, params object[] args)
        {
            this.Browser.Log(logLevel, message, args);
        }

        protected void LogTrace(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Trace, exception, message, args);
        }

        protected void LogDebug(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Debug, exception, message, args);
        }

        protected void LogInformation(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Information, exception, message, args);
        }

        protected void LogWarning(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Warning, exception, message, args);
        }

        protected void LogError(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Error, exception, message, args);
        }

        protected void LogCritical(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Critical, exception, message, args);
        }

        protected void Log(Microsoft.Extensions.Logging.LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            this.Browser.Log(logLevel, exception, message, args);
        }

        public Element FindElement()
        {
            return this.FindElement(this.Required ? this.Options.TimeOutForGet : this.Options.TimeOutForFind);
        }

        public Element FindElement(TimeSpan timeout)
        {
            ImmutableArray<Element> result = this.FindElementsWithTimeout(timeout);
            if (result.Length == 0 || result.Length > 1)
            {
                Element nullResult = new Element(this.Browser, this.Parent, this.LocatorText, this.Tag, null);
                if (result.Length > 1) this.Browser.AssertElement(nullResult, null, "More than one {0} found in {1}.", nullResult, nullResult.Parent);
                else if (this.Required) this.Browser.AssertElement(nullResult, null, "{0} not found in {1}.", nullResult, nullResult.Parent);
                return nullResult;
            }
            return result[0];
        }

        public ImmutableArray<Element> FindElements()
        {
            return this.FindElements(this.Required ? this.Options.TimeOutForGet : this.Options.TimeOutForFind);
        }

        public ImmutableArray<Element> FindElements(TimeSpan timeout)
        {
            ImmutableArray<Element> result = ImmutableArray<Element>.Empty;
            result = this.FindElementsWithTimeout(timeout);
            if (this.Required && result.Length == 0) this.Browser.AssertElement(new Element(this.Browser, this.Parent, this.LocatorText, this.Tag, null));
            return result;
        }

        private ImmutableArray<Element> FindElementsWithTimeout(TimeSpan timeout)
        {
            ImmutableArray<Element> result = ImmutableArray<Element>.Empty;
            Exception exception = null;
            this.Browser.Wait.Until(
                wd =>
                {
                    try
                    {
                        exception = null;
                        result = this.DoFindElements();
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                    }
                    return result.Length > 0;
                }, timeout: timeout);
            if (exception != null)
            {
                Element nullResult = new Element(this.Browser, this.Parent, this.LocatorText, this.Tag, null);
                this.LogError(exception, "Error executing locator {0} in {1}.", nullResult, nullResult.Parent);
            }
            return result;
        }

        protected abstract ImmutableArray<Element> DoFindElements();

        protected ImmutableArray<Element> FilterElements(IEnumerable<IWebElement> webElements)
        {
            List<Element> result = new List<Element>();
            foreach (var webElement in webElements)
            {
                if (Locator.ElementMatches(webElement, this.Tag))
                {
                    result.Add(new Element(this.Browser, this.Parent, this.LocatorText, this.Tag, webElement));
                }
            }
            return result.ToImmutableArray();
        }

        protected static bool ElementMatches(IWebElement element, string tag)
        {
            if (tag == null) return true;
            if (Locator.tags.TryGetValue(tag, out TagInfo tagInfo))
            {
                if (element.TagName.ToLower() != tagInfo.TagName) return false;
                foreach (var attrName in tagInfo.Attributes.Keys)
                {
                    string elementAttrValue = element.GetAttribute(attrName);
                    string[] attrValues = tagInfo.Attributes[attrName];
                    if (!attrValues.Contains(elementAttrValue)) return false;
                }
            }
            else
            {
                return element.TagName.ToLower() == tag.ToLower();
            }
            return true;
        }

        protected static string GetXPathConstraint(string name, string value)
        {
            return string.Format("@{0}='{1}'", name, value);
        }

        protected static string GetXPathConstraint(string name, string[] values)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("@");
            sb.Append(name);
            sb.Append("[. = '");
            for (int i = 0; i < values.Length; i++)
            {
                sb.Append(values[i]);
                if (i < values.Length)
                {
                    sb.Append("' or . = '");
                }
            }
            sb.Append("']");
            return sb.ToString();
        }

        private class TagInfo
        {
            public string Name { get; }
            public string TagName { get; }
            public Dictionary<string,string[]> Attributes { get; }

            public TagInfo(string name, string tagName)
            {
                this.Name = name;
                this.TagName = tagName;
                this.Attributes = new Dictionary<string, string[]>();
            }
        }
    }
}
