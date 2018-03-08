using DevToolsX.Testing.Selenium.Locators;
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

            this.ElementMarkerCss = "border : '4em solid red';";
            this.ElementMarkerCssClassName = "devtoolsxElementMarkerClass";

            this.RegisterLocator<ClassLocator>("class");
            this.RegisterLocator<CssLocator>("css");
            this.RegisterLocator<DomLocator>("dom");
            this.RegisterLocator<IdentifierLocator>("identifier");
            this.RegisterLocator<IdLocator>("id");
            this.RegisterLocator<JQueryLocator>("jquery");
            this.RegisterLocator<JQueryLocator>("sizzle");
            this.RegisterLocator<LinkLocator>("link");
            this.RegisterLocator<NameLocator>("name");
            this.RegisterLocator<PartialLinkLocator>("partial link");
            this.RegisterLocator<ScLocator>("scLocator");
            this.RegisterLocator<TagLocator>("tag");
            this.RegisterLocator<XPathLocator>("xpath");
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
            where TLocator: Locator
        {
            if (locators.ContainsKey(prefix)) throw new ArgumentException($"Locator prefix '{prefix}' is already registered.", nameof(prefix));
            this.locators.Add(prefix, typeof(TLocator));
        }

        public void UnregisterLocator(string prefix)
        {
            this.locators.Remove(prefix);
        }

        internal Locator CreateLocator(Browser browser, Element parent, string locator, string tag, bool required)
        {
            if (locator == null) throw new ArgumentException($"Invalid locator syntax '{locator}'. Locators should start with a registered locator prefix.");
            int colonIndex = locator.IndexOf(':');
            if (colonIndex < 0) throw new ArgumentException($"Invalid locator syntax '{locator}'. Locators should start with a registered locator prefix.");
            string prefix = locator.Substring(0, colonIndex).Trim();
            Type type;
            if (this.locators.TryGetValue(prefix, out type))
            {
                Locator result = type.GetConstructor(new Type[] { typeof(Browser), typeof(Element), typeof(string), typeof(string), typeof(bool)}).
                    Invoke(new object[] { browser, parent, locator, tag, required }) as Locator;
                if (result != null)
                {
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

        private TimeSpan implicitWaitTimeout = TimeSpan.Zero;
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

        private TimeSpan asynchronousJavaScriptTimeout = TimeSpan.Zero;
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

        public string ElementMarkerCssClassName { get; set; }
        public string ElementMarkerCss { get; set; }
    }
}
