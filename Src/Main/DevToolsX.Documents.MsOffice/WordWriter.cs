﻿using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX.Documents
{
    public class WordWriter : IDocumentWriter, IDisposable
    {
        private Application word;
        private Document document;

        private Style normalStyle;
        private ListGallery bulletListGallery;
        private ListGallery numberedListGallery;

        private List<int> positionStack;
        private List<ListGallery> listStack;
        private List<Table> tableStack;
        private Table table;

        public WordWriter(string document, bool debug = false)
        {
            try
            {
                word = (Application)Marshal.GetActiveObject("Word.Application");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Word is not running. Please, open the document '" + document + "' in Word.");
            }

            try
            {
                foreach (var item in word.Documents)
                {
                    Document doc = (Document)item;
                    if (doc.Name == document)
                    {
                        this.document = doc;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                this.Dispose();
                throw new InvalidOperationException("Document is not open. Please, open the document '" + document + "' in Word.");
            }

            if (this.document == null)
            {
                this.Dispose();
                throw new InvalidOperationException("Document is not open. Please, open the document '" + document + "' in Word.");
            }

            try
            {
                this.document.Activate();
                this.word.ScreenUpdating = debug;
                this.word.Visible = debug;
                this.word.CheckLanguage = false;
                this.positionStack = new List<int>();
                this.listStack = new List<ListGallery>();
                this.tableStack = new List<Table>();
                this.normalStyle = this.document.Styles[WdBuiltinStyle.wdStyleNormal];
                this.bulletListGallery = word.ListGalleries[WdListGalleryType.wdBulletGallery];
                this.numberedListGallery = word.ListGalleries[WdListGalleryType.wdNumberGallery];
            }
            catch (Exception)
            {
                this.Dispose();
                throw new InvalidOperationException("Could not access the document. Please, check the document '" + document + "' in Word.");
            }
        }

        public void Dispose()
        {
            this.word.ScreenUpdating = true;
            this.word.Visible = true;
            this.word.CheckLanguage = true;
            Marshal.ReleaseComObject(this.word);
            this.word = null;
        }

        private void PushPosition()
        {
            this.positionStack.Add(this.word.Selection.Start);
        }

        private Range PopPosition()
        {
            int end = this.word.Selection.End;
            int start = this.positionStack[this.positionStack.Count - 1];
            this.positionStack.RemoveAt(this.positionStack.Count - 1);
            return this.document.Range(start, end);
        }

        private Range CurrentPosition()
        {
            int start = this.word.Selection.End;
            int end = this.word.Selection.End;
            return this.document.Range(start, end);
        }

        public void AddLabel(string id)
        {
            dynamic range = this.CurrentPosition();
            this.word.Selection.Bookmarks.Add(id, range);
        }

        public void AddTableOfContents(int depth)
        {
            dynamic range = this.CurrentPosition();
            this.document.TablesOfContents.Add(range, LowerHeadingLevel: 1, UpperHeadingLevel: depth);
        }

        public void BeginDocument()
        {
        }

        public void BeginList(int level, ListKind listKind)
        {
            switch (listKind)
            {
                case ListKind.None:
                case ListKind.Bullets:
                    this.listStack.Add(this.bulletListGallery);
                    break;
                case ListKind.Numbers:
                case ListKind.RomanNumbers:
                case ListKind.CapitalLetters:
                case ListKind.SmallLetters:
                    this.listStack.Add(this.numberedListGallery);
                    break;
                default:
                    break;
            }
        }

        public void BeginListItem(int level, int index, string title)
        {
            this.PushPosition();
            if (!string.IsNullOrEmpty(title))
            {
                this.BeginMarkup(DocumentMarkupKind.Bold);
                this.Write(title);
                this.EndMarkup(DocumentMarkupKind.Bold);
            }
        }

        public void BeginMarkup(DocumentMarkupKind markupKind)
        {
            this.PushPosition();
        }

        public void BeginParagraph()
        {
        }

        public void BeginReference(string document, string id)
        {
            this.PushPosition();
        }

        public void BeginSectionTitle(int level, string label)
        {
            this.PushPosition();
            if (!string.IsNullOrWhiteSpace(label))
            {
                this.AddLabel(label);
            }
        }

        public void BeginTable(int colCount)
        {
            if (colCount > 0)
            {
                this.table = this.document.Tables.Add(this.word.Selection.Range, 1, colCount, WdDefaultTableBehavior.wdWord9TableBehavior, WdAutoFitBehavior.wdAutoFitWindow);
                this.tableStack.Add(this.table);
            }
        }

        public void BeginTableCell(int rowIndex, int colIndex, bool head)
        {
            if (this.table == null) return;
            int start = this.table.Cell(rowIndex + 1, colIndex + 1).Range.Start;
            int end = this.table.Cell(rowIndex + 1, colIndex + 1).Range.End;
            this.word.Selection.SetRange(start, end);
        }

        public void BeginTableRow(int rowIndex)
        {
            if (rowIndex > 0)
            {
                this.table.Rows.Add();
            }
        }

        public void EndDocument()
        {
        }

        public void EndList(int level, ListKind listKind)
        {
            this.listStack.RemoveAt(this.listStack.Count - 1);
            dynamic range = this.CurrentPosition();
            range.ListFormat.RemoveNumbers(WdNumberType.wdNumberParagraph);
        }

        public void EndListItem(int level, int index, string title)
        {
            dynamic range = this.PopPosition();
            ListGallery listGallery = this.listStack[this.listStack.Count - 1];
            range.ListFormat.ApplyListTemplateWithLevel(
                listGallery.ListTemplates[level + 1],
                ContinuePreviousList: true,
                ApplyTo: WdListApplyTo.wdListApplyToWholeList,
                DefaultListBehavior: WdDefaultListBehavior.wdWord10ListBehavior);
            range.SetListLevel(level + 1);
            this.word.Selection.TypeParagraph();
        }

        public void EndMarkup(DocumentMarkupKind markupKind)
        {
            dynamic range = this.PopPosition();
            switch (markupKind)
            {
                case DocumentMarkupKind.None:
                    range.Style = this.normalStyle;
                    break;
                case DocumentMarkupKind.Bold:
                    range.Font.Bold = true;
                    break;
                case DocumentMarkupKind.Italic:
                    range.Font.Italic = true;
                    break;
                case DocumentMarkupKind.SubScript:
                    range.Font.Subscript = true;
                    break;
                case DocumentMarkupKind.SuperScript:
                    range.Font.Superscript = true;
                    break;
                case DocumentMarkupKind.Code:
                case DocumentMarkupKind.CodeInline:
                    range.Font.Name = "Courier New";
                    range.Font.Size = this.normalStyle.Font.Size - 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid DocumentMarkupKind: " + markupKind);
            }
        }

        public void EndParagraph()
        {
            this.word.Selection.TypeParagraph();
        }

        public void EndReference(string document, string id)
        {
            dynamic range = this.PopPosition();
            this.word.Selection.Hyperlinks.Add(range, Address: document ?? string.Empty, SubAddress: id);
        }

        public void EndSectionTitle(int level, string label)
        {
            dynamic range = this.PopPosition();
            dynamic headingType = null;
            switch (level)
            {
                case 0:
                    headingType = WdBuiltinStyle.wdStyleHeading1;
                    break;
                case 1:
                    headingType = WdBuiltinStyle.wdStyleHeading2;
                    break;
                case 2:
                    headingType = WdBuiltinStyle.wdStyleHeading3;
                    break;
                case 3:
                    headingType = WdBuiltinStyle.wdStyleHeading4;
                    break;
                default:
                    break;
            }
            if (level >= 0 && level <= 3)
            {
                range.Style = headingType;
            }
            this.word.Selection.TypeParagraph();
        }

        public void EndTable(int colCount)
        {
            if (this.table == null) return;
            int end = this.table.Range.StoryLength - 1;
            this.word.Selection.SetRange(end, end);
            this.tableStack.RemoveAt(this.tableStack.Count - 1);
            if (this.tableStack.Count > 0) this.table = this.tableStack[this.tableStack.Count - 1];
            else this.table = null;
        }

        public void EndTableCell(int rowIndex, int colIndex, bool head)
        {
        }

        public void EndTableRow(int index)
        {
        }

        public void Write(string text)
        {
            int start = this.word.Selection.End;
            this.word.Selection.TypeText(text);
            int end = this.word.Selection.End;
            dynamic range = this.document.Range(start, end);
            range.Style = this.normalStyle;
        }

        public void WriteLine()
        {
            this.word.Selection.InsertBreak(WdBreakType.wdLineBreak);
        }

        public void PageBreak()
        {
            this.word.Selection.InsertBreak(WdBreakType.wdPageBreak);
        }
    }
}
