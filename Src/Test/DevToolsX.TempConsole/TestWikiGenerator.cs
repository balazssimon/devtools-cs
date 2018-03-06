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
            AssertEqualsResult assertEqualsResult = output as AssertEqualsResult;
            ImageResult imageResult = output as ImageResult;
            if (assertEqualsResult != null)
            {
                if (assertEqualsResult.Success)
                {
                    return assertEqualsResult.Expected;
                }
                else
                {
                    return assertEqualsResult.Expected + @"<span style=""background:#FF8080; text-decoration:line-through"">" + assertEqualsResult.Actual + "</span>";
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
