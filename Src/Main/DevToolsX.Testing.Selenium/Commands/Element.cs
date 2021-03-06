﻿using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    internal class MarkState
    {
        private static ConditionalWeakTable<Element, MarkState> markStates = new ConditionalWeakTable<Element, MarkState>();

        private MarkState(Element element, string styleBeforeMark)
        {
            this.MarkedElement = element;
            this.StyleBeforeMark = styleBeforeMark;
        }

        public Element MarkedElement { get; }
        public string StyleBeforeMark { get; }

        public static void Mark(Element element)
        {
            if (element == null || element.WebElement == null || element.Browser.JavaScript == null) return;
            MarkState markState;
            if (MarkState.markStates.TryGetValue(element, out markState)) return;
            string saveMarkStateCode =
                @"var style = window.getComputedStyle(arguments[0], null); return [style.getPropertyValue('border'), style.getPropertyValue('border-color'), style.getPropertyValue('border-style')];";
            element.Browser.LogDebug("Executing JavaScript: {0}", saveMarkStateCode);
            string[] styleString = element.Browser.JavaScript.Execute(saveMarkStateCode, element.WebElement) as string[];
            string styleBeforeMark =
                @"arguments[0].style.border = 0; arguments[0].style.borderColor = ''; arguments[0].style.borderStyle = '';";
            if (styleString != null && styleString.Length == 3)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("arguments[0].style.border = '");
                if (!string.IsNullOrWhiteSpace(styleString[0]))
                {
                    sb.Append(styleString[0]);
                }
                sb.Append("'; ");
                sb.Append("arguments[0].style.borderColor = '");
                if (!string.IsNullOrWhiteSpace(styleString[1]))
                {
                    sb.Append(styleString[1]);
                }
                sb.Append("'; ");
                sb.Append("arguments[0].style.borderStyle = '");
                if (!string.IsNullOrWhiteSpace(styleString[2]))
                {
                    sb.Append(styleString[2]);
                }
                sb.Append("'; ");
                styleBeforeMark = sb.ToString();
            }
            styleBeforeMark = @"arguments[0].style.outline = ''; arguments[0].style.outlineOffset = '';";
            MarkState.markStates.Add(element, new MarkState(element, styleBeforeMark));
            string markCode =
                @"arguments[0].style.outline = 'red solid 4px'; arguments[0].style.outlineOffset = '-4px';";
            //@"arguments[0].style.setProperty('border', '4px', 'important'); arguments[0].style.setProperty('border-color', 'red', 'important'); arguments[0].style.setProperty('border-style', 'solid', 'important');";
            element.Browser.LogDebug("Executing JavaScript: {0}", markCode);
            element.Browser.JavaScript.Execute(markCode, element.WebElement);
        }

        public static void Unmark(Element element)
        {
            if (element == null || element.WebElement == null || element.Browser.JavaScript == null) return;
            MarkState markState;
            if (MarkState.markStates.TryGetValue(element, out markState))
            {
                element.Browser.LogDebug("Executing JavaScript: {0}", markState.StyleBeforeMark);
                element.Browser.JavaScript.Execute(markState.StyleBeforeMark, element.WebElement);
            }
        }
    }

    public class Element : IEquatable<Element>
    {
        private ElementWait cachedWait;

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
        public IWebElement WebElement { get; private set; }

        internal void UpdateWebElement(IWebElement webElement)
        {
            this.WebElement = webElement;
        }

        public ElementWait Wait
        {
            get
            {
                if (this.cachedWait == null) this.cachedWait = new ElementWait(this);
                return this.cachedWait;
            }
        }

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

        internal string LogName
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

        public Element FindAncestorElement(string tag = null, bool required = false)
        {
            return this.Options.CreateLocator(this.Browser, this, string.Format("xpath:./ancestor::{0}", tag ?? "*"), null, required).FindElement();
        }

        public Element GetAncestorElement(string tag = null)
        {
            return this.FindAncestorElement(tag, true);
        }

        public Element FindParentElement(string tag = null, bool required = false)
        {
            return this.Options.CreateLocator(this.Browser, this, string.Format("xpath:./parent::{0}", tag ?? "*"), null, required).FindElement();
        }

        public Element GetParentElement(string tag = null)
        {
            return this.FindParentElement(tag, true);
        }

        public Element FindElement(string locator, string tag = null, bool required = false)
        {
            var result = this.InternalFindElement(locator, tag, required);
            if (result.WebElement != null)
            {
                this.Logger.LogInformation("{0} found in {1}.", this.LogName, this.Parent?.LogName ?? "browser");
            }
            return result;
        }

        public ImmutableArray<Element> FindElements(string locator, string tag = null, bool required = false)
        {
            return this.InternalFindElements(locator, tag, required);
        }

        internal Element InternalFindElement(string locator, string tag = null, bool required = false)
        {
            return this.Options.CreateLocator(this.Browser, this, locator, tag, required).FindElement();
        }

        internal ImmutableArray<Element> InternalFindElements(string locator, string tag = null, bool required = false)
        {
            return this.Options.CreateLocator(this.Browser, this, locator, tag, required).FindElements();
        }

        public Element GetElement(string locator, string tag = null)
        {
            return this.FindElement(locator, tag, true);
        }

        public ImmutableArray<Element> GetElements(string locator, string tag = null)
        {
            return this.FindElements(locator, tag, true);
        }

        public int GetElementCount(string locator)
        {
            return this.InternalFindElements(locator).Length;
        }

        public int LocatorShouldMatchNTimes(string locator, int n)
        {
            int matchCount = this.GetElementCount(locator);
            this.Browser.AssertSuccess(matchCount == n, "Locator '{2}' matches {1} times.", "Locator '{2}' should have matched {0} times but matched {1} times.", n, matchCount, locator);
            return matchCount;
        }

        public int GetMatchingXPathCount(string xpath)
        {
            return this.InternalFindElements("xpath:" + xpath).Length;
        }

        public int XPathShouldMatchNTimes(string xpath, int n)
        {
            int matchCount = this.GetMatchingXPathCount(xpath);
            this.Browser.AssertSuccess(matchCount == n, "XPath '{2}' matches {1} times.", "XPath '{2}' should have matched {0} times but matched {1} times.", n, matchCount, xpath);
            return matchCount;
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

        public bool ContainsText(string text)
        {
            string locator = string.Format("xpath:.//*[contains(., '{0}')]", text.Replace("'", "\\'"));
            return this.InternalFindElements(locator).Length > 0;
        }

        public string LogSource(Microsoft.Extensions.Logging.LogLevel level = Microsoft.Extensions.Logging.LogLevel.Debug)
        {
            if (this.WebElement != null)
            {
                string source = this.Source;
                this.Browser.Log(level, source);
                return source;
            }
            return null;
        }

        public Element ShouldContainElement(string locator, string tag = null, string message = null)
        {
            Element child = this.InternalFindElement(locator, tag);
            string successMessage = "{0} contains {1}.";
            string failureMessage = message ?? "{0} should have contained {1} but did not.";
            return this.Browser.AssertElement(this.InternalFindElement(locator, tag), successMessage, failureMessage, this.LogName, child.LogName);
        }

        public Element ShouldNotContainElement(string locator, string tag = null, string message = null)
        {
            Element child = this.InternalFindElement(locator, tag);
            string successMessage = "{0} does not contain {1}.";
            string failureMessage = message ?? "{0} should not have contained {1}.";
            return this.Browser.AssertElement(child, !child.Exists, successMessage, failureMessage, this.LogName, child.LogName);
        }

        public string ShouldContainText(string text, bool ignoreCase = false, string message = null)
        {
            return this.CheckText(true, false, text, ignoreCase, message);
        }

        public string ShouldNotContainText(string text, bool ignoreCase = false, string message = null)
        {
            return this.CheckText(false, false, text, ignoreCase, message);
        }

        public string ShouldHaveText(string text, bool ignoreCase = false, string message = null)
        {
            return this.CheckText(true, true, text, ignoreCase, message);
        }

        public string ShouldNotHaveText(string text, bool ignoreCase = false, string message = null)
        {
            return this.CheckText(false, true, text, ignoreCase, message);
        }

        private string CheckText(bool shouldContain, bool equals, string text, bool ignoreCase = false, string message = null)
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
            this.Browser.AssertSuccess(success, successMessage, failureMessage, this.LogName, text, elementText);
            return elementText;
        }

        public string GetAttribute(string name)
        {
            return this.WebElement?.GetAttribute(name);
        }

        public string GetCssValue(string name)
        {
            return this.WebElement?.GetCssValue(name);
        }

        public bool ShouldBeEnabled()
        {
            return this.Browser.AssertSuccess(this.IsEnabled, "{0} is enabled.", "{0} should have been enabled.", this.LogName);
        }

        public bool ShouldBeDisabled()
        {
            return this.Browser.AssertSuccess(!this.IsEnabled, "{0} is disabled.", "{0} should have been disabled.", this.LogName);
        }

        public bool ShouldBeVisible()
        {
            return this.Browser.AssertSuccess(this.IsVisible, "{0} is visible.", "{0} should have been visible.", this.LogName);
        }

        public bool ShouldNotBeVisible()
        {
            return this.Browser.AssertSuccess(!this.IsVisible, "{0} is not visible.", "{0} should not have been visible.", this.LogName);
        }

        public bool ShouldBeFocused()
        {
            return this.Browser.AssertSuccess(this.IsFocused, "{0} is focused.", "{0} should have been focused.", this.LogName);
        }

        public bool ShouldNotBeFocused()
        {
            return this.Browser.AssertSuccess(!this.IsFocused, "{0} is not focused.", "{0} should not have been focused.", this.LogName);
        }

        public bool ShouldBeSelected()
        {
            return this.Browser.AssertSuccess(this.IsSelected, "{0} is selected.", "{0} should have been selected.", this.LogName);
        }

        public bool ShouldNotBeSelected()
        {
            return this.Browser.AssertSuccess(!this.IsSelected, "{0} is not selected.", "{0} should not have been selected.", this.LogName);
        }

        public void ClearText()
        {
            this.WebElement?.Clear();
        }

        public void Click(bool directClick = false)
        {
            if (this.WebElement == null) return;
            if (directClick) this.Browser.JavaScript.Execute("arguments[0].click();", this.WebElement);
            else this.WebElement.Click();
        }

        public void Select(bool directClick = false)
        {
            if (this.WebElement == null) return;
            if (!this.WebElement.Selected)
            {
                this.Click(directClick);
            }
        }

        public void Unselect(bool directClick = false)
        {
            if (this.WebElement == null) return;
            if (this.WebElement.Selected)
            {
                this.Click(directClick);
            }
        }

        public void SetCheckBox(bool isSelected)
        {
            if (this.IsSelected)
            {
                if (!isSelected) this.Unselect(true);
            }
            else
            {
                if (isSelected) this.Select(true);
            }
        }

        public void DoubleClick()
        {
            // TODO
        }

        public void ScrollIntoView()
        {
            if (this.WebElement == null) return;
            this.Browser.JavaScript.Execute("arguments[0].scrollIntoView(true);", this.WebElement);
        }

        public void Focus()
        {
            if (this.WebElement == null) return;
            this.Browser.JavaScript.Execute("arguments[0].focus();", this.WebElement);
        }

        public void TypeText(string text, bool clear = true)
        {
            if (clear) this.ClearText();
            this.WebElement?.SendKeys(text);
        }


        public Element FindLink(string locator)
        {
            return this.InternalFindElement(locator, "link");
        }

        public Element GetLink(string locator)
        {
            return this.GetElement(locator, "link");
        }

        public ImmutableArray<Element> FindAllLinks()
        {
            return this.InternalFindElements("tag:a", "link");
        }

        public Element ShouldContainLink(string locator, string message = null)
        {
            return this.ShouldContainElement(locator, "link", message);
        }

        public Element ShouldNotContainLink(string locator, string message = null)
        {
            return this.ShouldNotContainElement(locator, "link", message);
        }


        public Form FindForm(string locator)
        {
            return new Form(this.InternalFindElement(locator, "form"));
        }

        public Form GetForm(string locator)
        {
            return new Form(this.GetElement(locator, "form"));
        }

        public ImmutableArray<Form> FindAllForms()
        {
            return this.InternalFindElements("tag:form", "form").Select(e => new Form(e)).ToImmutableArray();
        }

        public Form ShouldContainForm(string locator, string message = null)
        {
            return new Form(this.ShouldContainElement(locator, "form", message));
        }

        public Form ShouldNotContainForm(string locator, string message = null)
        {
            return new Form(this.ShouldNotContainElement(locator, "form", message));
        }


        public Element FindLabel(string locator)
        {
            return this.InternalFindElement(locator, tag: "label");
        }

        public Element GetLabel(string locator)
        {
            return this.GetElement(locator, tag: "label");
        }

        public ImmutableArray<Element> FindAllLabels()
        {
            return this.InternalFindElements("tag:input", "label");
        }

        public Element ShouldContainLabel(string locator, string message = null)
        {
            return this.ShouldContainElement(locator, "label", message);
        }

        public Element ShouldNotContainLabel(string locator, string message = null)
        {
            return this.ShouldNotContainElement(locator, "label", message);
        }


        public Element FindCheckBox(string locator)
        {
            return this.InternalFindElement(locator, tag: "checkbox");
        }

        public Element GetCheckBox(string locator)
        {
            return this.GetElement(locator, tag: "checkbox");
        }

        public ImmutableArray<Element> FindAllCheckBoxes()
        {
            return this.InternalFindElements("tag:input", "checkbox");
        }

        public Element ShouldContainCheckBox(string locator, string message = null)
        {
            return this.ShouldContainElement(locator, "checkbox", message);
        }

        public Element ShouldNotContainCheckBox(string locator, string message = null)
        {
            return this.ShouldNotContainElement(locator, "checkbox", message);
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


        public Element FindTextField(string locator)
        {
            return this.InternalFindElement(locator, "text field");
        }

        public Element GetTextField(string locator)
        {
            return this.GetElement(locator, "text field");
        }

        public ImmutableArray<Element> FindAllTextFields()
        {
            return this.InternalFindElements("tag:input", "text field");
        }

        public Element ShouldContainTextField(string locator, string message = null)
        {
            return this.ShouldContainElement(locator, "text field", message);
        }

        public Element ShouldNotContainTextField(string locator, string message = null)
        {
            return this.ShouldNotContainElement(locator, "text field", message);
        }


        public Element FindTextArea(string locator)
        {
            return this.InternalFindElement(locator, "text area");
        }

        public Element GetTextArea(string locator)
        {
            return this.GetElement(locator, "text area");
        }

        public ImmutableArray<Element> FindAllTextAreas()
        {
            return this.InternalFindElements("tag:input", "text area");
        }

        public Element ShouldContainTextArea(string locator, string message = null)
        {
            return this.ShouldContainElement(locator, "text area", message);
        }

        public Element ShouldNotContainTextArea(string locator, string message = null)
        {
            return this.ShouldNotContainElement(locator, "text area", message);
        }


        public Element FindButton(string locator)
        {
            return this.InternalFindElement(locator, "button");
        }

        public Element GetButton(string locator)
        {
            return this.GetElement(locator, "button");
        }

        public ImmutableArray<Element> FindAllButtons()
        {
            return this.InternalFindElements("tag:button");
        }

        public Element ShouldContainButton(string locator, string message = null)
        {
            return this.ShouldContainElement(locator, "button", message);
        }

        public Element ShouldNotContainButton(string locator, string message = null)
        {
            return this.ShouldNotContainElement(locator, "button", message);
        }


        public RadioGroup FindRadioGroup(string groupName)
        {
            var xpath = string.Format("xpath://input[@type='radio' and @name='{0}']", groupName);
            var items = this.InternalFindElements(xpath);
            return new RadioGroup(this.Browser, this, xpath, "radio group", groupName, items);
        }

        public RadioGroup GetRadioGroup(string groupName)
        {
            var xpath = string.Format("xpath://input[@type='radio' and @name='{0}']", groupName);
            var items = this.GetElements(xpath);
            return new RadioGroup(this.Browser, this, xpath, "radio group", groupName, items);
        }

        public RadioGroup ShouldContainRadioGroup(string groupName, string message = null)
        {
            var xpath = string.Format("xpath://input[@type='radio' and @name='{0}']", groupName);
            this.ShouldContainElement(xpath, "radio group", message);
            return this.GetRadioGroup(groupName);
        }

        public RadioGroup ShouldNotContainRadioGroup(string groupName, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            var xpath = string.Format("xpath://input[@type='radio' and @name='{0}']", groupName);
            this.ShouldNotContainElement(xpath, "radio group", message);
            return this.FindRadioGroup(groupName);
        }


        public Element FindRadioButton(string locator)
        {
            return this.InternalFindElement(locator, tag: "radio button");
        }

        public Element GetRadioButton(string locator)
        {
            return this.GetElement(locator, tag: "radio button");
        }

        public Element ShouldContainRadioButton(string locator, string message = null)
        {
            return this.ShouldContainElement(locator, "radio button", message);
        }

        public Element ShouldNotContainRadioButton(string locator, string message = null)
        {
            return this.ShouldNotContainElement(locator, "radio button", message);
        }


        public List FindList(string locator)
        {
            return new List(this.InternalFindElement(locator, "list"));
        }

        public List GetList(string locator)
        {
            return new List(this.GetElement(locator, "list"));
        }

        public ImmutableArray<List> FindAllLists()
        {
            return this.InternalFindElements("tag:list").Select(e => new List(e)).ToImmutableArray();
        }

        public List ShouldContainList(string locator, string message = null)
        {
            return new List(this.ShouldContainElement(locator, "list", message));
        }

        public List ShouldNotContainList(string locator, string tag = null, string message = null)
        {
            return new List(this.ShouldNotContainElement(locator, "list", message));
        }


        public Table FindTable(string locator, string tag = "table")
        {
            return new Table(this.InternalFindElement(locator, tag));
        }

        public Table GetTable(string locator, string tag = "table")
        {
            return new Table(this.GetElement(locator, tag));
        }

        public ImmutableArray<Table> FindAllTables(string tag = "table")
        {
            return this.InternalFindElements(string.Format("tag:{0}", tag)).Select(e => new Table(e)).ToImmutableArray();
        }

        public Table ShouldContainTable(string locator, string tag = "table", string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return new Table(this.ShouldContainElement(locator, tag, message));
        }

        public Table ShouldNotContainTable(string locator, string tag = "table", string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            return new Table(this.ShouldNotContainElement(locator, tag, message));
        }

        public void Mark()
        {
            MarkState.Mark(this);
        }

        public void Unmark()
        {
            MarkState.Unmark(this);
        }

        public override string ToString()
        {
            return this.LogName;
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
