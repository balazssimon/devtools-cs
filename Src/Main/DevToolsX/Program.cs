using DevToolsX.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Program.GenerateDocument(new LatexWriter("hello.tex", Encoding.UTF8));
                Program.GenerateDocument(new HtmlWriter("hello.html", Encoding.UTF8));
                Program.GenerateDocument(new WordWriter("Doc1.docx", false));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void GenerateDocument(IDocumentWriter writer)
        {
            using (DocumentGenerator doc = DocumentGenerator.CreateDocument(writer))
            {
                doc.AutoAppendSpaceBetweenWords = true;
                doc.WriteSectionTitle(0, "Első fejezet", "elso");
                doc.Write("One");
                doc.Write("One");
                doc.Write("One");
                doc.Write("One");
                doc.Write("two", DocumentMarkupKind.Bold);
                doc.WriteLine("One");
                doc.WriteLine("One");
                doc.Write("One");
                doc.BeginMarkup(DocumentMarkupKind.Italic);
                doc.Write("two");
                doc.Write("three");
                doc.BeginMarkup(DocumentMarkupKind.Bold);
                doc.Write("four");
                doc.Write("two");
                doc.EndMarkup();
                doc.Write("three");
                doc.EndMarkup();
                doc.WriteLine("five");
                doc.WriteLine("One");
                doc.WriteLine("One");
                doc.WriteLine("One");
                doc.NewParagraph();
                doc.Write("abc");
                doc.NewParagraph();
                doc.WriteLine("One");
                doc.WriteLine("One");
                doc.WriteLine("One");

                doc.BeginMarkup(DocumentMarkupKind.Code);
                doc.WriteLine("One");
                doc.WriteLine("One");
                doc.WriteLine("One");
                doc.NewParagraph();
                doc.EndMarkup();
                doc.WriteLine("One");
                doc.Write("One");
                doc.Write("one", DocumentMarkupKind.CodeInline);
                doc.Write("one");
                doc.WriteLine("One");

                doc.BeginList(ListKind.Bullets);
                doc.AddListItem();
                doc.Write("First");
                doc.AddListItem();
                doc.Write("Second");
                doc.AddListItem();
                doc.Write("Third");
                doc.EndList();

                doc.WriteLine("One");
                doc.WriteLine("One");

                doc.WriteSectionTitle(1, "Első alfejezet");
                doc.Write("three");
                doc.WriteLine();
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");
                doc.WriteLine("Four");

                doc.BeginList(ListKind.Numbers);
                doc.AddListItem();
                doc.Write("First");
                doc.WriteReference(null, "elso", "első");
                doc.AddListItem();
                doc.Write("Second");
                doc.WriteReference(null, "masodik", "második");
                doc.AddListItem();
                doc.Write("Third");
                doc.EndList();

                doc.WriteLine("Four");
                doc.WriteLine("Four");

                doc.WriteSectionTitle(2, "Első alalfejezet");
                doc.WriteLine("Four five six");
                doc.WriteSectionTitle(0, "Második fejezet", "masodik");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteLine("Seven");
                doc.WriteSectionTitle(1, "Második alfejezet");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteLine("Eight");
                doc.WriteSectionTitle(2, "Második alalfejezet");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");
                doc.WriteLine("Nine");

                doc.BeginTable(3);
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        doc.AddTableCell();
                        doc.Write(i);
                        doc.Write("*");
                        doc.Write(j);
                        doc.Write("=");
                        doc.Write(i * j);
                        /*doc.LineBreak();
                        doc.Write("Aaa");*/
                    }
                }
                doc.EndTable();

                doc.WriteLine("Ten");
                doc.WriteLine("Ten");
            }
        }
    }
}
