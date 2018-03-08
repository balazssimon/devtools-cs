using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using OpenQA.Selenium;

namespace DevToolsX.Testing.Selenium
{
    public class Table : Element
    {
        private ImmutableArray<Element>? headerCache;
        private ImmutableArray<Element>? bodyCache;
        private ImmutableArray<Element>? footerCache;
        private ImmutableArray<Element>? rowCache;
        private ImmutableArray<Element>?[] cellCache;

        public Table(Browser browser, Element parent, string locator, string tagKind, IWebElement webElement)
            : base(browser, parent, locator, tagKind, webElement)
        {
        }

        public Table(Element element)
            : base(element)
        {
        }

        public ImmutableArray<Element> Rows
        {
            get
            {
                if (this.rowCache == null) this.CacheRows();
                return this.rowCache ?? ImmutableArray<Element>.Empty;
            }
        }

        public ImmutableArray<Element> Header
        {
            get
            {
                if (this.headerCache == null) this.CacheRows();
                return this.headerCache ?? ImmutableArray<Element>.Empty;
            }
        }

        public ImmutableArray<Element> Body
        {
            get
            {
                if (this.bodyCache == null) this.CacheRows();
                return this.bodyCache ?? ImmutableArray<Element>.Empty;
            }
        }

        public ImmutableArray<Element> Footer
        {
            get
            {
                if (this.footerCache == null) this.CacheRows();
                return this.footerCache ?? ImmutableArray<Element>.Empty;
            }
        }

        public Element this[int row, int column]
        {
            get { return this.GetCell(row, column); }
        }

        private void CacheRows()
        {
            List<Element> rows = new List<Element>();
            this.headerCache = this.FindElements("xpath:./thead/tr");
            rows.AddRange(this.headerCache);
            this.bodyCache = this.FindElements("xpath:./tbody/tr");
            rows.AddRange(this.bodyCache);
            this.footerCache = this.FindElements("xpath:./tfoot/tr");
            rows.AddRange(this.footerCache);
            this.rowCache = rows.ToImmutableArray();
            this.cellCache = new ImmutableArray<Element>?[rows.Count];
        }

        public Element GetCell(int row, int column)
        {
            ImmutableArray<Element> cells = this.GetRow(row);
            if (column < 0) column = cells.Length + column;
            if (column >= 0 && column < cells.Length)
            {
                return cells[column];
            }
            return new Element(this.Browser, this, null, "row", null);
        }

        public ImmutableArray<Element> GetRow(int row)
        {
            if (row < 0) row = this.Rows.Length + row;
            if (row >= 0 && row < this.Rows.Length)
            {
                if (this.cellCache[row] == null)
                {
                    var rowElement = this.Rows[row];
                    this.cellCache[row] = rowElement.FindElements("xpath:./th|./td");
                }
                return this.cellCache[row] ?? ImmutableArray<Element>.Empty;
            }
            return ImmutableArray<Element>.Empty;
        }

        public ImmutableArray<Element> GetColumn(int column)
        {
            Element[] result = new Element[this.Rows.Length];
            for (int i = 0; i < this.Rows.Length; i++)
            {
                result[i] = this.GetCell(i, column);
            }
            return result.ToImmutableArray();
        }

        public Element FindElementInRow(int row, string locator, string tag = null, bool required = true)
        {
            foreach (var rowElement in this.GetRow(row))
            {
                Element result = rowElement.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return result;
            }
            return new Element(this.Browser, this, locator, tag, null);
        }

        public Element FindElementInColumn(int column, string locator, string tag = null, bool required = true)
        {
            foreach (var rowElement in this.GetColumn(column))
            {
                Element result = rowElement.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return result;
            }
            return new Element(this.Browser, this, locator, tag, null);
        }

        public Element FindElementInHeader(string locator, string tag = null, bool required = true)
        {
            foreach (var rowElement in this.Header)
            {
                Element result = rowElement.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return result;
            }
            return new Element(this.Browser, this, locator, tag, null);
        }

        public Element FindElementInBody(string locator, string tag = null, bool required = true)
        {
            foreach (var rowElement in this.Body)
            {
                Element result = rowElement.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return result;
            }
            return new Element(this.Browser, this, locator, tag, null);
        }

        public Element FindElementInFooter(string locator, string tag = null, bool required = true)
        {
            foreach (var rowElement in this.Footer)
            {
                Element result = rowElement.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return result;
            }
            return new Element(this.Browser, this, locator, tag, null);
        }

        public AssertElementResult RowShouldContain(int row, string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInRow(row, locator, tag, false);
            if (child.WebElement == null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Row {1} of {0} contains {2}.";
            string failureMessage = message ?? "Row {1} of {0} should have contained {2} but did not.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, row, childName);
        }

        public AssertElementResult RowShouldNotContain(int row, string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInRow(row, locator, tag, false);
            if (child.WebElement != null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Row {1} of {0} does not contain {2}.";
            string failureMessage = message ?? "Row {1} of {0} should not have contained {2}.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, row, childName);
        }

        public AssertElementResult ColumnShouldContain(int column, string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInColumn(column, locator, tag, false);
            if (child.WebElement == null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Column {1} of {0} contains {2}.";
            string failureMessage = message ?? "Column {1} of {0} should have contained {2} but did not.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, column, childName);
        }

        public AssertElementResult ColumnShouldNotContain(int column, string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInColumn(column, locator, tag, false);
            if (child.WebElement != null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Column {1} of {0} does not contain {2}.";
            string failureMessage = message ?? "Column {1} of {0} should not have contained {2}.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, column, childName);
        }

        public AssertElementResult HeaderShouldContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInHeader(locator, tag, false);
            if (child.WebElement == null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Header of {0} contains {1}.";
            string failureMessage = message ?? "Header of {0} should have contained {1} but did not.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertElementResult HeaderShouldNotContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInHeader(locator, tag, false);
            if (child.WebElement != null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Header of {0} does not contain {1}.";
            string failureMessage = message ?? "Header of {0} should not have contained {1}.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertElementResult BodyShouldContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInBody(locator, tag, false);
            if (child.WebElement == null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Body of {0} contains {1}.";
            string failureMessage = message ?? "Body of {0} should have contained {1} but did not.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertElementResult BodyShouldNotContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInBody(locator, tag, false);
            if (child.WebElement != null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Body of {0} does not contain {1}.";
            string failureMessage = message ?? "Body of {0} should not have contained {1}.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertElementResult FooterShouldContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInFooter(locator, tag, false);
            if (child.WebElement == null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Footer of {0} contains {1}.";
            string failureMessage = message ?? "Footer of {0} should have contained {1} but did not.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, childName);
        }

        public AssertElementResult FooterShouldNotContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
        {
            Element child = this.FindElementInFooter(locator, tag, false);
            if (child.WebElement != null)
            {
                this.LogSource(logLevel);
            }
            string childName = (tag ?? "element") + " '" + locator + " ";
            string successMessage = "Footer of {0} does not contain {1}.";
            string failureMessage = message ?? "Footer of {0} should not have contained {1}.";
            return this.Browser.AssertElement(child, successMessage, failureMessage, this.LogName, childName);
        }
    }
}
