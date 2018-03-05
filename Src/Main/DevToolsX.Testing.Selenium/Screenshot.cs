using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class Screenshot : CommandsBase
    {
        private static int screenshotIndex = 0;
        private static object screenshotLock = new object();
        private ITakesScreenshot screenshotTaker;

        public Screenshot(Browser browser) 
            : base(browser)
        {
            this.screenshotTaker = this.Driver as ITakesScreenshot;
        }

        public ImageResult TakeScreenshot(string filePath = null)
        {
            if (this.screenshotTaker == null) return null;
            string fileName = filePath;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                int index = 0;
                lock (screenshotLock)
                {
                    index = ++screenshotIndex;
                }
                Directory.CreateDirectory(this.Options.ScreenshotDirectory);
                fileName = $"screenshot-{index}.png";
                filePath = Path.Combine(this.Options.ScreenshotDirectory, fileName);
            }
            var screenshot = this.screenshotTaker.GetScreenshot();
            screenshot.SaveAsFile(filePath);
            return new ImageResult(fileName);
        }
    }
}
