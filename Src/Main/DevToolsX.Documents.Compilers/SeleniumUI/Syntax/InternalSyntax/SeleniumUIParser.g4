parser grammar SeleniumUIParser;

options
{
	tokenVocab = SeleniumUILexer;
	                        
}

     
main:                    namespace* EOF;

                                                                        
namespace : KNamespace qualifiedName namespaceBody;

     
namespaceBody: TOpenBrace declaration* TCloseBrace;

                       
declaration: tag | element;


               
tag: KTag typeSpecifier name htmlTagLocatorSpecifier? TSemicolon;

typeSpecifier:                            qualifier;


                   
element: elementOrPage name baseElement? htmlTagLocatorSpecifier? elementBody;

                 
elementOrPage
	:              KPage 
	|               KElement
	;

               
baseElement: TColon                                        qualifier;

elementBody: emptyElementBody | childElementsBody;

emptyElementBody: TSemicolon;

     
childElementsBody: TOpenBrace childElement* TCloseBrace;

                   
                   
childElement: elementTypeSpecifier? name htmlTagLocatorSpecifier? elementBody;

elementTypeSpecifier:                                         qualifier;

htmlTagLocatorSpecifier: TAssign htmlTagSpecifier? locatorSpecifier?;
htmlTagSpecifier: TOpenBracket                                   string TCloseBracket;
locatorSpecifier:                                   string;

     
qualifiedName: qualifier;

     
name: identifier;

          
qualifier: identifier (TDot identifier)*;

           
identifier: LIdentifier;

string: LRegularString | LDoubleQuoteVerbatimString | LSingleQuoteVerbatimString;
