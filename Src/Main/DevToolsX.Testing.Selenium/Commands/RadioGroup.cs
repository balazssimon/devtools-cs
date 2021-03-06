﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using OpenQA.Selenium;

namespace DevToolsX.Testing.Selenium
{
    public class RadioGroup : CommandsBase
    {
        public RadioGroup(Browser browser, Element parent, string locator, string tagKind, string groupName, ImmutableArray<Element> items) 
            : base(browser)
        {
            this.Parent = parent;
            this.Locator = locator;
            this.TagKind = tagKind;
            this.GroupName = groupName;
            this.Items = items;
        }

        public bool Exists
        {
            get { return this.Items.Length > 0; }
        }

        public Element Parent { get; }
        public string Locator { get; }
        public string TagKind { get; }
        public string GroupName { get; }
        public ImmutableArray<Element> Items { get; }
        public string LogName
        {
            get { return string.Format("{0} '{1}'", this.TagKind ?? "Radio group", this.Locator); }
        }

        public string Value
        {
            get
            {
                string radioValue = null;
                this.TryGetRadioGroupValue(out radioValue);
                return radioValue;
            }
        }

        public bool IsSelected
        {
            get { return this.TryGetRadioGroupValue(out string value); }
        }

        public bool ShouldHaveValue(string value, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            string radioValue = null;
            string successMessage = "Radio group '{0}' is set to '{1}'.";
            string failureMessage = null;
            if (this.TryGetRadioGroupValue(out radioValue))
            {
                failureMessage = message ?? "Radio group '{0}' should have been set to '{1}' but was set to '{2}'.";
            }
            else
            {
                failureMessage = message ?? "Radio group '{0}' should have been set to '{1}' but had no selection.";
            }
            bool success = value == radioValue;
            this.Browser.AssertSuccess(success, successMessage, failureMessage, this.GroupName, value, radioValue);
            return success;
        }

        public bool ShouldNotBeSelected(string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            string radioValue = null;
            bool selected = this.TryGetRadioGroupValue(out radioValue);
            string successMessage = "Radio group '{0}' has no selection.";
            string failureMessage = message ?? "Radio group '{0}' should not have had selection but was set to '{1}'.";
            return this.Browser.AssertSuccess(selected, successMessage, failureMessage, this.GroupName, radioValue);
        }

        public void Select(string value)
        {
            Element radioButton = this.GetRadioButtonWithValue(value);
            if (radioButton != null) radioButton.Select();
        }

        private bool TryGetRadioGroupValue(out string value)
        {
            bool selected = false;
            value = null;
            foreach (var element in this.Items)
            {
                if (element.IsSelected)
                {
                    selected = true;
                    value = element.GetAttribute("value");
                    break;
                }
            }
            return selected;
        }

        private Element GetRadioButtonWithValue(string value)
        {
            foreach (var element in this.Items)
            {
                if (element.GetAttribute("value") == value)
                {
                    return element;
                }
            }
            return null;
        }


    }
}
