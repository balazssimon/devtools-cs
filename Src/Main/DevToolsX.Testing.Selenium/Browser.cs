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

        public string Title
        {
            get { return this.driver.Title; }
        }

        public string Url
        {
            get { return this.driver.Url; }
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

        public AssertionResult TitleShouldBe(string title)
        {
            return new AssertionResult(title, this.Title);
        }
    }
}
