using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class Browser : CommandsBase, IDisposable
    {
        private IWebDriver driver;

        public Browser(BrowserKind kind, Options options)
            : base(null)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
            switch (kind)
            {
                case BrowserKind.Firefox:
                    this.driver = new FirefoxDriver();
                    break;
                case BrowserKind.Chrome:
                    this.driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentException("Invalid browser kind.", nameof(kind));
            }
            this.Options = options;
            this.Options.RegisterDriver(driver);
            base.SetBrowser(this);
            this.Page = new Page(this);
        }

        public Browser(IWebDriver driver, Options options)
            : base(null)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            if (options == null) throw new ArgumentNullException(nameof(options));
            this.driver = driver;
            this.Options = options;
            this.Options.RegisterDriver(driver);
            base.SetBrowser(this);
            this.Page = new Page(this);
        }

        public void Dispose()
        {
            this.Options.UnregisterDriver(driver);
            this.driver.Dispose();
        }

        public override Options Options
        {
            get;
        }

        public override IWebDriver Driver
        {
            get { return this.driver; }
        }

        /// <summary>
        /// Returns the title of current page.
        /// </summary>
        public string Title
        {
            get { return this.driver.Title; }
        }

        /// <summary>
        /// Verifies that current page title equals title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public AssertionResult TitleShouldBe(string title, string message = null)
        {
            return this.AssertEquals("Title", title, this.Title, message);
        }

        public string LogTitle()
        {
            return this.LogValue("Title", this.Title);
        }

        /// <summary>
        /// Returns the current browser URL.
        /// </summary>
        public string Url
        {
            get { return this.driver.Url; }
        }

        /// <summary>
        /// Verifies that current URL is exactly the url.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public AssertionResult UrlShouldBe(string url, string message = null)
        {
            return this.AssertEquals("URL", url, this.Url);
        }

        /// <summary>
        /// Verifies that current URL is exactly the url.
        /// </summary>
        /// <param name="urlPart"></param>
        /// <returns></returns>
        public AssertionResult UrlShouldContain(string urlPart, string message = null)
        {
            return this.AssertSuccess(this.Url.Contains(urlPart), message ?? "URL should have contained '{0}' but it was '{1}'.", "URL is '{1}'.", urlPart, this.Url);
        }

        public string LogUrl()
        {
            return this.LogValue("URL", this.Url);
        }

        public Element Page
        {
            get;
        }

        /// <summary>
        /// Returns the entire HTML source of the current page or frame.
        /// </summary>
        public string PageSource
        {
            get { return this.driver.PageSource; }
        }

        public string LogPageSource(Microsoft.Extensions.Logging.LogLevel level = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            this.Log(level, this.PageSource);
            return this.PageSource;
        }

        public void GoBack()
        {
            this.driver.Navigate().Back();
        }

        public void GoForward()
        {
            this.driver.Navigate().Forward();
        }

        public void GoToUrl(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        public void ReloadPage()
        {
            this.driver.Navigate().Refresh();
        }

        public void Maximize()
        {
            this.driver.Manage().Window.Maximize();
        }

        public void Close()
        {
            this.driver.Close();
        }
    }
}
