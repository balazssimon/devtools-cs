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
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Symbols;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface.Binding
{
    public class SeleniumUserInterfaceSymbolBuilder : SymbolBuilder
    {
        public SeleniumUserInterfaceSymbolBuilder(CompilationBase compilation) : base(compilation)
        {
        }

        private SeleniumUserInterfaceFactory _factory;

        private SeleniumUserInterfaceFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    Interlocked.CompareExchange(ref _factory, new SeleniumUserInterfaceFactory(this.ModelBuilder), null);
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

