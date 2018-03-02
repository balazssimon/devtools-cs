using DevToolsX.Documents.Symbols;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DevToolsX.Documents
{
    public class DocumentGenerator : IDisposable
    {
        private IDocumentWriter writer;
        private bool newParagraph = true;
        private bool isInParagraph = false;
        private bool appendSpace = false;
        private bool disposing = false;

        private bool isInCode = false;
        private int listLevel = 0;

        private List<Begin> beginStack = new List<Begin>();
        private List<ListIterator> listIteratorStack = new List<ListIterator>();
        private List<TableIterator> tableIteratorStack = new List<TableIterator>();

        private DocumentGenerator(IDocumentWriter writer)
        {
            this.writer = writer;
            this.writer.BeginDocument();
        }

        public bool AutoAppendSpaceBetweenWords { get; set; }

        public static DocumentGenerator CreateDocument(IDocumentWriter writer)
        {
            return new DocumentGenerator(writer);
        }

        public static DocumentGenerator CreateLatexDocument(string path)
        {
            return new DocumentGenerator(new LatexWriter(path, Encoding.UTF8));
        }

        public static DocumentGenerator CreateLatexDocument(string path, Encoding encoding)
        {
            return new DocumentGenerator(new LatexWriter(path, encoding));
        }

        public static DocumentGenerator CreateLatexDocument(Stream stream)
        {
            return new DocumentGenerator(new LatexWriter(stream, Encoding.UTF8));
        }

        public static DocumentGenerator CreateLatexDocument(Stream stream, Encoding encoding)
        {
            return new DocumentGenerator(new LatexWriter(stream, encoding));
        }

        public static DocumentGenerator CreateHtmlDocument(string path)
        {
            return new DocumentGenerator(new HtmlWriter(path, Encoding.UTF8));
        }

        public static DocumentGenerator CreateHtmlDocument(string path, Encoding encoding)
        {
            return new DocumentGenerator(new HtmlWriter(path, encoding));
        }

        public static DocumentGenerator CreateHtmlDocument(Stream stream)
        {
            return new DocumentGenerator(new HtmlWriter(stream, Encoding.UTF8));
        }

        public static DocumentGenerator CreateHtmlDocument(Stream stream, Encoding encoding)
        {
            return new DocumentGenerator(new HtmlWriter(stream, encoding));
        }

        public void Dispose()
        {
            if (this.disposing) return;
            this.disposing = true;
            this.EndParagraphIfNecessary();
            this.writer.EndDocument();
            IDisposable disposableWriter = this.writer as IDisposable;
            if (disposableWriter != null)
            {
                disposableWriter.Dispose();
            }
        }

        private void FlushBegin()
        {
            int i = this.beginStack.Count - 1;
            while (i >= 0 && !this.beginStack[i].IsFlushed) --i;
            ++i;
            while (i < this.beginStack.Count)
            {
                this.beginStack[i].Apply(this);
                ++i;
            }
        }

        private Begin CurrentBegin
        {
            get
            {
                if (this.beginStack.Count > 0)
                {
                    return this.beginStack[this.beginStack.Count - 1];
                }
                return null;
            }
        }

        private TBegin PopBegin<TBegin>(string close)
            where TBegin : Begin
        {
            Begin currentBegin = this.CurrentBegin;
            TBegin typedBegin = currentBegin as TBegin;
            if (typedBegin != null)
            {
                if (this.beginStack.Count > 0)
                {
                    this.beginStack.RemoveAt(this.beginStack.Count - 1);
                    return typedBegin;
                }
            }
            else
            {
                throw new DocumentException($"Cannot close '{currentBegin}' with '{close}'");
            }
            return null;
        }

        public void AddImage(string filePath)
        {
            this.writer.AddImage(filePath);
        }

        private ListIterator CurrentListIterator
        {
            get
            {
                if (this.listIteratorStack.Count == 0) return null;
                return this.listIteratorStack[this.listIteratorStack.Count - 1];
            }
        }

        private TableIterator CurrentTableIterator
        {
            get
            {
                if (this.tableIteratorStack.Count == 0) return null;
                return this.tableIteratorStack[this.tableIteratorStack.Count - 1];
            }
        }

        public void Write(bool value, MarkupKind markup = MarkupKind.None)
        {
            this.Append(value.ToString(), markup);
        }

        public void Write(char value, MarkupKind markup = MarkupKind.None)
        {
            this.Append(value.ToString(), markup);
        }

        public void Write(int value, MarkupKind markup = MarkupKind.None)
        {
            this.Append(value.ToString(), markup);
        }

        public void Write(long value, MarkupKind markup = MarkupKind.None)
        {
            this.Append(value.ToString(), markup);
        }

        public void Write(float value, MarkupKind markup = MarkupKind.None)
        {
            this.Append(value.ToString(), markup);
        }

        public void Write(double value, MarkupKind markup = MarkupKind.None)
        {
            this.Append(value.ToString(), markup);
        }

        public void Write(string text, MarkupKind markup = MarkupKind.None)
        {
            this.Append(text, markup);
        }

        public void Write(string text, params object[] args)
        {
            this.Append(string.Format(text, args));
        }

        public void WriteLine()
        {
            this.EndParagraphIfNecessary();
        }

        public void LineBreak()
        {
            this.writer.WriteLine();
            this.appendSpace = false;
        }

        public void WriteLine(bool value, MarkupKind markup = MarkupKind.None)
        {
            this.AppendLine(value.ToString(), markup);
        }

        public void WriteLine(char value, MarkupKind markup = MarkupKind.None)
        {
            this.AppendLine(value.ToString(), markup);
        }

        public void WriteLine(int value, MarkupKind markup = MarkupKind.None)
        {
            this.AppendLine(value.ToString(), markup);
        }

        public void WriteLine(long value, MarkupKind markup = MarkupKind.None)
        {
            this.AppendLine(value.ToString(), markup);
        }

        public void WriteLine(float value, MarkupKind markup = MarkupKind.None)
        {
            this.AppendLine(value.ToString(), markup);
        }

        public void WriteLine(double value, MarkupKind markup = MarkupKind.None)
        {
            this.AppendLine(value.ToString(), markup);
        }

        public void WriteLine(string text, MarkupKind markup = MarkupKind.None)
        {
            this.AppendLine(text, markup);
        }

        public void WriteLine(string text, params object[] args)
        {
            this.AppendLine(string.Format(text, args));
        }

        private void Append(string text, MarkupKind markup = MarkupKind.None)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (this.AutoAppendSpaceBetweenWords && this.appendSpace)
                {
                    this.writer.Write(" ");
                }
                this.FlushBegin();
                this.BeginParagraphIfNecessary();
                if (markup != MarkupKind.None)
                {
                    this.writer.BeginMarkup(markup);
                }
                this.writer.Write(text);
                if (markup != MarkupKind.None)
                {
                    this.writer.EndMarkup(markup);
                }
                this.newParagraph = false;
                this.appendSpace = true;
            }
        }

        private void AppendLine(string text, MarkupKind markup = MarkupKind.None)
        {
            this.Append(text);
            if (!string.IsNullOrEmpty(text))
            {
                this.EndParagraphIfNecessary();
            }
        }

        private void DisableParagraph()
        {
            this.isInParagraph = false;
            this.newParagraph = false;
            this.appendSpace = false;
        }

        private void EnableParagraph()
        {
            this.EndParagraphIfNecessary();
        }

        public void NewParagraph()
        {
            if (this.isInParagraph)
            {
                this.EndParagraphIfNecessary();
                this.BeginParagraphIfNecessary();
            }
            else
            {
                this.EndParagraphIfNecessary();
                this.BeginParagraphIfNecessary();
                this.EndParagraphIfNecessary();
                this.BeginParagraphIfNecessary();
            }
        }

        public void NewPage()
        {
            this.writer.PageBreak();
        }

        private void BeginParagraphIfNecessary()
        {
            if (!this.isInParagraph && this.newParagraph)
            {
                this.writer.BeginParagraph();
                this.isInParagraph = true;
            }
            this.appendSpace = false;
        }

        private void EndParagraphIfNecessary()
        {
            if (this.isInParagraph)
            {
                this.writer.EndParagraph();
                this.newParagraph = true;
                this.isInParagraph = false;
            }
            this.newParagraph = true;
            this.appendSpace = false;
        }

        public void WriteSectionTitle(int level, string title, string label = null)
        {
            if (!string.IsNullOrEmpty(title))
            {
                this.BeginSectionTitle(level, label);
                this.Write(title);
                this.EndSectionTitle();
            }
        }

        public void WriteReference(string document, string id, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                this.BeginReference(document, id);
                this.Write(text);
                this.EndReference();
            }
        }

        public void AddTableOfContents(int depth)
        {
            this.writer.AddTableOfContents(depth);
        }

        public void BeginSectionTitle(int level, string label = null)
        {
            this.EndParagraphIfNecessary();
            this.DisableParagraph();
            this.beginStack.Add(new SectionTitleBegin() { Level = level, Label = label });
        }

        public void EndSectionTitle()
        {
            SectionTitleBegin begin = this.PopBegin<SectionTitleBegin>("EndSectionTitle");
            if (begin.IsFlushed)
            {
                this.writer.EndSectionTitle(begin.Level, begin.Label);
            }
            this.EnableParagraph();
        }

        public void BeginMarkup(MarkupKind markupKind)
        {
            if (markupKind == MarkupKind.Code)
            {
                this.EndParagraphIfNecessary();
                this.isInCode = true;
                this.appendSpace = false;
            }
            this.beginStack.Add(new MarkupBegin() { MarkupKind = markupKind });
        }

        public void EndMarkup()
        {
            MarkupBegin begin = this.PopBegin<MarkupBegin>("EndMarkup");
            if (begin.IsFlushed)
            {
                this.writer.EndMarkup(begin.MarkupKind);
            }
            if (begin.MarkupKind == MarkupKind.Code)
            {
                this.isInCode = false;
                this.isInParagraph = false;
                this.newParagraph = true;
                this.appendSpace = false;
            }
        }

        public void AddLabel(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                this.writer.AddLabel(id);
            }
            else
            {
                throw new DocumentException($"Invalid label identifier: '{id}'. It must be non-null and non-whitespace.");
            }
        }
        
        public void BeginReference(string document, string id)
        {
            if (document == null) document = string.Empty;
            if (id == null) id = string.Empty;
            this.beginStack.Add(new ReferenceBegin() { Document = document, Id = id });
        }

        public void EndReference()
        {
            ReferenceBegin begin = this.PopBegin<ReferenceBegin>("EndReference");
            if (begin.IsFlushed)
            {
                this.writer.EndReference(begin.Document, begin.Id);
            }
        }
        
        public void BeginList(ListKind listKind = ListKind.None)
        {
            ListIterator iterator = this.CurrentListIterator;
            if (iterator != null)
            {
                this.CloseListItem(iterator);
            }
            this.EndParagraphIfNecessary();
            this.DisableParagraph();
            int level = this.listLevel++;
            this.beginStack.Add(new ListBegin() { Level = level, ListKind = listKind });
            this.listIteratorStack.Add(new ListIterator(this, level, listKind));
        }

        public void AddListItem(string title = null)
        {
            ListIterator iterator = this.CurrentListIterator;
            if (iterator == null) throw new DocumentException("Cannot add a list item within a non-list environment. Wrap AddListItem() between a BeginList() and an EndList() call.");
            iterator.Next(title);
        }

        private void BeginListItem(ListIterator iterator)
        {
            this.DisableParagraph();
            this.beginStack.Add(new ListItemBegin() { Level = iterator.Level, Index = iterator.Index, Title = iterator.Title });
            this.appendSpace = false;
        }

        private void CloseListItem(ListIterator iterator)
        {
            ListItemBegin begin = this.CurrentBegin as ListItemBegin;
            if (begin != null && !begin.IsClosed)
            {
                if (begin.IsFlushed)
                {
                    this.writer.EndListItem(begin.Level, begin.Index, begin.Title);
                    this.EnableParagraph();
                }
                begin.IsClosed = true;
            }
        }

        private void EndListItem(ListIterator iterator)
        {
            ListItemBegin begin = this.PopBegin<ListItemBegin>("EndListItem");
            if (begin.IsFlushed)
            {
                if (!begin.IsClosed)
                {
                    this.writer.EndListItem(begin.Level, begin.Index, begin.Title);
                    this.EnableParagraph();
                }
            }
            else
            {
                iterator.Previous();
            }
        }

        public void EndList()
        {
            ListIterator iterator = this.CurrentListIterator;
            if (iterator == null) throw new DocumentException("Cannot end a list item within a non-list environment. Start a list with BeginList() first.");
            iterator.End();

            ListBegin begin = this.PopBegin<ListBegin>("EndList");
            --this.listLevel;
            if (begin.IsFlushed)
            {
                this.writer.EndList(begin.Level, begin.ListKind);
            }
            if (this.listIteratorStack.Count > 0)
            {
                this.listIteratorStack.RemoveAt(this.listIteratorStack.Count - 1);
            }
            else
            {
                // Should not happen:
                throw new DocumentException("Cannot remove list iterator.");
            }
            this.EnableParagraph();
        }
        
        public void BeginTable(int columnCount, int headColumnCount = 0, int headRowCount = 0)
        {
            this.EndParagraphIfNecessary();
            //this.DisableParagraph();
            this.beginStack.Add(new TableBegin() { ColumnCount = columnCount, HeadColumnCount = headColumnCount, HeadRowCount = headRowCount });
            this.tableIteratorStack.Add(new TableIterator(this, columnCount, headColumnCount, headRowCount));
        }

        public void AddTableCell()
        {
            TableIterator iterator = this.CurrentTableIterator;
            if (iterator == null) throw new DocumentException("Cannot add a cell within a non-table environment. Wrap AddTableCell() between a BeginTable() and an EndTable() call.");
            iterator.Next();
        }

        private void BeginTableCell(TableIterator iterator)
        {
            this.FlushBegin();
            if (iterator.Column == 0)
            {
                if (iterator.Row > 0)
                {
                    this.writer.EndTableRow(iterator.Row);
                }
                this.writer.BeginTableRow(iterator.Row);
            }
            this.writer.BeginTableCell(iterator.Row, iterator.Column, iterator.IsHead);
            this.newParagraph = true;
            this.isInParagraph = false;
        }

        private void EndTableCell(TableIterator iterator)
        {
            //this.EndParagraphIfNecessary();
            this.writer.EndTableCell(iterator.Row, iterator.Column, iterator.IsHead);
        }

        public void EndTable()
        {
            TableIterator iterator = this.CurrentTableIterator;
            if (iterator == null) throw new DocumentException("Cannot end a table a non-table environment. Start a table with BeginTable() first.");
            iterator.End();

            TableBegin begin = this.PopBegin<TableBegin>("EndTable");
            if (begin.IsFlushed)
            {
                this.writer.EndTableRow(iterator.Row);
                this.writer.EndTable(begin.ColumnCount);
            }
            if (this.tableIteratorStack.Count > 0)
            {
                this.tableIteratorStack.RemoveAt(this.tableIteratorStack.Count - 1);
            }
            else
            {
                // Should not happen:
                throw new DocumentException("Cannot remove table iterator.");
            }
            this.EnableParagraph();
        }

        private abstract class Begin
        {
            public bool IsFlushed { get; private set; }

            public void Apply(DocumentGenerator generator)
            {
                this.IsFlushed = true;
                this.DoApply(generator);
            }

            protected abstract void DoApply(DocumentGenerator generator);
        }

        private class SectionTitleBegin : Begin
        {
            public string Label { get; set; }
            public int Level { get; set; }

            protected override void DoApply(DocumentGenerator generator)
            {
                generator.writer.BeginSectionTitle(this.Level, this.Label);
            }

            public override string ToString()
            {
                return "BeginSectionTitle";
            }
        }

        private class MarkupBegin : Begin
        {
            public MarkupKind MarkupKind { get; set; }

            protected override void DoApply(DocumentGenerator generator)
            {
                generator.writer.BeginMarkup(this.MarkupKind);
            }

            public override string ToString()
            {
                return "BeginMarkup";
            }
        }

        private class ReferenceBegin : Begin
        {
            public string Document { get; set; }
            public string Id { get; set; }

            protected override void DoApply(DocumentGenerator generator)
            {
                generator.writer.BeginReference(this.Document, this.Id);
            }

            public override string ToString()
            {
                return "BeginReference";
            }
        }

        private class ListBegin : Begin
        {
            public int Level { get; set; }
            public ListKind ListKind { get; set; }

            protected override void DoApply(DocumentGenerator generator)
            {
                generator.writer.BeginList(this.Level, this.ListKind);
            }

            public override string ToString()
            {
                return "BeginList";
            }
        }

        private class ListItemBegin : Begin
        {
            public int Level { get; set; }
            public int Index { get; set; }
            public string Title { get; set; }
            public bool IsClosed { get; set; }

            protected override void DoApply(DocumentGenerator generator)
            {
                generator.writer.BeginListItem(this.Level, this.Index, this.Title);
            }

            public override string ToString()
            {
                return "BeginListItem";
            }
        }

        private class TableBegin : Begin
        {
            public int ColumnCount { get; set; }

            public int HeadColumnCount { get; set; }
            public int HeadRowCount { get; set; }

            protected override void DoApply(DocumentGenerator generator)
            {
                generator.writer.BeginTable(this.ColumnCount);
            }

            public override string ToString()
            {
                return "BeginTable";
            }
        }

        private class ListIterator
        {
            private DocumentGenerator generator;

            public ListIterator(DocumentGenerator generator, int level, ListKind listKind)
            {
                this.generator = generator;
                this.Level = level;
                this.ListKind = listKind;
                this.Index = -1;
            }

            public int Level { get; private set; }
            public int Index { get; private set; }
            public string Title { get; private set; }
            public ListKind ListKind { get; private set; }

            public void Previous()
            {
                --this.Index;
            }

            public void Next(string title)
            {
                if (this.Index >= 0)
                {
                    this.generator.EndListItem(this);
                }
                ++this.Index;
                this.Title = title;
                this.generator.BeginListItem(this);
            }

            public void End()
            {
                if (this.Index >= 0)
                {
                    this.generator.EndListItem(this);
                }
            }
        }

        private class TableIterator
        {
            private DocumentGenerator generator;
            private int index;

            public TableIterator(DocumentGenerator generator, int columnCount, int headColumnCount, int headRowCount)
            {
                this.generator = generator;
                this.ColumnCount = columnCount;
                this.HeadColumnCount = headColumnCount;
                this.HeadRowCount = headRowCount;
                this.index = -1;
            }

            public int ColumnCount { get; private set; }

            public int HeadColumnCount { get; private set; }
            public int HeadRowCount { get; private set; }

            public int Column
            {
                get
                {
                    if (this.ColumnCount == 0) return 0;
                    return this.index % this.ColumnCount;
                }
            }
            public int Row
            {
                get
                {
                    if (this.ColumnCount == 0) return 0;
                    return this.index / this.ColumnCount;
                }
            }

            public bool IsHead
            {
                get
                {
                    return this.Column < this.HeadColumnCount || this.Row < this.HeadRowCount;
                }
            }

            public void Next()
            {
                if (this.index >= 0)
                {
                    this.generator.EndTableCell(this);
                }
                ++this.index;
                this.generator.BeginTableCell(this);
            }

            public void End()
            {
                if (this.index >= 0)
                {
                    this.generator.EndTableCell(this);
                }
            }
        }
    }


}
