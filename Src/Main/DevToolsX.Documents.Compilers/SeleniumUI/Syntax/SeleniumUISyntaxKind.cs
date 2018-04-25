// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;

namespace DevToolsX.Documents.Compilers.SeleniumUI.Syntax
{
	public enum SeleniumUISyntaxKind : int
	{
        None                          = SyntaxKind.None,
        List                          = SyntaxKind.List,
        BadToken                      = SyntaxKind.BadToken,
        Eof                           = SyntaxKind.Eof,

		// Tokens:
		KParent = 1,
		KAncestor = 2,
		KNamespace = 3,
		KPage = 4,
		KElement = 5,
		KTag = 6,
		TSemicolon = 7,
		TColon = 8,
		TDot = 9,
		TComma = 10,
		TAssign = 11,
		TOpenParen = 12,
		TCloseParen = 13,
		TOpenBracket = 14,
		TCloseBracket = 15,
		TOpenBrace = 16,
		TCloseBrace = 17,
		TLessThan = 18,
		TGreaterThan = 19,
		TQuestion = 20,
		LIdentifier = 21,
		LInteger = 22,
		LDecimal = 23,
		LScientific = 24,
		LRegularString = 25,
		LUtf8Bom = 26,
		LWhiteSpace = 27,
		LCrLf = 28,
		LLineEnd = 29,
		LSingleLineComment = 30,
		LComment = 31,
		LDoubleQuoteVerbatimString = 32,
		LSingleQuoteVerbatimString = 33,
		DoubleQuoteVerbatimStringLiteralStart = 34,
		SingleQuoteVerbatimStringLiteralStart = 35,
		LCommentStart = 36,
		LComment_Star = 37,
		LastTokenSyntaxKind = 37,

		// Rules:
		Main,
		Namespace,
		NamespaceBody,
		Declaration,
		Tag,
		TypeSpecifier,
		Element,
		ElementOrPage,
		BaseElement,
		ElementBody,
		EmptyElementBody,
		ChildElementsBody,
		ChildElement,
		ElementTypeSpecifier,
		HtmlTagLocatorSpecifier,
		HtmlTagSpecifier,
		LocatorSpecifier,
		QualifiedName,
		Name,
		Qualifier,
		Identifier,
		String,
	}
}

