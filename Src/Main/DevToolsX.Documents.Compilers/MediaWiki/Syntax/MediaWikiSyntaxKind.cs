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

namespace DevToolsX.Documents.Compilers.MediaWiki.Syntax
{
	public enum MediaWikiSyntaxKind : int
	{
        None                          = SyntaxKind.None,
        List                          = SyntaxKind.List,
        BadToken                      = SyntaxKind.BadToken,
        Eof                           = SyntaxKind.Eof,

		// Tokens:
		THorizontalLine = 1,
		THeading = 2,
		TDefinitionStart = 3,
		TListStart = 4,
		TSpaceBlockStart = 5,
		TTableStart = 6,
		TFormat = 7,
		TLinkStart = 8,
		TExternalLinkStart = 9,
		TTemplateParamStart = 10,
		TTemplateStart = 11,
		THtmlComment = 12,
		TNoWiki = 13,
		THtmlScript = 14,
		THtmlStyle = 15,
		TEndTagStart = 16,
		TTagStart = 17,
		TNormalText = 18,
		TComma = 19,
		TWhiteSpace = 20,
		UTF8BOM = 21,
		CRLF = 22,
		TBar = 23,
		TExclamation = 24,
		TApos = 25,
		TSpecialChars = 26,
		TLinkEnd = 27,
		TExternalLinkEnd = 28,
		TTemplateParamEnd = 29,
		TTemplateEnd = 30,
		TBarBar = 31,
		TExclExcl = 32,
		TColon = 33,
		TEntityRef = 34,
		TCharRef = 35,
		TTagEnd = 36,
		TTagCloseEnd = 37,
		TAttributeEquals = 38,
		TTagName = 39,
		TAttributeValue = 40,
		TEndTagEnd = 41,
		TTableEnd = 42,
		TTableCaptionStart = 43,
		TTableRowStart = 44,
		TTextLine_RefStart = 45,
		LastTokenSyntaxKind = 45,

		// Rules:
		Main,
		SpecialBlockOrParagraph,
		SpecialBlockWithComment,
		SpecialBlock,
		Heading,
		HeadingLevel,
		HorizontalRule,
		CodeBlock,
		SpaceBlock,
		WikiList,
		ListItem,
		NormalListItem,
		DefinitionItem,
		WikiTable,
		TableCaption,
		TableRows,
		TableFirstRow,
		TableRow,
		TableColumn,
		TableSingleHeaderCell,
		TableHeaderCells,
		TableSingleCell,
		TableCells,
		TableCell,
		CellValue,
		Paragraph,
		TextLineInlineElementsWithComment,
		TextLineComment,
		TextElements,
		InlineText,
		InlineTextElementWithComment,
		InlineTextElement,
		InlineTextElements,
		DefinitionText,
		DefinitionTextElementWithComment,
		DefinitionTextElement,
		DefinitionTextElements,
		HeadingText,
		HeadingTextWithComment,
		HeadingTextElement,
		HeadingTextElements,
		CellText,
		CellTextElementWithComment,
		CellTextElement,
		CellTextElements,
		LinkText,
		LinkTextWithComment,
		LinkTextElement,
		LinkTextElements,
		WikiFormat,
		WikiLink,
		WikiInternalLink,
		WikiExternalLink,
		WikiTemplate,
		WikiTemplateParam,
		NoWiki,
		BarOrBarBar,
		LinkTextPart,
		HtmlReference,
		HtmlCommentList,
		HtmlComment,
		HtmlStyle,
		HtmlScript,
		HtmlTag,
		HtmlTagOpen,
		HtmlTagClose,
		HtmlTagEmpty,
		HtmlAttributeWithValue,
		HtmlAttributeWithNoValue,
		HtmlAttributeName,
		HtmlAttributeValue,
		HtmlTagName,
		WhitespaceList,
		Whitespace,
	}
}

