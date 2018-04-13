// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.MetaModel;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Languages.Antlr4Roslyn.Parser;
namespace DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax
{
    public class SeleniumUserInterfaceSyntaxParser : Antlr4SyntaxParser<SeleniumUserInterfaceLexer, SeleniumUserInterfaceParser>
    {
        public SeleniumUserInterfaceSyntaxParser(
            SourceText text,
            SeleniumUserInterfaceParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, SeleniumUserInterfaceLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override SeleniumUserInterfaceLexer CreateLexer(AntlrInputStream inputStream)
        {
            return new SeleniumUserInterfaceLexer(inputStream);
        }
        protected override SeleniumUserInterfaceParser CreateParser(CommonTokenStream tokenStream)
        {
            return new SeleniumUserInterfaceParser(tokenStream);
        }
        public override GreenNode Parse()
        {
            return this.ParseMain();
        }
        internal MainGreen ParseMain()
        {
            Antlr4ToRoslynVisitor visitor = new Antlr4ToRoslynVisitor(this);
            var tree = this.Parser.main();
            return (MainGreen)visitor.Visit(tree);
        }
        private class Antlr4ToRoslynVisitor : SeleniumUserInterfaceParserBaseVisitor<GreenNode>
        {
            private SeleniumUserInterfaceLanguage language;
			private SeleniumUserInterfaceGreenFactory factory;
            private SeleniumUserInterfaceSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastTokenOrTrivia;
            public Antlr4ToRoslynVisitor(SeleniumUserInterfaceSyntaxParser syntaxParser)
            {
                this.language = SeleniumUserInterfaceLanguage.Instance;
				this.factory = language.InternalSyntaxFactory;
                this.syntaxParser = syntaxParser;
				this.tokens = this.syntaxParser.CommonTokenStream.GetTokens();
                this.lastTokenOrTrivia = null;
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                GreenNode result = this.syntaxParser.VisitTerminal(node, ref this.lastTokenOrTrivia);
                return result;
            }
			
			public override GreenNode VisitMain(SeleniumUserInterfaceParser.MainContext context)
			{
				if (context == null) return null;
				SeleniumUserInterfaceParser.PageContext pageContext = context.page();
				PageGreen page = null;
				if (pageContext != null)
				{
					page = (PageGreen)this.Visit(pageContext);
				}
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof());
				return this.factory.Main(page, eof, true);
			}
			
			public override GreenNode VisitPage(SeleniumUserInterfaceParser.PageContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kPage = (InternalSyntaxToken)this.VisitTerminal(context.KPage());
				SeleniumUserInterfaceParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.Page(kPage, name, tOpenBrace, tCloseBrace, true);
			}
			
			public override GreenNode VisitName(SeleniumUserInterfaceParser.NameContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken identifier = (InternalSyntaxToken)this.VisitTerminal(context.Identifier());
				return this.factory.Name(identifier, true);
			}
        }
    }
}

