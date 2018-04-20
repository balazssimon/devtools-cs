lexer grammar SeleniumUILexer;

options
{
	                        
}

channels
{
	COMMENT,
	WHITESPACE
}

                                            
KParent: 'parent';
KAncestor: 'ancestor';

KNamespace: 'namespace';
KPage: 'page';
KElement: 'element';
KTag: 'tag';

TSemicolon : ';';
TColon : ':';
TDot : '.';
TComma : ',';
TAssign : '=';
TOpenParen : '(';
TCloseParen : ')';
TOpenBracket : '[';
TCloseBracket : ']';
TOpenBrace : '{';
TCloseBrace : '}';
TLessThan : '<';
TGreaterThan : '>';
TQuestion : '?';



                       
LIdentifier : IdentifierBegin IdentifierCharacter*;
fragment IdentifierBegin : [a-zA-Z_];
fragment IdentifierCharacter : [a-zA-Z0-9_];

                   
LInteger : DecimalDigits | Hexadecimal;
                   
                   
LDecimal : DecimalDigit+ '.' DecimalDigit+;
                   
                   
LScientific : LDecimal [eE] Sign? DecimalDigit+;

fragment DecimalDigits : DecimalDigit+;
fragment DecimalDigit : [0-9];
fragment Sign : '+' | '-';
fragment Hexadecimal : ('0x'|'0X') HexDigit*;
fragment HexDigit : [0-9a-fA-F];

                   
LRegularString
    : '"' DoubleQuoteTextCharacter* '"'
    | '\'' SingleQuoteTextCharacter* '\'';

DoubleQuoteVerbatimStringLiteralStart : '@"' -> more, mode(DOUBLEQUOTE_VERBATIM_STRING);
SingleQuoteVerbatimStringLiteralStart : '@\'' -> more, mode(SINGLEQUOTE_VERBATIM_STRING);
fragment SingleQuoteTextCharacter 
    : SingleQuoteTextSimple | CharacterEscapeSimple | CharacterEscapeUnicode;
fragment SingleQuoteTextSimple 
    : ~('\'' | '\\' | '\u000A' | '\u000D' | '\u0085' | '\u2028' | '\u2029');
fragment SingleQuoteTextVerbatimCharacter 
    : ~'\'' | SingleQuoteTextVerbatimCharacterEscape;
fragment SingleQuoteTextVerbatimCharacterEscape : '\'' '\'';
fragment SingleQuoteTextVerbatimCharacters : SingleQuoteTextVerbatimCharacter+;
fragment DoubleQuoteTextCharacter 
    : DoubleQuoteTextSimple | CharacterEscapeSimple | CharacterEscapeUnicode;
fragment DoubleQuoteTextSimple 
    : ~('"' | '\\' | '\u000A' | '\u000D' | '\u0085' | '\u2028' | '\u2029');
fragment DoubleQuoteTextVerbatimCharacter 
    : ~'"' | DoubleQuoteTextVerbatimCharacterEscape;
fragment DoubleQuoteTextVerbatimCharacterEscape : '"' '"';
fragment DoubleQuoteTextVerbatimCharacters : DoubleQuoteTextVerbatimCharacter+;
fragment CharacterEscapeSimple : '\\' CharacterEscapeSimpleCharacter;
fragment CharacterEscapeSimpleCharacter 
    : '\'' | '"' | '\\' | '0' | 'a' | 'b' | 'f' | 'n' | 'r' | 't' | 'v'; 
fragment CharacterEscapeUnicode
    : '\\u' HexDigit HexDigit HexDigit HexDigit
    | '\\U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit;


// Whitespace and comments
                       
                       
LUtf8Bom : [\u00EF][\u00BB][\u00BF] -> channel(WHITESPACE);
                                               
                                               
LWhiteSpace : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> channel(WHITESPACE);
                                                              
                                                              
LCrLf : '\r'? '\n' -> channel(WHITESPACE);
                                       
                                       
LLineEnd : [\u0085\u2028\u2029] -> channel(WHITESPACE);

                    
LSingleLineComment : '//' ~[\r\n]* -> channel(COMMENT);
LCommentStart : '/*' -> more, mode(LMultilineComment);

                    
                    
mode LMultilineComment;

LComment_CrLf : '\r'? '\n' -> more;
LComment_LineBreak : [\u0085\u2028\u2029] -> more;
LComment_Text : ~[\u002A\r\n\u0085\u2028\u2029]+ -> more;
                    
                    
LComment : '*/' -> mode(DEFAULT_MODE), channel(COMMENT);
LComment_Star : '*' -> more;

                   
                   
mode DOUBLEQUOTE_VERBATIM_STRING;

DoubleQuoteVerbatimStringText : DoubleQuoteTextVerbatimCharacter -> more;
                   
                   
LDoubleQuoteVerbatimString : '"' -> mode(DEFAULT_MODE);

                   
                   
mode SINGLEQUOTE_VERBATIM_STRING;

SingleQuoteVerbatimStringText : SingleQuoteTextVerbatimCharacter -> more;
                   
                   
LSingleQuoteVerbatimString : '\'' -> mode(DEFAULT_MODE);
