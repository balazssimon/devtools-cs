using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public class ImageResult
    {
        public ImageResult(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; private set; }
    }
}
