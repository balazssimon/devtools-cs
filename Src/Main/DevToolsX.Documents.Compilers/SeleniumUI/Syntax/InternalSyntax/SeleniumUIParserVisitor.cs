//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from SeleniumUIParser.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="SeleniumUIParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface ISeleniumUIParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMain([NotNull] SeleniumUIParser.MainContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.namespace"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamespace([NotNull] SeleniumUIParser.NamespaceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.namespaceBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamespaceBody([NotNull] SeleniumUIParser.NamespaceBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] SeleniumUIParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.tag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTag([NotNull] SeleniumUIParser.TagContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.typeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypeSpecifier([NotNull] SeleniumUIParser.TypeSpecifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElement([NotNull] SeleniumUIParser.ElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.elementOrPage"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElementOrPage([NotNull] SeleniumUIParser.ElementOrPageContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.baseElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBaseElement([NotNull] SeleniumUIParser.BaseElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.elementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElementBody([NotNull] SeleniumUIParser.ElementBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.emptyElementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEmptyElementBody([NotNull] SeleniumUIParser.EmptyElementBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.childElementsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitChildElementsBody([NotNull] SeleniumUIParser.ChildElementsBodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.childElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitChildElement([NotNull] SeleniumUIParser.ChildElementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.elementTypeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElementTypeSpecifier([NotNull] SeleniumUIParser.ElementTypeSpecifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.htmlTagLocatorSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlTagLocatorSpecifier([NotNull] SeleniumUIParser.HtmlTagLocatorSpecifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.htmlTagSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHtmlTagSpecifier([NotNull] SeleniumUIParser.HtmlTagSpecifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.locatorSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLocatorSpecifier([NotNull] SeleniumUIParser.LocatorSpecifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQualifiedName([NotNull] SeleniumUIParser.QualifiedNameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitName([NotNull] SeleniumUIParser.NameContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQualifier([NotNull] SeleniumUIParser.QualifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] SeleniumUIParser.IdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="SeleniumUIParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] SeleniumUIParser.StringContext context);
}
} // namespace DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax

