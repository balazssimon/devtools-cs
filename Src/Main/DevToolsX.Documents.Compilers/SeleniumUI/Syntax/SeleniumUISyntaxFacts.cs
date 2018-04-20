using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace DevToolsX.Documents.Compilers.SeleniumUI.Syntax
{
	public enum SeleniumUITokenKind : int
	{
		None = 0,
		Comment,
		Identifier,
		Keyword,
		Number,
		String,
		Whitespace
	}

	public enum SeleniumUILexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class SeleniumUISyntaxFacts : SyntaxFacts
	{
		public static readonly SeleniumUISyntaxFacts Instance = new SeleniumUISyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)SeleniumUISyntaxKind.LCrLf; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)SeleniumUISyntaxKind.LWhiteSpace; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsToken(SeleniumUISyntaxKind kind)
		{
			switch (kind)
			{
				case SeleniumUISyntaxKind.Eof:
				case SeleniumUISyntaxKind.KParent:
				case SeleniumUISyntaxKind.KAncestor:
				case SeleniumUISyntaxKind.KNamespace:
				case SeleniumUISyntaxKind.KPage:
				case SeleniumUISyntaxKind.KElement:
				case SeleniumUISyntaxKind.KTag:
				case SeleniumUISyntaxKind.TSemicolon:
				case SeleniumUISyntaxKind.TColon:
				case SeleniumUISyntaxKind.TDot:
				case SeleniumUISyntaxKind.TComma:
				case SeleniumUISyntaxKind.TAssign:
				case SeleniumUISyntaxKind.TOpenParen:
				case SeleniumUISyntaxKind.TCloseParen:
				case SeleniumUISyntaxKind.TOpenBracket:
				case SeleniumUISyntaxKind.TCloseBracket:
				case SeleniumUISyntaxKind.TOpenBrace:
				case SeleniumUISyntaxKind.TCloseBrace:
				case SeleniumUISyntaxKind.TLessThan:
				case SeleniumUISyntaxKind.TGreaterThan:
				case SeleniumUISyntaxKind.TQuestion:
				case SeleniumUISyntaxKind.LIdentifier:
				case SeleniumUISyntaxKind.LInteger:
				case SeleniumUISyntaxKind.LDecimal:
				case SeleniumUISyntaxKind.LScientific:
				case SeleniumUISyntaxKind.LRegularString:
				case SeleniumUISyntaxKind.LUtf8Bom:
				case SeleniumUISyntaxKind.LWhiteSpace:
				case SeleniumUISyntaxKind.LCrLf:
				case SeleniumUISyntaxKind.LLineEnd:
				case SeleniumUISyntaxKind.LSingleLineComment:
				case SeleniumUISyntaxKind.LComment:
				case SeleniumUISyntaxKind.LDoubleQuoteVerbatimString:
				case SeleniumUISyntaxKind.LSingleQuoteVerbatimString:
				case SeleniumUISyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case SeleniumUISyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case SeleniumUISyntaxKind.LCommentStart:
				case SeleniumUISyntaxKind.LComment_Star:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsFixedToken(SeleniumUISyntaxKind kind)
		{
			switch (kind)
			{
				case SeleniumUISyntaxKind.Eof:
				case SeleniumUISyntaxKind.KParent:
				case SeleniumUISyntaxKind.KAncestor:
				case SeleniumUISyntaxKind.KNamespace:
				case SeleniumUISyntaxKind.KPage:
				case SeleniumUISyntaxKind.KElement:
				case SeleniumUISyntaxKind.KTag:
				case SeleniumUISyntaxKind.TSemicolon:
				case SeleniumUISyntaxKind.TColon:
				case SeleniumUISyntaxKind.TDot:
				case SeleniumUISyntaxKind.TComma:
				case SeleniumUISyntaxKind.TAssign:
				case SeleniumUISyntaxKind.TOpenParen:
				case SeleniumUISyntaxKind.TCloseParen:
				case SeleniumUISyntaxKind.TOpenBracket:
				case SeleniumUISyntaxKind.TCloseBracket:
				case SeleniumUISyntaxKind.TOpenBrace:
				case SeleniumUISyntaxKind.TCloseBrace:
				case SeleniumUISyntaxKind.TLessThan:
				case SeleniumUISyntaxKind.TGreaterThan:
				case SeleniumUISyntaxKind.TQuestion:
				case SeleniumUISyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case SeleniumUISyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case SeleniumUISyntaxKind.LCommentStart:
				case SeleniumUISyntaxKind.LComment_Star:
				case SeleniumUISyntaxKind.LDoubleQuoteVerbatimString:
				case SeleniumUISyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}

		public override string GetText(int rawKind)
		{
			return this.GetText((SeleniumUISyntaxKind)rawKind);
		}

		public string GetText(SeleniumUISyntaxKind kind)
		{
			switch (kind)
			{
				case SeleniumUISyntaxKind.KParent:
					return "parent";
				case SeleniumUISyntaxKind.KAncestor:
					return "ancestor";
				case SeleniumUISyntaxKind.KNamespace:
					return "namespace";
				case SeleniumUISyntaxKind.KPage:
					return "page";
				case SeleniumUISyntaxKind.KElement:
					return "element";
				case SeleniumUISyntaxKind.KTag:
					return "tag";
				case SeleniumUISyntaxKind.TSemicolon:
					return ";";
				case SeleniumUISyntaxKind.TColon:
					return ":";
				case SeleniumUISyntaxKind.TDot:
					return ".";
				case SeleniumUISyntaxKind.TComma:
					return ",";
				case SeleniumUISyntaxKind.TAssign:
					return "=";
				case SeleniumUISyntaxKind.TOpenParen:
					return "(";
				case SeleniumUISyntaxKind.TCloseParen:
					return ")";
				case SeleniumUISyntaxKind.TOpenBracket:
					return "[";
				case SeleniumUISyntaxKind.TCloseBracket:
					return "]";
				case SeleniumUISyntaxKind.TOpenBrace:
					return "{";
				case SeleniumUISyntaxKind.TCloseBrace:
					return "}";
				case SeleniumUISyntaxKind.TLessThan:
					return "<";
				case SeleniumUISyntaxKind.TGreaterThan:
					return ">";
				case SeleniumUISyntaxKind.TQuestion:
					return "?";
				case SeleniumUISyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case SeleniumUISyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case SeleniumUISyntaxKind.LCommentStart:
					return "/*";
				case SeleniumUISyntaxKind.LComment_Star:
					return "*";
				case SeleniumUISyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case SeleniumUISyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public SeleniumUISyntaxKind GetKind(string text)
		{
			switch (text)
			{
				case "parent":
					return SeleniumUISyntaxKind.KParent;
				case "ancestor":
					return SeleniumUISyntaxKind.KAncestor;
				case "namespace":
					return SeleniumUISyntaxKind.KNamespace;
				case "page":
					return SeleniumUISyntaxKind.KPage;
				case "element":
					return SeleniumUISyntaxKind.KElement;
				case "tag":
					return SeleniumUISyntaxKind.KTag;
				case ";":
					return SeleniumUISyntaxKind.TSemicolon;
				case ":":
					return SeleniumUISyntaxKind.TColon;
				case ".":
					return SeleniumUISyntaxKind.TDot;
				case ",":
					return SeleniumUISyntaxKind.TComma;
				case "=":
					return SeleniumUISyntaxKind.TAssign;
				case "(":
					return SeleniumUISyntaxKind.TOpenParen;
				case ")":
					return SeleniumUISyntaxKind.TCloseParen;
				case "[":
					return SeleniumUISyntaxKind.TOpenBracket;
				case "]":
					return SeleniumUISyntaxKind.TCloseBracket;
				case "{":
					return SeleniumUISyntaxKind.TOpenBrace;
				case "}":
					return SeleniumUISyntaxKind.TCloseBrace;
				case "<":
					return SeleniumUISyntaxKind.TLessThan;
				case ">":
					return SeleniumUISyntaxKind.TGreaterThan;
				case "?":
					return SeleniumUISyntaxKind.TQuestion;
				case "@\"":
					return SeleniumUISyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return SeleniumUISyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return SeleniumUISyntaxKind.LCommentStart;
				case "*":
					return SeleniumUISyntaxKind.LComment_Star;
				case "\"":
					return SeleniumUISyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return SeleniumUISyntaxKind.LSingleQuoteVerbatimString;
				default:
					return SeleniumUISyntaxKind.None;
			}
		}

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((SeleniumUISyntaxKind)rawKind);
		}

		public string GetKindText(SeleniumUISyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(SeleniumUISyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUISyntaxKind.LCrLf:
					return true;
				case SeleniumUISyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}

		public bool IsKeyword(int rawKind)
		{
			return this.IsKeyword((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsKeyword(SeleniumUISyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUISyntaxKind.KParent:
				case SeleniumUISyntaxKind.KAncestor:
				case SeleniumUISyntaxKind.KNamespace:
				case SeleniumUISyntaxKind.KPage:
				case SeleniumUISyntaxKind.KElement:
				case SeleniumUISyntaxKind.KTag:
					return true;
				default:
					return false;
			}
		}
		public bool IsIdentifier(int rawKind)
		{
			return this.IsIdentifier((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsIdentifier(SeleniumUISyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUISyntaxKind.LIdentifier:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(int rawKind)
		{
			return this.IsNumber((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsNumber(SeleniumUISyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUISyntaxKind.LInteger:
					return true;
				case SeleniumUISyntaxKind.LDecimal:
					return true;
				case SeleniumUISyntaxKind.LScientific:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(int rawKind)
		{
			return this.IsString((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsString(SeleniumUISyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUISyntaxKind.LRegularString:
					return true;
				case SeleniumUISyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case SeleniumUISyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(int rawKind)
		{
			return this.IsWhitespace((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsWhitespace(SeleniumUISyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUISyntaxKind.LUtf8Bom:
					return true;
				case SeleniumUISyntaxKind.LWhiteSpace:
					return true;
				case SeleniumUISyntaxKind.LCrLf:
					return true;
				case SeleniumUISyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(int rawKind)
		{
			return this.IsComment((SeleniumUISyntaxKind)rawKind);
		}

		public bool IsComment(SeleniumUISyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUISyntaxKind.LSingleLineComment:
					return true;
				case SeleniumUISyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}

		public SeleniumUITokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((SeleniumUISyntaxKind)rawKind);
		}

		public SeleniumUITokenKind GetTokenKind(SeleniumUISyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUISyntaxKind.KParent:
				case SeleniumUISyntaxKind.KAncestor:
				case SeleniumUISyntaxKind.KNamespace:
				case SeleniumUISyntaxKind.KPage:
				case SeleniumUISyntaxKind.KElement:
				case SeleniumUISyntaxKind.KTag:
					return SeleniumUITokenKind.Keyword;
				case SeleniumUISyntaxKind.LIdentifier:
					return SeleniumUITokenKind.Identifier;
				case SeleniumUISyntaxKind.LInteger:
					return SeleniumUITokenKind.Number;
				case SeleniumUISyntaxKind.LDecimal:
					return SeleniumUITokenKind.Number;
				case SeleniumUISyntaxKind.LScientific:
					return SeleniumUITokenKind.Number;
				case SeleniumUISyntaxKind.LRegularString:
					return SeleniumUITokenKind.String;
				case SeleniumUISyntaxKind.LUtf8Bom:
					return SeleniumUITokenKind.Whitespace;
				case SeleniumUISyntaxKind.LWhiteSpace:
					return SeleniumUITokenKind.Whitespace;
				case SeleniumUISyntaxKind.LCrLf:
					return SeleniumUITokenKind.Whitespace;
				case SeleniumUISyntaxKind.LLineEnd:
					return SeleniumUITokenKind.Whitespace;
				case SeleniumUISyntaxKind.LSingleLineComment:
					return SeleniumUITokenKind.Comment;
				case SeleniumUISyntaxKind.LComment:
					return SeleniumUITokenKind.Comment;
				case SeleniumUISyntaxKind.LDoubleQuoteVerbatimString:
					return SeleniumUITokenKind.String;
				case SeleniumUISyntaxKind.LSingleQuoteVerbatimString:
					return SeleniumUITokenKind.String;
				default:
					return SeleniumUITokenKind.None;
			}
		}

		public SeleniumUITokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((SeleniumUILexerMode)rawKind);
		}

		public SeleniumUITokenKind GetModeTokenKind(SeleniumUILexerMode kind)
		{
			switch(kind)
			{
				case SeleniumUILexerMode.LMultilineComment:
					return SeleniumUITokenKind.Comment;
				case SeleniumUILexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return SeleniumUITokenKind.String;
				case SeleniumUILexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return SeleniumUITokenKind.String;
				default:
					return SeleniumUITokenKind.None;
			}
		}
	}
}

