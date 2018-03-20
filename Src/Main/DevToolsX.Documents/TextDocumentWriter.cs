using DevToolsX.Documents.Symbols;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX.Documents
{
    public abstract class TextDocumentWriter : IDocumentWriter, IDisposable
    {
        private bool disposing = false;
        protected TextWriter Writer { get; private set; }

        public TextDocumentWriter(string path)
        {
            this.Writer = new StreamWriter(path);
        }

        public TextDocumentWriter(string path, Encoding encoding)
        {
            this.Writer = new StreamWriter(path, false, encoding);
        }

        public TextDocumentWriter(Stream stream)
        {
            this.Writer = new StreamWriter(stream);
        }

        public TextDocumentWriter(Stream stream, Encoding encoding)
        {
            this.Writer = new StreamWriter(stream, encoding);
        }

        public void Dispose()
        {
            if (this.disposing) return;
            this.disposing = true;
            this.Writer.Dispose();
            this.Writer = null;
        }

        public abstract void BeginDocument();
        public abstract void EndDocument();
        public abstract void AddTableOfContents(int depth);
        public abstract void BeginSectionTitle(int level, string label);
        public abstract void EndSectionTitle(int level, string label);
        public abstract void BeginParagraph();
        public abstract void Write(string text);
        public abstract void WriteLine();
        public abstract void EndParagraph();
        public abstract void BeginMarkup(IEnumerable<MarkupKind> markupKinds, Color foregroundColor, Color backgroundColor);
        public abstract void EndMarkup(IEnumerable<MarkupKind> markupKinds, Color foregroundColor, Color backgroundColor);
        public abstract void AddLabel(string id);
        public abstract void BeginReference(string document, string id);
        public abstract void EndReference(string document, string id);
        public abstract void BeginList(int level, ListKind listKind);
        public abstract void EndList(int level, ListKind listKind);
        public abstract void BeginListItem(int level, int index, string title);
        public abstract void EndListItem(int level, int index, string title);
        public abstract void BeginTable(int colCount);
        public abstract void BeginTableRow(int rowIndex);
        public abstract void EndTableRow(int index);
        public abstract void BeginTableCell(int rowIndex, int colIndex, bool head);
        public abstract void EndTableCell(int rowIndex, int colIndex, bool head);
        public abstract void EndTable(int colCount);
        public abstract void PageBreak();
        public abstract void LineBreak();
        public abstract void AddImage(string path);
    }
}
