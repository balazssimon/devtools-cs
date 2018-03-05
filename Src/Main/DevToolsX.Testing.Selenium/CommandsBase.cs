using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public abstract class CommandsBase
    {
        private Browser browser;

        public CommandsBase(Browser browser)
        {
            this.browser = browser;
            this.Logger = browser.Options.LoggerFactory.CreateLogger(this.GetType());
        }

        public Browser Browser
        {
            get { return this.browser; }
        }

        public Options Options
        {
            get { return this.browser.Options; }
        }

        public IWebDriver Driver
        {
            get { return this.browser.Driver; }
        }

        public ILogger Logger
        {
            get;
        }
    }
}
