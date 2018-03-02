using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DevToolsX.Documents.Symbols;

namespace DevToolsX.Documents
{
    public class HtmlWriter : TextDocumentWriter
    {
        private bool isInCode;

        public HtmlWriter(string path)
            : base(path)
        {
        }

        public HtmlWriter(string path, Encoding encoding)
            : base(path, encoding)
        {
        }

        public HtmlWriter(Stream stream)
            : base(stream)
        {
        }

        public HtmlWriter(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }


        private string EscapeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            return text.Replace(@"&", @"&amp;").Replace(@"<", @"&lt;").Replace(@">", @"&gt;").Replace(@"'", @"&apos;")
                .Replace(@"""", @"&quot;");
        }

        public override void BeginDocument()
        {
            Writer.WriteLine(@"<html>");
            Writer.WriteLine(@"<head>");
            Writer.WriteLine(@"</head>");
            Writer.WriteLine(@"<body>");
            Writer.WriteLine();
        }

        public override void EndDocument()
        {
            Writer.WriteLine(@"</body>");
            Writer.WriteLine(@"</html>");
        }

        public override void AddTableOfContents(int depth)
        {
            Writer.WriteLine(@"Table of Contents (TODO)");
        }

        public override void BeginSectionTitle(int level, string label)
        {
            Writer.WriteLine();
            switch (level)
            {
                case 0:
                    Writer.Write(@"<h1>");
                    break;
                case 1:
                    Writer.Write(@"<h2>");
                    break;
                case 2:
                    Writer.Write(@"<h3>");
                    break;
                case 3:
                    Writer.Write(@"<h4>");
                    break;
                case 4:
                    Writer.Write(@"<h5>");
                    break;
                default:
                    Writer.Write(@"<p><b>");
                    break;
            }
            if (!string.IsNullOrWhiteSpace(label))
            {
                this.AddLabel(label);
            }
        }

        public override void EndSectionTitle(int level, string label)
        {
            switch (level)
            {
                case 0:
                    Writer.Write(@"</h1>");
                    break;
                case 1:
                    Writer.Write(@"</h2>");
                    break;
                case 2:
                    Writer.Write(@"</h3>");
                    break;
                case 3:
                    Writer.Write(@"</h4>");
                    break;
                case 4:
                    Writer.Write(@"</h5>");
                    break;
                default:
                    Writer.Write(@"</b></p>");
                    break;
            }
            Writer.WriteLine();
        }

        public override void BeginParagraph()
        {
            if (!this.isInCode)
            {
                Writer.WriteLine(@"<p>");
            }
        }

        public override void Write(string text)
        {
            Writer.Write(this.EscapeText(text));
        }

        public override void WriteLine()
        {
            if (this.isInCode)
            {
                Writer.WriteLine();
            }
            else
            {
                Writer.WriteLine(@"<br/>");
            }
        }

        public override void EndParagraph()
        {
            if (this.isInCode)
            {
                Writer.WriteLine();
            }
            else
            {
                Writer.WriteLine();
                Writer.WriteLine(@"</p>");
            }
        }

        public override void BeginMarkup(MarkupKind markupKind)
        {
            switch (markupKind)
            {
                case MarkupKind.Bold:
                    Writer.Write(@"<b>");
                    break;
                case MarkupKind.Italic:
                    Writer.Write(@"<i>");
                    break;
                case MarkupKind.Code:
                    Writer.WriteLine();
                    Writer.WriteLine(@"<pre><code>");
                    break;
                case MarkupKind.CodeInline:
                    Writer.Write(@"<code>");
                    break;
                default:
                    throw new DocumentException("Invalid MarkupKind: " + markupKind);
            }
            if (markupKind == MarkupKind.Code || markupKind == MarkupKind.CodeInline)
            {
                this.isInCode = true;
            }
        }

        public override void EndMarkup(MarkupKind markupKind)
        {
            switch (markupKind)
            {
                case MarkupKind.Bold:
                    Writer.Write(@"</b>");
                    break;
                case MarkupKind.Italic:
                    Writer.Write(@"</i>");
                    break;
                case MarkupKind.Code:
                    Writer.WriteLine(@"</code></pre>");
                    Writer.WriteLine();
                    break;
                case MarkupKind.CodeInline:
                    Writer.Write(@"</code>");
                    break;
                default:
                    throw new DocumentException("Invalid MarkupKind: " + markupKind);
            }
            if (markupKind == MarkupKind.Code || markupKind == MarkupKind.CodeInline)
            {
                this.isInCode = false;
            }
        }

        public override void AddLabel(string id)
        {
            Writer.Write(@"<a name=""" + this.EscapeText(id) + @"""/>");
        }

        public override void BeginReference(string document, string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                Writer.Write(@"<a href=""" + this.EscapeText(document) + "#" + this.EscapeText(id) + @""">");
            }
            else
            {
                Writer.Write(@"<a href=""" + this.EscapeText(document) + @""">");
            }
        }

        public override void EndReference(string document, string id)
        {
            Writer.Write(@"</a>");
        }

        public override void BeginList(int level, ListKind listKind)
        {
            switch (listKind)
            {
                case ListKind.None:
                case ListKind.Bullets:
                    Writer.WriteLine(@"<ul>");
                    break;
                case ListKind.Numbers:
                case ListKind.RomanNumbers:
                case ListKind.CapitalLetters:
                case ListKind.SmallLetters:
                    Writer.WriteLine(@"<ol>");
                    break;
                default:
                    throw new DocumentException("Invalid ListKind: " + listKind);
            }
        }

        public override void EndList(int level, ListKind listKind)
        {
            switch (listKind)
            {
                case ListKind.None:
                case ListKind.Bullets:
                    Writer.WriteLine(@"</ul>");
                    break;
                case ListKind.Numbers:
                case ListKind.RomanNumbers:
                case ListKind.CapitalLetters:
                case ListKind.SmallLetters:
                    Writer.WriteLine(@"</ol>");
                    break;
                default:
                    throw new DocumentException("Invalid ListKind: " + listKind);
            }
        }

        public override void BeginListItem(int level, int index, string title)
        {
            if (title != null)
            {
                Writer.Write(@"<li><b>" + this.EscapeText(title) + "<b> ");
            }
            else
            {
                Writer.Write(@"<li>");
            }
        }

        public override void EndListItem(int level, int index, string title)
        {
            Writer.WriteLine(@"</li>");
        }

        public override void BeginTable(int colCount)
        {
            Writer.WriteLine(@"<table>");
        }

        public override void BeginTableRow(int rowIndex)
        {
            Writer.WriteLine(@"<tr>");
        }

        public override void EndTableRow(int index)
        {
            Writer.WriteLine(@"</tr>");
        }

        public override void BeginTableCell(int rowIndex, int colIndex, bool head)
        {
            if (head)
            {
                Writer.Write(@"<th>");
            }
            else
            {
                Writer.Write(@"<td>");
            }
        }

        public override void EndTableCell(int rowIndex, int colIndex, bool head)
        {
            if (head)
            {
                Writer.WriteLine(@"</th>");
            }
            else
            {
                Writer.WriteLine(@"</td>");
            }
        }

        public override void EndTable(int colCount)
        {
            Writer.WriteLine(@"</table>");
        }

        public override void PageBreak()
        {
            
        }

        public override void AddImage(string path)
        {
            Writer.WriteLine(@"<img src=""" + path + @"""/>");
        }
    }
}
