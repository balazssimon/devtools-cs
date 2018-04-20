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

namespace DevToolsX.Documents.Compilers.SeleniumUI.Syntax
{
    public abstract class SeleniumUISyntaxNode : SyntaxNode
    {
        protected SeleniumUISyntaxNode(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected SeleniumUISyntaxNode(InternalSyntaxNode green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public SeleniumUISyntaxKind Kind
        {
            get { return (SeleniumUISyntaxKind)base.RawKind; }
        }

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            ISeleniumUISyntaxVisitor<TResult> typedVisitor = visitor as ISeleniumUISyntaxVisitor<TResult>;
            if (typedVisitor != null)
            {
                return this.Accept(typedVisitor);
            }
            return default(TResult);
        }

        public abstract TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            ISeleniumUISyntaxVisitor typedVisitor = visitor as ISeleniumUISyntaxVisitor;
            if (typedVisitor != null)
            {
                this.Accept(typedVisitor);
            }
        }
        public abstract void Accept(ISeleniumUISyntaxVisitor visitor);
    }

    public class SeleniumUISyntaxTrivia : SyntaxTrivia
    {
        public SeleniumUISyntaxTrivia(InternalSyntaxTrivia green, SyntaxToken token, int position, int index)
            : base(green, token, position, index)
        {
        }

        public SeleniumUISyntaxKind Kind
        {
            get { return (SeleniumUISyntaxKind)base.RawKind; }
        }
    }

    public class SeleniumUISyntaxToken : SyntaxToken
    {
        public SeleniumUISyntaxToken(InternalSyntaxToken green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
        }

        public SeleniumUISyntaxKind Kind
        {
            get { return (SeleniumUISyntaxKind)base.RawKind; }
        }

        protected override SyntaxToken WithLeadingTriviaCore(InternalSyntaxTrivia[] leading)
        {
            return new SeleniumUISyntaxToken(this.GreenToken.WithLeadingTrivia(new InternalSyntaxTriviaList(leading, null, null)), null, 0, 0);
        }

        protected override SyntaxToken WithTrailingTriviaCore(InternalSyntaxTrivia[] trailing)
        {
            return new SeleniumUISyntaxToken(this.GreenToken.WithTrailingTrivia(new InternalSyntaxTriviaList(trailing, null, null)), null, 0, 0);
        }
    }
	
	public sealed class MainSyntax : SeleniumUISyntaxNode, ICompilationUnitSyntax
	{
	    private SyntaxNodeList _namespace;
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<NamespaceSyntax> Namespace 
		{ 
			get
			{
				var red = this.GetRed(ref this._namespace, 0);
				if (red != null)
				{
					return new SyntaxNodeList<NamespaceSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken Eof 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.Eof;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this._namespace, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this._namespace;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithNamespace(SyntaxNodeList<NamespaceSyntax> _namespace)
		{
			return this.Update(Namespace, this.Eof);
		}
	
	    public MainSyntax AddNamespace(params NamespaceSyntax[] _namespace)
		{
			return this.WithNamespace(this.Namespace.AddRange(_namespace));
		}
	
	    public MainSyntax WithEof(SyntaxToken eof)
		{
			return this.Update(this.Namespace, Eof);
		}
	
	    public MainSyntax Update(SyntaxNodeList<NamespaceSyntax> _namespace, SyntaxToken eof)
	    {
	        if (this.Namespace.Node != _namespace.Node ||
				this.Eof != eof)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Main(_namespace, eof);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class NamespaceSyntax : SeleniumUISyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBodySyntax namespaceBody;
	
	    public NamespaceSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.NamespaceGreen)this.Green;
				var greenToken = green.KNamespace;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBodySyntax NamespaceBody 
		{ 
			get { return this.GetRed(ref this.namespaceBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody;
				default: return null;
	        }
	    }
	
	    public NamespaceSyntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody);
		}
	
	    public NamespaceSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody);
		}
	
