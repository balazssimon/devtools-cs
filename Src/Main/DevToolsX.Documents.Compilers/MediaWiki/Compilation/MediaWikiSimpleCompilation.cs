﻿using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using DevToolsX.Documents.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using DevToolsX.Documents.Utils;
using MetaDslx.Compiler;
using System.Collections.Immutable;
using System.Threading;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Diagnostics;

namespace DevToolsX.Documents.Compilers.MediaWiki
{
    public class MediaWikiSimpleCompilation : SimpleCompilation
    {
        protected MediaWikiSimpleCompilation(string compilationName, MediaWikiCompilationOptions options, IEnumerable<SyntaxTree> syntaxTrees, ImmutableArray<MetadataReference> references) 
            : base(compilationName, options, syntaxTrees, references)
        {
        }

        public override Language Language => MediaWikiLanguage.Instance;

        public new MediaWikiCompilationOptions Options
        {
            get { return (MediaWikiCompilationOptions)base.Options; }
        }

        protected override void Compile(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var syntaxTree in this.SyntaxTrees)
            {
                var root = syntaxTree.GetRoot();
                MediaWikiToDocumentVisitor visitor = new MediaWikiToDocumentVisitor(this.ModelBuilder, this.DiagnosticBag);
                root.Accept(visitor);
            }
        }

        protected override SimpleCompilation Update(string compilationName, CompilationOptions options, IEnumerable<SyntaxTree> syntaxTrees, ImmutableArray<MetadataReference> references)
        {
            return new MediaWikiSimpleCompilation(compilationName, (MediaWikiCompilationOptions)options, syntaxTrees, references);
        }

