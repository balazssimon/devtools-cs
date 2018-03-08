using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class Element : IEquatable<Element>
    {
        public Element(Browser browser, Element parent, string locator, string tagKind, IWebElement webElement)
        {
            if (browser == null) throw new ArgumentNullException(nameof(browser));
            this.Browser = browser;
            this.Parent = parent;
            this.Locator = locator;
            this.TagKind = tagKind;
            this.WebElement = webElement;
        }

        public Element(Element element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            this.Browser = element.Browser;
            this.Parent = element.Parent;
            this.Locator = element.Locator;
            this.TagKind = element.TagKind;
            this.WebElement = element.WebElement;
        }


        public Browser Browser { get; }
        public Element Parent { get; }
        public string Locator { get; }
        public string TagKind { get; }
        public IWebElement WebElement { get; }

        public string Name
        {
            get
            {
                if (this.Locator == null) return "Page";
                else return this.TagKind ?? this.WebElement?.TagName ?? "Element";
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

        protected string LogName
        {
            get
            {
                if (this.Locator == null) return this.CapitalName();
                else return this.CapitalName() + " '" + this.Locator + "'";
            }
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

        public bool Exists
        {
            get { return this.Locator == null || this.WebElement != null; }
        }

        public Element FindElement(string locator, string tag = null, bool required = true)
        {
            return this.Options.CreateLocator(this.Browser, this, locator, tag, required).FindElement();
        }

        public ImmutableArray<Element> FindElements(string locator, string tag = null, bool required = true)
        {
            return this.Options.CreateLocator(this.Browser, this, locator, tag, required).FindElements();
        }

        public int GetElementCount(string locator)
        {
            return this.FindElements(locator, required: false).Length;
        }

        public AssertionResult LocatorShouldMatchNTimes(string locator, int n, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            int matchCount = this.GetElementCount(locator);
            return this.Browser.AssertSuccess(matchCount == n, "Locator '{2}' matches {1} times.", message ?? "Locator '{2}' should have matched {0} times but matched {1} times.", n, matchCount, locator);
        }

        public int GetMatchingXPathCount(string xpath)
        {
            return this.FindElements("xpath:" + xpath, required: false).Length;
        }

        public AssertionResult XPathShouldMatchNTimes(string xpath, int n, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            int matchCount = this.GetMatchingXPathCount(xpath);
            return this.Browser.AssertSuccess(matchCount == n, "XPath '{2}' matches {1} times.", message ?? "XPath '{2}' should have matched {0} times but matched {1} times.", n, matchCount, xpath);
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

        public bool IsVisible
        {
            get
            {
                if (this.WebElement == null) return false;
                return this.WebElement.Displayed;
            }
        }

        public bool IsFocused
        {
            get
            {
                if (this.WebElement == null) return false;
                return this.WebElement.Equals(this.Browser.Driver.SwitchTo().ActiveElement());
            }
        }

        public bool IsSelected
        {
            get
            {
                if (this.WebElement == null) return false;
                return this.WebElement.Selected;
            }
        }

        public string Source
        {
            get
            {
                return this.WebElement?.GetAttribute("innerHTML");
            }
        }

        public bool IsTextPresent(string text)
        {
            string locator = string.Format("xpath://*[contains(., {0})]", Utils.EscapeXpathValue(text));
            return this.FindElement(locator, required: false) != null;
        }

        public string LogSource(Microsoft.Extensions.Logging.LogLevel level = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            if (this.WebElement != null)
            {
                string source = this.Source;
                this.Browser.Log(level, source);
                return source;
            }
            return null;
        }

        public AssertElementResult ShouldContainElement(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElement(locator, tag, false);
            if (!child.Exists)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "{0} contains {1}.";
            string failureMessage = message ?? "{0} should have contained {1} but did not.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertElementResult ShouldNotContainElement(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElement(locator, tag, false);
            if (child.Exists)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "{0} does not contain {1}.";
            string failureMessage = message ?? "{0} should not have contained {1}.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertionResult ShouldContainText(string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckText(true, false, text, ignoreCase, message: message, logLevel: logLevel);
        }

        public AssertionResult ShouldNotContainText(string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckText(false, false, text, ignoreCase, message: message, logLevel: logLevel);
        }

        public AssertionResult ShouldHaveText(string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckText(true, true, text, ignoreCase, message: message, logLevel: logLevel);
        }

        public AssertionResult ShouldNotHaveText(string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.CheckText(false, true, text, ignoreCase, message: message, logLevel: logLevel);
        }

        private AssertionResult CheckText(bool shouldContain, bool equals, string text, bool ignoreCase = false, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            string successMessage;
            string failureMessage;
            if (shouldContain)
            {
                successMessage = "{0} contains text '{1}'.";
                failureMessage = message ?? "{0} should have contained text '{1}' but its text was '{2}'.";
            }
            else
            {
                successMessage = "{0} does not contain text '{1}'.";
                failureMessage = message ?? "{0} should not have contained text '{1}' but its text was '{2}'.";
            }
            string elementText = this.Text;
            string actualText = elementText;
            string expectedText = text;
            if (ignoreCase)
            {
                actualText = actualText.ToLower();
                expectedText = expectedText.ToLower();
            }
            bool contains = equals ? expectedText == actualText : expectedText?.Contains(text) ?? false;
            bool success = (shouldContain && contains) || (!shouldContain && !contains);
            return this.Browser.AssertSuccess(success, successMessage, failureMessage, this.LogName, text, elementText);
        }

        public string GetAttribute(string name)
        {
            return this.WebElement?.GetAttribute(name);
        }

        public string GetCssValue(string name)
        {
            return this.WebElement?.GetCssValue(name);
        }

        public AssertionResult ShouldBeEnabled()
        {
            return this.Browser.AssertSuccess(this.IsEnabled, "{0} is enabled.", "{0} should have been enabled.", this.LogName);
        }

        public AssertionResult ShouldBeDisabled()
        {
            return this.Browser.AssertSuccess(!this.IsEnabled, "{0} is disabled.", "{0} should have been disabled.", this.LogName);
        }

        public AssertionResult ShouldBeVisible()
        {
            return this.Browser.AssertSuccess(this.IsVisible, "{0} is visible.", "{0} should have been visible.", this.LogName);
        }

        public AssertionResult ShouldNotBeVisible()
        {
            return this.Browser.AssertSuccess(!this.IsVisible, "{0} is not visible.", "{0} should not have been visible.", this.LogName);
        }

        public AssertionResult ShouldBeFocused()
        {
            return this.Browser.AssertSuccess(this.IsFocused, "{0} is focused.", "{0} should have been focused.", this.LogName);
        }

        public AssertionResult ShouldNotBeFocused()
        {
            return this.Browser.AssertSuccess(!this.IsFocused, "{0} is not focused.", "{0} should not have been focused.", this.LogName);
        }

        public AssertionResult ShouldBeSelected()
        {
            return this.Browser.AssertSuccess(this.IsSelected, "{0} is selected.", "{0} should have been selected.", this.LogName);
        }

        public AssertionResult ShouldNotBeSelected()
        {
            return this.Browser.AssertSuccess(!this.IsSelected, "{0} is not selected.", "{0} should not have been selected.", this.LogName);
        }

        public void ClearText()
        {
            this.WebElement?.Clear();
        }

        public void Click()
        {
            this.WebElement?.Click();
        }

        public void Select()
        {
            if (this.WebElement == null) return;
            if (!this.WebElement.Selected)
            {
                this.WebElement.Click();
            }
        }

        public void Unselect()
        {
            if (this.WebElement == null) return;
            if (this.WebElement.Selected)
            {
                this.WebElement.Click();
            }
        }

        public void DoubleClick()
        {
            // TODO
        }

        public void Focus()
        {
            var javaScriptExecutor = this.Browser.Driver as IJavaScriptExecutor;
            if (javaScriptExecutor != null)
            {
                javaScriptExecutor.ExecuteScript("arguments[0].focus();", this);
            }
        }

        public void TypeText(string text)
        {
            this.WebElement?.SendKeys(text);
        }

        public Element GetLink(string locator)
        {
            return this.FindElement(locator, "link", required: false);
        }

        public ImmutableArray<Element> GetAllLinks()
        {
            return this.FindElements("tag:a", "link", required: false);
        }

        public AssertElementResult ShouldContainLink(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldContainElement(locator, "link", message, logLevel);
        }

        public AssertElementResult ShouldNotContainLink(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldNotContainElement(locator, "link", message, logLevel);
        }

        public Form GetForm(string locator)
        {
            return new Form(this.FindElement(locator, "form", required: false));
        }

        public ImmutableArray<Form> GetAllForms()
        {
            return this.FindElements("tag:form", "form", required: false).Select(e => new Form(e)).ToImmutableArray();
        }

        public AssertFormResult ShouldContainForm(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Form child = this.GetForm(locator);
            if (!child.Exists)
            {
                this.LogSource(logLevel);
            }
            string childName = "form '" + locator + " ";
            string successMessage = "{0} contains {1}.";
            string failureMessage = message ?? "{0} should have contained {1} but did not.";
            return this.Browser.AssertForm(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertFormResult ShouldNotContainForm(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Form child = this.GetForm(locator);
            if (child.Exists)
            {
                this.LogSource(logLevel);
            }
            string childName = "form '" + locator + " ";
            string successMessage = "{0} does not contain {1}.";
            string failureMessage = message ?? "{0} should not have contained {1}.";
            return this.Browser.AssertForm(child, successMessage, failureMessage, this.LogName, childName);
        }

        public Element GetCheckBox(string locator)
        {
            return this.FindElement(locator, tag: "checkbox", required: false);
        }

        public ImmutableArray<Element> GetAllCheckBoxes()
        {
            return this.FindElements("tag:input", "checkbox", required: false);
        }

        public AssertElementResult ShouldContainCheckBox(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldContainElement(locator, "checkbox", message, logLevel);
        }

        public AssertElementResult ShouldNotContainCheckBox(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldNotContainElement(locator, "checkbox", message, logLevel);
        }

        public void ChooseFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                this.Browser.LogError("File '{0}' does not exist on the local file system.", filePath);
                throw new InvalidOperationException(string.Format("File '{0}' does not exist on the local file system.", filePath));
            }
            this.TypeText(filePath);
        }

        public Element GetTextField(string locator)
        {
            return this.FindElement(locator, "text field", required: false);
        }

        public ImmutableArray<Element> GetAllTextFields()
        {
            return this.FindElements("tag:input", "text field", required: false);
        }

        public AssertElementResult ShouldContainTextField(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldContainElement(locator, "text field", message, logLevel);
        }

        public AssertElementResult ShouldNotContainTextField(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldNotContainElement(locator, "text field", message, logLevel);
        }


        public Element GetTextArea(string locator)
        {
            return this.FindElement(locator, "text area", required: false);
        }

        public ImmutableArray<Element> GetAllTextAreas()
        {
            return this.FindElements("tag:input", "text area", required: false);
        }

        public AssertElementResult ShouldContainTextArea(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldContainElement(locator, "text area", message, logLevel);
        }

        public AssertElementResult ShouldNotContainTextArea(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldNotContainElement(locator, "text area", message, logLevel);
        }


        public Element GetButton(string locator)
        {
            return this.FindElement(locator, "button", required: false);
        }

        public ImmutableArray<Element> GetAllButtons()
        {
            return this.FindElements("tag:button", required: false);
        }

        public AssertElementResult ShouldContainButton(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldContainElement(locator, "button", message, logLevel);
        }

        public AssertElementResult ShouldNotContainButton(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldNotContainElement(locator, "button", message, logLevel);
        }


        public RadioGroup GetRadioGroup(string groupName)
        {
            var xpath = string.Format("xpath://input[@type='radio' and @name='{0}']", groupName);
            var items = this.FindElements(xpath, required: false);
            return new RadioGroup(this.Browser, this, xpath, "radio group", groupName, items);
        }

        public AssertRadioGroupResult ShouldContainRadioGroup(string groupName, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            RadioGroup child = this.GetRadioGroup(groupName);
            if (!child.Exists)
            {
                this.LogSource(logLevel);
            }
            string childName = "radio group '" + groupName + " ";
            string successMessage = "{0} contains {1}.";
            string failureMessage = message ?? "{0} should have contained {1} but did not.";
            return this.Browser.AssertRadioGroup(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertRadioGroupResult ShouldNotContainRadioGroup(string groupName, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            RadioGroup child = this.GetRadioGroup(groupName);
            if (child.Exists)
            {
                this.LogSource(logLevel);
            }
            string childName = "radio group '" + groupName + " ";
            string successMessage = "{0} does not contain {1}.";
            string failureMessage = message ?? "{0} should not have contained {1}.";
            return this.Browser.AssertRadioGroup(child, successMessage, failureMessage, this.LogName, childName);
        }


        public Element GetRadioButton(string locator)
        {
            return this.FindElement(locator, tag: "radio button", required: false);
        }

        public AssertElementResult ShouldContainRadioButton(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldContainElement(locator, "radio button", message, logLevel);
        }

        public AssertElementResult ShouldNotContainRadioButton(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return this.ShouldNotContainElement(locator, "radio button", message, logLevel);
        }


        public List GetList(string locator)
        {
            return new List(this.FindElement(locator, "list", required: false));
        }

        public ImmutableArray<List> GetAllLists()
        {
            return this.FindElements("tag:list", required: false).Select(e => new List(e)).ToImmutableArray();
        }

        public AssertListResult ShouldContainList(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            List child = this.GetList(locator);
            if (child.WebElement == null)
            {
                this.LogSource(logLevel);
            }
            string childName = "list '" + locator + " ";
            string successMessage = "{0} contains {1}.";
            string failureMessage = message ?? "{0} should have contained {1} but did not.";
            return this.Browser.AssertList(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertListResult ShouldNotContainList(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            List child = this.GetList(locator);
            if (child.WebElement != null)
            {
                this.LogSource(logLevel);
            }
            string childName = "list '" + locator + " ";
            string successMessage = "{0} does not contain {1}.";
            string failureMessage = message ?? "{0} should not have contained {1}.";
            return this.Browser.AssertList(child, successMessage, failureMessage, this.LogName, childName);
        }


        public Table GetTable(string locator)
        {
            return new Table(this.FindElement(locator, "table", required: false));
        }

        public ImmutableArray<Table> GetAllTables()
        {
            return this.FindElements("tag:table", required: false).Select(e => new Table(e)).ToImmutableArray();
        }

        public AssertTableResult ShouldContainTable(string locator, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Table child = this.GetTable(locator);
            if (child.WebElement == null)
            {
                this.LogSource(logLevel);
            }
            string childName = "table '" + locator + " ";
            string successMessage = "{0} contains {1}.";
            string failureMessage = message ?? "{0} should have contained {1} but did not.";
            return this.Browser.AssertTable(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertTableResult ShouldNotContainTable(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Table child = this.GetTable(locator);
            if (child.WebElement != null)
            {
                this.LogSource(logLevel);
            }
            string childName = "table '" + locator + " ";
            string successMessage = "{0} does not contain {1}.";
            string failureMessage = message ?? "{0} should not have contained {1}.";
            return this.Browser.AssertTable(child, successMessage, failureMessage, this.LogName, childName);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Element);
        }

        public bool Equals(Element element)
        {
            if (element == null) return false;
            return this.WebElement?.Equals(element.WebElement) ?? false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
