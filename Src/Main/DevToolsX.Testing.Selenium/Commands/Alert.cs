using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public enum AlertAction
    {
        Accept,
        Dismiss,
        Leave
    }

    public class Alert : CommandsBase
    {
        public Alert(Browser browser) 
            : base(browser)
        {
        }

        private IAlert WaitForAlert(TimeSpan timeout = default(TimeSpan))
        {
            try
            {
                return this.Browser.Wait.Until(ExpectedConditions.AlertIsPresent(), timeout);
            }
            catch(WebDriverException)
            {
                this.LogError("Alert not found in {0}.", timeout);
            }
            return null;
        }

        private string HandleAlert(IAlert alert, AlertAction action)
        {
            switch (action)
            {
                case AlertAction.Accept:
                    alert.Accept();
                    break;
                case AlertAction.Dismiss:
                    alert.Dismiss();
                    break;
                case AlertAction.Leave:
                    break;
                default:
                    break;
            }
            return alert.Text ?? string.Empty;
        }

        public void TypeText(string text, AlertAction action = AlertAction.Accept, TimeSpan timeout = default(TimeSpan))
        {
            var alert = this.WaitForAlert(timeout);
            if (alert != null)
            {
                alert.SendKeys(text);
                this.HandleAlert(alert, action);
            }
        }

        public string Handle(AlertAction action = AlertAction.Accept, TimeSpan timeout = default(TimeSpan))
        {
            var alert = this.WaitForAlert(timeout);
            if (alert != null)
            {
                return this.HandleAlert(alert, action);
            }
            return null;
        }

        public AssertionResult ShouldBePresent(string text, AlertAction action = AlertAction.Accept, TimeSpan timeout = default(TimeSpan))
        {
            string message = this.Handle(action, timeout);
            string successMessage = "Alert message is '{0}'.";
            string failureMessage = "Alert message should have been '{0}' but it was '{1}'";
            return this.AssertSuccess(text == null || (message != null && message == text), successMessage, failureMessage, text, message);
        }

        public AssertionResult ShouldNotBePresent(AlertAction action = AlertAction.Accept, TimeSpan timeout = default(TimeSpan))
        {
            string message = this.Handle(action, timeout);
            string successMessage = "Alert is not present.";
            string failureMessage = "Alert message should not have been present but it was '{0}'";
            return this.AssertSuccess(message == null, successMessage, failureMessage, message);
        }
    }
}
