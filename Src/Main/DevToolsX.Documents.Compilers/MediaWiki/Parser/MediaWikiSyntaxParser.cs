// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.MetaModel;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Languages.Antlr4Roslyn.Parser;
namespace DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax
{
    public class MediaWikiSyntaxParser : Antlr4SyntaxParser<MediaWikiLexer, MediaWikiParser>
    {
        public MediaWikiSyntaxParser(
            SourceText text,
            MediaWikiParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, MediaWikiLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override MediaWikiLexer CreateLexer(AntlrInputStream inputStream)
        {
            return new MediaWikiLexer(inputStream);
        }
        protected override MediaWikiParser CreateParser(CommonTokenStream tokenStream)
        {
            return new MediaWikiParser(tokenStream);
        }
        public override GreenNode Parse()
        {
            return this.ParseMain();
        }
        internal MainGreen ParseMain()
        {
            Antlr4ToRoslynVisitor visitor = new Antlr4ToRoslynVisitor(this);
            var tree = this.Parser.main();
            return (MainGreen)visitor.Visit(tree);
        }
        private class Antlr4ToRoslynVisitor : MediaWikiParserBaseVisitor<GreenNode>
        {
            private MediaWikiLanguage language;
			private MediaWikiGreenFactory factory;
            private MediaWikiSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastToken;
            public Antlr4ToRoslynVisitor(MediaWikiSyntaxParser syntaxParser)
            {
                this.language = MediaWikiLanguage.Instance;
				this.factory = language.InternalSyntaxFactory;
                this.syntaxParser = syntaxParser;
				this.tokens = this.syntaxParser.CommonTokenStream.GetTokens();
                this.lastToken = null;
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                GreenNode result = this.syntaxParser.VisitTerminal(node, ref this.lastToken);
                if (result != null && !result.IsMissing)
                {
                    this.lastToken = node.Symbol;
                }
                return result;
            }
			
			public override GreenNode VisitMain(MediaWikiParser.MainContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.SpecialBlockOrParagraphContext[] specialBlockOrParagraphContext = context.specialBlockOrParagraph();
			    ArrayBuilder<SpecialBlockOrParagraphGreen> specialBlockOrParagraphBuilder = ArrayBuilder<SpecialBlockOrParagraphGreen>.GetInstance(specialBlockOrParagraphContext.Length);
			    for (int i = 0; i < specialBlockOrParagraphContext.Length; i++)
			    {
			        specialBlockOrParagraphBuilder.Add((SpecialBlockOrParagraphGreen)this.Visit(specialBlockOrParagraphContext[i]));
			    }
				InternalSyntaxNodeList specialBlockOrParagraph = InternalSyntaxNodeList.Create(specialBlockOrParagraphBuilder.ToArrayAndFree());
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof());
				return this.factory.Main(specialBlockOrParagraph, eof, true);
			}
			
			public override GreenNode VisitSpecialBlockOrParagraph(MediaWikiParser.SpecialBlockOrParagraphContext context)
			{
				if (context == null) return null;
				MediaWikiParser.SpecialBlockWithCommentContext specialBlockWithCommentContext = context.specialBlockWithComment();
				if (specialBlockWithCommentContext != null) 
				{
					return this.factory.SpecialBlockOrParagraph((SpecialBlockWithCommentGreen)this.Visit(specialBlockWithCommentContext), true);
				}
				MediaWikiParser.ParagraphContext paragraphContext = context.paragraph();
				if (paragraphContext != null) 
				{
					return this.factory.SpecialBlockOrParagraph((ParagraphGreen)this.Visit(paragraphContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitSpecialBlockWithComment(MediaWikiParser.SpecialBlockWithCommentContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlCommentListContext leadingCommentContext = context.leadingComment;
				HtmlCommentListGreen leadingComment = null;
				if (leadingCommentContext != null)
				{
					leadingComment = (HtmlCommentListGreen)this.Visit(leadingCommentContext);
				}
				MediaWikiParser.SpecialBlockContext specialBlockContext = context.specialBlock();
				SpecialBlockGreen specialBlock = null;
				if (specialBlockContext != null)
				{
					specialBlock = (SpecialBlockGreen)this.Visit(specialBlockContext);
				}
				MediaWikiParser.HtmlCommentListContext trailingCommentContext = context.trailingComment;
				HtmlCommentListGreen trailingComment = null;
				if (trailingCommentContext != null)
				{
					trailingComment = (HtmlCommentListGreen)this.Visit(trailingCommentContext);
				}
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
				return this.factory.SpecialBlockWithComment(leadingComment, specialBlock, trailingComment, crlf, true);
			}
			
			public override GreenNode VisitSpecialBlock(MediaWikiParser.SpecialBlockContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HeadingContext headingContext = context.heading();
				if (headingContext != null) 
				{
					return this.factory.SpecialBlock((HeadingGreen)this.Visit(headingContext), true);
				}
				MediaWikiParser.HorizontalRuleContext horizontalRuleContext = context.horizontalRule();
				if (horizontalRuleContext != null) 
				{
					return this.factory.SpecialBlock((HorizontalRuleGreen)this.Visit(horizontalRuleContext), true);
				}
				MediaWikiParser.SpaceBlockContext spaceBlockContext = context.spaceBlock();
				if (spaceBlockContext != null) 
				{
					return this.factory.SpecialBlock((SpaceBlockGreen)this.Visit(spaceBlockContext), true);
				}
				MediaWikiParser.ListItemContext listItemContext = context.listItem();
				if (listItemContext != null) 
				{
					return this.factory.SpecialBlock((ListItemGreen)this.Visit(listItemContext), true);
				}
				MediaWikiParser.TableContext tableContext = context.table();
				if (tableContext != null) 
				{
					return this.factory.SpecialBlock((TableGreen)this.Visit(tableContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitHeading(MediaWikiParser.HeadingContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HeadingLevelContext headingStartContext = context.headingStart;
				HeadingLevelGreen headingStart = null;
				if (headingStartContext != null)
				{
					headingStart = (HeadingLevelGreen)this.Visit(headingStartContext);
				}
				MediaWikiParser.HeadingTextContext headingTextContext = context.headingText();
				HeadingTextGreen headingText = null;
				if (headingTextContext != null)
				{
					headingText = (HeadingTextGreen)this.Visit(headingTextContext);
				}
				MediaWikiParser.HeadingLevelContext headingEndContext = context.headingEnd;
				HeadingLevelGreen headingEnd = null;
				if (headingEndContext != null)
				{
					headingEnd = (HeadingLevelGreen)this.Visit(headingEndContext);
				}
				MediaWikiParser.InlineTextContext inlineTextContext = context.inlineText();
				InlineTextGreen inlineText = null;
				if (inlineTextContext != null)
				{
					inlineText = (InlineTextGreen)this.Visit(inlineTextContext);
				}
				return this.factory.Heading(headingStart, headingText, headingEnd, inlineText, true);
			}
			
			public override GreenNode VisitHeadingLevel(MediaWikiParser.HeadingLevelContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tHeading = (InternalSyntaxToken)this.VisitTerminal(context.THeading());
				return this.factory.HeadingLevel(tHeading, true);
			}
			
			public override GreenNode VisitHorizontalRule(MediaWikiParser.HorizontalRuleContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tHorizontalLine = (InternalSyntaxToken)this.VisitTerminal(context.THorizontalLine());
				MediaWikiParser.InlineTextContext inlineTextContext = context.inlineText();
				InlineTextGreen inlineText = null;
				if (inlineTextContext != null)
				{
					inlineText = (InlineTextGreen)this.Visit(inlineTextContext);
				}
				return this.factory.HorizontalRule(tHorizontalLine, inlineText, true);
			}
			
			public override GreenNode VisitSpaceBlock(MediaWikiParser.SpaceBlockContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSpaceBlockStart = (InternalSyntaxToken)this.VisitTerminal(context.TSpaceBlockStart());
				MediaWikiParser.InlineTextContext inlineTextContext = context.inlineText();
				InlineTextGreen inlineText = null;
				if (inlineTextContext != null)
				{
					inlineText = (InlineTextGreen)this.Visit(inlineTextContext);
				}
				return this.factory.SpaceBlock(tSpaceBlockStart, inlineText, true);
			}
			
			public override GreenNode VisitListItem(MediaWikiParser.ListItemContext context)
			{
				if (context == null) return null;
				MediaWikiParser.NormalListItemContext normalListItemContext = context.normalListItem();
				if (normalListItemContext != null) 
				{
					return this.factory.ListItem((NormalListItemGreen)this.Visit(normalListItemContext), true);
				}
				MediaWikiParser.DefinitionItemContext definitionItemContext = context.definitionItem();
				if (definitionItemContext != null) 
				{
					return this.factory.ListItem((DefinitionItemGreen)this.Visit(definitionItemContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitNormalListItem(MediaWikiParser.NormalListItemContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tListStart = (InternalSyntaxToken)this.VisitTerminal(context.TListStart());
				MediaWikiParser.InlineTextContext inlineTextContext = context.inlineText();
				InlineTextGreen inlineText = null;
				if (inlineTextContext != null)
				{
					inlineText = (InlineTextGreen)this.Visit(inlineTextContext);
				}
				return this.factory.NormalListItem(tListStart, inlineText, true);
			}
			
			public override GreenNode VisitDefinitionItem(MediaWikiParser.DefinitionItemContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tDefinitionStart = (InternalSyntaxToken)this.VisitTerminal(context.TDefinitionStart());
				MediaWikiParser.DefinitionTextContext definitionTextContext = context.definitionText();
				DefinitionTextGreen definitionText = null;
				if (definitionTextContext != null)
				{
					definitionText = (DefinitionTextGreen)this.Visit(definitionTextContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				MediaWikiParser.InlineTextContext inlineTextContext = context.inlineText();
				InlineTextGreen inlineText = null;
				if (inlineTextContext != null)
				{
					inlineText = (InlineTextGreen)this.Visit(inlineTextContext);
				}
				return this.factory.DefinitionItem(tDefinitionStart, definitionText, tColon, inlineText, true);
			}
			
			public override GreenNode VisitTable(MediaWikiParser.TableContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTableStart = (InternalSyntaxToken)this.VisitTerminal(context.TTableStart());
				MediaWikiParser.InlineTextContext leadingInlineTextContext = context.leadingInlineText;
				InlineTextGreen leadingInlineText = null;
				if (leadingInlineTextContext != null)
				{
					leadingInlineText = (InlineTextGreen)this.Visit(leadingInlineTextContext);
				}
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
				MediaWikiParser.TableCaptionContext tableCaptionContext = context.tableCaption();
				TableCaptionGreen tableCaption = null;
				if (tableCaptionContext != null)
				{
					tableCaption = (TableCaptionGreen)this.Visit(tableCaptionContext);
				}
				MediaWikiParser.TableRowsContext tableRowsContext = context.tableRows();
				TableRowsGreen tableRows = null;
				if (tableRowsContext != null)
				{
					tableRows = (TableRowsGreen)this.Visit(tableRowsContext);
				}
				InternalSyntaxToken tTableEnd = (InternalSyntaxToken)this.VisitTerminal(context.TTableEnd());
				MediaWikiParser.InlineTextContext trailingInlineTextContext = context.trailingInlineText;
				InlineTextGreen trailingInlineText = null;
				if (trailingInlineTextContext != null)
				{
					trailingInlineText = (InlineTextGreen)this.Visit(trailingInlineTextContext);
				}
				return this.factory.Table(tTableStart, leadingInlineText, crlf, tableCaption, tableRows, tTableEnd, trailingInlineText, true);
			}
			
			public override GreenNode VisitTableCaption(MediaWikiParser.TableCaptionContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTableCaptionStart = (InternalSyntaxToken)this.VisitTerminal(context.TTableCaptionStart());
				MediaWikiParser.InlineTextContext inlineTextContext = context.inlineText();
				InlineTextGreen inlineText = null;
				if (inlineTextContext != null)
				{
					inlineText = (InlineTextGreen)this.Visit(inlineTextContext);
				}
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
			    MediaWikiParser.SpecialBlockOrParagraphContext[] specialBlockOrParagraphContext = context.specialBlockOrParagraph();
			    ArrayBuilder<SpecialBlockOrParagraphGreen> specialBlockOrParagraphBuilder = ArrayBuilder<SpecialBlockOrParagraphGreen>.GetInstance(specialBlockOrParagraphContext.Length);
			    for (int i = 0; i < specialBlockOrParagraphContext.Length; i++)
			    {
			        specialBlockOrParagraphBuilder.Add((SpecialBlockOrParagraphGreen)this.Visit(specialBlockOrParagraphContext[i]));
			    }
				InternalSyntaxNodeList specialBlockOrParagraph = InternalSyntaxNodeList.Create(specialBlockOrParagraphBuilder.ToArrayAndFree());
				return this.factory.TableCaption(tTableCaptionStart, inlineText, crlf, specialBlockOrParagraph, true);
			}
			
			public override GreenNode VisitTableRows(MediaWikiParser.TableRowsContext context)
			{
				if (context == null) return null;
				MediaWikiParser.TableFirstRowContext tableFirstRowContext = context.tableFirstRow();
				TableFirstRowGreen tableFirstRow = null;
				if (tableFirstRowContext != null)
				{
					tableFirstRow = (TableFirstRowGreen)this.Visit(tableFirstRowContext);
				}
			    MediaWikiParser.TableRowContext[] tableRowContext = context.tableRow();
			    ArrayBuilder<TableRowGreen> tableRowBuilder = ArrayBuilder<TableRowGreen>.GetInstance(tableRowContext.Length);
			    for (int i = 0; i < tableRowContext.Length; i++)
			    {
			        tableRowBuilder.Add((TableRowGreen)this.Visit(tableRowContext[i]));
			    }
				InternalSyntaxNodeList tableRow = InternalSyntaxNodeList.Create(tableRowBuilder.ToArrayAndFree());
				return this.factory.TableRows(tableFirstRow, tableRow, true);
			}
			
			public override GreenNode VisitTableFirstRow(MediaWikiParser.TableFirstRowContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.TableColumnContext[] tableColumnContext = context.tableColumn();
			    ArrayBuilder<TableColumnGreen> tableColumnBuilder = ArrayBuilder<TableColumnGreen>.GetInstance(tableColumnContext.Length);
			    for (int i = 0; i < tableColumnContext.Length; i++)
			    {
			        tableColumnBuilder.Add((TableColumnGreen)this.Visit(tableColumnContext[i]));
			    }
				InternalSyntaxNodeList tableColumn = InternalSyntaxNodeList.Create(tableColumnBuilder.ToArrayAndFree());
				return this.factory.TableFirstRow(tableColumn, true);
			}
			
			public override GreenNode VisitTableRow(MediaWikiParser.TableRowContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTableRowStart = (InternalSyntaxToken)this.VisitTerminal(context.TTableRowStart());
				MediaWikiParser.InlineTextContext inlineTextContext = context.inlineText();
				InlineTextGreen inlineText = null;
				if (inlineTextContext != null)
				{
					inlineText = (InlineTextGreen)this.Visit(inlineTextContext);
				}
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
			    MediaWikiParser.TableColumnContext[] tableColumnContext = context.tableColumn();
			    ArrayBuilder<TableColumnGreen> tableColumnBuilder = ArrayBuilder<TableColumnGreen>.GetInstance(tableColumnContext.Length);
			    for (int i = 0; i < tableColumnContext.Length; i++)
			    {
			        tableColumnBuilder.Add((TableColumnGreen)this.Visit(tableColumnContext[i]));
			    }
				InternalSyntaxNodeList tableColumn = InternalSyntaxNodeList.Create(tableColumnBuilder.ToArrayAndFree());
				return this.factory.TableRow(tTableRowStart, inlineText, crlf, tableColumn, true);
			}
			
			public override GreenNode VisitTableColumn(MediaWikiParser.TableColumnContext context)
			{
				if (context == null) return null;
				MediaWikiParser.TableSingleHeaderCellContext tableSingleHeaderCellContext = context.tableSingleHeaderCell();
				if (tableSingleHeaderCellContext != null) 
				{
					return this.factory.TableColumn((TableSingleHeaderCellGreen)this.Visit(tableSingleHeaderCellContext), true);
				}
				MediaWikiParser.TableHeaderCellsContext tableHeaderCellsContext = context.tableHeaderCells();
				if (tableHeaderCellsContext != null) 
				{
					return this.factory.TableColumn((TableHeaderCellsGreen)this.Visit(tableHeaderCellsContext), true);
				}
				MediaWikiParser.TableSingleCellContext tableSingleCellContext = context.tableSingleCell();
				if (tableSingleCellContext != null) 
				{
					return this.factory.TableColumn((TableSingleCellGreen)this.Visit(tableSingleCellContext), true);
				}
				MediaWikiParser.TableCellsContext tableCellsContext = context.tableCells();
				if (tableCellsContext != null) 
				{
					return this.factory.TableColumn((TableCellsGreen)this.Visit(tableCellsContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitTableSingleHeaderCell(MediaWikiParser.TableSingleHeaderCellContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tExclamation = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				MediaWikiParser.TableCellContext tableCellContext = context.tableCell();
				TableCellGreen tableCell = null;
				if (tableCellContext != null)
				{
					tableCell = (TableCellGreen)this.Visit(tableCellContext);
				}
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
			    MediaWikiParser.SpecialBlockOrParagraphContext[] specialBlockOrParagraphContext = context.specialBlockOrParagraph();
			    ArrayBuilder<SpecialBlockOrParagraphGreen> specialBlockOrParagraphBuilder = ArrayBuilder<SpecialBlockOrParagraphGreen>.GetInstance(specialBlockOrParagraphContext.Length);
			    for (int i = 0; i < specialBlockOrParagraphContext.Length; i++)
			    {
			        specialBlockOrParagraphBuilder.Add((SpecialBlockOrParagraphGreen)this.Visit(specialBlockOrParagraphContext[i]));
			    }
				InternalSyntaxNodeList specialBlockOrParagraph = InternalSyntaxNodeList.Create(specialBlockOrParagraphBuilder.ToArrayAndFree());
				return this.factory.TableSingleHeaderCell(tExclamation, tableCell, crlf, specialBlockOrParagraph, true);
			}
			
			public override GreenNode VisitTableHeaderCells(MediaWikiParser.TableHeaderCellsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tExclamation = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
			    MediaWikiParser.TableCellContext[] tableCellContext = context.tableCell();
			    ITerminalNode[] tExclExclContext = context.TExclExcl();
			    ArrayBuilder<GreenNode> tableCellBuilder = ArrayBuilder<GreenNode>.GetInstance(tableCellContext.Length+tExclExclContext.Length);
			    for (int i = 0; i < tableCellContext.Length; i++)
			    {
			        tableCellBuilder.Add((TableCellGreen)this.Visit(tableCellContext[i]));
			        if (i < tExclExclContext.Length)
			        {
			            tableCellBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tExclExclContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList tableCell = InternalSeparatedSyntaxNodeList.Create(tableCellBuilder.ToArrayAndFree());
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
			    MediaWikiParser.SpecialBlockOrParagraphContext[] specialBlockOrParagraphContext = context.specialBlockOrParagraph();
			    ArrayBuilder<SpecialBlockOrParagraphGreen> specialBlockOrParagraphBuilder = ArrayBuilder<SpecialBlockOrParagraphGreen>.GetInstance(specialBlockOrParagraphContext.Length);
			    for (int i = 0; i < specialBlockOrParagraphContext.Length; i++)
			    {
			        specialBlockOrParagraphBuilder.Add((SpecialBlockOrParagraphGreen)this.Visit(specialBlockOrParagraphContext[i]));
			    }
				InternalSyntaxNodeList specialBlockOrParagraph = InternalSyntaxNodeList.Create(specialBlockOrParagraphBuilder.ToArrayAndFree());
				return this.factory.TableHeaderCells(tExclamation, tableCell, crlf, specialBlockOrParagraph, true);
			}
			
			public override GreenNode VisitTableSingleCell(MediaWikiParser.TableSingleCellContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tBar = (InternalSyntaxToken)this.VisitTerminal(context.TBar());
				MediaWikiParser.TableCellContext tableCellContext = context.tableCell();
				TableCellGreen tableCell = null;
				if (tableCellContext != null)
				{
					tableCell = (TableCellGreen)this.Visit(tableCellContext);
				}
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
			    MediaWikiParser.SpecialBlockOrParagraphContext[] specialBlockOrParagraphContext = context.specialBlockOrParagraph();
			    ArrayBuilder<SpecialBlockOrParagraphGreen> specialBlockOrParagraphBuilder = ArrayBuilder<SpecialBlockOrParagraphGreen>.GetInstance(specialBlockOrParagraphContext.Length);
			    for (int i = 0; i < specialBlockOrParagraphContext.Length; i++)
			    {
			        specialBlockOrParagraphBuilder.Add((SpecialBlockOrParagraphGreen)this.Visit(specialBlockOrParagraphContext[i]));
			    }
				InternalSyntaxNodeList specialBlockOrParagraph = InternalSyntaxNodeList.Create(specialBlockOrParagraphBuilder.ToArrayAndFree());
				return this.factory.TableSingleCell(tBar, tableCell, crlf, specialBlockOrParagraph, true);
			}
			
			public override GreenNode VisitTableCells(MediaWikiParser.TableCellsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tBar = (InternalSyntaxToken)this.VisitTerminal(context.TBar());
			    MediaWikiParser.TableCellContext[] tableCellContext = context.tableCell();
			    ITerminalNode[] tBarBarContext = context.TBarBar();
			    ArrayBuilder<GreenNode> tableCellBuilder = ArrayBuilder<GreenNode>.GetInstance(tableCellContext.Length+tBarBarContext.Length);
			    for (int i = 0; i < tableCellContext.Length; i++)
			    {
			        tableCellBuilder.Add((TableCellGreen)this.Visit(tableCellContext[i]));
			        if (i < tBarBarContext.Length)
			        {
			            tableCellBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tBarBarContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList tableCell = InternalSeparatedSyntaxNodeList.Create(tableCellBuilder.ToArrayAndFree());
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
			    MediaWikiParser.SpecialBlockOrParagraphContext[] specialBlockOrParagraphContext = context.specialBlockOrParagraph();
			    ArrayBuilder<SpecialBlockOrParagraphGreen> specialBlockOrParagraphBuilder = ArrayBuilder<SpecialBlockOrParagraphGreen>.GetInstance(specialBlockOrParagraphContext.Length);
			    for (int i = 0; i < specialBlockOrParagraphContext.Length; i++)
			    {
			        specialBlockOrParagraphBuilder.Add((SpecialBlockOrParagraphGreen)this.Visit(specialBlockOrParagraphContext[i]));
			    }
				InternalSyntaxNodeList specialBlockOrParagraph = InternalSyntaxNodeList.Create(specialBlockOrParagraphBuilder.ToArrayAndFree());
				return this.factory.TableCells(tBar, tableCell, crlf, specialBlockOrParagraph, true);
			}
			
			public override GreenNode VisitTableCell(MediaWikiParser.TableCellContext context)
			{
				if (context == null) return null;
				MediaWikiParser.CellTextContext cellTextContext = context.cellText();
				CellTextGreen cellText = null;
				if (cellTextContext != null)
				{
					cellText = (CellTextGreen)this.Visit(cellTextContext);
				}
			    MediaWikiParser.CellTextOptContext[] cellTextOptContext = context.cellTextOpt();
			    ArrayBuilder<CellTextOptGreen> cellTextOptBuilder = ArrayBuilder<CellTextOptGreen>.GetInstance(cellTextOptContext.Length);
			    for (int i = 0; i < cellTextOptContext.Length; i++)
			    {
			        cellTextOptBuilder.Add((CellTextOptGreen)this.Visit(cellTextOptContext[i]));
			    }
				InternalSyntaxNodeList cellTextOpt = InternalSyntaxNodeList.Create(cellTextOptBuilder.ToArrayAndFree());
				return this.factory.TableCell(cellText, cellTextOpt, true);
			}
			
			public override GreenNode VisitCellTextOpt(MediaWikiParser.CellTextOptContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tBar = (InternalSyntaxToken)this.VisitTerminal(context.TBar());
				MediaWikiParser.CellTextContext cellTextContext = context.cellText();
				CellTextGreen cellText = null;
				if (cellTextContext != null)
				{
					cellText = (CellTextGreen)this.Visit(cellTextContext);
				}
				return this.factory.CellTextOpt(tBar, cellText, true);
			}
			
			public override GreenNode VisitParagraph(MediaWikiParser.ParagraphContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.TextLineContext[] textLineContext = context.textLine();
			    ArrayBuilder<TextLineGreen> textLineBuilder = ArrayBuilder<TextLineGreen>.GetInstance(textLineContext.Length);
			    for (int i = 0; i < textLineContext.Length; i++)
			    {
			        textLineBuilder.Add((TextLineGreen)this.Visit(textLineContext[i]));
			    }
				InternalSyntaxNodeList textLine = InternalSyntaxNodeList.Create(textLineBuilder.ToArrayAndFree());
				return this.factory.Paragraph(textLine, true);
			}
			
			public override GreenNode VisitTextLineInlineElementsWithComment(MediaWikiParser.TextLineInlineElementsWithCommentContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlCommentListContext leadingCommentContext = context.leadingComment;
				HtmlCommentListGreen leadingComment = null;
				if (leadingCommentContext != null)
				{
					leadingComment = (HtmlCommentListGreen)this.Visit(leadingCommentContext);
				}
			    MediaWikiParser.InlineTextElementContext[] inlineTextElementContext = context.inlineTextElement();
			    ArrayBuilder<InlineTextElementGreen> inlineTextElementBuilder = ArrayBuilder<InlineTextElementGreen>.GetInstance(inlineTextElementContext.Length);
			    for (int i = 0; i < inlineTextElementContext.Length; i++)
			    {
			        inlineTextElementBuilder.Add((InlineTextElementGreen)this.Visit(inlineTextElementContext[i]));
			    }
				InternalSyntaxNodeList inlineTextElement = InternalSyntaxNodeList.Create(inlineTextElementBuilder.ToArrayAndFree());
				MediaWikiParser.HtmlCommentListContext trailingCommentContext = context.trailingComment;
				HtmlCommentListGreen trailingComment = null;
				if (trailingCommentContext != null)
				{
					trailingComment = (HtmlCommentListGreen)this.Visit(trailingCommentContext);
				}
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
				return this.factory.TextLineInlineElementsWithComment(leadingComment, inlineTextElement, trailingComment, crlf, true);
			}
			
			public override GreenNode VisitTextLineComment(MediaWikiParser.TextLineCommentContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlCommentListContext htmlCommentListContext = context.htmlCommentList();
				HtmlCommentListGreen htmlCommentList = null;
				if (htmlCommentListContext != null)
				{
					htmlCommentList = (HtmlCommentListGreen)this.Visit(htmlCommentListContext);
				}
				InternalSyntaxToken crlf = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
				return this.factory.TextLineComment(htmlCommentList, crlf, true);
			}
			
			public override GreenNode VisitTextElements(MediaWikiParser.TextElementsContext context)
			{
				if (context == null) return null;
				MediaWikiParser.WikiFormatContext wikiFormatContext = context.wikiFormat();
				if (wikiFormatContext != null) 
				{
					return this.factory.TextElements((WikiFormatGreen)this.Visit(wikiFormatContext), true);
				}
				MediaWikiParser.WikiLinkContext wikiLinkContext = context.wikiLink();
				if (wikiLinkContext != null) 
				{
					return this.factory.TextElements((WikiLinkGreen)this.Visit(wikiLinkContext), true);
				}
				MediaWikiParser.WikiTemplateContext wikiTemplateContext = context.wikiTemplate();
				if (wikiTemplateContext != null) 
				{
					return this.factory.TextElements((WikiTemplateGreen)this.Visit(wikiTemplateContext), true);
				}
				MediaWikiParser.WikiTemplateParamContext wikiTemplateParamContext = context.wikiTemplateParam();
				if (wikiTemplateParamContext != null) 
				{
					return this.factory.TextElements((WikiTemplateParamGreen)this.Visit(wikiTemplateParamContext), true);
				}
				MediaWikiParser.NoWikiContext noWikiContext = context.noWiki();
				if (noWikiContext != null) 
				{
					return this.factory.TextElements((NoWikiGreen)this.Visit(noWikiContext), true);
				}
				MediaWikiParser.HtmlReferenceContext htmlReferenceContext = context.htmlReference();
				if (htmlReferenceContext != null) 
				{
					return this.factory.TextElements((HtmlReferenceGreen)this.Visit(htmlReferenceContext), true);
				}
				MediaWikiParser.HtmlStyleContext htmlStyleContext = context.htmlStyle();
				if (htmlStyleContext != null) 
				{
					return this.factory.TextElements((HtmlStyleGreen)this.Visit(htmlStyleContext), true);
				}
				MediaWikiParser.HtmlScriptContext htmlScriptContext = context.htmlScript();
				if (htmlScriptContext != null) 
				{
					return this.factory.TextElements((HtmlScriptGreen)this.Visit(htmlScriptContext), true);
				}
				MediaWikiParser.HtmlTagContext htmlTagContext = context.htmlTag();
				if (htmlTagContext != null) 
				{
					return this.factory.TextElements((HtmlTagGreen)this.Visit(htmlTagContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitInlineText(MediaWikiParser.InlineTextContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.InlineTextElementWithCommentContext[] inlineTextElementWithCommentContext = context.inlineTextElementWithComment();
			    ArrayBuilder<InlineTextElementWithCommentGreen> inlineTextElementWithCommentBuilder = ArrayBuilder<InlineTextElementWithCommentGreen>.GetInstance(inlineTextElementWithCommentContext.Length);
			    for (int i = 0; i < inlineTextElementWithCommentContext.Length; i++)
			    {
			        inlineTextElementWithCommentBuilder.Add((InlineTextElementWithCommentGreen)this.Visit(inlineTextElementWithCommentContext[i]));
			    }
				InternalSyntaxNodeList inlineTextElementWithComment = InternalSyntaxNodeList.Create(inlineTextElementWithCommentBuilder.ToArrayAndFree());
				MediaWikiParser.HtmlCommentListContext trailingCommentContext = context.trailingComment;
				HtmlCommentListGreen trailingComment = null;
				if (trailingCommentContext != null)
				{
					trailingComment = (HtmlCommentListGreen)this.Visit(trailingCommentContext);
				}
				return this.factory.InlineText(inlineTextElementWithComment, trailingComment, true);
			}
			
			public override GreenNode VisitInlineTextElementWithComment(MediaWikiParser.InlineTextElementWithCommentContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlCommentListContext leadingCommentContext = context.leadingComment;
				HtmlCommentListGreen leadingComment = null;
				if (leadingCommentContext != null)
				{
					leadingComment = (HtmlCommentListGreen)this.Visit(leadingCommentContext);
				}
				MediaWikiParser.InlineTextElementContext inlineTextElementContext = context.inlineTextElement();
				InlineTextElementGreen inlineTextElement = null;
				if (inlineTextElementContext != null)
				{
					inlineTextElement = (InlineTextElementGreen)this.Visit(inlineTextElementContext);
				}
				return this.factory.InlineTextElementWithComment(leadingComment, inlineTextElement, true);
			}
			
			public override GreenNode VisitInlineTextElement(MediaWikiParser.InlineTextElementContext context)
			{
				if (context == null) return null;
				MediaWikiParser.TextElementsContext textElementsContext = context.textElements();
				if (textElementsContext != null) 
				{
					return this.factory.InlineTextElement((TextElementsGreen)this.Visit(textElementsContext), true);
				}
				MediaWikiParser.InlineTextElementsContext inlineTextElementsContext = context.inlineTextElements();
				if (inlineTextElementsContext != null) 
				{
					return this.factory.InlineTextElement((InlineTextElementsGreen)this.Visit(inlineTextElementsContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitInlineTextElements(MediaWikiParser.InlineTextElementsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken inlineTextElements = null;
				if (context.TNormalText() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TNormalText());
				}
				else 	if (context.TWhiteSpace() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TWhiteSpace());
				}
				else 	if (context.TComma() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TComma());
				}
				else 	if (context.TBar() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TBar());
				}
				else 	if (context.TBarBar() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TBarBar());
				}
				else 	if (context.TExclamation() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				}
				else 	if (context.TExclExcl() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TExclExcl());
				}
				else 	if (context.TApos() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TApos());
				}
				else 	if (context.TColon() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				}
				else 	if (context.TSpecialChars() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TSpecialChars());
				}
				else 	if (context.THeading() != null)
				{
					inlineTextElements = (InternalSyntaxToken)this.VisitTerminal(context.THeading());
				}
				return this.factory.InlineTextElements(inlineTextElements, true);
			}
			
			public override GreenNode VisitDefinitionText(MediaWikiParser.DefinitionTextContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.DefinitionTextElementWithCommentContext[] definitionTextElementWithCommentContext = context.definitionTextElementWithComment();
			    ArrayBuilder<DefinitionTextElementWithCommentGreen> definitionTextElementWithCommentBuilder = ArrayBuilder<DefinitionTextElementWithCommentGreen>.GetInstance(definitionTextElementWithCommentContext.Length);
			    for (int i = 0; i < definitionTextElementWithCommentContext.Length; i++)
			    {
			        definitionTextElementWithCommentBuilder.Add((DefinitionTextElementWithCommentGreen)this.Visit(definitionTextElementWithCommentContext[i]));
			    }
				InternalSyntaxNodeList definitionTextElementWithComment = InternalSyntaxNodeList.Create(definitionTextElementWithCommentBuilder.ToArrayAndFree());
				MediaWikiParser.HtmlCommentListContext trailingCommentContext = context.trailingComment;
				HtmlCommentListGreen trailingComment = null;
				if (trailingCommentContext != null)
				{
					trailingComment = (HtmlCommentListGreen)this.Visit(trailingCommentContext);
				}
				return this.factory.DefinitionText(definitionTextElementWithComment, trailingComment, true);
			}
			
			public override GreenNode VisitDefinitionTextElementWithComment(MediaWikiParser.DefinitionTextElementWithCommentContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlCommentListContext leadingCommentContext = context.leadingComment;
				HtmlCommentListGreen leadingComment = null;
				if (leadingCommentContext != null)
				{
					leadingComment = (HtmlCommentListGreen)this.Visit(leadingCommentContext);
				}
				MediaWikiParser.DefinitionTextElementContext definitionTextElementContext = context.definitionTextElement();
				DefinitionTextElementGreen definitionTextElement = null;
				if (definitionTextElementContext != null)
				{
					definitionTextElement = (DefinitionTextElementGreen)this.Visit(definitionTextElementContext);
				}
				return this.factory.DefinitionTextElementWithComment(leadingComment, definitionTextElement, true);
			}
			
			public override GreenNode VisitDefinitionTextElement(MediaWikiParser.DefinitionTextElementContext context)
			{
				if (context == null) return null;
				MediaWikiParser.TextElementsContext textElementsContext = context.textElements();
				if (textElementsContext != null) 
				{
					return this.factory.DefinitionTextElement((TextElementsGreen)this.Visit(textElementsContext), true);
				}
				MediaWikiParser.DefinitionTextElementsContext definitionTextElementsContext = context.definitionTextElements();
				if (definitionTextElementsContext != null) 
				{
					return this.factory.DefinitionTextElement((DefinitionTextElementsGreen)this.Visit(definitionTextElementsContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitDefinitionTextElements(MediaWikiParser.DefinitionTextElementsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken definitionTextElements = null;
				if (context.TNormalText() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TNormalText());
				}
				else 	if (context.TWhiteSpace() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TWhiteSpace());
				}
				else 	if (context.TComma() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TComma());
				}
				else 	if (context.TBar() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TBar());
				}
				else 	if (context.TBarBar() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TBarBar());
				}
				else 	if (context.TExclamation() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				}
				else 	if (context.TExclExcl() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TExclExcl());
				}
				else 	if (context.TApos() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TApos());
				}
				else 	if (context.TSpecialChars() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TSpecialChars());
				}
				else 	if (context.THeading() != null)
				{
					definitionTextElements = (InternalSyntaxToken)this.VisitTerminal(context.THeading());
				}
				return this.factory.DefinitionTextElements(definitionTextElements, true);
			}
			
			public override GreenNode VisitHeadingText(MediaWikiParser.HeadingTextContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.HeadingTextWithCommentContext[] headingTextWithCommentContext = context.headingTextWithComment();
			    ArrayBuilder<HeadingTextWithCommentGreen> headingTextWithCommentBuilder = ArrayBuilder<HeadingTextWithCommentGreen>.GetInstance(headingTextWithCommentContext.Length);
			    for (int i = 0; i < headingTextWithCommentContext.Length; i++)
			    {
			        headingTextWithCommentBuilder.Add((HeadingTextWithCommentGreen)this.Visit(headingTextWithCommentContext[i]));
			    }
				InternalSyntaxNodeList headingTextWithComment = InternalSyntaxNodeList.Create(headingTextWithCommentBuilder.ToArrayAndFree());
				MediaWikiParser.HtmlCommentListContext trailingCommentContext = context.trailingComment;
				HtmlCommentListGreen trailingComment = null;
				if (trailingCommentContext != null)
				{
					trailingComment = (HtmlCommentListGreen)this.Visit(trailingCommentContext);
				}
				return this.factory.HeadingText(headingTextWithComment, trailingComment, true);
			}
			
			public override GreenNode VisitHeadingTextWithComment(MediaWikiParser.HeadingTextWithCommentContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlCommentListContext leadingCommentContext = context.leadingComment;
				HtmlCommentListGreen leadingComment = null;
				if (leadingCommentContext != null)
				{
					leadingComment = (HtmlCommentListGreen)this.Visit(leadingCommentContext);
				}
				MediaWikiParser.HeadingTextElementContext headingTextElementContext = context.headingTextElement();
				HeadingTextElementGreen headingTextElement = null;
				if (headingTextElementContext != null)
				{
					headingTextElement = (HeadingTextElementGreen)this.Visit(headingTextElementContext);
				}
				return this.factory.HeadingTextWithComment(leadingComment, headingTextElement, true);
			}
			
			public override GreenNode VisitHeadingTextElement(MediaWikiParser.HeadingTextElementContext context)
			{
				if (context == null) return null;
				MediaWikiParser.TextElementsContext textElementsContext = context.textElements();
				if (textElementsContext != null) 
				{
					return this.factory.HeadingTextElement((TextElementsGreen)this.Visit(textElementsContext), true);
				}
				MediaWikiParser.HeadingTextElementsContext headingTextElementsContext = context.headingTextElements();
				if (headingTextElementsContext != null) 
				{
					return this.factory.HeadingTextElement((HeadingTextElementsGreen)this.Visit(headingTextElementsContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitHeadingTextElements(MediaWikiParser.HeadingTextElementsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken headingTextElements = null;
				if (context.TNormalText() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TNormalText());
				}
				else 	if (context.TWhiteSpace() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TWhiteSpace());
				}
				else 	if (context.TComma() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TComma());
				}
				else 	if (context.TBar() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TBar());
				}
				else 	if (context.TBarBar() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TBarBar());
				}
				else 	if (context.TExclamation() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				}
				else 	if (context.TExclExcl() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TExclExcl());
				}
				else 	if (context.TApos() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TApos());
				}
				else 	if (context.TColon() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				}
				else 	if (context.TSpecialChars() != null)
				{
					headingTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TSpecialChars());
				}
				return this.factory.HeadingTextElements(headingTextElements, true);
			}
			
			public override GreenNode VisitCellText(MediaWikiParser.CellTextContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.CellTextElementWithCommentContext[] cellTextElementWithCommentContext = context.cellTextElementWithComment();
			    ArrayBuilder<CellTextElementWithCommentGreen> cellTextElementWithCommentBuilder = ArrayBuilder<CellTextElementWithCommentGreen>.GetInstance(cellTextElementWithCommentContext.Length);
			    for (int i = 0; i < cellTextElementWithCommentContext.Length; i++)
			    {
			        cellTextElementWithCommentBuilder.Add((CellTextElementWithCommentGreen)this.Visit(cellTextElementWithCommentContext[i]));
			    }
				InternalSyntaxNodeList cellTextElementWithComment = InternalSyntaxNodeList.Create(cellTextElementWithCommentBuilder.ToArrayAndFree());
				MediaWikiParser.HtmlCommentListContext trailingCommentContext = context.trailingComment;
				HtmlCommentListGreen trailingComment = null;
				if (trailingCommentContext != null)
				{
					trailingComment = (HtmlCommentListGreen)this.Visit(trailingCommentContext);
				}
				return this.factory.CellText(cellTextElementWithComment, trailingComment, true);
			}
			
			public override GreenNode VisitCellTextElementWithComment(MediaWikiParser.CellTextElementWithCommentContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlCommentListContext leadingCommentContext = context.leadingComment;
				HtmlCommentListGreen leadingComment = null;
				if (leadingCommentContext != null)
				{
					leadingComment = (HtmlCommentListGreen)this.Visit(leadingCommentContext);
				}
				MediaWikiParser.CellTextElementContext cellTextElementContext = context.cellTextElement();
				CellTextElementGreen cellTextElement = null;
				if (cellTextElementContext != null)
				{
					cellTextElement = (CellTextElementGreen)this.Visit(cellTextElementContext);
				}
				return this.factory.CellTextElementWithComment(leadingComment, cellTextElement, true);
			}
			
			public override GreenNode VisitCellTextElement(MediaWikiParser.CellTextElementContext context)
			{
				if (context == null) return null;
				MediaWikiParser.TextElementsContext textElementsContext = context.textElements();
				if (textElementsContext != null) 
				{
					return this.factory.CellTextElement((TextElementsGreen)this.Visit(textElementsContext), true);
				}
				MediaWikiParser.CellTextElementsContext cellTextElementsContext = context.cellTextElements();
				if (cellTextElementsContext != null) 
				{
					return this.factory.CellTextElement((CellTextElementsGreen)this.Visit(cellTextElementsContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitCellTextElements(MediaWikiParser.CellTextElementsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken cellTextElements = null;
				if (context.TNormalText() != null)
				{
					cellTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TNormalText());
				}
				else 	if (context.TWhiteSpace() != null)
				{
					cellTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TWhiteSpace());
				}
				else 	if (context.TComma() != null)
				{
					cellTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TComma());
				}
				else 	if (context.TApos() != null)
				{
					cellTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TApos());
				}
				else 	if (context.TColon() != null)
				{
					cellTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				}
				else 	if (context.TSpecialChars() != null)
				{
					cellTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TSpecialChars());
				}
				else 	if (context.THeading() != null)
				{
					cellTextElements = (InternalSyntaxToken)this.VisitTerminal(context.THeading());
				}
				return this.factory.CellTextElements(cellTextElements, true);
			}
			
			public override GreenNode VisitLinkText(MediaWikiParser.LinkTextContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.LinkTextWithCommentContext[] linkTextWithCommentContext = context.linkTextWithComment();
			    ArrayBuilder<LinkTextWithCommentGreen> linkTextWithCommentBuilder = ArrayBuilder<LinkTextWithCommentGreen>.GetInstance(linkTextWithCommentContext.Length);
			    for (int i = 0; i < linkTextWithCommentContext.Length; i++)
			    {
			        linkTextWithCommentBuilder.Add((LinkTextWithCommentGreen)this.Visit(linkTextWithCommentContext[i]));
			    }
				InternalSyntaxNodeList linkTextWithComment = InternalSyntaxNodeList.Create(linkTextWithCommentBuilder.ToArrayAndFree());
				MediaWikiParser.HtmlCommentListContext trailingCommentContext = context.trailingComment;
				HtmlCommentListGreen trailingComment = null;
				if (trailingCommentContext != null)
				{
					trailingComment = (HtmlCommentListGreen)this.Visit(trailingCommentContext);
				}
				return this.factory.LinkText(linkTextWithComment, trailingComment, true);
			}
			
			public override GreenNode VisitLinkTextWithComment(MediaWikiParser.LinkTextWithCommentContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlCommentListContext leadingCommentContext = context.leadingComment;
				HtmlCommentListGreen leadingComment = null;
				if (leadingCommentContext != null)
				{
					leadingComment = (HtmlCommentListGreen)this.Visit(leadingCommentContext);
				}
				MediaWikiParser.LinkTextElementContext linkTextElementContext = context.linkTextElement();
				LinkTextElementGreen linkTextElement = null;
				if (linkTextElementContext != null)
				{
					linkTextElement = (LinkTextElementGreen)this.Visit(linkTextElementContext);
				}
				return this.factory.LinkTextWithComment(leadingComment, linkTextElement, true);
			}
			
			public override GreenNode VisitLinkTextElement(MediaWikiParser.LinkTextElementContext context)
			{
				if (context == null) return null;
				MediaWikiParser.TextElementsContext textElementsContext = context.textElements();
				if (textElementsContext != null) 
				{
					return this.factory.LinkTextElement((TextElementsGreen)this.Visit(textElementsContext), true);
				}
				MediaWikiParser.LinkTextElementsContext linkTextElementsContext = context.linkTextElements();
				if (linkTextElementsContext != null) 
				{
					return this.factory.LinkTextElement((LinkTextElementsGreen)this.Visit(linkTextElementsContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitLinkTextElements(MediaWikiParser.LinkTextElementsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken linkTextElements = null;
				if (context.TNormalText() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TNormalText());
				}
				else 	if (context.TWhiteSpace() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TWhiteSpace());
				}
				else 	if (context.TComma() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TComma());
				}
				else 	if (context.TExclamation() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				}
				else 	if (context.TExclExcl() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TExclExcl());
				}
				else 	if (context.TApos() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TApos());
				}
				else 	if (context.TColon() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				}
				else 	if (context.TSpecialChars() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.TSpecialChars());
				}
				else 	if (context.THeading() != null)
				{
					linkTextElements = (InternalSyntaxToken)this.VisitTerminal(context.THeading());
				}
				return this.factory.LinkTextElements(linkTextElements, true);
			}
			
			public override GreenNode VisitWikiFormat(MediaWikiParser.WikiFormatContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tFormat = (InternalSyntaxToken)this.VisitTerminal(context.TFormat());
				return this.factory.WikiFormat(tFormat, true);
			}
			
			public override GreenNode VisitWikiLink(MediaWikiParser.WikiLinkContext context)
			{
				if (context == null) return null;
				MediaWikiParser.WikiInternalLinkContext wikiInternalLinkContext = context.wikiInternalLink();
				if (wikiInternalLinkContext != null) 
				{
					return this.factory.WikiLink((WikiInternalLinkGreen)this.Visit(wikiInternalLinkContext), true);
				}
				MediaWikiParser.WikiExternalLinkContext wikiExternalLinkContext = context.wikiExternalLink();
				if (wikiExternalLinkContext != null) 
				{
					return this.factory.WikiLink((WikiExternalLinkGreen)this.Visit(wikiExternalLinkContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitWikiInternalLink(MediaWikiParser.WikiInternalLinkContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tLinkStart = (InternalSyntaxToken)this.VisitTerminal(context.TLinkStart());
				MediaWikiParser.LinkTextContext linkTextContext = context.linkText();
				LinkTextGreen linkText = null;
				if (linkTextContext != null)
				{
					linkText = (LinkTextGreen)this.Visit(linkTextContext);
				}
			    MediaWikiParser.LinkTextPartContext[] linkTextPartContext = context.linkTextPart();
			    ArrayBuilder<LinkTextPartGreen> linkTextPartBuilder = ArrayBuilder<LinkTextPartGreen>.GetInstance(linkTextPartContext.Length);
			    for (int i = 0; i < linkTextPartContext.Length; i++)
			    {
			        linkTextPartBuilder.Add((LinkTextPartGreen)this.Visit(linkTextPartContext[i]));
			    }
				InternalSyntaxNodeList linkTextPart = InternalSyntaxNodeList.Create(linkTextPartBuilder.ToArrayAndFree());
				InternalSyntaxToken tLinkEnd = (InternalSyntaxToken)this.VisitTerminal(context.TLinkEnd());
				return this.factory.WikiInternalLink(tLinkStart, linkText, linkTextPart, tLinkEnd, true);
			}
			
			public override GreenNode VisitWikiExternalLink(MediaWikiParser.WikiExternalLinkContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tExternalLinkStart = (InternalSyntaxToken)this.VisitTerminal(context.TExternalLinkStart());
				MediaWikiParser.LinkTextContext linkTextContext = context.linkText();
				LinkTextGreen linkText = null;
				if (linkTextContext != null)
				{
					linkText = (LinkTextGreen)this.Visit(linkTextContext);
				}
			    MediaWikiParser.LinkTextPartContext[] linkTextPartContext = context.linkTextPart();
			    ArrayBuilder<LinkTextPartGreen> linkTextPartBuilder = ArrayBuilder<LinkTextPartGreen>.GetInstance(linkTextPartContext.Length);
			    for (int i = 0; i < linkTextPartContext.Length; i++)
			    {
			        linkTextPartBuilder.Add((LinkTextPartGreen)this.Visit(linkTextPartContext[i]));
			    }
				InternalSyntaxNodeList linkTextPart = InternalSyntaxNodeList.Create(linkTextPartBuilder.ToArrayAndFree());
				InternalSyntaxToken tExternalLinkEnd = (InternalSyntaxToken)this.VisitTerminal(context.TExternalLinkEnd());
				return this.factory.WikiExternalLink(tExternalLinkStart, linkText, linkTextPart, tExternalLinkEnd, true);
			}
			
			public override GreenNode VisitWikiTemplate(MediaWikiParser.WikiTemplateContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTemplateStart = (InternalSyntaxToken)this.VisitTerminal(context.TTemplateStart());
				MediaWikiParser.LinkTextContext linkTextContext = context.linkText();
				LinkTextGreen linkText = null;
				if (linkTextContext != null)
				{
					linkText = (LinkTextGreen)this.Visit(linkTextContext);
				}
			    MediaWikiParser.LinkTextPartContext[] linkTextPartContext = context.linkTextPart();
			    ArrayBuilder<LinkTextPartGreen> linkTextPartBuilder = ArrayBuilder<LinkTextPartGreen>.GetInstance(linkTextPartContext.Length);
			    for (int i = 0; i < linkTextPartContext.Length; i++)
			    {
			        linkTextPartBuilder.Add((LinkTextPartGreen)this.Visit(linkTextPartContext[i]));
			    }
				InternalSyntaxNodeList linkTextPart = InternalSyntaxNodeList.Create(linkTextPartBuilder.ToArrayAndFree());
				InternalSyntaxToken tTemplateEnd = (InternalSyntaxToken)this.VisitTerminal(context.TTemplateEnd());
				return this.factory.WikiTemplate(tTemplateStart, linkText, linkTextPart, tTemplateEnd, true);
			}
			
			public override GreenNode VisitWikiTemplateParam(MediaWikiParser.WikiTemplateParamContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTemplateParamStart = (InternalSyntaxToken)this.VisitTerminal(context.TTemplateParamStart());
				MediaWikiParser.LinkTextContext linkTextContext = context.linkText();
				LinkTextGreen linkText = null;
				if (linkTextContext != null)
				{
					linkText = (LinkTextGreen)this.Visit(linkTextContext);
				}
			    MediaWikiParser.LinkTextPartContext[] linkTextPartContext = context.linkTextPart();
			    ArrayBuilder<LinkTextPartGreen> linkTextPartBuilder = ArrayBuilder<LinkTextPartGreen>.GetInstance(linkTextPartContext.Length);
			    for (int i = 0; i < linkTextPartContext.Length; i++)
			    {
			        linkTextPartBuilder.Add((LinkTextPartGreen)this.Visit(linkTextPartContext[i]));
			    }
				InternalSyntaxNodeList linkTextPart = InternalSyntaxNodeList.Create(linkTextPartBuilder.ToArrayAndFree());
				InternalSyntaxToken tTemplateParamEnd = (InternalSyntaxToken)this.VisitTerminal(context.TTemplateParamEnd());
				return this.factory.WikiTemplateParam(tTemplateParamStart, linkText, linkTextPart, tTemplateParamEnd, true);
			}
			
			public override GreenNode VisitNoWiki(MediaWikiParser.NoWikiContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tNoWiki = (InternalSyntaxToken)this.VisitTerminal(context.TNoWiki());
				return this.factory.NoWiki(tNoWiki, true);
			}
			
			public override GreenNode VisitBarOrBarBar(MediaWikiParser.BarOrBarBarContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken barOrBarBar = null;
				if (context.TBar() != null)
				{
					barOrBarBar = (InternalSyntaxToken)this.VisitTerminal(context.TBar());
				}
				else 	if (context.TBarBar() != null)
				{
					barOrBarBar = (InternalSyntaxToken)this.VisitTerminal(context.TBarBar());
				}
				return this.factory.BarOrBarBar(barOrBarBar, true);
			}
			
			public override GreenNode VisitLinkTextPart(MediaWikiParser.LinkTextPartContext context)
			{
				if (context == null) return null;
				MediaWikiParser.BarOrBarBarContext barOrBarBarContext = context.barOrBarBar();
				BarOrBarBarGreen barOrBarBar = null;
				if (barOrBarBarContext != null)
				{
					barOrBarBar = (BarOrBarBarGreen)this.Visit(barOrBarBarContext);
				}
				MediaWikiParser.LinkTextContext linkTextContext = context.linkText();
				LinkTextGreen linkText = null;
				if (linkTextContext != null)
				{
					linkText = (LinkTextGreen)this.Visit(linkTextContext);
				}
				return this.factory.LinkTextPart(barOrBarBar, linkText, true);
			}
			
			public override GreenNode VisitHtmlReference(MediaWikiParser.HtmlReferenceContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken htmlReference = null;
				if (context.TEntityRef() != null)
				{
					htmlReference = (InternalSyntaxToken)this.VisitTerminal(context.TEntityRef());
				}
				else 	if (context.TCharRef() != null)
				{
					htmlReference = (InternalSyntaxToken)this.VisitTerminal(context.TCharRef());
				}
				return this.factory.HtmlReference(htmlReference, true);
			}
			
			public override GreenNode VisitHtmlCommentList(MediaWikiParser.HtmlCommentListContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.HtmlCommentContext[] htmlCommentContext = context.htmlComment();
			    ArrayBuilder<HtmlCommentGreen> htmlCommentBuilder = ArrayBuilder<HtmlCommentGreen>.GetInstance(htmlCommentContext.Length);
			    for (int i = 0; i < htmlCommentContext.Length; i++)
			    {
			        htmlCommentBuilder.Add((HtmlCommentGreen)this.Visit(htmlCommentContext[i]));
			    }
				InternalSyntaxNodeList htmlComment = InternalSyntaxNodeList.Create(htmlCommentBuilder.ToArrayAndFree());
				return this.factory.HtmlCommentList(htmlComment, true);
			}
			
			public override GreenNode VisitHtmlComment(MediaWikiParser.HtmlCommentContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tHtmlComment = (InternalSyntaxToken)this.VisitTerminal(context.THtmlComment());
				return this.factory.HtmlComment(tHtmlComment, true);
			}
			
			public override GreenNode VisitHtmlStyle(MediaWikiParser.HtmlStyleContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tHtmlStyle = (InternalSyntaxToken)this.VisitTerminal(context.THtmlStyle());
				return this.factory.HtmlStyle(tHtmlStyle, true);
			}
			
			public override GreenNode VisitHtmlScript(MediaWikiParser.HtmlScriptContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tHtmlScript = (InternalSyntaxToken)this.VisitTerminal(context.THtmlScript());
				return this.factory.HtmlScript(tHtmlScript, true);
			}
			
			public override GreenNode VisitHtmlTag(MediaWikiParser.HtmlTagContext context)
			{
				if (context == null) return null;
				MediaWikiParser.HtmlTagOpenContext htmlTagOpenContext = context.htmlTagOpen();
				if (htmlTagOpenContext != null) 
				{
					return this.factory.HtmlTag((HtmlTagOpenGreen)this.Visit(htmlTagOpenContext), true);
				}
				MediaWikiParser.HtmlTagCloseContext htmlTagCloseContext = context.htmlTagClose();
				if (htmlTagCloseContext != null) 
				{
					return this.factory.HtmlTag((HtmlTagCloseGreen)this.Visit(htmlTagCloseContext), true);
				}
				MediaWikiParser.HtmlTagEmptyContext htmlTagEmptyContext = context.htmlTagEmpty();
				if (htmlTagEmptyContext != null) 
				{
					return this.factory.HtmlTag((HtmlTagEmptyGreen)this.Visit(htmlTagEmptyContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitHtmlTagOpen(MediaWikiParser.HtmlTagOpenContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTagStart = (InternalSyntaxToken)this.VisitTerminal(context.TTagStart());
				MediaWikiParser.WhitespaceListContext leadingWhitespaceContext = context.leadingWhitespace;
				WhitespaceListGreen leadingWhitespace = null;
				if (leadingWhitespaceContext != null)
				{
					leadingWhitespace = (WhitespaceListGreen)this.Visit(leadingWhitespaceContext);
				}
				MediaWikiParser.HtmlTagNameContext htmlTagNameContext = context.htmlTagName();
				HtmlTagNameGreen htmlTagName = null;
				if (htmlTagNameContext != null)
				{
					htmlTagName = (HtmlTagNameGreen)this.Visit(htmlTagNameContext);
				}
			    MediaWikiParser.HtmlAttributeContext[] htmlAttributeContext = context.htmlAttribute();
			    ArrayBuilder<HtmlAttributeGreen> htmlAttributeBuilder = ArrayBuilder<HtmlAttributeGreen>.GetInstance(htmlAttributeContext.Length);
			    for (int i = 0; i < htmlAttributeContext.Length; i++)
			    {
			        htmlAttributeBuilder.Add((HtmlAttributeGreen)this.Visit(htmlAttributeContext[i]));
			    }
				InternalSyntaxNodeList htmlAttribute = InternalSyntaxNodeList.Create(htmlAttributeBuilder.ToArrayAndFree());
				MediaWikiParser.WhitespaceListContext trailingWhitespaceContext = context.trailingWhitespace;
				WhitespaceListGreen trailingWhitespace = null;
				if (trailingWhitespaceContext != null)
				{
					trailingWhitespace = (WhitespaceListGreen)this.Visit(trailingWhitespaceContext);
				}
				InternalSyntaxToken tTagEnd = (InternalSyntaxToken)this.VisitTerminal(context.TTagEnd());
				return this.factory.HtmlTagOpen(tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagEnd, true);
			}
			
			public override GreenNode VisitHtmlTagClose(MediaWikiParser.HtmlTagCloseContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tEndTagStart = (InternalSyntaxToken)this.VisitTerminal(context.TEndTagStart());
				MediaWikiParser.WhitespaceListContext leadingWhitespaceContext = context.leadingWhitespace;
				WhitespaceListGreen leadingWhitespace = null;
				if (leadingWhitespaceContext != null)
				{
					leadingWhitespace = (WhitespaceListGreen)this.Visit(leadingWhitespaceContext);
				}
				MediaWikiParser.HtmlTagNameContext htmlTagNameContext = context.htmlTagName();
				HtmlTagNameGreen htmlTagName = null;
				if (htmlTagNameContext != null)
				{
					htmlTagName = (HtmlTagNameGreen)this.Visit(htmlTagNameContext);
				}
			    MediaWikiParser.HtmlAttributeContext[] htmlAttributeContext = context.htmlAttribute();
			    ArrayBuilder<HtmlAttributeGreen> htmlAttributeBuilder = ArrayBuilder<HtmlAttributeGreen>.GetInstance(htmlAttributeContext.Length);
			    for (int i = 0; i < htmlAttributeContext.Length; i++)
			    {
			        htmlAttributeBuilder.Add((HtmlAttributeGreen)this.Visit(htmlAttributeContext[i]));
			    }
				InternalSyntaxNodeList htmlAttribute = InternalSyntaxNodeList.Create(htmlAttributeBuilder.ToArrayAndFree());
				MediaWikiParser.WhitespaceListContext trailingWhitespaceContext = context.trailingWhitespace;
				WhitespaceListGreen trailingWhitespace = null;
				if (trailingWhitespaceContext != null)
				{
					trailingWhitespace = (WhitespaceListGreen)this.Visit(trailingWhitespaceContext);
				}
				InternalSyntaxToken tEndTagEnd = (InternalSyntaxToken)this.VisitTerminal(context.TEndTagEnd());
				return this.factory.HtmlTagClose(tEndTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tEndTagEnd, true);
			}
			
			public override GreenNode VisitHtmlTagEmpty(MediaWikiParser.HtmlTagEmptyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTagStart = (InternalSyntaxToken)this.VisitTerminal(context.TTagStart());
				MediaWikiParser.WhitespaceListContext leadingWhitespaceContext = context.leadingWhitespace;
				WhitespaceListGreen leadingWhitespace = null;
				if (leadingWhitespaceContext != null)
				{
					leadingWhitespace = (WhitespaceListGreen)this.Visit(leadingWhitespaceContext);
				}
				MediaWikiParser.HtmlTagNameContext htmlTagNameContext = context.htmlTagName();
				HtmlTagNameGreen htmlTagName = null;
				if (htmlTagNameContext != null)
				{
					htmlTagName = (HtmlTagNameGreen)this.Visit(htmlTagNameContext);
				}
			    MediaWikiParser.HtmlAttributeContext[] htmlAttributeContext = context.htmlAttribute();
			    ArrayBuilder<HtmlAttributeGreen> htmlAttributeBuilder = ArrayBuilder<HtmlAttributeGreen>.GetInstance(htmlAttributeContext.Length);
			    for (int i = 0; i < htmlAttributeContext.Length; i++)
			    {
			        htmlAttributeBuilder.Add((HtmlAttributeGreen)this.Visit(htmlAttributeContext[i]));
			    }
				InternalSyntaxNodeList htmlAttribute = InternalSyntaxNodeList.Create(htmlAttributeBuilder.ToArrayAndFree());
				MediaWikiParser.WhitespaceListContext trailingWhitespaceContext = context.trailingWhitespace;
				WhitespaceListGreen trailingWhitespace = null;
				if (trailingWhitespaceContext != null)
				{
					trailingWhitespace = (WhitespaceListGreen)this.Visit(trailingWhitespaceContext);
				}
				InternalSyntaxToken tTagCloseEnd = (InternalSyntaxToken)this.VisitTerminal(context.TTagCloseEnd());
				return this.factory.HtmlTagEmpty(tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagCloseEnd, true);
			}
			
			public override GreenNode VisitHtmlAttributeWithValue(MediaWikiParser.HtmlAttributeWithValueContext context)
			{
				if (context == null) return null;
				MediaWikiParser.WhitespaceListContext leadingWhitespaceContext = context.leadingWhitespace;
				WhitespaceListGreen leadingWhitespace = null;
				if (leadingWhitespaceContext != null)
				{
					leadingWhitespace = (WhitespaceListGreen)this.Visit(leadingWhitespaceContext);
				}
				MediaWikiParser.HtmlAttributeNameContext htmlAttributeNameContext = context.htmlAttributeName();
				HtmlAttributeNameGreen htmlAttributeName = null;
				if (htmlAttributeNameContext != null)
				{
					htmlAttributeName = (HtmlAttributeNameGreen)this.Visit(htmlAttributeNameContext);
				}
				MediaWikiParser.WhitespaceListContext whitespaceBeforeEqualsContext = context.whitespaceBeforeEquals;
				WhitespaceListGreen whitespaceBeforeEquals = null;
				if (whitespaceBeforeEqualsContext != null)
				{
					whitespaceBeforeEquals = (WhitespaceListGreen)this.Visit(whitespaceBeforeEqualsContext);
				}
				InternalSyntaxToken tAttributeEquals = (InternalSyntaxToken)this.VisitTerminal(context.TAttributeEquals());
				MediaWikiParser.WhitespaceListContext whitespaceAfterEqualsContext = context.whitespaceAfterEquals;
				WhitespaceListGreen whitespaceAfterEquals = null;
				if (whitespaceAfterEqualsContext != null)
				{
					whitespaceAfterEquals = (WhitespaceListGreen)this.Visit(whitespaceAfterEqualsContext);
				}
				MediaWikiParser.HtmlAttributeValueContext htmlAttributeValueContext = context.htmlAttributeValue();
				HtmlAttributeValueGreen htmlAttributeValue = null;
				if (htmlAttributeValueContext != null)
				{
					htmlAttributeValue = (HtmlAttributeValueGreen)this.Visit(htmlAttributeValueContext);
				}
				return this.factory.HtmlAttributeWithValue(leadingWhitespace, htmlAttributeName, whitespaceBeforeEquals, tAttributeEquals, whitespaceAfterEquals, htmlAttributeValue, true);
			}
			
			public override GreenNode VisitHtmlAttributeWithNoValue(MediaWikiParser.HtmlAttributeWithNoValueContext context)
			{
				if (context == null) return null;
				MediaWikiParser.WhitespaceListContext leadingWhitespaceContext = context.leadingWhitespace;
				WhitespaceListGreen leadingWhitespace = null;
				if (leadingWhitespaceContext != null)
				{
					leadingWhitespace = (WhitespaceListGreen)this.Visit(leadingWhitespaceContext);
				}
				MediaWikiParser.HtmlAttributeNameContext htmlAttributeNameContext = context.htmlAttributeName();
				HtmlAttributeNameGreen htmlAttributeName = null;
				if (htmlAttributeNameContext != null)
				{
					htmlAttributeName = (HtmlAttributeNameGreen)this.Visit(htmlAttributeNameContext);
				}
				return this.factory.HtmlAttributeWithNoValue(leadingWhitespace, htmlAttributeName, true);
			}
			
			public override GreenNode VisitHtmlAttributeName(MediaWikiParser.HtmlAttributeNameContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTagName = (InternalSyntaxToken)this.VisitTerminal(context.TTagName());
				return this.factory.HtmlAttributeName(tTagName, true);
			}
			
			public override GreenNode VisitHtmlAttributeValue(MediaWikiParser.HtmlAttributeValueContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tAttributeValue = (InternalSyntaxToken)this.VisitTerminal(context.TAttributeValue());
				return this.factory.HtmlAttributeValue(tAttributeValue, true);
			}
			
			public override GreenNode VisitHtmlTagName(MediaWikiParser.HtmlTagNameContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tTagName = (InternalSyntaxToken)this.VisitTerminal(context.TTagName());
				return this.factory.HtmlTagName(tTagName, true);
			}
			
			public override GreenNode VisitWhitespaceList(MediaWikiParser.WhitespaceListContext context)
			{
				if (context == null) return null;
			    MediaWikiParser.WhitespaceContext[] whitespaceContext = context.whitespace();
			    ArrayBuilder<WhitespaceGreen> whitespaceBuilder = ArrayBuilder<WhitespaceGreen>.GetInstance(whitespaceContext.Length);
			    for (int i = 0; i < whitespaceContext.Length; i++)
			    {
			        whitespaceBuilder.Add((WhitespaceGreen)this.Visit(whitespaceContext[i]));
			    }
				InternalSyntaxNodeList whitespace = InternalSyntaxNodeList.Create(whitespaceBuilder.ToArrayAndFree());
				return this.factory.WhitespaceList(whitespace, true);
			}
			
			public override GreenNode VisitWhitespace(MediaWikiParser.WhitespaceContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken whitespace = null;
				if (context.TWhiteSpace() != null)
				{
					whitespace = (InternalSyntaxToken)this.VisitTerminal(context.TWhiteSpace());
				}
				else 	if (context.CRLF() != null)
				{
					whitespace = (InternalSyntaxToken)this.VisitTerminal(context.CRLF());
				}
				return this.factory.Whitespace(whitespace, true);
			}
        }
    }
}

