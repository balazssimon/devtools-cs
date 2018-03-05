using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class Options
    {
        private ILoggerFactory loggerFactory;
        private HashSet<IWebDriver> drivers = new HashSet<IWebDriver>();

        public Options(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));
            this.ScreenshotDirectory = Directory.GetCurrentDirectory();
            this.loggerFactory = loggerFactory;
        }

        public void RegisterDriver(IWebDriver driver)
        {
            this.drivers.Add(driver);
            driver.Manage().Timeouts().PageLoad = this.pageLoadTimeout;
            driver.Manage().Timeouts().ImplicitWait = this.implicitWaitTimeout;
            driver.Manage().Timeouts().AsynchronousJavaScript = this.asynchronousJavaScriptTimeout;
        }

        public void UnregisterDriver(IWebDriver driver)
        {
            this.drivers.Remove(driver);
        }

        public ILoggerFactory LoggerFactory
        {
            get { return this.loggerFactory; }
        }

        private TimeSpan pageLoadTimeout = TimeSpan.MaxValue;
        public TimeSpan PageLoadTimeout
        {
            get { return this.pageLoadTimeout; }
            set
            {
                if (value != this.pageLoadTimeout)
                {
                    this.pageLoadTimeout = value;
                    foreach (var driver in this.drivers)
                    {
                        driver.Manage().Timeouts().PageLoad = this.pageLoadTimeout;
                    }
                }
            }
        }

        private TimeSpan implicitWaitTimeout = TimeSpan.MaxValue;
        public TimeSpan ImplicitWaitTimeout
        {
            get { return this.implicitWaitTimeout; }
            set
            {
                if (value != this.implicitWaitTimeout)
                {
                    this.implicitWaitTimeout = value;
                    foreach (var driver in this.drivers)
                    {
                        driver.Manage().Timeouts().ImplicitWait = this.implicitWaitTimeout;
                    }
                }
            }
        }

        private TimeSpan asynchronousJavaScriptTimeout = TimeSpan.MaxValue;
        public TimeSpan AsynchronousJavaScriptTimeout
        {
            get { return this.asynchronousJavaScriptTimeout; }
            set
            {
                if (value != this.asynchronousJavaScriptTimeout)
                {
                    this.asynchronousJavaScriptTimeout = value;
                    foreach (var driver in this.drivers)
                    {
                        driver.Manage().Timeouts().AsynchronousJavaScript = this.asynchronousJavaScriptTimeout;
                    }
                }
            }
        }

        public string ScreenshotDirectory
        {
            get;
            set;
        }
    }
}
