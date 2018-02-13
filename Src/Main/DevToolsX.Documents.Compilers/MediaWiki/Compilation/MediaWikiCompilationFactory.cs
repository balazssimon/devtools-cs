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
using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using DevToolsX.Documents.Compilers.MediaWiki.Binding;

namespace DevToolsX.Documents.Compilers.MediaWiki
{
    internal class MediaWikiCompilationFactory : CompilationFactory
    {
        internal static readonly MediaWikiCompilationFactory Instance = new MediaWikiCompilationFactory();

        private MediaWikiCompilationFactory()
        {
        }

        public override RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return MediaWikiDeclarationTreeBuilderVisitor.ForTree((MediaWikiSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new MediaWikiBinderFactoryVisitor(binderFactory);
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new MediaWikiScriptCompilationInfo((MediaWikiCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new MediaWikiSymbolBuilder((MediaWikiCompilation)compilation);
        }
    }
}

