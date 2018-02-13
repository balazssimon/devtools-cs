using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
using DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax;

namespace DevToolsX.Documents.Compilers.MediaWiki
{
    public sealed class MediaWikiLanguage : Language
    {
        internal const string LanguageName = "MediaWiki";

        public static readonly MediaWikiLanguage Instance = new MediaWikiLanguage();

        private MediaWikiLanguage()
        {
        }

        public override string Name
        {
            get { return MediaWikiLanguage.LanguageName; }
        }

        protected override SyntaxFacts SyntaxFactsCore
        {
            get { return MediaWikiSyntaxFacts.Instance; }
        }

        public new MediaWikiSyntaxFacts SyntaxFacts
        {
            get { return (MediaWikiSyntaxFacts)base.SyntaxFacts; }
        }

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore
        {
            get { return MediaWikiGreenFactory.Instance; }
        }

        internal MediaWikiGreenFactory InternalSyntaxFactory
        {
            get { return (MediaWikiGreenFactory)this.InternalSyntaxFactoryCore; }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get { return MediaWikiSyntaxFactory.Instance; }
        }

        public new MediaWikiSyntaxFactory SyntaxFactory
        {
            get { return (MediaWikiSyntaxFactory)base.SyntaxFactory; }
        }

        protected override CompilationFactory CompilationFactoryCore
        {
            get { return MediaWikiCompilationFactory.Instance; }
        }

        internal MediaWikiCompilationFactory CompilationFactory
        {
            get { return (MediaWikiCompilationFactory)this.CompilationFactoryCore; }
        }
    }
}

