﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class LinkLocator : Locator
    {
        public LinkLocator(Browser browser, Element parent, string locatorText, string tag, bool required) 
            : base(browser, parent, locatorText, tag, required)
        {
        }

        protected override ImmutableArray<Element> DoFindElements()
        {
            var elements = this.SearchContext.FindElements(By.LinkText(this.Value));
            return this.FilterElements(elements);
        }
    }
}
