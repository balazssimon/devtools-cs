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

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax
{
	public enum SeleniumUserInterfaceSyntaxKind : int
	{
        None                          = SyntaxKind.None,
        List                          = SyntaxKind.List,
        BadToken                      = SyntaxKind.BadToken,
        Eof                           = SyntaxKind.Eof,

		// Tokens:
		KParent = 1,
		KAncestor = 2,
		KPage = 3,
		KElement = 4,
		KInput = 5,
		KImage = 6,
		KLink = 7,
		KForm = 8,
		KLabel = 9,
		KCheckBox = 10,
		KTextField = 11,
		KTextArea = 12,
		KButton = 13,
		KRadioGroup = 14,
		KRadioButton = 15,
		KList = 16,
		KTable = 17,
		TSemicolon = 18,
		TColon = 19,
		TDot = 20,
		TComma = 21,
		TAssign = 22,
		TOpenParen = 23,
		TCloseParen = 24,
		TOpenBracket = 25,
		TCloseBracket = 26,
		TOpenBrace = 27,
		TCloseBrace = 28,
		TLessThan = 29,
		TGreaterThan = 30,
		TQuestion = 31,
		Identifier = 32,
		LInteger = 33,
		LDecimal = 34,
		LScientific = 35,
		LRegularString = 36,
		LUtf8Bom = 37,
		LWhiteSpace = 38,
		LCrLf = 39,
		LLineEnd = 40,
		LSingleLineComment = 41,
		LComment = 42,
		LDoubleQuoteVerbatimString = 43,
		LSingleQuoteVerbatimString = 44,
		DoubleQuoteVerbatimStringLiteralStart = 45,
		SingleQuoteVerbatimStringLiteralStart = 46,
		LCommentStart = 47,
		LComment_Star = 48,
		LastTokenSyntaxKind = 48,

		// Rules:
		Main,
		Page,
		Name,
	}
}

