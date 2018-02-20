parser grammar MediaWikiParser;

options
{
    tokenVocab = MediaWikiLexer;
	                        
}

/*
// Java:
@parser::members {
    boolean isSpecialToken() {
    	String name = getCurrentToken().getText();
    	if (" ".equals(name) || name.startsWith("-") || name.startsWith("=") || name.startsWith("#") ||
    	    name.startsWith("*") || name.startsWith(":") || name.startsWith(";") || name.startsWith("{|") ||
    	    name.startsWith("|+") || name.startsWith("|-") || name.startsWith("|}") || name.startsWith("|") ||
    	    name.startsWith("!")) return true;
        return false;
    }
}
*/


// C#:
@parser::members {
    bool isSpecialToken() {
    	String name = this.CurrentToken.Text;
    	if (name == " " || name.StartsWith("-") || name.StartsWith("=") || name.StartsWith("#") ||
    	    name.StartsWith("*") || name.StartsWith(":") || name.StartsWith(";") || name.StartsWith("{|") ||
    	    name.StartsWith("|+") || name.StartsWith("|-") || name.StartsWith("|}") || name.StartsWith("|") ||
    	    name.StartsWith("!")) return true;
        return false;
    }
}

//$Root(Document)
main : specialBlockOrParagraph* EOF;

specialBlockOrParagraph
    : specialBlockWithComment
    | paragraph;

specialBlockWithComment
	: leadingComment=htmlCommentList {isSpecialToken()}? specialBlock trailingComment=htmlCommentList CRLF
	;

specialBlock
    : heading
    | horizontalRule
    | codeBlock
    | wikiList
    | wikiTable
    ;

heading : headingStart=headingLevel (headingText headingEnd=headingLevel)? inlineText?;

headingLevel : THeading;

horizontalRule : THorizontalLine inlineText?;

codeBlock : spaceBlock (CRLF spaceBlock)*;
spaceBlock : TSpaceBlockStart inlineText?;

wikiList : listItem (CRLF listItem)*;
listItem
    : normalListItem
    | definitionItem;
normalListItem : TListStart inlineText?;
definitionItem : TDefinitionStart definitionText? (TColon inlineText)?;


wikiTable : TTableStart leadingInlineText=inlineText? CRLF tableCaption? tableRows TTableEnd trailingInlineText=inlineText?;

tableCaption : TTableCaptionStart inlineText? CRLF specialBlockOrParagraph*;
tableRows : tableFirstRow tableRow*;
tableFirstRow : tableColumn*;
tableRow : TTableRowStart inlineText? CRLF tableColumn*;
tableColumn
    : tableSingleHeaderCell
    | tableHeaderCells
    | tableSingleCell
    | tableCells
    ;
tableSingleHeaderCell : TExclamation tableCell? CRLF specialBlockOrParagraph*;
tableHeaderCells : TExclamation tableCell (TExclExcl tableCell)* CRLF specialBlockOrParagraph*;
tableSingleCell : TBar tableCell? CRLF specialBlockOrParagraph*;
tableCells : TBar tableCell (TBarBar tableCell)* CRLF specialBlockOrParagraph*;
tableCell : cellText? cellValue?;

cellValue : TBar cellText?;

paragraph : textLine+;
textLine
    : leadingComment=htmlCommentList {!isSpecialToken()}? inlineTextElement+ trailingComment=htmlCommentList CRLF #textLineInlineElementsWithComment
    | htmlCommentList CRLF #textLineComment
	;


textElements
    : wikiFormat
    | wikiLink
    | wikiTemplate
    | wikiTemplateParam
    | noWiki
    | htmlReference
    | htmlStyle
    | htmlScript
    | htmlTag
    ;

inlineText : inlineTextElementWithComment+ trailingComment=htmlCommentList;
inlineTextElementWithComment : leadingComment=htmlCommentList inlineTextElement;
inlineTextElement
    : textElements
    | inlineTextElements;
