using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium
{
    public static class Utils
    {
        private static IReadOnlyCollection<IWebElement> EmptyWebElementList = new List<IWebElement>();

        public static string EscapeXpathValue(string value)
        {
            if (!value.Contains("'"))
                return '\'' + value + '\'';

            else if (!value.Contains("\""))
                return '"' + value + '"';

            else
                return "concat('" + value.Replace("'", "',\"'\",'") + "')";
        }

        public static IReadOnlyCollection<IWebElement> JavaScriptResultToElementList(object result)
        {
            if (result == null) return Utils.EmptyWebElementList;
            var resultList = result as IReadOnlyCollection<object>;
            if (resultList == null)
            {
                IWebElement webElement = result as IWebElement;
                if (webElement == null) return Utils.EmptyWebElementList;
                return new List<IWebElement>() { webElement };
            }
            var resultElementList = result as IReadOnlyCollection<IWebElement>;
            if (resultElementList == null) return Utils.EmptyWebElementList;
            return resultElementList;
        }
    }
}
