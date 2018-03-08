using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class JavaScript : CommandsBase
    {
        private IJavaScriptExecutor javaScriptExecutor;

        public JavaScript(Browser browser) 
            : base(browser)
        {
            this.javaScriptExecutor = this.Driver as IJavaScriptExecutor;
        }

        public bool IsSupported
        {
            get { return this.javaScriptExecutor != null; }
        }

        public object Execute(string javaScriptCode, params object[] args)
        {
            if (this.javaScriptExecutor == null)
            {
                this.LogError("The driver does not support JavaScript.");
                return null;
            }
            return this.javaScriptExecutor.ExecuteScript(javaScriptCode, args);
        }

        public object ExecuteAsync(string javaScriptCode, params object[] args)
        {
            if (this.javaScriptExecutor == null)
            {
                this.LogError("The driver does not support JavaScript.");
                return null;
            }
            return this.javaScriptExecutor.ExecuteAsyncScript(javaScriptCode, args);
        }

        public object ExecuteFile(string javaScriptFileName, params object[] args)
        {
            string javaScriptFilePath = Path.Combine(this.Options.JavaScriptDirectory, javaScriptFileName);
            string javaScriptCode = File.ReadAllText(javaScriptFilePath);
            return this.Execute(javaScriptCode, args);
        }

        public object ExecuteFileAsync(string javaScriptFileName, params object[] args)
        {
            string javaScriptFilePath = Path.Combine(this.Options.JavaScriptDirectory, javaScriptFileName);
            string javaScriptCode = File.ReadAllText(javaScriptFilePath);
            return this.ExecuteAsync(javaScriptCode, args);
        }
    }
}
