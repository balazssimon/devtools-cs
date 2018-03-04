using DevToolsX.Documents;
using DevToolsX.Documents.Compilers.MediaWiki;
using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using DevToolsX.Documents.Office;
using DevToolsX.Documents.Symbols;
using DevToolsX.Testing.Selenium;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevToolsX.TempConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Browser browser = new Browser())
                {
                    TestDocWiki test = new TestDocWiki();
                    test.Properties.Browser = browser;
                    string wikiText = test.OpenPage("http://www.google.com");
                    ImmutableModel model = MediaWikiToDocumentModel.Compile(wikiText);
                    using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateHtmlDocument("test.html")))
                    {
                        printer.Print();
                    }
                    using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateDocument(new WordWriter("Doc1.docx", true))))
                    {
                        printer.Print();
                    }
                    //Console.ReadLine();
                }
                /*string text = string.Empty;
                using (StreamReader reader = new StreamReader(@"..\..\test.wiki"))
                {
                    text = reader.ReadToEnd();
                }
                ImmutableModel model = MediaWikiToDocumentModel.Compile(text);
                using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateHtmlDocument("test.html")))
                {
                    printer.Print();
                }*/
                /*using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateLatexDocument("test.tex")))
                {
                    printer.Print();
                }
                using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateDocument(new WordWriter("Doc1.docx", true))))
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

/*
*/
