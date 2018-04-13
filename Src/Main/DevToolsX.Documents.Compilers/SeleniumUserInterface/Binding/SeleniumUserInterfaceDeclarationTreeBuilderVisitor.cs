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
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface.Binding
{
	public class SeleniumUserInterfaceDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, ISeleniumUserInterfaceSyntaxVisitor
	{
        protected SeleniumUserInterfaceDeclarationTreeBuilderVisitor(SeleniumUserInterfaceSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            SeleniumUserInterfaceSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new SeleniumUserInterfaceDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
		}
		
		public virtual void VisitPage(PageSyntax node)
		{
		}
		
		public virtual void VisitName(NameSyntax node)
		{
		}
	}
}

