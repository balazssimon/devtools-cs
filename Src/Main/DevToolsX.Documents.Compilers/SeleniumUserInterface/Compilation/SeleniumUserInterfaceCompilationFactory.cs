// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax;
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Binding;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface
{
    internal class SeleniumUserInterfaceCompilationFactory : CompilationFactory
    {
        internal static readonly SeleniumUserInterfaceCompilationFactory Instance = new SeleniumUserInterfaceCompilationFactory();

        private SeleniumUserInterfaceCompilationFactory()
        {
        }

        public override RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SeleniumUserInterfaceDeclarationTreeBuilderVisitor.ForTree((SeleniumUserInterfaceSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new SeleniumUserInterfaceBinderFactoryVisitor(binderFactory);
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SeleniumUserInterfaceScriptCompilationInfo((SeleniumUserInterfaceCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new SeleniumUserInterfaceSymbolBuilder((SeleniumUserInterfaceCompilation)compilation);
        }
    }
}

