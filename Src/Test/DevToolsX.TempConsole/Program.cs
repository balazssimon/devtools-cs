using DevToolsX.Documents;
using DevToolsX.Documents.Compilers.MediaWiki;
using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using DevToolsX.Documents.Office;
using DevToolsX.Documents.Symbols;
using DevToolsX.Testing.Selenium;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Core;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevToolsX.TempConsole
{
    class Program
    {
        private static readonly ILoggerFactory LoggerFactory;

        static Program()
        {
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .CreateLogger();
            Program.LoggerFactory = new LoggerFactory();
            Program.LoggerFactory.AddSerilog();
        }

        static void Main(string[] args)
        {
            /*try
            {*/
            /*Options options = new Options(LoggerFactory);
            options.ImplicitWaitTimeout = TimeSpan.FromSeconds(3);
            //options.ScreenshotImageFormat = ImageFormat.Jpeg;
            using (Browser browser = new Browser(BrowserKind.Firefox, options))
            {
                TestDocWiki test = new TestDocWiki();
                test.Browser = browser;
                string wikiText = test.OpenPage("http://www.google.com", "apple");
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
            }*/
            string fileName = "test1";
                string text = string.Empty;
                using (StreamReader reader = new StreamReader(@"..\..\"+fileName+".wiki"))
                {
                    text = reader.ReadToEnd();
                }
                var tree = MediaWikiSyntaxTree.ParseText(text);
                var compilation = MediaWikiSimpleCompilation.Create("wiki").AddSyntaxTrees(tree);
                ImmutableModel model = compilation.Model;
                foreach (var diagnostic in compilation.GetDiagnostics())
                {
                    Console.WriteLine(DiagnosticFormatter.Instance.Format(diagnostic));
                }
                using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateHtmlDocument(fileName+".html")))
                {
                    printer.Print();
                }
                /*using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateLatexDocument("test.tex")))
                {
                    printer.Print();
                }
                using (DocumentModelPrinter printer = new DocumentModelPrinter(model, DocumentGenerator.CreateDocument(new WordWriter("Doc1.docx", true))))
                {
                    printer.Print();
                }*/
            /*}
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/
        }
    }


}

