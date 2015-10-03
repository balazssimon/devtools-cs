lexer grammar MediaWikiLexer;

THorizontalLine : '----' '-'* -> pushMode(TEXT_LINE);
THeading : '='+ -> pushMode(TEXT_LINE);
TDefinitionStart : ListStart? ';' -> pushMode(TEXT_LINE);
TListStart : ListStart -> pushMode(TEXT_LINE);
TSpaceBlockStart : ' ' -> pushMode(TEXT_LINE);
TTableStart : '{|' -> pushMode(TABLE), pushMode(TEXT_LINE);

TFormat : '\'' '\''+ -> pushMode(TEXT_LINE);
TLinkStart : '[[' -> pushMode(TEXT_LINE);
TExternalLinkStart : '[' -> pushMode(TEXT_LINE);
TTemplateParamStart : '{{{' -> pushMode(TEXT_LINE);
TTemplateStart : '{{' -> pushMode(TEXT_LINE);
TRefStart : '&' -> more, pushMode(TEXT_LINE), pushMode(REFERENCE);

THtmlComment : '<!--' .*? '-->';
TNoWiki : ('<nowiki' TWhiteSpace? '/>' | '<nowiki' TWhiteSpace? '>' .*? '</nowiki' TWhiteSpace? '>') -> pushMode(TEXT_LINE);
THtmlScript : ('<script' TWhiteSpace? '/>' | '<script' TWhiteSpace? '>' .*? '</script' TWhiteSpace? '>') -> pushMode(TEXT_LINE);
THtmlStyle : ('<style' TWhiteSpace? '/>' | '<style' TWhiteSpace? '>' .*? '</style' TWhiteSpace? '>') -> pushMode(TEXT_LINE);
TEndTagStart : '</' -> pushMode(TEXT_LINE), pushMode(END_TAG);
TTagStart : '<' -> pushMode(TEXT_LINE), pushMode(TAG);

TNormalText : ~('-'|'='|'|'|':'|'#'|'*'|';'|'['|']'|'{'|'}'|'&'|'<'|'>'|'!'|'\''|[\u0020\u0009\u000B\u000C\u00A0\u001A\r\n\u0085\u2028\u2029])+ -> pushMode(TEXT_LINE);
TWhiteSpace : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> pushMode(TEXT_LINE);
UTF8BOM : [\u00EF][\u00BB][\u00BF] -> skip;
CRLF : '\r'? '\n';
TBar : '|' -> pushMode(TEXT_LINE);
TExclamation : '!' -> pushMode(TEXT_LINE);
TApos : '\'' -> pushMode(TEXT_LINE);
TSpecialChars : .+? -> pushMode(TEXT_LINE);

fragment Name : NameStartChar NameChar*;

fragment HexDigit : [a-fA-F0-9];

fragment Digit : [0-9];


/*fragment NameChar
    : NameStartChar
    | '-' | '_' | '.' | Digit;

fragment NameStartChar
    : [:a-zA-Z];
*/

fragment NameChar
    : NameStartChar
    | '-' | '_' | '.' | Digit
    | '\u00B7'
    | '\u0300'..'\u036F'
    | '\u203F'..'\u2040'
    ;

fragment NameStartChar
    : [:a-zA-Z]
    | '\u2070'..'\u218F'
    | '\u2C00'..'\u2FEF'
    | '\u3001'..'\uD7FF'
    | '\uF900'..'\uFDCF'
    | '\uFDF0'..'\uFFFD'
    ;

fragment ListStart : (':'|'#'|'*')+;

mode TEXT_LINE;

TTextLine_Heading : '='+ -> type(THeading);
TTextLine_Format : '\'' '\''+ -> type(TFormat);
TTextLine_LinkStart : '[[' -> type(TLinkStart);
TTextLine_ExternalLinkStart : '[' -> type(TExternalLinkStart);
TTextLine_TemplateParamStart : '{{{' -> type(TTemplateParamStart);
TTextLine_TemplateStart : '{{' -> type(TTemplateStart);
TTextLine_RefStart : '&' -> more, pushMode(REFERENCE);
TLinkEnd : ']]';
TExternalLinkEnd : ']';
TTemplateParamEnd : '}}}';
TTemplateEnd : '}}';

TTextLine_HtmlComment : '<!--' .*? '-->' -> type(THtmlComment);
TTextLine_NoWiki : ('<nowiki' TWhiteSpace? '/>' | '<nowiki' TWhiteSpace? '>' .*? '</nowiki' TWhiteSpace? '>') -> type(TNoWiki);
TTextLine_HtmlScript : ('<script' TWhiteSpace? '/>' | '<script' TWhiteSpace? '>' .*? '</script' TWhiteSpace? '>') -> type(THtmlScript);
TTextLine_HtmlStyle : ('<style' TWhiteSpace? '/>' | '<style' TWhiteSpace? '>' .*? '</style' TWhiteSpace? '>') -> type(THtmlStyle);
TTextLine_EndTagStart : '</' -> pushMode(END_TAG), type(TEndTagStart);
TTextLine_TagStart : '<' -> pushMode(TAG), type(TTagStart);

TTextLine_NormalText : ~('-'|'='|'|'|':'|'#'|'*'|';'|'['|']'|'{'|'}'|'&'|'<'|'>'|'!'|'\''|[\u0020\u0009\u000B\u000C\u00A0\u001A\r\n\u0085\u2028\u2029])+ -> type(TNormalText);
TTextLine_WhiteSpace : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(TWhiteSpace);
TTextLine_CRLF : '\r'? '\n' -> popMode, type(CRLF);
TBarBar : '||';
TExclExcl : '!!';
TColon : ':';
TTextLine_TBar : '|' -> type(TBar);
TTextLine_Exclamation : '!' -> pushMode(TEXT_LINE), type(TExclamation);
TTextLine_TApos : '\'' -> type(TApos);
TTextLine_SpecialChars : .+? -> type(TSpecialChars);


