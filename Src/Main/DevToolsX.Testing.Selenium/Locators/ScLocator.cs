using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class ScLocator : Locator
    {
        protected override ImmutableArray<Element> FindElements(string value, string tag)
        {
            if (this.ParentWebElement != null) return ImmutableArray<Element>.Empty;
            IJavaScriptExecutor executor = this.Driver as IJavaScriptExecutor;
            if (executor == null) return ImmutableArray<Element>.Empty;
            var result = executor.ExecuteScript(string.Format("return isc.AutoTest.getElement('{0}');", value.Replace("'", "\\'")));
            return this.FilterElements(Utils.JavaScriptResultToElementList(result), tag);
        }
    }
}
