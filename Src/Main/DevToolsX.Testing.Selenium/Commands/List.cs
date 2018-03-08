using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace DevToolsX.Testing.Selenium
{
    public class List : Element
    {
        public List(Browser browser, Element parent, string locator, string tagKind, IWebElement webElement) 
            : base(browser, parent, locator, tagKind, webElement)
        {
        }

        public List(Element element) 
            : base(element)
        {
        }

    }
}
