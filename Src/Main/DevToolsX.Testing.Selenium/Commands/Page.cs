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
            : base(browser, null, null)
        {
        }
    }
}
