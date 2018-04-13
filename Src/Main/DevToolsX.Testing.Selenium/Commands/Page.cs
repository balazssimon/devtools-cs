using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class Page : Element
    {
        public Page(Browser browser) 
            : base(browser, null, null, null, null)
        {
            this.Browser.LogDebug("Page {0} is not yet loaded. Waiting for {1} for the page to be fully loaded.", this.Browser.Url, this.Options.PageLoadTimeout);
            if (this.Wait.UntilPageLoaded(this.Options.PageLoadTimeout))
            {
                this.Browser.LogInformation("Page {0} is loaded.", this.Browser.Url);
            }
            else
            {
                this.Browser.LogError("Page {0} is not loaded in {1}.", this.Browser.Url, this.Options.PageLoadTimeout);
            }
        }
    }
}
