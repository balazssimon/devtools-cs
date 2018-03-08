using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace DevToolsX.Testing.Selenium
{
    public class Form : Element
    {
        public Form(Browser browser, Element parent, string locator, string tagKind, IWebElement webElement) 
            : base(browser, parent, locator, tagKind, webElement)
        {
        }

        public Form(Element element)
            : base(element)
        {
        }

        public void Submit()
        {
            this.WebElement?.Submit();
        }
    }
}
