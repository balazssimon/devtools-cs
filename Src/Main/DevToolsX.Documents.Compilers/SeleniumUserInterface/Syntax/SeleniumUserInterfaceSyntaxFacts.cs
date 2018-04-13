using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax
{
	public enum SeleniumUserInterfaceTokenKind : int
	{
		None = 0,
		Comment,
		Identifier,
		Keyword,
		Number,
		String,
		Whitespace
	}

	public enum SeleniumUserInterfaceLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class SeleniumUserInterfaceSyntaxFacts : SyntaxFacts
	{
		public static readonly SeleniumUserInterfaceSyntaxFacts Instance = new SeleniumUserInterfaceSyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)SeleniumUserInterfaceSyntaxKind.LCrLf; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)SeleniumUserInterfaceSyntaxKind.LWhiteSpace; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsToken(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch (kind)
			{
				case SeleniumUserInterfaceSyntaxKind.Eof:
				case SeleniumUserInterfaceSyntaxKind.KParent:
				case SeleniumUserInterfaceSyntaxKind.KAncestor:
				case SeleniumUserInterfaceSyntaxKind.KPage:
				case SeleniumUserInterfaceSyntaxKind.KElement:
				case SeleniumUserInterfaceSyntaxKind.KInput:
				case SeleniumUserInterfaceSyntaxKind.KImage:
				case SeleniumUserInterfaceSyntaxKind.KLink:
				case SeleniumUserInterfaceSyntaxKind.KForm:
				case SeleniumUserInterfaceSyntaxKind.KLabel:
				case SeleniumUserInterfaceSyntaxKind.KCheckBox:
				case SeleniumUserInterfaceSyntaxKind.KTextField:
				case SeleniumUserInterfaceSyntaxKind.KTextArea:
				case SeleniumUserInterfaceSyntaxKind.KButton:
				case SeleniumUserInterfaceSyntaxKind.KRadioGroup:
				case SeleniumUserInterfaceSyntaxKind.KRadioButton:
				case SeleniumUserInterfaceSyntaxKind.KList:
				case SeleniumUserInterfaceSyntaxKind.KTable:
				case SeleniumUserInterfaceSyntaxKind.TSemicolon:
				case SeleniumUserInterfaceSyntaxKind.TColon:
				case SeleniumUserInterfaceSyntaxKind.TDot:
				case SeleniumUserInterfaceSyntaxKind.TComma:
				case SeleniumUserInterfaceSyntaxKind.TAssign:
				case SeleniumUserInterfaceSyntaxKind.TOpenParen:
				case SeleniumUserInterfaceSyntaxKind.TCloseParen:
				case SeleniumUserInterfaceSyntaxKind.TOpenBracket:
				case SeleniumUserInterfaceSyntaxKind.TCloseBracket:
				case SeleniumUserInterfaceSyntaxKind.TOpenBrace:
				case SeleniumUserInterfaceSyntaxKind.TCloseBrace:
				case SeleniumUserInterfaceSyntaxKind.TLessThan:
				case SeleniumUserInterfaceSyntaxKind.TGreaterThan:
				case SeleniumUserInterfaceSyntaxKind.TQuestion:
				case SeleniumUserInterfaceSyntaxKind.Identifier:
				case SeleniumUserInterfaceSyntaxKind.LInteger:
				case SeleniumUserInterfaceSyntaxKind.LDecimal:
				case SeleniumUserInterfaceSyntaxKind.LScientific:
				case SeleniumUserInterfaceSyntaxKind.LRegularString:
				case SeleniumUserInterfaceSyntaxKind.LUtf8Bom:
				case SeleniumUserInterfaceSyntaxKind.LWhiteSpace:
				case SeleniumUserInterfaceSyntaxKind.LCrLf:
				case SeleniumUserInterfaceSyntaxKind.LLineEnd:
				case SeleniumUserInterfaceSyntaxKind.LSingleLineComment:
				case SeleniumUserInterfaceSyntaxKind.LComment:
				case SeleniumUserInterfaceSyntaxKind.LDoubleQuoteVerbatimString:
				case SeleniumUserInterfaceSyntaxKind.LSingleQuoteVerbatimString:
				case SeleniumUserInterfaceSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case SeleniumUserInterfaceSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case SeleniumUserInterfaceSyntaxKind.LCommentStart:
				case SeleniumUserInterfaceSyntaxKind.LComment_Star:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsFixedToken(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch (kind)
			{
				case SeleniumUserInterfaceSyntaxKind.Eof:
				case SeleniumUserInterfaceSyntaxKind.KParent:
				case SeleniumUserInterfaceSyntaxKind.KAncestor:
				case SeleniumUserInterfaceSyntaxKind.KPage:
				case SeleniumUserInterfaceSyntaxKind.KElement:
				case SeleniumUserInterfaceSyntaxKind.KInput:
				case SeleniumUserInterfaceSyntaxKind.KImage:
				case SeleniumUserInterfaceSyntaxKind.KLink:
				case SeleniumUserInterfaceSyntaxKind.KForm:
				case SeleniumUserInterfaceSyntaxKind.KLabel:
				case SeleniumUserInterfaceSyntaxKind.KCheckBox:
				case SeleniumUserInterfaceSyntaxKind.KTextField:
				case SeleniumUserInterfaceSyntaxKind.KTextArea:
				case SeleniumUserInterfaceSyntaxKind.KButton:
				case SeleniumUserInterfaceSyntaxKind.KRadioGroup:
				case SeleniumUserInterfaceSyntaxKind.KRadioButton:
				case SeleniumUserInterfaceSyntaxKind.KList:
				case SeleniumUserInterfaceSyntaxKind.KTable:
				case SeleniumUserInterfaceSyntaxKind.TSemicolon:
				case SeleniumUserInterfaceSyntaxKind.TColon:
				case SeleniumUserInterfaceSyntaxKind.TDot:
				case SeleniumUserInterfaceSyntaxKind.TComma:
				case SeleniumUserInterfaceSyntaxKind.TAssign:
				case SeleniumUserInterfaceSyntaxKind.TOpenParen:
				case SeleniumUserInterfaceSyntaxKind.TCloseParen:
				case SeleniumUserInterfaceSyntaxKind.TOpenBracket:
				case SeleniumUserInterfaceSyntaxKind.TCloseBracket:
				case SeleniumUserInterfaceSyntaxKind.TOpenBrace:
				case SeleniumUserInterfaceSyntaxKind.TCloseBrace:
				case SeleniumUserInterfaceSyntaxKind.TLessThan:
				case SeleniumUserInterfaceSyntaxKind.TGreaterThan:
				case SeleniumUserInterfaceSyntaxKind.TQuestion:
				case SeleniumUserInterfaceSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case SeleniumUserInterfaceSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case SeleniumUserInterfaceSyntaxKind.LCommentStart:
				case SeleniumUserInterfaceSyntaxKind.LComment_Star:
				case SeleniumUserInterfaceSyntaxKind.LDoubleQuoteVerbatimString:
				case SeleniumUserInterfaceSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}

		public override string GetText(int rawKind)
		{
			return this.GetText((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public string GetText(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch (kind)
			{
				case SeleniumUserInterfaceSyntaxKind.KParent:
					return "parent";
				case SeleniumUserInterfaceSyntaxKind.KAncestor:
					return "ancestor";
				case SeleniumUserInterfaceSyntaxKind.KPage:
					return "page";
				case SeleniumUserInterfaceSyntaxKind.KElement:
					return "element";
				case SeleniumUserInterfaceSyntaxKind.KInput:
					return "input";
				case SeleniumUserInterfaceSyntaxKind.KImage:
					return "image";
				case SeleniumUserInterfaceSyntaxKind.KLink:
					return "link";
				case SeleniumUserInterfaceSyntaxKind.KForm:
					return "form";
				case SeleniumUserInterfaceSyntaxKind.KLabel:
					return "label";
				case SeleniumUserInterfaceSyntaxKind.KCheckBox:
					return "checkbox";
				case SeleniumUserInterfaceSyntaxKind.KTextField:
					return "text-field";
				case SeleniumUserInterfaceSyntaxKind.KTextArea:
					return "text-area";
				case SeleniumUserInterfaceSyntaxKind.KButton:
					return "button";
				case SeleniumUserInterfaceSyntaxKind.KRadioGroup:
					return "radio-group";
				case SeleniumUserInterfaceSyntaxKind.KRadioButton:
					return "radio-button";
				case SeleniumUserInterfaceSyntaxKind.KList:
					return "list";
				case SeleniumUserInterfaceSyntaxKind.KTable:
					return "table";
				case SeleniumUserInterfaceSyntaxKind.TSemicolon:
					return ";";
				case SeleniumUserInterfaceSyntaxKind.TColon:
					return ":";
				case SeleniumUserInterfaceSyntaxKind.TDot:
					return ".";
				case SeleniumUserInterfaceSyntaxKind.TComma:
					return ",";
				case SeleniumUserInterfaceSyntaxKind.TAssign:
					return "=";
				case SeleniumUserInterfaceSyntaxKind.TOpenParen:
					return "(";
				case SeleniumUserInterfaceSyntaxKind.TCloseParen:
					return ")";
				case SeleniumUserInterfaceSyntaxKind.TOpenBracket:
					return "[";
				case SeleniumUserInterfaceSyntaxKind.TCloseBracket:
					return "]";
				case SeleniumUserInterfaceSyntaxKind.TOpenBrace:
					return "{";
				case SeleniumUserInterfaceSyntaxKind.TCloseBrace:
					return "}";
				case SeleniumUserInterfaceSyntaxKind.TLessThan:
					return "<";
				case SeleniumUserInterfaceSyntaxKind.TGreaterThan:
					return ">";
				case SeleniumUserInterfaceSyntaxKind.TQuestion:
					return "?";
				case SeleniumUserInterfaceSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case SeleniumUserInterfaceSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case SeleniumUserInterfaceSyntaxKind.LCommentStart:
					return "/*";
				case SeleniumUserInterfaceSyntaxKind.LComment_Star:
					return "*";
				case SeleniumUserInterfaceSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case SeleniumUserInterfaceSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public SeleniumUserInterfaceSyntaxKind GetKind(string text)
		{
			switch (text)
			{
				case "parent":
					return SeleniumUserInterfaceSyntaxKind.KParent;
				case "ancestor":
					return SeleniumUserInterfaceSyntaxKind.KAncestor;
				case "page":
					return SeleniumUserInterfaceSyntaxKind.KPage;
				case "element":
					return SeleniumUserInterfaceSyntaxKind.KElement;
				case "input":
					return SeleniumUserInterfaceSyntaxKind.KInput;
				case "image":
					return SeleniumUserInterfaceSyntaxKind.KImage;
				case "link":
					return SeleniumUserInterfaceSyntaxKind.KLink;
				case "form":
					return SeleniumUserInterfaceSyntaxKind.KForm;
				case "label":
					return SeleniumUserInterfaceSyntaxKind.KLabel;
				case "checkbox":
					return SeleniumUserInterfaceSyntaxKind.KCheckBox;
				case "text-field":
					return SeleniumUserInterfaceSyntaxKind.KTextField;
				case "text-area":
					return SeleniumUserInterfaceSyntaxKind.KTextArea;
				case "button":
					return SeleniumUserInterfaceSyntaxKind.KButton;
				case "radio-group":
					return SeleniumUserInterfaceSyntaxKind.KRadioGroup;
				case "radio-button":
					return SeleniumUserInterfaceSyntaxKind.KRadioButton;
				case "list":
					return SeleniumUserInterfaceSyntaxKind.KList;
				case "table":
					return SeleniumUserInterfaceSyntaxKind.KTable;
				case ";":
					return SeleniumUserInterfaceSyntaxKind.TSemicolon;
				case ":":
					return SeleniumUserInterfaceSyntaxKind.TColon;
				case ".":
					return SeleniumUserInterfaceSyntaxKind.TDot;
				case ",":
					return SeleniumUserInterfaceSyntaxKind.TComma;
				case "=":
					return SeleniumUserInterfaceSyntaxKind.TAssign;
				case "(":
					return SeleniumUserInterfaceSyntaxKind.TOpenParen;
				case ")":
					return SeleniumUserInterfaceSyntaxKind.TCloseParen;
				case "[":
					return SeleniumUserInterfaceSyntaxKind.TOpenBracket;
				case "]":
					return SeleniumUserInterfaceSyntaxKind.TCloseBracket;
				case "{":
					return SeleniumUserInterfaceSyntaxKind.TOpenBrace;
				case "}":
					return SeleniumUserInterfaceSyntaxKind.TCloseBrace;
				case "<":
					return SeleniumUserInterfaceSyntaxKind.TLessThan;
				case ">":
					return SeleniumUserInterfaceSyntaxKind.TGreaterThan;
				case "?":
					return SeleniumUserInterfaceSyntaxKind.TQuestion;
				case "@\"":
					return SeleniumUserInterfaceSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return SeleniumUserInterfaceSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return SeleniumUserInterfaceSyntaxKind.LCommentStart;
				case "*":
					return SeleniumUserInterfaceSyntaxKind.LComment_Star;
				case "\"":
					return SeleniumUserInterfaceSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return SeleniumUserInterfaceSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return SeleniumUserInterfaceSyntaxKind.None;
			}
		}

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public string GetKindText(SeleniumUserInterfaceSyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceSyntaxKind.LCrLf:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}

		public bool IsKeyword(int rawKind)
		{
			return this.IsKeyword((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsKeyword(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceSyntaxKind.KParent:
				case SeleniumUserInterfaceSyntaxKind.KAncestor:
				case SeleniumUserInterfaceSyntaxKind.KPage:
				case SeleniumUserInterfaceSyntaxKind.KElement:
				case SeleniumUserInterfaceSyntaxKind.KInput:
				case SeleniumUserInterfaceSyntaxKind.KImage:
				case SeleniumUserInterfaceSyntaxKind.KLink:
				case SeleniumUserInterfaceSyntaxKind.KForm:
				case SeleniumUserInterfaceSyntaxKind.KLabel:
				case SeleniumUserInterfaceSyntaxKind.KCheckBox:
				case SeleniumUserInterfaceSyntaxKind.KTextField:
				case SeleniumUserInterfaceSyntaxKind.KTextArea:
				case SeleniumUserInterfaceSyntaxKind.KButton:
				case SeleniumUserInterfaceSyntaxKind.KRadioGroup:
				case SeleniumUserInterfaceSyntaxKind.KRadioButton:
				case SeleniumUserInterfaceSyntaxKind.KList:
				case SeleniumUserInterfaceSyntaxKind.KTable:
					return true;
				default:
					return false;
			}
		}
		public bool IsIdentifier(int rawKind)
		{
			return this.IsIdentifier((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsIdentifier(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceSyntaxKind.Identifier:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(int rawKind)
		{
			return this.IsNumber((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsNumber(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceSyntaxKind.LInteger:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LDecimal:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LScientific:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(int rawKind)
		{
			return this.IsString((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsString(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceSyntaxKind.LRegularString:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(int rawKind)
		{
			return this.IsWhitespace((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsWhitespace(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceSyntaxKind.LUtf8Bom:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LWhiteSpace:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LCrLf:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(int rawKind)
		{
			return this.IsComment((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public bool IsComment(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceSyntaxKind.LSingleLineComment:
					return true;
				case SeleniumUserInterfaceSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}

		public SeleniumUserInterfaceTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((SeleniumUserInterfaceSyntaxKind)rawKind);
		}

		public SeleniumUserInterfaceTokenKind GetTokenKind(SeleniumUserInterfaceSyntaxKind kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceSyntaxKind.KParent:
				case SeleniumUserInterfaceSyntaxKind.KAncestor:
				case SeleniumUserInterfaceSyntaxKind.KPage:
				case SeleniumUserInterfaceSyntaxKind.KElement:
				case SeleniumUserInterfaceSyntaxKind.KInput:
				case SeleniumUserInterfaceSyntaxKind.KImage:
				case SeleniumUserInterfaceSyntaxKind.KLink:
				case SeleniumUserInterfaceSyntaxKind.KForm:
				case SeleniumUserInterfaceSyntaxKind.KLabel:
				case SeleniumUserInterfaceSyntaxKind.KCheckBox:
				case SeleniumUserInterfaceSyntaxKind.KTextField:
				case SeleniumUserInterfaceSyntaxKind.KTextArea:
				case SeleniumUserInterfaceSyntaxKind.KButton:
				case SeleniumUserInterfaceSyntaxKind.KRadioGroup:
				case SeleniumUserInterfaceSyntaxKind.KRadioButton:
				case SeleniumUserInterfaceSyntaxKind.KList:
				case SeleniumUserInterfaceSyntaxKind.KTable:
					return SeleniumUserInterfaceTokenKind.Keyword;
				case SeleniumUserInterfaceSyntaxKind.Identifier:
					return SeleniumUserInterfaceTokenKind.Identifier;
				case SeleniumUserInterfaceSyntaxKind.LInteger:
					return SeleniumUserInterfaceTokenKind.Number;
				case SeleniumUserInterfaceSyntaxKind.LDecimal:
					return SeleniumUserInterfaceTokenKind.Number;
				case SeleniumUserInterfaceSyntaxKind.LScientific:
					return SeleniumUserInterfaceTokenKind.Number;
				case SeleniumUserInterfaceSyntaxKind.LRegularString:
					return SeleniumUserInterfaceTokenKind.String;
				case SeleniumUserInterfaceSyntaxKind.LUtf8Bom:
					return SeleniumUserInterfaceTokenKind.Whitespace;
				case SeleniumUserInterfaceSyntaxKind.LWhiteSpace:
					return SeleniumUserInterfaceTokenKind.Whitespace;
				case SeleniumUserInterfaceSyntaxKind.LCrLf:
					return SeleniumUserInterfaceTokenKind.Whitespace;
				case SeleniumUserInterfaceSyntaxKind.LLineEnd:
					return SeleniumUserInterfaceTokenKind.Whitespace;
				case SeleniumUserInterfaceSyntaxKind.LSingleLineComment:
					return SeleniumUserInterfaceTokenKind.Comment;
				case SeleniumUserInterfaceSyntaxKind.LComment:
					return SeleniumUserInterfaceTokenKind.Comment;
				case SeleniumUserInterfaceSyntaxKind.LDoubleQuoteVerbatimString:
					return SeleniumUserInterfaceTokenKind.String;
				case SeleniumUserInterfaceSyntaxKind.LSingleQuoteVerbatimString:
					return SeleniumUserInterfaceTokenKind.String;
				default:
					return SeleniumUserInterfaceTokenKind.None;
			}
		}

		public SeleniumUserInterfaceTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((SeleniumUserInterfaceLexerMode)rawKind);
		}

		public SeleniumUserInterfaceTokenKind GetModeTokenKind(SeleniumUserInterfaceLexerMode kind)
		{
			switch(kind)
			{
				case SeleniumUserInterfaceLexerMode.LMultilineComment:
					return SeleniumUserInterfaceTokenKind.Comment;
				case SeleniumUserInterfaceLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return SeleniumUserInterfaceTokenKind.String;
				case SeleniumUserInterfaceLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return SeleniumUserInterfaceTokenKind.String;
				default:
					return SeleniumUserInterfaceTokenKind.None;
			}
		}
	}
}

