using DevToolsX.Documents.Symbols;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Documents.Compilers.MediaWiki.Symbols
{
    class MediaWikiFactory
    {
        private DocumentModelFactory factory;

        public MediaWikiFactory(MutableModel model)
        {
            this.factory = new DocumentModelFactory(model);
        }

        internal MutableSymbol Create(Type symbolType)
        {
            return this.factory.Create(symbolType);
        }
    }
}
