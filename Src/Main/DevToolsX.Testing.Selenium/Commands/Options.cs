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
        private Dictionary<string, Type> locators = new Dictionary<string, Type>();

        public Options(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));
            this.loggerFactory = loggerFactory;

            this.ScreenshotDirectory = Directory.GetCurrentDirectory();
            this.ScreenshotImageFormat = ImageFormat.Png;

            this.JavaScriptDirectory = Directory.GetCurrentDirectory();
        }

        internal void RegisterDriver(IWebDriver driver)
        {
            this.drivers.Add(driver);
            driver.Manage().Timeouts().PageLoad = this.pageLoadTimeout;
            driver.Manage().Timeouts().ImplicitWait = this.implicitWaitTimeout;
            driver.Manage().Timeouts().AsynchronousJavaScript = this.asynchronousJavaScriptTimeout;
        }

        internal void UnregisterDriver(IWebDriver driver)
        {
            this.drivers.Remove(driver);
        }

        public void RegisterLocator<TLocator>(string prefix)
            where TLocator: Locator, new()
        {
            if (locators.ContainsKey(prefix)) throw new ArgumentException($"Locator prefix '{prefix}' is already registered.", nameof(prefix));
            this.locators.Add(prefix, typeof(TLocator));
        }

        public void UnregisterLocator(string prefix)
        {
            this.locators.Remove(prefix);
        }

        internal Locator CreateLocator(string prefix, Browser browser, Element parent)
        {
            Type type;
            if (this.locators.TryGetValue(prefix, out type))
            {
                Locator result = type.GetConstructor(Type.EmptyTypes).Invoke(null) as Locator;
                if (result != null)
                {
                    result.Init(browser, parent);
                    return result;
                }
                else
                {
                    throw new InvalidOperationException($"Could not create locator with prefix '{prefix}'.");
                }
            }
            else
            {
                throw new ArgumentException($"Locator prefix '{prefix}' is not registered.", nameof(prefix));
            }
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

        public string ScreenshotDirectory { get; set; }
        public ImageFormat ScreenshotImageFormat { get; set; }

        public string JavaScriptDirectory { get; set; }
    }
}
