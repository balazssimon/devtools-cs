using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace DevToolsX.Testing.Selenium.Locators
{
    public class DefaultLocator : Locator
    {
        private static readonly string[] defaultAttributes;
        private static readonly Dictionary<string, string[]> attributes = new Dictionary<string, string[]>();

        static DefaultLocator()
        {
            defaultAttributes = new string[] { "@id", "@name" };
            attributes.Add("a", new string[] { "@id", "@name", "@href", "normalize-space(descendant-or-self::text())" });
            attributes.Add("img", new string[] { "@id", "@name", "@src", "@alt" });
            attributes.Add("input", new string[] { "@id", "@name", "@src", "@value" });
            attributes.Add("button", new string[] { "@id", "@name", "@value", "normalize-space(descendant-or-self::text())" });
        }

        protected override ImmutableArray<Element> FindElements(string value, string tag)
        {
            // TODO
            var elements = this.SearchContext.FindElements(By.Id(value));
            return this.FilterElements(elements, tag);
        }
    }
}
