using System;
using System.Collections.Generic;
using System.Text;

namespace DevToolsX.Documents.Compilers.SeleniumUI.Symbols.Internal
{
    internal class SeleniumUIImplementation : SeleniumUIImplementationBase
    {
        public override void Element(ElementBuilder _this)
        {
            base.Element(_this);
            _this.HtmlTagLazy = () => _this.DeclaredHtmlTag ?? _this.Tag?.DeclaredHtmlTag;
            _this.LocatorLazy = () => _this.DeclaredLocator ?? _this.Tag?.DeclaredLocator;
        }
    }
}
