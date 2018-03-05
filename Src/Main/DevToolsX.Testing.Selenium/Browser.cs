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
        private static int screenshotIndex = 0;
        private static object screenshotLock = new object();

        private IWebDriver driver;
        private ITakesScreenshot screenshotTaker;

        public Browser(BrowserKind kind = BrowserKind.Firefox)
        {
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
            this.ScreenshotDirectory = Directory.GetCurrentDirectory();
            this.screenshotTaker = this.driver as ITakesScreenshot;
        }

        public Browser(IWebDriver driver)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            this.driver = driver;
            this.screenshotTaker = this.driver as ITakesScreenshot;
        }

        public void Dispose()
        {
            this.driver.Dispose();
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
            message = message ?? "Title should have been '{0}' but was '{1}'.";
            return new AssertionResult(title, this.Title, message);
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
            message = message ?? "URL should have been '{0}' but was '{1}'.";
            return new AssertionResult(url, this.Url, message);
        }

        /// <summary>
        /// Verifies that current URL is exactly the url.
        /// </summary>
        /// <param name="urlPart"></param>
        /// <returns></returns>
        public AssertionResult UrlShouldContain(string urlPart, string message = null)
        {
            message = message ?? "URL should have contained '{0}' but it was '{1}'.";
            return new AssertionResult(this.Url.Contains(urlPart), urlPart, this.Url, message);
        }

        /// <summary>
        /// Returns the entire HTML source of the current page or frame.
        /// </summary>
        public string PageSource
        {
            get { return this.driver.PageSource; }
        }

        public string ScreenshotDirectory
        {
            get;
            set;
        }

        public TimeSpan PageLoadTimeout
        {
            get { return this.driver.Manage().Timeouts().PageLoad; }
            set { this.driver.Manage().Timeouts().PageLoad = value; }
        }

        public TimeSpan ImplicitWaitTimeout
        {
            get { return this.driver.Manage().Timeouts().ImplicitWait; }
            set { this.driver.Manage().Timeouts().ImplicitWait = value; }
        }

        public TimeSpan AsynchronousJavaScriptTimeout
        {
            get { return this.driver.Manage().Timeouts().AsynchronousJavaScript; }
            set { this.driver.Manage().Timeouts().AsynchronousJavaScript = value; }
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

        public ImageResult TakeScreenshot(string filePath = null)
        {
            if (this.screenshotTaker == null) return null;
            string fileName = filePath;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                int index = 0;
                lock (screenshotLock)
                {
                    index = ++screenshotIndex;
                }
                Directory.CreateDirectory(this.ScreenshotDirectory);
                fileName = $"screenshot-{index}.png";
                filePath = Path.Combine(this.ScreenshotDirectory, fileName);
            }
            var screenshot = this.screenshotTaker.GetScreenshot();
            screenshot.SaveAsFile(filePath);
            return new ImageResult(fileName);
        }

        public void WaitUntil(Func<bool> condition, TimeSpan timeout)
        {
            var wait = new WebDriverWait(driver, timeout);
            wait.Until(d => condition);
        }

        public void Close()
        {
            this.driver.Close();
        }

    }
}
