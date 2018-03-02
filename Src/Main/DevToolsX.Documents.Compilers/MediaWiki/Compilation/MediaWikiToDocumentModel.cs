using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using DevToolsX.Documents.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace DevToolsX.Documents.Compilers.MediaWiki
{
    public class MediaWikiToDocumentModel
    {
        public static ImmutableModel Compile(string mediaWikiText)
        {
            MediaWikiSyntaxTree tree = MediaWikiSyntaxTree.ParseText(mediaWikiText);
            var root = tree.GetRoot();
            MediaWikiToDocumentVisitor visitor = new MediaWikiToDocumentVisitor();
            root.Accept(visitor);
            return visitor.Model.ToImmutable();
        }
    }

    internal class MediaWikiToDocumentVisitor : MediaWikiSyntaxVisitor
    {
        private DocumentModelFactory factory;
        private MutableModel model;
        private DocumentBuilder document;
        private Stack<ContentContainerBuilder> containerStack = new Stack<ContentContainerBuilder>();
        private Stack<string> formatStack = new Stack<string>();
        private Stack<ListInfo> listStack = new Stack<ListInfo>();
        private Stack<TableInfo> tableStack = new Stack<TableInfo>();
        private bool addParagraphSpace = false;

        public MediaWikiToDocumentVisitor()
        {
            this.model = new MutableModel();
            this.factory = new DocumentModelFactory(this.model);
            this.document = this.factory.Document();
        }

        public MutableModel Model
        {
            get { return this.model; }
        }

        private void AddContent(ContentBuilder content)
        {
            this.PeekContainer().Text.Add(content);
        }

        private void PushContainer(ContentContainerBuilder container)
        {
            this.containerStack.Push(container);
        }

        private ContentContainerBuilder PeekContainer()
        {
            if (this.containerStack.Count > 0) return this.containerStack.Peek();
            else return this.document;
        }

        private ContentContainerBuilder PopContainer()
        {
            return this.containerStack.Pop();
        }

        private void ClearContainer()
        {
            this.containerStack.Clear();
        }

        public override void DefaultVisit(SyntaxNode node)
        {
            foreach (var child in node.ChildNodes())
            {
                child.Accept(this);
            }
        }

        public override void VisitMain(MainSyntax node)
        {
            base.VisitMain(node);
        }


        public override void VisitHeading(HeadingSyntax node)
        {
            this.formatStack.Clear();
            var heading = this.factory.SectionTitle();
            heading.Level = node.HeadingStart.THeading.ValueText.Length - 1;
            heading.Title = this.GetText(node.HeadingText).Trim();
            this.AddContent(heading);
            this.ClearContainer();
            this.addParagraphSpace = false;
        }

        public override void VisitParagraph(ParagraphSyntax node)
        {
            this.formatStack.Clear();
            var paragraph = this.factory.Paragraph();
            this.AddContent(paragraph);
            this.PushContainer(paragraph);
            base.VisitParagraph(node);
            if (!(this.PeekContainer() is ParagraphBuilder))
            {
                Console.WriteLine("ERROR: paragraph mismatch (position: " + node.Span.Start + ")");
            }
            this.PopContainer();
        }

        private void AddParagraphSpace()
        {
            if (this.addParagraphSpace)
            {
                this.addParagraphSpace = false;
                var contentList = this.PeekContainer().Text;
                var lastText = contentList.LastOrDefault() as TextBuilder;
                if (lastText != null)
                {
                    lastText.Text += " ";
                }
                else
                {
                    var spaceText = this.factory.Text();
                    spaceText.Text = " ";
                    this.AddContent(spaceText);
                }
            }
        }

        private void AddParagraphText(string text, ContentBuilder content = null)
        {
            if (string.IsNullOrEmpty(text)) return;
            text = text.Trim();
            if (string.IsNullOrEmpty(text)) return;
            this.AddParagraphSpace();
            if (content == null)
            {
                var contentList = this.PeekContainer().Text;
                var lastText = contentList.LastOrDefault() as TextBuilder;
                if (lastText != null)
                {
                    lastText.Text += text;
                }
                else
                {
                    var docText = this.factory.Text();
                    docText.Text = text;
                    this.AddContent(docText);
                }
            }
            else
            {
                this.AddContent(content);
            }
            this.addParagraphSpace = true;
        }

        public override void VisitInlineTextElement(InlineTextElementSyntax node)
        {
            base.VisitInlineTextElement(node);
        }

        public override void VisitInlineTextElements(InlineTextElementsSyntax node)
        {
            var text = node.InlineTextElements.ValueText;
            this.AddParagraphText(text);
        }

        public override void VisitWikiFormat(WikiFormatSyntax node)
        {
            var formatText = node.TFormat.ValueText;
            if (this.formatStack.Count > 0)
            {
                var topFormatText = this.formatStack.Peek();
                if (formatText == topFormatText)
                {
                    if (this.PeekContainer() is MarkupBuilder)
                    {
                        this.PopContainer();
                    }
                    else
                    {
                        Console.WriteLine("ERROR: markup mismatch (position: " + node.Span.Start + ")");
                    }
                    this.formatStack.Pop();
                    return;
                }
            }
            this.formatStack.Push(formatText);
            var markup = this.factory.Markup();
            switch (formatText.Length)
            {
                case 2:
                    markup.Kind.Add(MarkupKind.Italic);
                    break;
                case 3:
                    markup.Kind.Add(MarkupKind.Bold);
                    break;
                case 5:
                    markup.Kind.Add(MarkupKind.Bold);
                    markup.Kind.Add(MarkupKind.Italic);
                    break;
                default:
                    markup.Kind.Add(MarkupKind.None);
                    break;
            }
            this.AddContent(markup);
            this.PushContainer(markup);
        }

        public override void VisitNoWiki(NoWikiSyntax node)
        {
            var text = this.GetText(node);
            this.AddParagraphText(text);
        }

        public override void VisitHtmlReference(HtmlReferenceSyntax node)
        {
            var text = this.GetText(node);
            this.AddParagraphText(text);
        }

        public override void VisitHorizontalRule(HorizontalRuleSyntax node)
        {
            if (this.PeekContainer() != this.document) return;
            var pageBreak = this.factory.PageBreak();
            this.AddContent(pageBreak);
        }

        public override void VisitCodeBlock(CodeBlockSyntax node)
        {
            var codeMarkup = this.factory.Markup();
            codeMarkup.Kind.Add(MarkupKind.Code);
            this.AddContent(codeMarkup);
            this.PushContainer(codeMarkup);
            foreach (var codeLine in node.SpaceBlock)
            {
                string text = codeLine.GetText().ToString();
                if (text.StartsWith(" ")) text = text.Substring(1);
                var line = this.factory.Text();
                line.Text = text;
                var paragraph = this.factory.Paragraph();
                paragraph.Text.Add(line);
                codeMarkup.Text.Add(paragraph);
            }
            this.PopContainer();
            this.addParagraphSpace = false;
        }

        public override void VisitWikiList(WikiListSyntax node)
        {
            int listStackCount = this.listStack.Count;
            this.CreateListInfo(null, string.Empty);
            base.VisitWikiList(node);
            while (this.listStack.Count > listStackCount) this.listStack.Pop();
            this.addParagraphSpace = false;
        }

        public override void VisitWikiInternalLink(WikiInternalLinkSyntax node)
        {
            string text = node.GetText().ToString();
            text = text.Substring(2, text.Length - 4);
            int firstBarIndex = text.IndexOf('|');
            int lastBarIndex = text.LastIndexOf('|');
            string title = text;
            if (firstBarIndex >= 0)
            {
                title = text.Substring(0, firstBarIndex);
                text = text.Substring(lastBarIndex + 1);
            }
            if (string.IsNullOrWhiteSpace(text)) return;
            if (title.StartsWith("File:") || title.StartsWith("Image:") || title.StartsWith("Media:"))
            {
                int colonIndex = title.IndexOf(':');
                title = title.Substring(colonIndex + 1);
                var image = this.factory.Image();
                image.FilePath = title;
                this.addParagraphSpace = false;
                this.AddContent(image);
                this.addParagraphSpace = false;
            }
            else
            {
                var reference = this.factory.Reference();
                this.AddParagraphSpace();
                this.AddContent(reference);
                this.addParagraphSpace = true;
                var referenceText = this.factory.Text();
                referenceText.Text = text;
                reference.Text.Add(referenceText);
                reference.DocumentName = title;
            }
        }

        public override void VisitWikiExternalLink(WikiExternalLinkSyntax node)
        {
            string text = node.GetText().ToString();
            text = text.Substring(1, text.Length - 2);
            int firstSpaceIndex = text.IndexOf(' ');
            string url = text;
            if (firstSpaceIndex >= 0)
            {
                url = text.Substring(0, firstSpaceIndex);
                text = text.Substring(firstSpaceIndex + 1);
            }
            if (string.IsNullOrWhiteSpace(text)) return;
            var reference = this.factory.Reference();
            this.AddParagraphSpace();
            this.AddContent(reference);
            this.addParagraphSpace = true;
            var referenceText = this.factory.Text();
            referenceText.Text = text;
            reference.Text.Add(referenceText);
            reference.DocumentName = url;
        }

        public override void VisitListItem(ListItemSyntax node)
        {
            string listStart = null;
            if (node.NormalListItem != null)
            {
                listStart = node.NormalListItem.TListStart.ValueText;
            }
            else if (node.DefinitionItem != null)
            {
                listStart = node.DefinitionItem.TDefinitionStart.ValueText;
            }
            if (string.IsNullOrEmpty(listStart)) return;
            ListInfo listInfo = this.GetListInfo(listStart);
            if (listInfo.ListStart.Length > 0)
            {
                var item = this.factory.ListItem();
                this.PushContainer(item);
                this.addParagraphSpace = false;
                listInfo.List.Items.Add(item);
                if (node.DefinitionItem != null)
                {
                    MarkupBuilder markup = this.factory.Markup();
                    markup.Kind.Add(MarkupKind.Bold);
                    this.AddContent(markup);
                    this.PushContainer(markup);
                    this.AddParagraphText(this.GetText(node.DefinitionItem.DefinitionText));
                    this.PopContainer();
                }
                base.VisitListItem(node);
                if (!(this.PeekContainer() is ListItemBuilder))
                {
                    Console.WriteLine("ERROR: list mismatch (position: " + node.Span.Start + ")");
                }
                this.PopContainer();
            }
            else
            {
                this.addParagraphSpace = false;
                if (node.DefinitionItem != null)
                {
                    MarkupBuilder markup = this.factory.Markup();
                    markup.Kind.Add(MarkupKind.Bold);
                    this.AddContent(markup);
                    this.PushContainer(markup);
                    this.AddParagraphText(this.GetText(node.DefinitionItem.DefinitionText));
                    this.PopContainer();
                }
                base.VisitListItem(node);
            }
        }

        private ListInfo GetListInfo(string listStart)
        {
            ListInfo listInfo = null;
            string listStartWithoutDefinition = listStart.EndsWith(";") ? listStart.Substring(0, listStart.Length - 1) : listStart;
            while (this.listStack.Count > 0 && 
                (this.listStack.Peek().ListStart.Length > listStartWithoutDefinition.Length ||
                (this.listStack.Peek().ListStart.Length == listStartWithoutDefinition.Length && this.listStack.Peek().ListStart != listStartWithoutDefinition)))
            {
                this.listStack.Pop();
            }
            if (this.listStack.Count == 0)
            {
                listInfo = this.CreateListInfo(null, listStartWithoutDefinition);
            }
            else
            {
                listInfo = this.listStack.Peek();
            }
            if (listInfo.ListStart != listStartWithoutDefinition)
            {
                if (listInfo.ListStart.Length < listStartWithoutDefinition.Length)
                {
                    for (int i = listInfo.ListStart.Length + 1; i <= listStartWithoutDefinition.Length; i++)
                    {
                        string start = listStartWithoutDefinition.Substring(0, i);
                        listInfo = this.CreateListInfo(listInfo, start);
                    }
                }
                else
                {
                    Debug.Assert(false);
                }
            }
            return listInfo;
        }

        private ListInfo CreateListInfo(ListInfo parentList, string listStartWithoutDefinition)
        {
            ListInfo listInfo = new ListInfo();
            listInfo.ListStart = listStartWithoutDefinition;
            listInfo.List = this.factory.List();
            if (listStartWithoutDefinition.EndsWith(":"))
            {
                listInfo.List.Kind = ListKind.Indent;
            }
            else if (listStartWithoutDefinition.EndsWith("*"))
            {
                listInfo.List.Kind = ListKind.Bullets;
            }
            else if (listStartWithoutDefinition.EndsWith("#"))
            {
                listInfo.List.Kind = ListKind.Numbers;
            }
            this.listStack.Push(listInfo);
            if (parentList != null && !string.IsNullOrEmpty(parentList.ListStart))
            {
                var lastItem = parentList.List.Items.LastOrDefault();
                if (lastItem == null)
                {
                    lastItem = this.factory.ListItem();
                    parentList.List.Items.Add(lastItem);
                }
                lastItem.Text.Add(listInfo.List);
                return listInfo;
            }
            this.AddContent(listInfo.List);
            return listInfo;
        }

        private string GetText(TextElementsSyntax node)
        {
            if (node.NoWiki != null)
            {
                return this.GetText(node.NoWiki);
            }
            else if (node.WikiLink != null)
            {
                return this.GetText(node.WikiLink);
            }
            else if (node.HtmlReference != null)
            {
                return this.GetText(node.HtmlReference);
            }
            return string.Empty;
        }

        private string GetText(NoWikiSyntax node)
        {
            string text = node.TNoWiki.ValueText;
            if (text.EndsWith("/>")) return string.Empty;
            else
            {
                int startIndex = text.IndexOf('>') + 1;
                int endIndex = text.LastIndexOf('<') - 1;
                if (startIndex <= endIndex)
                {
                    return text.Substring(startIndex, endIndex - startIndex + 1);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private string GetText(WikiLinkSyntax node)
        {
            if (node.WikiInternalLink != null)
            {
                var linkText = node.WikiInternalLink.LinkTextPart?.LastOrDefault()?.LinkText;
                if (linkText == null) linkText = node.WikiInternalLink.LinkText;
                if (linkText == null) return string.Empty;
                return this.GetText(linkText);
            }
            else if (node.WikiExternalLink != null)
            {
                var linkText = node.WikiExternalLink.LinkTextPart?.LastOrDefault()?.LinkText;
                if (linkText == null) linkText = node.WikiExternalLink.LinkText;
                if (linkText == null) return string.Empty;
                return this.GetText(linkText);
            }
            return string.Empty;
        }

        private string GetText(HtmlReferenceSyntax node)
        {
            var refText = node.HtmlReference.ValueText;
            if (refText.StartsWith("&#x"))
            {
                var charCode = refText.Substring(3, refText.Length - 4);
                var code = Convert.ToInt32(charCode, 16);
                return char.ConvertFromUtf32(code);
            }
            else if (refText.StartsWith("&#"))
            {
                var charCode = refText.Substring(2, refText.Length - 3);
                var code = Convert.ToInt32(charCode);
                return char.ConvertFromUtf32(code);
            }
            else
            {
                var text = HtmlEntities.Resolve(refText);
                if (text != null) return text;
                else return string.Empty;
            }
        }

        private string GetText(InlineTextSyntax node)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var htwc in node.InlineTextElementWithComment)
            {
                var hte = htwc.InlineTextElement;
                sb.Append(this.GetText(hte));
            }
            return sb.ToString();
        }

        private string GetText(InlineTextElementSyntax node)
        {
            if (node.InlineTextElements != null)
            {
                return node.InlineTextElements.GetText().ToString();
            }
            else if (node.TextElements != null)
            {
                return this.GetText(node.TextElements);
            }
            return string.Empty;
        }

        private string GetText(DefinitionTextSyntax node)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var htwc in node.DefinitionTextElementWithComment)
            {
                var hte = htwc.DefinitionTextElement;
                if (hte.DefinitionTextElements != null)
                {
                    sb.Append(hte.DefinitionTextElements.GetText().ToString());
                }
                else if (hte.TextElements != null)
                {
                    sb.Append(this.GetText(hte.TextElements));
                }
            }
            return sb.ToString();
        }

        private string GetText(HeadingTextSyntax node)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var htwc in node.HeadingTextWithComment)
            {
                var hte = htwc.HeadingTextElement;
                if (hte.HeadingTextElements != null)
                {
                    sb.Append(hte.HeadingTextElements.GetText().ToString());
                }
                else if (hte.TextElements != null)
                {
                    sb.Append(this.GetText(hte.TextElements));
                }
            }
            return sb.ToString();
        }

        private string GetText(CellTextSyntax node)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var htwc in node.CellTextElementWithComment)
            {
                var hte = htwc.CellTextElement;
                if (hte.CellTextElements != null)
                {
                    sb.Append(hte.CellTextElements.GetText().ToString());
                }
                else if (hte.TextElements != null)
                {
                    sb.Append(this.GetText(hte.TextElements));
                }
            }
            return sb.ToString();
        }

        private string GetText(LinkTextSyntax node)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var htwc in node.LinkTextWithComment)
            {
                var hte = htwc.LinkTextElement;
                if (hte.LinkTextElements != null)
                {
                    sb.Append(hte.LinkTextElements.GetText().ToString());
                }
                else if (hte.TextElements != null)
                {
                    sb.Append(this.GetText(hte.TextElements));
                }
            }
            return sb.ToString();
        }

        public override void VisitWikiTable(WikiTableSyntax node)
        {
            this.formatStack.Clear();
            if (node.TableCaption != null)
            {
                var tableCaptionParagraph = this.factory.Paragraph();
                tableCaptionParagraph.Alignment = HorizontalAlignment.Center;
                this.AddContent(tableCaptionParagraph);
                this.PushContainer(tableCaptionParagraph);
                this.addParagraphSpace = false;
                base.Visit(node.TableCaption);
                this.PopContainer();
            }

            var tableInfo = new TableInfo();
            this.tableStack.Push(tableInfo);
            tableInfo.Table = this.factory.Table();
            this.AddContent(tableInfo.Table);
            base.Visit(node.TableRows);
            this.tableStack.Pop();
            this.addParagraphSpace = false;
        }

        public override void VisitTableRow(TableRowSyntax node)
        {
            var tableInfo = this.tableStack.Peek();
            tableInfo.RowStart = true;
            tableInfo.HeadColumnCount = 0;
            base.VisitTableRow(node);
            if (tableInfo.HeadColumnCount == tableInfo.Table.ColumnCount && tableInfo.RowIndex == tableInfo.Table.HeadRowCount)
            {
                ++tableInfo.Table.HeadRowCount;
            }
            if (tableInfo.HeadColumnCount < tableInfo.Table.ColumnCount)
            {
                if (tableInfo.HeadColumnCount > tableInfo.Table.HeadColumnCount)
                {
                    tableInfo.Table.HeadColumnCount = tableInfo.HeadColumnCount;
                }
            }
            ++tableInfo.RowIndex;
        }

        public override void VisitTableSingleHeaderCell(TableSingleHeaderCellSyntax node)
        {
            var tableInfo = this.tableStack.Peek();
            tableInfo.IsHeaderCell = true;
            if (node.TableCell != null)
            {
                this.VisitTableCell(node.TableCell);
                this.AddToLastCell(node.SpecialBlockOrParagraph);
            }
        }

        public override void VisitTableHeaderCells(TableHeaderCellsSyntax node)
        {
            var tableInfo = this.tableStack.Peek();
            tableInfo.IsHeaderCell = true;
            foreach (var cell in node.TableCell)
            {
                this.VisitTableCell(cell);
            }
            this.AddToLastCell(node.SpecialBlockOrParagraph);
        }

        public override void VisitTableSingleCell(TableSingleCellSyntax node)
        {
            var tableInfo = this.tableStack.Peek();
            tableInfo.IsHeaderCell = false;
            tableInfo.RowStart = false;
            if (node.TableCell != null)
            {
                this.VisitTableCell(node.TableCell);
                this.AddToLastCell(node.SpecialBlockOrParagraph);
            }
        }

        public override void VisitTableCells(TableCellsSyntax node)
        {
            var tableInfo = this.tableStack.Peek();
            tableInfo.IsHeaderCell = false;
            tableInfo.RowStart = false;
            foreach (var cell in node.TableCell)
            {
                this.VisitTableCell(cell);
            }
            this.AddToLastCell(node.SpecialBlockOrParagraph);
        }

        private void AddToLastCell(SyntaxNodeList<SpecialBlockOrParagraphSyntax> nodes)
        {
            if (nodes == null) return;
            var tableInfo = this.tableStack.Peek();
            var cell = tableInfo.Table.Cells.LastOrDefault();
            if (cell != null)
            {
                this.PushContainer(cell);
                foreach (var node in nodes)
                {
                    this.VisitSpecialBlockOrParagraph(node);
                }
                this.PopContainer();
            }
        }

        public override void VisitTableCell(TableCellSyntax node)
        {
            var tableInfo = this.tableStack.Peek();
            if (tableInfo.RowIndex == 0)
            {
                ++tableInfo.Table.ColumnCount;
            }
            if (tableInfo.RowStart)
            {
                if (tableInfo.IsHeaderCell)
                {
                    ++tableInfo.HeadColumnCount;
                }
            }
            var cell = this.factory.TableCell();
            tableInfo.Table.Cells.Add(cell);
            if (node.CellText != null)
            {
                this.PushContainer(cell);
                this.formatStack.Clear();
                this.addParagraphSpace = false;
                this.VisitCellText(node.CellText);
                this.PopContainer();
            }
        }

        public override void VisitCellTextElement(CellTextElementSyntax node)
        {
            if (node.CellTextElements != null)
            {
                string text = node.CellTextElements.GetText().ToString();
                this.AddParagraphText(text);
            }
            else
            {
                base.VisitCellTextElement(node);
            }
        }


        private class ListInfo
        {
            public string ListStart;
            public ListBuilder List;
        }

        private class TableInfo
        {
            public int RowIndex = 0;
            public bool RowStart = false;
            public bool IsHeaderCell = false;
            public int HeadColumnCount = 0;
            public TableBuilder Table;
        }

    }


}
