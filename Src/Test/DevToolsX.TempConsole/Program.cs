using DevToolsX.Documents;
using DevToolsX.Documents.Compilers.MediaWiki;
using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using DevToolsX.Documents.Office;
using DevToolsX.Documents.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.TempConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string text =
    @"= Hello =
World ''italic'' aaa '''bold''' bbb '''''italic &amp; bold''''' &#65;
*World2
*World3
*#AAA
*#BBB
***CCC
*#DDD
*#EEE
*FFF
*;aaa
*:bbb
*;ccc
*:ddd
*:eee
;xxx
:yyy
;zzz
:www
:ttt
World4
 code
 block
== Bello ==
Rorld";
                ImmutableModel model = MediaWikiToDocumentModel.Compile(text);
                using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateHtmlDocument("test.html")))
                {
                    printer.Print();
                }
                using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateLatexDocument("test.tex")))
                {
                    printer.Print();
                }
                /*using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateDocument(new WordWriter("Doc1.docx"))))
                {
                    printer.Print();
                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }


}
