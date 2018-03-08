using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class ScLocator : Locator
    {
        public ScLocator(Browser browser, Element parent, string locatorText, string tag, bool required) 
            : base(browser, parent, locatorText, tag, required)
        {
        }

        protected override ImmutableArray<Element> DoFindElements()
        {
            if (this.ParentWebElement != null) return ImmutableArray<Element>.Empty;
            IJavaScriptExecutor executor = this.Driver as IJavaScriptExecutor;
            if (executor == null) return ImmutableArray<Element>.Empty;
            var result = executor.ExecuteScript(string.Format("return isc.AutoTest.getElement('{0}');", this.Value.Replace("'", "\\'")));
            return this.FilterElements(Utils.JavaScriptResultToElementList(result));
        }
    }
}
