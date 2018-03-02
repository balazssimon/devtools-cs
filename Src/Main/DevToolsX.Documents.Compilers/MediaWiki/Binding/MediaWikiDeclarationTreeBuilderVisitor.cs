// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using DevToolsX.Documents.Compilers.MediaWiki.Syntax;

namespace DevToolsX.Documents.Compilers.MediaWiki.Binding
{
	public class MediaWikiDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, IMediaWikiSyntaxVisitor
	{
        protected MediaWikiDeclarationTreeBuilderVisitor(MediaWikiSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            MediaWikiSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new MediaWikiDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
		}
		
		public virtual void VisitSpecialBlockOrParagraph(SpecialBlockOrParagraphSyntax node)
		{
		}
		
		public virtual void VisitSpecialBlockWithComment(SpecialBlockWithCommentSyntax node)
		{
		}
		
		public virtual void VisitSpecialBlock(SpecialBlockSyntax node)
		{
		}
		
		public virtual void VisitHeading(HeadingSyntax node)
		{
		}
		
		public virtual void VisitHeadingLevel(HeadingLevelSyntax node)
		{
		}
		
		public virtual void VisitHorizontalRule(HorizontalRuleSyntax node)
		{
		}
		
		public virtual void VisitCodeBlock(CodeBlockSyntax node)
		{
		}
		
		public virtual void VisitSpaceBlock(SpaceBlockSyntax node)
		{
		}
		
		public virtual void VisitWikiList(WikiListSyntax node)
		{
		}
		
		public virtual void VisitListItem(ListItemSyntax node)
		{
		}
		
		public virtual void VisitNormalListItem(NormalListItemSyntax node)
		{
		}
		
		public virtual void VisitDefinitionItem(DefinitionItemSyntax node)
		{
		}
		
		public virtual void VisitWikiTable(WikiTableSyntax node)
		{
		}
		
		public virtual void VisitTableCaption(TableCaptionSyntax node)
		{
		}
		
		public virtual void VisitTableRows(TableRowsSyntax node)
		{
		}
		
		public virtual void VisitTableFirstRow(TableFirstRowSyntax node)
		{
		}
		
		public virtual void VisitTableNonFirstRow(TableNonFirstRowSyntax node)
		{
		}
		
		public virtual void VisitTableRowStart(TableRowStartSyntax node)
		{
		}
		
		public virtual void VisitTableRow(TableRowSyntax node)
		{
		}
		
		public virtual void VisitTableColumn(TableColumnSyntax node)
		{
		}
		
		public virtual void VisitTableSingleHeaderCell(TableSingleHeaderCellSyntax node)
		{
		}
		
		public virtual void VisitTableHeaderCells(TableHeaderCellsSyntax node)
		{
		}
		
		public virtual void VisitTableSingleCell(TableSingleCellSyntax node)
		{
		}
		
		public virtual void VisitTableCells(TableCellsSyntax node)
		{
		}
		
		public virtual void VisitTableCell(TableCellSyntax node)
		{
		}
		
		public virtual void VisitCellAttributes(CellAttributesSyntax node)
		{
		}
		
		public virtual void VisitParagraph(ParagraphSyntax node)
		{
		}
		
		public virtual void VisitTextLineInlineElementsWithComment(TextLineInlineElementsWithCommentSyntax node)
		{
		}
		
		public virtual void VisitTextLineComment(TextLineCommentSyntax node)
		{
		}
		
		public virtual void VisitTextElements(TextElementsSyntax node)
		{
		}
		
		public virtual void VisitInlineText(InlineTextSyntax node)
		{
		}
		
		public virtual void VisitInlineTextElementWithComment(InlineTextElementWithCommentSyntax node)
		{
		}
		
		public virtual void VisitInlineTextElement(InlineTextElementSyntax node)
		{
		}
		
		public virtual void VisitInlineTextElements(InlineTextElementsSyntax node)
		{
		}
		
		public virtual void VisitDefinitionText(DefinitionTextSyntax node)
		{
		}
		
