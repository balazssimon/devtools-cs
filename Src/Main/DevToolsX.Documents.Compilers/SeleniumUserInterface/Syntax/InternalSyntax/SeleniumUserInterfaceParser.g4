parser grammar SeleniumUserInterfaceParser;

options
{
	tokenVocab = SeleniumUserInterfaceLexer;
	                        
}

main: page EOF;

page: KPage name TOpenBrace TCloseBrace;

name: Identifier;
