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
            if (browser != null)
            {
                this.Logger = browser.Options.LoggerFactory.CreateLogger(this.GetType());
            }
        }

        internal void SetBrowser(Browser browser)
        {
            this.browser = browser;
            if (browser != null)
            {
                this.Logger = browser.Options.LoggerFactory.CreateLogger(this.GetType());
            }
        }

        public Browser Browser
        {
            get { return this.browser; }
        }

        public virtual Options Options
        {
            get { return this.browser.Options; }
        }

        public virtual IWebDriver Driver
        {
            get { return this.browser.Driver; }
        }

        public virtual JavaScript JavaScript
        {
            get { return this.browser.JavaScript; }
        }

        public ILogger Logger
        {
            get;
            private set;
        }

        internal protected void LogTrace(string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Trace, message, args);
        }

        internal protected void LogDebug(string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Debug, message, args);
        }

        internal protected void LogInformation(string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Information, message, args);
        }

        internal protected void LogWarning(string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Warning, message, args);
        }

        internal protected void LogError(string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Error, message, args);
        }

        internal protected void LogCritical(string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Critical, message, args);
        }

        internal protected void Log(Microsoft.Extensions.Logging.LogLevel logLevel, string message, params object[] args)
        {
            switch (logLevel)
            {
                case Microsoft.Extensions.Logging.LogLevel.Trace:
                    this.Logger.LogTrace(message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Debug:
                    this.Logger.LogDebug(message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Information:
                    this.Logger.LogInformation(message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Warning:
                    this.Logger.LogWarning(message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Error:
                    this.Logger.LogError(message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Critical:
                    this.Logger.LogCritical(message, args);
                    break;
                default:
                    break;
            }
        }

        internal protected void LogTrace(Exception exception, string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Trace, exception, message, args);
        }

        internal protected void LogDebug(Exception exception, string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Debug, exception, message, args);
        }

        internal protected void LogInformation(Exception exception, string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Information, exception, message, args);
        }

        internal protected void LogWarning(Exception exception, string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Warning, exception, message, args);
        }

        internal protected void LogError(Exception exception, string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Error, exception, message, args);
        }

        internal protected void LogCritical(Exception exception, string message, params object[] args)
        {
            this.Log(Microsoft.Extensions.Logging.LogLevel.Critical, exception, message, args);
        }

        internal protected void Log(Microsoft.Extensions.Logging.LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            switch (logLevel)
            {
                case Microsoft.Extensions.Logging.LogLevel.Trace:
                    this.Logger.LogTrace(exception, message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Debug:
                    this.Logger.LogDebug(exception, message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Information:
                    this.Logger.LogInformation(exception, message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Warning:
                    this.Logger.LogWarning(exception, message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Error:
                    this.Logger.LogError(exception, message, args);
                    break;
                case Microsoft.Extensions.Logging.LogLevel.Critical:
                    this.Logger.LogCritical(exception, message, args);
                    break;
                default:
                    break;
            }
        }

        internal protected string LogValue(string name, string value)
        {
            this.LogInformation(name + " is '{0}'.", value);
            return value;
        }

        internal protected string LogValue(Microsoft.Extensions.Logging.LogLevel logLevel, string name, string value)
        {
            this.Log(logLevel, name + " is '{0}'.", value);
            return value;
        }

        private void LogAssertionResult(bool success, string successMessage, string failureMessage, params object[] args)
        {
            if (success)
            {
                this.LogInformation(successMessage, args);
            }
            else
            {
                this.LogError(failureMessage, args);
            }
        }

        internal protected bool AssertSuccess(bool success, string successMessage, string failureMessage, params object[] args)
        {
            this.LogAssertionResult(success, successMessage, failureMessage, args);
            if (!success && this.Options.ThrowExceptionOnAssertionError)
            {
                throw new AssertionException(failureMessage, args);
            }
            return success;
        }

        internal protected string AssertEquals(string name, string expected, string actual, string successMessage = null, string failureMessage = null)
        {
            successMessage = successMessage ?? name + " is '{1}'";
            failureMessage = failureMessage ?? name + " should have been '{0}' but it was '{1}'.";
            bool success = expected == actual;
            this.LogAssertionResult(success, successMessage, failureMessage, expected, actual);
            if (!success && this.Options.ThrowExceptionOnAssertionError)
            {
                throw new AssertEqualsException(expected, actual, failureMessage, expected, actual);
            }
            return actual;
        }

        internal protected TElement AssertElement<TElement>(TElement element)
            where TElement : Element
        {
            return this.AssertElement(element, "{0} contains {1}.", "{0} should have contained {1} but it did not.", element.Parent, element);
        }

        internal protected TElement AssertElement<TElement>(TElement element, string successMessage, string failureMessage, params object[] args)
            where TElement : Element
        {
            return this.AssertElement(element, element.Exists, successMessage, failureMessage, args);
        }

        internal protected TElement AssertElement<TElement>(TElement element, bool success, string successMessage, string failureMessage, params object[] args)
            where TElement: Element
        {
            if (!success)
            {
                element.Parent.LogSource();
            }
            this.LogAssertionResult(success, successMessage, failureMessage, args);
            if (!success && this.Options.ThrowExceptionOnAssertionError)
            {
                throw new AssertElementException(element, failureMessage, args);
            }
            return element;
        }
    }
}
