using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class IdentifierLocator : Locator
    {
        protected override ImmutableArray<Element> FindElements(string value, string tag)
        {
            var elementsById = this.SearchContext.FindElements(By.Id(value));
            var elementsByName = this.SearchContext.FindElements(By.Name(value));
            var elements = new List<IWebElement>(elementsById);
            elements.AddRange(elementsByName);
            return this.FilterElements(elements, tag);
        }
    }
}
