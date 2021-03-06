// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MetaDslx.Core;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Binding;
using DevToolsX.Documents.Compilers.MediaWiki.Symbols;

namespace DevToolsX.Documents.Compilers.MediaWiki.Binding
{
    public class MediaWikiSymbolBuilder : SymbolBuilder
    {
        public MediaWikiSymbolBuilder(CompilationBase compilation) : base(compilation)
        {
        }

        private MediaWikiFactory _factory;

        private MediaWikiFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    Interlocked.CompareExchange(ref _factory, new MediaWikiFactory(this.ModelBuilder), null);
                }
                return _factory;
            }
        }

        protected override MutableSymbol CreateSymbolCore(Type symbolType)
        {
            return this.Factory.Create(symbolType);
        }
    }
}

