//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from MediaWikiParser.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="MediaWikiParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface IMediaWikiParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMain([NotNull] MediaWikiParser.MainContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.specialBlockOrParagraph"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSpecialBlockOrParagraph([NotNull] MediaWikiParser.SpecialBlockOrParagraphContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.specialBlockWithComment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSpecialBlockWithComment([NotNull] MediaWikiParser.SpecialBlockWithCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.specialBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSpecialBlock([NotNull] MediaWikiParser.SpecialBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.heading"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeading([NotNull] MediaWikiParser.HeadingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.headingLevel"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeadingLevel([NotNull] MediaWikiParser.HeadingLevelContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.horizontalRule"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHorizontalRule([NotNull] MediaWikiParser.HorizontalRuleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.codeBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCodeBlock([NotNull] MediaWikiParser.CodeBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.spaceBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSpaceBlock([NotNull] MediaWikiParser.SpaceBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.wikiList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWikiList([NotNull] MediaWikiParser.WikiListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.listItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListItem([NotNull] MediaWikiParser.ListItemContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.normalListItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNormalListItem([NotNull] MediaWikiParser.NormalListItemContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.definitionItem"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinitionItem([NotNull] MediaWikiParser.DefinitionItemContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.wikiTable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWikiTable([NotNull] MediaWikiParser.WikiTableContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableCaption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableCaption([NotNull] MediaWikiParser.TableCaptionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableRows"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableRows([NotNull] MediaWikiParser.TableRowsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableFirstRow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableFirstRow([NotNull] MediaWikiParser.TableFirstRowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableNonFirstRow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableNonFirstRow([NotNull] MediaWikiParser.TableNonFirstRowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableRowStart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableRowStart([NotNull] MediaWikiParser.TableRowStartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableRow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableRow([NotNull] MediaWikiParser.TableRowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableColumn"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableColumn([NotNull] MediaWikiParser.TableColumnContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableSingleHeaderCell"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableSingleHeaderCell([NotNull] MediaWikiParser.TableSingleHeaderCellContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableHeaderCells"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableHeaderCells([NotNull] MediaWikiParser.TableHeaderCellsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableSingleCell"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableSingleCell([NotNull] MediaWikiParser.TableSingleCellContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableCells"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableCells([NotNull] MediaWikiParser.TableCellsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.tableCell"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTableCell([NotNull] MediaWikiParser.TableCellContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.cellAttributes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCellAttributes([NotNull] MediaWikiParser.CellAttributesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.paragraph"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParagraph([NotNull] MediaWikiParser.ParagraphContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>textLineInlineElementsWithComment</c>
	/// labeled alternative in <see cref="MediaWikiParser.textLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTextLineInlineElementsWithComment([NotNull] MediaWikiParser.TextLineInlineElementsWithCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>textLineComment</c>
	/// labeled alternative in <see cref="MediaWikiParser.textLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTextLineComment([NotNull] MediaWikiParser.TextLineCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.textElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTextElements([NotNull] MediaWikiParser.TextElementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.inlineText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInlineText([NotNull] MediaWikiParser.InlineTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.inlineTextElementWithComment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInlineTextElementWithComment([NotNull] MediaWikiParser.InlineTextElementWithCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.inlineTextElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInlineTextElement([NotNull] MediaWikiParser.InlineTextElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.inlineTextElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInlineTextElements([NotNull] MediaWikiParser.InlineTextElementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.definitionText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinitionText([NotNull] MediaWikiParser.DefinitionTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.definitionTextElementWithComment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinitionTextElementWithComment([NotNull] MediaWikiParser.DefinitionTextElementWithCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.definitionTextElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinitionTextElement([NotNull] MediaWikiParser.DefinitionTextElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.definitionTextElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDefinitionTextElements([NotNull] MediaWikiParser.DefinitionTextElementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.headingText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeadingText([NotNull] MediaWikiParser.HeadingTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.headingTextWithComment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeadingTextWithComment([NotNull] MediaWikiParser.HeadingTextWithCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.headingTextElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeadingTextElement([NotNull] MediaWikiParser.HeadingTextElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.headingTextElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeadingTextElements([NotNull] MediaWikiParser.HeadingTextElementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.cellText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCellText([NotNull] MediaWikiParser.CellTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.cellTextElementWithComment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCellTextElementWithComment([NotNull] MediaWikiParser.CellTextElementWithCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.cellTextElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCellTextElement([NotNull] MediaWikiParser.CellTextElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.cellTextElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCellTextElements([NotNull] MediaWikiParser.CellTextElementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.linkText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLinkText([NotNull] MediaWikiParser.LinkTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.linkTextWithComment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLinkTextWithComment([NotNull] MediaWikiParser.LinkTextWithCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.linkTextElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLinkTextElement([NotNull] MediaWikiParser.LinkTextElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.linkTextElements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLinkTextElements([NotNull] MediaWikiParser.LinkTextElementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.wikiFormat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWikiFormat([NotNull] MediaWikiParser.WikiFormatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.wikiLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWikiLink([NotNull] MediaWikiParser.WikiLinkContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.wikiInternalLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWikiInternalLink([NotNull] MediaWikiParser.WikiInternalLinkContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.wikiExternalLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWikiExternalLink([NotNull] MediaWikiParser.WikiExternalLinkContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.wikiTemplate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWikiTemplate([NotNull] MediaWikiParser.WikiTemplateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.wikiTemplateParam"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWikiTemplateParam([NotNull] MediaWikiParser.WikiTemplateParamContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.noWiki"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNoWiki([NotNull] MediaWikiParser.NoWikiContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.barOrBarBar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBarOrBarBar([NotNull] MediaWikiParser.BarOrBarBarContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.linkTextPart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLinkTextPart([NotNull] MediaWikiParser.LinkTextPartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlReference"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlReference([NotNull] MediaWikiParser.HtmlReferenceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlCommentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlCommentList([NotNull] MediaWikiParser.HtmlCommentListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlComment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlComment([NotNull] MediaWikiParser.HtmlCommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlStyle"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlStyle([NotNull] MediaWikiParser.HtmlStyleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlScript"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlScript([NotNull] MediaWikiParser.HtmlScriptContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlTag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlTag([NotNull] MediaWikiParser.HtmlTagContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlTagOpen"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlTagOpen([NotNull] MediaWikiParser.HtmlTagOpenContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlTagClose"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlTagClose([NotNull] MediaWikiParser.HtmlTagCloseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlTagEmpty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlTagEmpty([NotNull] MediaWikiParser.HtmlTagEmptyContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>htmlAttributeWithValue</c>
	/// labeled alternative in <see cref="MediaWikiParser.htmlAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlAttributeWithValue([NotNull] MediaWikiParser.HtmlAttributeWithValueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>htmlAttributeWithNoValue</c>
	/// labeled alternative in <see cref="MediaWikiParser.htmlAttribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlAttributeWithNoValue([NotNull] MediaWikiParser.HtmlAttributeWithNoValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlAttributeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlAttributeName([NotNull] MediaWikiParser.HtmlAttributeNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlAttributeValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlAttributeValue([NotNull] MediaWikiParser.HtmlAttributeValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.htmlTagName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlTagName([NotNull] MediaWikiParser.HtmlTagNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.whitespaceList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhitespaceList([NotNull] MediaWikiParser.WhitespaceListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MediaWikiParser.whitespace"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhitespace([NotNull] MediaWikiParser.WhitespaceContext context);
}
} // namespace DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax

