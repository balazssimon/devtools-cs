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
namespace DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax
{
    public class SeleniumUISyntaxParser : Antlr4SyntaxParser<SeleniumUILexer, SeleniumUIParser>
    {
        public SeleniumUISyntaxParser(
            SourceText text,
            SeleniumUIParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, SeleniumUILanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override SeleniumUILexer CreateLexer(AntlrInputStream inputStream)
        {
            return new SeleniumUILexer(inputStream);
        }
        protected override SeleniumUIParser CreateParser(CommonTokenStream tokenStream)
        {
            return new SeleniumUIParser(tokenStream);
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
        private class Antlr4ToRoslynVisitor : SeleniumUIParserBaseVisitor<GreenNode>
        {
            private SeleniumUILanguage language;
			private SeleniumUIGreenFactory factory;
            private SeleniumUISyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastTokenOrTrivia;
            public Antlr4ToRoslynVisitor(SeleniumUISyntaxParser syntaxParser)
            {
                this.language = SeleniumUILanguage.Instance;
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
			
			public override GreenNode VisitMain(SeleniumUIParser.MainContext context)
			{
				if (context == null) return null;
			    SeleniumUIParser.NamespaceContext[] _namespaceContext = context.@namespace();
			    ArrayBuilder<NamespaceGreen> _namespaceBuilder = ArrayBuilder<NamespaceGreen>.GetInstance(_namespaceContext.Length);
			    for (int i = 0; i < _namespaceContext.Length; i++)
			    {
			        _namespaceBuilder.Add((NamespaceGreen)this.Visit(_namespaceContext[i]));
			    }
				InternalSyntaxNodeList _namespace = InternalSyntaxNodeList.Create(_namespaceBuilder.ToArrayAndFree());
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof());
				return this.factory.Main(_namespace, eof, true);
			}
			
			public override GreenNode VisitNamespace(SeleniumUIParser.NamespaceContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace());
				SeleniumUIParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				SeleniumUIParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null)
				{
					namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				}
				return this.factory.Namespace(kNamespace, qualifiedName, namespaceBody, true);
			}
			
			public override GreenNode VisitNamespaceBody(SeleniumUIParser.NamespaceBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SeleniumUIParser.DeclarationContext[] declarationContext = context.declaration();
			    ArrayBuilder<DeclarationGreen> declarationBuilder = ArrayBuilder<DeclarationGreen>.GetInstance(declarationContext.Length);
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				InternalSyntaxNodeList declaration = InternalSyntaxNodeList.Create(declarationBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.NamespaceBody(tOpenBrace, declaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitDeclaration(SeleniumUIParser.DeclarationContext context)
			{
				if (context == null) return null;
				SeleniumUIParser.TagContext tagContext = context.tag();
				if (tagContext != null) 
				{
					return this.factory.Declaration((TagGreen)this.Visit(tagContext), true);
				}
				SeleniumUIParser.PageContext pageContext = context.page();
				if (pageContext != null) 
				{
					return this.factory.Declaration((PageGreen)this.Visit(pageContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitTag(SeleniumUIParser.TagContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kTag = (InternalSyntaxToken)this.VisitTerminal(context.KTag());
				SeleniumUIParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SeleniumUIParser.TypeSpecifierContext typeSpecifierContext = context.typeSpecifier();
				TypeSpecifierGreen typeSpecifier = null;
				if (typeSpecifierContext != null)
				{
					typeSpecifier = (TypeSpecifierGreen)this.Visit(typeSpecifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.Tag(kTag, name, typeSpecifier, tSemicolon, true);
			}
			
			public override GreenNode VisitTypeSpecifier(SeleniumUIParser.TypeSpecifierContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SeleniumUIParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.TypeSpecifier(tColon, qualifier, true);
			}
			
			public override GreenNode VisitPage(SeleniumUIParser.PageContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kPage = (InternalSyntaxToken)this.VisitTerminal(context.KPage());
				SeleniumUIParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SeleniumUIParser.ElementBodyContext elementBodyContext = context.elementBody();
				ElementBodyGreen elementBody = null;
				if (elementBodyContext != null)
				{
					elementBody = (ElementBodyGreen)this.Visit(elementBodyContext);
				}
				return this.factory.Page(kPage, name, elementBody, true);
			}
			
			public override GreenNode VisitElement(SeleniumUIParser.ElementContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kElement = (InternalSyntaxToken)this.VisitTerminal(context.KElement());
				SeleniumUIParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SeleniumUIParser.TagSpecifierContext tagSpecifierContext = context.tagSpecifier();
				TagSpecifierGreen tagSpecifier = null;
				if (tagSpecifierContext != null)
				{
					tagSpecifier = (TagSpecifierGreen)this.Visit(tagSpecifierContext);
				}
				SeleniumUIParser.LocatorSpecifierContext locatorSpecifierContext = context.locatorSpecifier();
				LocatorSpecifierGreen locatorSpecifier = null;
				if (locatorSpecifierContext != null)
				{
					locatorSpecifier = (LocatorSpecifierGreen)this.Visit(locatorSpecifierContext);
				}
				SeleniumUIParser.ElementBodyContext elementBodyContext = context.elementBody();
				ElementBodyGreen elementBody = null;
				if (elementBodyContext != null)
				{
					elementBody = (ElementBodyGreen)this.Visit(elementBodyContext);
				}
				return this.factory.Element(kElement, name, tagSpecifier, locatorSpecifier, elementBody, true);
			}
			
			public override GreenNode VisitTagSpecifier(SeleniumUIParser.TagSpecifierContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SeleniumUIParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.TagSpecifier(tColon, qualifier, true);
			}
			
			public override GreenNode VisitLocatorSpecifier(SeleniumUIParser.LocatorSpecifierContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SeleniumUIParser.StringContext _stringContext = context.@string();
				StringGreen _string = null;
				if (_stringContext != null)
				{
					_string = (StringGreen)this.Visit(_stringContext);
				}
				return this.factory.LocatorSpecifier(tAssign, _string, true);
			}
			
			public override GreenNode VisitElementBody(SeleniumUIParser.ElementBodyContext context)
			{
				if (context == null) return null;
				SeleniumUIParser.EmptyElementBodyContext emptyElementBodyContext = context.emptyElementBody();
				if (emptyElementBodyContext != null) 
				{
					return this.factory.ElementBody((EmptyElementBodyGreen)this.Visit(emptyElementBodyContext), true);
				}
				SeleniumUIParser.ChildElementsBodyContext childElementsBodyContext = context.childElementsBody();
				if (childElementsBodyContext != null) 
				{
					return this.factory.ElementBody((ChildElementsBodyGreen)this.Visit(childElementsBodyContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitEmptyElementBody(SeleniumUIParser.EmptyElementBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.EmptyElementBody(tSemicolon, true);
			}
			
			public override GreenNode VisitChildElementsBody(SeleniumUIParser.ChildElementsBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SeleniumUIParser.ElementContext[] elementContext = context.element();
			    ArrayBuilder<ElementGreen> elementBuilder = ArrayBuilder<ElementGreen>.GetInstance(elementContext.Length);
			    for (int i = 0; i < elementContext.Length; i++)
			    {
			        elementBuilder.Add((ElementGreen)this.Visit(elementContext[i]));
			    }
				InternalSyntaxNodeList element = InternalSyntaxNodeList.Create(elementBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.ChildElementsBody(tOpenBrace, element, tCloseBrace, true);
			}
			
			public override GreenNode VisitQualifiedName(SeleniumUIParser.QualifiedNameContext context)
			{
				if (context == null) return null;
				SeleniumUIParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.QualifiedName(qualifier, true);
			}
			
			public override GreenNode VisitName(SeleniumUIParser.NameContext context)
			{
				if (context == null) return null;
				SeleniumUIParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				return this.factory.Name(identifier, true);
			}
			
			public override GreenNode VisitQualifier(SeleniumUIParser.QualifierContext context)
			{
				if (context == null) return null;
			    SeleniumUIParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    ArrayBuilder<GreenNode> identifierBuilder = ArrayBuilder<GreenNode>.GetInstance(identifierContext.Length+tDotContext.Length);
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tDotContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList identifier = InternalSeparatedSyntaxNodeList.Create(identifierBuilder.ToArrayAndFree());
				return this.factory.Qualifier(identifier, true);
			}
			
			public override GreenNode VisitIdentifier(SeleniumUIParser.IdentifierContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lIdentifier = (InternalSyntaxToken)this.VisitTerminal(context.LIdentifier());
				return this.factory.Identifier(lIdentifier, true);
			}
			
			public override GreenNode VisitString(SeleniumUIParser.StringContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken _string = null;
				if (context.LRegularString() != null)
				{
					_string = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString());
				}
				else 	if (context.LDoubleQuoteVerbatimString() != null)
				{
					_string = (InternalSyntaxToken)this.VisitTerminal(context.LDoubleQuoteVerbatimString());
				}
				else 	if (context.LSingleQuoteVerbatimString() != null)
				{
					_string = (InternalSyntaxToken)this.VisitTerminal(context.LSingleQuoteVerbatimString());
				}
				return this.factory.String(_string, true);
			}
        }
    }
}

