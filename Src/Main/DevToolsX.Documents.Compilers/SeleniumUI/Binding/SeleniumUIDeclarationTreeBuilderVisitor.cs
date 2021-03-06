// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using DevToolsX.Documents.Compilers.SeleniumUI.Syntax;

namespace DevToolsX.Documents.Compilers.SeleniumUI.Binding
{
	public class SeleniumUIDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, ISeleniumUISyntaxVisitor
	{
        protected SeleniumUIDeclarationTreeBuilderVisitor(SeleniumUISyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            SeleniumUISyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new SeleniumUIDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.BeginProperty("Symbols");
			try
			{
				if (node.Namespace != null)
				{
					foreach (var child in node.Namespace)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNamespace(NamespaceSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Namespace), node);
			try
			{
				this.RegisterNestingProperty("Declarations");
				this.RegisterCanMerge(true);
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			if (node.Declaration != null)
			{
				foreach (var child in node.Declaration)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty("Declarations");
			try
			{
				this.Visit(node.Tag);
				this.Visit(node.Element);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTag(TagSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Tag), node);
			try
			{
				this.Visit(node.TypeSpecifier);
				this.Visit(node.Name);
				this.Visit(node.HtmlTagLocatorSpecifier);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitTypeSpecifier(TypeSpecifierSyntax node)
		{
		}
		
		public virtual void VisitElement(ElementSyntax node)
		{
			this.BeginDeclaration(typeof(Symbols.Element), node);
			try
			{
				this.Visit(node.ElementOrPage);
				this.Visit(node.Name);
				this.Visit(node.BaseElement);
				this.Visit(node.HtmlTagLocatorSpecifier);
				this.Visit(node.ElementBody);
			}
			finally
			{
				this.EndDeclaration();
			}
		}
		
		public virtual void VisitElementOrPage(ElementOrPageSyntax node)
		{
			this.BeginProperty("IsPage");
			try
			{
				if (node.ElementOrPage != null)
				{
					switch (((SeleniumUISyntaxToken)node.ElementOrPage).Kind)
					{
						case SeleniumUISyntaxKind.KPage:
							break;
						case SeleniumUISyntaxKind.KElement:
							break;
						default:
							break;
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitBaseElement(BaseElementSyntax node)
		{
			this.BeginProperty("Base");
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitElementBody(ElementBodySyntax node)
		{
			this.Visit(node.ChildElementsBody);
		}
		
		public virtual void VisitEmptyElementBody(EmptyElementBodySyntax node)
		{
		}
		
		public virtual void VisitChildElementsBody(ChildElementsBodySyntax node)
		{
			if (node.ChildElement != null)
			{
				foreach (var child in node.ChildElement)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitChildElement(ChildElementSyntax node)
		{
			this.BeginProperty("Elements");
			try
			{
				this.BeginDeclaration(typeof(Symbols.Element), node);
				try
				{
					this.Visit(node.ElementTypeSpecifier);
					this.Visit(node.Name);
					this.Visit(node.HtmlTagLocatorSpecifier);
					this.Visit(node.ElementBody);
				}
				finally
				{
					this.EndDeclaration();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitElementTypeSpecifier(ElementTypeSpecifierSyntax node)
		{
		}
		
		public virtual void VisitHtmlTagLocatorSpecifier(HtmlTagLocatorSpecifierSyntax node)
		{
			this.Visit(node.HtmlTagSpecifier);
			this.Visit(node.LocatorSpecifier);
		}
		
		public virtual void VisitHtmlTagSpecifier(HtmlTagSpecifierSyntax node)
		{
		}
		
		public virtual void VisitLocatorSpecifier(LocatorSpecifierSyntax node)
		{
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginName();
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName();
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
			this.BeginQualifier();
			try
			{
				if (node.Identifier != null)
				{
					foreach (var child in node.Identifier)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndQualifier();
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitString(StringSyntax node)
		{
		}
	}
}

