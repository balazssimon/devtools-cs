﻿using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
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
        }

        public override void VisitParagraph(ParagraphSyntax node)
        {
            this.formatStack.Clear();
            var paragraph = this.factory.Paragraph();
            this.AddContent(paragraph);
            this.PushContainer(paragraph);
            this.addParagraphSpace = false;
            base.VisitParagraph(node);
            if (!(this.PeekContainer() is ParagraphBuilder))
            {
                Console.WriteLine("ERROR: paragraph mismatch (position: " + node.Span.Start + ")");
            }
            this.PopContainer();
        }

        private void AddParagraphSpaceBefore(string text)
        {
            if (this.addParagraphSpace)
            {
                if (!text.StartsWith(" ") && !text.StartsWith("\t"))
                {
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
                this.addParagraphSpace = false;
            }
        }

        private void AddParagraphText(string text, ContentBuilder content = null)
        {
            if (string.IsNullOrEmpty(text)) return;
            this.AddParagraphSpaceBefore(text);
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
                    markup.Kind = MarkupKind.Italic;
                    break;
                case 3:
                case 5:
                    markup.Kind = MarkupKind.Bold;
                    break;
                default:
                    markup.Kind = MarkupKind.None;
                    break;
            }
            this.AddContent(markup);
            this.PushContainer(markup);
        }

        public override void VisitWikiLink(WikiLinkSyntax node)
        {
            var text = this.GetText(node);
            var reference = this.factory.Reference();
            var linkText = this.factory.Text();
            linkText.Text = text;
            reference.Text.Add(linkText);
            this.AddParagraphText(text, reference);
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
            codeMarkup.Kind = MarkupKind.Code;
            this.AddContent(codeMarkup);
            this.PushContainer(codeMarkup);
            foreach (var codeLine in node.SpaceBlock)
            {
                string text = codeLine.GetText().ToString();
                var line = this.factory.Text();
                line.Text = text;
                codeMarkup.Text.Add(line);
            }
            this.PopContainer();
        }

        public override void VisitWikiList(WikiListSyntax node)
        {
            int listStackCount = this.listStack.Count;
            this.CreateListInfo(null, string.Empty);
            base.VisitWikiList(node);
            while (this.listStack.Count > listStackCount) this.listStack.Pop();
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
                listInfo.List.Items.Add(item);
                if (node.DefinitionItem != null)
                {
                    MarkupBuilder markup = this.factory.Markup();
                    markup.Kind = MarkupKind.Bold;
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
                if (node.DefinitionItem != null)
                {
                    MarkupBuilder markup = this.factory.Markup();
                    markup.Kind = MarkupKind.Bold;
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
                var linkText = node.WikiInternalLink.LinkTextPart.LastOrDefault()?.LinkText;
                if (linkText == null) linkText = node.WikiInternalLink.LinkText;
                if (linkText == null) return string.Empty;
                return this.GetText(linkText);
            }
            else if (node.WikiExternalLink != null)
            {
                var linkText = node.WikiExternalLink.LinkTextPart.LastOrDefault()?.LinkText;
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

        private class ListInfo
        {
            public string ListStart;
            public ListBuilder List;
        }

        private class TableInfo
        {

        }

        private class TableCellInfo
        {

        }
    }


    internal class HtmlEntities
    {
        private static Dictionary<string, string> htmlEntityMap = new Dictionary<string, string>();

        public static string Resolve(string entityName)
        {
            if (htmlEntityMap.TryGetValue(entityName, out string entityValue))
            {
                return entityValue;
            }
            return null;
        }

        static HtmlEntities()
        {
            htmlEntityMap.Add("&Aacute;", "\u00C1");
            htmlEntityMap.Add("&Aacute", "\u00C1");
            htmlEntityMap.Add("&aacute;", "\u00E1");
            htmlEntityMap.Add("&aacute", "\u00E1");
            htmlEntityMap.Add("&Abreve;", "\u0102");
            htmlEntityMap.Add("&abreve;", "\u0103");
            htmlEntityMap.Add("&ac;", "\u223E");
            htmlEntityMap.Add("&acd;", "\u223F");
            htmlEntityMap.Add("&acE;", "\u223E\u0333");
            htmlEntityMap.Add("&Acirc;", "\u00C2");
            htmlEntityMap.Add("&Acirc", "\u00C2");
            htmlEntityMap.Add("&acirc;", "\u00E2");
            htmlEntityMap.Add("&acirc", "\u00E2");
            htmlEntityMap.Add("&acute;", "\u00B4");
            htmlEntityMap.Add("&acute", "\u00B4");
            htmlEntityMap.Add("&Acy;", "\u0410");
            htmlEntityMap.Add("&acy;", "\u0430");
            htmlEntityMap.Add("&AElig;", "\u00C6");
            htmlEntityMap.Add("&AElig", "\u00C6");
            htmlEntityMap.Add("&aelig;", "\u00E6");
            htmlEntityMap.Add("&aelig", "\u00E6");
            htmlEntityMap.Add("&af;", "\u2061");
            htmlEntityMap.Add("&Afr;", "\uD835\uDD04");
            htmlEntityMap.Add("&afr;", "\uD835\uDD1E");
            htmlEntityMap.Add("&Agrave;", "\u00C0");
            htmlEntityMap.Add("&Agrave", "\u00C0");
            htmlEntityMap.Add("&agrave;", "\u00E0");
            htmlEntityMap.Add("&agrave", "\u00E0");
            htmlEntityMap.Add("&alefsym;", "\u2135");
            htmlEntityMap.Add("&aleph;", "\u2135");
            htmlEntityMap.Add("&Alpha;", "\u0391");
            htmlEntityMap.Add("&alpha;", "\u03B1");
            htmlEntityMap.Add("&Amacr;", "\u0100");
            htmlEntityMap.Add("&amacr;", "\u0101");
            htmlEntityMap.Add("&amalg;", "\u2A3F");
            htmlEntityMap.Add("&amp;", "\u0026");
            htmlEntityMap.Add("&amp", "\u0026");
            htmlEntityMap.Add("&AMP;", "\u0026");
            htmlEntityMap.Add("&AMP", "\u0026");
            htmlEntityMap.Add("&andand;", "\u2A55");
            htmlEntityMap.Add("&And;", "\u2A53");
            htmlEntityMap.Add("&and;", "\u2227");
            htmlEntityMap.Add("&andd;", "\u2A5C");
            htmlEntityMap.Add("&andslope;", "\u2A58");
            htmlEntityMap.Add("&andv;", "\u2A5A");
            htmlEntityMap.Add("&ang;", "\u2220");
            htmlEntityMap.Add("&ange;", "\u29A4");
            htmlEntityMap.Add("&angle;", "\u2220");
            htmlEntityMap.Add("&angmsdaa;", "\u29A8");
            htmlEntityMap.Add("&angmsdab;", "\u29A9");
            htmlEntityMap.Add("&angmsdac;", "\u29AA");
            htmlEntityMap.Add("&angmsdad;", "\u29AB");
            htmlEntityMap.Add("&angmsdae;", "\u29AC");
            htmlEntityMap.Add("&angmsdaf;", "\u29AD");
            htmlEntityMap.Add("&angmsdag;", "\u29AE");
            htmlEntityMap.Add("&angmsdah;", "\u29AF");
            htmlEntityMap.Add("&angmsd;", "\u2221");
            htmlEntityMap.Add("&angrt;", "\u221F");
            htmlEntityMap.Add("&angrtvb;", "\u22BE");
            htmlEntityMap.Add("&angrtvbd;", "\u299D");
            htmlEntityMap.Add("&angsph;", "\u2222");
            htmlEntityMap.Add("&angst;", "\u00C5");
            htmlEntityMap.Add("&angzarr;", "\u237C");
            htmlEntityMap.Add("&Aogon;", "\u0104");
            htmlEntityMap.Add("&aogon;", "\u0105");
            htmlEntityMap.Add("&Aopf;", "\uD835\uDD38");
            htmlEntityMap.Add("&aopf;", "\uD835\uDD52");
            htmlEntityMap.Add("&apacir;", "\u2A6F");
            htmlEntityMap.Add("&ap;", "\u2248");
            htmlEntityMap.Add("&apE;", "\u2A70");
            htmlEntityMap.Add("&ape;", "\u224A");
            htmlEntityMap.Add("&apid;", "\u224B");
            htmlEntityMap.Add("&apos;", "\u0027");
            htmlEntityMap.Add("&ApplyFunction;", "\u2061");
            htmlEntityMap.Add("&approx;", "\u2248");
            htmlEntityMap.Add("&approxeq;", "\u224A");
            htmlEntityMap.Add("&Aring;", "\u00C5");
            htmlEntityMap.Add("&Aring", "\u00C5");
            htmlEntityMap.Add("&aring;", "\u00E5");
            htmlEntityMap.Add("&aring", "\u00E5");
            htmlEntityMap.Add("&Ascr;", "\uD835\uDC9C");
            htmlEntityMap.Add("&ascr;", "\uD835\uDCB6");
            htmlEntityMap.Add("&Assign;", "\u2254");
            htmlEntityMap.Add("&ast;", "\u002A");
            htmlEntityMap.Add("&asymp;", "\u2248");
            htmlEntityMap.Add("&asympeq;", "\u224D");
            htmlEntityMap.Add("&Atilde;", "\u00C3");
            htmlEntityMap.Add("&Atilde", "\u00C3");
            htmlEntityMap.Add("&atilde;", "\u00E3");
            htmlEntityMap.Add("&atilde", "\u00E3");
            htmlEntityMap.Add("&Auml;", "\u00C4");
            htmlEntityMap.Add("&Auml", "\u00C4");
            htmlEntityMap.Add("&auml;", "\u00E4");
            htmlEntityMap.Add("&auml", "\u00E4");
            htmlEntityMap.Add("&awconint;", "\u2233");
            htmlEntityMap.Add("&awint;", "\u2A11");
            htmlEntityMap.Add("&backcong;", "\u224C");
            htmlEntityMap.Add("&backepsilon;", "\u03F6");
            htmlEntityMap.Add("&backprime;", "\u2035");
            htmlEntityMap.Add("&backsim;", "\u223D");
            htmlEntityMap.Add("&backsimeq;", "\u22CD");
            htmlEntityMap.Add("&Backslash;", "\u2216");
            htmlEntityMap.Add("&Barv;", "\u2AE7");
            htmlEntityMap.Add("&barvee;", "\u22BD");
            htmlEntityMap.Add("&barwed;", "\u2305");
            htmlEntityMap.Add("&Barwed;", "\u2306");
            htmlEntityMap.Add("&barwedge;", "\u2305");
            htmlEntityMap.Add("&bbrk;", "\u23B5");
            htmlEntityMap.Add("&bbrktbrk;", "\u23B6");
            htmlEntityMap.Add("&bcong;", "\u224C");
            htmlEntityMap.Add("&Bcy;", "\u0411");
            htmlEntityMap.Add("&bcy;", "\u0431");
            htmlEntityMap.Add("&bdquo;", "\u201E");
            htmlEntityMap.Add("&becaus;", "\u2235");
            htmlEntityMap.Add("&because;", "\u2235");
            htmlEntityMap.Add("&Because;", "\u2235");
            htmlEntityMap.Add("&bemptyv;", "\u29B0");
            htmlEntityMap.Add("&bepsi;", "\u03F6");
            htmlEntityMap.Add("&bernou;", "\u212C");
            htmlEntityMap.Add("&Bernoullis;", "\u212C");
            htmlEntityMap.Add("&Beta;", "\u0392");
            htmlEntityMap.Add("&beta;", "\u03B2");
            htmlEntityMap.Add("&beth;", "\u2136");
            htmlEntityMap.Add("&between;", "\u226C");
            htmlEntityMap.Add("&Bfr;", "\uD835\uDD05");
            htmlEntityMap.Add("&bfr;", "\uD835\uDD1F");
            htmlEntityMap.Add("&bigcap;", "\u22C2");
            htmlEntityMap.Add("&bigcirc;", "\u25EF");
            htmlEntityMap.Add("&bigcup;", "\u22C3");
            htmlEntityMap.Add("&bigodot;", "\u2A00");
            htmlEntityMap.Add("&bigoplus;", "\u2A01");
            htmlEntityMap.Add("&bigotimes;", "\u2A02");
            htmlEntityMap.Add("&bigsqcup;", "\u2A06");
            htmlEntityMap.Add("&bigstar;", "\u2605");
            htmlEntityMap.Add("&bigtriangledown;", "\u25BD");
            htmlEntityMap.Add("&bigtriangleup;", "\u25B3");
            htmlEntityMap.Add("&biguplus;", "\u2A04");
            htmlEntityMap.Add("&bigvee;", "\u22C1");
            htmlEntityMap.Add("&bigwedge;", "\u22C0");
            htmlEntityMap.Add("&bkarow;", "\u290D");
            htmlEntityMap.Add("&blacklozenge;", "\u29EB");
            htmlEntityMap.Add("&blacksquare;", "\u25AA");
            htmlEntityMap.Add("&blacktriangle;", "\u25B4");
            htmlEntityMap.Add("&blacktriangledown;", "\u25BE");
            htmlEntityMap.Add("&blacktriangleleft;", "\u25C2");
            htmlEntityMap.Add("&blacktriangleright;", "\u25B8");
            htmlEntityMap.Add("&blank;", "\u2423");
            htmlEntityMap.Add("&blk12;", "\u2592");
            htmlEntityMap.Add("&blk14;", "\u2591");
            htmlEntityMap.Add("&blk34;", "\u2593");
            htmlEntityMap.Add("&block;", "\u2588");
            htmlEntityMap.Add("&bne;", "\u003D\u20E5");
            htmlEntityMap.Add("&bnequiv;", "\u2261\u20E5");
            htmlEntityMap.Add("&bNot;", "\u2AED");
            htmlEntityMap.Add("&bnot;", "\u2310");
            htmlEntityMap.Add("&Bopf;", "\uD835\uDD39");
            htmlEntityMap.Add("&bopf;", "\uD835\uDD53");
            htmlEntityMap.Add("&bot;", "\u22A5");
            htmlEntityMap.Add("&bottom;", "\u22A5");
            htmlEntityMap.Add("&bowtie;", "\u22C8");
            htmlEntityMap.Add("&boxbox;", "\u29C9");
            htmlEntityMap.Add("&boxdl;", "\u2510");
            htmlEntityMap.Add("&boxdL;", "\u2555");
            htmlEntityMap.Add("&boxDl;", "\u2556");
            htmlEntityMap.Add("&boxDL;", "\u2557");
            htmlEntityMap.Add("&boxdr;", "\u250C");
            htmlEntityMap.Add("&boxdR;", "\u2552");
            htmlEntityMap.Add("&boxDr;", "\u2553");
            htmlEntityMap.Add("&boxDR;", "\u2554");
            htmlEntityMap.Add("&boxh;", "\u2500");
            htmlEntityMap.Add("&boxH;", "\u2550");
            htmlEntityMap.Add("&boxhd;", "\u252C");
            htmlEntityMap.Add("&boxHd;", "\u2564");
            htmlEntityMap.Add("&boxhD;", "\u2565");
            htmlEntityMap.Add("&boxHD;", "\u2566");
            htmlEntityMap.Add("&boxhu;", "\u2534");
            htmlEntityMap.Add("&boxHu;", "\u2567");
            htmlEntityMap.Add("&boxhU;", "\u2568");
            htmlEntityMap.Add("&boxHU;", "\u2569");
            htmlEntityMap.Add("&boxminus;", "\u229F");
            htmlEntityMap.Add("&boxplus;", "\u229E");
            htmlEntityMap.Add("&boxtimes;", "\u22A0");
            htmlEntityMap.Add("&boxul;", "\u2518");
            htmlEntityMap.Add("&boxuL;", "\u255B");
            htmlEntityMap.Add("&boxUl;", "\u255C");
            htmlEntityMap.Add("&boxUL;", "\u255D");
            htmlEntityMap.Add("&boxur;", "\u2514");
            htmlEntityMap.Add("&boxuR;", "\u2558");
            htmlEntityMap.Add("&boxUr;", "\u2559");
            htmlEntityMap.Add("&boxUR;", "\u255A");
            htmlEntityMap.Add("&boxv;", "\u2502");
            htmlEntityMap.Add("&boxV;", "\u2551");
            htmlEntityMap.Add("&boxvh;", "\u253C");
            htmlEntityMap.Add("&boxvH;", "\u256A");
            htmlEntityMap.Add("&boxVh;", "\u256B");
            htmlEntityMap.Add("&boxVH;", "\u256C");
            htmlEntityMap.Add("&boxvl;", "\u2524");
            htmlEntityMap.Add("&boxvL;", "\u2561");
            htmlEntityMap.Add("&boxVl;", "\u2562");
            htmlEntityMap.Add("&boxVL;", "\u2563");
            htmlEntityMap.Add("&boxvr;", "\u251C");
            htmlEntityMap.Add("&boxvR;", "\u255E");
            htmlEntityMap.Add("&boxVr;", "\u255F");
            htmlEntityMap.Add("&boxVR;", "\u2560");
            htmlEntityMap.Add("&bprime;", "\u2035");
            htmlEntityMap.Add("&breve;", "\u02D8");
            htmlEntityMap.Add("&Breve;", "\u02D8");
            htmlEntityMap.Add("&brvbar;", "\u00A6");
            htmlEntityMap.Add("&brvbar", "\u00A6");
            htmlEntityMap.Add("&bscr;", "\uD835\uDCB7");
            htmlEntityMap.Add("&Bscr;", "\u212C");
            htmlEntityMap.Add("&bsemi;", "\u204F");
            htmlEntityMap.Add("&bsim;", "\u223D");
            htmlEntityMap.Add("&bsime;", "\u22CD");
            htmlEntityMap.Add("&bsolb;", "\u29C5");
            htmlEntityMap.Add("&bsol;", "\u005C");
            htmlEntityMap.Add("&bsolhsub;", "\u27C8");
            htmlEntityMap.Add("&bull;", "\u2022");
            htmlEntityMap.Add("&bullet;", "\u2022");
            htmlEntityMap.Add("&bump;", "\u224E");
            htmlEntityMap.Add("&bumpE;", "\u2AAE");
            htmlEntityMap.Add("&bumpe;", "\u224F");
            htmlEntityMap.Add("&Bumpeq;", "\u224E");
            htmlEntityMap.Add("&bumpeq;", "\u224F");
            htmlEntityMap.Add("&Cacute;", "\u0106");
            htmlEntityMap.Add("&cacute;", "\u0107");
            htmlEntityMap.Add("&capand;", "\u2A44");
            htmlEntityMap.Add("&capbrcup;", "\u2A49");
            htmlEntityMap.Add("&capcap;", "\u2A4B");
            htmlEntityMap.Add("&cap;", "\u2229");
            htmlEntityMap.Add("&Cap;", "\u22D2");
            htmlEntityMap.Add("&capcup;", "\u2A47");
            htmlEntityMap.Add("&capdot;", "\u2A40");
            htmlEntityMap.Add("&CapitalDifferentialD;", "\u2145");
            htmlEntityMap.Add("&caps;", "\u2229\uFE00");
            htmlEntityMap.Add("&caret;", "\u2041");
            htmlEntityMap.Add("&caron;", "\u02C7");
            htmlEntityMap.Add("&Cayleys;", "\u212D");
            htmlEntityMap.Add("&ccaps;", "\u2A4D");
            htmlEntityMap.Add("&Ccaron;", "\u010C");
            htmlEntityMap.Add("&ccaron;", "\u010D");
            htmlEntityMap.Add("&Ccedil;", "\u00C7");
            htmlEntityMap.Add("&Ccedil", "\u00C7");
            htmlEntityMap.Add("&ccedil;", "\u00E7");
            htmlEntityMap.Add("&ccedil", "\u00E7");
            htmlEntityMap.Add("&Ccirc;", "\u0108");
            htmlEntityMap.Add("&ccirc;", "\u0109");
            htmlEntityMap.Add("&Cconint;", "\u2230");
            htmlEntityMap.Add("&ccups;", "\u2A4C");
            htmlEntityMap.Add("&ccupssm;", "\u2A50");
            htmlEntityMap.Add("&Cdot;", "\u010A");
            htmlEntityMap.Add("&cdot;", "\u010B");
            htmlEntityMap.Add("&cedil;", "\u00B8");
            htmlEntityMap.Add("&cedil", "\u00B8");
            htmlEntityMap.Add("&Cedilla;", "\u00B8");
            htmlEntityMap.Add("&cemptyv;", "\u29B2");
            htmlEntityMap.Add("&cent;", "\u00A2");
            htmlEntityMap.Add("&cent", "\u00A2");
            htmlEntityMap.Add("&centerdot;", "\u00B7");
            htmlEntityMap.Add("&CenterDot;", "\u00B7");
            htmlEntityMap.Add("&cfr;", "\uD835\uDD20");
            htmlEntityMap.Add("&Cfr;", "\u212D");
            htmlEntityMap.Add("&CHcy;", "\u0427");
            htmlEntityMap.Add("&chcy;", "\u0447");
            htmlEntityMap.Add("&check;", "\u2713");
            htmlEntityMap.Add("&checkmark;", "\u2713");
            htmlEntityMap.Add("&Chi;", "\u03A7");
            htmlEntityMap.Add("&chi;", "\u03C7");
            htmlEntityMap.Add("&circ;", "\u02C6");
            htmlEntityMap.Add("&circeq;", "\u2257");
            htmlEntityMap.Add("&circlearrowleft;", "\u21BA");
            htmlEntityMap.Add("&circlearrowright;", "\u21BB");
            htmlEntityMap.Add("&circledast;", "\u229B");
            htmlEntityMap.Add("&circledcirc;", "\u229A");
            htmlEntityMap.Add("&circleddash;", "\u229D");
            htmlEntityMap.Add("&CircleDot;", "\u2299");
            htmlEntityMap.Add("&circledR;", "\u00AE");
            htmlEntityMap.Add("&circledS;", "\u24C8");
            htmlEntityMap.Add("&CircleMinus;", "\u2296");
            htmlEntityMap.Add("&CirclePlus;", "\u2295");
            htmlEntityMap.Add("&CircleTimes;", "\u2297");
            htmlEntityMap.Add("&cir;", "\u25CB");
            htmlEntityMap.Add("&cirE;", "\u29C3");
            htmlEntityMap.Add("&cire;", "\u2257");
            htmlEntityMap.Add("&cirfnint;", "\u2A10");
            htmlEntityMap.Add("&cirmid;", "\u2AEF");
            htmlEntityMap.Add("&cirscir;", "\u29C2");
            htmlEntityMap.Add("&ClockwiseContourIntegral;", "\u2232");
            htmlEntityMap.Add("&CloseCurlyDoubleQuote;", "\u201D");
            htmlEntityMap.Add("&CloseCurlyQuote;", "\u2019");
            htmlEntityMap.Add("&clubs;", "\u2663");
            htmlEntityMap.Add("&clubsuit;", "\u2663");
            htmlEntityMap.Add("&colon;", "\u003A");
            htmlEntityMap.Add("&Colon;", "\u2237");
            htmlEntityMap.Add("&Colone;", "\u2A74");
            htmlEntityMap.Add("&colone;", "\u2254");
            htmlEntityMap.Add("&coloneq;", "\u2254");
            htmlEntityMap.Add("&comma;", "\u002C");
            htmlEntityMap.Add("&commat;", "\u0040");
            htmlEntityMap.Add("&comp;", "\u2201");
            htmlEntityMap.Add("&compfn;", "\u2218");
            htmlEntityMap.Add("&complement;", "\u2201");
            htmlEntityMap.Add("&complexes;", "\u2102");
            htmlEntityMap.Add("&cong;", "\u2245");
            htmlEntityMap.Add("&congdot;", "\u2A6D");
            htmlEntityMap.Add("&Congruent;", "\u2261");
            htmlEntityMap.Add("&conint;", "\u222E");
            htmlEntityMap.Add("&Conint;", "\u222F");
            htmlEntityMap.Add("&ContourIntegral;", "\u222E");
            htmlEntityMap.Add("&copf;", "\uD835\uDD54");
            htmlEntityMap.Add("&Copf;", "\u2102");
            htmlEntityMap.Add("&coprod;", "\u2210");
            htmlEntityMap.Add("&Coproduct;", "\u2210");
            htmlEntityMap.Add("&copy;", "\u00A9");
            htmlEntityMap.Add("&copy", "\u00A9");
            htmlEntityMap.Add("&COPY;", "\u00A9");
            htmlEntityMap.Add("&COPY", "\u00A9");
            htmlEntityMap.Add("&copysr;", "\u2117");
            htmlEntityMap.Add("&CounterClockwiseContourIntegral;", "\u2233");
            htmlEntityMap.Add("&crarr;", "\u21B5");
            htmlEntityMap.Add("&cross;", "\u2717");
            htmlEntityMap.Add("&Cross;", "\u2A2F");
            htmlEntityMap.Add("&Cscr;", "\uD835\uDC9E");
            htmlEntityMap.Add("&cscr;", "\uD835\uDCB8");
            htmlEntityMap.Add("&csub;", "\u2ACF");
            htmlEntityMap.Add("&csube;", "\u2AD1");
            htmlEntityMap.Add("&csup;", "\u2AD0");
            htmlEntityMap.Add("&csupe;", "\u2AD2");
            htmlEntityMap.Add("&ctdot;", "\u22EF");
            htmlEntityMap.Add("&cudarrl;", "\u2938");
            htmlEntityMap.Add("&cudarrr;", "\u2935");
            htmlEntityMap.Add("&cuepr;", "\u22DE");
            htmlEntityMap.Add("&cuesc;", "\u22DF");
            htmlEntityMap.Add("&cularr;", "\u21B6");
            htmlEntityMap.Add("&cularrp;", "\u293D");
            htmlEntityMap.Add("&cupbrcap;", "\u2A48");
            htmlEntityMap.Add("&cupcap;", "\u2A46");
            htmlEntityMap.Add("&CupCap;", "\u224D");
            htmlEntityMap.Add("&cup;", "\u222A");
            htmlEntityMap.Add("&Cup;", "\u22D3");
            htmlEntityMap.Add("&cupcup;", "\u2A4A");
            htmlEntityMap.Add("&cupdot;", "\u228D");
            htmlEntityMap.Add("&cupor;", "\u2A45");
            htmlEntityMap.Add("&cups;", "\u222A\uFE00");
            htmlEntityMap.Add("&curarr;", "\u21B7");
            htmlEntityMap.Add("&curarrm;", "\u293C");
            htmlEntityMap.Add("&curlyeqprec;", "\u22DE");
            htmlEntityMap.Add("&curlyeqsucc;", "\u22DF");
            htmlEntityMap.Add("&curlyvee;", "\u22CE");
            htmlEntityMap.Add("&curlywedge;", "\u22CF");
            htmlEntityMap.Add("&curren;", "\u00A4");
            htmlEntityMap.Add("&curren", "\u00A4");
            htmlEntityMap.Add("&curvearrowleft;", "\u21B6");
            htmlEntityMap.Add("&curvearrowright;", "\u21B7");
            htmlEntityMap.Add("&cuvee;", "\u22CE");
            htmlEntityMap.Add("&cuwed;", "\u22CF");
            htmlEntityMap.Add("&cwconint;", "\u2232");
            htmlEntityMap.Add("&cwint;", "\u2231");
            htmlEntityMap.Add("&cylcty;", "\u232D");
            htmlEntityMap.Add("&dagger;", "\u2020");
            htmlEntityMap.Add("&Dagger;", "\u2021");
            htmlEntityMap.Add("&daleth;", "\u2138");
            htmlEntityMap.Add("&darr;", "\u2193");
            htmlEntityMap.Add("&Darr;", "\u21A1");
            htmlEntityMap.Add("&dArr;", "\u21D3");
            htmlEntityMap.Add("&dash;", "\u2010");
            htmlEntityMap.Add("&Dashv;", "\u2AE4");
            htmlEntityMap.Add("&dashv;", "\u22A3");
            htmlEntityMap.Add("&dbkarow;", "\u290F");
            htmlEntityMap.Add("&dblac;", "\u02DD");
            htmlEntityMap.Add("&Dcaron;", "\u010E");
            htmlEntityMap.Add("&dcaron;", "\u010F");
            htmlEntityMap.Add("&Dcy;", "\u0414");
            htmlEntityMap.Add("&dcy;", "\u0434");
            htmlEntityMap.Add("&ddagger;", "\u2021");
            htmlEntityMap.Add("&ddarr;", "\u21CA");
            htmlEntityMap.Add("&DD;", "\u2145");
            htmlEntityMap.Add("&dd;", "\u2146");
            htmlEntityMap.Add("&DDotrahd;", "\u2911");
            htmlEntityMap.Add("&ddotseq;", "\u2A77");
            htmlEntityMap.Add("&deg;", "\u00B0");
            htmlEntityMap.Add("&deg", "\u00B0");
            htmlEntityMap.Add("&Del;", "\u2207");
            htmlEntityMap.Add("&Delta;", "\u0394");
            htmlEntityMap.Add("&delta;", "\u03B4");
            htmlEntityMap.Add("&demptyv;", "\u29B1");
            htmlEntityMap.Add("&dfisht;", "\u297F");
            htmlEntityMap.Add("&Dfr;", "\uD835\uDD07");
            htmlEntityMap.Add("&dfr;", "\uD835\uDD21");
            htmlEntityMap.Add("&dHar;", "\u2965");
            htmlEntityMap.Add("&dharl;", "\u21C3");
            htmlEntityMap.Add("&dharr;", "\u21C2");
            htmlEntityMap.Add("&DiacriticalAcute;", "\u00B4");
            htmlEntityMap.Add("&DiacriticalDot;", "\u02D9");
            htmlEntityMap.Add("&DiacriticalDoubleAcute;", "\u02DD");
            htmlEntityMap.Add("&DiacriticalGrave;", "\u0060");
            htmlEntityMap.Add("&DiacriticalTilde;", "\u02DC");
            htmlEntityMap.Add("&diam;", "\u22C4");
            htmlEntityMap.Add("&diamond;", "\u22C4");
            htmlEntityMap.Add("&Diamond;", "\u22C4");
            htmlEntityMap.Add("&diamondsuit;", "\u2666");
            htmlEntityMap.Add("&diams;", "\u2666");
            htmlEntityMap.Add("&die;", "\u00A8");
            htmlEntityMap.Add("&DifferentialD;", "\u2146");
            htmlEntityMap.Add("&digamma;", "\u03DD");
            htmlEntityMap.Add("&disin;", "\u22F2");
            htmlEntityMap.Add("&div;", "\u00F7");
            htmlEntityMap.Add("&divide;", "\u00F7");
            htmlEntityMap.Add("&divide", "\u00F7");
            htmlEntityMap.Add("&divideontimes;", "\u22C7");
            htmlEntityMap.Add("&divonx;", "\u22C7");
            htmlEntityMap.Add("&DJcy;", "\u0402");
            htmlEntityMap.Add("&djcy;", "\u0452");
            htmlEntityMap.Add("&dlcorn;", "\u231E");
            htmlEntityMap.Add("&dlcrop;", "\u230D");
            htmlEntityMap.Add("&dollar;", "\u0024");
            htmlEntityMap.Add("&Dopf;", "\uD835\uDD3B");
            htmlEntityMap.Add("&dopf;", "\uD835\uDD55");
            htmlEntityMap.Add("&Dot;", "\u00A8");
            htmlEntityMap.Add("&dot;", "\u02D9");
            htmlEntityMap.Add("&DotDot;", "\u20DC");
            htmlEntityMap.Add("&doteq;", "\u2250");
            htmlEntityMap.Add("&doteqdot;", "\u2251");
            htmlEntityMap.Add("&DotEqual;", "\u2250");
            htmlEntityMap.Add("&dotminus;", "\u2238");
            htmlEntityMap.Add("&dotplus;", "\u2214");
            htmlEntityMap.Add("&dotsquare;", "\u22A1");
            htmlEntityMap.Add("&doublebarwedge;", "\u2306");
            htmlEntityMap.Add("&DoubleContourIntegral;", "\u222F");
            htmlEntityMap.Add("&DoubleDot;", "\u00A8");
            htmlEntityMap.Add("&DoubleDownArrow;", "\u21D3");
            htmlEntityMap.Add("&DoubleLeftArrow;", "\u21D0");
            htmlEntityMap.Add("&DoubleLeftRightArrow;", "\u21D4");
            htmlEntityMap.Add("&DoubleLeftTee;", "\u2AE4");
            htmlEntityMap.Add("&DoubleLongLeftArrow;", "\u27F8");
            htmlEntityMap.Add("&DoubleLongLeftRightArrow;", "\u27FA");
            htmlEntityMap.Add("&DoubleLongRightArrow;", "\u27F9");
            htmlEntityMap.Add("&DoubleRightArrow;", "\u21D2");
            htmlEntityMap.Add("&DoubleRightTee;", "\u22A8");
            htmlEntityMap.Add("&DoubleUpArrow;", "\u21D1");
            htmlEntityMap.Add("&DoubleUpDownArrow;", "\u21D5");
            htmlEntityMap.Add("&DoubleVerticalBar;", "\u2225");
            htmlEntityMap.Add("&DownArrowBar;", "\u2913");
            htmlEntityMap.Add("&downarrow;", "\u2193");
            htmlEntityMap.Add("&DownArrow;", "\u2193");
            htmlEntityMap.Add("&Downarrow;", "\u21D3");
            htmlEntityMap.Add("&DownArrowUpArrow;", "\u21F5");
            htmlEntityMap.Add("&DownBreve;", "\u0311");
            htmlEntityMap.Add("&downdownarrows;", "\u21CA");
            htmlEntityMap.Add("&downharpoonleft;", "\u21C3");
            htmlEntityMap.Add("&downharpoonright;", "\u21C2");
            htmlEntityMap.Add("&DownLeftRightVector;", "\u2950");
            htmlEntityMap.Add("&DownLeftTeeVector;", "\u295E");
            htmlEntityMap.Add("&DownLeftVectorBar;", "\u2956");
            htmlEntityMap.Add("&DownLeftVector;", "\u21BD");
            htmlEntityMap.Add("&DownRightTeeVector;", "\u295F");
            htmlEntityMap.Add("&DownRightVectorBar;", "\u2957");
            htmlEntityMap.Add("&DownRightVector;", "\u21C1");
            htmlEntityMap.Add("&DownTeeArrow;", "\u21A7");
            htmlEntityMap.Add("&DownTee;", "\u22A4");
            htmlEntityMap.Add("&drbkarow;", "\u2910");
            htmlEntityMap.Add("&drcorn;", "\u231F");
            htmlEntityMap.Add("&drcrop;", "\u230C");
            htmlEntityMap.Add("&Dscr;", "\uD835\uDC9F");
            htmlEntityMap.Add("&dscr;", "\uD835\uDCB9");
            htmlEntityMap.Add("&DScy;", "\u0405");
            htmlEntityMap.Add("&dscy;", "\u0455");
            htmlEntityMap.Add("&dsol;", "\u29F6");
            htmlEntityMap.Add("&Dstrok;", "\u0110");
            htmlEntityMap.Add("&dstrok;", "\u0111");
            htmlEntityMap.Add("&dtdot;", "\u22F1");
            htmlEntityMap.Add("&dtri;", "\u25BF");
            htmlEntityMap.Add("&dtrif;", "\u25BE");
            htmlEntityMap.Add("&duarr;", "\u21F5");
            htmlEntityMap.Add("&duhar;", "\u296F");
            htmlEntityMap.Add("&dwangle;", "\u29A6");
            htmlEntityMap.Add("&DZcy;", "\u040F");
            htmlEntityMap.Add("&dzcy;", "\u045F");
            htmlEntityMap.Add("&dzigrarr;", "\u27FF");
            htmlEntityMap.Add("&Eacute;", "\u00C9");
            htmlEntityMap.Add("&Eacute", "\u00C9");
            htmlEntityMap.Add("&eacute;", "\u00E9");
            htmlEntityMap.Add("&eacute", "\u00E9");
            htmlEntityMap.Add("&easter;", "\u2A6E");
            htmlEntityMap.Add("&Ecaron;", "\u011A");
            htmlEntityMap.Add("&ecaron;", "\u011B");
            htmlEntityMap.Add("&Ecirc;", "\u00CA");
            htmlEntityMap.Add("&Ecirc", "\u00CA");
            htmlEntityMap.Add("&ecirc;", "\u00EA");
            htmlEntityMap.Add("&ecirc", "\u00EA");
            htmlEntityMap.Add("&ecir;", "\u2256");
            htmlEntityMap.Add("&ecolon;", "\u2255");
            htmlEntityMap.Add("&Ecy;", "\u042D");
            htmlEntityMap.Add("&ecy;", "\u044D");
            htmlEntityMap.Add("&eDDot;", "\u2A77");
            htmlEntityMap.Add("&Edot;", "\u0116");
            htmlEntityMap.Add("&edot;", "\u0117");
            htmlEntityMap.Add("&eDot;", "\u2251");
            htmlEntityMap.Add("&ee;", "\u2147");
            htmlEntityMap.Add("&efDot;", "\u2252");
            htmlEntityMap.Add("&Efr;", "\uD835\uDD08");
            htmlEntityMap.Add("&efr;", "\uD835\uDD22");
            htmlEntityMap.Add("&eg;", "\u2A9A");
            htmlEntityMap.Add("&Egrave;", "\u00C8");
            htmlEntityMap.Add("&Egrave", "\u00C8");
            htmlEntityMap.Add("&egrave;", "\u00E8");
            htmlEntityMap.Add("&egrave", "\u00E8");
            htmlEntityMap.Add("&egs;", "\u2A96");
            htmlEntityMap.Add("&egsdot;", "\u2A98");
            htmlEntityMap.Add("&el;", "\u2A99");
            htmlEntityMap.Add("&Element;", "\u2208");
            htmlEntityMap.Add("&elinters;", "\u23E7");
            htmlEntityMap.Add("&ell;", "\u2113");
            htmlEntityMap.Add("&els;", "\u2A95");
            htmlEntityMap.Add("&elsdot;", "\u2A97");
            htmlEntityMap.Add("&Emacr;", "\u0112");
            htmlEntityMap.Add("&emacr;", "\u0113");
            htmlEntityMap.Add("&empty;", "\u2205");
            htmlEntityMap.Add("&emptyset;", "\u2205");
            htmlEntityMap.Add("&EmptySmallSquare;", "\u25FB");
            htmlEntityMap.Add("&emptyv;", "\u2205");
            htmlEntityMap.Add("&EmptyVerySmallSquare;", "\u25AB");
            htmlEntityMap.Add("&emsp13;", "\u2004");
            htmlEntityMap.Add("&emsp14;", "\u2005");
            htmlEntityMap.Add("&emsp;", "\u2003");
            htmlEntityMap.Add("&ENG;", "\u014A");
            htmlEntityMap.Add("&eng;", "\u014B");
            htmlEntityMap.Add("&ensp;", "\u2002");
            htmlEntityMap.Add("&Eogon;", "\u0118");
            htmlEntityMap.Add("&eogon;", "\u0119");
            htmlEntityMap.Add("&Eopf;", "\uD835\uDD3C");
            htmlEntityMap.Add("&eopf;", "\uD835\uDD56");
            htmlEntityMap.Add("&epar;", "\u22D5");
            htmlEntityMap.Add("&eparsl;", "\u29E3");
            htmlEntityMap.Add("&eplus;", "\u2A71");
            htmlEntityMap.Add("&epsi;", "\u03B5");
            htmlEntityMap.Add("&Epsilon;", "\u0395");
            htmlEntityMap.Add("&epsilon;", "\u03B5");
            htmlEntityMap.Add("&epsiv;", "\u03F5");
            htmlEntityMap.Add("&eqcirc;", "\u2256");
            htmlEntityMap.Add("&eqcolon;", "\u2255");
            htmlEntityMap.Add("&eqsim;", "\u2242");
            htmlEntityMap.Add("&eqslantgtr;", "\u2A96");
            htmlEntityMap.Add("&eqslantless;", "\u2A95");
            htmlEntityMap.Add("&Equal;", "\u2A75");
            htmlEntityMap.Add("&equals;", "\u003D");
            htmlEntityMap.Add("&EqualTilde;", "\u2242");
            htmlEntityMap.Add("&equest;", "\u225F");
            htmlEntityMap.Add("&Equilibrium;", "\u21CC");
            htmlEntityMap.Add("&equiv;", "\u2261");
            htmlEntityMap.Add("&equivDD;", "\u2A78");
            htmlEntityMap.Add("&eqvparsl;", "\u29E5");
            htmlEntityMap.Add("&erarr;", "\u2971");
            htmlEntityMap.Add("&erDot;", "\u2253");
            htmlEntityMap.Add("&escr;", "\u212F");
            htmlEntityMap.Add("&Escr;", "\u2130");
            htmlEntityMap.Add("&esdot;", "\u2250");
            htmlEntityMap.Add("&Esim;", "\u2A73");
            htmlEntityMap.Add("&esim;", "\u2242");
            htmlEntityMap.Add("&Eta;", "\u0397");
            htmlEntityMap.Add("&eta;", "\u03B7");
            htmlEntityMap.Add("&ETH;", "\u00D0");
            htmlEntityMap.Add("&ETH", "\u00D0");
            htmlEntityMap.Add("&eth;", "\u00F0");
            htmlEntityMap.Add("&eth", "\u00F0");
            htmlEntityMap.Add("&Euml;", "\u00CB");
            htmlEntityMap.Add("&Euml", "\u00CB");
            htmlEntityMap.Add("&euml;", "\u00EB");
            htmlEntityMap.Add("&euml", "\u00EB");
            htmlEntityMap.Add("&euro;", "\u20AC");
            htmlEntityMap.Add("&excl;", "\u0021");
            htmlEntityMap.Add("&exist;", "\u2203");
            htmlEntityMap.Add("&Exists;", "\u2203");
            htmlEntityMap.Add("&expectation;", "\u2130");
            htmlEntityMap.Add("&exponentiale;", "\u2147");
            htmlEntityMap.Add("&ExponentialE;", "\u2147");
            htmlEntityMap.Add("&fallingdotseq;", "\u2252");
            htmlEntityMap.Add("&Fcy;", "\u0424");
            htmlEntityMap.Add("&fcy;", "\u0444");
            htmlEntityMap.Add("&female;", "\u2640");
            htmlEntityMap.Add("&ffilig;", "\uFB03");
            htmlEntityMap.Add("&fflig;", "\uFB00");
            htmlEntityMap.Add("&ffllig;", "\uFB04");
            htmlEntityMap.Add("&Ffr;", "\uD835\uDD09");
            htmlEntityMap.Add("&ffr;", "\uD835\uDD23");
            htmlEntityMap.Add("&filig;", "\uFB01");
            htmlEntityMap.Add("&FilledSmallSquare;", "\u25FC");
            htmlEntityMap.Add("&FilledVerySmallSquare;", "\u25AA");
            htmlEntityMap.Add("&fjlig;", "\u0066\u006A");
            htmlEntityMap.Add("&flat;", "\u266D");
            htmlEntityMap.Add("&fllig;", "\uFB02");
            htmlEntityMap.Add("&fltns;", "\u25B1");
            htmlEntityMap.Add("&fnof;", "\u0192");
            htmlEntityMap.Add("&Fopf;", "\uD835\uDD3D");
            htmlEntityMap.Add("&fopf;", "\uD835\uDD57");
            htmlEntityMap.Add("&forall;", "\u2200");
            htmlEntityMap.Add("&ForAll;", "\u2200");
            htmlEntityMap.Add("&fork;", "\u22D4");
            htmlEntityMap.Add("&forkv;", "\u2AD9");
            htmlEntityMap.Add("&Fouriertrf;", "\u2131");
            htmlEntityMap.Add("&fpartint;", "\u2A0D");
            htmlEntityMap.Add("&frac12;", "\u00BD");
            htmlEntityMap.Add("&frac12", "\u00BD");
            htmlEntityMap.Add("&frac13;", "\u2153");
            htmlEntityMap.Add("&frac14;", "\u00BC");
            htmlEntityMap.Add("&frac14", "\u00BC");
            htmlEntityMap.Add("&frac15;", "\u2155");
            htmlEntityMap.Add("&frac16;", "\u2159");
            htmlEntityMap.Add("&frac18;", "\u215B");
            htmlEntityMap.Add("&frac23;", "\u2154");
            htmlEntityMap.Add("&frac25;", "\u2156");
            htmlEntityMap.Add("&frac34;", "\u00BE");
            htmlEntityMap.Add("&frac34", "\u00BE");
            htmlEntityMap.Add("&frac35;", "\u2157");
            htmlEntityMap.Add("&frac38;", "\u215C");
            htmlEntityMap.Add("&frac45;", "\u2158");
            htmlEntityMap.Add("&frac56;", "\u215A");
            htmlEntityMap.Add("&frac58;", "\u215D");
            htmlEntityMap.Add("&frac78;", "\u215E");
            htmlEntityMap.Add("&frasl;", "\u2044");
            htmlEntityMap.Add("&frown;", "\u2322");
            htmlEntityMap.Add("&fscr;", "\uD835\uDCBB");
            htmlEntityMap.Add("&Fscr;", "\u2131");
            htmlEntityMap.Add("&gacute;", "\u01F5");
            htmlEntityMap.Add("&Gamma;", "\u0393");
            htmlEntityMap.Add("&gamma;", "\u03B3");
            htmlEntityMap.Add("&Gammad;", "\u03DC");
            htmlEntityMap.Add("&gammad;", "\u03DD");
            htmlEntityMap.Add("&gap;", "\u2A86");
            htmlEntityMap.Add("&Gbreve;", "\u011E");
            htmlEntityMap.Add("&gbreve;", "\u011F");
            htmlEntityMap.Add("&Gcedil;", "\u0122");
            htmlEntityMap.Add("&Gcirc;", "\u011C");
            htmlEntityMap.Add("&gcirc;", "\u011D");
            htmlEntityMap.Add("&Gcy;", "\u0413");
            htmlEntityMap.Add("&gcy;", "\u0433");
            htmlEntityMap.Add("&Gdot;", "\u0120");
            htmlEntityMap.Add("&gdot;", "\u0121");
            htmlEntityMap.Add("&ge;", "\u2265");
            htmlEntityMap.Add("&gE;", "\u2267");
            htmlEntityMap.Add("&gEl;", "\u2A8C");
            htmlEntityMap.Add("&gel;", "\u22DB");
            htmlEntityMap.Add("&geq;", "\u2265");
            htmlEntityMap.Add("&geqq;", "\u2267");
            htmlEntityMap.Add("&geqslant;", "\u2A7E");
            htmlEntityMap.Add("&gescc;", "\u2AA9");
            htmlEntityMap.Add("&ges;", "\u2A7E");
            htmlEntityMap.Add("&gesdot;", "\u2A80");
            htmlEntityMap.Add("&gesdoto;", "\u2A82");
            htmlEntityMap.Add("&gesdotol;", "\u2A84");
            htmlEntityMap.Add("&gesl;", "\u22DB\uFE00");
            htmlEntityMap.Add("&gesles;", "\u2A94");
            htmlEntityMap.Add("&Gfr;", "\uD835\uDD0A");
            htmlEntityMap.Add("&gfr;", "\uD835\uDD24");
            htmlEntityMap.Add("&gg;", "\u226B");
            htmlEntityMap.Add("&Gg;", "\u22D9");
            htmlEntityMap.Add("&ggg;", "\u22D9");
            htmlEntityMap.Add("&gimel;", "\u2137");
            htmlEntityMap.Add("&GJcy;", "\u0403");
            htmlEntityMap.Add("&gjcy;", "\u0453");
            htmlEntityMap.Add("&gla;", "\u2AA5");
            htmlEntityMap.Add("&gl;", "\u2277");
            htmlEntityMap.Add("&glE;", "\u2A92");
            htmlEntityMap.Add("&glj;", "\u2AA4");
            htmlEntityMap.Add("&gnap;", "\u2A8A");
            htmlEntityMap.Add("&gnapprox;", "\u2A8A");
            htmlEntityMap.Add("&gne;", "\u2A88");
            htmlEntityMap.Add("&gnE;", "\u2269");
            htmlEntityMap.Add("&gneq;", "\u2A88");
            htmlEntityMap.Add("&gneqq;", "\u2269");
            htmlEntityMap.Add("&gnsim;", "\u22E7");
            htmlEntityMap.Add("&Gopf;", "\uD835\uDD3E");
            htmlEntityMap.Add("&gopf;", "\uD835\uDD58");
            htmlEntityMap.Add("&grave;", "\u0060");
            htmlEntityMap.Add("&GreaterEqual;", "\u2265");
            htmlEntityMap.Add("&GreaterEqualLess;", "\u22DB");
            htmlEntityMap.Add("&GreaterFullEqual;", "\u2267");
            htmlEntityMap.Add("&GreaterGreater;", "\u2AA2");
            htmlEntityMap.Add("&GreaterLess;", "\u2277");
            htmlEntityMap.Add("&GreaterSlantEqual;", "\u2A7E");
            htmlEntityMap.Add("&GreaterTilde;", "\u2273");
            htmlEntityMap.Add("&Gscr;", "\uD835\uDCA2");
            htmlEntityMap.Add("&gscr;", "\u210A");
            htmlEntityMap.Add("&gsim;", "\u2273");
            htmlEntityMap.Add("&gsime;", "\u2A8E");
            htmlEntityMap.Add("&gsiml;", "\u2A90");
            htmlEntityMap.Add("&gtcc;", "\u2AA7");
            htmlEntityMap.Add("&gtcir;", "\u2A7A");
            htmlEntityMap.Add("&gt;", "\u003E");
            htmlEntityMap.Add("&gt", "\u003E");
            htmlEntityMap.Add("&GT;", "\u003E");
            htmlEntityMap.Add("&GT", "\u003E");
            htmlEntityMap.Add("&Gt;", "\u226B");
            htmlEntityMap.Add("&gtdot;", "\u22D7");
            htmlEntityMap.Add("&gtlPar;", "\u2995");
            htmlEntityMap.Add("&gtquest;", "\u2A7C");
            htmlEntityMap.Add("&gtrapprox;", "\u2A86");
            htmlEntityMap.Add("&gtrarr;", "\u2978");
            htmlEntityMap.Add("&gtrdot;", "\u22D7");
            htmlEntityMap.Add("&gtreqless;", "\u22DB");
            htmlEntityMap.Add("&gtreqqless;", "\u2A8C");
            htmlEntityMap.Add("&gtrless;", "\u2277");
            htmlEntityMap.Add("&gtrsim;", "\u2273");
            htmlEntityMap.Add("&gvertneqq;", "\u2269\uFE00");
            htmlEntityMap.Add("&gvnE;", "\u2269\uFE00");
            htmlEntityMap.Add("&Hacek;", "\u02C7");
            htmlEntityMap.Add("&hairsp;", "\u200A");
            htmlEntityMap.Add("&half;", "\u00BD");
            htmlEntityMap.Add("&hamilt;", "\u210B");
            htmlEntityMap.Add("&HARDcy;", "\u042A");
            htmlEntityMap.Add("&hardcy;", "\u044A");
            htmlEntityMap.Add("&harrcir;", "\u2948");
            htmlEntityMap.Add("&harr;", "\u2194");
            htmlEntityMap.Add("&hArr;", "\u21D4");
            htmlEntityMap.Add("&harrw;", "\u21AD");
            htmlEntityMap.Add("&Hat;", "\u005E");
            htmlEntityMap.Add("&hbar;", "\u210F");
            htmlEntityMap.Add("&Hcirc;", "\u0124");
            htmlEntityMap.Add("&hcirc;", "\u0125");
            htmlEntityMap.Add("&hearts;", "\u2665");
            htmlEntityMap.Add("&heartsuit;", "\u2665");
            htmlEntityMap.Add("&hellip;", "\u2026");
            htmlEntityMap.Add("&hercon;", "\u22B9");
            htmlEntityMap.Add("&hfr;", "\uD835\uDD25");
            htmlEntityMap.Add("&Hfr;", "\u210C");
            htmlEntityMap.Add("&HilbertSpace;", "\u210B");
            htmlEntityMap.Add("&hksearow;", "\u2925");
            htmlEntityMap.Add("&hkswarow;", "\u2926");
            htmlEntityMap.Add("&hoarr;", "\u21FF");
            htmlEntityMap.Add("&homtht;", "\u223B");
            htmlEntityMap.Add("&hookleftarrow;", "\u21A9");
            htmlEntityMap.Add("&hookrightarrow;", "\u21AA");
            htmlEntityMap.Add("&hopf;", "\uD835\uDD59");
            htmlEntityMap.Add("&Hopf;", "\u210D");
            htmlEntityMap.Add("&horbar;", "\u2015");
            htmlEntityMap.Add("&HorizontalLine;", "\u2500");
            htmlEntityMap.Add("&hscr;", "\uD835\uDCBD");
            htmlEntityMap.Add("&Hscr;", "\u210B");
            htmlEntityMap.Add("&hslash;", "\u210F");
            htmlEntityMap.Add("&Hstrok;", "\u0126");
            htmlEntityMap.Add("&hstrok;", "\u0127");
            htmlEntityMap.Add("&HumpDownHump;", "\u224E");
            htmlEntityMap.Add("&HumpEqual;", "\u224F");
            htmlEntityMap.Add("&hybull;", "\u2043");
            htmlEntityMap.Add("&hyphen;", "\u2010");
            htmlEntityMap.Add("&Iacute;", "\u00CD");
            htmlEntityMap.Add("&Iacute", "\u00CD");
            htmlEntityMap.Add("&iacute;", "\u00ED");
            htmlEntityMap.Add("&iacute", "\u00ED");
            htmlEntityMap.Add("&ic;", "\u2063");
            htmlEntityMap.Add("&Icirc;", "\u00CE");
            htmlEntityMap.Add("&Icirc", "\u00CE");
            htmlEntityMap.Add("&icirc;", "\u00EE");
            htmlEntityMap.Add("&icirc", "\u00EE");
            htmlEntityMap.Add("&Icy;", "\u0418");
            htmlEntityMap.Add("&icy;", "\u0438");
            htmlEntityMap.Add("&Idot;", "\u0130");
            htmlEntityMap.Add("&IEcy;", "\u0415");
            htmlEntityMap.Add("&iecy;", "\u0435");
            htmlEntityMap.Add("&iexcl;", "\u00A1");
            htmlEntityMap.Add("&iexcl", "\u00A1");
            htmlEntityMap.Add("&iff;", "\u21D4");
            htmlEntityMap.Add("&ifr;", "\uD835\uDD26");
            htmlEntityMap.Add("&Ifr;", "\u2111");
            htmlEntityMap.Add("&Igrave;", "\u00CC");
            htmlEntityMap.Add("&Igrave", "\u00CC");
            htmlEntityMap.Add("&igrave;", "\u00EC");
            htmlEntityMap.Add("&igrave", "\u00EC");
            htmlEntityMap.Add("&ii;", "\u2148");
            htmlEntityMap.Add("&iiiint;", "\u2A0C");
            htmlEntityMap.Add("&iiint;", "\u222D");
            htmlEntityMap.Add("&iinfin;", "\u29DC");
            htmlEntityMap.Add("&iiota;", "\u2129");
            htmlEntityMap.Add("&IJlig;", "\u0132");
            htmlEntityMap.Add("&ijlig;", "\u0133");
            htmlEntityMap.Add("&Imacr;", "\u012A");
            htmlEntityMap.Add("&imacr;", "\u012B");
            htmlEntityMap.Add("&image;", "\u2111");
            htmlEntityMap.Add("&ImaginaryI;", "\u2148");
            htmlEntityMap.Add("&imagline;", "\u2110");
            htmlEntityMap.Add("&imagpart;", "\u2111");
            htmlEntityMap.Add("&imath;", "\u0131");
            htmlEntityMap.Add("&Im;", "\u2111");
            htmlEntityMap.Add("&imof;", "\u22B7");
            htmlEntityMap.Add("&imped;", "\u01B5");
            htmlEntityMap.Add("&Implies;", "\u21D2");
            htmlEntityMap.Add("&incare;", "\u2105");
            htmlEntityMap.Add("&in;", "\u2208");
            htmlEntityMap.Add("&infin;", "\u221E");
            htmlEntityMap.Add("&infintie;", "\u29DD");
            htmlEntityMap.Add("&inodot;", "\u0131");
            htmlEntityMap.Add("&intcal;", "\u22BA");
            htmlEntityMap.Add("&int;", "\u222B");
            htmlEntityMap.Add("&Int;", "\u222C");
            htmlEntityMap.Add("&integers;", "\u2124");
            htmlEntityMap.Add("&Integral;", "\u222B");
            htmlEntityMap.Add("&intercal;", "\u22BA");
            htmlEntityMap.Add("&Intersection;", "\u22C2");
            htmlEntityMap.Add("&intlarhk;", "\u2A17");
            htmlEntityMap.Add("&intprod;", "\u2A3C");
            htmlEntityMap.Add("&InvisibleComma;", "\u2063");
            htmlEntityMap.Add("&InvisibleTimes;", "\u2062");
            htmlEntityMap.Add("&IOcy;", "\u0401");
            htmlEntityMap.Add("&iocy;", "\u0451");
            htmlEntityMap.Add("&Iogon;", "\u012E");
            htmlEntityMap.Add("&iogon;", "\u012F");
            htmlEntityMap.Add("&Iopf;", "\uD835\uDD40");
            htmlEntityMap.Add("&iopf;", "\uD835\uDD5A");
            htmlEntityMap.Add("&Iota;", "\u0399");
            htmlEntityMap.Add("&iota;", "\u03B9");
            htmlEntityMap.Add("&iprod;", "\u2A3C");
            htmlEntityMap.Add("&iquest;", "\u00BF");
            htmlEntityMap.Add("&iquest", "\u00BF");
            htmlEntityMap.Add("&iscr;", "\uD835\uDCBE");
            htmlEntityMap.Add("&Iscr;", "\u2110");
            htmlEntityMap.Add("&isin;", "\u2208");
            htmlEntityMap.Add("&isindot;", "\u22F5");
            htmlEntityMap.Add("&isinE;", "\u22F9");
            htmlEntityMap.Add("&isins;", "\u22F4");
            htmlEntityMap.Add("&isinsv;", "\u22F3");
            htmlEntityMap.Add("&isinv;", "\u2208");
            htmlEntityMap.Add("&it;", "\u2062");
            htmlEntityMap.Add("&Itilde;", "\u0128");
            htmlEntityMap.Add("&itilde;", "\u0129");
            htmlEntityMap.Add("&Iukcy;", "\u0406");
            htmlEntityMap.Add("&iukcy;", "\u0456");
            htmlEntityMap.Add("&Iuml;", "\u00CF");
            htmlEntityMap.Add("&Iuml", "\u00CF");
            htmlEntityMap.Add("&iuml;", "\u00EF");
            htmlEntityMap.Add("&iuml", "\u00EF");
            htmlEntityMap.Add("&Jcirc;", "\u0134");
            htmlEntityMap.Add("&jcirc;", "\u0135");
            htmlEntityMap.Add("&Jcy;", "\u0419");
            htmlEntityMap.Add("&jcy;", "\u0439");
            htmlEntityMap.Add("&Jfr;", "\uD835\uDD0D");
            htmlEntityMap.Add("&jfr;", "\uD835\uDD27");
            htmlEntityMap.Add("&jmath;", "\u0237");
            htmlEntityMap.Add("&Jopf;", "\uD835\uDD41");
            htmlEntityMap.Add("&jopf;", "\uD835\uDD5B");
            htmlEntityMap.Add("&Jscr;", "\uD835\uDCA5");
            htmlEntityMap.Add("&jscr;", "\uD835\uDCBF");
            htmlEntityMap.Add("&Jsercy;", "\u0408");
            htmlEntityMap.Add("&jsercy;", "\u0458");
            htmlEntityMap.Add("&Jukcy;", "\u0404");
            htmlEntityMap.Add("&jukcy;", "\u0454");
            htmlEntityMap.Add("&Kappa;", "\u039A");
            htmlEntityMap.Add("&kappa;", "\u03BA");
            htmlEntityMap.Add("&kappav;", "\u03F0");
            htmlEntityMap.Add("&Kcedil;", "\u0136");
            htmlEntityMap.Add("&kcedil;", "\u0137");
            htmlEntityMap.Add("&Kcy;", "\u041A");
            htmlEntityMap.Add("&kcy;", "\u043A");
            htmlEntityMap.Add("&Kfr;", "\uD835\uDD0E");
            htmlEntityMap.Add("&kfr;", "\uD835\uDD28");
            htmlEntityMap.Add("&kgreen;", "\u0138");
            htmlEntityMap.Add("&KHcy;", "\u0425");
            htmlEntityMap.Add("&khcy;", "\u0445");
            htmlEntityMap.Add("&KJcy;", "\u040C");
            htmlEntityMap.Add("&kjcy;", "\u045C");
            htmlEntityMap.Add("&Kopf;", "\uD835\uDD42");
            htmlEntityMap.Add("&kopf;", "\uD835\uDD5C");
            htmlEntityMap.Add("&Kscr;", "\uD835\uDCA6");
            htmlEntityMap.Add("&kscr;", "\uD835\uDCC0");
            htmlEntityMap.Add("&lAarr;", "\u21DA");
            htmlEntityMap.Add("&Lacute;", "\u0139");
            htmlEntityMap.Add("&lacute;", "\u013A");
            htmlEntityMap.Add("&laemptyv;", "\u29B4");
            htmlEntityMap.Add("&lagran;", "\u2112");
            htmlEntityMap.Add("&Lambda;", "\u039B");
            htmlEntityMap.Add("&lambda;", "\u03BB");
            htmlEntityMap.Add("&lang;", "\u27E8");
            htmlEntityMap.Add("&Lang;", "\u27EA");
            htmlEntityMap.Add("&langd;", "\u2991");
            htmlEntityMap.Add("&langle;", "\u27E8");
            htmlEntityMap.Add("&lap;", "\u2A85");
            htmlEntityMap.Add("&Laplacetrf;", "\u2112");
            htmlEntityMap.Add("&laquo;", "\u00AB");
            htmlEntityMap.Add("&laquo", "\u00AB");
            htmlEntityMap.Add("&larrb;", "\u21E4");
            htmlEntityMap.Add("&larrbfs;", "\u291F");
            htmlEntityMap.Add("&larr;", "\u2190");
            htmlEntityMap.Add("&Larr;", "\u219E");
            htmlEntityMap.Add("&lArr;", "\u21D0");
            htmlEntityMap.Add("&larrfs;", "\u291D");
            htmlEntityMap.Add("&larrhk;", "\u21A9");
            htmlEntityMap.Add("&larrlp;", "\u21AB");
            htmlEntityMap.Add("&larrpl;", "\u2939");
            htmlEntityMap.Add("&larrsim;", "\u2973");
            htmlEntityMap.Add("&larrtl;", "\u21A2");
            htmlEntityMap.Add("&latail;", "\u2919");
            htmlEntityMap.Add("&lAtail;", "\u291B");
            htmlEntityMap.Add("&lat;", "\u2AAB");
            htmlEntityMap.Add("&late;", "\u2AAD");
            htmlEntityMap.Add("&lates;", "\u2AAD\uFE00");
            htmlEntityMap.Add("&lbarr;", "\u290C");
            htmlEntityMap.Add("&lBarr;", "\u290E");
            htmlEntityMap.Add("&lbbrk;", "\u2772");
            htmlEntityMap.Add("&lbrace;", "\u007B");
            htmlEntityMap.Add("&lbrack;", "\u005B");
            htmlEntityMap.Add("&lbrke;", "\u298B");
            htmlEntityMap.Add("&lbrksld;", "\u298F");
            htmlEntityMap.Add("&lbrkslu;", "\u298D");
            htmlEntityMap.Add("&Lcaron;", "\u013D");
            htmlEntityMap.Add("&lcaron;", "\u013E");
            htmlEntityMap.Add("&Lcedil;", "\u013B");
            htmlEntityMap.Add("&lcedil;", "\u013C");
            htmlEntityMap.Add("&lceil;", "\u2308");
            htmlEntityMap.Add("&lcub;", "\u007B");
            htmlEntityMap.Add("&Lcy;", "\u041B");
            htmlEntityMap.Add("&lcy;", "\u043B");
            htmlEntityMap.Add("&ldca;", "\u2936");
            htmlEntityMap.Add("&ldquo;", "\u201C");
            htmlEntityMap.Add("&ldquor;", "\u201E");
            htmlEntityMap.Add("&ldrdhar;", "\u2967");
            htmlEntityMap.Add("&ldrushar;", "\u294B");
            htmlEntityMap.Add("&ldsh;", "\u21B2");
            htmlEntityMap.Add("&le;", "\u2264");
            htmlEntityMap.Add("&lE;", "\u2266");
            htmlEntityMap.Add("&LeftAngleBracket;", "\u27E8");
            htmlEntityMap.Add("&LeftArrowBar;", "\u21E4");
            htmlEntityMap.Add("&leftarrow;", "\u2190");
            htmlEntityMap.Add("&LeftArrow;", "\u2190");
            htmlEntityMap.Add("&Leftarrow;", "\u21D0");
            htmlEntityMap.Add("&LeftArrowRightArrow;", "\u21C6");
            htmlEntityMap.Add("&leftarrowtail;", "\u21A2");
            htmlEntityMap.Add("&LeftCeiling;", "\u2308");
            htmlEntityMap.Add("&LeftDoubleBracket;", "\u27E6");
            htmlEntityMap.Add("&LeftDownTeeVector;", "\u2961");
            htmlEntityMap.Add("&LeftDownVectorBar;", "\u2959");
            htmlEntityMap.Add("&LeftDownVector;", "\u21C3");
            htmlEntityMap.Add("&LeftFloor;", "\u230A");
            htmlEntityMap.Add("&leftharpoondown;", "\u21BD");
            htmlEntityMap.Add("&leftharpoonup;", "\u21BC");
            htmlEntityMap.Add("&leftleftarrows;", "\u21C7");
            htmlEntityMap.Add("&leftrightarrow;", "\u2194");
            htmlEntityMap.Add("&LeftRightArrow;", "\u2194");
            htmlEntityMap.Add("&Leftrightarrow;", "\u21D4");
            htmlEntityMap.Add("&leftrightarrows;", "\u21C6");
            htmlEntityMap.Add("&leftrightharpoons;", "\u21CB");
            htmlEntityMap.Add("&leftrightsquigarrow;", "\u21AD");
            htmlEntityMap.Add("&LeftRightVector;", "\u294E");
            htmlEntityMap.Add("&LeftTeeArrow;", "\u21A4");
            htmlEntityMap.Add("&LeftTee;", "\u22A3");
            htmlEntityMap.Add("&LeftTeeVector;", "\u295A");
            htmlEntityMap.Add("&leftthreetimes;", "\u22CB");
            htmlEntityMap.Add("&LeftTriangleBar;", "\u29CF");
            htmlEntityMap.Add("&LeftTriangle;", "\u22B2");
            htmlEntityMap.Add("&LeftTriangleEqual;", "\u22B4");
            htmlEntityMap.Add("&LeftUpDownVector;", "\u2951");
            htmlEntityMap.Add("&LeftUpTeeVector;", "\u2960");
            htmlEntityMap.Add("&LeftUpVectorBar;", "\u2958");
            htmlEntityMap.Add("&LeftUpVector;", "\u21BF");
            htmlEntityMap.Add("&LeftVectorBar;", "\u2952");
            htmlEntityMap.Add("&LeftVector;", "\u21BC");
            htmlEntityMap.Add("&lEg;", "\u2A8B");
            htmlEntityMap.Add("&leg;", "\u22DA");
            htmlEntityMap.Add("&leq;", "\u2264");
            htmlEntityMap.Add("&leqq;", "\u2266");
            htmlEntityMap.Add("&leqslant;", "\u2A7D");
            htmlEntityMap.Add("&lescc;", "\u2AA8");
            htmlEntityMap.Add("&les;", "\u2A7D");
            htmlEntityMap.Add("&lesdot;", "\u2A7F");
            htmlEntityMap.Add("&lesdoto;", "\u2A81");
            htmlEntityMap.Add("&lesdotor;", "\u2A83");
            htmlEntityMap.Add("&lesg;", "\u22DA\uFE00");
            htmlEntityMap.Add("&lesges;", "\u2A93");
            htmlEntityMap.Add("&lessapprox;", "\u2A85");
            htmlEntityMap.Add("&lessdot;", "\u22D6");
            htmlEntityMap.Add("&lesseqgtr;", "\u22DA");
            htmlEntityMap.Add("&lesseqqgtr;", "\u2A8B");
            htmlEntityMap.Add("&LessEqualGreater;", "\u22DA");
            htmlEntityMap.Add("&LessFullEqual;", "\u2266");
            htmlEntityMap.Add("&LessGreater;", "\u2276");
            htmlEntityMap.Add("&lessgtr;", "\u2276");
            htmlEntityMap.Add("&LessLess;", "\u2AA1");
            htmlEntityMap.Add("&lesssim;", "\u2272");
            htmlEntityMap.Add("&LessSlantEqual;", "\u2A7D");
            htmlEntityMap.Add("&LessTilde;", "\u2272");
            htmlEntityMap.Add("&lfisht;", "\u297C");
            htmlEntityMap.Add("&lfloor;", "\u230A");
            htmlEntityMap.Add("&Lfr;", "\uD835\uDD0F");
            htmlEntityMap.Add("&lfr;", "\uD835\uDD29");
            htmlEntityMap.Add("&lg;", "\u2276");
            htmlEntityMap.Add("&lgE;", "\u2A91");
            htmlEntityMap.Add("&lHar;", "\u2962");
            htmlEntityMap.Add("&lhard;", "\u21BD");
            htmlEntityMap.Add("&lharu;", "\u21BC");
            htmlEntityMap.Add("&lharul;", "\u296A");
            htmlEntityMap.Add("&lhblk;", "\u2584");
            htmlEntityMap.Add("&LJcy;", "\u0409");
            htmlEntityMap.Add("&ljcy;", "\u0459");
            htmlEntityMap.Add("&llarr;", "\u21C7");
            htmlEntityMap.Add("&ll;", "\u226A");
            htmlEntityMap.Add("&Ll;", "\u22D8");
            htmlEntityMap.Add("&llcorner;", "\u231E");
            htmlEntityMap.Add("&Lleftarrow;", "\u21DA");
            htmlEntityMap.Add("&llhard;", "\u296B");
            htmlEntityMap.Add("&lltri;", "\u25FA");
            htmlEntityMap.Add("&Lmidot;", "\u013F");
            htmlEntityMap.Add("&lmidot;", "\u0140");
            htmlEntityMap.Add("&lmoustache;", "\u23B0");
            htmlEntityMap.Add("&lmoust;", "\u23B0");
            htmlEntityMap.Add("&lnap;", "\u2A89");
            htmlEntityMap.Add("&lnapprox;", "\u2A89");
            htmlEntityMap.Add("&lne;", "\u2A87");
            htmlEntityMap.Add("&lnE;", "\u2268");
            htmlEntityMap.Add("&lneq;", "\u2A87");
            htmlEntityMap.Add("&lneqq;", "\u2268");
            htmlEntityMap.Add("&lnsim;", "\u22E6");
            htmlEntityMap.Add("&loang;", "\u27EC");
            htmlEntityMap.Add("&loarr;", "\u21FD");
            htmlEntityMap.Add("&lobrk;", "\u27E6");
            htmlEntityMap.Add("&longleftarrow;", "\u27F5");
            htmlEntityMap.Add("&LongLeftArrow;", "\u27F5");
            htmlEntityMap.Add("&Longleftarrow;", "\u27F8");
            htmlEntityMap.Add("&longleftrightarrow;", "\u27F7");
            htmlEntityMap.Add("&LongLeftRightArrow;", "\u27F7");
            htmlEntityMap.Add("&Longleftrightarrow;", "\u27FA");
            htmlEntityMap.Add("&longmapsto;", "\u27FC");
            htmlEntityMap.Add("&longrightarrow;", "\u27F6");
            htmlEntityMap.Add("&LongRightArrow;", "\u27F6");
            htmlEntityMap.Add("&Longrightarrow;", "\u27F9");
            htmlEntityMap.Add("&looparrowleft;", "\u21AB");
            htmlEntityMap.Add("&looparrowright;", "\u21AC");
            htmlEntityMap.Add("&lopar;", "\u2985");
            htmlEntityMap.Add("&Lopf;", "\uD835\uDD43");
            htmlEntityMap.Add("&lopf;", "\uD835\uDD5D");
            htmlEntityMap.Add("&loplus;", "\u2A2D");
            htmlEntityMap.Add("&lotimes;", "\u2A34");
            htmlEntityMap.Add("&lowast;", "\u2217");
            htmlEntityMap.Add("&lowbar;", "\u005F");
            htmlEntityMap.Add("&LowerLeftArrow;", "\u2199");
            htmlEntityMap.Add("&LowerRightArrow;", "\u2198");
            htmlEntityMap.Add("&loz;", "\u25CA");
            htmlEntityMap.Add("&lozenge;", "\u25CA");
            htmlEntityMap.Add("&lozf;", "\u29EB");
            htmlEntityMap.Add("&lpar;", "\u0028");
            htmlEntityMap.Add("&lparlt;", "\u2993");
            htmlEntityMap.Add("&lrarr;", "\u21C6");
            htmlEntityMap.Add("&lrcorner;", "\u231F");
            htmlEntityMap.Add("&lrhar;", "\u21CB");
            htmlEntityMap.Add("&lrhard;", "\u296D");
            htmlEntityMap.Add("&lrm;", "\u200E");
            htmlEntityMap.Add("&lrtri;", "\u22BF");
            htmlEntityMap.Add("&lsaquo;", "\u2039");
            htmlEntityMap.Add("&lscr;", "\uD835\uDCC1");
            htmlEntityMap.Add("&Lscr;", "\u2112");
            htmlEntityMap.Add("&lsh;", "\u21B0");
            htmlEntityMap.Add("&Lsh;", "\u21B0");
            htmlEntityMap.Add("&lsim;", "\u2272");
            htmlEntityMap.Add("&lsime;", "\u2A8D");
            htmlEntityMap.Add("&lsimg;", "\u2A8F");
            htmlEntityMap.Add("&lsqb;", "\u005B");
            htmlEntityMap.Add("&lsquo;", "\u2018");
            htmlEntityMap.Add("&lsquor;", "\u201A");
            htmlEntityMap.Add("&Lstrok;", "\u0141");
            htmlEntityMap.Add("&lstrok;", "\u0142");
            htmlEntityMap.Add("&ltcc;", "\u2AA6");
            htmlEntityMap.Add("&ltcir;", "\u2A79");
            htmlEntityMap.Add("&lt;", "\u003C");
            htmlEntityMap.Add("&lt", "\u003C");
            htmlEntityMap.Add("&LT;", "\u003C");
            htmlEntityMap.Add("&LT", "\u003C");
            htmlEntityMap.Add("&Lt;", "\u226A");
            htmlEntityMap.Add("&ltdot;", "\u22D6");
            htmlEntityMap.Add("&lthree;", "\u22CB");
            htmlEntityMap.Add("&ltimes;", "\u22C9");
            htmlEntityMap.Add("&ltlarr;", "\u2976");
            htmlEntityMap.Add("&ltquest;", "\u2A7B");
            htmlEntityMap.Add("&ltri;", "\u25C3");
            htmlEntityMap.Add("&ltrie;", "\u22B4");
            htmlEntityMap.Add("&ltrif;", "\u25C2");
            htmlEntityMap.Add("&ltrPar;", "\u2996");
            htmlEntityMap.Add("&lurdshar;", "\u294A");
            htmlEntityMap.Add("&luruhar;", "\u2966");
            htmlEntityMap.Add("&lvertneqq;", "\u2268\uFE00");
            htmlEntityMap.Add("&lvnE;", "\u2268\uFE00");
            htmlEntityMap.Add("&macr;", "\u00AF");
            htmlEntityMap.Add("&macr", "\u00AF");
            htmlEntityMap.Add("&male;", "\u2642");
            htmlEntityMap.Add("&malt;", "\u2720");
            htmlEntityMap.Add("&maltese;", "\u2720");
            htmlEntityMap.Add("&Map;", "\u2905");
            htmlEntityMap.Add("&map;", "\u21A6");
            htmlEntityMap.Add("&mapsto;", "\u21A6");
            htmlEntityMap.Add("&mapstodown;", "\u21A7");
            htmlEntityMap.Add("&mapstoleft;", "\u21A4");
            htmlEntityMap.Add("&mapstoup;", "\u21A5");
            htmlEntityMap.Add("&marker;", "\u25AE");
            htmlEntityMap.Add("&mcomma;", "\u2A29");
            htmlEntityMap.Add("&Mcy;", "\u041C");
            htmlEntityMap.Add("&mcy;", "\u043C");
            htmlEntityMap.Add("&mdash;", "\u2014");
            htmlEntityMap.Add("&mDDot;", "\u223A");
            htmlEntityMap.Add("&measuredangle;", "\u2221");
            htmlEntityMap.Add("&MediumSpace;", "\u205F");
            htmlEntityMap.Add("&Mellintrf;", "\u2133");
            htmlEntityMap.Add("&Mfr;", "\uD835\uDD10");
            htmlEntityMap.Add("&mfr;", "\uD835\uDD2A");
            htmlEntityMap.Add("&mho;", "\u2127");
            htmlEntityMap.Add("&micro;", "\u00B5");
            htmlEntityMap.Add("&micro", "\u00B5");
            htmlEntityMap.Add("&midast;", "\u002A");
            htmlEntityMap.Add("&midcir;", "\u2AF0");
            htmlEntityMap.Add("&mid;", "\u2223");
            htmlEntityMap.Add("&middot;", "\u00B7");
            htmlEntityMap.Add("&middot", "\u00B7");
            htmlEntityMap.Add("&minusb;", "\u229F");
            htmlEntityMap.Add("&minus;", "\u2212");
            htmlEntityMap.Add("&minusd;", "\u2238");
            htmlEntityMap.Add("&minusdu;", "\u2A2A");
            htmlEntityMap.Add("&MinusPlus;", "\u2213");
            htmlEntityMap.Add("&mlcp;", "\u2ADB");
            htmlEntityMap.Add("&mldr;", "\u2026");
            htmlEntityMap.Add("&mnplus;", "\u2213");
            htmlEntityMap.Add("&models;", "\u22A7");
            htmlEntityMap.Add("&Mopf;", "\uD835\uDD44");
            htmlEntityMap.Add("&mopf;", "\uD835\uDD5E");
            htmlEntityMap.Add("&mp;", "\u2213");
            htmlEntityMap.Add("&mscr;", "\uD835\uDCC2");
            htmlEntityMap.Add("&Mscr;", "\u2133");
            htmlEntityMap.Add("&mstpos;", "\u223E");
            htmlEntityMap.Add("&Mu;", "\u039C");
            htmlEntityMap.Add("&mu;", "\u03BC");
            htmlEntityMap.Add("&multimap;", "\u22B8");
            htmlEntityMap.Add("&mumap;", "\u22B8");
            htmlEntityMap.Add("&nabla;", "\u2207");
            htmlEntityMap.Add("&Nacute;", "\u0143");
            htmlEntityMap.Add("&nacute;", "\u0144");
            htmlEntityMap.Add("&nang;", "\u2220\u20D2");
            htmlEntityMap.Add("&nap;", "\u2249");
            htmlEntityMap.Add("&napE;", "\u2A70\u0338");
            htmlEntityMap.Add("&napid;", "\u224B\u0338");
            htmlEntityMap.Add("&napos;", "\u0149");
            htmlEntityMap.Add("&napprox;", "\u2249");
            htmlEntityMap.Add("&natural;", "\u266E");
            htmlEntityMap.Add("&naturals;", "\u2115");
            htmlEntityMap.Add("&natur;", "\u266E");
            htmlEntityMap.Add("&nbsp;", "\u00A0");
            htmlEntityMap.Add("&nbsp", "\u00A0");
            htmlEntityMap.Add("&nbump;", "\u224E\u0338");
            htmlEntityMap.Add("&nbumpe;", "\u224F\u0338");
            htmlEntityMap.Add("&ncap;", "\u2A43");
            htmlEntityMap.Add("&Ncaron;", "\u0147");
            htmlEntityMap.Add("&ncaron;", "\u0148");
            htmlEntityMap.Add("&Ncedil;", "\u0145");
            htmlEntityMap.Add("&ncedil;", "\u0146");
            htmlEntityMap.Add("&ncong;", "\u2247");
            htmlEntityMap.Add("&ncongdot;", "\u2A6D\u0338");
            htmlEntityMap.Add("&ncup;", "\u2A42");
            htmlEntityMap.Add("&Ncy;", "\u041D");
            htmlEntityMap.Add("&ncy;", "\u043D");
            htmlEntityMap.Add("&ndash;", "\u2013");
            htmlEntityMap.Add("&nearhk;", "\u2924");
            htmlEntityMap.Add("&nearr;", "\u2197");
            htmlEntityMap.Add("&neArr;", "\u21D7");
            htmlEntityMap.Add("&nearrow;", "\u2197");
            htmlEntityMap.Add("&ne;", "\u2260");
            htmlEntityMap.Add("&nedot;", "\u2250\u0338");
            htmlEntityMap.Add("&NegativeMediumSpace;", "\u200B");
            htmlEntityMap.Add("&NegativeThickSpace;", "\u200B");
            htmlEntityMap.Add("&NegativeThinSpace;", "\u200B");
            htmlEntityMap.Add("&NegativeVeryThinSpace;", "\u200B");
            htmlEntityMap.Add("&nequiv;", "\u2262");
            htmlEntityMap.Add("&nesear;", "\u2928");
            htmlEntityMap.Add("&nesim;", "\u2242\u0338");
            htmlEntityMap.Add("&NestedGreaterGreater;", "\u226B");
            htmlEntityMap.Add("&NestedLessLess;", "\u226A");
            htmlEntityMap.Add("&NewLine;", "\u000A");
            htmlEntityMap.Add("&nexist;", "\u2204");
            htmlEntityMap.Add("&nexists;", "\u2204");
            htmlEntityMap.Add("&Nfr;", "\uD835\uDD11");
            htmlEntityMap.Add("&nfr;", "\uD835\uDD2B");
            htmlEntityMap.Add("&ngE;", "\u2267\u0338");
            htmlEntityMap.Add("&nge;", "\u2271");
            htmlEntityMap.Add("&ngeq;", "\u2271");
            htmlEntityMap.Add("&ngeqq;", "\u2267\u0338");
            htmlEntityMap.Add("&ngeqslant;", "\u2A7E\u0338");
            htmlEntityMap.Add("&nges;", "\u2A7E\u0338");
            htmlEntityMap.Add("&nGg;", "\u22D9\u0338");
            htmlEntityMap.Add("&ngsim;", "\u2275");
            htmlEntityMap.Add("&nGt;", "\u226B\u20D2");
            htmlEntityMap.Add("&ngt;", "\u226F");
            htmlEntityMap.Add("&ngtr;", "\u226F");
            htmlEntityMap.Add("&nGtv;", "\u226B\u0338");
            htmlEntityMap.Add("&nharr;", "\u21AE");
            htmlEntityMap.Add("&nhArr;", "\u21CE");
            htmlEntityMap.Add("&nhpar;", "\u2AF2");
            htmlEntityMap.Add("&ni;", "\u220B");
            htmlEntityMap.Add("&nis;", "\u22FC");
            htmlEntityMap.Add("&nisd;", "\u22FA");
            htmlEntityMap.Add("&niv;", "\u220B");
            htmlEntityMap.Add("&NJcy;", "\u040A");
            htmlEntityMap.Add("&njcy;", "\u045A");
            htmlEntityMap.Add("&nlarr;", "\u219A");
            htmlEntityMap.Add("&nlArr;", "\u21CD");
            htmlEntityMap.Add("&nldr;", "\u2025");
            htmlEntityMap.Add("&nlE;", "\u2266\u0338");
            htmlEntityMap.Add("&nle;", "\u2270");
            htmlEntityMap.Add("&nleftarrow;", "\u219A");
            htmlEntityMap.Add("&nLeftarrow;", "\u21CD");
            htmlEntityMap.Add("&nleftrightarrow;", "\u21AE");
            htmlEntityMap.Add("&nLeftrightarrow;", "\u21CE");
            htmlEntityMap.Add("&nleq;", "\u2270");
            htmlEntityMap.Add("&nleqq;", "\u2266\u0338");
            htmlEntityMap.Add("&nleqslant;", "\u2A7D\u0338");
            htmlEntityMap.Add("&nles;", "\u2A7D\u0338");
            htmlEntityMap.Add("&nless;", "\u226E");
            htmlEntityMap.Add("&nLl;", "\u22D8\u0338");
            htmlEntityMap.Add("&nlsim;", "\u2274");
            htmlEntityMap.Add("&nLt;", "\u226A\u20D2");
            htmlEntityMap.Add("&nlt;", "\u226E");
            htmlEntityMap.Add("&nltri;", "\u22EA");
            htmlEntityMap.Add("&nltrie;", "\u22EC");
            htmlEntityMap.Add("&nLtv;", "\u226A\u0338");
            htmlEntityMap.Add("&nmid;", "\u2224");
            htmlEntityMap.Add("&NoBreak;", "\u2060");
            htmlEntityMap.Add("&NonBreakingSpace;", "\u00A0");
            htmlEntityMap.Add("&nopf;", "\uD835\uDD5F");
            htmlEntityMap.Add("&Nopf;", "\u2115");
            htmlEntityMap.Add("&Not;", "\u2AEC");
            htmlEntityMap.Add("&not;", "\u00AC");
            htmlEntityMap.Add("&not", "\u00AC");
            htmlEntityMap.Add("&NotCongruent;", "\u2262");
            htmlEntityMap.Add("&NotCupCap;", "\u226D");
            htmlEntityMap.Add("&NotDoubleVerticalBar;", "\u2226");
            htmlEntityMap.Add("&NotElement;", "\u2209");
            htmlEntityMap.Add("&NotEqual;", "\u2260");
            htmlEntityMap.Add("&NotEqualTilde;", "\u2242\u0338");
            htmlEntityMap.Add("&NotExists;", "\u2204");
            htmlEntityMap.Add("&NotGreater;", "\u226F");
            htmlEntityMap.Add("&NotGreaterEqual;", "\u2271");
            htmlEntityMap.Add("&NotGreaterFullEqual;", "\u2267\u0338");
            htmlEntityMap.Add("&NotGreaterGreater;", "\u226B\u0338");
            htmlEntityMap.Add("&NotGreaterLess;", "\u2279");
            htmlEntityMap.Add("&NotGreaterSlantEqual;", "\u2A7E\u0338");
            htmlEntityMap.Add("&NotGreaterTilde;", "\u2275");
            htmlEntityMap.Add("&NotHumpDownHump;", "\u224E\u0338");
            htmlEntityMap.Add("&NotHumpEqual;", "\u224F\u0338");
            htmlEntityMap.Add("&notin;", "\u2209");
            htmlEntityMap.Add("&notindot;", "\u22F5\u0338");
            htmlEntityMap.Add("&notinE;", "\u22F9\u0338");
            htmlEntityMap.Add("&notinva;", "\u2209");
            htmlEntityMap.Add("&notinvb;", "\u22F7");
            htmlEntityMap.Add("&notinvc;", "\u22F6");
            htmlEntityMap.Add("&NotLeftTriangleBar;", "\u29CF\u0338");
            htmlEntityMap.Add("&NotLeftTriangle;", "\u22EA");
            htmlEntityMap.Add("&NotLeftTriangleEqual;", "\u22EC");
            htmlEntityMap.Add("&NotLess;", "\u226E");
            htmlEntityMap.Add("&NotLessEqual;", "\u2270");
            htmlEntityMap.Add("&NotLessGreater;", "\u2278");
            htmlEntityMap.Add("&NotLessLess;", "\u226A\u0338");
            htmlEntityMap.Add("&NotLessSlantEqual;", "\u2A7D\u0338");
            htmlEntityMap.Add("&NotLessTilde;", "\u2274");
            htmlEntityMap.Add("&NotNestedGreaterGreater;", "\u2AA2\u0338");
            htmlEntityMap.Add("&NotNestedLessLess;", "\u2AA1\u0338");
            htmlEntityMap.Add("&notni;", "\u220C");
            htmlEntityMap.Add("&notniva;", "\u220C");
            htmlEntityMap.Add("&notnivb;", "\u22FE");
            htmlEntityMap.Add("&notnivc;", "\u22FD");
            htmlEntityMap.Add("&NotPrecedes;", "\u2280");
            htmlEntityMap.Add("&NotPrecedesEqual;", "\u2AAF\u0338");
            htmlEntityMap.Add("&NotPrecedesSlantEqual;", "\u22E0");
            htmlEntityMap.Add("&NotReverseElement;", "\u220C");
            htmlEntityMap.Add("&NotRightTriangleBar;", "\u29D0\u0338");
            htmlEntityMap.Add("&NotRightTriangle;", "\u22EB");
            htmlEntityMap.Add("&NotRightTriangleEqual;", "\u22ED");
            htmlEntityMap.Add("&NotSquareSubset;", "\u228F\u0338");
            htmlEntityMap.Add("&NotSquareSubsetEqual;", "\u22E2");
            htmlEntityMap.Add("&NotSquareSuperset;", "\u2290\u0338");
            htmlEntityMap.Add("&NotSquareSupersetEqual;", "\u22E3");
            htmlEntityMap.Add("&NotSubset;", "\u2282\u20D2");
            htmlEntityMap.Add("&NotSubsetEqual;", "\u2288");
            htmlEntityMap.Add("&NotSucceeds;", "\u2281");
            htmlEntityMap.Add("&NotSucceedsEqual;", "\u2AB0\u0338");
            htmlEntityMap.Add("&NotSucceedsSlantEqual;", "\u22E1");
            htmlEntityMap.Add("&NotSucceedsTilde;", "\u227F\u0338");
            htmlEntityMap.Add("&NotSuperset;", "\u2283\u20D2");
            htmlEntityMap.Add("&NotSupersetEqual;", "\u2289");
            htmlEntityMap.Add("&NotTilde;", "\u2241");
            htmlEntityMap.Add("&NotTildeEqual;", "\u2244");
            htmlEntityMap.Add("&NotTildeFullEqual;", "\u2247");
            htmlEntityMap.Add("&NotTildeTilde;", "\u2249");
            htmlEntityMap.Add("&NotVerticalBar;", "\u2224");
            htmlEntityMap.Add("&nparallel;", "\u2226");
            htmlEntityMap.Add("&npar;", "\u2226");
            htmlEntityMap.Add("&nparsl;", "\u2AFD\u20E5");
            htmlEntityMap.Add("&npart;", "\u2202\u0338");
            htmlEntityMap.Add("&npolint;", "\u2A14");
            htmlEntityMap.Add("&npr;", "\u2280");
            htmlEntityMap.Add("&nprcue;", "\u22E0");
            htmlEntityMap.Add("&nprec;", "\u2280");
            htmlEntityMap.Add("&npreceq;", "\u2AAF\u0338");
            htmlEntityMap.Add("&npre;", "\u2AAF\u0338");
            htmlEntityMap.Add("&nrarrc;", "\u2933\u0338");
            htmlEntityMap.Add("&nrarr;", "\u219B");
            htmlEntityMap.Add("&nrArr;", "\u21CF");
            htmlEntityMap.Add("&nrarrw;", "\u219D\u0338");
            htmlEntityMap.Add("&nrightarrow;", "\u219B");
            htmlEntityMap.Add("&nRightarrow;", "\u21CF");
            htmlEntityMap.Add("&nrtri;", "\u22EB");
            htmlEntityMap.Add("&nrtrie;", "\u22ED");
            htmlEntityMap.Add("&nsc;", "\u2281");
            htmlEntityMap.Add("&nsccue;", "\u22E1");
            htmlEntityMap.Add("&nsce;", "\u2AB0\u0338");
            htmlEntityMap.Add("&Nscr;", "\uD835\uDCA9");
            htmlEntityMap.Add("&nscr;", "\uD835\uDCC3");
            htmlEntityMap.Add("&nshortmid;", "\u2224");
            htmlEntityMap.Add("&nshortparallel;", "\u2226");
            htmlEntityMap.Add("&nsim;", "\u2241");
            htmlEntityMap.Add("&nsime;", "\u2244");
            htmlEntityMap.Add("&nsimeq;", "\u2244");
            htmlEntityMap.Add("&nsmid;", "\u2224");
            htmlEntityMap.Add("&nspar;", "\u2226");
            htmlEntityMap.Add("&nsqsube;", "\u22E2");
            htmlEntityMap.Add("&nsqsupe;", "\u22E3");
            htmlEntityMap.Add("&nsub;", "\u2284");
            htmlEntityMap.Add("&nsubE;", "\u2AC5\u0338");
            htmlEntityMap.Add("&nsube;", "\u2288");
            htmlEntityMap.Add("&nsubset;", "\u2282\u20D2");
            htmlEntityMap.Add("&nsubseteq;", "\u2288");
            htmlEntityMap.Add("&nsubseteqq;", "\u2AC5\u0338");
            htmlEntityMap.Add("&nsucc;", "\u2281");
            htmlEntityMap.Add("&nsucceq;", "\u2AB0\u0338");
            htmlEntityMap.Add("&nsup;", "\u2285");
            htmlEntityMap.Add("&nsupE;", "\u2AC6\u0338");
            htmlEntityMap.Add("&nsupe;", "\u2289");
            htmlEntityMap.Add("&nsupset;", "\u2283\u20D2");
            htmlEntityMap.Add("&nsupseteq;", "\u2289");
            htmlEntityMap.Add("&nsupseteqq;", "\u2AC6\u0338");
            htmlEntityMap.Add("&ntgl;", "\u2279");
            htmlEntityMap.Add("&Ntilde;", "\u00D1");
            htmlEntityMap.Add("&Ntilde", "\u00D1");
            htmlEntityMap.Add("&ntilde;", "\u00F1");
            htmlEntityMap.Add("&ntilde", "\u00F1");
            htmlEntityMap.Add("&ntlg;", "\u2278");
            htmlEntityMap.Add("&ntriangleleft;", "\u22EA");
            htmlEntityMap.Add("&ntrianglelefteq;", "\u22EC");
            htmlEntityMap.Add("&ntriangleright;", "\u22EB");
            htmlEntityMap.Add("&ntrianglerighteq;", "\u22ED");
            htmlEntityMap.Add("&Nu;", "\u039D");
            htmlEntityMap.Add("&nu;", "\u03BD");
            htmlEntityMap.Add("&num;", "\u0023");
            htmlEntityMap.Add("&numero;", "\u2116");
            htmlEntityMap.Add("&numsp;", "\u2007");
            htmlEntityMap.Add("&nvap;", "\u224D\u20D2");
            htmlEntityMap.Add("&nvdash;", "\u22AC");
            htmlEntityMap.Add("&nvDash;", "\u22AD");
            htmlEntityMap.Add("&nVdash;", "\u22AE");
            htmlEntityMap.Add("&nVDash;", "\u22AF");
            htmlEntityMap.Add("&nvge;", "\u2265\u20D2");
            htmlEntityMap.Add("&nvgt;", "\u003E\u20D2");
            htmlEntityMap.Add("&nvHarr;", "\u2904");
            htmlEntityMap.Add("&nvinfin;", "\u29DE");
            htmlEntityMap.Add("&nvlArr;", "\u2902");
            htmlEntityMap.Add("&nvle;", "\u2264\u20D2");
            htmlEntityMap.Add("&nvlt;", "\u003C\u20D2");
            htmlEntityMap.Add("&nvltrie;", "\u22B4\u20D2");
            htmlEntityMap.Add("&nvrArr;", "\u2903");
            htmlEntityMap.Add("&nvrtrie;", "\u22B5\u20D2");
            htmlEntityMap.Add("&nvsim;", "\u223C\u20D2");
            htmlEntityMap.Add("&nwarhk;", "\u2923");
            htmlEntityMap.Add("&nwarr;", "\u2196");
            htmlEntityMap.Add("&nwArr;", "\u21D6");
            htmlEntityMap.Add("&nwarrow;", "\u2196");
            htmlEntityMap.Add("&nwnear;", "\u2927");
            htmlEntityMap.Add("&Oacute;", "\u00D3");
            htmlEntityMap.Add("&Oacute", "\u00D3");
            htmlEntityMap.Add("&oacute;", "\u00F3");
            htmlEntityMap.Add("&oacute", "\u00F3");
            htmlEntityMap.Add("&oast;", "\u229B");
            htmlEntityMap.Add("&Ocirc;", "\u00D4");
            htmlEntityMap.Add("&Ocirc", "\u00D4");
            htmlEntityMap.Add("&ocirc;", "\u00F4");
            htmlEntityMap.Add("&ocirc", "\u00F4");
            htmlEntityMap.Add("&ocir;", "\u229A");
            htmlEntityMap.Add("&Ocy;", "\u041E");
            htmlEntityMap.Add("&ocy;", "\u043E");
            htmlEntityMap.Add("&odash;", "\u229D");
            htmlEntityMap.Add("&Odblac;", "\u0150");
            htmlEntityMap.Add("&odblac;", "\u0151");
            htmlEntityMap.Add("&odiv;", "\u2A38");
            htmlEntityMap.Add("&odot;", "\u2299");
            htmlEntityMap.Add("&odsold;", "\u29BC");
            htmlEntityMap.Add("&OElig;", "\u0152");
            htmlEntityMap.Add("&oelig;", "\u0153");
            htmlEntityMap.Add("&ofcir;", "\u29BF");
            htmlEntityMap.Add("&Ofr;", "\uD835\uDD12");
            htmlEntityMap.Add("&ofr;", "\uD835\uDD2C");
            htmlEntityMap.Add("&ogon;", "\u02DB");
            htmlEntityMap.Add("&Ograve;", "\u00D2");
            htmlEntityMap.Add("&Ograve", "\u00D2");
            htmlEntityMap.Add("&ograve;", "\u00F2");
            htmlEntityMap.Add("&ograve", "\u00F2");
            htmlEntityMap.Add("&ogt;", "\u29C1");
            htmlEntityMap.Add("&ohbar;", "\u29B5");
            htmlEntityMap.Add("&ohm;", "\u03A9");
            htmlEntityMap.Add("&oint;", "\u222E");
            htmlEntityMap.Add("&olarr;", "\u21BA");
            htmlEntityMap.Add("&olcir;", "\u29BE");
            htmlEntityMap.Add("&olcross;", "\u29BB");
            htmlEntityMap.Add("&oline;", "\u203E");
            htmlEntityMap.Add("&olt;", "\u29C0");
            htmlEntityMap.Add("&Omacr;", "\u014C");
            htmlEntityMap.Add("&omacr;", "\u014D");
            htmlEntityMap.Add("&Omega;", "\u03A9");
            htmlEntityMap.Add("&omega;", "\u03C9");
            htmlEntityMap.Add("&Omicron;", "\u039F");
            htmlEntityMap.Add("&omicron;", "\u03BF");
            htmlEntityMap.Add("&omid;", "\u29B6");
            htmlEntityMap.Add("&ominus;", "\u2296");
            htmlEntityMap.Add("&Oopf;", "\uD835\uDD46");
            htmlEntityMap.Add("&oopf;", "\uD835\uDD60");
            htmlEntityMap.Add("&opar;", "\u29B7");
            htmlEntityMap.Add("&OpenCurlyDoubleQuote;", "\u201C");
            htmlEntityMap.Add("&OpenCurlyQuote;", "\u2018");
            htmlEntityMap.Add("&operp;", "\u29B9");
            htmlEntityMap.Add("&oplus;", "\u2295");
            htmlEntityMap.Add("&orarr;", "\u21BB");
            htmlEntityMap.Add("&Or;", "\u2A54");
            htmlEntityMap.Add("&or;", "\u2228");
            htmlEntityMap.Add("&ord;", "\u2A5D");
            htmlEntityMap.Add("&order;", "\u2134");
            htmlEntityMap.Add("&orderof;", "\u2134");
            htmlEntityMap.Add("&ordf;", "\u00AA");
            htmlEntityMap.Add("&ordf", "\u00AA");
            htmlEntityMap.Add("&ordm;", "\u00BA");
            htmlEntityMap.Add("&ordm", "\u00BA");
            htmlEntityMap.Add("&origof;", "\u22B6");
            htmlEntityMap.Add("&oror;", "\u2A56");
            htmlEntityMap.Add("&orslope;", "\u2A57");
            htmlEntityMap.Add("&orv;", "\u2A5B");
            htmlEntityMap.Add("&oS;", "\u24C8");
            htmlEntityMap.Add("&Oscr;", "\uD835\uDCAA");
            htmlEntityMap.Add("&oscr;", "\u2134");
            htmlEntityMap.Add("&Oslash;", "\u00D8");
            htmlEntityMap.Add("&Oslash", "\u00D8");
            htmlEntityMap.Add("&oslash;", "\u00F8");
            htmlEntityMap.Add("&oslash", "\u00F8");
            htmlEntityMap.Add("&osol;", "\u2298");
            htmlEntityMap.Add("&Otilde;", "\u00D5");
            htmlEntityMap.Add("&Otilde", "\u00D5");
            htmlEntityMap.Add("&otilde;", "\u00F5");
            htmlEntityMap.Add("&otilde", "\u00F5");
            htmlEntityMap.Add("&otimesas;", "\u2A36");
            htmlEntityMap.Add("&Otimes;", "\u2A37");
            htmlEntityMap.Add("&otimes;", "\u2297");
            htmlEntityMap.Add("&Ouml;", "\u00D6");
            htmlEntityMap.Add("&Ouml", "\u00D6");
            htmlEntityMap.Add("&ouml;", "\u00F6");
            htmlEntityMap.Add("&ouml", "\u00F6");
            htmlEntityMap.Add("&ovbar;", "\u233D");
            htmlEntityMap.Add("&OverBar;", "\u203E");
            htmlEntityMap.Add("&OverBrace;", "\u23DE");
            htmlEntityMap.Add("&OverBracket;", "\u23B4");
            htmlEntityMap.Add("&OverParenthesis;", "\u23DC");
            htmlEntityMap.Add("&para;", "\u00B6");
            htmlEntityMap.Add("&para", "\u00B6");
            htmlEntityMap.Add("&parallel;", "\u2225");
            htmlEntityMap.Add("&par;", "\u2225");
            htmlEntityMap.Add("&parsim;", "\u2AF3");
            htmlEntityMap.Add("&parsl;", "\u2AFD");
            htmlEntityMap.Add("&part;", "\u2202");
            htmlEntityMap.Add("&PartialD;", "\u2202");
            htmlEntityMap.Add("&Pcy;", "\u041F");
            htmlEntityMap.Add("&pcy;", "\u043F");
            htmlEntityMap.Add("&percnt;", "\u0025");
            htmlEntityMap.Add("&period;", "\u002E");
            htmlEntityMap.Add("&permil;", "\u2030");
            htmlEntityMap.Add("&perp;", "\u22A5");
            htmlEntityMap.Add("&pertenk;", "\u2031");
            htmlEntityMap.Add("&Pfr;", "\uD835\uDD13");
            htmlEntityMap.Add("&pfr;", "\uD835\uDD2D");
            htmlEntityMap.Add("&Phi;", "\u03A6");
            htmlEntityMap.Add("&phi;", "\u03C6");
            htmlEntityMap.Add("&phiv;", "\u03D5");
            htmlEntityMap.Add("&phmmat;", "\u2133");
            htmlEntityMap.Add("&phone;", "\u260E");
            htmlEntityMap.Add("&Pi;", "\u03A0");
            htmlEntityMap.Add("&pi;", "\u03C0");
            htmlEntityMap.Add("&pitchfork;", "\u22D4");
            htmlEntityMap.Add("&piv;", "\u03D6");
            htmlEntityMap.Add("&planck;", "\u210F");
            htmlEntityMap.Add("&planckh;", "\u210E");
            htmlEntityMap.Add("&plankv;", "\u210F");
            htmlEntityMap.Add("&plusacir;", "\u2A23");
            htmlEntityMap.Add("&plusb;", "\u229E");
            htmlEntityMap.Add("&pluscir;", "\u2A22");
            htmlEntityMap.Add("&plus;", "\u002B");
            htmlEntityMap.Add("&plusdo;", "\u2214");
            htmlEntityMap.Add("&plusdu;", "\u2A25");
            htmlEntityMap.Add("&pluse;", "\u2A72");
            htmlEntityMap.Add("&PlusMinus;", "\u00B1");
            htmlEntityMap.Add("&plusmn;", "\u00B1");
            htmlEntityMap.Add("&plusmn", "\u00B1");
            htmlEntityMap.Add("&plussim;", "\u2A26");
            htmlEntityMap.Add("&plustwo;", "\u2A27");
            htmlEntityMap.Add("&pm;", "\u00B1");
            htmlEntityMap.Add("&Poincareplane;", "\u210C");
            htmlEntityMap.Add("&pointint;", "\u2A15");
            htmlEntityMap.Add("&popf;", "\uD835\uDD61");
            htmlEntityMap.Add("&Popf;", "\u2119");
            htmlEntityMap.Add("&pound;", "\u00A3");
            htmlEntityMap.Add("&pound", "\u00A3");
            htmlEntityMap.Add("&prap;", "\u2AB7");
            htmlEntityMap.Add("&Pr;", "\u2ABB");
            htmlEntityMap.Add("&pr;", "\u227A");
            htmlEntityMap.Add("&prcue;", "\u227C");
            htmlEntityMap.Add("&precapprox;", "\u2AB7");
            htmlEntityMap.Add("&prec;", "\u227A");
            htmlEntityMap.Add("&preccurlyeq;", "\u227C");
            htmlEntityMap.Add("&Precedes;", "\u227A");
            htmlEntityMap.Add("&PrecedesEqual;", "\u2AAF");
            htmlEntityMap.Add("&PrecedesSlantEqual;", "\u227C");
            htmlEntityMap.Add("&PrecedesTilde;", "\u227E");
            htmlEntityMap.Add("&preceq;", "\u2AAF");
            htmlEntityMap.Add("&precnapprox;", "\u2AB9");
            htmlEntityMap.Add("&precneqq;", "\u2AB5");
            htmlEntityMap.Add("&precnsim;", "\u22E8");
            htmlEntityMap.Add("&pre;", "\u2AAF");
            htmlEntityMap.Add("&prE;", "\u2AB3");
            htmlEntityMap.Add("&precsim;", "\u227E");
            htmlEntityMap.Add("&prime;", "\u2032");
            htmlEntityMap.Add("&Prime;", "\u2033");
            htmlEntityMap.Add("&primes;", "\u2119");
            htmlEntityMap.Add("&prnap;", "\u2AB9");
            htmlEntityMap.Add("&prnE;", "\u2AB5");
            htmlEntityMap.Add("&prnsim;", "\u22E8");
            htmlEntityMap.Add("&prod;", "\u220F");
            htmlEntityMap.Add("&Product;", "\u220F");
            htmlEntityMap.Add("&profalar;", "\u232E");
            htmlEntityMap.Add("&profline;", "\u2312");
            htmlEntityMap.Add("&profsurf;", "\u2313");
            htmlEntityMap.Add("&prop;", "\u221D");
            htmlEntityMap.Add("&Proportional;", "\u221D");
            htmlEntityMap.Add("&Proportion;", "\u2237");
            htmlEntityMap.Add("&propto;", "\u221D");
            htmlEntityMap.Add("&prsim;", "\u227E");
            htmlEntityMap.Add("&prurel;", "\u22B0");
            htmlEntityMap.Add("&Pscr;", "\uD835\uDCAB");
            htmlEntityMap.Add("&pscr;", "\uD835\uDCC5");
            htmlEntityMap.Add("&Psi;", "\u03A8");
            htmlEntityMap.Add("&psi;", "\u03C8");
            htmlEntityMap.Add("&puncsp;", "\u2008");
            htmlEntityMap.Add("&Qfr;", "\uD835\uDD14");
            htmlEntityMap.Add("&qfr;", "\uD835\uDD2E");
            htmlEntityMap.Add("&qint;", "\u2A0C");
            htmlEntityMap.Add("&qopf;", "\uD835\uDD62");
            htmlEntityMap.Add("&Qopf;", "\u211A");
            htmlEntityMap.Add("&qprime;", "\u2057");
            htmlEntityMap.Add("&Qscr;", "\uD835\uDCAC");
            htmlEntityMap.Add("&qscr;", "\uD835\uDCC6");
            htmlEntityMap.Add("&quaternions;", "\u210D");
            htmlEntityMap.Add("&quatint;", "\u2A16");
            htmlEntityMap.Add("&quest;", "\u003F");
            htmlEntityMap.Add("&questeq;", "\u225F");
            htmlEntityMap.Add("&quot;", "\u0022");
            htmlEntityMap.Add("&quot", "\u0022");
            htmlEntityMap.Add("&QUOT;", "\u0022");
            htmlEntityMap.Add("&QUOT", "\u0022");
            htmlEntityMap.Add("&rAarr;", "\u21DB");
            htmlEntityMap.Add("&race;", "\u223D\u0331");
            htmlEntityMap.Add("&Racute;", "\u0154");
            htmlEntityMap.Add("&racute;", "\u0155");
            htmlEntityMap.Add("&radic;", "\u221A");
            htmlEntityMap.Add("&raemptyv;", "\u29B3");
            htmlEntityMap.Add("&rang;", "\u27E9");
            htmlEntityMap.Add("&Rang;", "\u27EB");
            htmlEntityMap.Add("&rangd;", "\u2992");
            htmlEntityMap.Add("&range;", "\u29A5");
            htmlEntityMap.Add("&rangle;", "\u27E9");
            htmlEntityMap.Add("&raquo;", "\u00BB");
            htmlEntityMap.Add("&raquo", "\u00BB");
            htmlEntityMap.Add("&rarrap;", "\u2975");
            htmlEntityMap.Add("&rarrb;", "\u21E5");
            htmlEntityMap.Add("&rarrbfs;", "\u2920");
            htmlEntityMap.Add("&rarrc;", "\u2933");
            htmlEntityMap.Add("&rarr;", "\u2192");
            htmlEntityMap.Add("&Rarr;", "\u21A0");
            htmlEntityMap.Add("&rArr;", "\u21D2");
            htmlEntityMap.Add("&rarrfs;", "\u291E");
            htmlEntityMap.Add("&rarrhk;", "\u21AA");
            htmlEntityMap.Add("&rarrlp;", "\u21AC");
            htmlEntityMap.Add("&rarrpl;", "\u2945");
            htmlEntityMap.Add("&rarrsim;", "\u2974");
            htmlEntityMap.Add("&Rarrtl;", "\u2916");
            htmlEntityMap.Add("&rarrtl;", "\u21A3");
            htmlEntityMap.Add("&rarrw;", "\u219D");
            htmlEntityMap.Add("&ratail;", "\u291A");
            htmlEntityMap.Add("&rAtail;", "\u291C");
            htmlEntityMap.Add("&ratio;", "\u2236");
            htmlEntityMap.Add("&rationals;", "\u211A");
            htmlEntityMap.Add("&rbarr;", "\u290D");
            htmlEntityMap.Add("&rBarr;", "\u290F");
            htmlEntityMap.Add("&RBarr;", "\u2910");
            htmlEntityMap.Add("&rbbrk;", "\u2773");
            htmlEntityMap.Add("&rbrace;", "\u007D");
            htmlEntityMap.Add("&rbrack;", "\u005D");
            htmlEntityMap.Add("&rbrke;", "\u298C");
            htmlEntityMap.Add("&rbrksld;", "\u298E");
            htmlEntityMap.Add("&rbrkslu;", "\u2990");
            htmlEntityMap.Add("&Rcaron;", "\u0158");
            htmlEntityMap.Add("&rcaron;", "\u0159");
            htmlEntityMap.Add("&Rcedil;", "\u0156");
            htmlEntityMap.Add("&rcedil;", "\u0157");
            htmlEntityMap.Add("&rceil;", "\u2309");
            htmlEntityMap.Add("&rcub;", "\u007D");
            htmlEntityMap.Add("&Rcy;", "\u0420");
            htmlEntityMap.Add("&rcy;", "\u0440");
            htmlEntityMap.Add("&rdca;", "\u2937");
            htmlEntityMap.Add("&rdldhar;", "\u2969");
            htmlEntityMap.Add("&rdquo;", "\u201D");
            htmlEntityMap.Add("&rdquor;", "\u201D");
            htmlEntityMap.Add("&rdsh;", "\u21B3");
            htmlEntityMap.Add("&real;", "\u211C");
            htmlEntityMap.Add("&realine;", "\u211B");
            htmlEntityMap.Add("&realpart;", "\u211C");
            htmlEntityMap.Add("&reals;", "\u211D");
            htmlEntityMap.Add("&Re;", "\u211C");
            htmlEntityMap.Add("&rect;", "\u25AD");
            htmlEntityMap.Add("&reg;", "\u00AE");
            htmlEntityMap.Add("&reg", "\u00AE");
            htmlEntityMap.Add("&REG;", "\u00AE");
            htmlEntityMap.Add("&REG", "\u00AE");
            htmlEntityMap.Add("&ReverseElement;", "\u220B");
            htmlEntityMap.Add("&ReverseEquilibrium;", "\u21CB");
            htmlEntityMap.Add("&ReverseUpEquilibrium;", "\u296F");
            htmlEntityMap.Add("&rfisht;", "\u297D");
            htmlEntityMap.Add("&rfloor;", "\u230B");
            htmlEntityMap.Add("&rfr;", "\uD835\uDD2F");
            htmlEntityMap.Add("&Rfr;", "\u211C");
            htmlEntityMap.Add("&rHar;", "\u2964");
            htmlEntityMap.Add("&rhard;", "\u21C1");
            htmlEntityMap.Add("&rharu;", "\u21C0");
            htmlEntityMap.Add("&rharul;", "\u296C");
            htmlEntityMap.Add("&Rho;", "\u03A1");
            htmlEntityMap.Add("&rho;", "\u03C1");
            htmlEntityMap.Add("&rhov;", "\u03F1");
            htmlEntityMap.Add("&RightAngleBracket;", "\u27E9");
            htmlEntityMap.Add("&RightArrowBar;", "\u21E5");
            htmlEntityMap.Add("&rightarrow;", "\u2192");
            htmlEntityMap.Add("&RightArrow;", "\u2192");
            htmlEntityMap.Add("&Rightarrow;", "\u21D2");
            htmlEntityMap.Add("&RightArrowLeftArrow;", "\u21C4");
            htmlEntityMap.Add("&rightarrowtail;", "\u21A3");
            htmlEntityMap.Add("&RightCeiling;", "\u2309");
            htmlEntityMap.Add("&RightDoubleBracket;", "\u27E7");
            htmlEntityMap.Add("&RightDownTeeVector;", "\u295D");
            htmlEntityMap.Add("&RightDownVectorBar;", "\u2955");
            htmlEntityMap.Add("&RightDownVector;", "\u21C2");
            htmlEntityMap.Add("&RightFloor;", "\u230B");
            htmlEntityMap.Add("&rightharpoondown;", "\u21C1");
            htmlEntityMap.Add("&rightharpoonup;", "\u21C0");
            htmlEntityMap.Add("&rightleftarrows;", "\u21C4");
            htmlEntityMap.Add("&rightleftharpoons;", "\u21CC");
            htmlEntityMap.Add("&rightrightarrows;", "\u21C9");
            htmlEntityMap.Add("&rightsquigarrow;", "\u219D");
            htmlEntityMap.Add("&RightTeeArrow;", "\u21A6");
            htmlEntityMap.Add("&RightTee;", "\u22A2");
            htmlEntityMap.Add("&RightTeeVector;", "\u295B");
            htmlEntityMap.Add("&rightthreetimes;", "\u22CC");
            htmlEntityMap.Add("&RightTriangleBar;", "\u29D0");
            htmlEntityMap.Add("&RightTriangle;", "\u22B3");
            htmlEntityMap.Add("&RightTriangleEqual;", "\u22B5");
            htmlEntityMap.Add("&RightUpDownVector;", "\u294F");
            htmlEntityMap.Add("&RightUpTeeVector;", "\u295C");
            htmlEntityMap.Add("&RightUpVectorBar;", "\u2954");
            htmlEntityMap.Add("&RightUpVector;", "\u21BE");
            htmlEntityMap.Add("&RightVectorBar;", "\u2953");
            htmlEntityMap.Add("&RightVector;", "\u21C0");
            htmlEntityMap.Add("&ring;", "\u02DA");
            htmlEntityMap.Add("&risingdotseq;", "\u2253");
            htmlEntityMap.Add("&rlarr;", "\u21C4");
            htmlEntityMap.Add("&rlhar;", "\u21CC");
            htmlEntityMap.Add("&rlm;", "\u200F");
            htmlEntityMap.Add("&rmoustache;", "\u23B1");
            htmlEntityMap.Add("&rmoust;", "\u23B1");
            htmlEntityMap.Add("&rnmid;", "\u2AEE");
            htmlEntityMap.Add("&roang;", "\u27ED");
            htmlEntityMap.Add("&roarr;", "\u21FE");
            htmlEntityMap.Add("&robrk;", "\u27E7");
            htmlEntityMap.Add("&ropar;", "\u2986");
            htmlEntityMap.Add("&ropf;", "\uD835\uDD63");
            htmlEntityMap.Add("&Ropf;", "\u211D");
            htmlEntityMap.Add("&roplus;", "\u2A2E");
            htmlEntityMap.Add("&rotimes;", "\u2A35");
            htmlEntityMap.Add("&RoundImplies;", "\u2970");
            htmlEntityMap.Add("&rpar;", "\u0029");
            htmlEntityMap.Add("&rpargt;", "\u2994");
            htmlEntityMap.Add("&rppolint;", "\u2A12");
            htmlEntityMap.Add("&rrarr;", "\u21C9");
            htmlEntityMap.Add("&Rrightarrow;", "\u21DB");
            htmlEntityMap.Add("&rsaquo;", "\u203A");
            htmlEntityMap.Add("&rscr;", "\uD835\uDCC7");
            htmlEntityMap.Add("&Rscr;", "\u211B");
            htmlEntityMap.Add("&rsh;", "\u21B1");
            htmlEntityMap.Add("&Rsh;", "\u21B1");
            htmlEntityMap.Add("&rsqb;", "\u005D");
            htmlEntityMap.Add("&rsquo;", "\u2019");
            htmlEntityMap.Add("&rsquor;", "\u2019");
            htmlEntityMap.Add("&rthree;", "\u22CC");
            htmlEntityMap.Add("&rtimes;", "\u22CA");
            htmlEntityMap.Add("&rtri;", "\u25B9");
            htmlEntityMap.Add("&rtrie;", "\u22B5");
            htmlEntityMap.Add("&rtrif;", "\u25B8");
            htmlEntityMap.Add("&rtriltri;", "\u29CE");
            htmlEntityMap.Add("&RuleDelayed;", "\u29F4");
            htmlEntityMap.Add("&ruluhar;", "\u2968");
            htmlEntityMap.Add("&rx;", "\u211E");
            htmlEntityMap.Add("&Sacute;", "\u015A");
            htmlEntityMap.Add("&sacute;", "\u015B");
            htmlEntityMap.Add("&sbquo;", "\u201A");
            htmlEntityMap.Add("&scap;", "\u2AB8");
            htmlEntityMap.Add("&Scaron;", "\u0160");
            htmlEntityMap.Add("&scaron;", "\u0161");
            htmlEntityMap.Add("&Sc;", "\u2ABC");
            htmlEntityMap.Add("&sc;", "\u227B");
            htmlEntityMap.Add("&sccue;", "\u227D");
            htmlEntityMap.Add("&sce;", "\u2AB0");
            htmlEntityMap.Add("&scE;", "\u2AB4");
            htmlEntityMap.Add("&Scedil;", "\u015E");
            htmlEntityMap.Add("&scedil;", "\u015F");
            htmlEntityMap.Add("&Scirc;", "\u015C");
            htmlEntityMap.Add("&scirc;", "\u015D");
            htmlEntityMap.Add("&scnap;", "\u2ABA");
            htmlEntityMap.Add("&scnE;", "\u2AB6");
            htmlEntityMap.Add("&scnsim;", "\u22E9");
            htmlEntityMap.Add("&scpolint;", "\u2A13");
            htmlEntityMap.Add("&scsim;", "\u227F");
            htmlEntityMap.Add("&Scy;", "\u0421");
            htmlEntityMap.Add("&scy;", "\u0441");
            htmlEntityMap.Add("&sdotb;", "\u22A1");
            htmlEntityMap.Add("&sdot;", "\u22C5");
            htmlEntityMap.Add("&sdote;", "\u2A66");
            htmlEntityMap.Add("&searhk;", "\u2925");
            htmlEntityMap.Add("&searr;", "\u2198");
            htmlEntityMap.Add("&seArr;", "\u21D8");
            htmlEntityMap.Add("&searrow;", "\u2198");
            htmlEntityMap.Add("&sect;", "\u00A7");
            htmlEntityMap.Add("&sect", "\u00A7");
            htmlEntityMap.Add("&semi;", "\u003B");
            htmlEntityMap.Add("&seswar;", "\u2929");
            htmlEntityMap.Add("&setminus;", "\u2216");
            htmlEntityMap.Add("&setmn;", "\u2216");
            htmlEntityMap.Add("&sext;", "\u2736");
            htmlEntityMap.Add("&Sfr;", "\uD835\uDD16");
            htmlEntityMap.Add("&sfr;", "\uD835\uDD30");
            htmlEntityMap.Add("&sfrown;", "\u2322");
            htmlEntityMap.Add("&sharp;", "\u266F");
            htmlEntityMap.Add("&SHCHcy;", "\u0429");
            htmlEntityMap.Add("&shchcy;", "\u0449");
            htmlEntityMap.Add("&SHcy;", "\u0428");
            htmlEntityMap.Add("&shcy;", "\u0448");
            htmlEntityMap.Add("&ShortDownArrow;", "\u2193");
            htmlEntityMap.Add("&ShortLeftArrow;", "\u2190");
            htmlEntityMap.Add("&shortmid;", "\u2223");
            htmlEntityMap.Add("&shortparallel;", "\u2225");
            htmlEntityMap.Add("&ShortRightArrow;", "\u2192");
            htmlEntityMap.Add("&ShortUpArrow;", "\u2191");
            htmlEntityMap.Add("&shy;", "\u00AD");
            htmlEntityMap.Add("&shy", "\u00AD");
            htmlEntityMap.Add("&Sigma;", "\u03A3");
            htmlEntityMap.Add("&sigma;", "\u03C3");
            htmlEntityMap.Add("&sigmaf;", "\u03C2");
            htmlEntityMap.Add("&sigmav;", "\u03C2");
            htmlEntityMap.Add("&sim;", "\u223C");
            htmlEntityMap.Add("&simdot;", "\u2A6A");
            htmlEntityMap.Add("&sime;", "\u2243");
            htmlEntityMap.Add("&simeq;", "\u2243");
            htmlEntityMap.Add("&simg;", "\u2A9E");
            htmlEntityMap.Add("&simgE;", "\u2AA0");
            htmlEntityMap.Add("&siml;", "\u2A9D");
            htmlEntityMap.Add("&simlE;", "\u2A9F");
            htmlEntityMap.Add("&simne;", "\u2246");
            htmlEntityMap.Add("&simplus;", "\u2A24");
            htmlEntityMap.Add("&simrarr;", "\u2972");
            htmlEntityMap.Add("&slarr;", "\u2190");
            htmlEntityMap.Add("&SmallCircle;", "\u2218");
            htmlEntityMap.Add("&smallsetminus;", "\u2216");
            htmlEntityMap.Add("&smashp;", "\u2A33");
            htmlEntityMap.Add("&smeparsl;", "\u29E4");
            htmlEntityMap.Add("&smid;", "\u2223");
            htmlEntityMap.Add("&smile;", "\u2323");
            htmlEntityMap.Add("&smt;", "\u2AAA");
            htmlEntityMap.Add("&smte;", "\u2AAC");
            htmlEntityMap.Add("&smtes;", "\u2AAC\uFE00");
            htmlEntityMap.Add("&SOFTcy;", "\u042C");
            htmlEntityMap.Add("&softcy;", "\u044C");
            htmlEntityMap.Add("&solbar;", "\u233F");
            htmlEntityMap.Add("&solb;", "\u29C4");
            htmlEntityMap.Add("&sol;", "\u002F");
            htmlEntityMap.Add("&Sopf;", "\uD835\uDD4A");
            htmlEntityMap.Add("&sopf;", "\uD835\uDD64");
            htmlEntityMap.Add("&spades;", "\u2660");
            htmlEntityMap.Add("&spadesuit;", "\u2660");
            htmlEntityMap.Add("&spar;", "\u2225");
            htmlEntityMap.Add("&sqcap;", "\u2293");
            htmlEntityMap.Add("&sqcaps;", "\u2293\uFE00");
            htmlEntityMap.Add("&sqcup;", "\u2294");
            htmlEntityMap.Add("&sqcups;", "\u2294\uFE00");
            htmlEntityMap.Add("&Sqrt;", "\u221A");
            htmlEntityMap.Add("&sqsub;", "\u228F");
            htmlEntityMap.Add("&sqsube;", "\u2291");
            htmlEntityMap.Add("&sqsubset;", "\u228F");
            htmlEntityMap.Add("&sqsubseteq;", "\u2291");
            htmlEntityMap.Add("&sqsup;", "\u2290");
            htmlEntityMap.Add("&sqsupe;", "\u2292");
            htmlEntityMap.Add("&sqsupset;", "\u2290");
            htmlEntityMap.Add("&sqsupseteq;", "\u2292");
            htmlEntityMap.Add("&square;", "\u25A1");
            htmlEntityMap.Add("&Square;", "\u25A1");
            htmlEntityMap.Add("&SquareIntersection;", "\u2293");
            htmlEntityMap.Add("&SquareSubset;", "\u228F");
            htmlEntityMap.Add("&SquareSubsetEqual;", "\u2291");
            htmlEntityMap.Add("&SquareSuperset;", "\u2290");
            htmlEntityMap.Add("&SquareSupersetEqual;", "\u2292");
            htmlEntityMap.Add("&SquareUnion;", "\u2294");
            htmlEntityMap.Add("&squarf;", "\u25AA");
            htmlEntityMap.Add("&squ;", "\u25A1");
            htmlEntityMap.Add("&squf;", "\u25AA");
            htmlEntityMap.Add("&srarr;", "\u2192");
            htmlEntityMap.Add("&Sscr;", "\uD835\uDCAE");
            htmlEntityMap.Add("&sscr;", "\uD835\uDCC8");
            htmlEntityMap.Add("&ssetmn;", "\u2216");
            htmlEntityMap.Add("&ssmile;", "\u2323");
            htmlEntityMap.Add("&sstarf;", "\u22C6");
            htmlEntityMap.Add("&Star;", "\u22C6");
            htmlEntityMap.Add("&star;", "\u2606");
            htmlEntityMap.Add("&starf;", "\u2605");
            htmlEntityMap.Add("&straightepsilon;", "\u03F5");
            htmlEntityMap.Add("&straightphi;", "\u03D5");
            htmlEntityMap.Add("&strns;", "\u00AF");
            htmlEntityMap.Add("&sub;", "\u2282");
            htmlEntityMap.Add("&Sub;", "\u22D0");
            htmlEntityMap.Add("&subdot;", "\u2ABD");
            htmlEntityMap.Add("&subE;", "\u2AC5");
            htmlEntityMap.Add("&sube;", "\u2286");
            htmlEntityMap.Add("&subedot;", "\u2AC3");
            htmlEntityMap.Add("&submult;", "\u2AC1");
            htmlEntityMap.Add("&subnE;", "\u2ACB");
            htmlEntityMap.Add("&subne;", "\u228A");
            htmlEntityMap.Add("&subplus;", "\u2ABF");
            htmlEntityMap.Add("&subrarr;", "\u2979");
            htmlEntityMap.Add("&subset;", "\u2282");
            htmlEntityMap.Add("&Subset;", "\u22D0");
            htmlEntityMap.Add("&subseteq;", "\u2286");
            htmlEntityMap.Add("&subseteqq;", "\u2AC5");
            htmlEntityMap.Add("&SubsetEqual;", "\u2286");
            htmlEntityMap.Add("&subsetneq;", "\u228A");
            htmlEntityMap.Add("&subsetneqq;", "\u2ACB");
            htmlEntityMap.Add("&subsim;", "\u2AC7");
            htmlEntityMap.Add("&subsub;", "\u2AD5");
            htmlEntityMap.Add("&subsup;", "\u2AD3");
            htmlEntityMap.Add("&succapprox;", "\u2AB8");
            htmlEntityMap.Add("&succ;", "\u227B");
            htmlEntityMap.Add("&succcurlyeq;", "\u227D");
            htmlEntityMap.Add("&Succeeds;", "\u227B");
            htmlEntityMap.Add("&SucceedsEqual;", "\u2AB0");
            htmlEntityMap.Add("&SucceedsSlantEqual;", "\u227D");
            htmlEntityMap.Add("&SucceedsTilde;", "\u227F");
            htmlEntityMap.Add("&succeq;", "\u2AB0");
            htmlEntityMap.Add("&succnapprox;", "\u2ABA");
            htmlEntityMap.Add("&succneqq;", "\u2AB6");
            htmlEntityMap.Add("&succnsim;", "\u22E9");
            htmlEntityMap.Add("&succsim;", "\u227F");
            htmlEntityMap.Add("&SuchThat;", "\u220B");
            htmlEntityMap.Add("&sum;", "\u2211");
            htmlEntityMap.Add("&Sum;", "\u2211");
            htmlEntityMap.Add("&sung;", "\u266A");
            htmlEntityMap.Add("&sup1;", "\u00B9");
            htmlEntityMap.Add("&sup1", "\u00B9");
            htmlEntityMap.Add("&sup2;", "\u00B2");
            htmlEntityMap.Add("&sup2", "\u00B2");
            htmlEntityMap.Add("&sup3;", "\u00B3");
            htmlEntityMap.Add("&sup3", "\u00B3");
            htmlEntityMap.Add("&sup;", "\u2283");
            htmlEntityMap.Add("&Sup;", "\u22D1");
            htmlEntityMap.Add("&supdot;", "\u2ABE");
            htmlEntityMap.Add("&supdsub;", "\u2AD8");
            htmlEntityMap.Add("&supE;", "\u2AC6");
            htmlEntityMap.Add("&supe;", "\u2287");
            htmlEntityMap.Add("&supedot;", "\u2AC4");
            htmlEntityMap.Add("&Superset;", "\u2283");
            htmlEntityMap.Add("&SupersetEqual;", "\u2287");
            htmlEntityMap.Add("&suphsol;", "\u27C9");
            htmlEntityMap.Add("&suphsub;", "\u2AD7");
            htmlEntityMap.Add("&suplarr;", "\u297B");
            htmlEntityMap.Add("&supmult;", "\u2AC2");
            htmlEntityMap.Add("&supnE;", "\u2ACC");
            htmlEntityMap.Add("&supne;", "\u228B");
            htmlEntityMap.Add("&supplus;", "\u2AC0");
            htmlEntityMap.Add("&supset;", "\u2283");
            htmlEntityMap.Add("&Supset;", "\u22D1");
            htmlEntityMap.Add("&supseteq;", "\u2287");
            htmlEntityMap.Add("&supseteqq;", "\u2AC6");
            htmlEntityMap.Add("&supsetneq;", "\u228B");
            htmlEntityMap.Add("&supsetneqq;", "\u2ACC");
            htmlEntityMap.Add("&supsim;", "\u2AC8");
            htmlEntityMap.Add("&supsub;", "\u2AD4");
            htmlEntityMap.Add("&supsup;", "\u2AD6");
            htmlEntityMap.Add("&swarhk;", "\u2926");
            htmlEntityMap.Add("&swarr;", "\u2199");
            htmlEntityMap.Add("&swArr;", "\u21D9");
            htmlEntityMap.Add("&swarrow;", "\u2199");
            htmlEntityMap.Add("&swnwar;", "\u292A");
            htmlEntityMap.Add("&szlig;", "\u00DF");
            htmlEntityMap.Add("&szlig", "\u00DF");
            htmlEntityMap.Add("&Tab;", "\u0009");
            htmlEntityMap.Add("&target;", "\u2316");
            htmlEntityMap.Add("&Tau;", "\u03A4");
            htmlEntityMap.Add("&tau;", "\u03C4");
            htmlEntityMap.Add("&tbrk;", "\u23B4");
            htmlEntityMap.Add("&Tcaron;", "\u0164");
            htmlEntityMap.Add("&tcaron;", "\u0165");
            htmlEntityMap.Add("&Tcedil;", "\u0162");
            htmlEntityMap.Add("&tcedil;", "\u0163");
            htmlEntityMap.Add("&Tcy;", "\u0422");
            htmlEntityMap.Add("&tcy;", "\u0442");
            htmlEntityMap.Add("&tdot;", "\u20DB");
            htmlEntityMap.Add("&telrec;", "\u2315");
            htmlEntityMap.Add("&Tfr;", "\uD835\uDD17");
            htmlEntityMap.Add("&tfr;", "\uD835\uDD31");
            htmlEntityMap.Add("&there4;", "\u2234");
            htmlEntityMap.Add("&therefore;", "\u2234");
            htmlEntityMap.Add("&Therefore;", "\u2234");
            htmlEntityMap.Add("&Theta;", "\u0398");
            htmlEntityMap.Add("&theta;", "\u03B8");
            htmlEntityMap.Add("&thetasym;", "\u03D1");
            htmlEntityMap.Add("&thetav;", "\u03D1");
            htmlEntityMap.Add("&thickapprox;", "\u2248");
            htmlEntityMap.Add("&thicksim;", "\u223C");
            htmlEntityMap.Add("&ThickSpace;", "\u205F\u200A");
            htmlEntityMap.Add("&ThinSpace;", "\u2009");
            htmlEntityMap.Add("&thinsp;", "\u2009");
            htmlEntityMap.Add("&thkap;", "\u2248");
            htmlEntityMap.Add("&thksim;", "\u223C");
            htmlEntityMap.Add("&THORN;", "\u00DE");
            htmlEntityMap.Add("&THORN", "\u00DE");
            htmlEntityMap.Add("&thorn;", "\u00FE");
            htmlEntityMap.Add("&thorn", "\u00FE");
            htmlEntityMap.Add("&tilde;", "\u02DC");
            htmlEntityMap.Add("&Tilde;", "\u223C");
            htmlEntityMap.Add("&TildeEqual;", "\u2243");
            htmlEntityMap.Add("&TildeFullEqual;", "\u2245");
            htmlEntityMap.Add("&TildeTilde;", "\u2248");
            htmlEntityMap.Add("&timesbar;", "\u2A31");
            htmlEntityMap.Add("&timesb;", "\u22A0");
            htmlEntityMap.Add("&times;", "\u00D7");
            htmlEntityMap.Add("&times", "\u00D7");
            htmlEntityMap.Add("&timesd;", "\u2A30");
            htmlEntityMap.Add("&tint;", "\u222D");
            htmlEntityMap.Add("&toea;", "\u2928");
            htmlEntityMap.Add("&topbot;", "\u2336");
            htmlEntityMap.Add("&topcir;", "\u2AF1");
            htmlEntityMap.Add("&top;", "\u22A4");
            htmlEntityMap.Add("&Topf;", "\uD835\uDD4B");
            htmlEntityMap.Add("&topf;", "\uD835\uDD65");
            htmlEntityMap.Add("&topfork;", "\u2ADA");
            htmlEntityMap.Add("&tosa;", "\u2929");
            htmlEntityMap.Add("&tprime;", "\u2034");
            htmlEntityMap.Add("&trade;", "\u2122");
            htmlEntityMap.Add("&TRADE;", "\u2122");
            htmlEntityMap.Add("&triangle;", "\u25B5");
            htmlEntityMap.Add("&triangledown;", "\u25BF");
            htmlEntityMap.Add("&triangleleft;", "\u25C3");
            htmlEntityMap.Add("&trianglelefteq;", "\u22B4");
            htmlEntityMap.Add("&triangleq;", "\u225C");
            htmlEntityMap.Add("&triangleright;", "\u25B9");
            htmlEntityMap.Add("&trianglerighteq;", "\u22B5");
            htmlEntityMap.Add("&tridot;", "\u25EC");
            htmlEntityMap.Add("&trie;", "\u225C");
            htmlEntityMap.Add("&triminus;", "\u2A3A");
            htmlEntityMap.Add("&TripleDot;", "\u20DB");
            htmlEntityMap.Add("&triplus;", "\u2A39");
            htmlEntityMap.Add("&trisb;", "\u29CD");
            htmlEntityMap.Add("&tritime;", "\u2A3B");
            htmlEntityMap.Add("&trpezium;", "\u23E2");
            htmlEntityMap.Add("&Tscr;", "\uD835\uDCAF");
            htmlEntityMap.Add("&tscr;", "\uD835\uDCC9");
            htmlEntityMap.Add("&TScy;", "\u0426");
            htmlEntityMap.Add("&tscy;", "\u0446");
            htmlEntityMap.Add("&TSHcy;", "\u040B");
            htmlEntityMap.Add("&tshcy;", "\u045B");
            htmlEntityMap.Add("&Tstrok;", "\u0166");
            htmlEntityMap.Add("&tstrok;", "\u0167");
            htmlEntityMap.Add("&twixt;", "\u226C");
            htmlEntityMap.Add("&twoheadleftarrow;", "\u219E");
            htmlEntityMap.Add("&twoheadrightarrow;", "\u21A0");
            htmlEntityMap.Add("&Uacute;", "\u00DA");
            htmlEntityMap.Add("&Uacute", "\u00DA");
            htmlEntityMap.Add("&uacute;", "\u00FA");
            htmlEntityMap.Add("&uacute", "\u00FA");
            htmlEntityMap.Add("&uarr;", "\u2191");
            htmlEntityMap.Add("&Uarr;", "\u219F");
            htmlEntityMap.Add("&uArr;", "\u21D1");
            htmlEntityMap.Add("&Uarrocir;", "\u2949");
            htmlEntityMap.Add("&Ubrcy;", "\u040E");
            htmlEntityMap.Add("&ubrcy;", "\u045E");
            htmlEntityMap.Add("&Ubreve;", "\u016C");
            htmlEntityMap.Add("&ubreve;", "\u016D");
            htmlEntityMap.Add("&Ucirc;", "\u00DB");
            htmlEntityMap.Add("&Ucirc", "\u00DB");
            htmlEntityMap.Add("&ucirc;", "\u00FB");
            htmlEntityMap.Add("&ucirc", "\u00FB");
            htmlEntityMap.Add("&Ucy;", "\u0423");
            htmlEntityMap.Add("&ucy;", "\u0443");
            htmlEntityMap.Add("&udarr;", "\u21C5");
            htmlEntityMap.Add("&Udblac;", "\u0170");
            htmlEntityMap.Add("&udblac;", "\u0171");
            htmlEntityMap.Add("&udhar;", "\u296E");
            htmlEntityMap.Add("&ufisht;", "\u297E");
            htmlEntityMap.Add("&Ufr;", "\uD835\uDD18");
            htmlEntityMap.Add("&ufr;", "\uD835\uDD32");
            htmlEntityMap.Add("&Ugrave;", "\u00D9");
            htmlEntityMap.Add("&Ugrave", "\u00D9");
            htmlEntityMap.Add("&ugrave;", "\u00F9");
            htmlEntityMap.Add("&ugrave", "\u00F9");
            htmlEntityMap.Add("&uHar;", "\u2963");
            htmlEntityMap.Add("&uharl;", "\u21BF");
            htmlEntityMap.Add("&uharr;", "\u21BE");
            htmlEntityMap.Add("&uhblk;", "\u2580");
            htmlEntityMap.Add("&ulcorn;", "\u231C");
            htmlEntityMap.Add("&ulcorner;", "\u231C");
            htmlEntityMap.Add("&ulcrop;", "\u230F");
            htmlEntityMap.Add("&ultri;", "\u25F8");
            htmlEntityMap.Add("&Umacr;", "\u016A");
            htmlEntityMap.Add("&umacr;", "\u016B");
            htmlEntityMap.Add("&uml;", "\u00A8");
            htmlEntityMap.Add("&uml", "\u00A8");
            htmlEntityMap.Add("&UnderBar;", "\u005F");
            htmlEntityMap.Add("&UnderBrace;", "\u23DF");
            htmlEntityMap.Add("&UnderBracket;", "\u23B5");
            htmlEntityMap.Add("&UnderParenthesis;", "\u23DD");
            htmlEntityMap.Add("&Union;", "\u22C3");
            htmlEntityMap.Add("&UnionPlus;", "\u228E");
            htmlEntityMap.Add("&Uogon;", "\u0172");
            htmlEntityMap.Add("&uogon;", "\u0173");
            htmlEntityMap.Add("&Uopf;", "\uD835\uDD4C");
            htmlEntityMap.Add("&uopf;", "\uD835\uDD66");
            htmlEntityMap.Add("&UpArrowBar;", "\u2912");
            htmlEntityMap.Add("&uparrow;", "\u2191");
            htmlEntityMap.Add("&UpArrow;", "\u2191");
            htmlEntityMap.Add("&Uparrow;", "\u21D1");
            htmlEntityMap.Add("&UpArrowDownArrow;", "\u21C5");
            htmlEntityMap.Add("&updownarrow;", "\u2195");
            htmlEntityMap.Add("&UpDownArrow;", "\u2195");
            htmlEntityMap.Add("&Updownarrow;", "\u21D5");
            htmlEntityMap.Add("&UpEquilibrium;", "\u296E");
            htmlEntityMap.Add("&upharpoonleft;", "\u21BF");
            htmlEntityMap.Add("&upharpoonright;", "\u21BE");
            htmlEntityMap.Add("&uplus;", "\u228E");
            htmlEntityMap.Add("&UpperLeftArrow;", "\u2196");
            htmlEntityMap.Add("&UpperRightArrow;", "\u2197");
            htmlEntityMap.Add("&upsi;", "\u03C5");
            htmlEntityMap.Add("&Upsi;", "\u03D2");
            htmlEntityMap.Add("&upsih;", "\u03D2");
            htmlEntityMap.Add("&Upsilon;", "\u03A5");
            htmlEntityMap.Add("&upsilon;", "\u03C5");
            htmlEntityMap.Add("&UpTeeArrow;", "\u21A5");
            htmlEntityMap.Add("&UpTee;", "\u22A5");
            htmlEntityMap.Add("&upuparrows;", "\u21C8");
            htmlEntityMap.Add("&urcorn;", "\u231D");
            htmlEntityMap.Add("&urcorner;", "\u231D");
            htmlEntityMap.Add("&urcrop;", "\u230E");
            htmlEntityMap.Add("&Uring;", "\u016E");
            htmlEntityMap.Add("&uring;", "\u016F");
            htmlEntityMap.Add("&urtri;", "\u25F9");
            htmlEntityMap.Add("&Uscr;", "\uD835\uDCB0");
            htmlEntityMap.Add("&uscr;", "\uD835\uDCCA");
            htmlEntityMap.Add("&utdot;", "\u22F0");
            htmlEntityMap.Add("&Utilde;", "\u0168");
            htmlEntityMap.Add("&utilde;", "\u0169");
            htmlEntityMap.Add("&utri;", "\u25B5");
            htmlEntityMap.Add("&utrif;", "\u25B4");
            htmlEntityMap.Add("&uuarr;", "\u21C8");
            htmlEntityMap.Add("&Uuml;", "\u00DC");
            htmlEntityMap.Add("&Uuml", "\u00DC");
            htmlEntityMap.Add("&uuml;", "\u00FC");
            htmlEntityMap.Add("&uuml", "\u00FC");
            htmlEntityMap.Add("&uwangle;", "\u29A7");
            htmlEntityMap.Add("&vangrt;", "\u299C");
            htmlEntityMap.Add("&varepsilon;", "\u03F5");
            htmlEntityMap.Add("&varkappa;", "\u03F0");
            htmlEntityMap.Add("&varnothing;", "\u2205");
            htmlEntityMap.Add("&varphi;", "\u03D5");
            htmlEntityMap.Add("&varpi;", "\u03D6");
            htmlEntityMap.Add("&varpropto;", "\u221D");
            htmlEntityMap.Add("&varr;", "\u2195");
            htmlEntityMap.Add("&vArr;", "\u21D5");
            htmlEntityMap.Add("&varrho;", "\u03F1");
            htmlEntityMap.Add("&varsigma;", "\u03C2");
            htmlEntityMap.Add("&varsubsetneq;", "\u228A\uFE00");
            htmlEntityMap.Add("&varsubsetneqq;", "\u2ACB\uFE00");
            htmlEntityMap.Add("&varsupsetneq;", "\u228B\uFE00");
            htmlEntityMap.Add("&varsupsetneqq;", "\u2ACC\uFE00");
            htmlEntityMap.Add("&vartheta;", "\u03D1");
            htmlEntityMap.Add("&vartriangleleft;", "\u22B2");
            htmlEntityMap.Add("&vartriangleright;", "\u22B3");
            htmlEntityMap.Add("&vBar;", "\u2AE8");
            htmlEntityMap.Add("&Vbar;", "\u2AEB");
            htmlEntityMap.Add("&vBarv;", "\u2AE9");
            htmlEntityMap.Add("&Vcy;", "\u0412");
            htmlEntityMap.Add("&vcy;", "\u0432");
            htmlEntityMap.Add("&vdash;", "\u22A2");
            htmlEntityMap.Add("&vDash;", "\u22A8");
            htmlEntityMap.Add("&Vdash;", "\u22A9");
            htmlEntityMap.Add("&VDash;", "\u22AB");
            htmlEntityMap.Add("&Vdashl;", "\u2AE6");
            htmlEntityMap.Add("&veebar;", "\u22BB");
            htmlEntityMap.Add("&vee;", "\u2228");
            htmlEntityMap.Add("&Vee;", "\u22C1");
            htmlEntityMap.Add("&veeeq;", "\u225A");
            htmlEntityMap.Add("&vellip;", "\u22EE");
            htmlEntityMap.Add("&verbar;", "\u007C");
            htmlEntityMap.Add("&Verbar;", "\u2016");
            htmlEntityMap.Add("&vert;", "\u007C");
            htmlEntityMap.Add("&Vert;", "\u2016");
            htmlEntityMap.Add("&VerticalBar;", "\u2223");
            htmlEntityMap.Add("&VerticalLine;", "\u007C");
            htmlEntityMap.Add("&VerticalSeparator;", "\u2758");
            htmlEntityMap.Add("&VerticalTilde;", "\u2240");
            htmlEntityMap.Add("&VeryThinSpace;", "\u200A");
            htmlEntityMap.Add("&Vfr;", "\uD835\uDD19");
            htmlEntityMap.Add("&vfr;", "\uD835\uDD33");
            htmlEntityMap.Add("&vltri;", "\u22B2");
            htmlEntityMap.Add("&vnsub;", "\u2282\u20D2");
            htmlEntityMap.Add("&vnsup;", "\u2283\u20D2");
            htmlEntityMap.Add("&Vopf;", "\uD835\uDD4D");
            htmlEntityMap.Add("&vopf;", "\uD835\uDD67");
            htmlEntityMap.Add("&vprop;", "\u221D");
            htmlEntityMap.Add("&vrtri;", "\u22B3");
            htmlEntityMap.Add("&Vscr;", "\uD835\uDCB1");
            htmlEntityMap.Add("&vscr;", "\uD835\uDCCB");
            htmlEntityMap.Add("&vsubnE;", "\u2ACB\uFE00");
            htmlEntityMap.Add("&vsubne;", "\u228A\uFE00");
            htmlEntityMap.Add("&vsupnE;", "\u2ACC\uFE00");
            htmlEntityMap.Add("&vsupne;", "\u228B\uFE00");
            htmlEntityMap.Add("&Vvdash;", "\u22AA");
            htmlEntityMap.Add("&vzigzag;", "\u299A");
            htmlEntityMap.Add("&Wcirc;", "\u0174");
            htmlEntityMap.Add("&wcirc;", "\u0175");
            htmlEntityMap.Add("&wedbar;", "\u2A5F");
            htmlEntityMap.Add("&wedge;", "\u2227");
            htmlEntityMap.Add("&Wedge;", "\u22C0");
            htmlEntityMap.Add("&wedgeq;", "\u2259");
            htmlEntityMap.Add("&weierp;", "\u2118");
            htmlEntityMap.Add("&Wfr;", "\uD835\uDD1A");
            htmlEntityMap.Add("&wfr;", "\uD835\uDD34");
            htmlEntityMap.Add("&Wopf;", "\uD835\uDD4E");
            htmlEntityMap.Add("&wopf;", "\uD835\uDD68");
            htmlEntityMap.Add("&wp;", "\u2118");
            htmlEntityMap.Add("&wr;", "\u2240");
            htmlEntityMap.Add("&wreath;", "\u2240");
            htmlEntityMap.Add("&Wscr;", "\uD835\uDCB2");
            htmlEntityMap.Add("&wscr;", "\uD835\uDCCC");
            htmlEntityMap.Add("&xcap;", "\u22C2");
            htmlEntityMap.Add("&xcirc;", "\u25EF");
            htmlEntityMap.Add("&xcup;", "\u22C3");
            htmlEntityMap.Add("&xdtri;", "\u25BD");
            htmlEntityMap.Add("&Xfr;", "\uD835\uDD1B");
            htmlEntityMap.Add("&xfr;", "\uD835\uDD35");
            htmlEntityMap.Add("&xharr;", "\u27F7");
            htmlEntityMap.Add("&xhArr;", "\u27FA");
            htmlEntityMap.Add("&Xi;", "\u039E");
            htmlEntityMap.Add("&xi;", "\u03BE");
            htmlEntityMap.Add("&xlarr;", "\u27F5");
            htmlEntityMap.Add("&xlArr;", "\u27F8");
            htmlEntityMap.Add("&xmap;", "\u27FC");
            htmlEntityMap.Add("&xnis;", "\u22FB");
            htmlEntityMap.Add("&xodot;", "\u2A00");
            htmlEntityMap.Add("&Xopf;", "\uD835\uDD4F");
            htmlEntityMap.Add("&xopf;", "\uD835\uDD69");
            htmlEntityMap.Add("&xoplus;", "\u2A01");
            htmlEntityMap.Add("&xotime;", "\u2A02");
            htmlEntityMap.Add("&xrarr;", "\u27F6");
            htmlEntityMap.Add("&xrArr;", "\u27F9");
            htmlEntityMap.Add("&Xscr;", "\uD835\uDCB3");
            htmlEntityMap.Add("&xscr;", "\uD835\uDCCD");
            htmlEntityMap.Add("&xsqcup;", "\u2A06");
            htmlEntityMap.Add("&xuplus;", "\u2A04");
            htmlEntityMap.Add("&xutri;", "\u25B3");
            htmlEntityMap.Add("&xvee;", "\u22C1");
            htmlEntityMap.Add("&xwedge;", "\u22C0");
            htmlEntityMap.Add("&Yacute;", "\u00DD");
            htmlEntityMap.Add("&Yacute", "\u00DD");
            htmlEntityMap.Add("&yacute;", "\u00FD");
            htmlEntityMap.Add("&yacute", "\u00FD");
            htmlEntityMap.Add("&YAcy;", "\u042F");
            htmlEntityMap.Add("&yacy;", "\u044F");
            htmlEntityMap.Add("&Ycirc;", "\u0176");
            htmlEntityMap.Add("&ycirc;", "\u0177");
            htmlEntityMap.Add("&Ycy;", "\u042B");
            htmlEntityMap.Add("&ycy;", "\u044B");
            htmlEntityMap.Add("&yen;", "\u00A5");
            htmlEntityMap.Add("&yen", "\u00A5");
            htmlEntityMap.Add("&Yfr;", "\uD835\uDD1C");
            htmlEntityMap.Add("&yfr;", "\uD835\uDD36");
            htmlEntityMap.Add("&YIcy;", "\u0407");
            htmlEntityMap.Add("&yicy;", "\u0457");
            htmlEntityMap.Add("&Yopf;", "\uD835\uDD50");
            htmlEntityMap.Add("&yopf;", "\uD835\uDD6A");
            htmlEntityMap.Add("&Yscr;", "\uD835\uDCB4");
            htmlEntityMap.Add("&yscr;", "\uD835\uDCCE");
            htmlEntityMap.Add("&YUcy;", "\u042E");
            htmlEntityMap.Add("&yucy;", "\u044E");
            htmlEntityMap.Add("&yuml;", "\u00FF");
            htmlEntityMap.Add("&yuml", "\u00FF");
            htmlEntityMap.Add("&Yuml;", "\u0178");
            htmlEntityMap.Add("&Zacute;", "\u0179");
            htmlEntityMap.Add("&zacute;", "\u017A");
            htmlEntityMap.Add("&Zcaron;", "\u017D");
            htmlEntityMap.Add("&zcaron;", "\u017E");
            htmlEntityMap.Add("&Zcy;", "\u0417");
            htmlEntityMap.Add("&zcy;", "\u0437");
            htmlEntityMap.Add("&Zdot;", "\u017B");
            htmlEntityMap.Add("&zdot;", "\u017C");
            htmlEntityMap.Add("&zeetrf;", "\u2128");
            htmlEntityMap.Add("&ZeroWidthSpace;", "\u200B");
            htmlEntityMap.Add("&Zeta;", "\u0396");
            htmlEntityMap.Add("&zeta;", "\u03B6");
            htmlEntityMap.Add("&zfr;", "\uD835\uDD37");
            htmlEntityMap.Add("&Zfr;", "\u2128");
            htmlEntityMap.Add("&ZHcy;", "\u0416");
            htmlEntityMap.Add("&zhcy;", "\u0436");
            htmlEntityMap.Add("&zigrarr;", "\u21DD");
            htmlEntityMap.Add("&zopf;", "\uD835\uDD6B");
            htmlEntityMap.Add("&Zopf;", "\u2124");
            htmlEntityMap.Add("&Zscr;", "\uD835\uDCB5");
            htmlEntityMap.Add("&zscr;", "\uD835\uDCCF");
            htmlEntityMap.Add("&zwj;", "\u200D");
            htmlEntityMap.Add("&zwnj;", "\u200C");
        }
    }
}
