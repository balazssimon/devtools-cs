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
    	String name = this.Text;
    	if (name == || name.StartsWith("-") || name.StartsWith("=") || name.StartsWith("#") ||
    	    name.StartsWith("*") || name.StartsWith(":") || name.StartsWith(";") || name.StartsWith("{|") ||
    	    name.StartsWith("|+") || name.StartsWith("|-") || name.StartsWith("|}") || name.StartsWith("|") ||
    	    name.StartsWith("!")) return true;
        return false;
    }
}


main : specialBlockOrParagraph*;

specialBlockOrParagraph
    : htmlComment* {isSpecialToken()}? specialBlock htmlComment* CRLF
    | paragraph;

specialBlock
    : heading
    | horizontalRule
    | spaceBlock
    | listItem
    | table
    ;

heading : THeading (headingText THeading)? inlineText?;

horizontalRule : THorizontalLine inlineText?;

spaceBlock : TSpaceBlockStart inlineText?;

listItem
    : normalListItem
    | definitionItem;

normalListItem : TListStart inlineText?;
definitionItem : TDefinitionStart definitionText? (TColon inlineText)?;


table : TTableStart inlineText? CRLF tableCaption? tableRows TTableEnd inlineText?;

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
tableCell : cellText (TBar cellText?)*;

paragraph : textLine+;
textLine
    : htmlComment* {!isSpecialToken()}? inlineTextElement+ htmlComment* CRLF
    | htmlComment* CRLF;

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

inlineText : (htmlComment* inlineTextElement)+ htmlComment*;
inlineTextElement
    : textElements
    | inlineTextElements;
inlineTextElements : TNormalText | TWhiteSpace |  TBar | TBarBar | TExclamation | TExclExcl | TApos | TColon | TSpecialChars | THeading;

definitionText : (htmlComment* definitionTextElement)+ htmlComment*;
definitionTextElement
    : textElements
    | definitionTextElements;
definitionTextElements : TNormalText | TWhiteSpace |  TBar | TBarBar | TExclamation | TExclExcl | TApos | TSpecialChars | THeading;

headingText : (htmlComment* headingTextElement)+ htmlComment*;
headingTextElement
    : textElements
    | headingTextElements;
headingTextElements : TNormalText | TWhiteSpace | TBar | TBarBar | TExclamation | TExclExcl | TApos | TColon | TSpecialChars;

cellText : (htmlComment* cellTextElement)+ htmlComment*;
cellTextElement
    : textElements
    | cellTextElements;
cellTextElements : TNormalText | TWhiteSpace | TApos | TColon | TSpecialChars | THeading;

linkText : (htmlComment* linkTextElement)+ htmlComment*;
linkTextElement
    : textElements
    | linkTextElements;
linkTextElements : TNormalText | TWhiteSpace | TExclamation | TExclExcl | TApos | TColon | TSpecialChars | THeading;


wikiFormat
    : TFormat
    ;
wikiLink
    : wikiInternalLink
    | wikiExternalLink ;
wikiInternalLink
    : TLinkStart linkText ((TBar | TBarBar) linkText)* TLinkEnd
    ;
wikiExternalLink
    : TExternalLinkStart linkText ((TBar | TBarBar) linkText)* TExternalLinkEnd
    ;
wikiTemplate
    : TTemplateStart linkText ((TBar | TBarBar) linkText)* TTemplateEnd
    ;
wikiTemplateParam
    : TTemplateParamStart linkText ((TBar | TBarBar) linkText)* TTemplateParamEnd
    ;
noWiki
    : TNoWiki
    ;
htmlReference
    : TEntityRef | TCharRef
    ;
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
    : TTagStart (TWhiteSpace|CRLF)* htmlTagName htmlAttribute* (TWhiteSpace|CRLF)* TTagEnd
    ;

htmlTagClose
    : TEndTagStart (TWhiteSpace|CRLF)* htmlTagName htmlAttribute* (TWhiteSpace|CRLF)* TEndTagEnd
    ;

htmlTagEmpty
    : TTagStart (TWhiteSpace|CRLF)* htmlTagName htmlAttribute* (TWhiteSpace|CRLF)* TTagCloseEnd
    ;

htmlAttribute
    : (TWhiteSpace|CRLF)* htmlAttributeName (TWhiteSpace|CRLF)* TAttributeEquals (TWhiteSpace|CRLF)* htmlAttributeValue
    | (TWhiteSpace|CRLF)* htmlAttributeName
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

