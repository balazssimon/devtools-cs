using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax;
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface
{
    public sealed class SeleniumUserInterfaceLanguage : Language
    {
        internal const string LanguageName = "SeleniumUserInterface";

        public static readonly SeleniumUserInterfaceLanguage Instance = new SeleniumUserInterfaceLanguage();

        private SeleniumUserInterfaceLanguage()
        {
        }

        public override string Name
        {
            get { return SeleniumUserInterfaceLanguage.LanguageName; }
        }

        protected override SyntaxFacts SyntaxFactsCore
        {
            get { return SeleniumUserInterfaceSyntaxFacts.Instance; }
        }

        public new SeleniumUserInterfaceSyntaxFacts SyntaxFacts
        {
            get { return (SeleniumUserInterfaceSyntaxFacts)base.SyntaxFacts; }
        }

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore
        {
            get { return SeleniumUserInterfaceGreenFactory.Instance; }
        }

        internal SeleniumUserInterfaceGreenFactory InternalSyntaxFactory
        {
            get { return (SeleniumUserInterfaceGreenFactory)this.InternalSyntaxFactoryCore; }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get { return SeleniumUserInterfaceSyntaxFactory.Instance; }
        }

        public new SeleniumUserInterfaceSyntaxFactory SyntaxFactory
        {
            get { return (SeleniumUserInterfaceSyntaxFactory)base.SyntaxFactory; }
        }

        protected override CompilationFactory CompilationFactoryCore
        {
            get { return SeleniumUserInterfaceCompilationFactory.Instance; }
        }

        internal SeleniumUserInterfaceCompilationFactory CompilationFactory
        {
            get { return (SeleniumUserInterfaceCompilationFactory)this.CompilationFactoryCore; }
        }
    }
}

