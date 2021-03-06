﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class NameLocator : Locator
    {
        public NameLocator(Browser browser, Element parent, string locatorText, string tag, bool required) 
            : base(browser, parent, locatorText, tag, required)
        {
        }

        protected override ImmutableArray<Element> DoFindElements()
        {
            var elements = this.SearchContext.FindElements(By.Name(this.Value));
            return this.FilterElements(elements);
        }
    }
}
