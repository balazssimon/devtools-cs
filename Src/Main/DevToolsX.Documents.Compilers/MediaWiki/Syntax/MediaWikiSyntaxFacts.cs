using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace DevToolsX.Documents.Compilers.MediaWiki.Syntax
{
	public enum MediaWikiTokenKind : int
	{
		None = 0,
	}

	public enum MediaWikiLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		TEXT_LINE = 1,
		REFERENCE = 2,
		TAG = 3,
		END_TAG = 4,
		TABLE = 5
	}

	public class MediaWikiSyntaxFacts : SyntaxFacts
	{
		public static readonly MediaWikiSyntaxFacts Instance = new MediaWikiSyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)MediaWikiSyntaxKind.None; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)MediaWikiSyntaxKind.None; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((MediaWikiSyntaxKind)rawKind);
		}

		public bool IsToken(MediaWikiSyntaxKind kind)
		{
			switch (kind)
			{
				case MediaWikiSyntaxKind.Eof:
				case MediaWikiSyntaxKind.THorizontalLine:
				case MediaWikiSyntaxKind.THeading:
				case MediaWikiSyntaxKind.TDefinitionStart:
				case MediaWikiSyntaxKind.TListStart:
				case MediaWikiSyntaxKind.TSpaceBlockStart:
				case MediaWikiSyntaxKind.TTableStart:
				case MediaWikiSyntaxKind.TFormat:
				case MediaWikiSyntaxKind.TLinkStart:
				case MediaWikiSyntaxKind.TExternalLinkStart:
				case MediaWikiSyntaxKind.TTemplateParamStart:
				case MediaWikiSyntaxKind.TTemplateStart:
				case MediaWikiSyntaxKind.THtmlComment:
				case MediaWikiSyntaxKind.TNoWiki:
				case MediaWikiSyntaxKind.THtmlScript:
				case MediaWikiSyntaxKind.THtmlStyle:
				case MediaWikiSyntaxKind.TEndTagStart:
				case MediaWikiSyntaxKind.TTagStart:
				case MediaWikiSyntaxKind.TNormalText:
				case MediaWikiSyntaxKind.TComma:
				case MediaWikiSyntaxKind.TWhiteSpace:
				case MediaWikiSyntaxKind.UTF8BOM:
				case MediaWikiSyntaxKind.CRLF:
				case MediaWikiSyntaxKind.TBar:
				case MediaWikiSyntaxKind.TExclamation:
				case MediaWikiSyntaxKind.TApos:
				case MediaWikiSyntaxKind.TSpecialChars:
				case MediaWikiSyntaxKind.TLinkEnd:
				case MediaWikiSyntaxKind.TExternalLinkEnd:
				case MediaWikiSyntaxKind.TTemplateParamEnd:
				case MediaWikiSyntaxKind.TTemplateEnd:
				case MediaWikiSyntaxKind.TBarBar:
				case MediaWikiSyntaxKind.TExclExcl:
				case MediaWikiSyntaxKind.TColon:
				case MediaWikiSyntaxKind.TEntityRef:
				case MediaWikiSyntaxKind.TCharRef:
				case MediaWikiSyntaxKind.TTagEnd:
				case MediaWikiSyntaxKind.TTagCloseEnd:
				case MediaWikiSyntaxKind.TAttributeEquals:
				case MediaWikiSyntaxKind.TTagName:
				case MediaWikiSyntaxKind.TAttributeValue:
				case MediaWikiSyntaxKind.TEndTagEnd:
				case MediaWikiSyntaxKind.TTableEnd:
				case MediaWikiSyntaxKind.TTableCaptionStart:
				case MediaWikiSyntaxKind.TTableRowStart:
				case MediaWikiSyntaxKind.TTextLine_RefStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((MediaWikiSyntaxKind)rawKind);
		}

		public bool IsFixedToken(MediaWikiSyntaxKind kind)
		{
			switch (kind)
			{
				case MediaWikiSyntaxKind.Eof:
				case MediaWikiSyntaxKind.TSpaceBlockStart:
				case MediaWikiSyntaxKind.TExclamation:
				case MediaWikiSyntaxKind.TTextLine_RefStart:
				case MediaWikiSyntaxKind.TLinkEnd:
				case MediaWikiSyntaxKind.TExternalLinkEnd:
				case MediaWikiSyntaxKind.TTemplateParamEnd:
				case MediaWikiSyntaxKind.TTemplateEnd:
				case MediaWikiSyntaxKind.TBarBar:
				case MediaWikiSyntaxKind.TExclExcl:
				case MediaWikiSyntaxKind.TColon:
				case MediaWikiSyntaxKind.TTagCloseEnd:
				case MediaWikiSyntaxKind.TAttributeEquals:
				case MediaWikiSyntaxKind.TTableEnd:
				case MediaWikiSyntaxKind.TTableCaptionStart:
				case MediaWikiSyntaxKind.TTableRowStart:
					return true;
				default:
					return false;
			}
		}

		public override string GetText(int rawKind)
		{
			return this.GetText((MediaWikiSyntaxKind)rawKind);
		}

		public string GetText(MediaWikiSyntaxKind kind)
		{
			switch (kind)
			{
				case MediaWikiSyntaxKind.TSpaceBlockStart:
					return " ";
				case MediaWikiSyntaxKind.TExclamation:
					return "!";
				case MediaWikiSyntaxKind.TTextLine_RefStart:
					return "&";
				case MediaWikiSyntaxKind.TLinkEnd:
					return "]]";
				case MediaWikiSyntaxKind.TExternalLinkEnd:
					return "]";
				case MediaWikiSyntaxKind.TTemplateParamEnd:
					return "}}}";
				case MediaWikiSyntaxKind.TTemplateEnd:
					return "}}";
				case MediaWikiSyntaxKind.TBarBar:
					return "||";
				case MediaWikiSyntaxKind.TExclExcl:
					return "!!";
				case MediaWikiSyntaxKind.TColon:
					return ":";
				case MediaWikiSyntaxKind.TTagCloseEnd:
					return "/>";
				case MediaWikiSyntaxKind.TAttributeEquals:
					return "=";
				case MediaWikiSyntaxKind.TTableEnd:
					return "|}";
				case MediaWikiSyntaxKind.TTableCaptionStart:
					return "|+";
				case MediaWikiSyntaxKind.TTableRowStart:
					return "|-";
				default:
					return string.Empty;
			}
		}

		public MediaWikiSyntaxKind GetKind(string text)
		{
			switch (text)
			{
				case " ":
					return MediaWikiSyntaxKind.TSpaceBlockStart;
				case "!":
					return MediaWikiSyntaxKind.TExclamation;
				case "&":
					return MediaWikiSyntaxKind.TTextLine_RefStart;
				case "]]":
					return MediaWikiSyntaxKind.TLinkEnd;
				case "]":
					return MediaWikiSyntaxKind.TExternalLinkEnd;
				case "}}}":
					return MediaWikiSyntaxKind.TTemplateParamEnd;
				case "}}":
					return MediaWikiSyntaxKind.TTemplateEnd;
				case "||":
					return MediaWikiSyntaxKind.TBarBar;
				case "!!":
					return MediaWikiSyntaxKind.TExclExcl;
				case ":":
					return MediaWikiSyntaxKind.TColon;
				case "/>":
					return MediaWikiSyntaxKind.TTagCloseEnd;
				case "=":
					return MediaWikiSyntaxKind.TAttributeEquals;
				case "|}":
					return MediaWikiSyntaxKind.TTableEnd;
				case "|+":
					return MediaWikiSyntaxKind.TTableCaptionStart;
				case "|-":
					return MediaWikiSyntaxKind.TTableRowStart;
				default:
					return MediaWikiSyntaxKind.None;
			}
		}

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((MediaWikiSyntaxKind)rawKind);
		}

		public string GetKindText(MediaWikiSyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((MediaWikiSyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(MediaWikiSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return false;
			}
		}


		public MediaWikiTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((MediaWikiSyntaxKind)rawKind);
		}

		public MediaWikiTokenKind GetTokenKind(MediaWikiSyntaxKind kind)
		{
			switch(kind)
			{
				default:
					return MediaWikiTokenKind.None;
			}
		}

		public MediaWikiTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((MediaWikiLexerMode)rawKind);
		}

		public MediaWikiTokenKind GetModeTokenKind(MediaWikiLexerMode kind)
		{
			switch(kind)
			{
				default:
					return MediaWikiTokenKind.None;
			}
		}
	}
}

