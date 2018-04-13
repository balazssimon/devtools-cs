// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax
{
    public abstract class SeleniumUserInterfaceSyntaxNode : SyntaxNode
    {
        protected SeleniumUserInterfaceSyntaxNode(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected SeleniumUserInterfaceSyntaxNode(InternalSyntaxNode green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public SeleniumUserInterfaceSyntaxKind Kind
        {
            get { return (SeleniumUserInterfaceSyntaxKind)base.RawKind; }
        }

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            ISeleniumUserInterfaceSyntaxVisitor<TResult> typedVisitor = visitor as ISeleniumUserInterfaceSyntaxVisitor<TResult>;
            if (typedVisitor != null)
            {
                return this.Accept(typedVisitor);
            }
            return default(TResult);
        }

        public abstract TResult Accept<TResult>(ISeleniumUserInterfaceSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            ISeleniumUserInterfaceSyntaxVisitor typedVisitor = visitor as ISeleniumUserInterfaceSyntaxVisitor;
            if (typedVisitor != null)
            {
                this.Accept(typedVisitor);
            }
        }
        public abstract void Accept(ISeleniumUserInterfaceSyntaxVisitor visitor);
    }

    public class SeleniumUserInterfaceSyntaxTrivia : SyntaxTrivia
    {
        public SeleniumUserInterfaceSyntaxTrivia(InternalSyntaxTrivia green, SyntaxToken token, int position, int index)
            : base(green, token, position, index)
        {
        }

        public SeleniumUserInterfaceSyntaxKind Kind
        {
            get { return (SeleniumUserInterfaceSyntaxKind)base.RawKind; }
        }
    }

    public class SeleniumUserInterfaceSyntaxToken : SyntaxToken
    {
        public SeleniumUserInterfaceSyntaxToken(InternalSyntaxToken green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
        }

        public SeleniumUserInterfaceSyntaxKind Kind
        {
            get { return (SeleniumUserInterfaceSyntaxKind)base.RawKind; }
        }

        protected override SyntaxToken WithLeadingTriviaCore(InternalSyntaxTrivia[] leading)
        {
            return new SeleniumUserInterfaceSyntaxToken(this.GreenToken.WithLeadingTrivia(new InternalSyntaxTriviaList(leading, null, null)), null, 0, 0);
        }

        protected override SyntaxToken WithTrailingTriviaCore(InternalSyntaxTrivia[] trailing)
        {
            return new SeleniumUserInterfaceSyntaxToken(this.GreenToken.WithTrailingTrivia(new InternalSyntaxTriviaList(trailing, null, null)), null, 0, 0);
        }
    }
	
	public sealed class MainSyntax : SeleniumUserInterfaceSyntaxNode, ICompilationUnitSyntax
	{
	    private PageSyntax page;
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public PageSyntax Page 
		{ 
			get { return this.GetRed(ref this.page, 0); } 
		}
	    public SyntaxToken Eof 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.Eof;
				return greenToken == null ? null : new SeleniumUserInterfaceSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.page, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.page;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithPage(PageSyntax page)
		{
			return this.Update(Page, this.Eof);
		}
	
	    public MainSyntax WithEof(SyntaxToken eof)
		{
			return this.Update(this.Page, Eof);
		}
	
	    public MainSyntax Update(PageSyntax page, SyntaxToken eof)
	    {
	        if (this.Page != page ||
				this.Eof != eof)
	        {
	            SyntaxNode newNode = SeleniumUserInterfaceLanguage.Instance.SyntaxFactory.Main(page, eof);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUserInterfaceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ISeleniumUserInterfaceSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class PageSyntax : SeleniumUserInterfaceSyntaxNode
	{
	    private NameSyntax name;
	
	    public PageSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PageSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KPage 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax.PageGreen)this.Green;
				var greenToken = green.KPage;
				return greenToken == null ? null : new SeleniumUserInterfaceSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax.PageGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return greenToken == null ? null : new SeleniumUserInterfaceSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax.PageGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return greenToken == null ? null : new SeleniumUserInterfaceSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				default: return null;
	        }
	    }
	
	    public PageSyntax WithKPage(SyntaxToken kPage)
		{
			return this.Update(KPage, this.Name, this.TOpenBrace, this.TCloseBrace);
		}
	
	    public PageSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KPage, Name, this.TOpenBrace, this.TCloseBrace);
		}
	
	    public PageSyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(this.KPage, this.Name, TOpenBrace, this.TCloseBrace);
		}
	
	    public PageSyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.KPage, this.Name, this.TOpenBrace, TCloseBrace);
		}
	
	    public PageSyntax Update(SyntaxToken kPage, NameSyntax name, SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
	    {
	        if (this.KPage != kPage ||
				this.Name != name ||
				this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            SyntaxNode newNode = SeleniumUserInterfaceLanguage.Instance.SyntaxFactory.Page(kPage, name, tOpenBrace, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PageSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUserInterfaceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPage(this);
	    }
	
	    public override void Accept(ISeleniumUserInterfaceSyntaxVisitor visitor)
	    {
	        visitor.VisitPage(this);
	    }
	}
	
	public sealed class NameSyntax : SeleniumUserInterfaceSyntaxNode
	{
	
	    public NameSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Identifier 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax.NameGreen)this.Green;
				var greenToken = green.Identifier;
				return greenToken == null ? null : new SeleniumUserInterfaceSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public NameSyntax WithIdentifier(SyntaxToken identifier)
		{
			return this.Update(Identifier);
		}
	
	    public NameSyntax Update(SyntaxToken identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            SyntaxNode newNode = SeleniumUserInterfaceLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUserInterfaceSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(ISeleniumUserInterfaceSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
}

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface
{
    using System.Threading;
    using MetaDslx.Compiler;
    using MetaDslx.Compiler.Text;
	using DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax;
    using DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax;

	public interface ISeleniumUserInterfaceSyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitPage(PageSyntax node);
		
		void VisitName(NameSyntax node);
	}
	
	public class SeleniumUserInterfaceSyntaxVisitor : SyntaxVisitor, ISeleniumUserInterfaceSyntaxVisitor
	{
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPage(PageSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	public class SeleniumUserInterfaceDetailedSyntaxVisitor : DetailedSyntaxVisitor, ISeleniumUserInterfaceSyntaxVisitor
	{
	    public SeleniumUserInterfaceDetailedSyntaxVisitor(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.Visit(node.Page);
			this.VisitToken(node.Eof);
		}
		
		public virtual void VisitPage(PageSyntax node)
		{
			this.VisitToken(node.KPage);
			this.Visit(node.Name);
			this.VisitToken(node.TOpenBrace);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.VisitToken(node.Identifier);
		}
	}

	public interface ISeleniumUserInterfaceSyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitPage(PageSyntax node);
		
		TResult VisitName(NameSyntax node);
	}
	
	public class SeleniumUserInterfaceSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ISeleniumUserInterfaceSyntaxVisitor<TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPage(PageSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitName(NameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class SeleniumUserInterfaceSyntaxRewriter : SyntaxRewriter, ISeleniumUserInterfaceSyntaxVisitor<SyntaxNode>
	{
	    public SeleniumUserInterfaceSyntaxRewriter(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var page = (PageSyntax)this.Visit(node.Page);
		    var eof = this.VisitToken(node.Eof);
			return node.Update(page, eof);
		}
		
		public virtual SyntaxNode VisitPage(PageSyntax node)
		{
		    var kPage = this.VisitToken(node.KPage);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(kPage, name, tOpenBrace, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitName(NameSyntax node)
		{
		    var identifier = this.VisitToken(node.Identifier);
			return node.Update(identifier);
		}
	}

	public class SeleniumUserInterfaceSyntaxFactory : SyntaxFactory
	{
	    internal static readonly SeleniumUserInterfaceSyntaxFactory Instance = new SeleniumUserInterfaceSyntaxFactory();
	
		public SeleniumUserInterfaceSyntaxFactory() 
		{
			this.CarriageReturnLineFeed = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.CarriageReturnLineFeed.CreateRed();
			this.LineFeed = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.LineFeed.CreateRed();
			this.CarriageReturn = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.CarriageReturn.CreateRed();
			this.Space = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.Space.CreateRed();
			this.Tab = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.Tab.CreateRed();
			this.ElasticCarriageReturnLineFeed = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.ElasticCarriageReturnLineFeed.CreateRed();
			this.ElasticLineFeed = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.ElasticLineFeed.CreateRed();
			this.ElasticCarriageReturn = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.ElasticCarriageReturn.CreateRed();
			this.ElasticSpace = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.ElasticSpace.CreateRed();
			this.ElasticTab = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.ElasticTab.CreateRed();
			this.ElasticZeroSpace = (SeleniumUserInterfaceSyntaxTrivia)SeleniumUserInterfaceGreenFactory.Instance.ElasticZeroSpace.CreateRed();
		}
	
		public new SeleniumUserInterfaceLanguage Language
		{
			get { return SeleniumUserInterfaceLanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
	    public SeleniumUserInterfaceSyntaxTrivia CarriageReturnLineFeed { get; }
	    public SeleniumUserInterfaceSyntaxTrivia LineFeed { get; }
	    public SeleniumUserInterfaceSyntaxTrivia CarriageReturn { get; }
	    public SeleniumUserInterfaceSyntaxTrivia Space { get; }
	    public SeleniumUserInterfaceSyntaxTrivia Tab { get; }
	    public SeleniumUserInterfaceSyntaxTrivia ElasticCarriageReturnLineFeed { get; }
	    public SeleniumUserInterfaceSyntaxTrivia ElasticLineFeed { get; }
	    public SeleniumUserInterfaceSyntaxTrivia ElasticCarriageReturn { get; }
	    public SeleniumUserInterfaceSyntaxTrivia ElasticSpace { get; }
	    public SeleniumUserInterfaceSyntaxTrivia ElasticTab { get; }
	    public SeleniumUserInterfaceSyntaxTrivia ElasticZeroSpace { get; }
	
		private SyntaxToken defaultToken = null;
	    protected override SyntaxToken DefaultToken
	    {
	        get 
			{
				if (defaultToken != null) return defaultToken;
			    Interlocked.CompareExchange(ref defaultToken, this.Token(SeleniumUserInterfaceSyntaxKind.None), null);
				return defaultToken;
			}
	    }
	
		private SyntaxTrivia defaultTrivia = null;
	    protected override SyntaxTrivia DefaultTrivia
	    {
	        get 
			{
				if (defaultTrivia != null) return defaultTrivia;
			    Interlocked.CompareExchange(ref defaultTrivia, this.Trivia(SeleniumUserInterfaceSyntaxKind.None, string.Empty), null);
				return defaultTrivia;
			}
	    }
	
		private SyntaxToken defaultSeparator = null;
	    protected override SyntaxToken DefaultSeparator
	    {
	        get 
			{
				if (defaultSeparator != null) return defaultSeparator;
			    Interlocked.CompareExchange(ref defaultSeparator, this.Token(SeleniumUserInterfaceSyntaxKind.TComma), null);
				return defaultSeparator;
			}
	    }
	
	    protected override SyntaxNode StructuredToken(SyntaxToken token)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxNode StructuredTrivia(SyntaxTrivia trivia)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxToken Token(SyntaxNode tokenStructure)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxTrivia Trivia(SyntaxNode triviaStructure)
	    {
	        throw new NotImplementedException();
	    }
	
		/// <summary>
		/// Creates a token corresponding to a syntax kind. This method can be used for token syntax kinds whose text
		/// can be inferred by the kind alone.
		/// </summary>
		/// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
		/// <returns></returns>
		public SyntaxToken Token(SeleniumUserInterfaceSyntaxKind kind)
		{
			return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Token(kind).CreateRed();
		}
	
		public SyntaxTrivia Trivia(SeleniumUserInterfaceSyntaxKind kind, string text)
		{
			return (SyntaxTrivia)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Trivia(kind, text).CreateRed();
		}
	
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public SeleniumUserInterfaceSyntaxTree SyntaxTree(SyntaxNode root, SeleniumUserInterfaceParseOptions options = null, string path = "", Encoding encoding = null)
		{
		    return SeleniumUserInterfaceSyntaxTree.Create((SeleniumUserInterfaceSyntaxNode)root, (SeleniumUserInterfaceParseOptions)options, path, encoding);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public SeleniumUserInterfaceSyntaxTree ParseSyntaxTree(
		    string text,
		    SeleniumUserInterfaceParseOptions options = null,
		    string path = "",
		    Encoding encoding = null,
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (SeleniumUserInterfaceSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public SeleniumUserInterfaceSyntaxTree ParseSyntaxTree(
		    SourceText text,
		    SeleniumUserInterfaceParseOptions options = null,
		    string path = "",
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (SeleniumUserInterfaceSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
	
		protected override SyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return SeleniumUserInterfaceSyntaxTree.ParseText(text, (SeleniumUserInterfaceParseOptions)options, path, cancellationToken);
		}
	
	    public MainSyntax ParseMain(string text)
	    {
	        // note that we do not need a "consumeFullText" parameter, because parsing a compilation unit always must
	        // consume input until the end-of-file
	        using (var parser = MakeParser(text))
	        {
	            var node = parser.Parse();
	            if (node == null) return null;
	            // if (consumeFullText) node = parser.ConsumeUnexpectedTokens(node);
	            return (MainSyntax)node.CreateRed();
	        }
	    }
	
		public override SyntaxParser MakeParser(SourceText text, ParseOptions options, SyntaxNode oldTree, IReadOnlyList<TextChangeRange> changes)
		{
		    return new SeleniumUserInterfaceSyntaxParser(text, (SeleniumUserInterfaceParseOptions)options, oldTree, changes);
		}
	
		public override SyntaxParser MakeParser(string text)
		{
		    return new SeleniumUserInterfaceSyntaxParser(SourceText.From(text, Encoding.UTF8), SeleniumUserInterfaceParseOptions.Default, null, null);
		}
	
	    public SyntaxToken Identifier(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Identifier(text).CreateRed();
	    }
	
	    public SyntaxToken Identifier(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Identifier(text, value).CreateRed();
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LInteger(text).CreateRed();
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LInteger(text, value).CreateRed();
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LDecimal(text).CreateRed();
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value).CreateRed();
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LScientific(text).CreateRed();
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LScientific(text, value).CreateRed();
	    }
	
	    public SyntaxToken LRegularString(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LRegularString(text).CreateRed();
	    }
	
	    public SyntaxToken LRegularString(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LRegularString(text, value).CreateRed();
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text).CreateRed();
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value).CreateRed();
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text).CreateRed();
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value).CreateRed();
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LCrLf(text).CreateRed();
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value).CreateRed();
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LLineEnd(text).CreateRed();
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value).CreateRed();
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text).CreateRed();
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value).CreateRed();
	    }
	
	    public SyntaxToken LComment(string text)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LComment(text).CreateRed();
	    }
	
	    public SyntaxToken LComment(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.LComment(text, value).CreateRed();
	    }
		
		public MainSyntax Main(PageSyntax page, SyntaxToken eof)
		{
		    if (page == null) throw new ArgumentNullException(nameof(page));
		    if (eof == null) throw new ArgumentNullException(nameof(eof));
		    if (eof.RawKind != (int)SeleniumUserInterfaceSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
		    return (MainSyntax)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Main((Syntax.InternalSyntax.PageGreen)page.Green, (InternalSyntaxToken)eof.Green).CreateRed();
		}
		
		public PageSyntax Page(SyntaxToken kPage, NameSyntax name, SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
		{
		    if (kPage == null) throw new ArgumentNullException(nameof(kPage));
		    if (kPage.RawKind != (int)SeleniumUserInterfaceSyntaxKind.KPage) throw new ArgumentException(nameof(kPage));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.RawKind != (int)SeleniumUserInterfaceSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.RawKind != (int)SeleniumUserInterfaceSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (PageSyntax)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Page((InternalSyntaxToken)kPage.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenBrace.Green, (InternalSyntaxToken)tCloseBrace.Green).CreateRed();
		}
		
		public PageSyntax Page(NameSyntax name)
		{
			return this.Page(this.Token(SeleniumUserInterfaceSyntaxKind.KPage), name, this.Token(SeleniumUserInterfaceSyntaxKind.TOpenBrace), this.Token(SeleniumUserInterfaceSyntaxKind.TCloseBrace));
		}
		
		public NameSyntax Name(SyntaxToken identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (identifier.RawKind != (int)SeleniumUserInterfaceSyntaxKind.Identifier) throw new ArgumentException(nameof(identifier));
		    return (NameSyntax)SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Name((InternalSyntaxToken)identifier.Green).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(PageSyntax),
				typeof(NameSyntax),
			};
		}
	}
}

