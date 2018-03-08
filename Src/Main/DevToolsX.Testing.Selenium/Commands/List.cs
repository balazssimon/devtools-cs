using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DevToolsX.Testing.Selenium
{
    public class List : Element
    {
        private SelectElement selectElement;
        private ImmutableArray<Element> items;

        public List(Browser browser, Element parent, string locator, string tagKind, IWebElement webElement) 
            : base(browser, parent, locator, tagKind, webElement)
        {
        }

        public List(Element element) 
            : base(element)
        {
        }

        protected SelectElement SelectElement
        {
            get
            {
                if (this.WebElement == null) return null;
                if (this.selectElement == null)
                {
                    this.selectElement = new SelectElement(this.WebElement);
                    this.items = this.selectElement.Options.Select(we => new Element(this.Browser, this, "tag:option", null, we)).ToImmutableArray();
                }
                return this.selectElement;
            }
        }

        public ImmutableArray<Element> Items
        {
            get
            {
                if (this.WebElement == null) return ImmutableArray<Element>.Empty;
                if (this.selectElement == null)
                {
                    this.selectElement = new SelectElement(this.WebElement);
                    this.items = this.selectElement.Options.Select(we => new Element(this.Browser, this, "tag:option", null, we)).ToImmutableArray();
                }
                return this.items;
            }
        }

        public bool IsMultiple
        {
            get { return this.SelectElement?.IsMultiple ?? false; }
        }

        public ImmutableArray<Element> GetItems(string locator)
        {
            return this.FindElements(locator, "option", required: false);
        }

        public ImmutableArray<Element> GetSelectedItems(string locator)
        {
            return this.GetItems(locator).Where(item => item.IsSelected).ToImmutableArray();
        }

        public void SelectAll()
        {
            foreach (var item in this.Items)
            {
                item.Select();
            }
        }

        public void UnselectAll()
        {
            this.SelectElement?.DeselectAll();
        }

        public void SelectByText(bool clearOthers = true, params string[] texts)
        {
            foreach (var item in this.Items)
            {
                if(texts.Contains(item.Text))
                {
                    item.Select();
                }
                else if (clearOthers)
                {
                    item.Unselect();
                }
            }
        }

        public void SelectByValue(bool clearOthers = true, params string[] values)
        {
            foreach (var item in this.Items)
            {
                if (values.Contains(item.Value))
                {
                    item.Select();
                }
                else if (clearOthers)
                {
                    item.Unselect();
                }
            }
        }

        public AssertionResult ShouldBeSelected(params string[] valuesOrTexts)
        {
            bool expectedNotSelected = false;
            HashSet<string> valueSet = new HashSet<string>(valuesOrTexts);
            foreach (var item in this.Items)
            {
                string text = item.Text;
                string value = item.Value;
                if (item.IsSelected)
                {
                    valueSet.Remove(text);
                    valueSet.Remove(value);
                }
                else
                {
                    if (valueSet.Contains(text) || valueSet.Contains(value))
                    {
                        expectedNotSelected = true;
                    }
                }
            }
            bool success = !expectedNotSelected && valueSet.Count == 0;
            string successMessage = "List '{0}' has selection [{1}].";
            string failureMessage = "List '{0}' items [{1}] should be selected but selection was [{2}].";
            return this.Browser.AssertSuccess(success, successMessage, failureMessage, this.LogName, this.ValuesToString(valuesOrTexts), this.OptionsToString(this.SelectElement?.AllSelectedOptions));
        }

        public AssertionResult ShouldNotBeSelected(params string[] valuesOrTexts)
        {
            bool unexpectedSelected = false;
            HashSet<string> valueSet = new HashSet<string>(valuesOrTexts);
            foreach (var item in this.Items)
            {
                string text = item.Text;
                string value = item.Value;
                if (item.IsSelected)
                {
                    if (valueSet.Contains(text) || valueSet.Contains(value))
                    {
                        unexpectedSelected = true;
                    }
                }
                else
                {
                    valueSet.Remove(text);
                    valueSet.Remove(value);
                }
            }
            bool success = !unexpectedSelected && valueSet.Count == 0;
            string successMessage = "List '{0}' has selection [{1}].";
            string failureMessage = "List '{0}' items [{1}] should not be selected but selection was [{1}].";
            return this.Browser.AssertSuccess(success, successMessage, failureMessage, this.LogName, this.ValuesToString(valuesOrTexts), this.OptionsToString(this.SelectElement?.AllSelectedOptions));
        }

        public AssertionResult ShouldHaveSelection(params string[] valuesOrTexts)
        {
            bool expectedNotSelected = false;
            bool unexpectedSelected = false;
            HashSet<string> valueSet = new HashSet<string>(valuesOrTexts);
            foreach (var item in this.Items)
            {
                string text = item.Text;
                string value = item.Value;
                bool shouldBeSelected = valueSet.Remove(text) || valueSet.Remove(value);
                if (item.IsSelected)
                {
                    if (!shouldBeSelected) unexpectedSelected = true;
                }
                else
                {
                    if (shouldBeSelected) expectedNotSelected = true;
                }
            }
            bool success = !expectedNotSelected && !unexpectedSelected && valueSet.Count == 0;
            string successMessage = "List '{0}' has selection [{1}].";
            string failureMessage = "List '{0}' should have had selection [{1}] but selection was [{2}].";
            return this.Browser.AssertSuccess(success, successMessage, failureMessage, this.LogName, this.ValuesToString(valuesOrTexts), this.OptionsToString(this.SelectElement?.AllSelectedOptions));
        }

        public AssertionResult ShouldHaveNoSelection(string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            var options = this.SelectElement?.AllSelectedOptions;
            string selectedOptions = string.Empty;
            if (options.Count > 0) selectedOptions = this.OptionsToString(options);
            string successMessage = "List '{0}' has no selection.";
            string failureMessage = message ?? "List '{0}' should not have had selection but selection was [{0}].";
            return this.Browser.AssertSuccess(options.Count == 0, successMessage, failureMessage, this.LogName, selectedOptions);
        }

        private string ValuesToString(IEnumerable<string> values)
        {
            bool first = true;
            StringBuilder sb = new StringBuilder();
            foreach (var value in values)
            {
                if (!first) sb.Append(" | ");
                sb.Append(value);
                first = false;
            }
            return sb.ToString();
        }

        private string OptionsToString(IEnumerable<IWebElement> options)
        {
            bool first = true;
            StringBuilder sb = new StringBuilder();
            foreach (var option in options)
            {
                if (!first) sb.Append(" | ");
                sb.Append(option.Text);
                sb.Append(" (");
                sb.Append(option.GetAttribute("value"));
                sb.Append(")");
                first = false;
            }
            return sb.ToString();
        }
    }
}
