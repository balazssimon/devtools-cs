using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class ClassLocator : Locator
    {
        protected override ImmutableArray<Element> FindElements(string value, string tag)
        {
            var elements = this.SearchContext.FindElements(By.ClassName(value));
            return this.FilterElements(elements, tag);
        }
    }
}
