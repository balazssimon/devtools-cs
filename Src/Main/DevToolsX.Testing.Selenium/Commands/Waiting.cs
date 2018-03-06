using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DevToolsX.Testing.Selenium
{
    public class Waiting : CommandsBase
    {
        public Waiting(Browser browser) 
            : base(browser)
        {
        }

        public void Wait(TimeSpan timeout)
        {
            Thread.Sleep(timeout);
        }

        public void WaitUntil(Func<bool> condition, TimeSpan timeout)
        {
            var wait = new WebDriverWait(this.Driver, timeout);
            wait.Until(d => condition);
        }
    }
}
