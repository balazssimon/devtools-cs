using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DevToolsX.Documents
{
    public class LatexWriter : TextDocumentWriter
    {
        public LatexWriter(string path)
            : base(path)
        {
        }

        public LatexWriter(string path, Encoding encoding)
            : base(path, encoding)
        {
        }

        public LatexWriter(Stream stream)
            : base(stream)
        {
        }

        public LatexWriter(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }

        private string EscapeText(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            return text.Replace(@"\", @"\textbackslash{}").Replace(@"{", @"\{").Replace(@"}", @"\}").Replace(@"&", @"\&")
                .Replace(@"%", @"\%").Replace(@"$", @"\$").Replace(@"#", @"\#").Replace(@"_", @"\_").Replace(@".",@".{}");
        }

        public override void BeginDocument()
        {
            Writer.WriteLine(@"\documentclass[11pt, oneside, a4paper]{book}");
            Writer.WriteLine();
            Writer.WriteLine(@"\usepackage{graphicx}");
            Writer.WriteLine(@"\usepackage[margin=1.5cm]{geometry}");
            Writer.WriteLine(@"\usepackage{hyperref}");
            Writer.WriteLine(@"\usepackage[magyar]{babel}");
            Writer.WriteLine(@"\usepackage[utf8]{inputenc}");
            Writer.WriteLine(@"\usepackage{t1enc}");
            Writer.WriteLine(@"\usepackage{longtable}");
            Writer.WriteLine();
            Writer.WriteLine(@"\begin{document}");
        }

        public override void EndDocument()
        {
            Writer.WriteLine(@"\end{document}");
        }

        public override void AddTableOfContents(int depth)
        {
            Writer.WriteLine(@"\setcounter{tocdepth}{"+depth+"}");
            Writer.WriteLine(@"\tableofcontents");
        }

        public override void BeginSectionTitle(int level, string label)
        {
            Writer.WriteLine();
            switch (level)
            {
                case 0:
                    Writer.Write(@"\chapter{");
                    break;
                case 1:
                    Writer.Write(@"\section{");
                    break;
                case 2:
                    Writer.Write(@"\subsection{");
                    break;
                case 3:
                    Writer.Write(@"\subsubsection{");
                    break;
                default:
                    Writer.Write(@"\noindent");
                    Writer.Write(@"\textbf{");
                    break;
            }
        }

        public override void EndSectionTitle(int level, string label)
        {
            Writer.WriteLine(@"}");
            if (!string.IsNullOrWhiteSpace(label))
            {
                this.AddLabel(label);
            }
        }

        public override void BeginParagraph()
        {
        }

        public override void Write(string text)
        {
            Writer.Write(text);
        }

        public override void WriteLine()
        {
            Writer.WriteLine(@"\newline");
        }

        public override void EndParagraph()
        {
            Writer.WriteLine();
            Writer.WriteLine();
        }

        public override void BeginMarkup(DocumentMarkupKind markupKind)
        {
            switch (markupKind)
            {
                case DocumentMarkupKind.Bold:
                    Writer.Write(@"\textbf{");
                    break;
                case DocumentMarkupKind.Italic:
                    Writer.Write(@"\emph{");
                    break;
                case DocumentMarkupKind.SubScript:
                    Writer.Write(@"_{");
                    break;
                case DocumentMarkupKind.SuperScript:
                    Writer.Write(@"^{");
                    break;
                case DocumentMarkupKind.Code:
                    Writer.WriteLine();
                    Writer.WriteLine(@"\begin{verbatim}");
                    break;
                case DocumentMarkupKind.CodeInline:
                    Writer.Write(@"\|");
                    break;
                default:
                    throw new DocumentException("Invalid DocumentMarkupKind: " + markupKind);
            }
        }

        public override void EndMarkup(DocumentMarkupKind markupKind)
        {
            switch (markupKind)
            {
                case DocumentMarkupKind.Bold:
                case DocumentMarkupKind.Italic:
                case DocumentMarkupKind.SubScript:
                case DocumentMarkupKind.SuperScript:
                    Writer.Write(@"}");
                    break;
                case DocumentMarkupKind.Code:
                    Writer.WriteLine(@"\end{verbatim}");
                    Writer.WriteLine();
                    break;
                case DocumentMarkupKind.CodeInline:
                    Writer.Write(@"\|");
                    break;
                default:
                    throw new DocumentException("Invalid DocumentMarkupKind: " + markupKind);
            }
        }

        public override void AddLabel(string id)
        {
            Writer.WriteLine(@"\hypertarget{" + this.EscapeText(id) + "}{}");
        }

        public override void BeginReference(string document, string id)
        {
            Writer.Write(@"\hyperlink{" + this.EscapeText(id) + "}{");
        }

        public override void EndReference(string document, string id)
        {
            Writer.Write(@"}");
        }

        public override void BeginList(int level, ListKind listKind)
        {
            Writer.WriteLine(@"\begin{itemize}");
        }

        public override void EndList(int level, ListKind listKind)
        {
            Writer.WriteLine(@"\end{itemize}");
        }

        public override void BeginListItem(int level, int index, string title)
        {
            if (title != null)
            {
                Writer.WriteLine(@"\item{" + this.EscapeText(title) + "} ");
            }
            else
            {
                Writer.Write(@"\item ");
            }
        }

        public override void EndListItem(int level, int index, string title)
        {
            Writer.WriteLine();
        }

        public override void BeginTable(int colCount)
        {
            Writer.WriteLine(@"\begin{center}");
            Writer.Write(@"\begin{longtable}{");
            string sep = " ";
            if (colCount < 2)
            {
                Writer.Write("|" + sep);
            }
            else
            {
                for (int i = 0; i < colCount; i++)
                {
                    if (i == 0)
                    {
                        Writer.Write("|" + sep);
                    }
                    else
                    {
                        Writer.Write("|" + sep);
                    }
                }
            }
            Writer.WriteLine("| }");
        }

        public override void BeginTableRow(int rowIndex)
        {
            Writer.WriteLine(@"\hline");
        }

        public override void EndTableRow(int index)
        {
            Writer.WriteLine(@"\\");
        }

        public override void BeginTableCell(int rowIndex, int colIndex, bool head)
        {
            if (colIndex > 0)
            {
                Writer.Write(@" & ");
            }
            if (head)
            {
                Writer.Write(@"\textbf{");
            }
            else
            {
                Writer.Write(@"");
            }
        }

        public override void EndTableCell(int rowIndex, int colIndex, bool head)
        {
            if (head)
            {
                Writer.Write(@"}");
            }
            else
            {
                Writer.Write(@"");
            }
        }

        public override void EndTable(int colCount)
        {
            Writer.WriteLine(@"\hline");
            Writer.WriteLine(@"\end{longtable}");
            Writer.WriteLine(@"\end{center}");
        }

        public override void PageBreak()
        {
            Writer.WriteLine();
            Writer.WriteLine(@"\newpage");
            Writer.WriteLine();
        }
    }
}

