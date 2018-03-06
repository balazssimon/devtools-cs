using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public static class Utils
    {
        public static string EscapeXpathValue(string value)
        {
            if (!value.Contains("'"))
                return '\'' + value + '\'';

            else if (!value.Contains("\""))
                return '"' + value + '"';

            else
                return "concat('" + value.Replace("'", "',\"'\",'") + "')";
        }
    }
}
