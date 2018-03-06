﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class NameLocator : Locator
    {
        protected override ImmutableArray<Element> FindElements(string value, string tag)
        {
            var elements = this.SearchContext.FindElements(By.Name(value));
            return this.FilterElements(elements, tag);
        }
    }
}
