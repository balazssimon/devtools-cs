using DevToolsX.Documents.Compilers.MediaWiki;
using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using System;

namespace DevToolsX.TempConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MediaWikiSyntaxTree tree = MediaWikiSyntaxTree.ParseText(
@"= Hello =
World
*World2
*World3
World4
== Bello ==
Rorld");
            Console.WriteLine(tree);
            var root = tree.GetRoot();
            Console.WriteLine("----");
            var mwvt = new MediaWikiVisitorTest();
            root.Accept(mwvt);
        }
    }

    class MediaWikiVisitorTest : MediaWikiSyntaxVisitor
    {
        public override void DefaultVisit(SyntaxNode node)
        {
            foreach (var child in node.ChildNodes())
            {
                child.Accept(this);
            }
        }

        public override void VisitMain(MainSyntax node)
        {
            base.VisitMain(node);
        }

        public override void VisitParagraph(ParagraphSyntax node)
        {
            Console.WriteLine("Paragraph text: "+node.GetText());
            base.VisitParagraph(node);
        }

        public override void VisitHeading(HeadingSyntax node)
        {
            Console.WriteLine("Heading level: "+node.HeadingStart.GetText().Length);
            Console.WriteLine("Heading text: "+node.HeadingText.GetText());
            base.VisitHeading(node);
        }

        public override void VisitListItem(ListItemSyntax node)
        {
            Console.WriteLine("List item: " + node.GetText());
            base.VisitListItem(node);
        }
    }
}
