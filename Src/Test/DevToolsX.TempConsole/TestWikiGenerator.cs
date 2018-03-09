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

        public Page Page
        {
            get { return this.Browser.Page; }
        }

        private Screenshot screenshot;
        public Screenshot Screenshot
        {
            get
            {
                if (screenshot == null) screenshot = new Screenshot(this.Browser);
                return screenshot;
            }
        }

        protected string Wait(int seconds)
        {
            this.Browser.Wait.For(TimeSpan.FromSeconds(seconds));
            return string.Empty;
        }

        protected virtual string ProcessTemplateOutput(object output)
        {
            if (output == null) return string.Empty;
            AssertExpectedResult assertExpectedResult = output as AssertExpectedResult;
            ImageResult imageResult = output as ImageResult;
            if (assertExpectedResult != null)
            {
                if (assertExpectedResult.Success)
                {
                    return assertExpectedResult.Expected;
                }
                else
                {
                    return assertExpectedResult.Expected + @"<span style=""background:#FF8080; text-decoration:line-through"">" + assertExpectedResult.Actual + "</span>";
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
