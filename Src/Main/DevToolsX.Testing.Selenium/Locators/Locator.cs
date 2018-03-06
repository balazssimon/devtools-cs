using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public abstract class Locator
    {
        internal void Init(Browser browser, Element parent)
        {
            this.Browser = browser;
            this.Parent = parent;
        }

        public Browser Browser { get; private set; }
        public Element Parent { get; private set; }

        public Options Options
        {
            get { return this.Browser.Options; }
        }

        public ILogger Logger
        {
            get { return this.Browser.Logger; }
        }

        public IWebElement ParentWebElement
        {
            get { return this.Parent?.WebElement; }
        }

        protected void LogTrace(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Trace, message, args);
        }

        protected void LogDebug(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Debug, message, args);
        }

        protected void LogInformation(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Information, message, args);
        }

        protected void LogWarning(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Warning, message, args);
        }

        protected void LogError(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Error, message, args);
        }

        protected void LogCritical(string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Critical, message, args);
        }

        protected void Log(Microsoft.Extensions.Logging.LogLevel logLevel, string message, params object[] args)
        {
            this.Browser.Log(logLevel, message, args);
        }

        protected void LogTrace(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Trace, exception, message, args);
        }

        protected void LogDebug(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Debug, exception, message, args);
        }

        protected void LogInformation(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Information, exception, message, args);
        }

        protected void LogWarning(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Warning, exception, message, args);
        }

        protected void LogError(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Error, exception, message, args);
        }

        protected void LogCritical(Exception exception, string message, params object[] args)
        {
            this.Browser.Log(Microsoft.Extensions.Logging.LogLevel.Critical, exception, message, args);
        }

        protected void Log(Microsoft.Extensions.Logging.LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            this.Browser.Log(logLevel, exception, message, args);
        }

        protected AssertionResult AssertSuccess(bool success, string successMessage, string failureMessage, params object[] args)
        {
            return this.Browser.AssertSuccess(success, successMessage, failureMessage, args);
        }

        protected AssertionResult AssertEquals(string name, string expected, string actual, string successMessage = null, string failureMessage = null)
        {
            return this.Browser.AssertEquals(name, expected, actual, successMessage, failureMessage);
        }

        public Element FindOne(string value, string tag, bool required)
        {
            return this.Find(value, tag, required).FirstOrDefault();
        }

        public ImmutableArray<Element> Find(string value, string tag, bool required)
        {
            ImmutableArray<Element> result = this.FindElements(value, tag);
            if (required && result.Length == 0) throw new InvalidOperationException($"Locator '{this.GetType().Name}' could not find element '{value}'.");
            return result;
        }

        protected abstract ImmutableArray<Element> FindElements(string value, string tag);
    }
}
