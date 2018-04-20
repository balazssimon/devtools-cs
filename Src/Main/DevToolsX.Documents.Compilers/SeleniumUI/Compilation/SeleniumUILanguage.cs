using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using DevToolsX.Documents.Compilers.SeleniumUI.Syntax;
using DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax;

namespace DevToolsX.Documents.Compilers.SeleniumUI
{
    public sealed class SeleniumUILanguage : Language
    {
        internal const string LanguageName = "SeleniumUI";

        public static readonly SeleniumUILanguage Instance = new SeleniumUILanguage();

        private SeleniumUILanguage()
        {
        }

        public override string Name
        {
            get { return SeleniumUILanguage.LanguageName; }
        }

        protected override SyntaxFacts SyntaxFactsCore
        {
            get { return SeleniumUISyntaxFacts.Instance; }
        }

        public new SeleniumUISyntaxFacts SyntaxFacts
        {
            get { return (SeleniumUISyntaxFacts)base.SyntaxFacts; }
        }

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore
        {
            get { return SeleniumUIGreenFactory.Instance; }
        }

        internal SeleniumUIGreenFactory InternalSyntaxFactory
        {
            get { return (SeleniumUIGreenFactory)this.InternalSyntaxFactoryCore; }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get { return SeleniumUISyntaxFactory.Instance; }
        }

        public new SeleniumUISyntaxFactory SyntaxFactory
        {
            get { return (SeleniumUISyntaxFactory)base.SyntaxFactory; }
        }

        protected override CompilationFactory CompilationFactoryCore
        {
            get { return SeleniumUICompilationFactory.Instance; }
        }

        internal SeleniumUICompilationFactory CompilationFactory
        {
            get { return (SeleniumUICompilationFactory)this.CompilationFactoryCore; }
        }
    }
}

