using DevToolsX.Testing.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX.TempConsole
{
    public class TestWikiGenerator
    {
        public Browser Browser { get; set; }

        private Screenshot screenshot;
        public Screenshot Screenshot
        {
            get
            {
                if (screenshot == null) screenshot = new Screenshot(this.Browser);
                return screenshot;
            }
        }

        protected virtual string ProcessTemplateOutput(object output)
        {
            if (output == null) return string.Empty;
            AssertionResult assertionResult = output as AssertionResult;
            ImageResult imageResult = output as ImageResult;
            if (assertionResult != null)
            {
                if (assertionResult.Success)
                {
                    return assertionResult.Expected;
                }
                else
                {
                    return assertionResult.Expected + @"<span style=""background:#FF8080; text-decoration:line-through"">" + assertionResult.Actual + "</span>";
                }
            }
            else if (imageResult != null)
            {
                return "[[Media:" + imageResult.FilePath + "]]";
            }
            else
            {
                return output.ToString();
            }
        }
    }
}
