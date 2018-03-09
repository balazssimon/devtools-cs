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

        public ImageResult Capture(Element element)
        {
            return this.Capture(null, element);
        }

        public ImageResult Capture(string fileName = null, Element element = null)
        {
            if (this.screenshotTaker == null)
            {
                this.LogError("The driver does not support screenshots.");
                return null;
            }
            if (element != null)
            {
                element.ScrollIntoView();
                element.Mark();
            }
            ScreenshotImageFormat format = this.GetImageFormat();
            if (string.IsNullOrWhiteSpace(fileName))
            {
                int index = 0;
                lock (screenshotLock)
                {
                    index = ++screenshotIndex;
                }
                Directory.CreateDirectory(this.Options.ScreenshotDirectory);
                fileName = $"screenshot-{index}.{format.ToString().ToLower()}";
            }
            var screenshot = this.screenshotTaker.GetScreenshot();
            string filePath = Path.Combine(this.Options.ScreenshotDirectory, fileName);
            screenshot.SaveAsFile(filePath, this.GetImageFormat());
            this.LogInformation("Screenshot created: '{0}'", fileName);
            if (element != null)
            {
                element.Unmark();
            }
            return new ImageResult(fileName);
        }

        private ScreenshotImageFormat GetImageFormat()
        {
            ScreenshotImageFormat format;
            switch (this.Options.ScreenshotImageFormat)
            {
                case ImageFormat.Bmp:
                    format = ScreenshotImageFormat.Bmp;
                    break;
                case ImageFormat.Gif:
                    format = ScreenshotImageFormat.Gif;
                    break;
                case ImageFormat.Jpeg:
                    format = ScreenshotImageFormat.Jpeg;
                    break;
                case ImageFormat.Png:
                    format = ScreenshotImageFormat.Png;
                    break;
                case ImageFormat.Tiff:
                    format = ScreenshotImageFormat.Tiff;
                    break;
                default:
                    format = ScreenshotImageFormat.Png;
                    break;
            }
            return format;
        }
    }
}
