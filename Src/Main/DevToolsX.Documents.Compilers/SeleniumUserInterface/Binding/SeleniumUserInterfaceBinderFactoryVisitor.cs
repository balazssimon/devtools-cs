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
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax;
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Symbols;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface.Binding
{
    public class SeleniumUserInterfaceBinderFactoryVisitor : BinderFactoryVisitor, ISeleniumUserInterfaceSyntaxVisitor<Binder>
    {

        public SeleniumUserInterfaceBinderFactoryVisitor(BinderFactory symbolBuilder)
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(node, use, out resultBinder))
			{
				resultBinder = this.GetParentBinder(node);
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitPage(PageSyntax node)
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
				this.BinderFactory.TryAddBinder(node, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}

