using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using OpenQA.Selenium;

namespace DevToolsX.Testing.Selenium
{
    public class Table : Element
    {
        private static XPaths TableXPaths = new XPaths("xpath:./tr[count(th) > 0]", "xpath:./tr[count(th) = 0]", null, "xpath:./th|./td");
        private static XPaths TTableXPaths = new XPaths("xpath:./thead/tr", "xpath:./tbody/tr", "xpath:./tfoot/tr", "xpath:./th|./td");
        private static XPaths NgxTableXPaths = new XPaths("xpath:.//datatable-header", "xpath:.//datatable-body//datatable-body-row", "xpath:.//datatable-footer", "xpath:.//datatable-header-cell|.//datatable-body-cell|.//datatable-footer-cell");

        private XPaths xpaths;
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

        public ImmutableArray<Element> RowElements
        {
            get
            {
                if (this.rowCache == null) this.CacheRows();
                return this.rowCache ?? ImmutableArray<Element>.Empty;
            }
        }

        public ImmutableArray<Element> HeaderRowElements
        {
            get
            {
                if (this.headerCache == null) this.CacheRows();
                return this.headerCache ?? ImmutableArray<Element>.Empty;
            }
        }

        public ImmutableArray<Element> BodyRowElements
        {
            get
            {
                if (this.bodyCache == null) this.CacheRows();
                return this.bodyCache ?? ImmutableArray<Element>.Empty;
            }
        }

        public ImmutableArray<Element> FooterRowElements
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
            if (this.WebElement == null) return;
            List<Element> rows = new List<Element>();
            if (this.WebElement.TagName.ToLower() == "ngx-datatable")
            {
                this.Browser.LogDebug("Table is '{0}'.", "ngx-datatable");
                this.xpaths = NgxTableXPaths;
                this.CacheRows(this.xpaths, rows);
            }
            else
            {
                this.xpaths = TTableXPaths;
                this.CacheRows(this.xpaths, rows);
                if (rows.Count == 0)
                {
                    this.xpaths = TableXPaths;
                    this.CacheRows(this.xpaths, rows);
                    this.Browser.LogDebug("Table is '{0}'.", "table");
                }
                else
                {
                    this.Browser.LogDebug("Table is '{0}'.", "ttable");
                }
            }
            this.rowCache = rows.ToImmutableArray();
            this.cellCache = new ImmutableArray<Element>?[rows.Count];
            this.Browser.LogDebug("Found {0} rows.", rows.Count);
        }

        private void CacheRows(XPaths xpaths, List<Element> rows)
        {
            if (xpaths.Header != null)
            {
                this.headerCache = this.FindElements(xpaths.Header);
                rows.AddRange(this.headerCache);
            }
            if (xpaths.Body != null)
            {
                this.bodyCache = this.FindElements(xpaths.Body);
                rows.AddRange(this.bodyCache);
            }
            if (xpaths.Footer != null)
            {
                this.footerCache = this.FindElements(xpaths.Footer);
                rows.AddRange(this.footerCache);
            }
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
            if (row < 0) row = this.RowElements.Length + row;
            if (row >= 0 && row < this.RowElements.Length)
            {
                if (this.cellCache[row] == null)
                {
                    var rowElement = this.RowElements[row];
                    this.cellCache[row] = rowElement.FindElements(this.xpaths.Cell);
                }
                return this.cellCache[row] ?? ImmutableArray<Element>.Empty;
            }
            return ImmutableArray<Element>.Empty;
        }

        public ImmutableArray<Element> GetColumn(int column)
        {
            Element[] result = new Element[this.RowElements.Length];
            for (int i = 0; i < this.RowElements.Length; i++)
            {
                result[i] = this.GetCell(i, column);
            }
            return result.ToImmutableArray();
        }

        public int IndexOf(ImmutableArray<Element> cells, string locator, string tag = null)
        {
            int index = 0;
            foreach (var cell in cells)
            {
                Element result = cell.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return index;
                ++index;
            }
            return -1;
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
            foreach (var rowElement in this.HeaderRowElements)
            {
                Element result = rowElement.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return result;
            }
            return new Element(this.Browser, this, locator, tag, null);
        }

        public Element FindElementInBody(string locator, string tag = null, bool required = true)
        {
            foreach (var rowElement in this.BodyRowElements)
            {
                Element result = rowElement.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return result;
            }
            return new Element(this.Browser, this, locator, tag, null);
        }

        public Element FindElementInFooter(string locator, string tag = null, bool required = true)
        {
            foreach (var rowElement in this.FooterRowElements)
            {
                Element result = rowElement.FindElement(locator, tag, required: false);
                if (result.WebElement != null) return result;
            }
            return new Element(this.Browser, this, locator, tag, null);
        }

        public Element RowShouldContain(int row, string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element RowShouldNotContain(int row, string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element ColumnShouldContain(int column, string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element ColumnShouldNotContain(int column, string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element HeaderShouldContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element HeaderShouldNotContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element BodyShouldContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element BodyShouldNotContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element FooterShouldContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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

        public Element FooterShouldNotContain(string locator, string tag = null, string message = null, Microsoft.Extensions.Logging.LogLevel logLevel = Microsoft.Extensions.Logging.LogLevel.Information)
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


        private class XPaths
        {
            public XPaths(string header, string body, string footer, string cell)
            {
                this.Header = header;
                this.Body = body;
                this.Footer = footer;
                this.Cell = cell;
            }

            public string Header { get; private set; }
            public string Body { get; private set; }
            public string Footer { get; private set; }
            public string Cell { get; private set; }
        }
    }
}