	    public NamespaceSyntax WithNamespaceBody(NamespaceBodySyntax namespaceBody)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody);
		}
	
	    public NamespaceSyntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody != namespaceBody)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Namespace(kNamespace, qualifiedName, namespaceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespace(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitNamespace(this);
	    }
	}
	
	public sealed class NamespaceBodySyntax : SeleniumUISyntaxNode
	{
	    private SyntaxNodeList declaration;
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public SyntaxNodeList<DeclarationSyntax> Declaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration, 1);
				if (red != null)
				{
					return new SyntaxNodeList<DeclarationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration;
				default: return null;
	        }
	    }
	
	    public NamespaceBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax WithDeclaration(SyntaxNodeList<DeclarationSyntax> declaration)
		{
			return this.Update(this.TOpenBrace, Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax AddDeclaration(params DeclarationSyntax[] declaration)
		{
			return this.WithDeclaration(this.Declaration.AddRange(declaration));
		}
	
	    public NamespaceBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration, TCloseBrace);
		}
	
	    public NamespaceBodySyntax Update(SyntaxToken tOpenBrace, SyntaxNodeList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration.Node != declaration.Node ||
				this.TCloseBrace != tCloseBrace)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody(this);
	    }
	}
	
	public sealed class DeclarationSyntax : SeleniumUISyntaxNode
	{
	    private TagSyntax tag;
	    private PageSyntax page;
	
	    public DeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TagSyntax Tag 
		{ 
			get { return this.GetRed(ref this.tag, 0); } 
		}
	    public PageSyntax Page 
		{ 
			get { return this.GetRed(ref this.page, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.tag, 0);
				case 1: return this.GetRed(ref this.page, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.tag;
				case 1: return this.page;
				default: return null;
	        }
	    }
	
	    public DeclarationSyntax WithTag(TagSyntax tag)
		{
			return this.Update(tag);
		}
	
	    public DeclarationSyntax WithPage(PageSyntax page)
		{
			return this.Update(page);
		}
	
	    public DeclarationSyntax Update(TagSyntax tag)
	    {
	        if (this.Tag != tag)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Declaration(tag);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(PageSyntax page)
	    {
	        if (this.Page != page)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Declaration(page);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration(this);
	    }
	}
	
	public sealed class TagSyntax : SeleniumUISyntaxNode
	{
	    private NameSyntax name;
	    private TypeSpecifierSyntax typeSpecifier;
	
	    public TagSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TagSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTag 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.TagGreen)this.Green;
				var greenToken = green.KTag;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public TypeSpecifierSyntax TypeSpecifier 
		{ 
			get { return this.GetRed(ref this.typeSpecifier, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.TagGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 2: return this.GetRed(ref this.typeSpecifier, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 2: return this.typeSpecifier;
				default: return null;
	        }
	    }
	
	    public TagSyntax WithKTag(SyntaxToken kTag)
		{
			return this.Update(KTag, this.Name, this.TypeSpecifier, this.TSemicolon);
		}
	
	    public TagSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KTag, Name, this.TypeSpecifier, this.TSemicolon);
		}
	
	    public TagSyntax WithTypeSpecifier(TypeSpecifierSyntax typeSpecifier)
		{
			return this.Update(this.KTag, this.Name, TypeSpecifier, this.TSemicolon);
		}
	
	    public TagSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KTag, this.Name, this.TypeSpecifier, TSemicolon);
		}
	
	    public TagSyntax Update(SyntaxToken kTag, NameSyntax name, TypeSpecifierSyntax typeSpecifier, SyntaxToken tSemicolon)
	    {
	        if (this.KTag != kTag ||
				this.Name != name ||
				this.TypeSpecifier != typeSpecifier ||
				this.TSemicolon != tSemicolon)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Tag(kTag, name, typeSpecifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TagSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTag(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitTag(this);
	    }
	}
	
	public sealed class TypeSpecifierSyntax : SeleniumUISyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public TypeSpecifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeSpecifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.TypeSpecifierGreen)this.Green;
				var greenToken = green.TColon;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public TypeSpecifierSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(TColon, this.Qualifier);
		}
	
	    public TypeSpecifierSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.TColon, Qualifier);
		}
	
	    public TypeSpecifierSyntax Update(SyntaxToken tColon, QualifierSyntax qualifier)
	    {
	        if (this.TColon != tColon ||
				this.Qualifier != qualifier)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.TypeSpecifier(tColon, qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeSpecifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeSpecifier(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitTypeSpecifier(this);
	    }
	}
	
	public sealed class PageSyntax : SeleniumUISyntaxNode
	{
	    private NameSyntax name;
	    private ElementBodySyntax elementBody;
	
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
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.PageGreen)this.Green;
				var greenToken = green.KPage;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public ElementBodySyntax ElementBody 
		{ 
			get { return this.GetRed(ref this.elementBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 2: return this.GetRed(ref this.elementBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 2: return this.elementBody;
				default: return null;
	        }
	    }
	
	    public PageSyntax WithKPage(SyntaxToken kPage)
		{
			return this.Update(KPage, this.Name, this.ElementBody);
		}
	
	    public PageSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KPage, Name, this.ElementBody);
		}
	
	    public PageSyntax WithElementBody(ElementBodySyntax elementBody)
		{
			return this.Update(this.KPage, this.Name, ElementBody);
		}
	
	    public PageSyntax Update(SyntaxToken kPage, NameSyntax name, ElementBodySyntax elementBody)
	    {
	        if (this.KPage != kPage ||
				this.Name != name ||
				this.ElementBody != elementBody)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Page(kPage, name, elementBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PageSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPage(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitPage(this);
	    }
	}
	
	public sealed class ElementSyntax : SeleniumUISyntaxNode
	{
	    private NameSyntax name;
	    private TagSpecifierSyntax tagSpecifier;
	    private LocatorSpecifierSyntax locatorSpecifier;
	    private ElementBodySyntax elementBody;
	
	    public ElementSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElementSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KElement 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.ElementGreen)this.Green;
				var greenToken = green.KElement;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public TagSpecifierSyntax TagSpecifier 
		{ 
			get { return this.GetRed(ref this.tagSpecifier, 2); } 
		}
	    public LocatorSpecifierSyntax LocatorSpecifier 
		{ 
			get { return this.GetRed(ref this.locatorSpecifier, 3); } 
		}
	    public ElementBodySyntax ElementBody 
		{ 
			get { return this.GetRed(ref this.elementBody, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 2: return this.GetRed(ref this.tagSpecifier, 2);
				case 3: return this.GetRed(ref this.locatorSpecifier, 3);
				case 4: return this.GetRed(ref this.elementBody, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 2: return this.tagSpecifier;
				case 3: return this.locatorSpecifier;
				case 4: return this.elementBody;
				default: return null;
	        }
	    }
	
	    public ElementSyntax WithKElement(SyntaxToken kElement)
		{
			return this.Update(KElement, this.Name, this.TagSpecifier, this.LocatorSpecifier, this.ElementBody);
		}
	
	    public ElementSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KElement, Name, this.TagSpecifier, this.LocatorSpecifier, this.ElementBody);
		}
	
	    public ElementSyntax WithTagSpecifier(TagSpecifierSyntax tagSpecifier)
		{
			return this.Update(this.KElement, this.Name, TagSpecifier, this.LocatorSpecifier, this.ElementBody);
		}
	
	    public ElementSyntax WithLocatorSpecifier(LocatorSpecifierSyntax locatorSpecifier)
		{
			return this.Update(this.KElement, this.Name, this.TagSpecifier, LocatorSpecifier, this.ElementBody);
		}
	
	    public ElementSyntax WithElementBody(ElementBodySyntax elementBody)
		{
			return this.Update(this.KElement, this.Name, this.TagSpecifier, this.LocatorSpecifier, ElementBody);
		}
	
	    public ElementSyntax Update(SyntaxToken kElement, NameSyntax name, TagSpecifierSyntax tagSpecifier, LocatorSpecifierSyntax locatorSpecifier, ElementBodySyntax elementBody)
	    {
	        if (this.KElement != kElement ||
				this.Name != name ||
				this.TagSpecifier != tagSpecifier ||
				this.LocatorSpecifier != locatorSpecifier ||
				this.ElementBody != elementBody)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Element(kElement, name, tagSpecifier, locatorSpecifier, elementBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElement(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitElement(this);
	    }
	}
	
	public sealed class TagSpecifierSyntax : SeleniumUISyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public TagSpecifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TagSpecifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.TagSpecifierGreen)this.Green;
				var greenToken = green.TColon;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public TagSpecifierSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(TColon, this.Qualifier);
		}
	
	    public TagSpecifierSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.TColon, Qualifier);
		}
	
	    public TagSpecifierSyntax Update(SyntaxToken tColon, QualifierSyntax qualifier)
	    {
	        if (this.TColon != tColon ||
				this.Qualifier != qualifier)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.TagSpecifier(tColon, qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TagSpecifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTagSpecifier(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitTagSpecifier(this);
	    }
	}
	
	public sealed class LocatorSpecifierSyntax : SeleniumUISyntaxNode
	{
	    private StringSyntax _string;
	
	    public LocatorSpecifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LocatorSpecifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.LocatorSpecifierGreen)this.Green;
				var greenToken = green.TAssign;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public StringSyntax String 
		{ 
			get { return this.GetRed(ref this._string, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this._string, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this._string;
				default: return null;
	        }
	    }
	
	    public LocatorSpecifierSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(TAssign, this.String);
		}
	
	    public LocatorSpecifierSyntax WithString(StringSyntax _string)
		{
			return this.Update(this.TAssign, String);
		}
	
	    public LocatorSpecifierSyntax Update(SyntaxToken tAssign, StringSyntax _string)
	    {
	        if (this.TAssign != tAssign ||
				this.String != _string)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.LocatorSpecifier(tAssign, _string);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LocatorSpecifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLocatorSpecifier(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitLocatorSpecifier(this);
	    }
	}
	
	public sealed class ElementBodySyntax : SeleniumUISyntaxNode
	{
	    private EmptyElementBodySyntax emptyElementBody;
	    private ChildElementsBodySyntax childElementsBody;
	
	    public ElementBodySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElementBodySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public EmptyElementBodySyntax EmptyElementBody 
		{ 
			get { return this.GetRed(ref this.emptyElementBody, 0); } 
		}
	    public ChildElementsBodySyntax ChildElementsBody 
		{ 
			get { return this.GetRed(ref this.childElementsBody, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.emptyElementBody, 0);
				case 1: return this.GetRed(ref this.childElementsBody, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.emptyElementBody;
				case 1: return this.childElementsBody;
				default: return null;
	        }
	    }
	
	    public ElementBodySyntax WithEmptyElementBody(EmptyElementBodySyntax emptyElementBody)
		{
			return this.Update(emptyElementBody);
		}
	
	    public ElementBodySyntax WithChildElementsBody(ChildElementsBodySyntax childElementsBody)
		{
			return this.Update(childElementsBody);
		}
	
	    public ElementBodySyntax Update(EmptyElementBodySyntax emptyElementBody)
	    {
	        if (this.EmptyElementBody != emptyElementBody)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.ElementBody(emptyElementBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public ElementBodySyntax Update(ChildElementsBodySyntax childElementsBody)
	    {
	        if (this.ChildElementsBody != childElementsBody)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.ElementBody(childElementsBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElementBody(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitElementBody(this);
	    }
	}
	
	public sealed class EmptyElementBodySyntax : SeleniumUISyntaxNode
	{
	
	    public EmptyElementBodySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EmptyElementBodySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.EmptyElementBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public EmptyElementBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon);
		}
	
	    public EmptyElementBodySyntax Update(SyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.EmptyElementBody(tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EmptyElementBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEmptyElementBody(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitEmptyElementBody(this);
	    }
	}
	
	public sealed class ChildElementsBodySyntax : SeleniumUISyntaxNode
	{
	    private SyntaxNodeList element;
	
	    public ChildElementsBodySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ChildElementsBodySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.ChildElementsBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public SyntaxNodeList<ElementSyntax> Element 
		{ 
			get
			{
				var red = this.GetRed(ref this.element, 1);
				if (red != null)
				{
					return new SyntaxNodeList<ElementSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.ChildElementsBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.element, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.element;
				default: return null;
	        }
	    }
	
	    public ChildElementsBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Element, this.TCloseBrace);
		}
	
	    public ChildElementsBodySyntax WithElement(SyntaxNodeList<ElementSyntax> element)
		{
			return this.Update(this.TOpenBrace, Element, this.TCloseBrace);
		}
	
	    public ChildElementsBodySyntax AddElement(params ElementSyntax[] element)
		{
			return this.WithElement(this.Element.AddRange(element));
		}
	
	    public ChildElementsBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Element, TCloseBrace);
		}
	
	    public ChildElementsBodySyntax Update(SyntaxToken tOpenBrace, SyntaxNodeList<ElementSyntax> element, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Element.Node != element.Node ||
				this.TCloseBrace != tCloseBrace)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.ChildElementsBody(tOpenBrace, element, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ChildElementsBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitChildElementsBody(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitChildElementsBody(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : SeleniumUISyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public QualifiedNameSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public QualifiedNameSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.QualifiedName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class NameSyntax : SeleniumUISyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				default: return null;
	        }
	    }
	
	    public NameSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public NameSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class QualifierSyntax : SeleniumUISyntaxNode
	{
	    private SeparatedSyntaxNodeList identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<IdentifierSyntax> Identifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.identifier, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<IdentifierSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				default: return null;
	        }
	    }
	
	    public QualifierSyntax WithIdentifier(SeparatedSyntaxNodeList<IdentifierSyntax> identifier)
		{
			return this.Update(Identifier);
		}
	
	    public QualifierSyntax AddIdentifier(params IdentifierSyntax[] identifier)
		{
			return this.WithIdentifier(this.Identifier.AddRange(identifier));
		}
	
	    public QualifierSyntax Update(SeparatedSyntaxNodeList<IdentifierSyntax> identifier)
	    {
	        if (this.Identifier.Node != identifier.Node)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class IdentifierSyntax : SeleniumUISyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LIdentifier 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.IdentifierGreen)this.Green;
				var greenToken = green.LIdentifier;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public IdentifierSyntax WithLIdentifier(SyntaxToken lIdentifier)
		{
			return this.Update(LIdentifier);
		}
	
	    public IdentifierSyntax Update(SyntaxToken lIdentifier)
	    {
	        if (this.LIdentifier != lIdentifier)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.Identifier(lIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class StringSyntax : SeleniumUISyntaxNode
	{
	
	    public StringSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken String 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax.StringGreen)this.Green;
				var greenToken = green.String;
				return greenToken == null ? null : new SeleniumUISyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public StringSyntax WithString(SyntaxToken _string)
		{
			return this.Update(String);
		}
	
	    public StringSyntax Update(SyntaxToken _string)
	    {
	        if (this.String != _string)
	        {
	            SyntaxNode newNode = SeleniumUILanguage.Instance.SyntaxFactory.String(_string);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(ISeleniumUISyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitString(this);
	    }
	
	    public override void Accept(ISeleniumUISyntaxVisitor visitor)
	    {
	        visitor.VisitString(this);
	    }
	}
}

namespace DevToolsX.Documents.Compilers.SeleniumUI
{
    using System.Threading;
    using MetaDslx.Compiler;
    using MetaDslx.Compiler.Text;
	using DevToolsX.Documents.Compilers.SeleniumUI.Syntax;
    using DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax;

	public interface ISeleniumUISyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitNamespace(NamespaceSyntax node);
		
		void VisitNamespaceBody(NamespaceBodySyntax node);
		
		void VisitDeclaration(DeclarationSyntax node);
		
		void VisitTag(TagSyntax node);
		
		void VisitTypeSpecifier(TypeSpecifierSyntax node);
		
		void VisitPage(PageSyntax node);
		
		void VisitElement(ElementSyntax node);
		
		void VisitTagSpecifier(TagSpecifierSyntax node);
		
		void VisitLocatorSpecifier(LocatorSpecifierSyntax node);
		
		void VisitElementBody(ElementBodySyntax node);
		
		void VisitEmptyElementBody(EmptyElementBodySyntax node);
		
		void VisitChildElementsBody(ChildElementsBodySyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitString(StringSyntax node);
	}
	
	public class SeleniumUISyntaxVisitor : SyntaxVisitor, ISeleniumUISyntaxVisitor
	{
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespace(NamespaceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTag(TagSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeSpecifier(TypeSpecifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPage(PageSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElement(ElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTagSpecifier(TagSpecifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLocatorSpecifier(LocatorSpecifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElementBody(ElementBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEmptyElementBody(EmptyElementBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitChildElementsBody(ChildElementsBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitString(StringSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	public class SeleniumUIDetailedSyntaxVisitor : DetailedSyntaxVisitor, ISeleniumUISyntaxVisitor
	{
	    public SeleniumUIDetailedSyntaxVisitor(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.VisitList(node.Namespace);
			this.VisitToken(node.Eof);
		}
		
		public virtual void VisitNamespace(NamespaceSyntax node)
		{
			this.VisitToken(node.KNamespace);
			this.Visit(node.QualifiedName);
			this.Visit(node.NamespaceBody);
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.Declaration);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.Visit(node.Tag);
			this.Visit(node.Page);
		}
		
		public virtual void VisitTag(TagSyntax node)
		{
			this.VisitToken(node.KTag);
			this.Visit(node.Name);
			this.Visit(node.TypeSpecifier);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitTypeSpecifier(TypeSpecifierSyntax node)
		{
			this.VisitToken(node.TColon);
			this.Visit(node.Qualifier);
		}
		
		public virtual void VisitPage(PageSyntax node)
		{
			this.VisitToken(node.KPage);
			this.Visit(node.Name);
			this.Visit(node.ElementBody);
		}
		
		public virtual void VisitElement(ElementSyntax node)
		{
			this.VisitToken(node.KElement);
			this.Visit(node.Name);
			this.Visit(node.TagSpecifier);
			this.Visit(node.LocatorSpecifier);
			this.Visit(node.ElementBody);
		}
		
		public virtual void VisitTagSpecifier(TagSpecifierSyntax node)
		{
			this.VisitToken(node.TColon);
			this.Visit(node.Qualifier);
		}
		
		public virtual void VisitLocatorSpecifier(LocatorSpecifierSyntax node)
		{
			this.VisitToken(node.TAssign);
			this.Visit(node.String);
		}
		
		public virtual void VisitElementBody(ElementBodySyntax node)
		{
			this.Visit(node.EmptyElementBody);
			this.Visit(node.ChildElementsBody);
		}
		
		public virtual void VisitEmptyElementBody(EmptyElementBodySyntax node)
		{
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitChildElementsBody(ChildElementsBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.Element);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.Visit(node.Qualifier);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			this.VisitToken(node.LIdentifier);
		}
		
		public virtual void VisitString(StringSyntax node)
		{
			this.VisitToken(node.String);
		}
	}

	public interface ISeleniumUISyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitNamespace(NamespaceSyntax node);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node);
		
		TResult VisitDeclaration(DeclarationSyntax node);
		
		TResult VisitTag(TagSyntax node);
		
		TResult VisitTypeSpecifier(TypeSpecifierSyntax node);
		
		TResult VisitPage(PageSyntax node);
		
		TResult VisitElement(ElementSyntax node);
		
		TResult VisitTagSpecifier(TagSpecifierSyntax node);
		
		TResult VisitLocatorSpecifier(LocatorSpecifierSyntax node);
		
		TResult VisitElementBody(ElementBodySyntax node);
		
		TResult VisitEmptyElementBody(EmptyElementBodySyntax node);
		
		TResult VisitChildElementsBody(ChildElementsBodySyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitString(StringSyntax node);
	}
	
	public class SeleniumUISyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ISeleniumUISyntaxVisitor<TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespace(NamespaceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration(DeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTag(TagSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeSpecifier(TypeSpecifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPage(PageSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElement(ElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTagSpecifier(TagSpecifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLocatorSpecifier(LocatorSpecifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElementBody(ElementBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEmptyElementBody(EmptyElementBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitChildElementsBody(ChildElementsBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifiedName(QualifiedNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitName(NameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifier(QualifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitString(StringSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class SeleniumUISyntaxRewriter : SyntaxRewriter, ISeleniumUISyntaxVisitor<SyntaxNode>
	{
	    public SeleniumUISyntaxRewriter(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var _namespace = this.VisitList(node.Namespace);
		    var eof = this.VisitToken(node.Eof);
			return node.Update(_namespace, eof);
		}
		
		public virtual SyntaxNode VisitNamespace(NamespaceSyntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody = (NamespaceBodySyntax)this.Visit(node.NamespaceBody);
			return node.Update(kNamespace, qualifiedName, namespaceBody);
		}
		
		public virtual SyntaxNode VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration = this.VisitList(node.Declaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration(DeclarationSyntax node)
		{
			var oldTag = node.Tag;
			if (oldTag != null)
			{
			    var newTag = (TagSyntax)this.Visit(oldTag);
				return node.Update(newTag);
			}
			var oldPage = node.Page;
			if (oldPage != null)
			{
			    var newPage = (PageSyntax)this.Visit(oldPage);
				return node.Update(newPage);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTag(TagSyntax node)
		{
		    var kTag = this.VisitToken(node.KTag);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var typeSpecifier = (TypeSpecifierSyntax)this.Visit(node.TypeSpecifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kTag, name, typeSpecifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitTypeSpecifier(TypeSpecifierSyntax node)
		{
		    var tColon = this.VisitToken(node.TColon);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(tColon, qualifier);
		}
		
		public virtual SyntaxNode VisitPage(PageSyntax node)
		{
		    var kPage = this.VisitToken(node.KPage);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var elementBody = (ElementBodySyntax)this.Visit(node.ElementBody);
			return node.Update(kPage, name, elementBody);
		}
		
		public virtual SyntaxNode VisitElement(ElementSyntax node)
		{
		    var kElement = this.VisitToken(node.KElement);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tagSpecifier = (TagSpecifierSyntax)this.Visit(node.TagSpecifier);
		    var locatorSpecifier = (LocatorSpecifierSyntax)this.Visit(node.LocatorSpecifier);
		    var elementBody = (ElementBodySyntax)this.Visit(node.ElementBody);
			return node.Update(kElement, name, tagSpecifier, locatorSpecifier, elementBody);
		}
		
		public virtual SyntaxNode VisitTagSpecifier(TagSpecifierSyntax node)
		{
		    var tColon = this.VisitToken(node.TColon);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(tColon, qualifier);
		}
		
		public virtual SyntaxNode VisitLocatorSpecifier(LocatorSpecifierSyntax node)
		{
		    var tAssign = this.VisitToken(node.TAssign);
		    var _string = (StringSyntax)this.Visit(node.String);
			return node.Update(tAssign, _string);
		}
		
		public virtual SyntaxNode VisitElementBody(ElementBodySyntax node)
		{
			var oldEmptyElementBody = node.EmptyElementBody;
			if (oldEmptyElementBody != null)
			{
			    var newEmptyElementBody = (EmptyElementBodySyntax)this.Visit(oldEmptyElementBody);
				return node.Update(newEmptyElementBody);
			}
			var oldChildElementsBody = node.ChildElementsBody;
			if (oldChildElementsBody != null)
			{
			    var newChildElementsBody = (ChildElementsBodySyntax)this.Visit(oldChildElementsBody);
				return node.Update(newChildElementsBody);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitEmptyElementBody(EmptyElementBodySyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(tSemicolon);
		}
		
		public virtual SyntaxNode VisitChildElementsBody(ChildElementsBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var element = this.VisitList(node.Element);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, element, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitName(NameSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitQualifier(QualifierSyntax node)
		{
		    var identifier = this.VisitList(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
		    var lIdentifier = this.VisitToken(node.LIdentifier);
			return node.Update(lIdentifier);
		}
		
		public virtual SyntaxNode VisitString(StringSyntax node)
		{
		    var _string = this.VisitToken(node.String);
			return node.Update(_string);
		}
	}

	public class SeleniumUISyntaxFactory : SyntaxFactory
	{
	    internal static readonly SeleniumUISyntaxFactory Instance = new SeleniumUISyntaxFactory();
	
		public SeleniumUISyntaxFactory() 
		{
			this.CarriageReturnLineFeed = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.CarriageReturnLineFeed.CreateRed();
			this.LineFeed = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.LineFeed.CreateRed();
			this.CarriageReturn = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.CarriageReturn.CreateRed();
			this.Space = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.Space.CreateRed();
			this.Tab = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.Tab.CreateRed();
			this.ElasticCarriageReturnLineFeed = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.ElasticCarriageReturnLineFeed.CreateRed();
			this.ElasticLineFeed = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.ElasticLineFeed.CreateRed();
			this.ElasticCarriageReturn = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.ElasticCarriageReturn.CreateRed();
			this.ElasticSpace = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.ElasticSpace.CreateRed();
			this.ElasticTab = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.ElasticTab.CreateRed();
			this.ElasticZeroSpace = (SeleniumUISyntaxTrivia)SeleniumUIGreenFactory.Instance.ElasticZeroSpace.CreateRed();
		}
	
		public new SeleniumUILanguage Language
		{
			get { return SeleniumUILanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
	    public SeleniumUISyntaxTrivia CarriageReturnLineFeed { get; }
	    public SeleniumUISyntaxTrivia LineFeed { get; }
	    public SeleniumUISyntaxTrivia CarriageReturn { get; }
	    public SeleniumUISyntaxTrivia Space { get; }
	    public SeleniumUISyntaxTrivia Tab { get; }
	    public SeleniumUISyntaxTrivia ElasticCarriageReturnLineFeed { get; }
	    public SeleniumUISyntaxTrivia ElasticLineFeed { get; }
	    public SeleniumUISyntaxTrivia ElasticCarriageReturn { get; }
	    public SeleniumUISyntaxTrivia ElasticSpace { get; }
	    public SeleniumUISyntaxTrivia ElasticTab { get; }
	    public SeleniumUISyntaxTrivia ElasticZeroSpace { get; }
	
		private SyntaxToken defaultToken = null;
	    protected override SyntaxToken DefaultToken
	    {
	        get 
			{
				if (defaultToken != null) return defaultToken;
			    Interlocked.CompareExchange(ref defaultToken, this.Token(SeleniumUISyntaxKind.None), null);
				return defaultToken;
			}
	    }
	
		private SyntaxTrivia defaultTrivia = null;
	    protected override SyntaxTrivia DefaultTrivia
	    {
	        get 
			{
				if (defaultTrivia != null) return defaultTrivia;
			    Interlocked.CompareExchange(ref defaultTrivia, this.Trivia(SeleniumUISyntaxKind.None, string.Empty), null);
				return defaultTrivia;
			}
	    }
	
		private SyntaxToken defaultSeparator = null;
	    protected override SyntaxToken DefaultSeparator
	    {
	        get 
			{
				if (defaultSeparator != null) return defaultSeparator;
			    Interlocked.CompareExchange(ref defaultSeparator, this.Token(SeleniumUISyntaxKind.TComma), null);
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
		public SyntaxToken Token(SeleniumUISyntaxKind kind)
		{
			return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.Token(kind).CreateRed();
		}
	
		public SyntaxTrivia Trivia(SeleniumUISyntaxKind kind, string text)
		{
			return (SyntaxTrivia)SeleniumUILanguage.Instance.InternalSyntaxFactory.Trivia(kind, text).CreateRed();
		}
	
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public SeleniumUISyntaxTree SyntaxTree(SyntaxNode root, SeleniumUIParseOptions options = null, string path = "", Encoding encoding = null)
		{
		    return SeleniumUISyntaxTree.Create((SeleniumUISyntaxNode)root, (SeleniumUIParseOptions)options, path, encoding);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public SeleniumUISyntaxTree ParseSyntaxTree(
		    string text,
		    SeleniumUIParseOptions options = null,
		    string path = "",
		    Encoding encoding = null,
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (SeleniumUISyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public SeleniumUISyntaxTree ParseSyntaxTree(
		    SourceText text,
		    SeleniumUIParseOptions options = null,
		    string path = "",
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (SeleniumUISyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
	
		protected override SyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return SeleniumUISyntaxTree.ParseText(text, (SeleniumUIParseOptions)options, path, cancellationToken);
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
		    return new SeleniumUISyntaxParser(text, (SeleniumUIParseOptions)options, oldTree, changes);
		}
	
		public override SyntaxParser MakeParser(string text)
		{
		    return new SeleniumUISyntaxParser(SourceText.From(text, Encoding.UTF8), SeleniumUIParseOptions.Default, null, null);
		}
	
	    public SyntaxToken LIdentifier(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LIdentifier(text).CreateRed();
	    }
	
	    public SyntaxToken LIdentifier(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LIdentifier(text, value).CreateRed();
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LInteger(text).CreateRed();
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LInteger(text, value).CreateRed();
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LDecimal(text).CreateRed();
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LDecimal(text, value).CreateRed();
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LScientific(text).CreateRed();
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LScientific(text, value).CreateRed();
	    }
	
	    public SyntaxToken LRegularString(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LRegularString(text).CreateRed();
	    }
	
	    public SyntaxToken LRegularString(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LRegularString(text, value).CreateRed();
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text).CreateRed();
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value).CreateRed();
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text).CreateRed();
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value).CreateRed();
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LCrLf(text).CreateRed();
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LCrLf(text, value).CreateRed();
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LLineEnd(text).CreateRed();
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value).CreateRed();
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text).CreateRed();
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value).CreateRed();
	    }
	
	    public SyntaxToken LComment(string text)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LComment(text).CreateRed();
	    }
	
	    public SyntaxToken LComment(string text, object value)
	    {
	        return (SyntaxToken)SeleniumUILanguage.Instance.InternalSyntaxFactory.LComment(text, value).CreateRed();
	    }
		
		public MainSyntax Main(SyntaxNodeList<NamespaceSyntax> _namespace, SyntaxToken eof)
		{
		    if (eof == null) throw new ArgumentNullException(nameof(eof));
		    if (eof.RawKind != (int)SeleniumUISyntaxKind.Eof) throw new ArgumentException(nameof(eof));
		    return (MainSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Main(_namespace == null ? null : _namespace.Green, (InternalSyntaxToken)eof.Green).CreateRed();
		}
		
		public MainSyntax Main(SyntaxToken eof)
		{
			return this.Main(null, eof);
		}
		
		public NamespaceSyntax Namespace(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.RawKind != (int)SeleniumUISyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
		    return (NamespaceSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Namespace((InternalSyntaxToken)kNamespace.Green, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBodyGreen)namespaceBody.Green).CreateRed();
		}
		
		public NamespaceSyntax Namespace(QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
			return this.Namespace(this.Token(SeleniumUISyntaxKind.KNamespace), qualifiedName, namespaceBody);
		}
		
		public NamespaceBodySyntax NamespaceBody(SyntaxToken tOpenBrace, SyntaxNodeList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.RawKind != (int)SeleniumUISyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.RawKind != (int)SeleniumUISyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBodySyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.NamespaceBody((InternalSyntaxToken)tOpenBrace.Green, declaration == null ? null : declaration.Green, (InternalSyntaxToken)tCloseBrace.Green).CreateRed();
		}
		
		public NamespaceBodySyntax NamespaceBody()
		{
			return this.NamespaceBody(this.Token(SeleniumUISyntaxKind.TOpenBrace), null, this.Token(SeleniumUISyntaxKind.TCloseBrace));
		}
		
		public DeclarationSyntax Declaration(TagSyntax tag)
		{
		    if (tag == null) throw new ArgumentNullException(nameof(tag));
		    return (DeclarationSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.TagGreen)tag.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(PageSyntax page)
		{
		    if (page == null) throw new ArgumentNullException(nameof(page));
		    return (DeclarationSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.PageGreen)page.Green).CreateRed();
		}
		
		public TagSyntax Tag(SyntaxToken kTag, NameSyntax name, TypeSpecifierSyntax typeSpecifier, SyntaxToken tSemicolon)
		{
		    if (kTag == null) throw new ArgumentNullException(nameof(kTag));
		    if (kTag.RawKind != (int)SeleniumUISyntaxKind.KTag) throw new ArgumentException(nameof(kTag));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)SeleniumUISyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (TagSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Tag((InternalSyntaxToken)kTag.Green, (Syntax.InternalSyntax.NameGreen)name.Green, typeSpecifier == null ? null : (Syntax.InternalSyntax.TypeSpecifierGreen)typeSpecifier.Green, (InternalSyntaxToken)tSemicolon.Green).CreateRed();
		}
		
		public TagSyntax Tag(NameSyntax name)
		{
			return this.Tag(this.Token(SeleniumUISyntaxKind.KTag), name, null, this.Token(SeleniumUISyntaxKind.TSemicolon));
		}
		
		public TypeSpecifierSyntax TypeSpecifier(SyntaxToken tColon, QualifierSyntax qualifier)
		{
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.RawKind != (int)SeleniumUISyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (TypeSpecifierSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.TypeSpecifier((InternalSyntaxToken)tColon.Green, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public TypeSpecifierSyntax TypeSpecifier(QualifierSyntax qualifier)
		{
			return this.TypeSpecifier(this.Token(SeleniumUISyntaxKind.TColon), qualifier);
		}
		
		public PageSyntax Page(SyntaxToken kPage, NameSyntax name, ElementBodySyntax elementBody)
		{
		    if (kPage == null) throw new ArgumentNullException(nameof(kPage));
		    if (kPage.RawKind != (int)SeleniumUISyntaxKind.KPage) throw new ArgumentException(nameof(kPage));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (elementBody == null) throw new ArgumentNullException(nameof(elementBody));
		    return (PageSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Page((InternalSyntaxToken)kPage.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.ElementBodyGreen)elementBody.Green).CreateRed();
		}
		
		public PageSyntax Page(NameSyntax name, ElementBodySyntax elementBody)
		{
			return this.Page(this.Token(SeleniumUISyntaxKind.KPage), name, elementBody);
		}
		
		public ElementSyntax Element(SyntaxToken kElement, NameSyntax name, TagSpecifierSyntax tagSpecifier, LocatorSpecifierSyntax locatorSpecifier, ElementBodySyntax elementBody)
		{
		    if (kElement == null) throw new ArgumentNullException(nameof(kElement));
		    if (kElement.RawKind != (int)SeleniumUISyntaxKind.KElement) throw new ArgumentException(nameof(kElement));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (locatorSpecifier == null) throw new ArgumentNullException(nameof(locatorSpecifier));
		    if (elementBody == null) throw new ArgumentNullException(nameof(elementBody));
		    return (ElementSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Element((InternalSyntaxToken)kElement.Green, (Syntax.InternalSyntax.NameGreen)name.Green, tagSpecifier == null ? null : (Syntax.InternalSyntax.TagSpecifierGreen)tagSpecifier.Green, (Syntax.InternalSyntax.LocatorSpecifierGreen)locatorSpecifier.Green, (Syntax.InternalSyntax.ElementBodyGreen)elementBody.Green).CreateRed();
		}
		
		public ElementSyntax Element(NameSyntax name, LocatorSpecifierSyntax locatorSpecifier, ElementBodySyntax elementBody)
		{
			return this.Element(this.Token(SeleniumUISyntaxKind.KElement), name, null, locatorSpecifier, elementBody);
		}
		
		public TagSpecifierSyntax TagSpecifier(SyntaxToken tColon, QualifierSyntax qualifier)
		{
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.RawKind != (int)SeleniumUISyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (TagSpecifierSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.TagSpecifier((InternalSyntaxToken)tColon.Green, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public TagSpecifierSyntax TagSpecifier(QualifierSyntax qualifier)
		{
			return this.TagSpecifier(this.Token(SeleniumUISyntaxKind.TColon), qualifier);
		}
		
		public LocatorSpecifierSyntax LocatorSpecifier(SyntaxToken tAssign, StringSyntax _string)
		{
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.RawKind != (int)SeleniumUISyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (_string == null) throw new ArgumentNullException(nameof(_string));
		    return (LocatorSpecifierSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.LocatorSpecifier((InternalSyntaxToken)tAssign.Green, (Syntax.InternalSyntax.StringGreen)_string.Green).CreateRed();
		}
		
		public LocatorSpecifierSyntax LocatorSpecifier(StringSyntax _string)
		{
			return this.LocatorSpecifier(this.Token(SeleniumUISyntaxKind.TAssign), _string);
		}
		
		public ElementBodySyntax ElementBody(EmptyElementBodySyntax emptyElementBody)
		{
		    if (emptyElementBody == null) throw new ArgumentNullException(nameof(emptyElementBody));
		    return (ElementBodySyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.ElementBody((Syntax.InternalSyntax.EmptyElementBodyGreen)emptyElementBody.Green).CreateRed();
		}
		
		public ElementBodySyntax ElementBody(ChildElementsBodySyntax childElementsBody)
		{
		    if (childElementsBody == null) throw new ArgumentNullException(nameof(childElementsBody));
		    return (ElementBodySyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.ElementBody((Syntax.InternalSyntax.ChildElementsBodyGreen)childElementsBody.Green).CreateRed();
		}
		
		public EmptyElementBodySyntax EmptyElementBody(SyntaxToken tSemicolon)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)SeleniumUISyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (EmptyElementBodySyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.EmptyElementBody((InternalSyntaxToken)tSemicolon.Green).CreateRed();
		}
		
		public EmptyElementBodySyntax EmptyElementBody()
		{
			return this.EmptyElementBody(this.Token(SeleniumUISyntaxKind.TSemicolon));
		}
		
		public ChildElementsBodySyntax ChildElementsBody(SyntaxToken tOpenBrace, SyntaxNodeList<ElementSyntax> element, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.RawKind != (int)SeleniumUISyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.RawKind != (int)SeleniumUISyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (ChildElementsBodySyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.ChildElementsBody((InternalSyntaxToken)tOpenBrace.Green, element == null ? null : element.Green, (InternalSyntaxToken)tCloseBrace.Green).CreateRed();
		}
		
		public ChildElementsBodySyntax ChildElementsBody()
		{
			return this.ChildElementsBody(this.Token(SeleniumUISyntaxKind.TOpenBrace), null, this.Token(SeleniumUISyntaxKind.TCloseBrace));
		}
		
		public QualifiedNameSyntax QualifiedName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifiedNameSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.QualifiedName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public QualifierSyntax Qualifier(SeparatedSyntaxNodeList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Qualifier(identifier.Green).CreateRed();
		}
		
		public IdentifierSyntax Identifier(SyntaxToken lIdentifier)
		{
		    if (lIdentifier == null) throw new ArgumentNullException(nameof(lIdentifier));
		    if (lIdentifier.RawKind != (int)SeleniumUISyntaxKind.LIdentifier) throw new ArgumentException(nameof(lIdentifier));
		    return (IdentifierSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)lIdentifier.Green).CreateRed();
		}
		
		public StringSyntax String(SyntaxToken _string)
		{
		    if (_string == null) throw new ArgumentNullException(nameof(_string));
		    return (StringSyntax)SeleniumUILanguage.Instance.InternalSyntaxFactory.String((InternalSyntaxToken)_string.Green).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(NamespaceSyntax),
				typeof(NamespaceBodySyntax),
				typeof(DeclarationSyntax),
				typeof(TagSyntax),
				typeof(TypeSpecifierSyntax),
				typeof(PageSyntax),
				typeof(ElementSyntax),
				typeof(TagSpecifierSyntax),
				typeof(LocatorSpecifierSyntax),
				typeof(ElementBodySyntax),
				typeof(EmptyElementBodySyntax),
				typeof(ChildElementsBodySyntax),
				typeof(QualifiedNameSyntax),
				typeof(NameSyntax),
				typeof(QualifierSyntax),
				typeof(IdentifierSyntax),
				typeof(StringSyntax),
			};
		}
	}
}

