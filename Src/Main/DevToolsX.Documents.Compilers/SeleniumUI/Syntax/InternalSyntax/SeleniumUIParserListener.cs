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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="SeleniumUIParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public interface ISeleniumUIParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMain([NotNull] SeleniumUIParser.MainContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.main"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMain([NotNull] SeleniumUIParser.MainContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.namespace"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamespace([NotNull] SeleniumUIParser.NamespaceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.namespace"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamespace([NotNull] SeleniumUIParser.NamespaceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.namespaceBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamespaceBody([NotNull] SeleniumUIParser.NamespaceBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.namespaceBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamespaceBody([NotNull] SeleniumUIParser.NamespaceBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] SeleniumUIParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] SeleniumUIParser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.tag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTag([NotNull] SeleniumUIParser.TagContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.tag"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTag([NotNull] SeleniumUIParser.TagContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.typeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeSpecifier([NotNull] SeleniumUIParser.TypeSpecifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.typeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeSpecifier([NotNull] SeleniumUIParser.TypeSpecifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElement([NotNull] SeleniumUIParser.ElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElement([NotNull] SeleniumUIParser.ElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.elementOrPage"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElementOrPage([NotNull] SeleniumUIParser.ElementOrPageContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.elementOrPage"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElementOrPage([NotNull] SeleniumUIParser.ElementOrPageContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.baseElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBaseElement([NotNull] SeleniumUIParser.BaseElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.baseElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBaseElement([NotNull] SeleniumUIParser.BaseElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.elementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElementBody([NotNull] SeleniumUIParser.ElementBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.elementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElementBody([NotNull] SeleniumUIParser.ElementBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.emptyElementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEmptyElementBody([NotNull] SeleniumUIParser.EmptyElementBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.emptyElementBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEmptyElementBody([NotNull] SeleniumUIParser.EmptyElementBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.childElementsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChildElementsBody([NotNull] SeleniumUIParser.ChildElementsBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.childElementsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChildElementsBody([NotNull] SeleniumUIParser.ChildElementsBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.childElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChildElement([NotNull] SeleniumUIParser.ChildElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.childElement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChildElement([NotNull] SeleniumUIParser.ChildElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.elementTypeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElementTypeSpecifier([NotNull] SeleniumUIParser.ElementTypeSpecifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.elementTypeSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElementTypeSpecifier([NotNull] SeleniumUIParser.ElementTypeSpecifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.htmlTagLocatorSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHtmlTagLocatorSpecifier([NotNull] SeleniumUIParser.HtmlTagLocatorSpecifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.htmlTagLocatorSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHtmlTagLocatorSpecifier([NotNull] SeleniumUIParser.HtmlTagLocatorSpecifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.htmlTagSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHtmlTagSpecifier([NotNull] SeleniumUIParser.HtmlTagSpecifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.htmlTagSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHtmlTagSpecifier([NotNull] SeleniumUIParser.HtmlTagSpecifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.locatorSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLocatorSpecifier([NotNull] SeleniumUIParser.LocatorSpecifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.locatorSpecifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLocatorSpecifier([NotNull] SeleniumUIParser.LocatorSpecifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifiedName([NotNull] SeleniumUIParser.QualifiedNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifiedName([NotNull] SeleniumUIParser.QualifiedNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterName([NotNull] SeleniumUIParser.NameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitName([NotNull] SeleniumUIParser.NameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifier([NotNull] SeleniumUIParser.QualifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.qualifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifier([NotNull] SeleniumUIParser.QualifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] SeleniumUIParser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] SeleniumUIParser.IdentifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="SeleniumUIParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString([NotNull] SeleniumUIParser.StringContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SeleniumUIParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString([NotNull] SeleniumUIParser.StringContext context);
}
} // namespace DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax

