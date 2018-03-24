using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class PartialTextLocator : Locator
    {
        public PartialTextLocator(Browser browser, Element parent, string locatorText, string tag, bool required)
            : base(browser, parent, locatorText, tag, required)
        {
        }

        protected override ImmutableArray<Element> DoFindElements()
        {
            var elements = this.SearchContext.FindElements(By.XPath(string.Format(".//*[contains(., '{0}')]", this.Value.Replace("'", "\\'"))));
            return this.FilterElements(elements);
        }
    }
}
