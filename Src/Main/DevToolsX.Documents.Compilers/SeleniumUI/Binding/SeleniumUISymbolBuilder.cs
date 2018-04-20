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
using DevToolsX.Documents.Compilers.SeleniumUI.Symbols;

namespace DevToolsX.Documents.Compilers.SeleniumUI.Binding
{
    public class SeleniumUISymbolBuilder : SymbolBuilder
    {
        public SeleniumUISymbolBuilder(CompilationBase compilation) : base(compilation)
        {
        }

        private SeleniumUIFactory _factory;

        private SeleniumUIFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    Interlocked.CompareExchange(ref _factory, new SeleniumUIFactory(this.ModelBuilder), null);
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