mode REFERENCE;

TEntityRef : Name ';' -> popMode;
TCharRef : CHARREF ';' -> popMode;

fragment CHARREF
    : '#' Digit+
    | '#x' HexDigit+
    ;


mode TAG;

TTagEnd : '>' -> popMode;
TTagCloseEnd : '/>' -> popMode;

TAttributeEquals : '=';
TTag_WhiteSpace : [ \t]+ -> type(TWhiteSpace);
TTag_CRLF : '\r'? '\n' -> type(CRLF);

TTagName : Name;
TAttributeValue
    : DOUBLE_QUOTE_STRING
    | SINGLE_QUOTE_STRING
    | ATTCHARS
    | HEXCHARS
    | DECCHARS
    ;

mode END_TAG;

TEndTagEnd : '>' -> popMode;

TEndTag_WhiteSpace : [ \t]+ -> type(TWhiteSpace);
TEndTag_CRLF : '\r'? '\n' -> type(CRLF);

TEndTagName : Name -> type(TTagName);


fragment ATTCHAR
    : '-'
    | '_'
    | '.'
//    | '/'
    | '+'
    | ','
    | '?'
//    | '='
    | ':'
    | ';'
    | '#'
    | [0-9a-zA-Z]
    ;

fragment ATTCHARS
    : ATTCHAR+
    ;

fragment HEXCHARS
    : '#' [0-9a-fA-F]+
    ;

fragment DECCHARS
    : [0-9]+ '%'?
    ;

fragment DOUBLE_QUOTE_STRING
    : '"' ~[<"]* '"'
    ;
fragment SINGLE_QUOTE_STRING
    : '\'' ~[<']* '\''
    ;



mode TABLE;

TTableEnd : '|}' -> popMode, pushMode(TEXT_LINE);
TTable_HorizontalLine : '----' '-'* -> pushMode(TEXT_LINE), type(THorizontalLine);
TTable_Heading : '='+ -> pushMode(TEXT_LINE), type(THeading);
TTable_DefinitionStart : ListStart? ';' -> pushMode(TEXT_LINE), type(TDefinitionStart);
TTable_ListStart : ListStart -> pushMode(TEXT_LINE), type(TListStart);
TTable_SpaceBlockStart : ' ' -> pushMode(TEXT_LINE), type(TSpaceBlockStart);
TTable_TableStart : '{|' -> pushMode(TABLE), pushMode(TEXT_LINE), type(TTableStart);
TTableCaptionStart : '|+' -> pushMode(TEXT_LINE);
TTableRowStart : '|-' -> pushMode(TEXT_LINE);
TTableColumnStart : '|' -> pushMode(TEXT_LINE), type(TBar);
TTableHeaderColumnStart : '!' -> pushMode(TEXT_LINE), type(TExclamation);

TTable_Format : '\'' '\''+ -> pushMode(TEXT_LINE), type(TFormat);
TTable_LinkStart : '[[' -> pushMode(TEXT_LINE), type(TLinkStart);
TTable_TExternalLinkStart : '[' -> pushMode(TEXT_LINE), type(TExternalLinkStart);
TTable_TemplateParamStart : '{{{' -> pushMode(TEXT_LINE), type(TTemplateParamStart);
TTable_TemplateStart : '{{' -> pushMode(TEXT_LINE), type(TTemplateStart);
TTable_RefStart : '&' -> more, pushMode(TEXT_LINE), pushMode(REFERENCE);

TTable_THtmlComment : '<!--' .*? '-->' -> type(THtmlComment);
TTable_TNoWiki : ('<nowiki' TWhiteSpace? '/>' | '<nowiki' TWhiteSpace? '>' .*? '</nowiki' TWhiteSpace? '>') -> pushMode(TEXT_LINE), type(TNoWiki);
TTable_THtmlScript : ('<script' TWhiteSpace? '/>' | '<script' TWhiteSpace? '>' .*? '</script' TWhiteSpace? '>') -> pushMode(TEXT_LINE), type(THtmlScript);
TTable_THtmlStyle : ('<style' TWhiteSpace? '/>' | '<style' TWhiteSpace? '>' .*? '</style' TWhiteSpace? '>') -> pushMode(TEXT_LINE), type(THtmlStyle);
TTable_EndTagStart : '</' -> pushMode(TEXT_LINE), pushMode(END_TAG), type(TEndTagStart);
TTable_TTagStart : '<' -> pushMode(TEXT_LINE), pushMode(TAG), type(TTagStart);

TTable_NormalText : ~('-'|'='|'|'|':'|'#'|'*'|';'|'['|']'|'{'|'}'|'&'|'<'|'>'|'!'|'\''|[\u0020\u0009\u000B\u000C\u00A0\u001A\r\n\u0085\u2028\u2029])+ -> type(TNormalText), pushMode(TEXT_LINE);
TTable_WhiteSpace : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(TWhiteSpace), pushMode(TEXT_LINE);
TTable_TApos : '\'' -> pushMode(TEXT_LINE), type(TApos);
TTable_TBar : '|' -> pushMode(TEXT_LINE), type(TBar);
TTable_TExclamation : '!' -> pushMode(TEXT_LINE), type(TExclamation);
TTable_CRLF : '\r'? '\n' -> type(CRLF);
TTable_SpecialChars : .+? -> pushMode(TEXT_LINE), type(TSpecialChars);
