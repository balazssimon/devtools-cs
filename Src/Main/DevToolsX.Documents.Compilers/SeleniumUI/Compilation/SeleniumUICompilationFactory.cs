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
using DevToolsX.Documents.Compilers.SeleniumUI.Syntax;
using DevToolsX.Documents.Compilers.SeleniumUI.Binding;

namespace DevToolsX.Documents.Compilers.SeleniumUI
{
    internal class SeleniumUICompilationFactory : CompilationFactory
    {
        internal static readonly SeleniumUICompilationFactory Instance = new SeleniumUICompilationFactory();

        private SeleniumUICompilationFactory()
        {
        }

        public override RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SeleniumUIDeclarationTreeBuilderVisitor.ForTree((SeleniumUISyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new SeleniumUIBinderFactoryVisitor(binderFactory);
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SeleniumUIScriptCompilationInfo((SeleniumUICompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new SeleniumUISymbolBuilder((SeleniumUICompilation)compilation);
        }
    }
}

