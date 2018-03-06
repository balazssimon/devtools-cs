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

        public void Execute(string javaScriptCode)
        {
            if (this.javaScriptExecutor == null)
            {
                this.LogError("The driver does not support JavaScript.");
                return;
            }
            this.javaScriptExecutor.ExecuteScript(javaScriptCode);
        }

        public void ExecuteAsync(string javaScriptCode)
        {
            if (this.javaScriptExecutor == null)
            {
                this.LogError("The driver does not support JavaScript.");
                return;
            }
            this.javaScriptExecutor.ExecuteAsyncScript(javaScriptCode);
        }

        public void ExecuteFile(string javaScriptFileName)
        {
            string javaScriptFilePath = Path.Combine(this.Options.JavaScriptDirectory, javaScriptFileName);
            string javaScriptCode = File.ReadAllText(javaScriptFilePath);
            this.Execute(javaScriptCode);
        }

        public void ExecuteFileAsync(string javaScriptFileName)
        {
            string javaScriptFilePath = Path.Combine(this.Options.JavaScriptDirectory, javaScriptFileName);
            string javaScriptCode = File.ReadAllText(javaScriptFilePath);
            this.ExecuteAsync(javaScriptCode);
        }
    }
}
