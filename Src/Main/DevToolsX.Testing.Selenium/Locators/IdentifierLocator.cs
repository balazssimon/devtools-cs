using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class IdentifierLocator : Locator
    {
        public IdentifierLocator(Browser browser, Element parent, string locatorText, string tag, bool required) 
            : base(browser, parent, locatorText, tag, required)
        {
        }

        protected override ImmutableArray<Element> DoFindElements()
        {
            var elementsById = this.SearchContext.FindElements(By.Id(this.Value));
            var elementsByName = this.SearchContext.FindElements(By.Name(this.Value));
            var elements = new List<IWebElement>(elementsById);
            elements.AddRange(elementsByName);
            return this.FilterElements(elements);
        }
    }
}
