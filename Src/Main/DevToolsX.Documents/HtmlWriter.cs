using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DevToolsX.Documents.Symbols;
using System.Drawing;
using DevToolsX.Documents.Utils;

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

        public override void BeginMarkup(IEnumerable<MarkupKind> markupKinds, Color foregroundColor, Color backgroundColor)
        {
            string style = string.Empty;
            bool code = false;
            bool inlineCode = false;
            if (foregroundColor != Color.Empty || backgroundColor != Color.Empty)
            {
                if (foregroundColor != Color.Empty)
                {
                    if (style.Length > 0) style += "; ";
                    style += "color:" + ColorTranslator.ToHtml(foregroundColor);
                }
                if (backgroundColor != Color.Empty)
                {
                    if (style.Length > 0) style += ";";
                    style += "background:" + ColorTranslator.ToHtml(backgroundColor);
                }
            }
            foreach (var markupKind in markupKinds)
            {
                switch (markupKind)
                {
                    case MarkupKind.Bold:
                        if (style.Length > 0) style += "; ";
                        style += "font-weight:bold";
                        break;
                    case MarkupKind.Italic:
                        if (style.Length > 0) style += "; ";
                        style += "font-style:italic";
                        break;
                    case MarkupKind.Underline:
                        if (style.Length > 0) style += "; ";
                        style += "text-decoration:underline";
                        break;
                    case MarkupKind.Strikethrough:
                        if (style.Length > 0) style += "; ";
                        style += "text-decoration:line-through";
                        break;
                    case MarkupKind.SubScript:
                        if (style.Length > 0) style += "; ";
                        style += "vertical-align:sub";
                        break;
                    case MarkupKind.SuperScript:
                        if (style.Length > 0) style += "; ";
                        style += "vertical-align:super";
                        break;
                    case MarkupKind.Code:
                        code = true;
                        break;
                    case MarkupKind.CodeInline:
                        inlineCode = true;
                        break;
                    default:
                        throw new DocumentException("Invalid MarkupKind: " + markupKind);
                }
            }
            Writer.Write(@"<span style=""" + style + @""">");
            if (code)
            {
                Writer.WriteLine();
                Writer.WriteLine(@"<pre><code>");
                this.isInCode = true;
            }
            else if (inlineCode)
            { 
                Writer.Write(@"<code>");
                this.isInCode = true;
            }
        }

        public override void EndMarkup(IEnumerable<MarkupKind> markupKinds, Color foregroundColor, Color backgroundColor)
        {
            bool code = false;
            bool inlineCode = false;
            foreach (var markupKind in markupKinds)
            {
                switch (markupKind)
                {
                    case MarkupKind.Code:
                        code = true;
                        break;
                    case MarkupKind.CodeInline:
                        inlineCode = true;
                        break;
                }
            }
            if (code)
            {
                Writer.WriteLine();
                Writer.WriteLine(@"</code></pre>");
                this.isInCode = false;
            }
            else if (inlineCode)
            {
                Writer.Write(@"</code>");
                this.isInCode = false;
            }
            Writer.Write(@"</span>");
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
