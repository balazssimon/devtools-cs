using DevToolsX.Documents;
using DevToolsX.Documents.Compilers.MediaWiki;
using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using DevToolsX.Documents.Office;
using DevToolsX.Documents.Symbols;
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
World ''italic'' aaa '''bold''' bbb '''''italic &amp; bold''''' &#65; [external.html] [external2.html external link] [[internal.html]] [[internal2.html|internal link]]
*World2 
*World3 ''italic'' aaa '''bold''' bbb '''''italic &amp; bold''''' &#65; [external.html] [external2.html external link] [[internal.html]] [[internal2.html|internal link]]
*#AAA
*#BBB
***CCC ''italic'' aaa '''bold''' bbb '''''italic &amp; bold''''' &#65; [external.html] [external2.html external link] [[internal.html]] [[internal2.html|internal link]]
*#DDD
*#EEE
*FFF
*;aaa
*:bbb
*;ccc
*:ddd
*:eee
;xxx
:yyy ''italic'' aaa '''bold''' bbb '''''italic &amp; bold''''' &#65; [external.html] [external2.html external link] [[internal.html]] [[internal2.html|internal link]]
;zzz
:www
:ttt
World4
 code
 block
{|
|+Food complements
|-
!Orange
!Apple
|-
!Bread
|Pie
* AAA
* BBB
** CCC ''italic''
** DDD '''bold'''
|-
!Butter ''italic'' aaa '''bold''' bbb '''''italic &amp; bold''''' &#65; [external.html] [external2.html external link] [[internal.html]] [[internal2.html|internal link]]
|Ice cream  ''italic'' aaa '''bold''' bbb '''''italic &amp; bold''''' &#65; [external.html] [external2.html external link] [[internal.html]] [[internal2.html|internal link]]
|}
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
                using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateDocument(new WordWriter("Doc1.docx", true))))
                {
                    printer.Print();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }


}

