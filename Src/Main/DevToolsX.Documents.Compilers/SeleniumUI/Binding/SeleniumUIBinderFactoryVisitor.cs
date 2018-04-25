// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using DevToolsX.Documents.Compilers.SeleniumUI.Syntax;
using DevToolsX.Documents.Compilers.SeleniumUI.Symbols;

namespace DevToolsX.Documents.Compilers.SeleniumUI.Binding
{
    public class SeleniumUIBinderFactoryVisitor : BinderFactoryVisitor, ISeleniumUISyntaxVisitor<Binder>
    {
		public static object UseNamespace = new object();
		public static object UseQualifier = new object();
		public static object UseElementOrPage = new object();
		public static object UseString = new object();

        public SeleniumUIBinderFactoryVisitor(BinderFactory symbolBuilder)
			: base(symbolBuilder)
        {

        }
		
		public Binder VisitMain(MainSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Namespace.Node)) use = UseNamespace;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateRootBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseNamespace)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Namespace.Node, "Symbols");
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNamespace(NamespaceSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Namespace));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateBodyBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDeclaration(DeclarationSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Declarations");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTag(TagSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Tag));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeSpecifier(TypeSpecifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "TypeName");
					resultBinder = this.CreateValueBinder(resultBinder, node.Qualifier);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitElement(ElementSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Element));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitElementOrPage(ElementOrPageSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.ElementOrPage)) use = UseElementOrPage;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "IsPage");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseElementOrPage)
				{
					switch (((SeleniumUISyntaxToken)node.ElementOrPage).Kind)
					{
						case SeleniumUISyntaxKind.KPage:
							resultBinder = this.CreateValueBinder(resultBinder, node.ElementOrPage, true);
							break;
						case SeleniumUISyntaxKind.KElement:
							resultBinder = this.CreateValueBinder(resultBinder, node.ElementOrPage, false);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitBaseElement(BaseElementSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Base");
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Element");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.Element)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitElementBody(ElementBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEmptyElementBody(EmptyElementBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitChildElementsBody(ChildElementsBodySyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateBodyBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitChildElement(ChildElementSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreatePropertyBinder(resultBinder, node, "Elements");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, node, typeof(Symbols.Element));
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitElementTypeSpecifier(ElementTypeSpecifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.Qualifier, "Type");
					resultBinder = this.CreateSymbolUseBinder(resultBinder, node.Qualifier, ImmutableArray.Create(typeof(Symbols.ElementType)));
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitHtmlTagLocatorSpecifier(HtmlTagLocatorSpecifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitHtmlTagSpecifier(HtmlTagSpecifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.String)) use = UseString;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseString)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.String, "DeclaredHtmlTag");
					resultBinder = this.CreateValueBinder(resultBinder, node.String);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLocatorSpecifier(LocatorSpecifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, node.String)) use = UseString;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
				if (use == UseString)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, node.String, "DeclaredLocator");
					resultBinder = this.CreateValueBinder(resultBinder, node.String);
					this.BinderFactory.TryAddBinder(node, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitQualifiedName(QualifiedNameSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateNameBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitName(NameSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateNameBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifier(QualifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateQualifierBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifier(IdentifierSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				resultBinder = this.CreateIdentifierBinder(resultBinder, node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitString(StringSyntax node)
		{
		    Debug.Assert(node.SyntaxTree == this.SyntaxTree);
		    if (!node.FullSpan.Contains(this.Position))
		    {
		        return this.GetParentBinder(node);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}