		public virtual void VisitDefinitionTextElementWithComment(DefinitionTextElementWithCommentSyntax node)
		{
		}
		
		public virtual void VisitDefinitionTextElement(DefinitionTextElementSyntax node)
		{
		}
		
		public virtual void VisitDefinitionTextElements(DefinitionTextElementsSyntax node)
		{
		}
		
		public virtual void VisitHeadingText(HeadingTextSyntax node)
		{
		}
		
		public virtual void VisitHeadingTextWithComment(HeadingTextWithCommentSyntax node)
		{
		}
		
		public virtual void VisitHeadingTextElement(HeadingTextElementSyntax node)
		{
		}
		
		public virtual void VisitHeadingTextElements(HeadingTextElementsSyntax node)
		{
		}
		
		public virtual void VisitCellText(CellTextSyntax node)
		{
		}
		
		public virtual void VisitCellTextElementWithComment(CellTextElementWithCommentSyntax node)
		{
		}
		
		public virtual void VisitCellTextElement(CellTextElementSyntax node)
		{
		}
		
		public virtual void VisitCellTextElements(CellTextElementsSyntax node)
		{
		}
		
		public virtual void VisitLinkText(LinkTextSyntax node)
		{
		}
		
		public virtual void VisitLinkTextWithComment(LinkTextWithCommentSyntax node)
		{
		}
		
		public virtual void VisitLinkTextElement(LinkTextElementSyntax node)
		{
		}
		
		public virtual void VisitLinkTextElements(LinkTextElementsSyntax node)
		{
		}
		
		public virtual void VisitWikiFormat(WikiFormatSyntax node)
		{
		}
		
		public virtual void VisitWikiLink(WikiLinkSyntax node)
		{
		}
		
		public virtual void VisitWikiInternalLink(WikiInternalLinkSyntax node)
		{
		}
		
		public virtual void VisitWikiExternalLink(WikiExternalLinkSyntax node)
		{
		}
		
		public virtual void VisitWikiTemplate(WikiTemplateSyntax node)
		{
		}
		
		public virtual void VisitWikiTemplateParam(WikiTemplateParamSyntax node)
		{
		}
		
		public virtual void VisitNoWiki(NoWikiSyntax node)
		{
		}
		
		public virtual void VisitBarOrBarBar(BarOrBarBarSyntax node)
		{
		}
		
		public virtual void VisitLinkTextPart(LinkTextPartSyntax node)
		{
		}
		
		public virtual void VisitHtmlReference(HtmlReferenceSyntax node)
		{
		}
		
		public virtual void VisitHtmlCommentList(HtmlCommentListSyntax node)
		{
		}
		
		public virtual void VisitHtmlComment(HtmlCommentSyntax node)
		{
		}
		
		public virtual void VisitHtmlStyle(HtmlStyleSyntax node)
		{
		}
		
		public virtual void VisitHtmlScript(HtmlScriptSyntax node)
		{
		}
		
		public virtual void VisitHtmlTag(HtmlTagSyntax node)
		{
		}
		
		public virtual void VisitHtmlTagOpen(HtmlTagOpenSyntax node)
		{
		}
		
		public virtual void VisitHtmlTagClose(HtmlTagCloseSyntax node)
		{
		}
		
		public virtual void VisitHtmlTagEmpty(HtmlTagEmptySyntax node)
		{
		}
		
		public virtual void VisitHtmlAttributeWithValue(HtmlAttributeWithValueSyntax node)
		{
		}
		
		public virtual void VisitHtmlAttributeWithNoValue(HtmlAttributeWithNoValueSyntax node)
		{
		}
		
		public virtual void VisitHtmlAttributeName(HtmlAttributeNameSyntax node)
		{
		}
		
		public virtual void VisitHtmlAttributeValue(HtmlAttributeValueSyntax node)
		{
		}
		
		public virtual void VisitHtmlTagName(HtmlTagNameSyntax node)
		{
		}
		
		public virtual void VisitWhitespaceList(WhitespaceListSyntax node)
		{
		}
		
		public virtual void VisitWhitespace(WhitespaceSyntax node)
		{
		}
	}
}

