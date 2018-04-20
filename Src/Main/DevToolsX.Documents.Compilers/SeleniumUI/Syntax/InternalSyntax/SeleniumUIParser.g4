parser grammar SeleniumUIParser;

options
{
	tokenVocab = SeleniumUILexer;
	                        
}

     
main:                    namespace* EOF;

                                                                        
namespace : KNamespace qualifiedName namespaceBody;

     
namespaceBody: TOpenBrace declaration* TCloseBrace;

                       
declaration: tag | page;

               
tag: KTag name typeSpecifier? TSemicolon;

typeSpecifier: TColon                            qualifier;

                
page: KPage name elementBody;

                   
                   
element: KElement name tagSpecifier? locatorSpecifier elementBody;

tagSpecifier: TColon                                qualifier;

locatorSpecifier: TAssign                           string;

elementBody: emptyElementBody | childElementsBody;

emptyElementBody: TSemicolon;

     
childElementsBody: TOpenBrace element* TCloseBrace;

     
qualifiedName: qualifier;

     
name: identifier;

          
qualifier: identifier (TDot identifier)*;

           
identifier: LIdentifier;

string: LRegularString | LDoubleQuoteVerbatimString | LSingleQuoteVerbatimString;
