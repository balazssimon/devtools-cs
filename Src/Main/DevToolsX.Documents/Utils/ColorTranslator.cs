using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevToolsX.Documents.Utils
{
    public static class ColorTranslator
    {
        public static string ToHtml(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        public static string ToLaTeX(Color color)
        {
            return string.Format("{0:F3},{1:F3},{2:F3}", color.R/255.0, color.G/255.0, color.B/255.0);
        }

        public static Color FromHtml(string color)
        {
            if (string.IsNullOrEmpty(color) || color.Length != 7) return Color.Empty;
            try
            {
                string rs = color.Substring(1, 2);
                string gs = color.Substring(3, 2);
                string bs = color.Substring(5, 2);
                int r = Convert.ToInt32(rs, 16);
                int g = Convert.ToInt32(gs, 16);
                int b = Convert.ToInt32(bs, 16);
                return Color.FromArgb(r, g, b);
            }
            catch
            {
                return Color.Empty;
            }
        }

    }
}