        public MediaWikiSimpleCompilation Clone()
        {
            return new MediaWikiSimpleCompilation(this.CompilationName, this.Options, this.SyntaxTrees, this.ExternalReferences);
        }

        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="name">Simple compilation name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static MediaWikiSimpleCompilation Create(
            string name,
            IEnumerable<MediaWikiSyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            MediaWikiCompilationOptions options = null)
        {
            var validatedReferences = ValidateReferences<CompilationReference>(references);
            return new MediaWikiSimpleCompilation(
                name, 
                options ?? new MediaWikiCompilationOptions(), 
                syntaxTrees,
                validatedReferences);
        }
    }

    internal class MediaWikiToDocumentVisitor : MediaWikiSyntaxVisitor
    {
        private DocumentModelFactory factory;
        private MutableModel model;
        private DiagnosticBag diagnostics;
        private DocumentBuilder document;
        private List<ContentContainerBuilder> containerStack = new List<ContentContainerBuilder>();
        private Stack<MarkupInfo> formatStack = new Stack<MarkupInfo>();
        private Stack<ListInfo> listStack = new Stack<ListInfo>();
        private Stack<TableInfo> tableStack = new Stack<TableInfo>();
        private bool addParagraphSpace = false;

        public MediaWikiToDocumentVisitor(MutableModel model, DiagnosticBag diagnostics)
        {
            this.model = model;
            this.diagnostics = diagnostics;
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
            this.containerStack.Add(container);
        }

        private ContentContainerBuilder PeekContainer()
        {
            if (this.containerStack.Count > 0) return this.containerStack[this.containerStack.Count - 1];
            else return this.document;
        }

        private ContentContainerBuilder PopContainer()
        {
            int index = this.containerStack.Count - 1;
            if (index < 0) return this.document;
            ContentContainerBuilder result = this.containerStack[index];
            this.containerStack.RemoveAt(index);
            return result;
        }

        private void ClearContainer()
        {
            this.containerStack.Clear();
        }

        private void EnsureFormattingClearAtBeginning(SyntaxNode node)
        {
            foreach (var format in this.formatStack)
            {
                this.diagnostics.Add(Diagnostic.Create(format.StartSyntaxNode.GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, format.Name));
                this.diagnostics.Add(Diagnostic.Create(node.GetFirstToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, format.Name));
                this.PopContainer();
            }
            this.formatStack.Clear();
        }

        private void EnsureFormattingClearAtEnd(SyntaxNode node)
        {
            foreach (var format in this.formatStack)
            {
                this.diagnostics.Add(Diagnostic.Create(format.StartSyntaxNode.GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, format.Name));
                this.diagnostics.Add(Diagnostic.Create(node.GetLastToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, format.Name));
                this.PopContainer();
            }
            this.formatStack.Clear();
        }

        private void EnsureContainerClearAtBeginning(SyntaxNode node)
        {
            this.EnsureFormattingClearAtBeginning(node);
            var container = this.PeekContainer();
            if (container != this.document)
            {
                this.diagnostics.Add(Diagnostic.Create(node.GetFirstToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, container.GetType().Name));
            }
            this.ClearContainer();
        }

        private T EnsureContainerClosedAtBeginning<T>(SyntaxNode node)
            where T : class, ContentContainerBuilder
        {
            this.EnsureFormattingClearAtBeginning(node);
            var container = this.PopContainer();
            var tContainer = container as T;
            if (tContainer == null)
            {
                this.diagnostics.Add(Diagnostic.Create(node.GetFirstToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseOtherError, typeof(T).Name, container.GetType().Name));
            }
            return tContainer;
        }

        private T EnsureContainerClosedAtEnd<T>(SyntaxNode node)
            where T : class, ContentContainerBuilder
        {
            this.EnsureFormattingClearAtEnd(node);
            var container = this.PopContainer();
            var tContainer = container as T;
            if (tContainer == null)
            {
                this.diagnostics.Add(Diagnostic.Create(node.GetLastToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseOtherError, typeof(T).Name, container.GetType().Name));
            }
            return tContainer;
        }
        
        private MarkupBuilder EnsureFormattingClosedAtBeginning(SyntaxNode node, string formatName)
        {
            var container = this.PeekContainer();
            MarkupBuilder expectedContainer = null;
            if (this.formatStack.Count > 0)
            {
                var format = this.formatStack.Peek();
                expectedContainer = format.Markup;
                if (format.Name != formatName)
                {
                    this.diagnostics.Add(Diagnostic.Create(format.StartSyntaxNode.GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, format.Name));
                    this.diagnostics.Add(Diagnostic.Create(node.GetFirstToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, format.Name));
                }
                else
                {
                    this.formatStack.Pop();
                }
            }
            if (container == expectedContainer)
            {
                this.PopContainer();
            }
            else
            {
                this.diagnostics.Add(Diagnostic.Create(node.GetFirstToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, formatName));
            }
            return expectedContainer;
        }

        private MarkupBuilder EnsureFormattingClosedAtEnd(SyntaxNode node, string formatName)
        {
            var container = this.PeekContainer();
            MarkupBuilder expectedContainer = null;
            if (this.formatStack.Count > 0)
            {
                var format = this.formatStack.Peek();
                expectedContainer = format.Markup;
                if (format.Name != formatName)
                {
                    this.diagnostics.Add(Diagnostic.Create(format.StartSyntaxNode.GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, format.Name));
                    this.diagnostics.Add(Diagnostic.Create(node.GetLastToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, format.Name));
                }
                else
                {
                    this.formatStack.Pop();
                }
            }
            if (container == expectedContainer)
            {
                this.PopContainer();
            }
            else
            {
                this.diagnostics.Add(Diagnostic.Create(node.GetLastToken().GetLocation(), MediaWikiErrorCodes.ERR_CloseSelfError, formatName));
            }
            return expectedContainer;
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
            this.EnsureContainerClearAtBeginning(node);

            var heading = this.factory.SectionTitle();
            heading.Level = node.HeadingStart.THeading.ValueText.Length - 1;
            heading.Title = this.GetText(node.HeadingText).Trim();
            this.AddContent(heading);
            this.addParagraphSpace = false;

            this.EnsureFormattingClearAtEnd(node);
        }

        public override void VisitParagraph(ParagraphSyntax node)
        {
            this.EnsureFormattingClearAtBeginning(node);

            var paragraph = this.factory.Paragraph();
            this.AddContent(paragraph);
            this.PushContainer(paragraph);
            base.VisitParagraph(node);

            this.EnsureContainerClosedAtEnd<ParagraphBuilder>(node);
        }

        private void AddParagraphSpace()
        {
            if (this.addParagraphSpace)
            {
                this.addParagraphSpace = false;
                
                ContentContainerBuilder container = null;
                int index = this.containerStack.Count - 1;
                while (index >= 0)
                {
                    container = this.containerStack[index];
                    if (container is ParagraphBuilder)
                    {
                        break;
                    }
                    else if (container.Text.Count > 0)
                    {
                        break;
                    }
                    --index;
                }
                bool insertBefore = index < this.containerStack.Count - 1;
                if (container == null)
                {
                    insertBefore = false;
                }

                TextBuilder lastText = null;
                if (insertBefore)
                {
                    var contentList = container.Text;
                    if (contentList.Count >= 2)
                    {
                        lastText = contentList[contentList.Count - 2] as TextBuilder;
                        if (lastText != null)
                        {
                            lastText.Text += " ";
                        }
                    }
                    if (lastText == null && contentList.Count >= 1)
                    {
                        lastText = this.factory.Text();
                        lastText.Text = " ";
                        contentList.Insert(contentList.Count - 1, lastText);
                    }
                }
                if (lastText == null)
                {
                    container = this.PeekContainer();
                    var contentList = container.Text;
                    lastText = contentList.LastOrDefault() as TextBuilder;
                    if (lastText != null)
                    {
                        lastText.Text += " ";
                    }
                    else
                    {
                        lastText = this.factory.Text();
                        lastText.Text = " ";
                        container.Text.Add(lastText);
                    }
                }
            }
        }

        private void AddParagraphText(string text, ContentBuilder content = null)
        {
            if (string.IsNullOrEmpty(text)) return;
            //text = text.Trim();
            //if (string.IsNullOrEmpty(text)) return;
            //this.AddParagraphSpace();
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

        public override void VisitTextLineInlineElementsWithComment(TextLineInlineElementsWithCommentSyntax node)
        {
            this.AddParagraphSpace();
            base.VisitTextLineInlineElementsWithComment(node);
        }

        public override void VisitTextLineComment(TextLineCommentSyntax node)
        {
            base.VisitTextLineComment(node);
            var container = this.PeekContainer() as ParagraphBuilder;
            if (container != null && container.Text.Count > 0)
            {
                this.EnsureContainerClosedAtBeginning<ParagraphBuilder>(node);
                container = this.factory.Paragraph();
                this.AddContent(container);
                this.PushContainer(container);
                this.addParagraphSpace = false;
            }
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
                if (formatText == topFormatText.Format)
                {
                    this.EnsureFormattingClosedAtBeginning(node, formatText);
                    return;
                }
            }
            var markup = this.factory.Markup();
            this.formatStack.Push(new MarkupInfo() { StartSyntaxNode = node, Markup = markup, Format = formatText });
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

        public override void VisitHtmlTagOpen(HtmlTagOpenSyntax node)
        {
            string name = node.HtmlTagName.GetText().ToString().ToLower();
            if (name == "br")
            {
                this.AddContent(this.factory.LineBreak());
                return;
            }
            bool bold = name == "b" || name == "strong";
            bool italic = name == "i" || name == "em";
            bool underline = false;
            bool strikeThrough = false;
            bool inlineCode = name == "code";
            bool code = name == "pre";
            bool subscript = name == "sub";
            bool superscript = name == "sup";
            Color foregroundColor = Color.Empty;
            Color backgroundColor = Color.Empty;
            if (name == "span" || name == "div" || name == "p")
            {
                var styleAttribute = node.HtmlAttribute?.OfType<HtmlAttributeWithValueSyntax>().FirstOrDefault(a => a.HtmlAttributeName.GetText().ToString() == "style");
                if (styleAttribute != null)
                {
                    string style = styleAttribute.HtmlAttributeValue.TAttributeValue.ValueText;
                    if (style.StartsWith("\"") || style.StartsWith("'")) style = style.Substring(1);
                    if (style.EndsWith("\"") || style.EndsWith("'")) style = style.Substring(0, style.Length - 1);
                    string[] cssAttributes = style.Split(';');
                    foreach (var cssAttribute in cssAttributes)
                    {
                        int colonIndex = cssAttribute.IndexOf(':');
                        if (colonIndex >= 0)
                        {
                            string cssAttributeName = cssAttribute.Substring(0, colonIndex).Trim();
                            string cssAttributeValue = cssAttribute.Substring(colonIndex + 1).Trim();
                            switch (cssAttributeName)
                            {
                                case "color":
                                    foregroundColor = ColorTranslator.FromHtml(cssAttributeValue);
                                    break;
                                case "background":
                                    backgroundColor = ColorTranslator.FromHtml(cssAttributeValue);
                                    break;
                                case "font-weight":
                                    if (cssAttributeValue == "bold") bold = true;
                                    break;
                                case "font-style":
                                    if (cssAttributeValue == "italic") italic = true;
                                    break;
                                case "text-decoration":
                                    if (cssAttributeValue == "underline") underline = true;
                                    if (cssAttributeValue == "line-through") strikeThrough = true;
                                    break;
                                case "vertical-align":
                                    if (cssAttributeValue == "sub") subscript = true;
                                    if (cssAttributeValue == "super") superscript = true;
                                    break;
                            }

                        }
                    }
                }
            }
            var markup = this.factory.Markup();
            this.formatStack.Push(new MarkupInfo() { StartSyntaxNode = node, Markup = markup, HtmlTag = name });
            if (bold) markup.Kind.Add(MarkupKind.Bold);
            if (italic) markup.Kind.Add(MarkupKind.Italic);
            if (underline) markup.Kind.Add(MarkupKind.Underline);
            if (strikeThrough) markup.Kind.Add(MarkupKind.Strikethrough);
            if (code) markup.Kind.Add(MarkupKind.Code);
            else if (inlineCode) markup.Kind.Add(MarkupKind.CodeInline);
            if (subscript) markup.Kind.Add(MarkupKind.SubScript);
            if (superscript) markup.Kind.Add(MarkupKind.SuperScript);
            markup.ForegroundColor = foregroundColor;
            markup.BackgroundColor = backgroundColor;
            this.AddContent(markup);
            this.PushContainer(markup);
        }

        public override void VisitHtmlTagClose(HtmlTagCloseSyntax node)
        {
            string name = node.HtmlTagName.GetText().ToString().ToLower();
            this.EnsureFormattingClosedAtEnd(node, name);
        }

        public override void VisitHtmlTagEmpty(HtmlTagEmptySyntax node)
        {
            string name = node.HtmlTagName.GetText().ToString().ToLower();
            if (name == "br")
            {
                this.AddContent(this.factory.LineBreak());
                return;
            }
            base.VisitHtmlTagEmpty(node);
        }

        public override void VisitHorizontalRule(HorizontalRuleSyntax node)
        {
            this.EnsureContainerClearAtBeginning(node);
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
            this.EnsureFormattingClearAtBeginning(node);
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
                this.AddContent(image);
                this.addParagraphSpace = true;
            }
            else
            {
                var reference = this.factory.Reference();
                this.AddContent(reference);
                var referenceText = this.factory.Text();
                referenceText.Text = text;
                reference.Text.Add(referenceText);
                reference.DocumentName = title;
                this.addParagraphSpace = true;
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
            this.AddContent(reference);
            var referenceText = this.factory.Text();
            referenceText.Text = text;
            reference.Text.Add(referenceText);
            reference.DocumentName = url;
            this.addParagraphSpace = true;
        }

        public override void VisitListItem(ListItemSyntax node)
        {
            this.EnsureFormattingClearAtBeginning(node);

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
                this.EnsureContainerClosedAtEnd<ListItemBuilder>(node);
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
            this.EnsureFormattingClearAtEnd(node);
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
            this.EnsureFormattingClearAtBeginning(node);

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
            this.EnsureFormattingClearAtBeginning(node);
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
                this.EnsureContainerClosedAtEnd<TableCellBuilder>(node);
            }
            this.EnsureFormattingClearAtEnd(node);
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


        private class MarkupInfo
        {
            public string Name
            {
                get { return this.Format ?? this.HtmlTag; }
            }

            public string Format;
            public string HtmlTag;
            public SyntaxNode StartSyntaxNode;
            public MarkupBuilder Markup;
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

    public class MediaWikiErrorCodes : ErrorCode
    {
        public const string MediaWikiCategory = "MediaWiki";
        public static readonly MediaWikiErrorCodes ERR_SyntaxError = new MediaWikiErrorCodes(1, DiagnosticSeverity.Error, 0, "Syntax error: {0}");
        public static readonly MediaWikiErrorCodes ERR_CloseOtherError = new MediaWikiErrorCodes(2, DiagnosticSeverity.Error, 0, "'{0}' should be closed but '{1}' is still open.");
        public static readonly MediaWikiErrorCodes ERR_CloseSelfError = new MediaWikiErrorCodes(3, DiagnosticSeverity.Error, 0, "'{0}' should be closed but it is still open.");

        public MediaWikiErrorCodes(int id, DiagnosticSeverity defaultSeverity, int warningLevel, string defaultMessage)
            : base(MediaWikiCategory, id, defaultSeverity, warningLevel, defaultMessage)
        {
        }
    }
}
