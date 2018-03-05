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
    public class Browser : IDisposable
    {
        private IWebDriver driver;

        public Browser(BrowserKind kind, Options options)
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
            this.Logger = this.Options.LoggerFactory.CreateLogger(this.GetType());
        }

        public Browser(IWebDriver driver, Options options)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            if (options == null) throw new ArgumentNullException(nameof(options));
            this.driver = driver;
            this.Options = options;
            this.Options.RegisterDriver(driver);
        }

        public void Dispose()
        {
            this.Options.UnregisterDriver(driver);
            this.driver.Dispose();
        }

        public Options Options
        {
            get;
        }

        public IWebDriver Driver
        {
            get { return this.driver; }
        }

        public ILogger Logger
        {
            get;
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
            message = message ?? "Title should have been '{0}' but it was '{1}'.";
            return AssertionResult.Create(this.Logger, title, this.LogTitle(), message);
        }

        public string LogTitle()
        {
            this.Logger.LogInformation("Title is '{0}'.", this.Title);
            return this.Title;
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
            message = message ?? "URL should have been '{0}' but it was '{1}'.";
            return AssertionResult.Create(this.Logger, url, this.Url, message);
        }

        /// <summary>
        /// Verifies that current URL is exactly the url.
        /// </summary>
        /// <param name="urlPart"></param>
        /// <returns></returns>
        public AssertionResult UrlShouldContain(string urlPart, string message = null)
        {
            message = message ?? "URL should have contained '{0}' but it was '{1}'.";
            return AssertionResult.Create(this.Logger, this.Url.Contains(urlPart), urlPart, this.LogUrl(), message);
        }

        public string LogUrl()
        {
            this.Logger.LogInformation("URL is '{0}'.", this.Url);
            return this.Url;
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
            this.Logger.Log(level, new EventId(), this.PageSource, null, null);
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