inlineTextElements : TNormalText | TWhiteSpace | TComma | TBar | TBarBar | TExclamation | TExclExcl | TApos | TColon | TSpecialChars | THeading;

definitionText : definitionTextElementWithComment+ trailingComment=htmlCommentList;
definitionTextElementWithComment : leadingComment=htmlCommentList definitionTextElement;
definitionTextElement
    : textElements
    | definitionTextElements;
definitionTextElements : TNormalText | TWhiteSpace | TComma | TBar | TBarBar | TExclamation | TExclExcl | TApos | TSpecialChars | THeading;

headingText : headingTextWithComment+ trailingComment=htmlCommentList;
headingTextWithComment : leadingComment=htmlCommentList headingTextElement;
headingTextElement
    : textElements
    | headingTextElements;
headingTextElements : TNormalText | TWhiteSpace | TComma | TBar | TBarBar | TExclamation | TExclExcl | TApos | TColon | TSpecialChars;

cellText : cellTextElementWithComment+ trailingComment=htmlCommentList;
cellTextElementWithComment : leadingComment=htmlCommentList cellTextElement;
cellTextElement
    : textElements
    | cellTextElements;
cellTextElements : TNormalText | TWhiteSpace | TComma | TApos | TColon | TSpecialChars | THeading;

linkText : linkTextWithComment+ trailingComment=htmlCommentList;
linkTextWithComment : leadingComment=htmlCommentList linkTextElement;
linkTextElement
    : textElements
    | linkTextElements;
linkTextElements : TNormalText | TWhiteSpace | TComma | TExclamation | TExclExcl | TApos | TColon | TSpecialChars | THeading;


wikiFormat
    : TFormat
    ;
wikiLink
    : wikiInternalLink
    | wikiExternalLink ;
wikiInternalLink
    : TLinkStart linkText linkTextPart* TLinkEnd
    ;
wikiExternalLink
    : TExternalLinkStart linkText linkTextPart* TExternalLinkEnd
    ;
wikiTemplate
    : TTemplateStart linkText linkTextPart* TTemplateEnd
    ;
wikiTemplateParam
    : TTemplateParamStart linkText linkTextPart* TTemplateParamEnd
    ;
noWiki
    : TNoWiki
    ;

barOrBarBar : TBar | TBarBar;

linkTextPart : barOrBarBar linkText;

htmlReference
    : TEntityRef | TCharRef
    ;

htmlCommentList: htmlComment*;

htmlComment
    : THtmlComment
    ;

htmlStyle
    : THtmlStyle
    ;
htmlScript
    : THtmlScript
    ;

htmlTag
    : htmlTagOpen
    | htmlTagClose
    | htmlTagEmpty
    ;

htmlTagOpen
    : TTagStart leadingWhitespace=whitespaceList htmlTagName htmlAttribute* trailingWhitespace=whitespaceList TTagEnd
    ;

htmlTagClose
    : TEndTagStart leadingWhitespace=whitespaceList htmlTagName htmlAttribute* trailingWhitespace=whitespaceList TEndTagEnd
    ;

htmlTagEmpty
    : TTagStart leadingWhitespace=whitespaceList htmlTagName htmlAttribute* trailingWhitespace=whitespaceList TTagCloseEnd
    ;

htmlAttribute
    : leadingWhitespace=whitespaceList htmlAttributeName whitespaceBeforeEquals=whitespaceList TAttributeEquals whitespaceAfterEquals=whitespaceList htmlAttributeValue #htmlAttributeWithValue
    | leadingWhitespace=whitespaceList htmlAttributeName #htmlAttributeWithNoValue
    ;

htmlAttributeName
    : TTagName
    ;

htmlAttributeValue
    : TAttributeValue
    ;

htmlTagName
    : TTagName
    ;

whitespaceList : whitespace*;
whitespace : TWhiteSpace | CRLF;
