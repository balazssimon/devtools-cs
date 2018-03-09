using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class TextLocator : Locator
    {
        public TextLocator(Browser browser, Element parent, string locatorText, string tag, bool required)
            : base(browser, parent, locatorText, tag, required)
        {
        }

        protected override ImmutableArray<Element> DoFindElements()
        {
            string xpath = string.Format("//*[text() = '{0}']", this.Value.Replace("'", "\\'"));
            var elements = this.SearchContext.FindElements(By.XPath(xpath));
            return this.FilterElements(elements);
        }
    }
}
