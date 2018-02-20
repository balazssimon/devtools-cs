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

namespace DevToolsX.Documents.Compilers.MediaWiki.Syntax
{
    public abstract class MediaWikiSyntaxNode : SyntaxNode
    {
        protected MediaWikiSyntaxNode(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected MediaWikiSyntaxNode(InternalSyntaxNode green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public MediaWikiSyntaxKind Kind
        {
            get { return (MediaWikiSyntaxKind)base.RawKind; }
        }

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            IMediaWikiSyntaxVisitor<TResult> typedVisitor = visitor as IMediaWikiSyntaxVisitor<TResult>;
            if (typedVisitor != null)
            {
                return this.Accept(typedVisitor);
            }
            return default(TResult);
        }

        public abstract TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            IMediaWikiSyntaxVisitor typedVisitor = visitor as IMediaWikiSyntaxVisitor;
            if (typedVisitor != null)
            {
                this.Accept(typedVisitor);
            }
        }
        public abstract void Accept(IMediaWikiSyntaxVisitor visitor);
    }

    public class MediaWikiSyntaxTrivia : SyntaxTrivia
    {
        public MediaWikiSyntaxTrivia(InternalSyntaxTrivia green, SyntaxToken token, int position, int index)
            : base(green, token, position, index)
        {
        }

        public MediaWikiSyntaxKind Kind
        {
            get { return (MediaWikiSyntaxKind)base.RawKind; }
        }
    }

    public class MediaWikiSyntaxToken : SyntaxToken
    {
        public MediaWikiSyntaxToken(InternalSyntaxToken green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
        }

        public MediaWikiSyntaxKind Kind
        {
            get { return (MediaWikiSyntaxKind)base.RawKind; }
        }

        protected override SyntaxToken WithLeadingTriviaCore(InternalSyntaxTrivia[] leading)
        {
            return new MediaWikiSyntaxToken(this.GreenToken.WithLeadingTrivia(new InternalSyntaxTriviaList(leading, null, null)), null, 0, 0);
        }

        protected override SyntaxToken WithTrailingTriviaCore(InternalSyntaxTrivia[] trailing)
        {
            return new MediaWikiSyntaxToken(this.GreenToken.WithTrailingTrivia(new InternalSyntaxTriviaList(trailing, null, null)), null, 0, 0);
        }
    }
	
	public sealed class MainSyntax : MediaWikiSyntaxNode, ICompilationUnitSyntax
	{
	    private SyntaxNodeList specialBlockOrParagraph;
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<SpecialBlockOrParagraphSyntax> SpecialBlockOrParagraph 
		{ 
			get
			{
				var red = this.GetRed(ref this.specialBlockOrParagraph, 0);
				if (red != null)
				{
					return new SyntaxNodeList<SpecialBlockOrParagraphSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken Eof 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.Eof;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.specialBlockOrParagraph, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.specialBlockOrParagraph;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithSpecialBlockOrParagraph(SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
			return this.Update(SpecialBlockOrParagraph, this.Eof);
		}
	
	    public MainSyntax AddSpecialBlockOrParagraph(params SpecialBlockOrParagraphSyntax[] specialBlockOrParagraph)
		{
			return this.WithSpecialBlockOrParagraph(this.SpecialBlockOrParagraph.AddRange(specialBlockOrParagraph));
		}
	
	    public MainSyntax WithEof(SyntaxToken eof)
		{
			return this.Update(this.SpecialBlockOrParagraph, Eof);
		}
	
	    public MainSyntax Update(SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph, SyntaxToken eof)
	    {
	        if (this.SpecialBlockOrParagraph.Node != specialBlockOrParagraph.Node ||
				this.Eof != eof)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.Main(specialBlockOrParagraph, eof);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class SpecialBlockOrParagraphSyntax : MediaWikiSyntaxNode
	{
	    private SpecialBlockWithCommentSyntax specialBlockWithComment;
	    private ParagraphSyntax paragraph;
	
	    public SpecialBlockOrParagraphSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SpecialBlockOrParagraphSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SpecialBlockWithCommentSyntax SpecialBlockWithComment 
		{ 
			get { return this.GetRed(ref this.specialBlockWithComment, 0); } 
		}
	    public ParagraphSyntax Paragraph 
		{ 
			get { return this.GetRed(ref this.paragraph, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.specialBlockWithComment, 0);
				case 1: return this.GetRed(ref this.paragraph, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.specialBlockWithComment;
				case 1: return this.paragraph;
				default: return null;
	        }
	    }
	
	    public SpecialBlockOrParagraphSyntax WithSpecialBlockWithComment(SpecialBlockWithCommentSyntax specialBlockWithComment)
		{
			return this.Update(specialBlockWithComment);
		}
	
	    public SpecialBlockOrParagraphSyntax WithParagraph(ParagraphSyntax paragraph)
		{
			return this.Update(paragraph);
		}
	
	    public SpecialBlockOrParagraphSyntax Update(SpecialBlockWithCommentSyntax specialBlockWithComment)
	    {
	        if (this.SpecialBlockWithComment != specialBlockWithComment)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpecialBlockOrParagraph(specialBlockWithComment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockOrParagraphSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockOrParagraphSyntax Update(ParagraphSyntax paragraph)
	    {
	        if (this.Paragraph != paragraph)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpecialBlockOrParagraph(paragraph);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockOrParagraphSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSpecialBlockOrParagraph(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitSpecialBlockOrParagraph(this);
	    }
	}
	
	public sealed class SpecialBlockWithCommentSyntax : MediaWikiSyntaxNode
	{
	    private HtmlCommentListSyntax leadingComment;
	    private SpecialBlockSyntax specialBlock;
	    private HtmlCommentListSyntax trailingComment;
	
	    public SpecialBlockWithCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SpecialBlockWithCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlCommentListSyntax LeadingComment 
		{ 
			get { return this.GetRed(ref this.leadingComment, 0); } 
		}
	    public SpecialBlockSyntax SpecialBlock 
		{ 
			get { return this.GetRed(ref this.specialBlock, 1); } 
		}
	    public HtmlCommentListSyntax TrailingComment 
		{ 
			get { return this.GetRed(ref this.trailingComment, 2); } 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.SpecialBlockWithCommentGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingComment, 0);
				case 1: return this.GetRed(ref this.specialBlock, 1);
				case 2: return this.GetRed(ref this.trailingComment, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingComment;
				case 1: return this.specialBlock;
				case 2: return this.trailingComment;
				default: return null;
	        }
	    }
	
	    public SpecialBlockWithCommentSyntax WithLeadingComment(HtmlCommentListSyntax leadingComment)
		{
			return this.Update(LeadingComment, this.SpecialBlock, this.TrailingComment, this.CRLF);
		}
	
	    public SpecialBlockWithCommentSyntax WithSpecialBlock(SpecialBlockSyntax specialBlock)
		{
			return this.Update(this.LeadingComment, SpecialBlock, this.TrailingComment, this.CRLF);
		}
	
	    public SpecialBlockWithCommentSyntax WithTrailingComment(HtmlCommentListSyntax trailingComment)
		{
			return this.Update(this.LeadingComment, this.SpecialBlock, TrailingComment, this.CRLF);
		}
	
	    public SpecialBlockWithCommentSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.LeadingComment, this.SpecialBlock, this.TrailingComment, CRLF);
		}
	
	    public SpecialBlockWithCommentSyntax Update(HtmlCommentListSyntax leadingComment, SpecialBlockSyntax specialBlock, HtmlCommentListSyntax trailingComment, SyntaxToken crlf)
	    {
	        if (this.LeadingComment != leadingComment ||
				this.SpecialBlock != specialBlock ||
				this.TrailingComment != trailingComment ||
				this.CRLF != crlf)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpecialBlockWithComment(leadingComment, specialBlock, trailingComment, crlf);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockWithCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSpecialBlockWithComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitSpecialBlockWithComment(this);
	    }
	}
	
	public sealed class SpecialBlockSyntax : MediaWikiSyntaxNode
	{
	    private HeadingSyntax heading;
	    private HorizontalRuleSyntax horizontalRule;
	    private CodeBlockSyntax codeBlock;
	    private WikiListSyntax wikiList;
	    private WikiTableSyntax wikiTable;
	
	    public SpecialBlockSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SpecialBlockSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HeadingSyntax Heading 
		{ 
			get { return this.GetRed(ref this.heading, 0); } 
		}
	    public HorizontalRuleSyntax HorizontalRule 
		{ 
			get { return this.GetRed(ref this.horizontalRule, 1); } 
		}
	    public CodeBlockSyntax CodeBlock 
		{ 
			get { return this.GetRed(ref this.codeBlock, 2); } 
		}
	    public WikiListSyntax WikiList 
		{ 
			get { return this.GetRed(ref this.wikiList, 3); } 
		}
	    public WikiTableSyntax WikiTable 
		{ 
			get { return this.GetRed(ref this.wikiTable, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.heading, 0);
				case 1: return this.GetRed(ref this.horizontalRule, 1);
				case 2: return this.GetRed(ref this.codeBlock, 2);
				case 3: return this.GetRed(ref this.wikiList, 3);
				case 4: return this.GetRed(ref this.wikiTable, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.heading;
				case 1: return this.horizontalRule;
				case 2: return this.codeBlock;
				case 3: return this.wikiList;
				case 4: return this.wikiTable;
				default: return null;
	        }
	    }
	
	    public SpecialBlockSyntax WithHeading(HeadingSyntax heading)
		{
			return this.Update(heading);
		}
	
	    public SpecialBlockSyntax WithHorizontalRule(HorizontalRuleSyntax horizontalRule)
		{
			return this.Update(horizontalRule);
		}
	
	    public SpecialBlockSyntax WithCodeBlock(CodeBlockSyntax codeBlock)
		{
			return this.Update(codeBlock);
		}
	
	    public SpecialBlockSyntax WithWikiList(WikiListSyntax wikiList)
		{
			return this.Update(wikiList);
		}
	
	    public SpecialBlockSyntax WithWikiTable(WikiTableSyntax wikiTable)
		{
			return this.Update(wikiTable);
		}
	
	    public SpecialBlockSyntax Update(HeadingSyntax heading)
	    {
	        if (this.Heading != heading)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpecialBlock(heading);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockSyntax Update(HorizontalRuleSyntax horizontalRule)
	    {
	        if (this.HorizontalRule != horizontalRule)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpecialBlock(horizontalRule);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockSyntax Update(CodeBlockSyntax codeBlock)
	    {
	        if (this.CodeBlock != codeBlock)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpecialBlock(codeBlock);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockSyntax Update(WikiListSyntax wikiList)
	    {
	        if (this.WikiList != wikiList)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpecialBlock(wikiList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockSyntax Update(WikiTableSyntax wikiTable)
	    {
	        if (this.WikiTable != wikiTable)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpecialBlock(wikiTable);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSpecialBlock(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitSpecialBlock(this);
	    }
	}
	
	public sealed class HeadingSyntax : MediaWikiSyntaxNode
	{
	    private HeadingLevelSyntax headingStart;
	    private HeadingTextSyntax headingText;
	    private HeadingLevelSyntax headingEnd;
	    private InlineTextSyntax inlineText;
	
	    public HeadingSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HeadingSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HeadingLevelSyntax HeadingStart 
		{ 
			get { return this.GetRed(ref this.headingStart, 0); } 
		}
	    public HeadingTextSyntax HeadingText 
		{ 
			get { return this.GetRed(ref this.headingText, 1); } 
		}
	    public HeadingLevelSyntax HeadingEnd 
		{ 
			get { return this.GetRed(ref this.headingEnd, 2); } 
		}
	    public InlineTextSyntax InlineText 
		{ 
			get { return this.GetRed(ref this.inlineText, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.headingStart, 0);
				case 1: return this.GetRed(ref this.headingText, 1);
				case 2: return this.GetRed(ref this.headingEnd, 2);
				case 3: return this.GetRed(ref this.inlineText, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.headingStart;
				case 1: return this.headingText;
				case 2: return this.headingEnd;
				case 3: return this.inlineText;
				default: return null;
	        }
	    }
	
	    public HeadingSyntax WithHeadingStart(HeadingLevelSyntax headingStart)
		{
			return this.Update(HeadingStart, this.HeadingText, this.HeadingEnd, this.InlineText);
		}
	
	    public HeadingSyntax WithHeadingText(HeadingTextSyntax headingText)
		{
			return this.Update(this.HeadingStart, HeadingText, this.HeadingEnd, this.InlineText);
		}
	
	    public HeadingSyntax WithHeadingEnd(HeadingLevelSyntax headingEnd)
		{
			return this.Update(this.HeadingStart, this.HeadingText, HeadingEnd, this.InlineText);
		}
	
	    public HeadingSyntax WithInlineText(InlineTextSyntax inlineText)
		{
			return this.Update(this.HeadingStart, this.HeadingText, this.HeadingEnd, InlineText);
		}
	
	    public HeadingSyntax Update(HeadingLevelSyntax headingStart, HeadingTextSyntax headingText, HeadingLevelSyntax headingEnd, InlineTextSyntax inlineText)
	    {
	        if (this.HeadingStart != headingStart ||
				this.HeadingText != headingText ||
				this.HeadingEnd != headingEnd ||
				this.InlineText != inlineText)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.Heading(headingStart, headingText, headingEnd, inlineText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHeading(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHeading(this);
	    }
	}
	
	public sealed class HeadingLevelSyntax : MediaWikiSyntaxNode
	{
	
	    public HeadingLevelSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HeadingLevelSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken THeading 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HeadingLevelGreen)this.Green;
				var greenToken = green.THeading;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HeadingLevelSyntax WithTHeading(SyntaxToken tHeading)
		{
			return this.Update(THeading);
		}
	
	    public HeadingLevelSyntax Update(SyntaxToken tHeading)
	    {
	        if (this.THeading != tHeading)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HeadingLevel(tHeading);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingLevelSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHeadingLevel(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHeadingLevel(this);
	    }
	}
	
	public sealed class HorizontalRuleSyntax : MediaWikiSyntaxNode
	{
	    private InlineTextSyntax inlineText;
	
	    public HorizontalRuleSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HorizontalRuleSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken THorizontalLine 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HorizontalRuleGreen)this.Green;
				var greenToken = green.THorizontalLine;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public InlineTextSyntax InlineText 
		{ 
			get { return this.GetRed(ref this.inlineText, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.inlineText, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.inlineText;
				default: return null;
	        }
	    }
	
	    public HorizontalRuleSyntax WithTHorizontalLine(SyntaxToken tHorizontalLine)
		{
			return this.Update(THorizontalLine, this.InlineText);
		}
	
	    public HorizontalRuleSyntax WithInlineText(InlineTextSyntax inlineText)
		{
			return this.Update(this.THorizontalLine, InlineText);
		}
	
	    public HorizontalRuleSyntax Update(SyntaxToken tHorizontalLine, InlineTextSyntax inlineText)
	    {
	        if (this.THorizontalLine != tHorizontalLine ||
				this.InlineText != inlineText)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HorizontalRule(tHorizontalLine, inlineText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HorizontalRuleSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHorizontalRule(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHorizontalRule(this);
	    }
	}
	
	public sealed class CodeBlockSyntax : MediaWikiSyntaxNode
	{
	    private SeparatedSyntaxNodeList spaceBlock;
	
	    public CodeBlockSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CodeBlockSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<SpaceBlockSyntax> SpaceBlock 
		{ 
			get
			{
				var red = this.GetRed(ref this.spaceBlock, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<SpaceBlockSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.spaceBlock, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.spaceBlock;
				default: return null;
	        }
	    }
	
	    public CodeBlockSyntax WithSpaceBlock(SeparatedSyntaxNodeList<SpaceBlockSyntax> spaceBlock)
		{
			return this.Update(SpaceBlock);
		}
	
	    public CodeBlockSyntax AddSpaceBlock(params SpaceBlockSyntax[] spaceBlock)
		{
			return this.WithSpaceBlock(this.SpaceBlock.AddRange(spaceBlock));
		}
	
	    public CodeBlockSyntax Update(SeparatedSyntaxNodeList<SpaceBlockSyntax> spaceBlock)
	    {
	        if (this.SpaceBlock.Node != spaceBlock.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.CodeBlock(spaceBlock);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CodeBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCodeBlock(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitCodeBlock(this);
	    }
	}
	
	public sealed class SpaceBlockSyntax : MediaWikiSyntaxNode
	{
	    private InlineTextSyntax inlineText;
	
	    public SpaceBlockSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SpaceBlockSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSpaceBlockStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.SpaceBlockGreen)this.Green;
				var greenToken = green.TSpaceBlockStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public InlineTextSyntax InlineText 
		{ 
			get { return this.GetRed(ref this.inlineText, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.inlineText, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.inlineText;
				default: return null;
	        }
	    }
	
	    public SpaceBlockSyntax WithTSpaceBlockStart(SyntaxToken tSpaceBlockStart)
		{
			return this.Update(TSpaceBlockStart, this.InlineText);
		}
	
	    public SpaceBlockSyntax WithInlineText(InlineTextSyntax inlineText)
		{
			return this.Update(this.TSpaceBlockStart, InlineText);
		}
	
	    public SpaceBlockSyntax Update(SyntaxToken tSpaceBlockStart, InlineTextSyntax inlineText)
	    {
	        if (this.TSpaceBlockStart != tSpaceBlockStart ||
				this.InlineText != inlineText)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.SpaceBlock(tSpaceBlockStart, inlineText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpaceBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSpaceBlock(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitSpaceBlock(this);
	    }
	}
	
	public sealed class WikiListSyntax : MediaWikiSyntaxNode
	{
	    private SeparatedSyntaxNodeList listItem;
	
	    public WikiListSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WikiListSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<ListItemSyntax> ListItem 
		{ 
			get
			{
				var red = this.GetRed(ref this.listItem, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<ListItemSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.listItem, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.listItem;
				default: return null;
	        }
	    }
	
	    public WikiListSyntax WithListItem(SeparatedSyntaxNodeList<ListItemSyntax> listItem)
		{
			return this.Update(ListItem);
		}
	
	    public WikiListSyntax AddListItem(params ListItemSyntax[] listItem)
		{
			return this.WithListItem(this.ListItem.AddRange(listItem));
		}
	
	    public WikiListSyntax Update(SeparatedSyntaxNodeList<ListItemSyntax> listItem)
	    {
	        if (this.ListItem.Node != listItem.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiList(listItem);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWikiList(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWikiList(this);
	    }
	}
	
	public sealed class ListItemSyntax : MediaWikiSyntaxNode
	{
	    private NormalListItemSyntax normalListItem;
	    private DefinitionItemSyntax definitionItem;
	
	    public ListItemSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ListItemSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NormalListItemSyntax NormalListItem 
		{ 
			get { return this.GetRed(ref this.normalListItem, 0); } 
		}
	    public DefinitionItemSyntax DefinitionItem 
		{ 
			get { return this.GetRed(ref this.definitionItem, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.normalListItem, 0);
				case 1: return this.GetRed(ref this.definitionItem, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.normalListItem;
				case 1: return this.definitionItem;
				default: return null;
	        }
	    }
	
	    public ListItemSyntax WithNormalListItem(NormalListItemSyntax normalListItem)
		{
			return this.Update(normalListItem);
		}
	
	    public ListItemSyntax WithDefinitionItem(DefinitionItemSyntax definitionItem)
		{
			return this.Update(definitionItem);
		}
	
	    public ListItemSyntax Update(NormalListItemSyntax normalListItem)
	    {
	        if (this.NormalListItem != normalListItem)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.ListItem(normalListItem);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ListItemSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ListItemSyntax Update(DefinitionItemSyntax definitionItem)
	    {
	        if (this.DefinitionItem != definitionItem)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.ListItem(definitionItem);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ListItemSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitListItem(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitListItem(this);
	    }
	}
	
	public sealed class NormalListItemSyntax : MediaWikiSyntaxNode
	{
	    private InlineTextSyntax inlineText;
	
	    public NormalListItemSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NormalListItemSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TListStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.NormalListItemGreen)this.Green;
				var greenToken = green.TListStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public InlineTextSyntax InlineText 
		{ 
			get { return this.GetRed(ref this.inlineText, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.inlineText, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.inlineText;
				default: return null;
	        }
	    }
	
	    public NormalListItemSyntax WithTListStart(SyntaxToken tListStart)
		{
			return this.Update(TListStart, this.InlineText);
		}
	
	    public NormalListItemSyntax WithInlineText(InlineTextSyntax inlineText)
		{
			return this.Update(this.TListStart, InlineText);
		}
	
	    public NormalListItemSyntax Update(SyntaxToken tListStart, InlineTextSyntax inlineText)
	    {
	        if (this.TListStart != tListStart ||
				this.InlineText != inlineText)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.NormalListItem(tListStart, inlineText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NormalListItemSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNormalListItem(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitNormalListItem(this);
	    }
	}
	
	public sealed class DefinitionItemSyntax : MediaWikiSyntaxNode
	{
	    private DefinitionTextSyntax definitionText;
	    private InlineTextSyntax inlineText;
	
	    public DefinitionItemSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefinitionItemSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TDefinitionStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.DefinitionItemGreen)this.Green;
				var greenToken = green.TDefinitionStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public DefinitionTextSyntax DefinitionText 
		{ 
			get { return this.GetRed(ref this.definitionText, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.DefinitionItemGreen)this.Green;
				var greenToken = green.TColon;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public InlineTextSyntax InlineText 
		{ 
			get { return this.GetRed(ref this.inlineText, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.definitionText, 1);
				case 3: return this.GetRed(ref this.inlineText, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.definitionText;
				case 3: return this.inlineText;
				default: return null;
	        }
	    }
	
	    public DefinitionItemSyntax WithTDefinitionStart(SyntaxToken tDefinitionStart)
		{
			return this.Update(TDefinitionStart, this.DefinitionText, this.TColon, this.InlineText);
		}
	
	    public DefinitionItemSyntax WithDefinitionText(DefinitionTextSyntax definitionText)
		{
			return this.Update(this.TDefinitionStart, DefinitionText, this.TColon, this.InlineText);
		}
	
	    public DefinitionItemSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.TDefinitionStart, this.DefinitionText, TColon, this.InlineText);
		}
	
	    public DefinitionItemSyntax WithInlineText(InlineTextSyntax inlineText)
		{
			return this.Update(this.TDefinitionStart, this.DefinitionText, this.TColon, InlineText);
		}
	
	    public DefinitionItemSyntax Update(SyntaxToken tDefinitionStart, DefinitionTextSyntax definitionText, SyntaxToken tColon, InlineTextSyntax inlineText)
	    {
	        if (this.TDefinitionStart != tDefinitionStart ||
				this.DefinitionText != definitionText ||
				this.TColon != tColon ||
				this.InlineText != inlineText)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.DefinitionItem(tDefinitionStart, definitionText, tColon, inlineText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionItemSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefinitionItem(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitDefinitionItem(this);
	    }
	}
	
	public sealed class WikiTableSyntax : MediaWikiSyntaxNode
	{
	    private InlineTextSyntax leadingInlineText;
	    private TableCaptionSyntax tableCaption;
	    private TableRowsSyntax tableRows;
	    private InlineTextSyntax trailingInlineText;
	
	    public WikiTableSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WikiTableSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTableStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiTableGreen)this.Green;
				var greenToken = green.TTableStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public InlineTextSyntax LeadingInlineText 
		{ 
			get { return this.GetRed(ref this.leadingInlineText, 1); } 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiTableGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public TableCaptionSyntax TableCaption 
		{ 
			get { return this.GetRed(ref this.tableCaption, 3); } 
		}
	    public TableRowsSyntax TableRows 
		{ 
			get { return this.GetRed(ref this.tableRows, 4); } 
		}
	    public SyntaxToken TTableEnd 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiTableGreen)this.Green;
				var greenToken = green.TTableEnd;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(5), this.GetChildIndex(5)); 
			}
		}
	    public InlineTextSyntax TrailingInlineText 
		{ 
			get { return this.GetRed(ref this.trailingInlineText, 6); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.leadingInlineText, 1);
				case 3: return this.GetRed(ref this.tableCaption, 3);
				case 4: return this.GetRed(ref this.tableRows, 4);
				case 6: return this.GetRed(ref this.trailingInlineText, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.leadingInlineText;
				case 3: return this.tableCaption;
				case 4: return this.tableRows;
				case 6: return this.trailingInlineText;
				default: return null;
	        }
	    }
	
	    public WikiTableSyntax WithTTableStart(SyntaxToken tTableStart)
		{
			return this.Update(TTableStart, this.LeadingInlineText, this.CRLF, this.TableCaption, this.TableRows, this.TTableEnd, this.TrailingInlineText);
		}
	
	    public WikiTableSyntax WithLeadingInlineText(InlineTextSyntax leadingInlineText)
		{
			return this.Update(this.TTableStart, LeadingInlineText, this.CRLF, this.TableCaption, this.TableRows, this.TTableEnd, this.TrailingInlineText);
		}
	
	    public WikiTableSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.TTableStart, this.LeadingInlineText, CRLF, this.TableCaption, this.TableRows, this.TTableEnd, this.TrailingInlineText);
		}
	
	    public WikiTableSyntax WithTableCaption(TableCaptionSyntax tableCaption)
		{
			return this.Update(this.TTableStart, this.LeadingInlineText, this.CRLF, TableCaption, this.TableRows, this.TTableEnd, this.TrailingInlineText);
		}
	
	    public WikiTableSyntax WithTableRows(TableRowsSyntax tableRows)
		{
			return this.Update(this.TTableStart, this.LeadingInlineText, this.CRLF, this.TableCaption, TableRows, this.TTableEnd, this.TrailingInlineText);
		}
	
	    public WikiTableSyntax WithTTableEnd(SyntaxToken tTableEnd)
		{
			return this.Update(this.TTableStart, this.LeadingInlineText, this.CRLF, this.TableCaption, this.TableRows, TTableEnd, this.TrailingInlineText);
		}
	
	    public WikiTableSyntax WithTrailingInlineText(InlineTextSyntax trailingInlineText)
		{
			return this.Update(this.TTableStart, this.LeadingInlineText, this.CRLF, this.TableCaption, this.TableRows, this.TTableEnd, TrailingInlineText);
		}
	
	    public WikiTableSyntax Update(SyntaxToken tTableStart, InlineTextSyntax leadingInlineText, SyntaxToken crlf, TableCaptionSyntax tableCaption, TableRowsSyntax tableRows, SyntaxToken tTableEnd, InlineTextSyntax trailingInlineText)
	    {
	        if (this.TTableStart != tTableStart ||
				this.LeadingInlineText != leadingInlineText ||
				this.CRLF != crlf ||
				this.TableCaption != tableCaption ||
				this.TableRows != tableRows ||
				this.TTableEnd != tTableEnd ||
				this.TrailingInlineText != trailingInlineText)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiTable(tTableStart, leadingInlineText, crlf, tableCaption, tableRows, tTableEnd, trailingInlineText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiTableSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWikiTable(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWikiTable(this);
	    }
	}
	
	public sealed class TableCaptionSyntax : MediaWikiSyntaxNode
	{
	    private InlineTextSyntax inlineText;
	    private SyntaxNodeList specialBlockOrParagraph;
	
	    public TableCaptionSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableCaptionSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTableCaptionStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableCaptionGreen)this.Green;
				var greenToken = green.TTableCaptionStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public InlineTextSyntax InlineText 
		{ 
			get { return this.GetRed(ref this.inlineText, 1); } 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableCaptionGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public SyntaxNodeList<SpecialBlockOrParagraphSyntax> SpecialBlockOrParagraph 
		{ 
			get
			{
				var red = this.GetRed(ref this.specialBlockOrParagraph, 3);
				if (red != null)
				{
					return new SyntaxNodeList<SpecialBlockOrParagraphSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.inlineText, 1);
				case 3: return this.GetRed(ref this.specialBlockOrParagraph, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.inlineText;
				case 3: return this.specialBlockOrParagraph;
				default: return null;
	        }
	    }
	
	    public TableCaptionSyntax WithTTableCaptionStart(SyntaxToken tTableCaptionStart)
		{
			return this.Update(TTableCaptionStart, this.InlineText, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableCaptionSyntax WithInlineText(InlineTextSyntax inlineText)
		{
			return this.Update(this.TTableCaptionStart, InlineText, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableCaptionSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.TTableCaptionStart, this.InlineText, CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableCaptionSyntax WithSpecialBlockOrParagraph(SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
			return this.Update(this.TTableCaptionStart, this.InlineText, this.CRLF, SpecialBlockOrParagraph);
		}
	
	    public TableCaptionSyntax AddSpecialBlockOrParagraph(params SpecialBlockOrParagraphSyntax[] specialBlockOrParagraph)
		{
			return this.WithSpecialBlockOrParagraph(this.SpecialBlockOrParagraph.AddRange(specialBlockOrParagraph));
		}
	
	    public TableCaptionSyntax Update(SyntaxToken tTableCaptionStart, InlineTextSyntax inlineText, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
	    {
	        if (this.TTableCaptionStart != tTableCaptionStart ||
				this.InlineText != inlineText ||
				this.CRLF != crlf ||
				this.SpecialBlockOrParagraph.Node != specialBlockOrParagraph.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableCaption(tTableCaptionStart, inlineText, crlf, specialBlockOrParagraph);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableCaptionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableCaption(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableCaption(this);
	    }
	}
	
	public sealed class TableRowsSyntax : MediaWikiSyntaxNode
	{
	    private TableFirstRowSyntax tableFirstRow;
	    private SyntaxNodeList tableRow;
	
	    public TableRowsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableRowsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TableFirstRowSyntax TableFirstRow 
		{ 
			get { return this.GetRed(ref this.tableFirstRow, 0); } 
		}
	    public SyntaxNodeList<TableRowSyntax> TableRow 
		{ 
			get
			{
				var red = this.GetRed(ref this.tableRow, 1);
				if (red != null)
				{
					return new SyntaxNodeList<TableRowSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.tableFirstRow, 0);
				case 1: return this.GetRed(ref this.tableRow, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.tableFirstRow;
				case 1: return this.tableRow;
				default: return null;
	        }
	    }
	
	    public TableRowsSyntax WithTableFirstRow(TableFirstRowSyntax tableFirstRow)
		{
			return this.Update(TableFirstRow, this.TableRow);
		}
	
	    public TableRowsSyntax WithTableRow(SyntaxNodeList<TableRowSyntax> tableRow)
		{
			return this.Update(this.TableFirstRow, TableRow);
		}
	
	    public TableRowsSyntax AddTableRow(params TableRowSyntax[] tableRow)
		{
			return this.WithTableRow(this.TableRow.AddRange(tableRow));
		}
	
	    public TableRowsSyntax Update(TableFirstRowSyntax tableFirstRow, SyntaxNodeList<TableRowSyntax> tableRow)
	    {
	        if (this.TableFirstRow != tableFirstRow ||
				this.TableRow.Node != tableRow.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableRows(tableFirstRow, tableRow);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableRowsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableRows(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableRows(this);
	    }
	}
	
	public sealed class TableFirstRowSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList tableColumn;
	
	    public TableFirstRowSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableFirstRowSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<TableColumnSyntax> TableColumn 
		{ 
			get
			{
				var red = this.GetRed(ref this.tableColumn, 0);
				if (red != null)
				{
					return new SyntaxNodeList<TableColumnSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.tableColumn, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.tableColumn;
				default: return null;
	        }
	    }
	
	    public TableFirstRowSyntax WithTableColumn(SyntaxNodeList<TableColumnSyntax> tableColumn)
		{
			return this.Update(TableColumn);
		}
	
	    public TableFirstRowSyntax AddTableColumn(params TableColumnSyntax[] tableColumn)
		{
			return this.WithTableColumn(this.TableColumn.AddRange(tableColumn));
		}
	
	    public TableFirstRowSyntax Update(SyntaxNodeList<TableColumnSyntax> tableColumn)
	    {
	        if (this.TableColumn.Node != tableColumn.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableFirstRow(tableColumn);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableFirstRowSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableFirstRow(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableFirstRow(this);
	    }
	}
	
	public sealed class TableRowSyntax : MediaWikiSyntaxNode
	{
	    private InlineTextSyntax inlineText;
	    private SyntaxNodeList tableColumn;
	
	    public TableRowSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableRowSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTableRowStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableRowGreen)this.Green;
				var greenToken = green.TTableRowStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public InlineTextSyntax InlineText 
		{ 
			get { return this.GetRed(ref this.inlineText, 1); } 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableRowGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public SyntaxNodeList<TableColumnSyntax> TableColumn 
		{ 
			get
			{
				var red = this.GetRed(ref this.tableColumn, 3);
				if (red != null)
				{
					return new SyntaxNodeList<TableColumnSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.inlineText, 1);
				case 3: return this.GetRed(ref this.tableColumn, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.inlineText;
				case 3: return this.tableColumn;
				default: return null;
	        }
	    }
	
	    public TableRowSyntax WithTTableRowStart(SyntaxToken tTableRowStart)
		{
			return this.Update(TTableRowStart, this.InlineText, this.CRLF, this.TableColumn);
		}
	
	    public TableRowSyntax WithInlineText(InlineTextSyntax inlineText)
		{
			return this.Update(this.TTableRowStart, InlineText, this.CRLF, this.TableColumn);
		}
	
	    public TableRowSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.TTableRowStart, this.InlineText, CRLF, this.TableColumn);
		}
	
	    public TableRowSyntax WithTableColumn(SyntaxNodeList<TableColumnSyntax> tableColumn)
		{
			return this.Update(this.TTableRowStart, this.InlineText, this.CRLF, TableColumn);
		}
	
	    public TableRowSyntax AddTableColumn(params TableColumnSyntax[] tableColumn)
		{
			return this.WithTableColumn(this.TableColumn.AddRange(tableColumn));
		}
	
	    public TableRowSyntax Update(SyntaxToken tTableRowStart, InlineTextSyntax inlineText, SyntaxToken crlf, SyntaxNodeList<TableColumnSyntax> tableColumn)
	    {
	        if (this.TTableRowStart != tTableRowStart ||
				this.InlineText != inlineText ||
				this.CRLF != crlf ||
				this.TableColumn.Node != tableColumn.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableRow(tTableRowStart, inlineText, crlf, tableColumn);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableRowSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableRow(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableRow(this);
	    }
	}
	
	public sealed class TableColumnSyntax : MediaWikiSyntaxNode
	{
	    private TableSingleHeaderCellSyntax tableSingleHeaderCell;
	    private TableHeaderCellsSyntax tableHeaderCells;
	    private TableSingleCellSyntax tableSingleCell;
	    private TableCellsSyntax tableCells;
	
	    public TableColumnSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableColumnSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TableSingleHeaderCellSyntax TableSingleHeaderCell 
		{ 
			get { return this.GetRed(ref this.tableSingleHeaderCell, 0); } 
		}
	    public TableHeaderCellsSyntax TableHeaderCells 
		{ 
			get { return this.GetRed(ref this.tableHeaderCells, 1); } 
		}
	    public TableSingleCellSyntax TableSingleCell 
		{ 
			get { return this.GetRed(ref this.tableSingleCell, 2); } 
		}
	    public TableCellsSyntax TableCells 
		{ 
			get { return this.GetRed(ref this.tableCells, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.tableSingleHeaderCell, 0);
				case 1: return this.GetRed(ref this.tableHeaderCells, 1);
				case 2: return this.GetRed(ref this.tableSingleCell, 2);
				case 3: return this.GetRed(ref this.tableCells, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.tableSingleHeaderCell;
				case 1: return this.tableHeaderCells;
				case 2: return this.tableSingleCell;
				case 3: return this.tableCells;
				default: return null;
	        }
	    }
	
	    public TableColumnSyntax WithTableSingleHeaderCell(TableSingleHeaderCellSyntax tableSingleHeaderCell)
		{
			return this.Update(tableSingleHeaderCell);
		}
	
	    public TableColumnSyntax WithTableHeaderCells(TableHeaderCellsSyntax tableHeaderCells)
		{
			return this.Update(tableHeaderCells);
		}
	
	    public TableColumnSyntax WithTableSingleCell(TableSingleCellSyntax tableSingleCell)
		{
			return this.Update(tableSingleCell);
		}
	
	    public TableColumnSyntax WithTableCells(TableCellsSyntax tableCells)
		{
			return this.Update(tableCells);
		}
	
	    public TableColumnSyntax Update(TableSingleHeaderCellSyntax tableSingleHeaderCell)
	    {
	        if (this.TableSingleHeaderCell != tableSingleHeaderCell)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableColumn(tableSingleHeaderCell);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableColumnSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TableColumnSyntax Update(TableHeaderCellsSyntax tableHeaderCells)
	    {
	        if (this.TableHeaderCells != tableHeaderCells)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableColumn(tableHeaderCells);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableColumnSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TableColumnSyntax Update(TableSingleCellSyntax tableSingleCell)
	    {
	        if (this.TableSingleCell != tableSingleCell)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableColumn(tableSingleCell);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableColumnSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TableColumnSyntax Update(TableCellsSyntax tableCells)
	    {
	        if (this.TableCells != tableCells)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableColumn(tableCells);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableColumnSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableColumn(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableColumn(this);
	    }
	}
	
	public sealed class TableSingleHeaderCellSyntax : MediaWikiSyntaxNode
	{
	    private TableCellSyntax tableCell;
	    private SyntaxNodeList specialBlockOrParagraph;
	
	    public TableSingleHeaderCellSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableSingleHeaderCellSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TExclamation 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableSingleHeaderCellGreen)this.Green;
				var greenToken = green.TExclamation;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public TableCellSyntax TableCell 
		{ 
			get { return this.GetRed(ref this.tableCell, 1); } 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableSingleHeaderCellGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public SyntaxNodeList<SpecialBlockOrParagraphSyntax> SpecialBlockOrParagraph 
		{ 
			get
			{
				var red = this.GetRed(ref this.specialBlockOrParagraph, 3);
				if (red != null)
				{
					return new SyntaxNodeList<SpecialBlockOrParagraphSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.tableCell, 1);
				case 3: return this.GetRed(ref this.specialBlockOrParagraph, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.tableCell;
				case 3: return this.specialBlockOrParagraph;
				default: return null;
	        }
	    }
	
	    public TableSingleHeaderCellSyntax WithTExclamation(SyntaxToken tExclamation)
		{
			return this.Update(TExclamation, this.TableCell, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableSingleHeaderCellSyntax WithTableCell(TableCellSyntax tableCell)
		{
			return this.Update(this.TExclamation, TableCell, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableSingleHeaderCellSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.TExclamation, this.TableCell, CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableSingleHeaderCellSyntax WithSpecialBlockOrParagraph(SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
			return this.Update(this.TExclamation, this.TableCell, this.CRLF, SpecialBlockOrParagraph);
		}
	
	    public TableSingleHeaderCellSyntax AddSpecialBlockOrParagraph(params SpecialBlockOrParagraphSyntax[] specialBlockOrParagraph)
		{
			return this.WithSpecialBlockOrParagraph(this.SpecialBlockOrParagraph.AddRange(specialBlockOrParagraph));
		}
	
	    public TableSingleHeaderCellSyntax Update(SyntaxToken tExclamation, TableCellSyntax tableCell, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
	    {
	        if (this.TExclamation != tExclamation ||
				this.TableCell != tableCell ||
				this.CRLF != crlf ||
				this.SpecialBlockOrParagraph.Node != specialBlockOrParagraph.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableSingleHeaderCell(tExclamation, tableCell, crlf, specialBlockOrParagraph);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableSingleHeaderCellSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableSingleHeaderCell(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableSingleHeaderCell(this);
	    }
	}
	
	public sealed class TableHeaderCellsSyntax : MediaWikiSyntaxNode
	{
	    private SeparatedSyntaxNodeList tableCell;
	    private SyntaxNodeList specialBlockOrParagraph;
	
	    public TableHeaderCellsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableHeaderCellsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TExclamation 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableHeaderCellsGreen)this.Green;
				var greenToken = green.TExclamation;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public SeparatedSyntaxNodeList<TableCellSyntax> TableCell 
		{ 
			get
			{
				var red = this.GetRed(ref this.tableCell, 1);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<TableCellSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableHeaderCellsGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public SyntaxNodeList<SpecialBlockOrParagraphSyntax> SpecialBlockOrParagraph 
		{ 
			get
			{
				var red = this.GetRed(ref this.specialBlockOrParagraph, 3);
				if (red != null)
				{
					return new SyntaxNodeList<SpecialBlockOrParagraphSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.tableCell, 1);
				case 3: return this.GetRed(ref this.specialBlockOrParagraph, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.tableCell;
				case 3: return this.specialBlockOrParagraph;
				default: return null;
	        }
	    }
	
	    public TableHeaderCellsSyntax WithTExclamation(SyntaxToken tExclamation)
		{
			return this.Update(TExclamation, this.TableCell, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableHeaderCellsSyntax WithTableCell(SeparatedSyntaxNodeList<TableCellSyntax> tableCell)
		{
			return this.Update(this.TExclamation, TableCell, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableHeaderCellsSyntax AddTableCell(params TableCellSyntax[] tableCell)
		{
			return this.WithTableCell(this.TableCell.AddRange(tableCell));
		}
	
	    public TableHeaderCellsSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.TExclamation, this.TableCell, CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableHeaderCellsSyntax WithSpecialBlockOrParagraph(SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
			return this.Update(this.TExclamation, this.TableCell, this.CRLF, SpecialBlockOrParagraph);
		}
	
	    public TableHeaderCellsSyntax AddSpecialBlockOrParagraph(params SpecialBlockOrParagraphSyntax[] specialBlockOrParagraph)
		{
			return this.WithSpecialBlockOrParagraph(this.SpecialBlockOrParagraph.AddRange(specialBlockOrParagraph));
		}
	
	    public TableHeaderCellsSyntax Update(SyntaxToken tExclamation, SeparatedSyntaxNodeList<TableCellSyntax> tableCell, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
	    {
	        if (this.TExclamation != tExclamation ||
				this.TableCell.Node != tableCell.Node ||
				this.CRLF != crlf ||
				this.SpecialBlockOrParagraph.Node != specialBlockOrParagraph.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableHeaderCells(tExclamation, tableCell, crlf, specialBlockOrParagraph);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableHeaderCellsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableHeaderCells(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableHeaderCells(this);
	    }
	}
	
	public sealed class TableSingleCellSyntax : MediaWikiSyntaxNode
	{
	    private TableCellSyntax tableCell;
	    private SyntaxNodeList specialBlockOrParagraph;
	
	    public TableSingleCellSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableSingleCellSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TBar 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableSingleCellGreen)this.Green;
				var greenToken = green.TBar;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public TableCellSyntax TableCell 
		{ 
			get { return this.GetRed(ref this.tableCell, 1); } 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableSingleCellGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public SyntaxNodeList<SpecialBlockOrParagraphSyntax> SpecialBlockOrParagraph 
		{ 
			get
			{
				var red = this.GetRed(ref this.specialBlockOrParagraph, 3);
				if (red != null)
				{
					return new SyntaxNodeList<SpecialBlockOrParagraphSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.tableCell, 1);
				case 3: return this.GetRed(ref this.specialBlockOrParagraph, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.tableCell;
				case 3: return this.specialBlockOrParagraph;
				default: return null;
	        }
	    }
	
	    public TableSingleCellSyntax WithTBar(SyntaxToken tBar)
		{
			return this.Update(TBar, this.TableCell, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableSingleCellSyntax WithTableCell(TableCellSyntax tableCell)
		{
			return this.Update(this.TBar, TableCell, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableSingleCellSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.TBar, this.TableCell, CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableSingleCellSyntax WithSpecialBlockOrParagraph(SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
			return this.Update(this.TBar, this.TableCell, this.CRLF, SpecialBlockOrParagraph);
		}
	
	    public TableSingleCellSyntax AddSpecialBlockOrParagraph(params SpecialBlockOrParagraphSyntax[] specialBlockOrParagraph)
		{
			return this.WithSpecialBlockOrParagraph(this.SpecialBlockOrParagraph.AddRange(specialBlockOrParagraph));
		}
	
	    public TableSingleCellSyntax Update(SyntaxToken tBar, TableCellSyntax tableCell, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
	    {
	        if (this.TBar != tBar ||
				this.TableCell != tableCell ||
				this.CRLF != crlf ||
				this.SpecialBlockOrParagraph.Node != specialBlockOrParagraph.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableSingleCell(tBar, tableCell, crlf, specialBlockOrParagraph);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableSingleCellSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableSingleCell(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableSingleCell(this);
	    }
	}
	
	public sealed class TableCellsSyntax : MediaWikiSyntaxNode
	{
	    private SeparatedSyntaxNodeList tableCell;
	    private SyntaxNodeList specialBlockOrParagraph;
	
	    public TableCellsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableCellsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TBar 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableCellsGreen)this.Green;
				var greenToken = green.TBar;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public SeparatedSyntaxNodeList<TableCellSyntax> TableCell 
		{ 
			get
			{
				var red = this.GetRed(ref this.tableCell, 1);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<TableCellSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TableCellsGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public SyntaxNodeList<SpecialBlockOrParagraphSyntax> SpecialBlockOrParagraph 
		{ 
			get
			{
				var red = this.GetRed(ref this.specialBlockOrParagraph, 3);
				if (red != null)
				{
					return new SyntaxNodeList<SpecialBlockOrParagraphSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.tableCell, 1);
				case 3: return this.GetRed(ref this.specialBlockOrParagraph, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.tableCell;
				case 3: return this.specialBlockOrParagraph;
				default: return null;
	        }
	    }
	
	    public TableCellsSyntax WithTBar(SyntaxToken tBar)
		{
			return this.Update(TBar, this.TableCell, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableCellsSyntax WithTableCell(SeparatedSyntaxNodeList<TableCellSyntax> tableCell)
		{
			return this.Update(this.TBar, TableCell, this.CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableCellsSyntax AddTableCell(params TableCellSyntax[] tableCell)
		{
			return this.WithTableCell(this.TableCell.AddRange(tableCell));
		}
	
	    public TableCellsSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.TBar, this.TableCell, CRLF, this.SpecialBlockOrParagraph);
		}
	
	    public TableCellsSyntax WithSpecialBlockOrParagraph(SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
			return this.Update(this.TBar, this.TableCell, this.CRLF, SpecialBlockOrParagraph);
		}
	
	    public TableCellsSyntax AddSpecialBlockOrParagraph(params SpecialBlockOrParagraphSyntax[] specialBlockOrParagraph)
		{
			return this.WithSpecialBlockOrParagraph(this.SpecialBlockOrParagraph.AddRange(specialBlockOrParagraph));
		}
	
	    public TableCellsSyntax Update(SyntaxToken tBar, SeparatedSyntaxNodeList<TableCellSyntax> tableCell, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
	    {
	        if (this.TBar != tBar ||
				this.TableCell.Node != tableCell.Node ||
				this.CRLF != crlf ||
				this.SpecialBlockOrParagraph.Node != specialBlockOrParagraph.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableCells(tBar, tableCell, crlf, specialBlockOrParagraph);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableCellsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableCells(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableCells(this);
	    }
	}
	
	public sealed class TableCellSyntax : MediaWikiSyntaxNode
	{
	    private CellTextSyntax cellText;
	    private CellValueSyntax cellValue;
	
	    public TableCellSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TableCellSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public CellTextSyntax CellText 
		{ 
			get { return this.GetRed(ref this.cellText, 0); } 
		}
	    public CellValueSyntax CellValue 
		{ 
			get { return this.GetRed(ref this.cellValue, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.cellText, 0);
				case 1: return this.GetRed(ref this.cellValue, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.cellText;
				case 1: return this.cellValue;
				default: return null;
	        }
	    }
	
	    public TableCellSyntax WithCellText(CellTextSyntax cellText)
		{
			return this.Update(CellText, this.CellValue);
		}
	
	    public TableCellSyntax WithCellValue(CellValueSyntax cellValue)
		{
			return this.Update(this.CellText, CellValue);
		}
	
	    public TableCellSyntax Update(CellTextSyntax cellText, CellValueSyntax cellValue)
	    {
	        if (this.CellText != cellText ||
				this.CellValue != cellValue)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TableCell(cellText, cellValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableCellSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTableCell(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTableCell(this);
	    }
	}
	
	public sealed class CellValueSyntax : MediaWikiSyntaxNode
	{
	    private CellTextSyntax cellText;
	
	    public CellValueSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CellValueSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TBar 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.CellValueGreen)this.Green;
				var greenToken = green.TBar;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public CellTextSyntax CellText 
		{ 
			get { return this.GetRed(ref this.cellText, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.cellText, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.cellText;
				default: return null;
	        }
	    }
	
	    public CellValueSyntax WithTBar(SyntaxToken tBar)
		{
			return this.Update(TBar, this.CellText);
		}
	
	    public CellValueSyntax WithCellText(CellTextSyntax cellText)
		{
			return this.Update(this.TBar, CellText);
		}
	
	    public CellValueSyntax Update(SyntaxToken tBar, CellTextSyntax cellText)
	    {
	        if (this.TBar != tBar ||
				this.CellText != cellText)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.CellValue(tBar, cellText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCellValue(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitCellValue(this);
	    }
	}
	
	public sealed class ParagraphSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList textLine;
	
	    public ParagraphSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParagraphSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<TextLineSyntax> TextLine 
		{ 
			get
			{
				var red = this.GetRed(ref this.textLine, 0);
				if (red != null)
				{
					return new SyntaxNodeList<TextLineSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.textLine, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.textLine;
				default: return null;
	        }
	    }
	
	    public ParagraphSyntax WithTextLine(SyntaxNodeList<TextLineSyntax> textLine)
		{
			return this.Update(TextLine);
		}
	
	    public ParagraphSyntax AddTextLine(params TextLineSyntax[] textLine)
		{
			return this.WithTextLine(this.TextLine.AddRange(textLine));
		}
	
	    public ParagraphSyntax Update(SyntaxNodeList<TextLineSyntax> textLine)
	    {
	        if (this.TextLine.Node != textLine.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.Paragraph(textLine);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParagraphSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParagraph(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitParagraph(this);
	    }
	}
	
	public abstract class TextLineSyntax : MediaWikiSyntaxNode
	{
	    protected TextLineSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected TextLineSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class TextLineInlineElementsWithCommentSyntax : TextLineSyntax
	{
	    private HtmlCommentListSyntax leadingComment;
	    private SyntaxNodeList inlineTextElement;
	    private HtmlCommentListSyntax trailingComment;
	
	    public TextLineInlineElementsWithCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TextLineInlineElementsWithCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlCommentListSyntax LeadingComment 
		{ 
			get { return this.GetRed(ref this.leadingComment, 0); } 
		}
	    public SyntaxNodeList<InlineTextElementSyntax> InlineTextElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.inlineTextElement, 1);
				if (red != null)
				{
					return new SyntaxNodeList<InlineTextElementSyntax>(red);
				}
				return null;
			} 
		}
	    public HtmlCommentListSyntax TrailingComment 
		{ 
			get { return this.GetRed(ref this.trailingComment, 2); } 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TextLineInlineElementsWithCommentGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingComment, 0);
				case 1: return this.GetRed(ref this.inlineTextElement, 1);
				case 2: return this.GetRed(ref this.trailingComment, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingComment;
				case 1: return this.inlineTextElement;
				case 2: return this.trailingComment;
				default: return null;
	        }
	    }
	
	    public TextLineInlineElementsWithCommentSyntax WithLeadingComment(HtmlCommentListSyntax leadingComment)
		{
			return this.Update(LeadingComment, this.InlineTextElement, this.TrailingComment, this.CRLF);
		}
	
	    public TextLineInlineElementsWithCommentSyntax WithInlineTextElement(SyntaxNodeList<InlineTextElementSyntax> inlineTextElement)
		{
			return this.Update(this.LeadingComment, InlineTextElement, this.TrailingComment, this.CRLF);
		}
	
	    public TextLineInlineElementsWithCommentSyntax AddInlineTextElement(params InlineTextElementSyntax[] inlineTextElement)
		{
			return this.WithInlineTextElement(this.InlineTextElement.AddRange(inlineTextElement));
		}
	
	    public TextLineInlineElementsWithCommentSyntax WithTrailingComment(HtmlCommentListSyntax trailingComment)
		{
			return this.Update(this.LeadingComment, this.InlineTextElement, TrailingComment, this.CRLF);
		}
	
	    public TextLineInlineElementsWithCommentSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.LeadingComment, this.InlineTextElement, this.TrailingComment, CRLF);
		}
	
	    public TextLineInlineElementsWithCommentSyntax Update(HtmlCommentListSyntax leadingComment, SyntaxNodeList<InlineTextElementSyntax> inlineTextElement, HtmlCommentListSyntax trailingComment, SyntaxToken crlf)
	    {
	        if (this.LeadingComment != leadingComment ||
				this.InlineTextElement.Node != inlineTextElement.Node ||
				this.TrailingComment != trailingComment ||
				this.CRLF != crlf)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextLineInlineElementsWithComment(leadingComment, inlineTextElement, trailingComment, crlf);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextLineInlineElementsWithCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTextLineInlineElementsWithComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTextLineInlineElementsWithComment(this);
	    }
	}
	
	public sealed class TextLineCommentSyntax : TextLineSyntax
	{
	    private HtmlCommentListSyntax htmlCommentList;
	
	    public TextLineCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TextLineCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlCommentListSyntax HtmlCommentList 
		{ 
			get { return this.GetRed(ref this.htmlCommentList, 0); } 
		}
	    public SyntaxToken CRLF 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.TextLineCommentGreen)this.Green;
				var greenToken = green.CRLF;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.htmlCommentList, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.htmlCommentList;
				default: return null;
	        }
	    }
	
	    public TextLineCommentSyntax WithHtmlCommentList(HtmlCommentListSyntax htmlCommentList)
		{
			return this.Update(HtmlCommentList, this.CRLF);
		}
	
	    public TextLineCommentSyntax WithCRLF(SyntaxToken crlf)
		{
			return this.Update(this.HtmlCommentList, CRLF);
		}
	
	    public TextLineCommentSyntax Update(HtmlCommentListSyntax htmlCommentList, SyntaxToken crlf)
	    {
	        if (this.HtmlCommentList != htmlCommentList ||
				this.CRLF != crlf)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextLineComment(htmlCommentList, crlf);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextLineCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTextLineComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTextLineComment(this);
	    }
	}
	
	public sealed class TextElementsSyntax : MediaWikiSyntaxNode
	{
	    private WikiFormatSyntax wikiFormat;
	    private WikiLinkSyntax wikiLink;
	    private WikiTemplateSyntax wikiTemplate;
	    private WikiTemplateParamSyntax wikiTemplateParam;
	    private NoWikiSyntax noWiki;
	    private HtmlReferenceSyntax htmlReference;
	    private HtmlStyleSyntax htmlStyle;
	    private HtmlScriptSyntax htmlScript;
	    private HtmlTagSyntax htmlTag;
	
	    public TextElementsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TextElementsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public WikiFormatSyntax WikiFormat 
		{ 
			get { return this.GetRed(ref this.wikiFormat, 0); } 
		}
	    public WikiLinkSyntax WikiLink 
		{ 
			get { return this.GetRed(ref this.wikiLink, 1); } 
		}
	    public WikiTemplateSyntax WikiTemplate 
		{ 
			get { return this.GetRed(ref this.wikiTemplate, 2); } 
		}
	    public WikiTemplateParamSyntax WikiTemplateParam 
		{ 
			get { return this.GetRed(ref this.wikiTemplateParam, 3); } 
		}
	    public NoWikiSyntax NoWiki 
		{ 
			get { return this.GetRed(ref this.noWiki, 4); } 
		}
	    public HtmlReferenceSyntax HtmlReference 
		{ 
			get { return this.GetRed(ref this.htmlReference, 5); } 
		}
	    public HtmlStyleSyntax HtmlStyle 
		{ 
			get { return this.GetRed(ref this.htmlStyle, 6); } 
		}
	    public HtmlScriptSyntax HtmlScript 
		{ 
			get { return this.GetRed(ref this.htmlScript, 7); } 
		}
	    public HtmlTagSyntax HtmlTag 
		{ 
			get { return this.GetRed(ref this.htmlTag, 8); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.wikiFormat, 0);
				case 1: return this.GetRed(ref this.wikiLink, 1);
				case 2: return this.GetRed(ref this.wikiTemplate, 2);
				case 3: return this.GetRed(ref this.wikiTemplateParam, 3);
				case 4: return this.GetRed(ref this.noWiki, 4);
				case 5: return this.GetRed(ref this.htmlReference, 5);
				case 6: return this.GetRed(ref this.htmlStyle, 6);
				case 7: return this.GetRed(ref this.htmlScript, 7);
				case 8: return this.GetRed(ref this.htmlTag, 8);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.wikiFormat;
				case 1: return this.wikiLink;
				case 2: return this.wikiTemplate;
				case 3: return this.wikiTemplateParam;
				case 4: return this.noWiki;
				case 5: return this.htmlReference;
				case 6: return this.htmlStyle;
				case 7: return this.htmlScript;
				case 8: return this.htmlTag;
				default: return null;
	        }
	    }
	
	    public TextElementsSyntax WithWikiFormat(WikiFormatSyntax wikiFormat)
		{
			return this.Update(wikiFormat);
		}
	
	    public TextElementsSyntax WithWikiLink(WikiLinkSyntax wikiLink)
		{
			return this.Update(wikiLink);
		}
	
	    public TextElementsSyntax WithWikiTemplate(WikiTemplateSyntax wikiTemplate)
		{
			return this.Update(wikiTemplate);
		}
	
	    public TextElementsSyntax WithWikiTemplateParam(WikiTemplateParamSyntax wikiTemplateParam)
		{
			return this.Update(wikiTemplateParam);
		}
	
	    public TextElementsSyntax WithNoWiki(NoWikiSyntax noWiki)
		{
			return this.Update(noWiki);
		}
	
	    public TextElementsSyntax WithHtmlReference(HtmlReferenceSyntax htmlReference)
		{
			return this.Update(htmlReference);
		}
	
	    public TextElementsSyntax WithHtmlStyle(HtmlStyleSyntax htmlStyle)
		{
			return this.Update(htmlStyle);
		}
	
	    public TextElementsSyntax WithHtmlScript(HtmlScriptSyntax htmlScript)
		{
			return this.Update(htmlScript);
		}
	
	    public TextElementsSyntax WithHtmlTag(HtmlTagSyntax htmlTag)
		{
			return this.Update(htmlTag);
		}
	
	    public TextElementsSyntax Update(WikiFormatSyntax wikiFormat)
	    {
	        if (this.WikiFormat != wikiFormat)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(wikiFormat);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsSyntax Update(WikiLinkSyntax wikiLink)
	    {
	        if (this.WikiLink != wikiLink)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(wikiLink);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsSyntax Update(WikiTemplateSyntax wikiTemplate)
	    {
	        if (this.WikiTemplate != wikiTemplate)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(wikiTemplate);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsSyntax Update(WikiTemplateParamSyntax wikiTemplateParam)
	    {
	        if (this.WikiTemplateParam != wikiTemplateParam)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(wikiTemplateParam);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsSyntax Update(NoWikiSyntax noWiki)
	    {
	        if (this.NoWiki != noWiki)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(noWiki);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsSyntax Update(HtmlReferenceSyntax htmlReference)
	    {
	        if (this.HtmlReference != htmlReference)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(htmlReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsSyntax Update(HtmlStyleSyntax htmlStyle)
	    {
	        if (this.HtmlStyle != htmlStyle)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(htmlStyle);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsSyntax Update(HtmlScriptSyntax htmlScript)
	    {
	        if (this.HtmlScript != htmlScript)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(htmlScript);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsSyntax Update(HtmlTagSyntax htmlTag)
	    {
	        if (this.HtmlTag != htmlTag)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.TextElements(htmlTag);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTextElements(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitTextElements(this);
	    }
	}
	
	public sealed class InlineTextSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList inlineTextElementWithComment;
	    private HtmlCommentListSyntax trailingComment;
	
	    public InlineTextSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InlineTextSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<InlineTextElementWithCommentSyntax> InlineTextElementWithComment 
		{ 
			get
			{
				var red = this.GetRed(ref this.inlineTextElementWithComment, 0);
				if (red != null)
				{
					return new SyntaxNodeList<InlineTextElementWithCommentSyntax>(red);
				}
				return null;
			} 
		}
	    public HtmlCommentListSyntax TrailingComment 
		{ 
			get { return this.GetRed(ref this.trailingComment, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.inlineTextElementWithComment, 0);
				case 1: return this.GetRed(ref this.trailingComment, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.inlineTextElementWithComment;
				case 1: return this.trailingComment;
				default: return null;
	        }
	    }
	
	    public InlineTextSyntax WithInlineTextElementWithComment(SyntaxNodeList<InlineTextElementWithCommentSyntax> inlineTextElementWithComment)
		{
			return this.Update(InlineTextElementWithComment, this.TrailingComment);
		}
	
	    public InlineTextSyntax AddInlineTextElementWithComment(params InlineTextElementWithCommentSyntax[] inlineTextElementWithComment)
		{
			return this.WithInlineTextElementWithComment(this.InlineTextElementWithComment.AddRange(inlineTextElementWithComment));
		}
	
	    public InlineTextSyntax WithTrailingComment(HtmlCommentListSyntax trailingComment)
		{
			return this.Update(this.InlineTextElementWithComment, TrailingComment);
		}
	
	    public InlineTextSyntax Update(SyntaxNodeList<InlineTextElementWithCommentSyntax> inlineTextElementWithComment, HtmlCommentListSyntax trailingComment)
	    {
	        if (this.InlineTextElementWithComment.Node != inlineTextElementWithComment.Node ||
				this.TrailingComment != trailingComment)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.InlineText(inlineTextElementWithComment, trailingComment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInlineText(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitInlineText(this);
	    }
	}
	
	public sealed class InlineTextElementWithCommentSyntax : MediaWikiSyntaxNode
	{
	    private HtmlCommentListSyntax leadingComment;
	    private InlineTextElementSyntax inlineTextElement;
	
	    public InlineTextElementWithCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InlineTextElementWithCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlCommentListSyntax LeadingComment 
		{ 
			get { return this.GetRed(ref this.leadingComment, 0); } 
		}
	    public InlineTextElementSyntax InlineTextElement 
		{ 
			get { return this.GetRed(ref this.inlineTextElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingComment, 0);
				case 1: return this.GetRed(ref this.inlineTextElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingComment;
				case 1: return this.inlineTextElement;
				default: return null;
	        }
	    }
	
	    public InlineTextElementWithCommentSyntax WithLeadingComment(HtmlCommentListSyntax leadingComment)
		{
			return this.Update(LeadingComment, this.InlineTextElement);
		}
	
	    public InlineTextElementWithCommentSyntax WithInlineTextElement(InlineTextElementSyntax inlineTextElement)
		{
			return this.Update(this.LeadingComment, InlineTextElement);
		}
	
	    public InlineTextElementWithCommentSyntax Update(HtmlCommentListSyntax leadingComment, InlineTextElementSyntax inlineTextElement)
	    {
	        if (this.LeadingComment != leadingComment ||
				this.InlineTextElement != inlineTextElement)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.InlineTextElementWithComment(leadingComment, inlineTextElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextElementWithCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInlineTextElementWithComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitInlineTextElementWithComment(this);
	    }
	}
	
	public sealed class InlineTextElementSyntax : MediaWikiSyntaxNode
	{
	    private TextElementsSyntax textElements;
	    private InlineTextElementsSyntax inlineTextElements;
	
	    public InlineTextElementSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InlineTextElementSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TextElementsSyntax TextElements 
		{ 
			get { return this.GetRed(ref this.textElements, 0); } 
		}
	    public InlineTextElementsSyntax InlineTextElements 
		{ 
			get { return this.GetRed(ref this.inlineTextElements, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.textElements, 0);
				case 1: return this.GetRed(ref this.inlineTextElements, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.textElements;
				case 1: return this.inlineTextElements;
				default: return null;
	        }
	    }
	
	    public InlineTextElementSyntax WithTextElements(TextElementsSyntax textElements)
		{
			return this.Update(textElements);
		}
	
	    public InlineTextElementSyntax WithInlineTextElements(InlineTextElementsSyntax inlineTextElements)
		{
			return this.Update(inlineTextElements);
		}
	
	    public InlineTextElementSyntax Update(TextElementsSyntax textElements)
	    {
	        if (this.TextElements != textElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.InlineTextElement(textElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public InlineTextElementSyntax Update(InlineTextElementsSyntax inlineTextElements)
	    {
	        if (this.InlineTextElements != inlineTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.InlineTextElement(inlineTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInlineTextElement(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitInlineTextElement(this);
	    }
	}
	
	public sealed class InlineTextElementsSyntax : MediaWikiSyntaxNode
	{
	
	    public InlineTextElementsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InlineTextElementsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken InlineTextElements 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.InlineTextElementsGreen)this.Green;
				var greenToken = green.InlineTextElements;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public InlineTextElementsSyntax WithInlineTextElements(SyntaxToken inlineTextElements)
		{
			return this.Update(InlineTextElements);
		}
	
	    public InlineTextElementsSyntax Update(SyntaxToken inlineTextElements)
	    {
	        if (this.InlineTextElements != inlineTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.InlineTextElements(inlineTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInlineTextElements(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitInlineTextElements(this);
	    }
	}
	
	public sealed class DefinitionTextSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList definitionTextElementWithComment;
	    private HtmlCommentListSyntax trailingComment;
	
	    public DefinitionTextSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefinitionTextSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<DefinitionTextElementWithCommentSyntax> DefinitionTextElementWithComment 
		{ 
			get
			{
				var red = this.GetRed(ref this.definitionTextElementWithComment, 0);
				if (red != null)
				{
					return new SyntaxNodeList<DefinitionTextElementWithCommentSyntax>(red);
				}
				return null;
			} 
		}
	    public HtmlCommentListSyntax TrailingComment 
		{ 
			get { return this.GetRed(ref this.trailingComment, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.definitionTextElementWithComment, 0);
				case 1: return this.GetRed(ref this.trailingComment, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.definitionTextElementWithComment;
				case 1: return this.trailingComment;
				default: return null;
	        }
	    }
	
	    public DefinitionTextSyntax WithDefinitionTextElementWithComment(SyntaxNodeList<DefinitionTextElementWithCommentSyntax> definitionTextElementWithComment)
		{
			return this.Update(DefinitionTextElementWithComment, this.TrailingComment);
		}
	
	    public DefinitionTextSyntax AddDefinitionTextElementWithComment(params DefinitionTextElementWithCommentSyntax[] definitionTextElementWithComment)
		{
			return this.WithDefinitionTextElementWithComment(this.DefinitionTextElementWithComment.AddRange(definitionTextElementWithComment));
		}
	
	    public DefinitionTextSyntax WithTrailingComment(HtmlCommentListSyntax trailingComment)
		{
			return this.Update(this.DefinitionTextElementWithComment, TrailingComment);
		}
	
	    public DefinitionTextSyntax Update(SyntaxNodeList<DefinitionTextElementWithCommentSyntax> definitionTextElementWithComment, HtmlCommentListSyntax trailingComment)
	    {
	        if (this.DefinitionTextElementWithComment.Node != definitionTextElementWithComment.Node ||
				this.TrailingComment != trailingComment)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.DefinitionText(definitionTextElementWithComment, trailingComment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefinitionText(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitDefinitionText(this);
	    }
	}
	
	public sealed class DefinitionTextElementWithCommentSyntax : MediaWikiSyntaxNode
	{
	    private HtmlCommentListSyntax leadingComment;
	    private DefinitionTextElementSyntax definitionTextElement;
	
	    public DefinitionTextElementWithCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefinitionTextElementWithCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlCommentListSyntax LeadingComment 
		{ 
			get { return this.GetRed(ref this.leadingComment, 0); } 
		}
	    public DefinitionTextElementSyntax DefinitionTextElement 
		{ 
			get { return this.GetRed(ref this.definitionTextElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingComment, 0);
				case 1: return this.GetRed(ref this.definitionTextElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingComment;
				case 1: return this.definitionTextElement;
				default: return null;
	        }
	    }
	
	    public DefinitionTextElementWithCommentSyntax WithLeadingComment(HtmlCommentListSyntax leadingComment)
		{
			return this.Update(LeadingComment, this.DefinitionTextElement);
		}
	
	    public DefinitionTextElementWithCommentSyntax WithDefinitionTextElement(DefinitionTextElementSyntax definitionTextElement)
		{
			return this.Update(this.LeadingComment, DefinitionTextElement);
		}
	
	    public DefinitionTextElementWithCommentSyntax Update(HtmlCommentListSyntax leadingComment, DefinitionTextElementSyntax definitionTextElement)
	    {
	        if (this.LeadingComment != leadingComment ||
				this.DefinitionTextElement != definitionTextElement)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.DefinitionTextElementWithComment(leadingComment, definitionTextElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextElementWithCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefinitionTextElementWithComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitDefinitionTextElementWithComment(this);
	    }
	}
	
	public sealed class DefinitionTextElementSyntax : MediaWikiSyntaxNode
	{
	    private TextElementsSyntax textElements;
	    private DefinitionTextElementsSyntax definitionTextElements;
	
	    public DefinitionTextElementSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefinitionTextElementSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TextElementsSyntax TextElements 
		{ 
			get { return this.GetRed(ref this.textElements, 0); } 
		}
	    public DefinitionTextElementsSyntax DefinitionTextElements 
		{ 
			get { return this.GetRed(ref this.definitionTextElements, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.textElements, 0);
				case 1: return this.GetRed(ref this.definitionTextElements, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.textElements;
				case 1: return this.definitionTextElements;
				default: return null;
	        }
	    }
	
	    public DefinitionTextElementSyntax WithTextElements(TextElementsSyntax textElements)
		{
			return this.Update(textElements);
		}
	
	    public DefinitionTextElementSyntax WithDefinitionTextElements(DefinitionTextElementsSyntax definitionTextElements)
		{
			return this.Update(definitionTextElements);
		}
	
	    public DefinitionTextElementSyntax Update(TextElementsSyntax textElements)
	    {
	        if (this.TextElements != textElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.DefinitionTextElement(textElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DefinitionTextElementSyntax Update(DefinitionTextElementsSyntax definitionTextElements)
	    {
	        if (this.DefinitionTextElements != definitionTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.DefinitionTextElement(definitionTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefinitionTextElement(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitDefinitionTextElement(this);
	    }
	}
	
	public sealed class DefinitionTextElementsSyntax : MediaWikiSyntaxNode
	{
	
	    public DefinitionTextElementsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefinitionTextElementsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken DefinitionTextElements 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.DefinitionTextElementsGreen)this.Green;
				var greenToken = green.DefinitionTextElements;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public DefinitionTextElementsSyntax WithDefinitionTextElements(SyntaxToken definitionTextElements)
		{
			return this.Update(DefinitionTextElements);
		}
	
	    public DefinitionTextElementsSyntax Update(SyntaxToken definitionTextElements)
	    {
	        if (this.DefinitionTextElements != definitionTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.DefinitionTextElements(definitionTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefinitionTextElements(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitDefinitionTextElements(this);
	    }
	}
	
	public sealed class HeadingTextSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList headingTextWithComment;
	    private HtmlCommentListSyntax trailingComment;
	
	    public HeadingTextSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HeadingTextSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<HeadingTextWithCommentSyntax> HeadingTextWithComment 
		{ 
			get
			{
				var red = this.GetRed(ref this.headingTextWithComment, 0);
				if (red != null)
				{
					return new SyntaxNodeList<HeadingTextWithCommentSyntax>(red);
				}
				return null;
			} 
		}
	    public HtmlCommentListSyntax TrailingComment 
		{ 
			get { return this.GetRed(ref this.trailingComment, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.headingTextWithComment, 0);
				case 1: return this.GetRed(ref this.trailingComment, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.headingTextWithComment;
				case 1: return this.trailingComment;
				default: return null;
	        }
	    }
	
	    public HeadingTextSyntax WithHeadingTextWithComment(SyntaxNodeList<HeadingTextWithCommentSyntax> headingTextWithComment)
		{
			return this.Update(HeadingTextWithComment, this.TrailingComment);
		}
	
	    public HeadingTextSyntax AddHeadingTextWithComment(params HeadingTextWithCommentSyntax[] headingTextWithComment)
		{
			return this.WithHeadingTextWithComment(this.HeadingTextWithComment.AddRange(headingTextWithComment));
		}
	
	    public HeadingTextSyntax WithTrailingComment(HtmlCommentListSyntax trailingComment)
		{
			return this.Update(this.HeadingTextWithComment, TrailingComment);
		}
	
	    public HeadingTextSyntax Update(SyntaxNodeList<HeadingTextWithCommentSyntax> headingTextWithComment, HtmlCommentListSyntax trailingComment)
	    {
	        if (this.HeadingTextWithComment.Node != headingTextWithComment.Node ||
				this.TrailingComment != trailingComment)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HeadingText(headingTextWithComment, trailingComment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHeadingText(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHeadingText(this);
	    }
	}
	
	public sealed class HeadingTextWithCommentSyntax : MediaWikiSyntaxNode
	{
	    private HtmlCommentListSyntax leadingComment;
	    private HeadingTextElementSyntax headingTextElement;
	
	    public HeadingTextWithCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HeadingTextWithCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlCommentListSyntax LeadingComment 
		{ 
			get { return this.GetRed(ref this.leadingComment, 0); } 
		}
	    public HeadingTextElementSyntax HeadingTextElement 
		{ 
			get { return this.GetRed(ref this.headingTextElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingComment, 0);
				case 1: return this.GetRed(ref this.headingTextElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingComment;
				case 1: return this.headingTextElement;
				default: return null;
	        }
	    }
	
	    public HeadingTextWithCommentSyntax WithLeadingComment(HtmlCommentListSyntax leadingComment)
		{
			return this.Update(LeadingComment, this.HeadingTextElement);
		}
	
	    public HeadingTextWithCommentSyntax WithHeadingTextElement(HeadingTextElementSyntax headingTextElement)
		{
			return this.Update(this.LeadingComment, HeadingTextElement);
		}
	
	    public HeadingTextWithCommentSyntax Update(HtmlCommentListSyntax leadingComment, HeadingTextElementSyntax headingTextElement)
	    {
	        if (this.LeadingComment != leadingComment ||
				this.HeadingTextElement != headingTextElement)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HeadingTextWithComment(leadingComment, headingTextElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextWithCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHeadingTextWithComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHeadingTextWithComment(this);
	    }
	}
	
	public sealed class HeadingTextElementSyntax : MediaWikiSyntaxNode
	{
	    private TextElementsSyntax textElements;
	    private HeadingTextElementsSyntax headingTextElements;
	
	    public HeadingTextElementSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HeadingTextElementSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TextElementsSyntax TextElements 
		{ 
			get { return this.GetRed(ref this.textElements, 0); } 
		}
	    public HeadingTextElementsSyntax HeadingTextElements 
		{ 
			get { return this.GetRed(ref this.headingTextElements, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.textElements, 0);
				case 1: return this.GetRed(ref this.headingTextElements, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.textElements;
				case 1: return this.headingTextElements;
				default: return null;
	        }
	    }
	
	    public HeadingTextElementSyntax WithTextElements(TextElementsSyntax textElements)
		{
			return this.Update(textElements);
		}
	
	    public HeadingTextElementSyntax WithHeadingTextElements(HeadingTextElementsSyntax headingTextElements)
		{
			return this.Update(headingTextElements);
		}
	
	    public HeadingTextElementSyntax Update(TextElementsSyntax textElements)
	    {
	        if (this.TextElements != textElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HeadingTextElement(textElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public HeadingTextElementSyntax Update(HeadingTextElementsSyntax headingTextElements)
	    {
	        if (this.HeadingTextElements != headingTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HeadingTextElement(headingTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHeadingTextElement(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHeadingTextElement(this);
	    }
	}
	
	public sealed class HeadingTextElementsSyntax : MediaWikiSyntaxNode
	{
	
	    public HeadingTextElementsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HeadingTextElementsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken HeadingTextElements 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HeadingTextElementsGreen)this.Green;
				var greenToken = green.HeadingTextElements;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HeadingTextElementsSyntax WithHeadingTextElements(SyntaxToken headingTextElements)
		{
			return this.Update(HeadingTextElements);
		}
	
	    public HeadingTextElementsSyntax Update(SyntaxToken headingTextElements)
	    {
	        if (this.HeadingTextElements != headingTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HeadingTextElements(headingTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHeadingTextElements(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHeadingTextElements(this);
	    }
	}
	
	public sealed class CellTextSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList cellTextElementWithComment;
	    private HtmlCommentListSyntax trailingComment;
	
	    public CellTextSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CellTextSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<CellTextElementWithCommentSyntax> CellTextElementWithComment 
		{ 
			get
			{
				var red = this.GetRed(ref this.cellTextElementWithComment, 0);
				if (red != null)
				{
					return new SyntaxNodeList<CellTextElementWithCommentSyntax>(red);
				}
				return null;
			} 
		}
	    public HtmlCommentListSyntax TrailingComment 
		{ 
			get { return this.GetRed(ref this.trailingComment, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.cellTextElementWithComment, 0);
				case 1: return this.GetRed(ref this.trailingComment, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.cellTextElementWithComment;
				case 1: return this.trailingComment;
				default: return null;
	        }
	    }
	
	    public CellTextSyntax WithCellTextElementWithComment(SyntaxNodeList<CellTextElementWithCommentSyntax> cellTextElementWithComment)
		{
			return this.Update(CellTextElementWithComment, this.TrailingComment);
		}
	
	    public CellTextSyntax AddCellTextElementWithComment(params CellTextElementWithCommentSyntax[] cellTextElementWithComment)
		{
			return this.WithCellTextElementWithComment(this.CellTextElementWithComment.AddRange(cellTextElementWithComment));
		}
	
	    public CellTextSyntax WithTrailingComment(HtmlCommentListSyntax trailingComment)
		{
			return this.Update(this.CellTextElementWithComment, TrailingComment);
		}
	
	    public CellTextSyntax Update(SyntaxNodeList<CellTextElementWithCommentSyntax> cellTextElementWithComment, HtmlCommentListSyntax trailingComment)
	    {
	        if (this.CellTextElementWithComment.Node != cellTextElementWithComment.Node ||
				this.TrailingComment != trailingComment)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.CellText(cellTextElementWithComment, trailingComment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCellText(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitCellText(this);
	    }
	}
	
	public sealed class CellTextElementWithCommentSyntax : MediaWikiSyntaxNode
	{
	    private HtmlCommentListSyntax leadingComment;
	    private CellTextElementSyntax cellTextElement;
	
	    public CellTextElementWithCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CellTextElementWithCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlCommentListSyntax LeadingComment 
		{ 
			get { return this.GetRed(ref this.leadingComment, 0); } 
		}
	    public CellTextElementSyntax CellTextElement 
		{ 
			get { return this.GetRed(ref this.cellTextElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingComment, 0);
				case 1: return this.GetRed(ref this.cellTextElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingComment;
				case 1: return this.cellTextElement;
				default: return null;
	        }
	    }
	
	    public CellTextElementWithCommentSyntax WithLeadingComment(HtmlCommentListSyntax leadingComment)
		{
			return this.Update(LeadingComment, this.CellTextElement);
		}
	
	    public CellTextElementWithCommentSyntax WithCellTextElement(CellTextElementSyntax cellTextElement)
		{
			return this.Update(this.LeadingComment, CellTextElement);
		}
	
	    public CellTextElementWithCommentSyntax Update(HtmlCommentListSyntax leadingComment, CellTextElementSyntax cellTextElement)
	    {
	        if (this.LeadingComment != leadingComment ||
				this.CellTextElement != cellTextElement)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.CellTextElementWithComment(leadingComment, cellTextElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextElementWithCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCellTextElementWithComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitCellTextElementWithComment(this);
	    }
	}
	
	public sealed class CellTextElementSyntax : MediaWikiSyntaxNode
	{
	    private TextElementsSyntax textElements;
	    private CellTextElementsSyntax cellTextElements;
	
	    public CellTextElementSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CellTextElementSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TextElementsSyntax TextElements 
		{ 
			get { return this.GetRed(ref this.textElements, 0); } 
		}
	    public CellTextElementsSyntax CellTextElements 
		{ 
			get { return this.GetRed(ref this.cellTextElements, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.textElements, 0);
				case 1: return this.GetRed(ref this.cellTextElements, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.textElements;
				case 1: return this.cellTextElements;
				default: return null;
	        }
	    }
	
	    public CellTextElementSyntax WithTextElements(TextElementsSyntax textElements)
		{
			return this.Update(textElements);
		}
	
	    public CellTextElementSyntax WithCellTextElements(CellTextElementsSyntax cellTextElements)
		{
			return this.Update(cellTextElements);
		}
	
	    public CellTextElementSyntax Update(TextElementsSyntax textElements)
	    {
	        if (this.TextElements != textElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.CellTextElement(textElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public CellTextElementSyntax Update(CellTextElementsSyntax cellTextElements)
	    {
	        if (this.CellTextElements != cellTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.CellTextElement(cellTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCellTextElement(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitCellTextElement(this);
	    }
	}
	
	public sealed class CellTextElementsSyntax : MediaWikiSyntaxNode
	{
	
	    public CellTextElementsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CellTextElementsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken CellTextElements 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.CellTextElementsGreen)this.Green;
				var greenToken = green.CellTextElements;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public CellTextElementsSyntax WithCellTextElements(SyntaxToken cellTextElements)
		{
			return this.Update(CellTextElements);
		}
	
	    public CellTextElementsSyntax Update(SyntaxToken cellTextElements)
	    {
	        if (this.CellTextElements != cellTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.CellTextElements(cellTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCellTextElements(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitCellTextElements(this);
	    }
	}
	
	public sealed class LinkTextSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList linkTextWithComment;
	    private HtmlCommentListSyntax trailingComment;
	
	    public LinkTextSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LinkTextSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<LinkTextWithCommentSyntax> LinkTextWithComment 
		{ 
			get
			{
				var red = this.GetRed(ref this.linkTextWithComment, 0);
				if (red != null)
				{
					return new SyntaxNodeList<LinkTextWithCommentSyntax>(red);
				}
				return null;
			} 
		}
	    public HtmlCommentListSyntax TrailingComment 
		{ 
			get { return this.GetRed(ref this.trailingComment, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.linkTextWithComment, 0);
				case 1: return this.GetRed(ref this.trailingComment, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.linkTextWithComment;
				case 1: return this.trailingComment;
				default: return null;
	        }
	    }
	
	    public LinkTextSyntax WithLinkTextWithComment(SyntaxNodeList<LinkTextWithCommentSyntax> linkTextWithComment)
		{
			return this.Update(LinkTextWithComment, this.TrailingComment);
		}
	
	    public LinkTextSyntax AddLinkTextWithComment(params LinkTextWithCommentSyntax[] linkTextWithComment)
		{
			return this.WithLinkTextWithComment(this.LinkTextWithComment.AddRange(linkTextWithComment));
		}
	
	    public LinkTextSyntax WithTrailingComment(HtmlCommentListSyntax trailingComment)
		{
			return this.Update(this.LinkTextWithComment, TrailingComment);
		}
	
	    public LinkTextSyntax Update(SyntaxNodeList<LinkTextWithCommentSyntax> linkTextWithComment, HtmlCommentListSyntax trailingComment)
	    {
	        if (this.LinkTextWithComment.Node != linkTextWithComment.Node ||
				this.TrailingComment != trailingComment)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.LinkText(linkTextWithComment, trailingComment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLinkText(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitLinkText(this);
	    }
	}
	
	public sealed class LinkTextWithCommentSyntax : MediaWikiSyntaxNode
	{
	    private HtmlCommentListSyntax leadingComment;
	    private LinkTextElementSyntax linkTextElement;
	
	    public LinkTextWithCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LinkTextWithCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlCommentListSyntax LeadingComment 
		{ 
			get { return this.GetRed(ref this.leadingComment, 0); } 
		}
	    public LinkTextElementSyntax LinkTextElement 
		{ 
			get { return this.GetRed(ref this.linkTextElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingComment, 0);
				case 1: return this.GetRed(ref this.linkTextElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingComment;
				case 1: return this.linkTextElement;
				default: return null;
	        }
	    }
	
	    public LinkTextWithCommentSyntax WithLeadingComment(HtmlCommentListSyntax leadingComment)
		{
			return this.Update(LeadingComment, this.LinkTextElement);
		}
	
	    public LinkTextWithCommentSyntax WithLinkTextElement(LinkTextElementSyntax linkTextElement)
		{
			return this.Update(this.LeadingComment, LinkTextElement);
		}
	
	    public LinkTextWithCommentSyntax Update(HtmlCommentListSyntax leadingComment, LinkTextElementSyntax linkTextElement)
	    {
	        if (this.LeadingComment != leadingComment ||
				this.LinkTextElement != linkTextElement)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.LinkTextWithComment(leadingComment, linkTextElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextWithCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLinkTextWithComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitLinkTextWithComment(this);
	    }
	}
	
	public sealed class LinkTextElementSyntax : MediaWikiSyntaxNode
	{
	    private TextElementsSyntax textElements;
	    private LinkTextElementsSyntax linkTextElements;
	
	    public LinkTextElementSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LinkTextElementSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TextElementsSyntax TextElements 
		{ 
			get { return this.GetRed(ref this.textElements, 0); } 
		}
	    public LinkTextElementsSyntax LinkTextElements 
		{ 
			get { return this.GetRed(ref this.linkTextElements, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.textElements, 0);
				case 1: return this.GetRed(ref this.linkTextElements, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.textElements;
				case 1: return this.linkTextElements;
				default: return null;
	        }
	    }
	
	    public LinkTextElementSyntax WithTextElements(TextElementsSyntax textElements)
		{
			return this.Update(textElements);
		}
	
	    public LinkTextElementSyntax WithLinkTextElements(LinkTextElementsSyntax linkTextElements)
		{
			return this.Update(linkTextElements);
		}
	
	    public LinkTextElementSyntax Update(TextElementsSyntax textElements)
	    {
	        if (this.TextElements != textElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.LinkTextElement(textElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LinkTextElementSyntax Update(LinkTextElementsSyntax linkTextElements)
	    {
	        if (this.LinkTextElements != linkTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.LinkTextElement(linkTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLinkTextElement(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitLinkTextElement(this);
	    }
	}
	
	public sealed class LinkTextElementsSyntax : MediaWikiSyntaxNode
	{
	
	    public LinkTextElementsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LinkTextElementsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LinkTextElements 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.LinkTextElementsGreen)this.Green;
				var greenToken = green.LinkTextElements;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public LinkTextElementsSyntax WithLinkTextElements(SyntaxToken linkTextElements)
		{
			return this.Update(LinkTextElements);
		}
	
	    public LinkTextElementsSyntax Update(SyntaxToken linkTextElements)
	    {
	        if (this.LinkTextElements != linkTextElements)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.LinkTextElements(linkTextElements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLinkTextElements(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitLinkTextElements(this);
	    }
	}
	
	public sealed class WikiFormatSyntax : MediaWikiSyntaxNode
	{
	
	    public WikiFormatSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WikiFormatSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TFormat 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiFormatGreen)this.Green;
				var greenToken = green.TFormat;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public WikiFormatSyntax WithTFormat(SyntaxToken tFormat)
		{
			return this.Update(TFormat);
		}
	
	    public WikiFormatSyntax Update(SyntaxToken tFormat)
	    {
	        if (this.TFormat != tFormat)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiFormat(tFormat);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiFormatSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWikiFormat(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWikiFormat(this);
	    }
	}
	
	public sealed class WikiLinkSyntax : MediaWikiSyntaxNode
	{
	    private WikiInternalLinkSyntax wikiInternalLink;
	    private WikiExternalLinkSyntax wikiExternalLink;
	
	    public WikiLinkSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WikiLinkSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public WikiInternalLinkSyntax WikiInternalLink 
		{ 
			get { return this.GetRed(ref this.wikiInternalLink, 0); } 
		}
	    public WikiExternalLinkSyntax WikiExternalLink 
		{ 
			get { return this.GetRed(ref this.wikiExternalLink, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.wikiInternalLink, 0);
				case 1: return this.GetRed(ref this.wikiExternalLink, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.wikiInternalLink;
				case 1: return this.wikiExternalLink;
				default: return null;
	        }
	    }
	
	    public WikiLinkSyntax WithWikiInternalLink(WikiInternalLinkSyntax wikiInternalLink)
		{
			return this.Update(wikiInternalLink);
		}
	
	    public WikiLinkSyntax WithWikiExternalLink(WikiExternalLinkSyntax wikiExternalLink)
		{
			return this.Update(wikiExternalLink);
		}
	
	    public WikiLinkSyntax Update(WikiInternalLinkSyntax wikiInternalLink)
	    {
	        if (this.WikiInternalLink != wikiInternalLink)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiLink(wikiInternalLink);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiLinkSyntax)newNode;
	        }
	        return this;
	    }
	
	    public WikiLinkSyntax Update(WikiExternalLinkSyntax wikiExternalLink)
	    {
	        if (this.WikiExternalLink != wikiExternalLink)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiLink(wikiExternalLink);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiLinkSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWikiLink(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWikiLink(this);
	    }
	}
	
	public sealed class WikiInternalLinkSyntax : MediaWikiSyntaxNode
	{
	    private LinkTextSyntax linkText;
	    private SyntaxNodeList linkTextPart;
	
	    public WikiInternalLinkSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WikiInternalLinkSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TLinkStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiInternalLinkGreen)this.Green;
				var greenToken = green.TLinkStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public LinkTextSyntax LinkText 
		{ 
			get { return this.GetRed(ref this.linkText, 1); } 
		}
	    public SyntaxNodeList<LinkTextPartSyntax> LinkTextPart 
		{ 
			get
			{
				var red = this.GetRed(ref this.linkTextPart, 2);
				if (red != null)
				{
					return new SyntaxNodeList<LinkTextPartSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TLinkEnd 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiInternalLinkGreen)this.Green;
				var greenToken = green.TLinkEnd;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.linkText, 1);
				case 2: return this.GetRed(ref this.linkTextPart, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.linkText;
				case 2: return this.linkTextPart;
				default: return null;
	        }
	    }
	
	    public WikiInternalLinkSyntax WithTLinkStart(SyntaxToken tLinkStart)
		{
			return this.Update(TLinkStart, this.LinkText, this.LinkTextPart, this.TLinkEnd);
		}
	
	    public WikiInternalLinkSyntax WithLinkText(LinkTextSyntax linkText)
		{
			return this.Update(this.TLinkStart, LinkText, this.LinkTextPart, this.TLinkEnd);
		}
	
	    public WikiInternalLinkSyntax WithLinkTextPart(SyntaxNodeList<LinkTextPartSyntax> linkTextPart)
		{
			return this.Update(this.TLinkStart, this.LinkText, LinkTextPart, this.TLinkEnd);
		}
	
	    public WikiInternalLinkSyntax AddLinkTextPart(params LinkTextPartSyntax[] linkTextPart)
		{
			return this.WithLinkTextPart(this.LinkTextPart.AddRange(linkTextPart));
		}
	
	    public WikiInternalLinkSyntax WithTLinkEnd(SyntaxToken tLinkEnd)
		{
			return this.Update(this.TLinkStart, this.LinkText, this.LinkTextPart, TLinkEnd);
		}
	
	    public WikiInternalLinkSyntax Update(SyntaxToken tLinkStart, LinkTextSyntax linkText, SyntaxNodeList<LinkTextPartSyntax> linkTextPart, SyntaxToken tLinkEnd)
	    {
	        if (this.TLinkStart != tLinkStart ||
				this.LinkText != linkText ||
				this.LinkTextPart.Node != linkTextPart.Node ||
				this.TLinkEnd != tLinkEnd)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiInternalLink(tLinkStart, linkText, linkTextPart, tLinkEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiInternalLinkSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWikiInternalLink(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWikiInternalLink(this);
	    }
	}
	
	public sealed class WikiExternalLinkSyntax : MediaWikiSyntaxNode
	{
	    private LinkTextSyntax linkText;
	    private SyntaxNodeList linkTextPart;
	
	    public WikiExternalLinkSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WikiExternalLinkSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TExternalLinkStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiExternalLinkGreen)this.Green;
				var greenToken = green.TExternalLinkStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public LinkTextSyntax LinkText 
		{ 
			get { return this.GetRed(ref this.linkText, 1); } 
		}
	    public SyntaxNodeList<LinkTextPartSyntax> LinkTextPart 
		{ 
			get
			{
				var red = this.GetRed(ref this.linkTextPart, 2);
				if (red != null)
				{
					return new SyntaxNodeList<LinkTextPartSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TExternalLinkEnd 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiExternalLinkGreen)this.Green;
				var greenToken = green.TExternalLinkEnd;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.linkText, 1);
				case 2: return this.GetRed(ref this.linkTextPart, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.linkText;
				case 2: return this.linkTextPart;
				default: return null;
	        }
	    }
	
	    public WikiExternalLinkSyntax WithTExternalLinkStart(SyntaxToken tExternalLinkStart)
		{
			return this.Update(TExternalLinkStart, this.LinkText, this.LinkTextPart, this.TExternalLinkEnd);
		}
	
	    public WikiExternalLinkSyntax WithLinkText(LinkTextSyntax linkText)
		{
			return this.Update(this.TExternalLinkStart, LinkText, this.LinkTextPart, this.TExternalLinkEnd);
		}
	
	    public WikiExternalLinkSyntax WithLinkTextPart(SyntaxNodeList<LinkTextPartSyntax> linkTextPart)
		{
			return this.Update(this.TExternalLinkStart, this.LinkText, LinkTextPart, this.TExternalLinkEnd);
		}
	
	    public WikiExternalLinkSyntax AddLinkTextPart(params LinkTextPartSyntax[] linkTextPart)
		{
			return this.WithLinkTextPart(this.LinkTextPart.AddRange(linkTextPart));
		}
	
	    public WikiExternalLinkSyntax WithTExternalLinkEnd(SyntaxToken tExternalLinkEnd)
		{
			return this.Update(this.TExternalLinkStart, this.LinkText, this.LinkTextPart, TExternalLinkEnd);
		}
	
	    public WikiExternalLinkSyntax Update(SyntaxToken tExternalLinkStart, LinkTextSyntax linkText, SyntaxNodeList<LinkTextPartSyntax> linkTextPart, SyntaxToken tExternalLinkEnd)
	    {
	        if (this.TExternalLinkStart != tExternalLinkStart ||
				this.LinkText != linkText ||
				this.LinkTextPart.Node != linkTextPart.Node ||
				this.TExternalLinkEnd != tExternalLinkEnd)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiExternalLink(tExternalLinkStart, linkText, linkTextPart, tExternalLinkEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiExternalLinkSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWikiExternalLink(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWikiExternalLink(this);
	    }
	}
	
	public sealed class WikiTemplateSyntax : MediaWikiSyntaxNode
	{
	    private LinkTextSyntax linkText;
	    private SyntaxNodeList linkTextPart;
	
	    public WikiTemplateSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WikiTemplateSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTemplateStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiTemplateGreen)this.Green;
				var greenToken = green.TTemplateStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public LinkTextSyntax LinkText 
		{ 
			get { return this.GetRed(ref this.linkText, 1); } 
		}
	    public SyntaxNodeList<LinkTextPartSyntax> LinkTextPart 
		{ 
			get
			{
				var red = this.GetRed(ref this.linkTextPart, 2);
				if (red != null)
				{
					return new SyntaxNodeList<LinkTextPartSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TTemplateEnd 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiTemplateGreen)this.Green;
				var greenToken = green.TTemplateEnd;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.linkText, 1);
				case 2: return this.GetRed(ref this.linkTextPart, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.linkText;
				case 2: return this.linkTextPart;
				default: return null;
	        }
	    }
	
	    public WikiTemplateSyntax WithTTemplateStart(SyntaxToken tTemplateStart)
		{
			return this.Update(TTemplateStart, this.LinkText, this.LinkTextPart, this.TTemplateEnd);
		}
	
	    public WikiTemplateSyntax WithLinkText(LinkTextSyntax linkText)
		{
			return this.Update(this.TTemplateStart, LinkText, this.LinkTextPart, this.TTemplateEnd);
		}
	
	    public WikiTemplateSyntax WithLinkTextPart(SyntaxNodeList<LinkTextPartSyntax> linkTextPart)
		{
			return this.Update(this.TTemplateStart, this.LinkText, LinkTextPart, this.TTemplateEnd);
		}
	
	    public WikiTemplateSyntax AddLinkTextPart(params LinkTextPartSyntax[] linkTextPart)
		{
			return this.WithLinkTextPart(this.LinkTextPart.AddRange(linkTextPart));
		}
	
	    public WikiTemplateSyntax WithTTemplateEnd(SyntaxToken tTemplateEnd)
		{
			return this.Update(this.TTemplateStart, this.LinkText, this.LinkTextPart, TTemplateEnd);
		}
	
	    public WikiTemplateSyntax Update(SyntaxToken tTemplateStart, LinkTextSyntax linkText, SyntaxNodeList<LinkTextPartSyntax> linkTextPart, SyntaxToken tTemplateEnd)
	    {
	        if (this.TTemplateStart != tTemplateStart ||
				this.LinkText != linkText ||
				this.LinkTextPart.Node != linkTextPart.Node ||
				this.TTemplateEnd != tTemplateEnd)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiTemplate(tTemplateStart, linkText, linkTextPart, tTemplateEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiTemplateSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWikiTemplate(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWikiTemplate(this);
	    }
	}
	
	public sealed class WikiTemplateParamSyntax : MediaWikiSyntaxNode
	{
	    private LinkTextSyntax linkText;
	    private SyntaxNodeList linkTextPart;
	
	    public WikiTemplateParamSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WikiTemplateParamSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTemplateParamStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiTemplateParamGreen)this.Green;
				var greenToken = green.TTemplateParamStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public LinkTextSyntax LinkText 
		{ 
			get { return this.GetRed(ref this.linkText, 1); } 
		}
	    public SyntaxNodeList<LinkTextPartSyntax> LinkTextPart 
		{ 
			get
			{
				var red = this.GetRed(ref this.linkTextPart, 2);
				if (red != null)
				{
					return new SyntaxNodeList<LinkTextPartSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TTemplateParamEnd 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WikiTemplateParamGreen)this.Green;
				var greenToken = green.TTemplateParamEnd;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.linkText, 1);
				case 2: return this.GetRed(ref this.linkTextPart, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.linkText;
				case 2: return this.linkTextPart;
				default: return null;
	        }
	    }
	
	    public WikiTemplateParamSyntax WithTTemplateParamStart(SyntaxToken tTemplateParamStart)
		{
			return this.Update(TTemplateParamStart, this.LinkText, this.LinkTextPart, this.TTemplateParamEnd);
		}
	
	    public WikiTemplateParamSyntax WithLinkText(LinkTextSyntax linkText)
		{
			return this.Update(this.TTemplateParamStart, LinkText, this.LinkTextPart, this.TTemplateParamEnd);
		}
	
	    public WikiTemplateParamSyntax WithLinkTextPart(SyntaxNodeList<LinkTextPartSyntax> linkTextPart)
		{
			return this.Update(this.TTemplateParamStart, this.LinkText, LinkTextPart, this.TTemplateParamEnd);
		}
	
	    public WikiTemplateParamSyntax AddLinkTextPart(params LinkTextPartSyntax[] linkTextPart)
		{
			return this.WithLinkTextPart(this.LinkTextPart.AddRange(linkTextPart));
		}
	
	    public WikiTemplateParamSyntax WithTTemplateParamEnd(SyntaxToken tTemplateParamEnd)
		{
			return this.Update(this.TTemplateParamStart, this.LinkText, this.LinkTextPart, TTemplateParamEnd);
		}
	
	    public WikiTemplateParamSyntax Update(SyntaxToken tTemplateParamStart, LinkTextSyntax linkText, SyntaxNodeList<LinkTextPartSyntax> linkTextPart, SyntaxToken tTemplateParamEnd)
	    {
	        if (this.TTemplateParamStart != tTemplateParamStart ||
				this.LinkText != linkText ||
				this.LinkTextPart.Node != linkTextPart.Node ||
				this.TTemplateParamEnd != tTemplateParamEnd)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WikiTemplateParam(tTemplateParamStart, linkText, linkTextPart, tTemplateParamEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiTemplateParamSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWikiTemplateParam(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWikiTemplateParam(this);
	    }
	}
	
	public sealed class NoWikiSyntax : MediaWikiSyntaxNode
	{
	
	    public NoWikiSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NoWikiSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TNoWiki 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.NoWikiGreen)this.Green;
				var greenToken = green.TNoWiki;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public NoWikiSyntax WithTNoWiki(SyntaxToken tNoWiki)
		{
			return this.Update(TNoWiki);
		}
	
	    public NoWikiSyntax Update(SyntaxToken tNoWiki)
	    {
	        if (this.TNoWiki != tNoWiki)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.NoWiki(tNoWiki);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NoWikiSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNoWiki(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitNoWiki(this);
	    }
	}
	
	public sealed class BarOrBarBarSyntax : MediaWikiSyntaxNode
	{
	
	    public BarOrBarBarSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BarOrBarBarSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BarOrBarBar 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.BarOrBarBarGreen)this.Green;
				var greenToken = green.BarOrBarBar;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public BarOrBarBarSyntax WithBarOrBarBar(SyntaxToken barOrBarBar)
		{
			return this.Update(BarOrBarBar);
		}
	
	    public BarOrBarBarSyntax Update(SyntaxToken barOrBarBar)
	    {
	        if (this.BarOrBarBar != barOrBarBar)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.BarOrBarBar(barOrBarBar);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BarOrBarBarSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBarOrBarBar(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitBarOrBarBar(this);
	    }
	}
	
	public sealed class LinkTextPartSyntax : MediaWikiSyntaxNode
	{
	    private BarOrBarBarSyntax barOrBarBar;
	    private LinkTextSyntax linkText;
	
	    public LinkTextPartSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LinkTextPartSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public BarOrBarBarSyntax BarOrBarBar 
		{ 
			get { return this.GetRed(ref this.barOrBarBar, 0); } 
		}
	    public LinkTextSyntax LinkText 
		{ 
			get { return this.GetRed(ref this.linkText, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.barOrBarBar, 0);
				case 1: return this.GetRed(ref this.linkText, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.barOrBarBar;
				case 1: return this.linkText;
				default: return null;
	        }
	    }
	
	    public LinkTextPartSyntax WithBarOrBarBar(BarOrBarBarSyntax barOrBarBar)
		{
			return this.Update(BarOrBarBar, this.LinkText);
		}
	
	    public LinkTextPartSyntax WithLinkText(LinkTextSyntax linkText)
		{
			return this.Update(this.BarOrBarBar, LinkText);
		}
	
	    public LinkTextPartSyntax Update(BarOrBarBarSyntax barOrBarBar, LinkTextSyntax linkText)
	    {
	        if (this.BarOrBarBar != barOrBarBar ||
				this.LinkText != linkText)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.LinkTextPart(barOrBarBar, linkText);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextPartSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLinkTextPart(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitLinkTextPart(this);
	    }
	}
	
	public sealed class HtmlReferenceSyntax : MediaWikiSyntaxNode
	{
	
	    public HtmlReferenceSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlReferenceSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken HtmlReference 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlReferenceGreen)this.Green;
				var greenToken = green.HtmlReference;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HtmlReferenceSyntax WithHtmlReference(SyntaxToken htmlReference)
		{
			return this.Update(HtmlReference);
		}
	
	    public HtmlReferenceSyntax Update(SyntaxToken htmlReference)
	    {
	        if (this.HtmlReference != htmlReference)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlReference(htmlReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlReference(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlReference(this);
	    }
	}
	
	public sealed class HtmlCommentListSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList htmlComment;
	
	    public HtmlCommentListSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlCommentListSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<HtmlCommentSyntax> HtmlComment 
		{ 
			get
			{
				var red = this.GetRed(ref this.htmlComment, 0);
				if (red != null)
				{
					return new SyntaxNodeList<HtmlCommentSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.htmlComment, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.htmlComment;
				default: return null;
	        }
	    }
	
	    public HtmlCommentListSyntax WithHtmlComment(SyntaxNodeList<HtmlCommentSyntax> htmlComment)
		{
			return this.Update(HtmlComment);
		}
	
	    public HtmlCommentListSyntax AddHtmlComment(params HtmlCommentSyntax[] htmlComment)
		{
			return this.WithHtmlComment(this.HtmlComment.AddRange(htmlComment));
		}
	
	    public HtmlCommentListSyntax Update(SyntaxNodeList<HtmlCommentSyntax> htmlComment)
	    {
	        if (this.HtmlComment.Node != htmlComment.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlCommentList(htmlComment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlCommentListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlCommentList(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlCommentList(this);
	    }
	}
	
	public sealed class HtmlCommentSyntax : MediaWikiSyntaxNode
	{
	
	    public HtmlCommentSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlCommentSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken THtmlComment 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlCommentGreen)this.Green;
				var greenToken = green.THtmlComment;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HtmlCommentSyntax WithTHtmlComment(SyntaxToken tHtmlComment)
		{
			return this.Update(THtmlComment);
		}
	
	    public HtmlCommentSyntax Update(SyntaxToken tHtmlComment)
	    {
	        if (this.THtmlComment != tHtmlComment)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlComment(tHtmlComment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlCommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlComment(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlComment(this);
	    }
	}
	
	public sealed class HtmlStyleSyntax : MediaWikiSyntaxNode
	{
	
	    public HtmlStyleSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlStyleSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken THtmlStyle 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlStyleGreen)this.Green;
				var greenToken = green.THtmlStyle;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HtmlStyleSyntax WithTHtmlStyle(SyntaxToken tHtmlStyle)
		{
			return this.Update(THtmlStyle);
		}
	
	    public HtmlStyleSyntax Update(SyntaxToken tHtmlStyle)
	    {
	        if (this.THtmlStyle != tHtmlStyle)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlStyle(tHtmlStyle);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlStyleSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlStyle(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlStyle(this);
	    }
	}
	
	public sealed class HtmlScriptSyntax : MediaWikiSyntaxNode
	{
	
	    public HtmlScriptSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlScriptSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken THtmlScript 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlScriptGreen)this.Green;
				var greenToken = green.THtmlScript;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HtmlScriptSyntax WithTHtmlScript(SyntaxToken tHtmlScript)
		{
			return this.Update(THtmlScript);
		}
	
	    public HtmlScriptSyntax Update(SyntaxToken tHtmlScript)
	    {
	        if (this.THtmlScript != tHtmlScript)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlScript(tHtmlScript);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlScriptSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlScript(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlScript(this);
	    }
	}
	
	public sealed class HtmlTagSyntax : MediaWikiSyntaxNode
	{
	    private HtmlTagOpenSyntax htmlTagOpen;
	    private HtmlTagCloseSyntax htmlTagClose;
	    private HtmlTagEmptySyntax htmlTagEmpty;
	
	    public HtmlTagSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlTagSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HtmlTagOpenSyntax HtmlTagOpen 
		{ 
			get { return this.GetRed(ref this.htmlTagOpen, 0); } 
		}
	    public HtmlTagCloseSyntax HtmlTagClose 
		{ 
			get { return this.GetRed(ref this.htmlTagClose, 1); } 
		}
	    public HtmlTagEmptySyntax HtmlTagEmpty 
		{ 
			get { return this.GetRed(ref this.htmlTagEmpty, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.htmlTagOpen, 0);
				case 1: return this.GetRed(ref this.htmlTagClose, 1);
				case 2: return this.GetRed(ref this.htmlTagEmpty, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.htmlTagOpen;
				case 1: return this.htmlTagClose;
				case 2: return this.htmlTagEmpty;
				default: return null;
	        }
	    }
	
	    public HtmlTagSyntax WithHtmlTagOpen(HtmlTagOpenSyntax htmlTagOpen)
		{
			return this.Update(htmlTagOpen);
		}
	
	    public HtmlTagSyntax WithHtmlTagClose(HtmlTagCloseSyntax htmlTagClose)
		{
			return this.Update(htmlTagClose);
		}
	
	    public HtmlTagSyntax WithHtmlTagEmpty(HtmlTagEmptySyntax htmlTagEmpty)
		{
			return this.Update(htmlTagEmpty);
		}
	
	    public HtmlTagSyntax Update(HtmlTagOpenSyntax htmlTagOpen)
	    {
	        if (this.HtmlTagOpen != htmlTagOpen)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlTag(htmlTagOpen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagSyntax)newNode;
	        }
	        return this;
	    }
	
	    public HtmlTagSyntax Update(HtmlTagCloseSyntax htmlTagClose)
	    {
	        if (this.HtmlTagClose != htmlTagClose)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlTag(htmlTagClose);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagSyntax)newNode;
	        }
	        return this;
	    }
	
	    public HtmlTagSyntax Update(HtmlTagEmptySyntax htmlTagEmpty)
	    {
	        if (this.HtmlTagEmpty != htmlTagEmpty)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlTag(htmlTagEmpty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlTag(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlTag(this);
	    }
	}
	
	public sealed class HtmlTagOpenSyntax : MediaWikiSyntaxNode
	{
	    private WhitespaceListSyntax leadingWhitespace;
	    private HtmlTagNameSyntax htmlTagName;
	    private SyntaxNodeList htmlAttribute;
	    private WhitespaceListSyntax trailingWhitespace;
	
	    public HtmlTagOpenSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlTagOpenSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTagStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlTagOpenGreen)this.Green;
				var greenToken = green.TTagStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public WhitespaceListSyntax LeadingWhitespace 
		{ 
			get { return this.GetRed(ref this.leadingWhitespace, 1); } 
		}
	    public HtmlTagNameSyntax HtmlTagName 
		{ 
			get { return this.GetRed(ref this.htmlTagName, 2); } 
		}
	    public SyntaxNodeList<HtmlAttributeSyntax> HtmlAttribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.htmlAttribute, 3);
				if (red != null)
				{
					return new SyntaxNodeList<HtmlAttributeSyntax>(red);
				}
				return null;
			} 
		}
	    public WhitespaceListSyntax TrailingWhitespace 
		{ 
			get { return this.GetRed(ref this.trailingWhitespace, 4); } 
		}
	    public SyntaxToken TTagEnd 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlTagOpenGreen)this.Green;
				var greenToken = green.TTagEnd;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(5), this.GetChildIndex(5)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.leadingWhitespace, 1);
				case 2: return this.GetRed(ref this.htmlTagName, 2);
				case 3: return this.GetRed(ref this.htmlAttribute, 3);
				case 4: return this.GetRed(ref this.trailingWhitespace, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.leadingWhitespace;
				case 2: return this.htmlTagName;
				case 3: return this.htmlAttribute;
				case 4: return this.trailingWhitespace;
				default: return null;
	        }
	    }
	
	    public HtmlTagOpenSyntax WithTTagStart(SyntaxToken tTagStart)
		{
			return this.Update(TTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TTagEnd);
		}
	
	    public HtmlTagOpenSyntax WithLeadingWhitespace(WhitespaceListSyntax leadingWhitespace)
		{
			return this.Update(this.TTagStart, LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TTagEnd);
		}
	
	    public HtmlTagOpenSyntax WithHtmlTagName(HtmlTagNameSyntax htmlTagName)
		{
			return this.Update(this.TTagStart, this.LeadingWhitespace, HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TTagEnd);
		}
	
	    public HtmlTagOpenSyntax WithHtmlAttribute(SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute)
		{
			return this.Update(this.TTagStart, this.LeadingWhitespace, this.HtmlTagName, HtmlAttribute, this.TrailingWhitespace, this.TTagEnd);
		}
	
	    public HtmlTagOpenSyntax AddHtmlAttribute(params HtmlAttributeSyntax[] htmlAttribute)
		{
			return this.WithHtmlAttribute(this.HtmlAttribute.AddRange(htmlAttribute));
		}
	
	    public HtmlTagOpenSyntax WithTrailingWhitespace(WhitespaceListSyntax trailingWhitespace)
		{
			return this.Update(this.TTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, TrailingWhitespace, this.TTagEnd);
		}
	
	    public HtmlTagOpenSyntax WithTTagEnd(SyntaxToken tTagEnd)
		{
			return this.Update(this.TTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, TTagEnd);
		}
	
	    public HtmlTagOpenSyntax Update(SyntaxToken tTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute, WhitespaceListSyntax trailingWhitespace, SyntaxToken tTagEnd)
	    {
	        if (this.TTagStart != tTagStart ||
				this.LeadingWhitespace != leadingWhitespace ||
				this.HtmlTagName != htmlTagName ||
				this.HtmlAttribute.Node != htmlAttribute.Node ||
				this.TrailingWhitespace != trailingWhitespace ||
				this.TTagEnd != tTagEnd)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlTagOpen(tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagOpenSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlTagOpen(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlTagOpen(this);
	    }
	}
	
	public sealed class HtmlTagCloseSyntax : MediaWikiSyntaxNode
	{
	    private WhitespaceListSyntax leadingWhitespace;
	    private HtmlTagNameSyntax htmlTagName;
	    private SyntaxNodeList htmlAttribute;
	    private WhitespaceListSyntax trailingWhitespace;
	
	    public HtmlTagCloseSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlTagCloseSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TEndTagStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlTagCloseGreen)this.Green;
				var greenToken = green.TEndTagStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public WhitespaceListSyntax LeadingWhitespace 
		{ 
			get { return this.GetRed(ref this.leadingWhitespace, 1); } 
		}
	    public HtmlTagNameSyntax HtmlTagName 
		{ 
			get { return this.GetRed(ref this.htmlTagName, 2); } 
		}
	    public SyntaxNodeList<HtmlAttributeSyntax> HtmlAttribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.htmlAttribute, 3);
				if (red != null)
				{
					return new SyntaxNodeList<HtmlAttributeSyntax>(red);
				}
				return null;
			} 
		}
	    public WhitespaceListSyntax TrailingWhitespace 
		{ 
			get { return this.GetRed(ref this.trailingWhitespace, 4); } 
		}
	    public SyntaxToken TEndTagEnd 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlTagCloseGreen)this.Green;
				var greenToken = green.TEndTagEnd;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(5), this.GetChildIndex(5)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.leadingWhitespace, 1);
				case 2: return this.GetRed(ref this.htmlTagName, 2);
				case 3: return this.GetRed(ref this.htmlAttribute, 3);
				case 4: return this.GetRed(ref this.trailingWhitespace, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.leadingWhitespace;
				case 2: return this.htmlTagName;
				case 3: return this.htmlAttribute;
				case 4: return this.trailingWhitespace;
				default: return null;
	        }
	    }
	
	    public HtmlTagCloseSyntax WithTEndTagStart(SyntaxToken tEndTagStart)
		{
			return this.Update(TEndTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TEndTagEnd);
		}
	
	    public HtmlTagCloseSyntax WithLeadingWhitespace(WhitespaceListSyntax leadingWhitespace)
		{
			return this.Update(this.TEndTagStart, LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TEndTagEnd);
		}
	
	    public HtmlTagCloseSyntax WithHtmlTagName(HtmlTagNameSyntax htmlTagName)
		{
			return this.Update(this.TEndTagStart, this.LeadingWhitespace, HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TEndTagEnd);
		}
	
	    public HtmlTagCloseSyntax WithHtmlAttribute(SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute)
		{
			return this.Update(this.TEndTagStart, this.LeadingWhitespace, this.HtmlTagName, HtmlAttribute, this.TrailingWhitespace, this.TEndTagEnd);
		}
	
	    public HtmlTagCloseSyntax AddHtmlAttribute(params HtmlAttributeSyntax[] htmlAttribute)
		{
			return this.WithHtmlAttribute(this.HtmlAttribute.AddRange(htmlAttribute));
		}
	
	    public HtmlTagCloseSyntax WithTrailingWhitespace(WhitespaceListSyntax trailingWhitespace)
		{
			return this.Update(this.TEndTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, TrailingWhitespace, this.TEndTagEnd);
		}
	
	    public HtmlTagCloseSyntax WithTEndTagEnd(SyntaxToken tEndTagEnd)
		{
			return this.Update(this.TEndTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, TEndTagEnd);
		}
	
	    public HtmlTagCloseSyntax Update(SyntaxToken tEndTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute, WhitespaceListSyntax trailingWhitespace, SyntaxToken tEndTagEnd)
	    {
	        if (this.TEndTagStart != tEndTagStart ||
				this.LeadingWhitespace != leadingWhitespace ||
				this.HtmlTagName != htmlTagName ||
				this.HtmlAttribute.Node != htmlAttribute.Node ||
				this.TrailingWhitespace != trailingWhitespace ||
				this.TEndTagEnd != tEndTagEnd)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlTagClose(tEndTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tEndTagEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagCloseSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlTagClose(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlTagClose(this);
	    }
	}
	
	public sealed class HtmlTagEmptySyntax : MediaWikiSyntaxNode
	{
	    private WhitespaceListSyntax leadingWhitespace;
	    private HtmlTagNameSyntax htmlTagName;
	    private SyntaxNodeList htmlAttribute;
	    private WhitespaceListSyntax trailingWhitespace;
	
	    public HtmlTagEmptySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlTagEmptySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTagStart 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlTagEmptyGreen)this.Green;
				var greenToken = green.TTagStart;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public WhitespaceListSyntax LeadingWhitespace 
		{ 
			get { return this.GetRed(ref this.leadingWhitespace, 1); } 
		}
	    public HtmlTagNameSyntax HtmlTagName 
		{ 
			get { return this.GetRed(ref this.htmlTagName, 2); } 
		}
	    public SyntaxNodeList<HtmlAttributeSyntax> HtmlAttribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.htmlAttribute, 3);
				if (red != null)
				{
					return new SyntaxNodeList<HtmlAttributeSyntax>(red);
				}
				return null;
			} 
		}
	    public WhitespaceListSyntax TrailingWhitespace 
		{ 
			get { return this.GetRed(ref this.trailingWhitespace, 4); } 
		}
	    public SyntaxToken TTagCloseEnd 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlTagEmptyGreen)this.Green;
				var greenToken = green.TTagCloseEnd;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(5), this.GetChildIndex(5)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.leadingWhitespace, 1);
				case 2: return this.GetRed(ref this.htmlTagName, 2);
				case 3: return this.GetRed(ref this.htmlAttribute, 3);
				case 4: return this.GetRed(ref this.trailingWhitespace, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.leadingWhitespace;
				case 2: return this.htmlTagName;
				case 3: return this.htmlAttribute;
				case 4: return this.trailingWhitespace;
				default: return null;
	        }
	    }
	
	    public HtmlTagEmptySyntax WithTTagStart(SyntaxToken tTagStart)
		{
			return this.Update(TTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TTagCloseEnd);
		}
	
	    public HtmlTagEmptySyntax WithLeadingWhitespace(WhitespaceListSyntax leadingWhitespace)
		{
			return this.Update(this.TTagStart, LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TTagCloseEnd);
		}
	
	    public HtmlTagEmptySyntax WithHtmlTagName(HtmlTagNameSyntax htmlTagName)
		{
			return this.Update(this.TTagStart, this.LeadingWhitespace, HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, this.TTagCloseEnd);
		}
	
	    public HtmlTagEmptySyntax WithHtmlAttribute(SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute)
		{
			return this.Update(this.TTagStart, this.LeadingWhitespace, this.HtmlTagName, HtmlAttribute, this.TrailingWhitespace, this.TTagCloseEnd);
		}
	
	    public HtmlTagEmptySyntax AddHtmlAttribute(params HtmlAttributeSyntax[] htmlAttribute)
		{
			return this.WithHtmlAttribute(this.HtmlAttribute.AddRange(htmlAttribute));
		}
	
	    public HtmlTagEmptySyntax WithTrailingWhitespace(WhitespaceListSyntax trailingWhitespace)
		{
			return this.Update(this.TTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, TrailingWhitespace, this.TTagCloseEnd);
		}
	
	    public HtmlTagEmptySyntax WithTTagCloseEnd(SyntaxToken tTagCloseEnd)
		{
			return this.Update(this.TTagStart, this.LeadingWhitespace, this.HtmlTagName, this.HtmlAttribute, this.TrailingWhitespace, TTagCloseEnd);
		}
	
	    public HtmlTagEmptySyntax Update(SyntaxToken tTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute, WhitespaceListSyntax trailingWhitespace, SyntaxToken tTagCloseEnd)
	    {
	        if (this.TTagStart != tTagStart ||
				this.LeadingWhitespace != leadingWhitespace ||
				this.HtmlTagName != htmlTagName ||
				this.HtmlAttribute.Node != htmlAttribute.Node ||
				this.TrailingWhitespace != trailingWhitespace ||
				this.TTagCloseEnd != tTagCloseEnd)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlTagEmpty(tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagCloseEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagEmptySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlTagEmpty(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlTagEmpty(this);
	    }
	}
	
	public abstract class HtmlAttributeSyntax : MediaWikiSyntaxNode
	{
	    protected HtmlAttributeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected HtmlAttributeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class HtmlAttributeWithValueSyntax : HtmlAttributeSyntax
	{
	    private WhitespaceListSyntax leadingWhitespace;
	    private HtmlAttributeNameSyntax htmlAttributeName;
	    private WhitespaceListSyntax whitespaceBeforeEquals;
	    private WhitespaceListSyntax whitespaceAfterEquals;
	    private HtmlAttributeValueSyntax htmlAttributeValue;
	
	    public HtmlAttributeWithValueSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlAttributeWithValueSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public WhitespaceListSyntax LeadingWhitespace 
		{ 
			get { return this.GetRed(ref this.leadingWhitespace, 0); } 
		}
	    public HtmlAttributeNameSyntax HtmlAttributeName 
		{ 
			get { return this.GetRed(ref this.htmlAttributeName, 1); } 
		}
	    public WhitespaceListSyntax WhitespaceBeforeEquals 
		{ 
			get { return this.GetRed(ref this.whitespaceBeforeEquals, 2); } 
		}
	    public SyntaxToken TAttributeEquals 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlAttributeWithValueGreen)this.Green;
				var greenToken = green.TAttributeEquals;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	    public WhitespaceListSyntax WhitespaceAfterEquals 
		{ 
			get { return this.GetRed(ref this.whitespaceAfterEquals, 4); } 
		}
	    public HtmlAttributeValueSyntax HtmlAttributeValue 
		{ 
			get { return this.GetRed(ref this.htmlAttributeValue, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingWhitespace, 0);
				case 1: return this.GetRed(ref this.htmlAttributeName, 1);
				case 2: return this.GetRed(ref this.whitespaceBeforeEquals, 2);
				case 4: return this.GetRed(ref this.whitespaceAfterEquals, 4);
				case 5: return this.GetRed(ref this.htmlAttributeValue, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingWhitespace;
				case 1: return this.htmlAttributeName;
				case 2: return this.whitespaceBeforeEquals;
				case 4: return this.whitespaceAfterEquals;
				case 5: return this.htmlAttributeValue;
				default: return null;
	        }
	    }
	
	    public HtmlAttributeWithValueSyntax WithLeadingWhitespace(WhitespaceListSyntax leadingWhitespace)
		{
			return this.Update(LeadingWhitespace, this.HtmlAttributeName, this.WhitespaceBeforeEquals, this.TAttributeEquals, this.WhitespaceAfterEquals, this.HtmlAttributeValue);
		}
	
	    public HtmlAttributeWithValueSyntax WithHtmlAttributeName(HtmlAttributeNameSyntax htmlAttributeName)
		{
			return this.Update(this.LeadingWhitespace, HtmlAttributeName, this.WhitespaceBeforeEquals, this.TAttributeEquals, this.WhitespaceAfterEquals, this.HtmlAttributeValue);
		}
	
	    public HtmlAttributeWithValueSyntax WithWhitespaceBeforeEquals(WhitespaceListSyntax whitespaceBeforeEquals)
		{
			return this.Update(this.LeadingWhitespace, this.HtmlAttributeName, WhitespaceBeforeEquals, this.TAttributeEquals, this.WhitespaceAfterEquals, this.HtmlAttributeValue);
		}
	
	    public HtmlAttributeWithValueSyntax WithTAttributeEquals(SyntaxToken tAttributeEquals)
		{
			return this.Update(this.LeadingWhitespace, this.HtmlAttributeName, this.WhitespaceBeforeEquals, TAttributeEquals, this.WhitespaceAfterEquals, this.HtmlAttributeValue);
		}
	
	    public HtmlAttributeWithValueSyntax WithWhitespaceAfterEquals(WhitespaceListSyntax whitespaceAfterEquals)
		{
			return this.Update(this.LeadingWhitespace, this.HtmlAttributeName, this.WhitespaceBeforeEquals, this.TAttributeEquals, WhitespaceAfterEquals, this.HtmlAttributeValue);
		}
	
	    public HtmlAttributeWithValueSyntax WithHtmlAttributeValue(HtmlAttributeValueSyntax htmlAttributeValue)
		{
			return this.Update(this.LeadingWhitespace, this.HtmlAttributeName, this.WhitespaceBeforeEquals, this.TAttributeEquals, this.WhitespaceAfterEquals, HtmlAttributeValue);
		}
	
	    public HtmlAttributeWithValueSyntax Update(WhitespaceListSyntax leadingWhitespace, HtmlAttributeNameSyntax htmlAttributeName, WhitespaceListSyntax whitespaceBeforeEquals, SyntaxToken tAttributeEquals, WhitespaceListSyntax whitespaceAfterEquals, HtmlAttributeValueSyntax htmlAttributeValue)
	    {
	        if (this.LeadingWhitespace != leadingWhitespace ||
				this.HtmlAttributeName != htmlAttributeName ||
				this.WhitespaceBeforeEquals != whitespaceBeforeEquals ||
				this.TAttributeEquals != tAttributeEquals ||
				this.WhitespaceAfterEquals != whitespaceAfterEquals ||
				this.HtmlAttributeValue != htmlAttributeValue)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlAttributeWithValue(leadingWhitespace, htmlAttributeName, whitespaceBeforeEquals, tAttributeEquals, whitespaceAfterEquals, htmlAttributeValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlAttributeWithValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlAttributeWithValue(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlAttributeWithValue(this);
	    }
	}
	
	public sealed class HtmlAttributeWithNoValueSyntax : HtmlAttributeSyntax
	{
	    private WhitespaceListSyntax leadingWhitespace;
	    private HtmlAttributeNameSyntax htmlAttributeName;
	
	    public HtmlAttributeWithNoValueSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlAttributeWithNoValueSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public WhitespaceListSyntax LeadingWhitespace 
		{ 
			get { return this.GetRed(ref this.leadingWhitespace, 0); } 
		}
	    public HtmlAttributeNameSyntax HtmlAttributeName 
		{ 
			get { return this.GetRed(ref this.htmlAttributeName, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leadingWhitespace, 0);
				case 1: return this.GetRed(ref this.htmlAttributeName, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leadingWhitespace;
				case 1: return this.htmlAttributeName;
				default: return null;
	        }
	    }
	
	    public HtmlAttributeWithNoValueSyntax WithLeadingWhitespace(WhitespaceListSyntax leadingWhitespace)
		{
			return this.Update(LeadingWhitespace, this.HtmlAttributeName);
		}
	
	    public HtmlAttributeWithNoValueSyntax WithHtmlAttributeName(HtmlAttributeNameSyntax htmlAttributeName)
		{
			return this.Update(this.LeadingWhitespace, HtmlAttributeName);
		}
	
	    public HtmlAttributeWithNoValueSyntax Update(WhitespaceListSyntax leadingWhitespace, HtmlAttributeNameSyntax htmlAttributeName)
	    {
	        if (this.LeadingWhitespace != leadingWhitespace ||
				this.HtmlAttributeName != htmlAttributeName)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlAttributeWithNoValue(leadingWhitespace, htmlAttributeName);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlAttributeWithNoValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlAttributeWithNoValue(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlAttributeWithNoValue(this);
	    }
	}
	
	public sealed class HtmlAttributeNameSyntax : MediaWikiSyntaxNode
	{
	
	    public HtmlAttributeNameSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlAttributeNameSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTagName 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlAttributeNameGreen)this.Green;
				var greenToken = green.TTagName;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HtmlAttributeNameSyntax WithTTagName(SyntaxToken tTagName)
		{
			return this.Update(TTagName);
		}
	
	    public HtmlAttributeNameSyntax Update(SyntaxToken tTagName)
	    {
	        if (this.TTagName != tTagName)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlAttributeName(tTagName);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlAttributeNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlAttributeName(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlAttributeName(this);
	    }
	}
	
	public sealed class HtmlAttributeValueSyntax : MediaWikiSyntaxNode
	{
	
	    public HtmlAttributeValueSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlAttributeValueSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TAttributeValue 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlAttributeValueGreen)this.Green;
				var greenToken = green.TAttributeValue;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HtmlAttributeValueSyntax WithTAttributeValue(SyntaxToken tAttributeValue)
		{
			return this.Update(TAttributeValue);
		}
	
	    public HtmlAttributeValueSyntax Update(SyntaxToken tAttributeValue)
	    {
	        if (this.TAttributeValue != tAttributeValue)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlAttributeValue(tAttributeValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlAttributeValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlAttributeValue(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlAttributeValue(this);
	    }
	}
	
	public sealed class HtmlTagNameSyntax : MediaWikiSyntaxNode
	{
	
	    public HtmlTagNameSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HtmlTagNameSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TTagName 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.HtmlTagNameGreen)this.Green;
				var greenToken = green.TTagName;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public HtmlTagNameSyntax WithTTagName(SyntaxToken tTagName)
		{
			return this.Update(TTagName);
		}
	
	    public HtmlTagNameSyntax Update(SyntaxToken tTagName)
	    {
	        if (this.TTagName != tTagName)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.HtmlTagName(tTagName);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHtmlTagName(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitHtmlTagName(this);
	    }
	}
	
	public sealed class WhitespaceListSyntax : MediaWikiSyntaxNode
	{
	    private SyntaxNodeList whitespace;
	
	    public WhitespaceListSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WhitespaceListSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<WhitespaceSyntax> Whitespace 
		{ 
			get
			{
				var red = this.GetRed(ref this.whitespace, 0);
				if (red != null)
				{
					return new SyntaxNodeList<WhitespaceSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.whitespace, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.whitespace;
				default: return null;
	        }
	    }
	
	    public WhitespaceListSyntax WithWhitespace(SyntaxNodeList<WhitespaceSyntax> whitespace)
		{
			return this.Update(Whitespace);
		}
	
	    public WhitespaceListSyntax AddWhitespace(params WhitespaceSyntax[] whitespace)
		{
			return this.WithWhitespace(this.Whitespace.AddRange(whitespace));
		}
	
	    public WhitespaceListSyntax Update(SyntaxNodeList<WhitespaceSyntax> whitespace)
	    {
	        if (this.Whitespace.Node != whitespace.Node)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.WhitespaceList(whitespace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhitespaceListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWhitespaceList(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWhitespaceList(this);
	    }
	}
	
	public sealed class WhitespaceSyntax : MediaWikiSyntaxNode
	{
	
	    public WhitespaceSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WhitespaceSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Whitespace 
		{ 
			get 
			{ 
				var green = (global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax.WhitespaceGreen)this.Green;
				var greenToken = green.Whitespace;
				return greenToken == null ? null : new MediaWikiSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
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
	
	    public WhitespaceSyntax WithWhitespace(SyntaxToken whitespace)
		{
			return this.Update(Whitespace);
		}
	
	    public WhitespaceSyntax Update(SyntaxToken whitespace)
	    {
	        if (this.Whitespace != whitespace)
	        {
	            SyntaxNode newNode = MediaWikiLanguage.Instance.SyntaxFactory.Whitespace(whitespace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhitespaceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMediaWikiSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWhitespace(this);
	    }
	
	    public override void Accept(IMediaWikiSyntaxVisitor visitor)
	    {
	        visitor.VisitWhitespace(this);
	    }
	}
}

namespace DevToolsX.Documents.Compilers.MediaWiki
{
    using System.Threading;
    using MetaDslx.Compiler;
    using MetaDslx.Compiler.Text;
	using DevToolsX.Documents.Compilers.MediaWiki.Syntax;
    using DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax;

	public interface IMediaWikiSyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitSpecialBlockOrParagraph(SpecialBlockOrParagraphSyntax node);
		
		void VisitSpecialBlockWithComment(SpecialBlockWithCommentSyntax node);
		
		void VisitSpecialBlock(SpecialBlockSyntax node);
		
		void VisitHeading(HeadingSyntax node);
		
		void VisitHeadingLevel(HeadingLevelSyntax node);
		
		void VisitHorizontalRule(HorizontalRuleSyntax node);
		
		void VisitCodeBlock(CodeBlockSyntax node);
		
		void VisitSpaceBlock(SpaceBlockSyntax node);
		
		void VisitWikiList(WikiListSyntax node);
		
		void VisitListItem(ListItemSyntax node);
		
		void VisitNormalListItem(NormalListItemSyntax node);
		
		void VisitDefinitionItem(DefinitionItemSyntax node);
		
		void VisitWikiTable(WikiTableSyntax node);
		
		void VisitTableCaption(TableCaptionSyntax node);
		
		void VisitTableRows(TableRowsSyntax node);
		
		void VisitTableFirstRow(TableFirstRowSyntax node);
		
		void VisitTableRow(TableRowSyntax node);
		
		void VisitTableColumn(TableColumnSyntax node);
		
		void VisitTableSingleHeaderCell(TableSingleHeaderCellSyntax node);
		
		void VisitTableHeaderCells(TableHeaderCellsSyntax node);
		
		void VisitTableSingleCell(TableSingleCellSyntax node);
		
		void VisitTableCells(TableCellsSyntax node);
		
		void VisitTableCell(TableCellSyntax node);
		
		void VisitCellValue(CellValueSyntax node);
		
		void VisitParagraph(ParagraphSyntax node);
		
		void VisitTextLineInlineElementsWithComment(TextLineInlineElementsWithCommentSyntax node);
		
		void VisitTextLineComment(TextLineCommentSyntax node);
		
		void VisitTextElements(TextElementsSyntax node);
		
		void VisitInlineText(InlineTextSyntax node);
		
		void VisitInlineTextElementWithComment(InlineTextElementWithCommentSyntax node);
		
		void VisitInlineTextElement(InlineTextElementSyntax node);
		
		void VisitInlineTextElements(InlineTextElementsSyntax node);
		
		void VisitDefinitionText(DefinitionTextSyntax node);
		
		void VisitDefinitionTextElementWithComment(DefinitionTextElementWithCommentSyntax node);
		
		void VisitDefinitionTextElement(DefinitionTextElementSyntax node);
		
		void VisitDefinitionTextElements(DefinitionTextElementsSyntax node);
		
		void VisitHeadingText(HeadingTextSyntax node);
		
		void VisitHeadingTextWithComment(HeadingTextWithCommentSyntax node);
		
		void VisitHeadingTextElement(HeadingTextElementSyntax node);
		
		void VisitHeadingTextElements(HeadingTextElementsSyntax node);
		
		void VisitCellText(CellTextSyntax node);
		
		void VisitCellTextElementWithComment(CellTextElementWithCommentSyntax node);
		
		void VisitCellTextElement(CellTextElementSyntax node);
		
		void VisitCellTextElements(CellTextElementsSyntax node);
		
		void VisitLinkText(LinkTextSyntax node);
		
		void VisitLinkTextWithComment(LinkTextWithCommentSyntax node);
		
		void VisitLinkTextElement(LinkTextElementSyntax node);
		
		void VisitLinkTextElements(LinkTextElementsSyntax node);
		
		void VisitWikiFormat(WikiFormatSyntax node);
		
		void VisitWikiLink(WikiLinkSyntax node);
		
		void VisitWikiInternalLink(WikiInternalLinkSyntax node);
		
		void VisitWikiExternalLink(WikiExternalLinkSyntax node);
		
		void VisitWikiTemplate(WikiTemplateSyntax node);
		
		void VisitWikiTemplateParam(WikiTemplateParamSyntax node);
		
		void VisitNoWiki(NoWikiSyntax node);
		
		void VisitBarOrBarBar(BarOrBarBarSyntax node);
		
		void VisitLinkTextPart(LinkTextPartSyntax node);
		
		void VisitHtmlReference(HtmlReferenceSyntax node);
		
		void VisitHtmlCommentList(HtmlCommentListSyntax node);
		
		void VisitHtmlComment(HtmlCommentSyntax node);
		
		void VisitHtmlStyle(HtmlStyleSyntax node);
		
		void VisitHtmlScript(HtmlScriptSyntax node);
		
		void VisitHtmlTag(HtmlTagSyntax node);
		
		void VisitHtmlTagOpen(HtmlTagOpenSyntax node);
		
		void VisitHtmlTagClose(HtmlTagCloseSyntax node);
		
		void VisitHtmlTagEmpty(HtmlTagEmptySyntax node);
		
		void VisitHtmlAttributeWithValue(HtmlAttributeWithValueSyntax node);
		
		void VisitHtmlAttributeWithNoValue(HtmlAttributeWithNoValueSyntax node);
		
		void VisitHtmlAttributeName(HtmlAttributeNameSyntax node);
		
		void VisitHtmlAttributeValue(HtmlAttributeValueSyntax node);
		
		void VisitHtmlTagName(HtmlTagNameSyntax node);
		
		void VisitWhitespaceList(WhitespaceListSyntax node);
		
		void VisitWhitespace(WhitespaceSyntax node);
	}
	
	public class MediaWikiSyntaxVisitor : SyntaxVisitor, IMediaWikiSyntaxVisitor
	{
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSpecialBlockOrParagraph(SpecialBlockOrParagraphSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSpecialBlockWithComment(SpecialBlockWithCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSpecialBlock(SpecialBlockSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHeading(HeadingSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHeadingLevel(HeadingLevelSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHorizontalRule(HorizontalRuleSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCodeBlock(CodeBlockSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSpaceBlock(SpaceBlockSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWikiList(WikiListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitListItem(ListItemSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNormalListItem(NormalListItemSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDefinitionItem(DefinitionItemSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWikiTable(WikiTableSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableCaption(TableCaptionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableRows(TableRowsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableFirstRow(TableFirstRowSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableRow(TableRowSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableColumn(TableColumnSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableSingleHeaderCell(TableSingleHeaderCellSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableHeaderCells(TableHeaderCellsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableSingleCell(TableSingleCellSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableCells(TableCellsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTableCell(TableCellSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCellValue(CellValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParagraph(ParagraphSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTextLineInlineElementsWithComment(TextLineInlineElementsWithCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTextLineComment(TextLineCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTextElements(TextElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInlineText(InlineTextSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInlineTextElementWithComment(InlineTextElementWithCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInlineTextElement(InlineTextElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInlineTextElements(InlineTextElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDefinitionText(DefinitionTextSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDefinitionTextElementWithComment(DefinitionTextElementWithCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDefinitionTextElement(DefinitionTextElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDefinitionTextElements(DefinitionTextElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHeadingText(HeadingTextSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHeadingTextWithComment(HeadingTextWithCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHeadingTextElement(HeadingTextElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHeadingTextElements(HeadingTextElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCellText(CellTextSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCellTextElementWithComment(CellTextElementWithCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCellTextElement(CellTextElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCellTextElements(CellTextElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLinkText(LinkTextSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLinkTextWithComment(LinkTextWithCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLinkTextElement(LinkTextElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLinkTextElements(LinkTextElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWikiFormat(WikiFormatSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWikiLink(WikiLinkSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWikiInternalLink(WikiInternalLinkSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWikiExternalLink(WikiExternalLinkSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWikiTemplate(WikiTemplateSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWikiTemplateParam(WikiTemplateParamSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNoWiki(NoWikiSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBarOrBarBar(BarOrBarBarSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLinkTextPart(LinkTextPartSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlReference(HtmlReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlCommentList(HtmlCommentListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlComment(HtmlCommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlStyle(HtmlStyleSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlScript(HtmlScriptSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlTag(HtmlTagSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlTagOpen(HtmlTagOpenSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlTagClose(HtmlTagCloseSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlTagEmpty(HtmlTagEmptySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlAttributeWithValue(HtmlAttributeWithValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlAttributeWithNoValue(HtmlAttributeWithNoValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlAttributeName(HtmlAttributeNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlAttributeValue(HtmlAttributeValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHtmlTagName(HtmlTagNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWhitespaceList(WhitespaceListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWhitespace(WhitespaceSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	public class MediaWikiDetailedSyntaxVisitor : DetailedSyntaxVisitor, IMediaWikiSyntaxVisitor
	{
	    public MediaWikiDetailedSyntaxVisitor(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.VisitList(node.SpecialBlockOrParagraph);
			this.VisitToken(node.Eof);
		}
		
		public virtual void VisitSpecialBlockOrParagraph(SpecialBlockOrParagraphSyntax node)
		{
			this.Visit(node.SpecialBlockWithComment);
			this.Visit(node.Paragraph);
		}
		
		public virtual void VisitSpecialBlockWithComment(SpecialBlockWithCommentSyntax node)
		{
			this.Visit(node.LeadingComment);
			this.Visit(node.SpecialBlock);
			this.Visit(node.TrailingComment);
			this.VisitToken(node.CRLF);
		}
		
		public virtual void VisitSpecialBlock(SpecialBlockSyntax node)
		{
			this.Visit(node.Heading);
			this.Visit(node.HorizontalRule);
			this.Visit(node.CodeBlock);
			this.Visit(node.WikiList);
			this.Visit(node.WikiTable);
		}
		
		public virtual void VisitHeading(HeadingSyntax node)
		{
			this.Visit(node.HeadingStart);
			this.Visit(node.HeadingText);
			this.Visit(node.HeadingEnd);
			this.Visit(node.InlineText);
		}
		
		public virtual void VisitHeadingLevel(HeadingLevelSyntax node)
		{
			this.VisitToken(node.THeading);
		}
		
		public virtual void VisitHorizontalRule(HorizontalRuleSyntax node)
		{
			this.VisitToken(node.THorizontalLine);
			this.Visit(node.InlineText);
		}
		
		public virtual void VisitCodeBlock(CodeBlockSyntax node)
		{
			this.VisitList(node.SpaceBlock);
		}
		
		public virtual void VisitSpaceBlock(SpaceBlockSyntax node)
		{
			this.VisitToken(node.TSpaceBlockStart);
			this.Visit(node.InlineText);
		}
		
		public virtual void VisitWikiList(WikiListSyntax node)
		{
			this.VisitList(node.ListItem);
		}
		
		public virtual void VisitListItem(ListItemSyntax node)
		{
			this.Visit(node.NormalListItem);
			this.Visit(node.DefinitionItem);
		}
		
		public virtual void VisitNormalListItem(NormalListItemSyntax node)
		{
			this.VisitToken(node.TListStart);
			this.Visit(node.InlineText);
		}
		
		public virtual void VisitDefinitionItem(DefinitionItemSyntax node)
		{
			this.VisitToken(node.TDefinitionStart);
			this.Visit(node.DefinitionText);
			this.VisitToken(node.TColon);
			this.Visit(node.InlineText);
		}
		
		public virtual void VisitWikiTable(WikiTableSyntax node)
		{
			this.VisitToken(node.TTableStart);
			this.Visit(node.LeadingInlineText);
			this.VisitToken(node.CRLF);
			this.Visit(node.TableCaption);
			this.Visit(node.TableRows);
			this.VisitToken(node.TTableEnd);
			this.Visit(node.TrailingInlineText);
		}
		
		public virtual void VisitTableCaption(TableCaptionSyntax node)
		{
			this.VisitToken(node.TTableCaptionStart);
			this.Visit(node.InlineText);
			this.VisitToken(node.CRLF);
			this.VisitList(node.SpecialBlockOrParagraph);
		}
		
		public virtual void VisitTableRows(TableRowsSyntax node)
		{
			this.Visit(node.TableFirstRow);
			this.VisitList(node.TableRow);
		}
		
		public virtual void VisitTableFirstRow(TableFirstRowSyntax node)
		{
			this.VisitList(node.TableColumn);
		}
		
		public virtual void VisitTableRow(TableRowSyntax node)
		{
			this.VisitToken(node.TTableRowStart);
			this.Visit(node.InlineText);
			this.VisitToken(node.CRLF);
			this.VisitList(node.TableColumn);
		}
		
		public virtual void VisitTableColumn(TableColumnSyntax node)
		{
			this.Visit(node.TableSingleHeaderCell);
			this.Visit(node.TableHeaderCells);
			this.Visit(node.TableSingleCell);
			this.Visit(node.TableCells);
		}
		
		public virtual void VisitTableSingleHeaderCell(TableSingleHeaderCellSyntax node)
		{
			this.VisitToken(node.TExclamation);
			this.Visit(node.TableCell);
			this.VisitToken(node.CRLF);
			this.VisitList(node.SpecialBlockOrParagraph);
		}
		
		public virtual void VisitTableHeaderCells(TableHeaderCellsSyntax node)
		{
			this.VisitToken(node.TExclamation);
			this.VisitList(node.TableCell);
			this.VisitToken(node.CRLF);
			this.VisitList(node.SpecialBlockOrParagraph);
		}
		
		public virtual void VisitTableSingleCell(TableSingleCellSyntax node)
		{
			this.VisitToken(node.TBar);
			this.Visit(node.TableCell);
			this.VisitToken(node.CRLF);
			this.VisitList(node.SpecialBlockOrParagraph);
		}
		
		public virtual void VisitTableCells(TableCellsSyntax node)
		{
			this.VisitToken(node.TBar);
			this.VisitList(node.TableCell);
			this.VisitToken(node.CRLF);
			this.VisitList(node.SpecialBlockOrParagraph);
		}
		
		public virtual void VisitTableCell(TableCellSyntax node)
		{
			this.Visit(node.CellText);
			this.Visit(node.CellValue);
		}
		
		public virtual void VisitCellValue(CellValueSyntax node)
		{
			this.VisitToken(node.TBar);
			this.Visit(node.CellText);
		}
		
		public virtual void VisitParagraph(ParagraphSyntax node)
		{
			this.VisitList(node.TextLine);
		}
		
		public virtual void VisitTextLineInlineElementsWithComment(TextLineInlineElementsWithCommentSyntax node)
		{
			this.Visit(node.LeadingComment);
			this.VisitList(node.InlineTextElement);
			this.Visit(node.TrailingComment);
			this.VisitToken(node.CRLF);
		}
		
		public virtual void VisitTextLineComment(TextLineCommentSyntax node)
		{
			this.Visit(node.HtmlCommentList);
			this.VisitToken(node.CRLF);
		}
		
		public virtual void VisitTextElements(TextElementsSyntax node)
		{
			this.Visit(node.WikiFormat);
			this.Visit(node.WikiLink);
			this.Visit(node.WikiTemplate);
			this.Visit(node.WikiTemplateParam);
			this.Visit(node.NoWiki);
			this.Visit(node.HtmlReference);
			this.Visit(node.HtmlStyle);
			this.Visit(node.HtmlScript);
			this.Visit(node.HtmlTag);
		}
		
		public virtual void VisitInlineText(InlineTextSyntax node)
		{
			this.VisitList(node.InlineTextElementWithComment);
			this.Visit(node.TrailingComment);
		}
		
		public virtual void VisitInlineTextElementWithComment(InlineTextElementWithCommentSyntax node)
		{
			this.Visit(node.LeadingComment);
			this.Visit(node.InlineTextElement);
		}
		
		public virtual void VisitInlineTextElement(InlineTextElementSyntax node)
		{
			this.Visit(node.TextElements);
			this.Visit(node.InlineTextElements);
		}
		
		public virtual void VisitInlineTextElements(InlineTextElementsSyntax node)
		{
			this.VisitToken(node.InlineTextElements);
		}
		
		public virtual void VisitDefinitionText(DefinitionTextSyntax node)
		{
			this.VisitList(node.DefinitionTextElementWithComment);
			this.Visit(node.TrailingComment);
		}
		
		public virtual void VisitDefinitionTextElementWithComment(DefinitionTextElementWithCommentSyntax node)
		{
			this.Visit(node.LeadingComment);
			this.Visit(node.DefinitionTextElement);
		}
		
		public virtual void VisitDefinitionTextElement(DefinitionTextElementSyntax node)
		{
			this.Visit(node.TextElements);
			this.Visit(node.DefinitionTextElements);
		}
		
		public virtual void VisitDefinitionTextElements(DefinitionTextElementsSyntax node)
		{
			this.VisitToken(node.DefinitionTextElements);
		}
		
		public virtual void VisitHeadingText(HeadingTextSyntax node)
		{
			this.VisitList(node.HeadingTextWithComment);
			this.Visit(node.TrailingComment);
		}
		
		public virtual void VisitHeadingTextWithComment(HeadingTextWithCommentSyntax node)
		{
			this.Visit(node.LeadingComment);
			this.Visit(node.HeadingTextElement);
		}
		
		public virtual void VisitHeadingTextElement(HeadingTextElementSyntax node)
		{
			this.Visit(node.TextElements);
			this.Visit(node.HeadingTextElements);
		}
		
		public virtual void VisitHeadingTextElements(HeadingTextElementsSyntax node)
		{
			this.VisitToken(node.HeadingTextElements);
		}
		
		public virtual void VisitCellText(CellTextSyntax node)
		{
			this.VisitList(node.CellTextElementWithComment);
			this.Visit(node.TrailingComment);
		}
		
		public virtual void VisitCellTextElementWithComment(CellTextElementWithCommentSyntax node)
		{
			this.Visit(node.LeadingComment);
			this.Visit(node.CellTextElement);
		}
		
		public virtual void VisitCellTextElement(CellTextElementSyntax node)
		{
			this.Visit(node.TextElements);
			this.Visit(node.CellTextElements);
		}
		
		public virtual void VisitCellTextElements(CellTextElementsSyntax node)
		{
			this.VisitToken(node.CellTextElements);
		}
		
		public virtual void VisitLinkText(LinkTextSyntax node)
		{
			this.VisitList(node.LinkTextWithComment);
			this.Visit(node.TrailingComment);
		}
		
		public virtual void VisitLinkTextWithComment(LinkTextWithCommentSyntax node)
		{
			this.Visit(node.LeadingComment);
			this.Visit(node.LinkTextElement);
		}
		
		public virtual void VisitLinkTextElement(LinkTextElementSyntax node)
		{
			this.Visit(node.TextElements);
			this.Visit(node.LinkTextElements);
		}
		
		public virtual void VisitLinkTextElements(LinkTextElementsSyntax node)
		{
			this.VisitToken(node.LinkTextElements);
		}
		
		public virtual void VisitWikiFormat(WikiFormatSyntax node)
		{
			this.VisitToken(node.TFormat);
		}
		
		public virtual void VisitWikiLink(WikiLinkSyntax node)
		{
			this.Visit(node.WikiInternalLink);
			this.Visit(node.WikiExternalLink);
		}
		
		public virtual void VisitWikiInternalLink(WikiInternalLinkSyntax node)
		{
			this.VisitToken(node.TLinkStart);
			this.Visit(node.LinkText);
			this.VisitList(node.LinkTextPart);
			this.VisitToken(node.TLinkEnd);
		}
		
		public virtual void VisitWikiExternalLink(WikiExternalLinkSyntax node)
		{
			this.VisitToken(node.TExternalLinkStart);
			this.Visit(node.LinkText);
			this.VisitList(node.LinkTextPart);
			this.VisitToken(node.TExternalLinkEnd);
		}
		
		public virtual void VisitWikiTemplate(WikiTemplateSyntax node)
		{
			this.VisitToken(node.TTemplateStart);
			this.Visit(node.LinkText);
			this.VisitList(node.LinkTextPart);
			this.VisitToken(node.TTemplateEnd);
		}
		
		public virtual void VisitWikiTemplateParam(WikiTemplateParamSyntax node)
		{
			this.VisitToken(node.TTemplateParamStart);
			this.Visit(node.LinkText);
			this.VisitList(node.LinkTextPart);
			this.VisitToken(node.TTemplateParamEnd);
		}
		
		public virtual void VisitNoWiki(NoWikiSyntax node)
		{
			this.VisitToken(node.TNoWiki);
		}
		
		public virtual void VisitBarOrBarBar(BarOrBarBarSyntax node)
		{
			this.VisitToken(node.BarOrBarBar);
		}
		
		public virtual void VisitLinkTextPart(LinkTextPartSyntax node)
		{
			this.Visit(node.BarOrBarBar);
			this.Visit(node.LinkText);
		}
		
		public virtual void VisitHtmlReference(HtmlReferenceSyntax node)
		{
			this.VisitToken(node.HtmlReference);
		}
		
		public virtual void VisitHtmlCommentList(HtmlCommentListSyntax node)
		{
			this.VisitList(node.HtmlComment);
		}
		
		public virtual void VisitHtmlComment(HtmlCommentSyntax node)
		{
			this.VisitToken(node.THtmlComment);
		}
		
		public virtual void VisitHtmlStyle(HtmlStyleSyntax node)
		{
			this.VisitToken(node.THtmlStyle);
		}
		
		public virtual void VisitHtmlScript(HtmlScriptSyntax node)
		{
			this.VisitToken(node.THtmlScript);
		}
		
		public virtual void VisitHtmlTag(HtmlTagSyntax node)
		{
			this.Visit(node.HtmlTagOpen);
			this.Visit(node.HtmlTagClose);
			this.Visit(node.HtmlTagEmpty);
		}
		
		public virtual void VisitHtmlTagOpen(HtmlTagOpenSyntax node)
		{
			this.VisitToken(node.TTagStart);
			this.Visit(node.LeadingWhitespace);
			this.Visit(node.HtmlTagName);
			this.VisitList(node.HtmlAttribute);
			this.Visit(node.TrailingWhitespace);
			this.VisitToken(node.TTagEnd);
		}
		
		public virtual void VisitHtmlTagClose(HtmlTagCloseSyntax node)
		{
			this.VisitToken(node.TEndTagStart);
			this.Visit(node.LeadingWhitespace);
			this.Visit(node.HtmlTagName);
			this.VisitList(node.HtmlAttribute);
			this.Visit(node.TrailingWhitespace);
			this.VisitToken(node.TEndTagEnd);
		}
		
		public virtual void VisitHtmlTagEmpty(HtmlTagEmptySyntax node)
		{
			this.VisitToken(node.TTagStart);
			this.Visit(node.LeadingWhitespace);
			this.Visit(node.HtmlTagName);
			this.VisitList(node.HtmlAttribute);
			this.Visit(node.TrailingWhitespace);
			this.VisitToken(node.TTagCloseEnd);
		}
		
		public virtual void VisitHtmlAttributeWithValue(HtmlAttributeWithValueSyntax node)
		{
			this.Visit(node.LeadingWhitespace);
			this.Visit(node.HtmlAttributeName);
			this.Visit(node.WhitespaceBeforeEquals);
			this.VisitToken(node.TAttributeEquals);
			this.Visit(node.WhitespaceAfterEquals);
			this.Visit(node.HtmlAttributeValue);
		}
		
		public virtual void VisitHtmlAttributeWithNoValue(HtmlAttributeWithNoValueSyntax node)
		{
			this.Visit(node.LeadingWhitespace);
			this.Visit(node.HtmlAttributeName);
		}
		
		public virtual void VisitHtmlAttributeName(HtmlAttributeNameSyntax node)
		{
			this.VisitToken(node.TTagName);
		}
		
		public virtual void VisitHtmlAttributeValue(HtmlAttributeValueSyntax node)
		{
			this.VisitToken(node.TAttributeValue);
		}
		
		public virtual void VisitHtmlTagName(HtmlTagNameSyntax node)
		{
			this.VisitToken(node.TTagName);
		}
		
		public virtual void VisitWhitespaceList(WhitespaceListSyntax node)
		{
			this.VisitList(node.Whitespace);
		}
		
		public virtual void VisitWhitespace(WhitespaceSyntax node)
		{
			this.VisitToken(node.Whitespace);
		}
	}

	public interface IMediaWikiSyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitSpecialBlockOrParagraph(SpecialBlockOrParagraphSyntax node);
		
		TResult VisitSpecialBlockWithComment(SpecialBlockWithCommentSyntax node);
		
		TResult VisitSpecialBlock(SpecialBlockSyntax node);
		
		TResult VisitHeading(HeadingSyntax node);
		
		TResult VisitHeadingLevel(HeadingLevelSyntax node);
		
		TResult VisitHorizontalRule(HorizontalRuleSyntax node);
		
		TResult VisitCodeBlock(CodeBlockSyntax node);
		
		TResult VisitSpaceBlock(SpaceBlockSyntax node);
		
		TResult VisitWikiList(WikiListSyntax node);
		
		TResult VisitListItem(ListItemSyntax node);
		
		TResult VisitNormalListItem(NormalListItemSyntax node);
		
		TResult VisitDefinitionItem(DefinitionItemSyntax node);
		
		TResult VisitWikiTable(WikiTableSyntax node);
		
		TResult VisitTableCaption(TableCaptionSyntax node);
		
		TResult VisitTableRows(TableRowsSyntax node);
		
		TResult VisitTableFirstRow(TableFirstRowSyntax node);
		
		TResult VisitTableRow(TableRowSyntax node);
		
		TResult VisitTableColumn(TableColumnSyntax node);
		
		TResult VisitTableSingleHeaderCell(TableSingleHeaderCellSyntax node);
		
		TResult VisitTableHeaderCells(TableHeaderCellsSyntax node);
		
		TResult VisitTableSingleCell(TableSingleCellSyntax node);
		
		TResult VisitTableCells(TableCellsSyntax node);
		
		TResult VisitTableCell(TableCellSyntax node);
		
		TResult VisitCellValue(CellValueSyntax node);
		
		TResult VisitParagraph(ParagraphSyntax node);
		
		TResult VisitTextLineInlineElementsWithComment(TextLineInlineElementsWithCommentSyntax node);
		
		TResult VisitTextLineComment(TextLineCommentSyntax node);
		
		TResult VisitTextElements(TextElementsSyntax node);
		
		TResult VisitInlineText(InlineTextSyntax node);
		
		TResult VisitInlineTextElementWithComment(InlineTextElementWithCommentSyntax node);
		
		TResult VisitInlineTextElement(InlineTextElementSyntax node);
		
		TResult VisitInlineTextElements(InlineTextElementsSyntax node);
		
		TResult VisitDefinitionText(DefinitionTextSyntax node);
		
		TResult VisitDefinitionTextElementWithComment(DefinitionTextElementWithCommentSyntax node);
		
		TResult VisitDefinitionTextElement(DefinitionTextElementSyntax node);
		
		TResult VisitDefinitionTextElements(DefinitionTextElementsSyntax node);
		
		TResult VisitHeadingText(HeadingTextSyntax node);
		
		TResult VisitHeadingTextWithComment(HeadingTextWithCommentSyntax node);
		
		TResult VisitHeadingTextElement(HeadingTextElementSyntax node);
		
		TResult VisitHeadingTextElements(HeadingTextElementsSyntax node);
		
		TResult VisitCellText(CellTextSyntax node);
		
		TResult VisitCellTextElementWithComment(CellTextElementWithCommentSyntax node);
		
		TResult VisitCellTextElement(CellTextElementSyntax node);
		
		TResult VisitCellTextElements(CellTextElementsSyntax node);
		
		TResult VisitLinkText(LinkTextSyntax node);
		
		TResult VisitLinkTextWithComment(LinkTextWithCommentSyntax node);
		
		TResult VisitLinkTextElement(LinkTextElementSyntax node);
		
		TResult VisitLinkTextElements(LinkTextElementsSyntax node);
		
		TResult VisitWikiFormat(WikiFormatSyntax node);
		
		TResult VisitWikiLink(WikiLinkSyntax node);
		
		TResult VisitWikiInternalLink(WikiInternalLinkSyntax node);
		
		TResult VisitWikiExternalLink(WikiExternalLinkSyntax node);
		
		TResult VisitWikiTemplate(WikiTemplateSyntax node);
		
		TResult VisitWikiTemplateParam(WikiTemplateParamSyntax node);
		
		TResult VisitNoWiki(NoWikiSyntax node);
		
		TResult VisitBarOrBarBar(BarOrBarBarSyntax node);
		
		TResult VisitLinkTextPart(LinkTextPartSyntax node);
		
		TResult VisitHtmlReference(HtmlReferenceSyntax node);
		
		TResult VisitHtmlCommentList(HtmlCommentListSyntax node);
		
		TResult VisitHtmlComment(HtmlCommentSyntax node);
		
		TResult VisitHtmlStyle(HtmlStyleSyntax node);
		
		TResult VisitHtmlScript(HtmlScriptSyntax node);
		
		TResult VisitHtmlTag(HtmlTagSyntax node);
		
		TResult VisitHtmlTagOpen(HtmlTagOpenSyntax node);
		
		TResult VisitHtmlTagClose(HtmlTagCloseSyntax node);
		
		TResult VisitHtmlTagEmpty(HtmlTagEmptySyntax node);
		
		TResult VisitHtmlAttributeWithValue(HtmlAttributeWithValueSyntax node);
		
		TResult VisitHtmlAttributeWithNoValue(HtmlAttributeWithNoValueSyntax node);
		
		TResult VisitHtmlAttributeName(HtmlAttributeNameSyntax node);
		
		TResult VisitHtmlAttributeValue(HtmlAttributeValueSyntax node);
		
		TResult VisitHtmlTagName(HtmlTagNameSyntax node);
		
		TResult VisitWhitespaceList(WhitespaceListSyntax node);
		
		TResult VisitWhitespace(WhitespaceSyntax node);
	}
	
	public class MediaWikiSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, IMediaWikiSyntaxVisitor<TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSpecialBlockOrParagraph(SpecialBlockOrParagraphSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSpecialBlockWithComment(SpecialBlockWithCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSpecialBlock(SpecialBlockSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHeading(HeadingSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHeadingLevel(HeadingLevelSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHorizontalRule(HorizontalRuleSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCodeBlock(CodeBlockSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSpaceBlock(SpaceBlockSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWikiList(WikiListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitListItem(ListItemSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNormalListItem(NormalListItemSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDefinitionItem(DefinitionItemSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWikiTable(WikiTableSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableCaption(TableCaptionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableRows(TableRowsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableFirstRow(TableFirstRowSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableRow(TableRowSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableColumn(TableColumnSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableSingleHeaderCell(TableSingleHeaderCellSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableHeaderCells(TableHeaderCellsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableSingleCell(TableSingleCellSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableCells(TableCellsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTableCell(TableCellSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCellValue(CellValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParagraph(ParagraphSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTextLineInlineElementsWithComment(TextLineInlineElementsWithCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTextLineComment(TextLineCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTextElements(TextElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInlineText(InlineTextSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInlineTextElementWithComment(InlineTextElementWithCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInlineTextElement(InlineTextElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInlineTextElements(InlineTextElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDefinitionText(DefinitionTextSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDefinitionTextElementWithComment(DefinitionTextElementWithCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDefinitionTextElement(DefinitionTextElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDefinitionTextElements(DefinitionTextElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHeadingText(HeadingTextSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHeadingTextWithComment(HeadingTextWithCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHeadingTextElement(HeadingTextElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHeadingTextElements(HeadingTextElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCellText(CellTextSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCellTextElementWithComment(CellTextElementWithCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCellTextElement(CellTextElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCellTextElements(CellTextElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLinkText(LinkTextSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLinkTextWithComment(LinkTextWithCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLinkTextElement(LinkTextElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLinkTextElements(LinkTextElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWikiFormat(WikiFormatSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWikiLink(WikiLinkSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWikiInternalLink(WikiInternalLinkSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWikiExternalLink(WikiExternalLinkSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWikiTemplate(WikiTemplateSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWikiTemplateParam(WikiTemplateParamSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNoWiki(NoWikiSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBarOrBarBar(BarOrBarBarSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLinkTextPart(LinkTextPartSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlReference(HtmlReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlCommentList(HtmlCommentListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlComment(HtmlCommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlStyle(HtmlStyleSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlScript(HtmlScriptSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlTag(HtmlTagSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlTagOpen(HtmlTagOpenSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlTagClose(HtmlTagCloseSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlTagEmpty(HtmlTagEmptySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlAttributeWithValue(HtmlAttributeWithValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlAttributeWithNoValue(HtmlAttributeWithNoValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlAttributeName(HtmlAttributeNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlAttributeValue(HtmlAttributeValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHtmlTagName(HtmlTagNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWhitespaceList(WhitespaceListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWhitespace(WhitespaceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class MediaWikiSyntaxRewriter : SyntaxRewriter, IMediaWikiSyntaxVisitor<SyntaxNode>
	{
	    public MediaWikiSyntaxRewriter(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var specialBlockOrParagraph = this.VisitList(node.SpecialBlockOrParagraph);
		    var eof = this.VisitToken(node.Eof);
			return node.Update(specialBlockOrParagraph, eof);
		}
		
		public virtual SyntaxNode VisitSpecialBlockOrParagraph(SpecialBlockOrParagraphSyntax node)
		{
			var oldSpecialBlockWithComment = node.SpecialBlockWithComment;
			if (oldSpecialBlockWithComment != null)
			{
			    var newSpecialBlockWithComment = (SpecialBlockWithCommentSyntax)this.Visit(oldSpecialBlockWithComment);
				return node.Update(newSpecialBlockWithComment);
			}
			var oldParagraph = node.Paragraph;
			if (oldParagraph != null)
			{
			    var newParagraph = (ParagraphSyntax)this.Visit(oldParagraph);
				return node.Update(newParagraph);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSpecialBlockWithComment(SpecialBlockWithCommentSyntax node)
		{
		    var leadingComment = (HtmlCommentListSyntax)this.Visit(node.LeadingComment);
		    var specialBlock = (SpecialBlockSyntax)this.Visit(node.SpecialBlock);
		    var trailingComment = (HtmlCommentListSyntax)this.Visit(node.TrailingComment);
		    var crlf = this.VisitToken(node.CRLF);
			return node.Update(leadingComment, specialBlock, trailingComment, crlf);
		}
		
		public virtual SyntaxNode VisitSpecialBlock(SpecialBlockSyntax node)
		{
			var oldHeading = node.Heading;
			if (oldHeading != null)
			{
			    var newHeading = (HeadingSyntax)this.Visit(oldHeading);
				return node.Update(newHeading);
			}
			var oldHorizontalRule = node.HorizontalRule;
			if (oldHorizontalRule != null)
			{
			    var newHorizontalRule = (HorizontalRuleSyntax)this.Visit(oldHorizontalRule);
				return node.Update(newHorizontalRule);
			}
			var oldCodeBlock = node.CodeBlock;
			if (oldCodeBlock != null)
			{
			    var newCodeBlock = (CodeBlockSyntax)this.Visit(oldCodeBlock);
				return node.Update(newCodeBlock);
			}
			var oldWikiList = node.WikiList;
			if (oldWikiList != null)
			{
			    var newWikiList = (WikiListSyntax)this.Visit(oldWikiList);
				return node.Update(newWikiList);
			}
			var oldWikiTable = node.WikiTable;
			if (oldWikiTable != null)
			{
			    var newWikiTable = (WikiTableSyntax)this.Visit(oldWikiTable);
				return node.Update(newWikiTable);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitHeading(HeadingSyntax node)
		{
		    var headingStart = (HeadingLevelSyntax)this.Visit(node.HeadingStart);
		    var headingText = (HeadingTextSyntax)this.Visit(node.HeadingText);
		    var headingEnd = (HeadingLevelSyntax)this.Visit(node.HeadingEnd);
		    var inlineText = (InlineTextSyntax)this.Visit(node.InlineText);
			return node.Update(headingStart, headingText, headingEnd, inlineText);
		}
		
		public virtual SyntaxNode VisitHeadingLevel(HeadingLevelSyntax node)
		{
		    var tHeading = this.VisitToken(node.THeading);
			return node.Update(tHeading);
		}
		
		public virtual SyntaxNode VisitHorizontalRule(HorizontalRuleSyntax node)
		{
		    var tHorizontalLine = this.VisitToken(node.THorizontalLine);
		    var inlineText = (InlineTextSyntax)this.Visit(node.InlineText);
			return node.Update(tHorizontalLine, inlineText);
		}
		
		public virtual SyntaxNode VisitCodeBlock(CodeBlockSyntax node)
		{
		    var spaceBlock = this.VisitList(node.SpaceBlock);
			return node.Update(spaceBlock);
		}
		
		public virtual SyntaxNode VisitSpaceBlock(SpaceBlockSyntax node)
		{
		    var tSpaceBlockStart = this.VisitToken(node.TSpaceBlockStart);
		    var inlineText = (InlineTextSyntax)this.Visit(node.InlineText);
			return node.Update(tSpaceBlockStart, inlineText);
		}
		
		public virtual SyntaxNode VisitWikiList(WikiListSyntax node)
		{
		    var listItem = this.VisitList(node.ListItem);
			return node.Update(listItem);
		}
		
		public virtual SyntaxNode VisitListItem(ListItemSyntax node)
		{
			var oldNormalListItem = node.NormalListItem;
			if (oldNormalListItem != null)
			{
			    var newNormalListItem = (NormalListItemSyntax)this.Visit(oldNormalListItem);
				return node.Update(newNormalListItem);
			}
			var oldDefinitionItem = node.DefinitionItem;
			if (oldDefinitionItem != null)
			{
			    var newDefinitionItem = (DefinitionItemSyntax)this.Visit(oldDefinitionItem);
				return node.Update(newDefinitionItem);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitNormalListItem(NormalListItemSyntax node)
		{
		    var tListStart = this.VisitToken(node.TListStart);
		    var inlineText = (InlineTextSyntax)this.Visit(node.InlineText);
			return node.Update(tListStart, inlineText);
		}
		
		public virtual SyntaxNode VisitDefinitionItem(DefinitionItemSyntax node)
		{
		    var tDefinitionStart = this.VisitToken(node.TDefinitionStart);
		    var definitionText = (DefinitionTextSyntax)this.Visit(node.DefinitionText);
		    var tColon = this.VisitToken(node.TColon);
		    var inlineText = (InlineTextSyntax)this.Visit(node.InlineText);
			return node.Update(tDefinitionStart, definitionText, tColon, inlineText);
		}
		
		public virtual SyntaxNode VisitWikiTable(WikiTableSyntax node)
		{
		    var tTableStart = this.VisitToken(node.TTableStart);
		    var leadingInlineText = (InlineTextSyntax)this.Visit(node.LeadingInlineText);
		    var crlf = this.VisitToken(node.CRLF);
		    var tableCaption = (TableCaptionSyntax)this.Visit(node.TableCaption);
		    var tableRows = (TableRowsSyntax)this.Visit(node.TableRows);
		    var tTableEnd = this.VisitToken(node.TTableEnd);
		    var trailingInlineText = (InlineTextSyntax)this.Visit(node.TrailingInlineText);
			return node.Update(tTableStart, leadingInlineText, crlf, tableCaption, tableRows, tTableEnd, trailingInlineText);
		}
		
		public virtual SyntaxNode VisitTableCaption(TableCaptionSyntax node)
		{
		    var tTableCaptionStart = this.VisitToken(node.TTableCaptionStart);
		    var inlineText = (InlineTextSyntax)this.Visit(node.InlineText);
		    var crlf = this.VisitToken(node.CRLF);
		    var specialBlockOrParagraph = this.VisitList(node.SpecialBlockOrParagraph);
			return node.Update(tTableCaptionStart, inlineText, crlf, specialBlockOrParagraph);
		}
		
		public virtual SyntaxNode VisitTableRows(TableRowsSyntax node)
		{
		    var tableFirstRow = (TableFirstRowSyntax)this.Visit(node.TableFirstRow);
		    var tableRow = this.VisitList(node.TableRow);
			return node.Update(tableFirstRow, tableRow);
		}
		
		public virtual SyntaxNode VisitTableFirstRow(TableFirstRowSyntax node)
		{
		    var tableColumn = this.VisitList(node.TableColumn);
			return node.Update(tableColumn);
		}
		
		public virtual SyntaxNode VisitTableRow(TableRowSyntax node)
		{
		    var tTableRowStart = this.VisitToken(node.TTableRowStart);
		    var inlineText = (InlineTextSyntax)this.Visit(node.InlineText);
		    var crlf = this.VisitToken(node.CRLF);
		    var tableColumn = this.VisitList(node.TableColumn);
			return node.Update(tTableRowStart, inlineText, crlf, tableColumn);
		}
		
		public virtual SyntaxNode VisitTableColumn(TableColumnSyntax node)
		{
			var oldTableSingleHeaderCell = node.TableSingleHeaderCell;
			if (oldTableSingleHeaderCell != null)
			{
			    var newTableSingleHeaderCell = (TableSingleHeaderCellSyntax)this.Visit(oldTableSingleHeaderCell);
				return node.Update(newTableSingleHeaderCell);
			}
			var oldTableHeaderCells = node.TableHeaderCells;
			if (oldTableHeaderCells != null)
			{
			    var newTableHeaderCells = (TableHeaderCellsSyntax)this.Visit(oldTableHeaderCells);
				return node.Update(newTableHeaderCells);
			}
			var oldTableSingleCell = node.TableSingleCell;
			if (oldTableSingleCell != null)
			{
			    var newTableSingleCell = (TableSingleCellSyntax)this.Visit(oldTableSingleCell);
				return node.Update(newTableSingleCell);
			}
			var oldTableCells = node.TableCells;
			if (oldTableCells != null)
			{
			    var newTableCells = (TableCellsSyntax)this.Visit(oldTableCells);
				return node.Update(newTableCells);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTableSingleHeaderCell(TableSingleHeaderCellSyntax node)
		{
		    var tExclamation = this.VisitToken(node.TExclamation);
		    var tableCell = (TableCellSyntax)this.Visit(node.TableCell);
		    var crlf = this.VisitToken(node.CRLF);
		    var specialBlockOrParagraph = this.VisitList(node.SpecialBlockOrParagraph);
			return node.Update(tExclamation, tableCell, crlf, specialBlockOrParagraph);
		}
		
		public virtual SyntaxNode VisitTableHeaderCells(TableHeaderCellsSyntax node)
		{
		    var tExclamation = this.VisitToken(node.TExclamation);
		    var tableCell = this.VisitList(node.TableCell);
		    var crlf = this.VisitToken(node.CRLF);
		    var specialBlockOrParagraph = this.VisitList(node.SpecialBlockOrParagraph);
			return node.Update(tExclamation, tableCell, crlf, specialBlockOrParagraph);
		}
		
		public virtual SyntaxNode VisitTableSingleCell(TableSingleCellSyntax node)
		{
		    var tBar = this.VisitToken(node.TBar);
		    var tableCell = (TableCellSyntax)this.Visit(node.TableCell);
		    var crlf = this.VisitToken(node.CRLF);
		    var specialBlockOrParagraph = this.VisitList(node.SpecialBlockOrParagraph);
			return node.Update(tBar, tableCell, crlf, specialBlockOrParagraph);
		}
		
		public virtual SyntaxNode VisitTableCells(TableCellsSyntax node)
		{
		    var tBar = this.VisitToken(node.TBar);
		    var tableCell = this.VisitList(node.TableCell);
		    var crlf = this.VisitToken(node.CRLF);
		    var specialBlockOrParagraph = this.VisitList(node.SpecialBlockOrParagraph);
			return node.Update(tBar, tableCell, crlf, specialBlockOrParagraph);
		}
		
		public virtual SyntaxNode VisitTableCell(TableCellSyntax node)
		{
		    var cellText = (CellTextSyntax)this.Visit(node.CellText);
		    var cellValue = (CellValueSyntax)this.Visit(node.CellValue);
			return node.Update(cellText, cellValue);
		}
		
		public virtual SyntaxNode VisitCellValue(CellValueSyntax node)
		{
		    var tBar = this.VisitToken(node.TBar);
		    var cellText = (CellTextSyntax)this.Visit(node.CellText);
			return node.Update(tBar, cellText);
		}
		
		public virtual SyntaxNode VisitParagraph(ParagraphSyntax node)
		{
		    var textLine = this.VisitList(node.TextLine);
			return node.Update(textLine);
		}
		
		public virtual SyntaxNode VisitTextLineInlineElementsWithComment(TextLineInlineElementsWithCommentSyntax node)
		{
		    var leadingComment = (HtmlCommentListSyntax)this.Visit(node.LeadingComment);
		    var inlineTextElement = this.VisitList(node.InlineTextElement);
		    var trailingComment = (HtmlCommentListSyntax)this.Visit(node.TrailingComment);
		    var crlf = this.VisitToken(node.CRLF);
			return node.Update(leadingComment, inlineTextElement, trailingComment, crlf);
		}
		
		public virtual SyntaxNode VisitTextLineComment(TextLineCommentSyntax node)
		{
		    var htmlCommentList = (HtmlCommentListSyntax)this.Visit(node.HtmlCommentList);
		    var crlf = this.VisitToken(node.CRLF);
			return node.Update(htmlCommentList, crlf);
		}
		
		public virtual SyntaxNode VisitTextElements(TextElementsSyntax node)
		{
			var oldWikiFormat = node.WikiFormat;
			if (oldWikiFormat != null)
			{
			    var newWikiFormat = (WikiFormatSyntax)this.Visit(oldWikiFormat);
				return node.Update(newWikiFormat);
			}
			var oldWikiLink = node.WikiLink;
			if (oldWikiLink != null)
			{
			    var newWikiLink = (WikiLinkSyntax)this.Visit(oldWikiLink);
				return node.Update(newWikiLink);
			}
			var oldWikiTemplate = node.WikiTemplate;
			if (oldWikiTemplate != null)
			{
			    var newWikiTemplate = (WikiTemplateSyntax)this.Visit(oldWikiTemplate);
				return node.Update(newWikiTemplate);
			}
			var oldWikiTemplateParam = node.WikiTemplateParam;
			if (oldWikiTemplateParam != null)
			{
			    var newWikiTemplateParam = (WikiTemplateParamSyntax)this.Visit(oldWikiTemplateParam);
				return node.Update(newWikiTemplateParam);
			}
			var oldNoWiki = node.NoWiki;
			if (oldNoWiki != null)
			{
			    var newNoWiki = (NoWikiSyntax)this.Visit(oldNoWiki);
				return node.Update(newNoWiki);
			}
			var oldHtmlReference = node.HtmlReference;
			if (oldHtmlReference != null)
			{
			    var newHtmlReference = (HtmlReferenceSyntax)this.Visit(oldHtmlReference);
				return node.Update(newHtmlReference);
			}
			var oldHtmlStyle = node.HtmlStyle;
			if (oldHtmlStyle != null)
			{
			    var newHtmlStyle = (HtmlStyleSyntax)this.Visit(oldHtmlStyle);
				return node.Update(newHtmlStyle);
			}
			var oldHtmlScript = node.HtmlScript;
			if (oldHtmlScript != null)
			{
			    var newHtmlScript = (HtmlScriptSyntax)this.Visit(oldHtmlScript);
				return node.Update(newHtmlScript);
			}
			var oldHtmlTag = node.HtmlTag;
			if (oldHtmlTag != null)
			{
			    var newHtmlTag = (HtmlTagSyntax)this.Visit(oldHtmlTag);
				return node.Update(newHtmlTag);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitInlineText(InlineTextSyntax node)
		{
		    var inlineTextElementWithComment = this.VisitList(node.InlineTextElementWithComment);
		    var trailingComment = (HtmlCommentListSyntax)this.Visit(node.TrailingComment);
			return node.Update(inlineTextElementWithComment, trailingComment);
		}
		
		public virtual SyntaxNode VisitInlineTextElementWithComment(InlineTextElementWithCommentSyntax node)
		{
		    var leadingComment = (HtmlCommentListSyntax)this.Visit(node.LeadingComment);
		    var inlineTextElement = (InlineTextElementSyntax)this.Visit(node.InlineTextElement);
			return node.Update(leadingComment, inlineTextElement);
		}
		
		public virtual SyntaxNode VisitInlineTextElement(InlineTextElementSyntax node)
		{
			var oldTextElements = node.TextElements;
			if (oldTextElements != null)
			{
			    var newTextElements = (TextElementsSyntax)this.Visit(oldTextElements);
				return node.Update(newTextElements);
			}
			var oldInlineTextElements = node.InlineTextElements;
			if (oldInlineTextElements != null)
			{
			    var newInlineTextElements = (InlineTextElementsSyntax)this.Visit(oldInlineTextElements);
				return node.Update(newInlineTextElements);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitInlineTextElements(InlineTextElementsSyntax node)
		{
		    var inlineTextElements = this.VisitToken(node.InlineTextElements);
			return node.Update(inlineTextElements);
		}
		
		public virtual SyntaxNode VisitDefinitionText(DefinitionTextSyntax node)
		{
		    var definitionTextElementWithComment = this.VisitList(node.DefinitionTextElementWithComment);
		    var trailingComment = (HtmlCommentListSyntax)this.Visit(node.TrailingComment);
			return node.Update(definitionTextElementWithComment, trailingComment);
		}
		
		public virtual SyntaxNode VisitDefinitionTextElementWithComment(DefinitionTextElementWithCommentSyntax node)
		{
		    var leadingComment = (HtmlCommentListSyntax)this.Visit(node.LeadingComment);
		    var definitionTextElement = (DefinitionTextElementSyntax)this.Visit(node.DefinitionTextElement);
			return node.Update(leadingComment, definitionTextElement);
		}
		
		public virtual SyntaxNode VisitDefinitionTextElement(DefinitionTextElementSyntax node)
		{
			var oldTextElements = node.TextElements;
			if (oldTextElements != null)
			{
			    var newTextElements = (TextElementsSyntax)this.Visit(oldTextElements);
				return node.Update(newTextElements);
			}
			var oldDefinitionTextElements = node.DefinitionTextElements;
			if (oldDefinitionTextElements != null)
			{
			    var newDefinitionTextElements = (DefinitionTextElementsSyntax)this.Visit(oldDefinitionTextElements);
				return node.Update(newDefinitionTextElements);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitDefinitionTextElements(DefinitionTextElementsSyntax node)
		{
		    var definitionTextElements = this.VisitToken(node.DefinitionTextElements);
			return node.Update(definitionTextElements);
		}
		
		public virtual SyntaxNode VisitHeadingText(HeadingTextSyntax node)
		{
		    var headingTextWithComment = this.VisitList(node.HeadingTextWithComment);
		    var trailingComment = (HtmlCommentListSyntax)this.Visit(node.TrailingComment);
			return node.Update(headingTextWithComment, trailingComment);
		}
		
		public virtual SyntaxNode VisitHeadingTextWithComment(HeadingTextWithCommentSyntax node)
		{
		    var leadingComment = (HtmlCommentListSyntax)this.Visit(node.LeadingComment);
		    var headingTextElement = (HeadingTextElementSyntax)this.Visit(node.HeadingTextElement);
			return node.Update(leadingComment, headingTextElement);
		}
		
		public virtual SyntaxNode VisitHeadingTextElement(HeadingTextElementSyntax node)
		{
			var oldTextElements = node.TextElements;
			if (oldTextElements != null)
			{
			    var newTextElements = (TextElementsSyntax)this.Visit(oldTextElements);
				return node.Update(newTextElements);
			}
			var oldHeadingTextElements = node.HeadingTextElements;
			if (oldHeadingTextElements != null)
			{
			    var newHeadingTextElements = (HeadingTextElementsSyntax)this.Visit(oldHeadingTextElements);
				return node.Update(newHeadingTextElements);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitHeadingTextElements(HeadingTextElementsSyntax node)
		{
		    var headingTextElements = this.VisitToken(node.HeadingTextElements);
			return node.Update(headingTextElements);
		}
		
		public virtual SyntaxNode VisitCellText(CellTextSyntax node)
		{
		    var cellTextElementWithComment = this.VisitList(node.CellTextElementWithComment);
		    var trailingComment = (HtmlCommentListSyntax)this.Visit(node.TrailingComment);
			return node.Update(cellTextElementWithComment, trailingComment);
		}
		
		public virtual SyntaxNode VisitCellTextElementWithComment(CellTextElementWithCommentSyntax node)
		{
		    var leadingComment = (HtmlCommentListSyntax)this.Visit(node.LeadingComment);
		    var cellTextElement = (CellTextElementSyntax)this.Visit(node.CellTextElement);
			return node.Update(leadingComment, cellTextElement);
		}
		
		public virtual SyntaxNode VisitCellTextElement(CellTextElementSyntax node)
		{
			var oldTextElements = node.TextElements;
			if (oldTextElements != null)
			{
			    var newTextElements = (TextElementsSyntax)this.Visit(oldTextElements);
				return node.Update(newTextElements);
			}
			var oldCellTextElements = node.CellTextElements;
			if (oldCellTextElements != null)
			{
			    var newCellTextElements = (CellTextElementsSyntax)this.Visit(oldCellTextElements);
				return node.Update(newCellTextElements);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitCellTextElements(CellTextElementsSyntax node)
		{
		    var cellTextElements = this.VisitToken(node.CellTextElements);
			return node.Update(cellTextElements);
		}
		
		public virtual SyntaxNode VisitLinkText(LinkTextSyntax node)
		{
		    var linkTextWithComment = this.VisitList(node.LinkTextWithComment);
		    var trailingComment = (HtmlCommentListSyntax)this.Visit(node.TrailingComment);
			return node.Update(linkTextWithComment, trailingComment);
		}
		
		public virtual SyntaxNode VisitLinkTextWithComment(LinkTextWithCommentSyntax node)
		{
		    var leadingComment = (HtmlCommentListSyntax)this.Visit(node.LeadingComment);
		    var linkTextElement = (LinkTextElementSyntax)this.Visit(node.LinkTextElement);
			return node.Update(leadingComment, linkTextElement);
		}
		
		public virtual SyntaxNode VisitLinkTextElement(LinkTextElementSyntax node)
		{
			var oldTextElements = node.TextElements;
			if (oldTextElements != null)
			{
			    var newTextElements = (TextElementsSyntax)this.Visit(oldTextElements);
				return node.Update(newTextElements);
			}
			var oldLinkTextElements = node.LinkTextElements;
			if (oldLinkTextElements != null)
			{
			    var newLinkTextElements = (LinkTextElementsSyntax)this.Visit(oldLinkTextElements);
				return node.Update(newLinkTextElements);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitLinkTextElements(LinkTextElementsSyntax node)
		{
		    var linkTextElements = this.VisitToken(node.LinkTextElements);
			return node.Update(linkTextElements);
		}
		
		public virtual SyntaxNode VisitWikiFormat(WikiFormatSyntax node)
		{
		    var tFormat = this.VisitToken(node.TFormat);
			return node.Update(tFormat);
		}
		
		public virtual SyntaxNode VisitWikiLink(WikiLinkSyntax node)
		{
			var oldWikiInternalLink = node.WikiInternalLink;
			if (oldWikiInternalLink != null)
			{
			    var newWikiInternalLink = (WikiInternalLinkSyntax)this.Visit(oldWikiInternalLink);
				return node.Update(newWikiInternalLink);
			}
			var oldWikiExternalLink = node.WikiExternalLink;
			if (oldWikiExternalLink != null)
			{
			    var newWikiExternalLink = (WikiExternalLinkSyntax)this.Visit(oldWikiExternalLink);
				return node.Update(newWikiExternalLink);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitWikiInternalLink(WikiInternalLinkSyntax node)
		{
		    var tLinkStart = this.VisitToken(node.TLinkStart);
		    var linkText = (LinkTextSyntax)this.Visit(node.LinkText);
		    var linkTextPart = this.VisitList(node.LinkTextPart);
		    var tLinkEnd = this.VisitToken(node.TLinkEnd);
			return node.Update(tLinkStart, linkText, linkTextPart, tLinkEnd);
		}
		
		public virtual SyntaxNode VisitWikiExternalLink(WikiExternalLinkSyntax node)
		{
		    var tExternalLinkStart = this.VisitToken(node.TExternalLinkStart);
		    var linkText = (LinkTextSyntax)this.Visit(node.LinkText);
		    var linkTextPart = this.VisitList(node.LinkTextPart);
		    var tExternalLinkEnd = this.VisitToken(node.TExternalLinkEnd);
			return node.Update(tExternalLinkStart, linkText, linkTextPart, tExternalLinkEnd);
		}
		
		public virtual SyntaxNode VisitWikiTemplate(WikiTemplateSyntax node)
		{
		    var tTemplateStart = this.VisitToken(node.TTemplateStart);
		    var linkText = (LinkTextSyntax)this.Visit(node.LinkText);
		    var linkTextPart = this.VisitList(node.LinkTextPart);
		    var tTemplateEnd = this.VisitToken(node.TTemplateEnd);
			return node.Update(tTemplateStart, linkText, linkTextPart, tTemplateEnd);
		}
		
		public virtual SyntaxNode VisitWikiTemplateParam(WikiTemplateParamSyntax node)
		{
		    var tTemplateParamStart = this.VisitToken(node.TTemplateParamStart);
		    var linkText = (LinkTextSyntax)this.Visit(node.LinkText);
		    var linkTextPart = this.VisitList(node.LinkTextPart);
		    var tTemplateParamEnd = this.VisitToken(node.TTemplateParamEnd);
			return node.Update(tTemplateParamStart, linkText, linkTextPart, tTemplateParamEnd);
		}
		
		public virtual SyntaxNode VisitNoWiki(NoWikiSyntax node)
		{
		    var tNoWiki = this.VisitToken(node.TNoWiki);
			return node.Update(tNoWiki);
		}
		
		public virtual SyntaxNode VisitBarOrBarBar(BarOrBarBarSyntax node)
		{
		    var barOrBarBar = this.VisitToken(node.BarOrBarBar);
			return node.Update(barOrBarBar);
		}
		
		public virtual SyntaxNode VisitLinkTextPart(LinkTextPartSyntax node)
		{
		    var barOrBarBar = (BarOrBarBarSyntax)this.Visit(node.BarOrBarBar);
		    var linkText = (LinkTextSyntax)this.Visit(node.LinkText);
			return node.Update(barOrBarBar, linkText);
		}
		
		public virtual SyntaxNode VisitHtmlReference(HtmlReferenceSyntax node)
		{
		    var htmlReference = this.VisitToken(node.HtmlReference);
			return node.Update(htmlReference);
		}
		
		public virtual SyntaxNode VisitHtmlCommentList(HtmlCommentListSyntax node)
		{
		    var htmlComment = this.VisitList(node.HtmlComment);
			return node.Update(htmlComment);
		}
		
		public virtual SyntaxNode VisitHtmlComment(HtmlCommentSyntax node)
		{
		    var tHtmlComment = this.VisitToken(node.THtmlComment);
			return node.Update(tHtmlComment);
		}
		
		public virtual SyntaxNode VisitHtmlStyle(HtmlStyleSyntax node)
		{
		    var tHtmlStyle = this.VisitToken(node.THtmlStyle);
			return node.Update(tHtmlStyle);
		}
		
		public virtual SyntaxNode VisitHtmlScript(HtmlScriptSyntax node)
		{
		    var tHtmlScript = this.VisitToken(node.THtmlScript);
			return node.Update(tHtmlScript);
		}
		
		public virtual SyntaxNode VisitHtmlTag(HtmlTagSyntax node)
		{
			var oldHtmlTagOpen = node.HtmlTagOpen;
			if (oldHtmlTagOpen != null)
			{
			    var newHtmlTagOpen = (HtmlTagOpenSyntax)this.Visit(oldHtmlTagOpen);
				return node.Update(newHtmlTagOpen);
			}
			var oldHtmlTagClose = node.HtmlTagClose;
			if (oldHtmlTagClose != null)
			{
			    var newHtmlTagClose = (HtmlTagCloseSyntax)this.Visit(oldHtmlTagClose);
				return node.Update(newHtmlTagClose);
			}
			var oldHtmlTagEmpty = node.HtmlTagEmpty;
			if (oldHtmlTagEmpty != null)
			{
			    var newHtmlTagEmpty = (HtmlTagEmptySyntax)this.Visit(oldHtmlTagEmpty);
				return node.Update(newHtmlTagEmpty);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitHtmlTagOpen(HtmlTagOpenSyntax node)
		{
		    var tTagStart = this.VisitToken(node.TTagStart);
		    var leadingWhitespace = (WhitespaceListSyntax)this.Visit(node.LeadingWhitespace);
		    var htmlTagName = (HtmlTagNameSyntax)this.Visit(node.HtmlTagName);
		    var htmlAttribute = this.VisitList(node.HtmlAttribute);
		    var trailingWhitespace = (WhitespaceListSyntax)this.Visit(node.TrailingWhitespace);
		    var tTagEnd = this.VisitToken(node.TTagEnd);
			return node.Update(tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagEnd);
		}
		
		public virtual SyntaxNode VisitHtmlTagClose(HtmlTagCloseSyntax node)
		{
		    var tEndTagStart = this.VisitToken(node.TEndTagStart);
		    var leadingWhitespace = (WhitespaceListSyntax)this.Visit(node.LeadingWhitespace);
		    var htmlTagName = (HtmlTagNameSyntax)this.Visit(node.HtmlTagName);
		    var htmlAttribute = this.VisitList(node.HtmlAttribute);
		    var trailingWhitespace = (WhitespaceListSyntax)this.Visit(node.TrailingWhitespace);
		    var tEndTagEnd = this.VisitToken(node.TEndTagEnd);
			return node.Update(tEndTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tEndTagEnd);
		}
		
		public virtual SyntaxNode VisitHtmlTagEmpty(HtmlTagEmptySyntax node)
		{
		    var tTagStart = this.VisitToken(node.TTagStart);
		    var leadingWhitespace = (WhitespaceListSyntax)this.Visit(node.LeadingWhitespace);
		    var htmlTagName = (HtmlTagNameSyntax)this.Visit(node.HtmlTagName);
		    var htmlAttribute = this.VisitList(node.HtmlAttribute);
		    var trailingWhitespace = (WhitespaceListSyntax)this.Visit(node.TrailingWhitespace);
		    var tTagCloseEnd = this.VisitToken(node.TTagCloseEnd);
			return node.Update(tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagCloseEnd);
		}
		
		public virtual SyntaxNode VisitHtmlAttributeWithValue(HtmlAttributeWithValueSyntax node)
		{
		    var leadingWhitespace = (WhitespaceListSyntax)this.Visit(node.LeadingWhitespace);
		    var htmlAttributeName = (HtmlAttributeNameSyntax)this.Visit(node.HtmlAttributeName);
		    var whitespaceBeforeEquals = (WhitespaceListSyntax)this.Visit(node.WhitespaceBeforeEquals);
		    var tAttributeEquals = this.VisitToken(node.TAttributeEquals);
		    var whitespaceAfterEquals = (WhitespaceListSyntax)this.Visit(node.WhitespaceAfterEquals);
		    var htmlAttributeValue = (HtmlAttributeValueSyntax)this.Visit(node.HtmlAttributeValue);
			return node.Update(leadingWhitespace, htmlAttributeName, whitespaceBeforeEquals, tAttributeEquals, whitespaceAfterEquals, htmlAttributeValue);
		}
		
		public virtual SyntaxNode VisitHtmlAttributeWithNoValue(HtmlAttributeWithNoValueSyntax node)
		{
		    var leadingWhitespace = (WhitespaceListSyntax)this.Visit(node.LeadingWhitespace);
		    var htmlAttributeName = (HtmlAttributeNameSyntax)this.Visit(node.HtmlAttributeName);
			return node.Update(leadingWhitespace, htmlAttributeName);
		}
		
		public virtual SyntaxNode VisitHtmlAttributeName(HtmlAttributeNameSyntax node)
		{
		    var tTagName = this.VisitToken(node.TTagName);
			return node.Update(tTagName);
		}
		
		public virtual SyntaxNode VisitHtmlAttributeValue(HtmlAttributeValueSyntax node)
		{
		    var tAttributeValue = this.VisitToken(node.TAttributeValue);
			return node.Update(tAttributeValue);
		}
		
		public virtual SyntaxNode VisitHtmlTagName(HtmlTagNameSyntax node)
		{
		    var tTagName = this.VisitToken(node.TTagName);
			return node.Update(tTagName);
		}
		
		public virtual SyntaxNode VisitWhitespaceList(WhitespaceListSyntax node)
		{
		    var whitespace = this.VisitList(node.Whitespace);
			return node.Update(whitespace);
		}
		
		public virtual SyntaxNode VisitWhitespace(WhitespaceSyntax node)
		{
		    var whitespace = this.VisitToken(node.Whitespace);
			return node.Update(whitespace);
		}
	}

	public class MediaWikiSyntaxFactory : SyntaxFactory
	{
	    internal static readonly MediaWikiSyntaxFactory Instance = new MediaWikiSyntaxFactory();
	
		public MediaWikiSyntaxFactory() 
		{
			this.CarriageReturnLineFeed = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.CarriageReturnLineFeed.CreateRed();
			this.LineFeed = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.LineFeed.CreateRed();
			this.CarriageReturn = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.CarriageReturn.CreateRed();
			this.Space = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.Space.CreateRed();
			this.Tab = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.Tab.CreateRed();
			this.ElasticCarriageReturnLineFeed = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.ElasticCarriageReturnLineFeed.CreateRed();
			this.ElasticLineFeed = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.ElasticLineFeed.CreateRed();
			this.ElasticCarriageReturn = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.ElasticCarriageReturn.CreateRed();
			this.ElasticSpace = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.ElasticSpace.CreateRed();
			this.ElasticTab = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.ElasticTab.CreateRed();
			this.ElasticZeroSpace = (MediaWikiSyntaxTrivia)MediaWikiGreenFactory.Instance.ElasticZeroSpace.CreateRed();
		}
	
		public new MediaWikiLanguage Language
		{
			get { return MediaWikiLanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
	    public MediaWikiSyntaxTrivia CarriageReturnLineFeed { get; }
	    public MediaWikiSyntaxTrivia LineFeed { get; }
	    public MediaWikiSyntaxTrivia CarriageReturn { get; }
	    public MediaWikiSyntaxTrivia Space { get; }
	    public MediaWikiSyntaxTrivia Tab { get; }
	    public MediaWikiSyntaxTrivia ElasticCarriageReturnLineFeed { get; }
	    public MediaWikiSyntaxTrivia ElasticLineFeed { get; }
	    public MediaWikiSyntaxTrivia ElasticCarriageReturn { get; }
	    public MediaWikiSyntaxTrivia ElasticSpace { get; }
	    public MediaWikiSyntaxTrivia ElasticTab { get; }
	    public MediaWikiSyntaxTrivia ElasticZeroSpace { get; }
	
		private SyntaxToken defaultToken = null;
	    protected override SyntaxToken DefaultToken
	    {
	        get 
			{
				if (defaultToken != null) return defaultToken;
			    Interlocked.CompareExchange(ref defaultToken, this.Token(MediaWikiSyntaxKind.None), null);
				return defaultToken;
			}
	    }
	
		private SyntaxTrivia defaultTrivia = null;
	    protected override SyntaxTrivia DefaultTrivia
	    {
	        get 
			{
				if (defaultTrivia != null) return defaultTrivia;
			    Interlocked.CompareExchange(ref defaultTrivia, this.Trivia(MediaWikiSyntaxKind.None, string.Empty), null);
				return defaultTrivia;
			}
	    }
	
		private SyntaxToken defaultSeparator = null;
	    protected override SyntaxToken DefaultSeparator
	    {
	        get 
			{
				if (defaultSeparator != null) return defaultSeparator;
			    Interlocked.CompareExchange(ref defaultSeparator, this.Token(MediaWikiSyntaxKind.TComma), null);
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
		public SyntaxToken Token(MediaWikiSyntaxKind kind)
		{
			return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.Token(kind).CreateRed();
		}
	
		public SyntaxTrivia Trivia(MediaWikiSyntaxKind kind, string text)
		{
			return (SyntaxTrivia)MediaWikiLanguage.Instance.InternalSyntaxFactory.Trivia(kind, text).CreateRed();
		}
	
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public MediaWikiSyntaxTree SyntaxTree(SyntaxNode root, MediaWikiParseOptions options = null, string path = "", Encoding encoding = null)
		{
		    return MediaWikiSyntaxTree.Create((MediaWikiSyntaxNode)root, (MediaWikiParseOptions)options, path, encoding);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public MediaWikiSyntaxTree ParseSyntaxTree(
		    string text,
		    MediaWikiParseOptions options = null,
		    string path = "",
		    Encoding encoding = null,
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (MediaWikiSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public MediaWikiSyntaxTree ParseSyntaxTree(
		    SourceText text,
		    MediaWikiParseOptions options = null,
		    string path = "",
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (MediaWikiSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
	
		protected override SyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return MediaWikiSyntaxTree.ParseText(text, (MediaWikiParseOptions)options, path, cancellationToken);
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
		    return new MediaWikiSyntaxParser(text, (MediaWikiParseOptions)options, oldTree, changes);
		}
	
		public override SyntaxParser MakeParser(string text)
		{
		    return new MediaWikiSyntaxParser(SourceText.From(text, Encoding.UTF8), MediaWikiParseOptions.Default, null, null);
		}
	
	    public SyntaxToken THorizontalLine(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THorizontalLine(text).CreateRed();
	    }
	
	    public SyntaxToken THorizontalLine(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THorizontalLine(text, value).CreateRed();
	    }
	
	    public SyntaxToken THeading(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THeading(text).CreateRed();
	    }
	
	    public SyntaxToken THeading(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THeading(text, value).CreateRed();
	    }
	
	    public SyntaxToken TDefinitionStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TDefinitionStart(text).CreateRed();
	    }
	
	    public SyntaxToken TDefinitionStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TDefinitionStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken TListStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TListStart(text).CreateRed();
	    }
	
	    public SyntaxToken TListStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TListStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken TTableStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTableStart(text).CreateRed();
	    }
	
	    public SyntaxToken TTableStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTableStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken TFormat(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TFormat(text).CreateRed();
	    }
	
	    public SyntaxToken TFormat(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TFormat(text, value).CreateRed();
	    }
	
	    public SyntaxToken TLinkStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TLinkStart(text).CreateRed();
	    }
	
	    public SyntaxToken TLinkStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TLinkStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken TExternalLinkStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TExternalLinkStart(text).CreateRed();
	    }
	
	    public SyntaxToken TExternalLinkStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TExternalLinkStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken TTemplateParamStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTemplateParamStart(text).CreateRed();
	    }
	
	    public SyntaxToken TTemplateParamStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTemplateParamStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken TTemplateStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTemplateStart(text).CreateRed();
	    }
	
	    public SyntaxToken TTemplateStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTemplateStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken THtmlComment(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THtmlComment(text).CreateRed();
	    }
	
	    public SyntaxToken THtmlComment(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THtmlComment(text, value).CreateRed();
	    }
	
	    public SyntaxToken TNoWiki(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TNoWiki(text).CreateRed();
	    }
	
	    public SyntaxToken TNoWiki(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TNoWiki(text, value).CreateRed();
	    }
	
	    public SyntaxToken THtmlScript(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THtmlScript(text).CreateRed();
	    }
	
	    public SyntaxToken THtmlScript(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THtmlScript(text, value).CreateRed();
	    }
	
	    public SyntaxToken THtmlStyle(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THtmlStyle(text).CreateRed();
	    }
	
	    public SyntaxToken THtmlStyle(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.THtmlStyle(text, value).CreateRed();
	    }
	
	    public SyntaxToken TEndTagStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TEndTagStart(text).CreateRed();
	    }
	
	    public SyntaxToken TEndTagStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TEndTagStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken TTagStart(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTagStart(text).CreateRed();
	    }
	
	    public SyntaxToken TTagStart(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTagStart(text, value).CreateRed();
	    }
	
	    public SyntaxToken TNormalText(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TNormalText(text).CreateRed();
	    }
	
	    public SyntaxToken TNormalText(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TNormalText(text, value).CreateRed();
	    }
	
	    public SyntaxToken TComma(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TComma(text).CreateRed();
	    }
	
	    public SyntaxToken TComma(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TComma(text, value).CreateRed();
	    }
	
	    public SyntaxToken TWhiteSpace(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TWhiteSpace(text).CreateRed();
	    }
	
	    public SyntaxToken TWhiteSpace(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TWhiteSpace(text, value).CreateRed();
	    }
	
	    public SyntaxToken UTF8BOM(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.UTF8BOM(text).CreateRed();
	    }
	
	    public SyntaxToken UTF8BOM(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.UTF8BOM(text, value).CreateRed();
	    }
	
	    public SyntaxToken CRLF(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.CRLF(text).CreateRed();
	    }
	
	    public SyntaxToken CRLF(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.CRLF(text, value).CreateRed();
	    }
	
	    public SyntaxToken TBar(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TBar(text).CreateRed();
	    }
	
	    public SyntaxToken TBar(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TBar(text, value).CreateRed();
	    }
	
	    public SyntaxToken TApos(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TApos(text).CreateRed();
	    }
	
	    public SyntaxToken TApos(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TApos(text, value).CreateRed();
	    }
	
	    public SyntaxToken TSpecialChars(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TSpecialChars(text).CreateRed();
	    }
	
	    public SyntaxToken TSpecialChars(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TSpecialChars(text, value).CreateRed();
	    }
	
	    public SyntaxToken TEntityRef(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TEntityRef(text).CreateRed();
	    }
	
	    public SyntaxToken TEntityRef(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TEntityRef(text, value).CreateRed();
	    }
	
	    public SyntaxToken TCharRef(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TCharRef(text).CreateRed();
	    }
	
	    public SyntaxToken TCharRef(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TCharRef(text, value).CreateRed();
	    }
	
	    public SyntaxToken TTagEnd(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTagEnd(text).CreateRed();
	    }
	
	    public SyntaxToken TTagEnd(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTagEnd(text, value).CreateRed();
	    }
	
	    public SyntaxToken TTagName(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTagName(text).CreateRed();
	    }
	
	    public SyntaxToken TTagName(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TTagName(text, value).CreateRed();
	    }
	
	    public SyntaxToken TAttributeValue(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TAttributeValue(text).CreateRed();
	    }
	
	    public SyntaxToken TAttributeValue(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TAttributeValue(text, value).CreateRed();
	    }
	
	    public SyntaxToken TEndTagEnd(string text)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TEndTagEnd(text).CreateRed();
	    }
	
	    public SyntaxToken TEndTagEnd(string text, object value)
	    {
	        return (SyntaxToken)MediaWikiLanguage.Instance.InternalSyntaxFactory.TEndTagEnd(text, value).CreateRed();
	    }
		
		public MainSyntax Main(SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph, SyntaxToken eof)
		{
		    if (eof == null) throw new ArgumentNullException(nameof(eof));
		    if (eof.RawKind != (int)MediaWikiSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
		    return (MainSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.Main(specialBlockOrParagraph == null ? null : specialBlockOrParagraph.Green, (InternalSyntaxToken)eof.Green).CreateRed();
		}
		
		public MainSyntax Main(SyntaxToken eof)
		{
			return this.Main(null, eof);
		}
		
		public SpecialBlockOrParagraphSyntax SpecialBlockOrParagraph(SpecialBlockWithCommentSyntax specialBlockWithComment)
		{
		    if (specialBlockWithComment == null) throw new ArgumentNullException(nameof(specialBlockWithComment));
		    return (SpecialBlockOrParagraphSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlockOrParagraph((Syntax.InternalSyntax.SpecialBlockWithCommentGreen)specialBlockWithComment.Green).CreateRed();
		}
		
		public SpecialBlockOrParagraphSyntax SpecialBlockOrParagraph(ParagraphSyntax paragraph)
		{
		    if (paragraph == null) throw new ArgumentNullException(nameof(paragraph));
		    return (SpecialBlockOrParagraphSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlockOrParagraph((Syntax.InternalSyntax.ParagraphGreen)paragraph.Green).CreateRed();
		}
		
		public SpecialBlockWithCommentSyntax SpecialBlockWithComment(HtmlCommentListSyntax leadingComment, SpecialBlockSyntax specialBlock, HtmlCommentListSyntax trailingComment, SyntaxToken crlf)
		{
		    if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
		    if (specialBlock == null) throw new ArgumentNullException(nameof(specialBlock));
		    if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (SpecialBlockWithCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlockWithComment((Syntax.InternalSyntax.HtmlCommentListGreen)leadingComment.Green, (Syntax.InternalSyntax.SpecialBlockGreen)specialBlock.Green, (Syntax.InternalSyntax.HtmlCommentListGreen)trailingComment.Green, (InternalSyntaxToken)crlf.Green).CreateRed();
		}
		
		public SpecialBlockSyntax SpecialBlock(HeadingSyntax heading)
		{
		    if (heading == null) throw new ArgumentNullException(nameof(heading));
		    return (SpecialBlockSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock((Syntax.InternalSyntax.HeadingGreen)heading.Green).CreateRed();
		}
		
		public SpecialBlockSyntax SpecialBlock(HorizontalRuleSyntax horizontalRule)
		{
		    if (horizontalRule == null) throw new ArgumentNullException(nameof(horizontalRule));
		    return (SpecialBlockSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock((Syntax.InternalSyntax.HorizontalRuleGreen)horizontalRule.Green).CreateRed();
		}
		
		public SpecialBlockSyntax SpecialBlock(CodeBlockSyntax codeBlock)
		{
		    if (codeBlock == null) throw new ArgumentNullException(nameof(codeBlock));
		    return (SpecialBlockSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock((Syntax.InternalSyntax.CodeBlockGreen)codeBlock.Green).CreateRed();
		}
		
		public SpecialBlockSyntax SpecialBlock(WikiListSyntax wikiList)
		{
		    if (wikiList == null) throw new ArgumentNullException(nameof(wikiList));
		    return (SpecialBlockSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock((Syntax.InternalSyntax.WikiListGreen)wikiList.Green).CreateRed();
		}
		
		public SpecialBlockSyntax SpecialBlock(WikiTableSyntax wikiTable)
		{
		    if (wikiTable == null) throw new ArgumentNullException(nameof(wikiTable));
		    return (SpecialBlockSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock((Syntax.InternalSyntax.WikiTableGreen)wikiTable.Green).CreateRed();
		}
		
		public HeadingSyntax Heading(HeadingLevelSyntax headingStart, HeadingTextSyntax headingText, HeadingLevelSyntax headingEnd, InlineTextSyntax inlineText)
		{
		    if (headingStart == null) throw new ArgumentNullException(nameof(headingStart));
		    if (headingText == null) throw new ArgumentNullException(nameof(headingText));
		    if (headingEnd == null) throw new ArgumentNullException(nameof(headingEnd));
		    return (HeadingSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.Heading((Syntax.InternalSyntax.HeadingLevelGreen)headingStart.Green, (Syntax.InternalSyntax.HeadingTextGreen)headingText.Green, (Syntax.InternalSyntax.HeadingLevelGreen)headingEnd.Green, inlineText == null ? null : (Syntax.InternalSyntax.InlineTextGreen)inlineText.Green).CreateRed();
		}
		
		public HeadingSyntax Heading(HeadingLevelSyntax headingStart, HeadingTextSyntax headingText, HeadingLevelSyntax headingEnd)
		{
			return this.Heading(headingStart, headingText, headingEnd, null);
		}
		
		public HeadingLevelSyntax HeadingLevel(SyntaxToken tHeading)
		{
		    if (tHeading == null) throw new ArgumentNullException(nameof(tHeading));
		    if (tHeading.RawKind != (int)MediaWikiSyntaxKind.THeading) throw new ArgumentException(nameof(tHeading));
		    return (HeadingLevelSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingLevel((InternalSyntaxToken)tHeading.Green).CreateRed();
		}
		
		public HorizontalRuleSyntax HorizontalRule(SyntaxToken tHorizontalLine, InlineTextSyntax inlineText)
		{
		    if (tHorizontalLine == null) throw new ArgumentNullException(nameof(tHorizontalLine));
		    if (tHorizontalLine.RawKind != (int)MediaWikiSyntaxKind.THorizontalLine) throw new ArgumentException(nameof(tHorizontalLine));
		    return (HorizontalRuleSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HorizontalRule((InternalSyntaxToken)tHorizontalLine.Green, inlineText == null ? null : (Syntax.InternalSyntax.InlineTextGreen)inlineText.Green).CreateRed();
		}
		
		public HorizontalRuleSyntax HorizontalRule(SyntaxToken tHorizontalLine)
		{
			return this.HorizontalRule(tHorizontalLine, null);
		}
		
		public CodeBlockSyntax CodeBlock(SeparatedSyntaxNodeList<SpaceBlockSyntax> spaceBlock)
		{
		    if (spaceBlock == null) throw new ArgumentNullException(nameof(spaceBlock));
		    return (CodeBlockSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.CodeBlock(spaceBlock.Green).CreateRed();
		}
		
		public SpaceBlockSyntax SpaceBlock(SyntaxToken tSpaceBlockStart, InlineTextSyntax inlineText)
		{
		    if (tSpaceBlockStart == null) throw new ArgumentNullException(nameof(tSpaceBlockStart));
		    if (tSpaceBlockStart.RawKind != (int)MediaWikiSyntaxKind.TSpaceBlockStart) throw new ArgumentException(nameof(tSpaceBlockStart));
		    return (SpaceBlockSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.SpaceBlock((InternalSyntaxToken)tSpaceBlockStart.Green, inlineText == null ? null : (Syntax.InternalSyntax.InlineTextGreen)inlineText.Green).CreateRed();
		}
		
		public SpaceBlockSyntax SpaceBlock()
		{
			return this.SpaceBlock(this.Token(MediaWikiSyntaxKind.TSpaceBlockStart), null);
		}
		
		public WikiListSyntax WikiList(SeparatedSyntaxNodeList<ListItemSyntax> listItem)
		{
		    if (listItem == null) throw new ArgumentNullException(nameof(listItem));
		    return (WikiListSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiList(listItem.Green).CreateRed();
		}
		
		public ListItemSyntax ListItem(NormalListItemSyntax normalListItem)
		{
		    if (normalListItem == null) throw new ArgumentNullException(nameof(normalListItem));
		    return (ListItemSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.ListItem((Syntax.InternalSyntax.NormalListItemGreen)normalListItem.Green).CreateRed();
		}
		
		public ListItemSyntax ListItem(DefinitionItemSyntax definitionItem)
		{
		    if (definitionItem == null) throw new ArgumentNullException(nameof(definitionItem));
		    return (ListItemSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.ListItem((Syntax.InternalSyntax.DefinitionItemGreen)definitionItem.Green).CreateRed();
		}
		
		public NormalListItemSyntax NormalListItem(SyntaxToken tListStart, InlineTextSyntax inlineText)
		{
		    if (tListStart == null) throw new ArgumentNullException(nameof(tListStart));
		    if (tListStart.RawKind != (int)MediaWikiSyntaxKind.TListStart) throw new ArgumentException(nameof(tListStart));
		    return (NormalListItemSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.NormalListItem((InternalSyntaxToken)tListStart.Green, inlineText == null ? null : (Syntax.InternalSyntax.InlineTextGreen)inlineText.Green).CreateRed();
		}
		
		public NormalListItemSyntax NormalListItem(SyntaxToken tListStart)
		{
			return this.NormalListItem(tListStart, null);
		}
		
		public DefinitionItemSyntax DefinitionItem(SyntaxToken tDefinitionStart, DefinitionTextSyntax definitionText, SyntaxToken tColon, InlineTextSyntax inlineText)
		{
		    if (tDefinitionStart == null) throw new ArgumentNullException(nameof(tDefinitionStart));
		    if (tDefinitionStart.RawKind != (int)MediaWikiSyntaxKind.TDefinitionStart) throw new ArgumentException(nameof(tDefinitionStart));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.RawKind != (int)MediaWikiSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (inlineText == null) throw new ArgumentNullException(nameof(inlineText));
		    return (DefinitionItemSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionItem((InternalSyntaxToken)tDefinitionStart.Green, definitionText == null ? null : (Syntax.InternalSyntax.DefinitionTextGreen)definitionText.Green, (InternalSyntaxToken)tColon.Green, (Syntax.InternalSyntax.InlineTextGreen)inlineText.Green).CreateRed();
		}
		
		public DefinitionItemSyntax DefinitionItem(SyntaxToken tDefinitionStart, InlineTextSyntax inlineText)
		{
			return this.DefinitionItem(tDefinitionStart, null, this.Token(MediaWikiSyntaxKind.TColon), inlineText);
		}
		
		public WikiTableSyntax WikiTable(SyntaxToken tTableStart, InlineTextSyntax leadingInlineText, SyntaxToken crlf, TableCaptionSyntax tableCaption, TableRowsSyntax tableRows, SyntaxToken tTableEnd, InlineTextSyntax trailingInlineText)
		{
		    if (tTableStart == null) throw new ArgumentNullException(nameof(tTableStart));
		    if (tTableStart.RawKind != (int)MediaWikiSyntaxKind.TTableStart) throw new ArgumentException(nameof(tTableStart));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    if (tableRows == null) throw new ArgumentNullException(nameof(tableRows));
		    if (tTableEnd == null) throw new ArgumentNullException(nameof(tTableEnd));
		    if (tTableEnd.RawKind != (int)MediaWikiSyntaxKind.TTableEnd) throw new ArgumentException(nameof(tTableEnd));
		    return (WikiTableSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiTable((InternalSyntaxToken)tTableStart.Green, leadingInlineText == null ? null : (Syntax.InternalSyntax.InlineTextGreen)leadingInlineText.Green, (InternalSyntaxToken)crlf.Green, tableCaption == null ? null : (Syntax.InternalSyntax.TableCaptionGreen)tableCaption.Green, (Syntax.InternalSyntax.TableRowsGreen)tableRows.Green, (InternalSyntaxToken)tTableEnd.Green, trailingInlineText == null ? null : (Syntax.InternalSyntax.InlineTextGreen)trailingInlineText.Green).CreateRed();
		}
		
		public WikiTableSyntax WikiTable(SyntaxToken tTableStart, SyntaxToken crlf, TableRowsSyntax tableRows)
		{
			return this.WikiTable(tTableStart, null, crlf, null, tableRows, this.Token(MediaWikiSyntaxKind.TTableEnd), null);
		}
		
		public TableCaptionSyntax TableCaption(SyntaxToken tTableCaptionStart, InlineTextSyntax inlineText, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
		    if (tTableCaptionStart == null) throw new ArgumentNullException(nameof(tTableCaptionStart));
		    if (tTableCaptionStart.RawKind != (int)MediaWikiSyntaxKind.TTableCaptionStart) throw new ArgumentException(nameof(tTableCaptionStart));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (TableCaptionSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableCaption((InternalSyntaxToken)tTableCaptionStart.Green, inlineText == null ? null : (Syntax.InternalSyntax.InlineTextGreen)inlineText.Green, (InternalSyntaxToken)crlf.Green, specialBlockOrParagraph == null ? null : specialBlockOrParagraph.Green).CreateRed();
		}
		
		public TableCaptionSyntax TableCaption(SyntaxToken crlf)
		{
			return this.TableCaption(this.Token(MediaWikiSyntaxKind.TTableCaptionStart), null, crlf, null);
		}
		
		public TableRowsSyntax TableRows(TableFirstRowSyntax tableFirstRow, SyntaxNodeList<TableRowSyntax> tableRow)
		{
		    if (tableFirstRow == null) throw new ArgumentNullException(nameof(tableFirstRow));
		    return (TableRowsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableRows((Syntax.InternalSyntax.TableFirstRowGreen)tableFirstRow.Green, tableRow == null ? null : tableRow.Green).CreateRed();
		}
		
		public TableRowsSyntax TableRows(TableFirstRowSyntax tableFirstRow)
		{
			return this.TableRows(tableFirstRow, null);
		}
		
		public TableFirstRowSyntax TableFirstRow(SyntaxNodeList<TableColumnSyntax> tableColumn)
		{
		    return (TableFirstRowSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableFirstRow(tableColumn == null ? null : tableColumn.Green).CreateRed();
		}
		
		public TableFirstRowSyntax TableFirstRow()
		{
			return this.TableFirstRow(null);
		}
		
		public TableRowSyntax TableRow(SyntaxToken tTableRowStart, InlineTextSyntax inlineText, SyntaxToken crlf, SyntaxNodeList<TableColumnSyntax> tableColumn)
		{
		    if (tTableRowStart == null) throw new ArgumentNullException(nameof(tTableRowStart));
		    if (tTableRowStart.RawKind != (int)MediaWikiSyntaxKind.TTableRowStart) throw new ArgumentException(nameof(tTableRowStart));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (TableRowSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableRow((InternalSyntaxToken)tTableRowStart.Green, inlineText == null ? null : (Syntax.InternalSyntax.InlineTextGreen)inlineText.Green, (InternalSyntaxToken)crlf.Green, tableColumn == null ? null : tableColumn.Green).CreateRed();
		}
		
		public TableRowSyntax TableRow(SyntaxToken crlf)
		{
			return this.TableRow(this.Token(MediaWikiSyntaxKind.TTableRowStart), null, crlf, null);
		}
		
		public TableColumnSyntax TableColumn(TableSingleHeaderCellSyntax tableSingleHeaderCell)
		{
		    if (tableSingleHeaderCell == null) throw new ArgumentNullException(nameof(tableSingleHeaderCell));
		    return (TableColumnSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableColumn((Syntax.InternalSyntax.TableSingleHeaderCellGreen)tableSingleHeaderCell.Green).CreateRed();
		}
		
		public TableColumnSyntax TableColumn(TableHeaderCellsSyntax tableHeaderCells)
		{
		    if (tableHeaderCells == null) throw new ArgumentNullException(nameof(tableHeaderCells));
		    return (TableColumnSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableColumn((Syntax.InternalSyntax.TableHeaderCellsGreen)tableHeaderCells.Green).CreateRed();
		}
		
		public TableColumnSyntax TableColumn(TableSingleCellSyntax tableSingleCell)
		{
		    if (tableSingleCell == null) throw new ArgumentNullException(nameof(tableSingleCell));
		    return (TableColumnSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableColumn((Syntax.InternalSyntax.TableSingleCellGreen)tableSingleCell.Green).CreateRed();
		}
		
		public TableColumnSyntax TableColumn(TableCellsSyntax tableCells)
		{
		    if (tableCells == null) throw new ArgumentNullException(nameof(tableCells));
		    return (TableColumnSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableColumn((Syntax.InternalSyntax.TableCellsGreen)tableCells.Green).CreateRed();
		}
		
		public TableSingleHeaderCellSyntax TableSingleHeaderCell(SyntaxToken tExclamation, TableCellSyntax tableCell, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
		    if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
		    if (tExclamation.RawKind != (int)MediaWikiSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (TableSingleHeaderCellSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableSingleHeaderCell((InternalSyntaxToken)tExclamation.Green, tableCell == null ? null : (Syntax.InternalSyntax.TableCellGreen)tableCell.Green, (InternalSyntaxToken)crlf.Green, specialBlockOrParagraph == null ? null : specialBlockOrParagraph.Green).CreateRed();
		}
		
		public TableSingleHeaderCellSyntax TableSingleHeaderCell(SyntaxToken crlf)
		{
			return this.TableSingleHeaderCell(this.Token(MediaWikiSyntaxKind.TExclamation), null, crlf, null);
		}
		
		public TableHeaderCellsSyntax TableHeaderCells(SyntaxToken tExclamation, SeparatedSyntaxNodeList<TableCellSyntax> tableCell, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
		    if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
		    if (tExclamation.RawKind != (int)MediaWikiSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
		    if (tableCell == null) throw new ArgumentNullException(nameof(tableCell));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (TableHeaderCellsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableHeaderCells((InternalSyntaxToken)tExclamation.Green, tableCell.Green, (InternalSyntaxToken)crlf.Green, specialBlockOrParagraph == null ? null : specialBlockOrParagraph.Green).CreateRed();
		}
		
		public TableHeaderCellsSyntax TableHeaderCells(SeparatedSyntaxNodeList<TableCellSyntax> tableCell, SyntaxToken crlf)
		{
			return this.TableHeaderCells(this.Token(MediaWikiSyntaxKind.TExclamation), tableCell, crlf, null);
		}
		
		public TableSingleCellSyntax TableSingleCell(SyntaxToken tBar, TableCellSyntax tableCell, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
		    if (tBar == null) throw new ArgumentNullException(nameof(tBar));
		    if (tBar.RawKind != (int)MediaWikiSyntaxKind.TBar) throw new ArgumentException(nameof(tBar));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (TableSingleCellSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableSingleCell((InternalSyntaxToken)tBar.Green, tableCell == null ? null : (Syntax.InternalSyntax.TableCellGreen)tableCell.Green, (InternalSyntaxToken)crlf.Green, specialBlockOrParagraph == null ? null : specialBlockOrParagraph.Green).CreateRed();
		}
		
		public TableSingleCellSyntax TableSingleCell(SyntaxToken tBar, SyntaxToken crlf)
		{
			return this.TableSingleCell(tBar, null, crlf, null);
		}
		
		public TableCellsSyntax TableCells(SyntaxToken tBar, SeparatedSyntaxNodeList<TableCellSyntax> tableCell, SyntaxToken crlf, SyntaxNodeList<SpecialBlockOrParagraphSyntax> specialBlockOrParagraph)
		{
		    if (tBar == null) throw new ArgumentNullException(nameof(tBar));
		    if (tBar.RawKind != (int)MediaWikiSyntaxKind.TBar) throw new ArgumentException(nameof(tBar));
		    if (tableCell == null) throw new ArgumentNullException(nameof(tableCell));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (TableCellsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableCells((InternalSyntaxToken)tBar.Green, tableCell.Green, (InternalSyntaxToken)crlf.Green, specialBlockOrParagraph == null ? null : specialBlockOrParagraph.Green).CreateRed();
		}
		
		public TableCellsSyntax TableCells(SyntaxToken tBar, SeparatedSyntaxNodeList<TableCellSyntax> tableCell, SyntaxToken crlf)
		{
			return this.TableCells(tBar, tableCell, crlf, null);
		}
		
		public TableCellSyntax TableCell(CellTextSyntax cellText, CellValueSyntax cellValue)
		{
		    return (TableCellSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TableCell(cellText == null ? null : (Syntax.InternalSyntax.CellTextGreen)cellText.Green, cellValue == null ? null : (Syntax.InternalSyntax.CellValueGreen)cellValue.Green).CreateRed();
		}
		
		public TableCellSyntax TableCell()
		{
			return this.TableCell(null, null);
		}
		
		public CellValueSyntax CellValue(SyntaxToken tBar, CellTextSyntax cellText)
		{
		    if (tBar == null) throw new ArgumentNullException(nameof(tBar));
		    if (tBar.RawKind != (int)MediaWikiSyntaxKind.TBar) throw new ArgumentException(nameof(tBar));
		    return (CellValueSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.CellValue((InternalSyntaxToken)tBar.Green, cellText == null ? null : (Syntax.InternalSyntax.CellTextGreen)cellText.Green).CreateRed();
		}
		
		public CellValueSyntax CellValue(SyntaxToken tBar)
		{
			return this.CellValue(tBar, null);
		}
		
		public ParagraphSyntax Paragraph(SyntaxNodeList<TextLineSyntax> textLine)
		{
		    if (textLine == null) throw new ArgumentNullException(nameof(textLine));
		    return (ParagraphSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.Paragraph(textLine.Green).CreateRed();
		}
		
		public TextLineInlineElementsWithCommentSyntax TextLineInlineElementsWithComment(HtmlCommentListSyntax leadingComment, SyntaxNodeList<InlineTextElementSyntax> inlineTextElement, HtmlCommentListSyntax trailingComment, SyntaxToken crlf)
		{
		    if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
		    if (inlineTextElement == null) throw new ArgumentNullException(nameof(inlineTextElement));
		    if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (TextLineInlineElementsWithCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextLineInlineElementsWithComment((Syntax.InternalSyntax.HtmlCommentListGreen)leadingComment.Green, inlineTextElement.Green, (Syntax.InternalSyntax.HtmlCommentListGreen)trailingComment.Green, (InternalSyntaxToken)crlf.Green).CreateRed();
		}
		
		public TextLineCommentSyntax TextLineComment(HtmlCommentListSyntax htmlCommentList, SyntaxToken crlf)
		{
		    if (htmlCommentList == null) throw new ArgumentNullException(nameof(htmlCommentList));
		    if (crlf == null) throw new ArgumentNullException(nameof(crlf));
		    if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
		    return (TextLineCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextLineComment((Syntax.InternalSyntax.HtmlCommentListGreen)htmlCommentList.Green, (InternalSyntaxToken)crlf.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(WikiFormatSyntax wikiFormat)
		{
		    if (wikiFormat == null) throw new ArgumentNullException(nameof(wikiFormat));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.WikiFormatGreen)wikiFormat.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(WikiLinkSyntax wikiLink)
		{
		    if (wikiLink == null) throw new ArgumentNullException(nameof(wikiLink));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.WikiLinkGreen)wikiLink.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(WikiTemplateSyntax wikiTemplate)
		{
		    if (wikiTemplate == null) throw new ArgumentNullException(nameof(wikiTemplate));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.WikiTemplateGreen)wikiTemplate.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(WikiTemplateParamSyntax wikiTemplateParam)
		{
		    if (wikiTemplateParam == null) throw new ArgumentNullException(nameof(wikiTemplateParam));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.WikiTemplateParamGreen)wikiTemplateParam.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(NoWikiSyntax noWiki)
		{
		    if (noWiki == null) throw new ArgumentNullException(nameof(noWiki));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.NoWikiGreen)noWiki.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(HtmlReferenceSyntax htmlReference)
		{
		    if (htmlReference == null) throw new ArgumentNullException(nameof(htmlReference));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.HtmlReferenceGreen)htmlReference.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(HtmlStyleSyntax htmlStyle)
		{
		    if (htmlStyle == null) throw new ArgumentNullException(nameof(htmlStyle));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.HtmlStyleGreen)htmlStyle.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(HtmlScriptSyntax htmlScript)
		{
		    if (htmlScript == null) throw new ArgumentNullException(nameof(htmlScript));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.HtmlScriptGreen)htmlScript.Green).CreateRed();
		}
		
		public TextElementsSyntax TextElements(HtmlTagSyntax htmlTag)
		{
		    if (htmlTag == null) throw new ArgumentNullException(nameof(htmlTag));
		    return (TextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements((Syntax.InternalSyntax.HtmlTagGreen)htmlTag.Green).CreateRed();
		}
		
		public InlineTextSyntax InlineText(SyntaxNodeList<InlineTextElementWithCommentSyntax> inlineTextElementWithComment, HtmlCommentListSyntax trailingComment)
		{
		    if (inlineTextElementWithComment == null) throw new ArgumentNullException(nameof(inlineTextElementWithComment));
		    if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
		    return (InlineTextSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineText(inlineTextElementWithComment.Green, (Syntax.InternalSyntax.HtmlCommentListGreen)trailingComment.Green).CreateRed();
		}
		
		public InlineTextElementWithCommentSyntax InlineTextElementWithComment(HtmlCommentListSyntax leadingComment, InlineTextElementSyntax inlineTextElement)
		{
		    if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
		    if (inlineTextElement == null) throw new ArgumentNullException(nameof(inlineTextElement));
		    return (InlineTextElementWithCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineTextElementWithComment((Syntax.InternalSyntax.HtmlCommentListGreen)leadingComment.Green, (Syntax.InternalSyntax.InlineTextElementGreen)inlineTextElement.Green).CreateRed();
		}
		
		public InlineTextElementSyntax InlineTextElement(TextElementsSyntax textElements)
		{
		    if (textElements == null) throw new ArgumentNullException(nameof(textElements));
		    return (InlineTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineTextElement((Syntax.InternalSyntax.TextElementsGreen)textElements.Green).CreateRed();
		}
		
		public InlineTextElementSyntax InlineTextElement(InlineTextElementsSyntax inlineTextElements)
		{
		    if (inlineTextElements == null) throw new ArgumentNullException(nameof(inlineTextElements));
		    return (InlineTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineTextElement((Syntax.InternalSyntax.InlineTextElementsGreen)inlineTextElements.Green).CreateRed();
		}
		
		public InlineTextElementsSyntax InlineTextElements(SyntaxToken inlineTextElements)
		{
		    if (inlineTextElements == null) throw new ArgumentNullException(nameof(inlineTextElements));
		    return (InlineTextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineTextElements((InternalSyntaxToken)inlineTextElements.Green).CreateRed();
		}
		
		public DefinitionTextSyntax DefinitionText(SyntaxNodeList<DefinitionTextElementWithCommentSyntax> definitionTextElementWithComment, HtmlCommentListSyntax trailingComment)
		{
		    if (definitionTextElementWithComment == null) throw new ArgumentNullException(nameof(definitionTextElementWithComment));
		    if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
		    return (DefinitionTextSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionText(definitionTextElementWithComment.Green, (Syntax.InternalSyntax.HtmlCommentListGreen)trailingComment.Green).CreateRed();
		}
		
		public DefinitionTextElementWithCommentSyntax DefinitionTextElementWithComment(HtmlCommentListSyntax leadingComment, DefinitionTextElementSyntax definitionTextElement)
		{
		    if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
		    if (definitionTextElement == null) throw new ArgumentNullException(nameof(definitionTextElement));
		    return (DefinitionTextElementWithCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionTextElementWithComment((Syntax.InternalSyntax.HtmlCommentListGreen)leadingComment.Green, (Syntax.InternalSyntax.DefinitionTextElementGreen)definitionTextElement.Green).CreateRed();
		}
		
		public DefinitionTextElementSyntax DefinitionTextElement(TextElementsSyntax textElements)
		{
		    if (textElements == null) throw new ArgumentNullException(nameof(textElements));
		    return (DefinitionTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionTextElement((Syntax.InternalSyntax.TextElementsGreen)textElements.Green).CreateRed();
		}
		
		public DefinitionTextElementSyntax DefinitionTextElement(DefinitionTextElementsSyntax definitionTextElements)
		{
		    if (definitionTextElements == null) throw new ArgumentNullException(nameof(definitionTextElements));
		    return (DefinitionTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionTextElement((Syntax.InternalSyntax.DefinitionTextElementsGreen)definitionTextElements.Green).CreateRed();
		}
		
		public DefinitionTextElementsSyntax DefinitionTextElements(SyntaxToken definitionTextElements)
		{
		    if (definitionTextElements == null) throw new ArgumentNullException(nameof(definitionTextElements));
		    return (DefinitionTextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionTextElements((InternalSyntaxToken)definitionTextElements.Green).CreateRed();
		}
		
		public HeadingTextSyntax HeadingText(SyntaxNodeList<HeadingTextWithCommentSyntax> headingTextWithComment, HtmlCommentListSyntax trailingComment)
		{
		    if (headingTextWithComment == null) throw new ArgumentNullException(nameof(headingTextWithComment));
		    if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
		    return (HeadingTextSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingText(headingTextWithComment.Green, (Syntax.InternalSyntax.HtmlCommentListGreen)trailingComment.Green).CreateRed();
		}
		
		public HeadingTextWithCommentSyntax HeadingTextWithComment(HtmlCommentListSyntax leadingComment, HeadingTextElementSyntax headingTextElement)
		{
		    if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
		    if (headingTextElement == null) throw new ArgumentNullException(nameof(headingTextElement));
		    return (HeadingTextWithCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingTextWithComment((Syntax.InternalSyntax.HtmlCommentListGreen)leadingComment.Green, (Syntax.InternalSyntax.HeadingTextElementGreen)headingTextElement.Green).CreateRed();
		}
		
		public HeadingTextElementSyntax HeadingTextElement(TextElementsSyntax textElements)
		{
		    if (textElements == null) throw new ArgumentNullException(nameof(textElements));
		    return (HeadingTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingTextElement((Syntax.InternalSyntax.TextElementsGreen)textElements.Green).CreateRed();
		}
		
		public HeadingTextElementSyntax HeadingTextElement(HeadingTextElementsSyntax headingTextElements)
		{
		    if (headingTextElements == null) throw new ArgumentNullException(nameof(headingTextElements));
		    return (HeadingTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingTextElement((Syntax.InternalSyntax.HeadingTextElementsGreen)headingTextElements.Green).CreateRed();
		}
		
		public HeadingTextElementsSyntax HeadingTextElements(SyntaxToken headingTextElements)
		{
		    if (headingTextElements == null) throw new ArgumentNullException(nameof(headingTextElements));
		    return (HeadingTextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingTextElements((InternalSyntaxToken)headingTextElements.Green).CreateRed();
		}
		
		public CellTextSyntax CellText(SyntaxNodeList<CellTextElementWithCommentSyntax> cellTextElementWithComment, HtmlCommentListSyntax trailingComment)
		{
		    if (cellTextElementWithComment == null) throw new ArgumentNullException(nameof(cellTextElementWithComment));
		    if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
		    return (CellTextSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.CellText(cellTextElementWithComment.Green, (Syntax.InternalSyntax.HtmlCommentListGreen)trailingComment.Green).CreateRed();
		}
		
		public CellTextElementWithCommentSyntax CellTextElementWithComment(HtmlCommentListSyntax leadingComment, CellTextElementSyntax cellTextElement)
		{
		    if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
		    if (cellTextElement == null) throw new ArgumentNullException(nameof(cellTextElement));
		    return (CellTextElementWithCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.CellTextElementWithComment((Syntax.InternalSyntax.HtmlCommentListGreen)leadingComment.Green, (Syntax.InternalSyntax.CellTextElementGreen)cellTextElement.Green).CreateRed();
		}
		
		public CellTextElementSyntax CellTextElement(TextElementsSyntax textElements)
		{
		    if (textElements == null) throw new ArgumentNullException(nameof(textElements));
		    return (CellTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.CellTextElement((Syntax.InternalSyntax.TextElementsGreen)textElements.Green).CreateRed();
		}
		
		public CellTextElementSyntax CellTextElement(CellTextElementsSyntax cellTextElements)
		{
		    if (cellTextElements == null) throw new ArgumentNullException(nameof(cellTextElements));
		    return (CellTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.CellTextElement((Syntax.InternalSyntax.CellTextElementsGreen)cellTextElements.Green).CreateRed();
		}
		
		public CellTextElementsSyntax CellTextElements(SyntaxToken cellTextElements)
		{
		    if (cellTextElements == null) throw new ArgumentNullException(nameof(cellTextElements));
		    return (CellTextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.CellTextElements((InternalSyntaxToken)cellTextElements.Green).CreateRed();
		}
		
		public LinkTextSyntax LinkText(SyntaxNodeList<LinkTextWithCommentSyntax> linkTextWithComment, HtmlCommentListSyntax trailingComment)
		{
		    if (linkTextWithComment == null) throw new ArgumentNullException(nameof(linkTextWithComment));
		    if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
		    return (LinkTextSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkText(linkTextWithComment.Green, (Syntax.InternalSyntax.HtmlCommentListGreen)trailingComment.Green).CreateRed();
		}
		
		public LinkTextWithCommentSyntax LinkTextWithComment(HtmlCommentListSyntax leadingComment, LinkTextElementSyntax linkTextElement)
		{
		    if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
		    if (linkTextElement == null) throw new ArgumentNullException(nameof(linkTextElement));
		    return (LinkTextWithCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextWithComment((Syntax.InternalSyntax.HtmlCommentListGreen)leadingComment.Green, (Syntax.InternalSyntax.LinkTextElementGreen)linkTextElement.Green).CreateRed();
		}
		
		public LinkTextElementSyntax LinkTextElement(TextElementsSyntax textElements)
		{
		    if (textElements == null) throw new ArgumentNullException(nameof(textElements));
		    return (LinkTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextElement((Syntax.InternalSyntax.TextElementsGreen)textElements.Green).CreateRed();
		}
		
		public LinkTextElementSyntax LinkTextElement(LinkTextElementsSyntax linkTextElements)
		{
		    if (linkTextElements == null) throw new ArgumentNullException(nameof(linkTextElements));
		    return (LinkTextElementSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextElement((Syntax.InternalSyntax.LinkTextElementsGreen)linkTextElements.Green).CreateRed();
		}
		
		public LinkTextElementsSyntax LinkTextElements(SyntaxToken linkTextElements)
		{
		    if (linkTextElements == null) throw new ArgumentNullException(nameof(linkTextElements));
		    return (LinkTextElementsSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextElements((InternalSyntaxToken)linkTextElements.Green).CreateRed();
		}
		
		public WikiFormatSyntax WikiFormat(SyntaxToken tFormat)
		{
		    if (tFormat == null) throw new ArgumentNullException(nameof(tFormat));
		    if (tFormat.RawKind != (int)MediaWikiSyntaxKind.TFormat) throw new ArgumentException(nameof(tFormat));
		    return (WikiFormatSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiFormat((InternalSyntaxToken)tFormat.Green).CreateRed();
		}
		
		public WikiLinkSyntax WikiLink(WikiInternalLinkSyntax wikiInternalLink)
		{
		    if (wikiInternalLink == null) throw new ArgumentNullException(nameof(wikiInternalLink));
		    return (WikiLinkSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiLink((Syntax.InternalSyntax.WikiInternalLinkGreen)wikiInternalLink.Green).CreateRed();
		}
		
		public WikiLinkSyntax WikiLink(WikiExternalLinkSyntax wikiExternalLink)
		{
		    if (wikiExternalLink == null) throw new ArgumentNullException(nameof(wikiExternalLink));
		    return (WikiLinkSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiLink((Syntax.InternalSyntax.WikiExternalLinkGreen)wikiExternalLink.Green).CreateRed();
		}
		
		public WikiInternalLinkSyntax WikiInternalLink(SyntaxToken tLinkStart, LinkTextSyntax linkText, SyntaxNodeList<LinkTextPartSyntax> linkTextPart, SyntaxToken tLinkEnd)
		{
		    if (tLinkStart == null) throw new ArgumentNullException(nameof(tLinkStart));
		    if (tLinkStart.RawKind != (int)MediaWikiSyntaxKind.TLinkStart) throw new ArgumentException(nameof(tLinkStart));
		    if (linkText == null) throw new ArgumentNullException(nameof(linkText));
		    if (tLinkEnd == null) throw new ArgumentNullException(nameof(tLinkEnd));
		    if (tLinkEnd.RawKind != (int)MediaWikiSyntaxKind.TLinkEnd) throw new ArgumentException(nameof(tLinkEnd));
		    return (WikiInternalLinkSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiInternalLink((InternalSyntaxToken)tLinkStart.Green, (Syntax.InternalSyntax.LinkTextGreen)linkText.Green, linkTextPart == null ? null : linkTextPart.Green, (InternalSyntaxToken)tLinkEnd.Green).CreateRed();
		}
		
		public WikiInternalLinkSyntax WikiInternalLink(SyntaxToken tLinkStart, LinkTextSyntax linkText)
		{
			return this.WikiInternalLink(tLinkStart, linkText, null, this.Token(MediaWikiSyntaxKind.TLinkEnd));
		}
		
		public WikiExternalLinkSyntax WikiExternalLink(SyntaxToken tExternalLinkStart, LinkTextSyntax linkText, SyntaxNodeList<LinkTextPartSyntax> linkTextPart, SyntaxToken tExternalLinkEnd)
		{
		    if (tExternalLinkStart == null) throw new ArgumentNullException(nameof(tExternalLinkStart));
		    if (tExternalLinkStart.RawKind != (int)MediaWikiSyntaxKind.TExternalLinkStart) throw new ArgumentException(nameof(tExternalLinkStart));
		    if (linkText == null) throw new ArgumentNullException(nameof(linkText));
		    if (tExternalLinkEnd == null) throw new ArgumentNullException(nameof(tExternalLinkEnd));
		    if (tExternalLinkEnd.RawKind != (int)MediaWikiSyntaxKind.TExternalLinkEnd) throw new ArgumentException(nameof(tExternalLinkEnd));
		    return (WikiExternalLinkSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiExternalLink((InternalSyntaxToken)tExternalLinkStart.Green, (Syntax.InternalSyntax.LinkTextGreen)linkText.Green, linkTextPart == null ? null : linkTextPart.Green, (InternalSyntaxToken)tExternalLinkEnd.Green).CreateRed();
		}
		
		public WikiExternalLinkSyntax WikiExternalLink(SyntaxToken tExternalLinkStart, LinkTextSyntax linkText)
		{
			return this.WikiExternalLink(tExternalLinkStart, linkText, null, this.Token(MediaWikiSyntaxKind.TExternalLinkEnd));
		}
		
		public WikiTemplateSyntax WikiTemplate(SyntaxToken tTemplateStart, LinkTextSyntax linkText, SyntaxNodeList<LinkTextPartSyntax> linkTextPart, SyntaxToken tTemplateEnd)
		{
		    if (tTemplateStart == null) throw new ArgumentNullException(nameof(tTemplateStart));
		    if (tTemplateStart.RawKind != (int)MediaWikiSyntaxKind.TTemplateStart) throw new ArgumentException(nameof(tTemplateStart));
		    if (linkText == null) throw new ArgumentNullException(nameof(linkText));
		    if (tTemplateEnd == null) throw new ArgumentNullException(nameof(tTemplateEnd));
		    if (tTemplateEnd.RawKind != (int)MediaWikiSyntaxKind.TTemplateEnd) throw new ArgumentException(nameof(tTemplateEnd));
		    return (WikiTemplateSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiTemplate((InternalSyntaxToken)tTemplateStart.Green, (Syntax.InternalSyntax.LinkTextGreen)linkText.Green, linkTextPart == null ? null : linkTextPart.Green, (InternalSyntaxToken)tTemplateEnd.Green).CreateRed();
		}
		
		public WikiTemplateSyntax WikiTemplate(SyntaxToken tTemplateStart, LinkTextSyntax linkText)
		{
			return this.WikiTemplate(tTemplateStart, linkText, null, this.Token(MediaWikiSyntaxKind.TTemplateEnd));
		}
		
		public WikiTemplateParamSyntax WikiTemplateParam(SyntaxToken tTemplateParamStart, LinkTextSyntax linkText, SyntaxNodeList<LinkTextPartSyntax> linkTextPart, SyntaxToken tTemplateParamEnd)
		{
		    if (tTemplateParamStart == null) throw new ArgumentNullException(nameof(tTemplateParamStart));
		    if (tTemplateParamStart.RawKind != (int)MediaWikiSyntaxKind.TTemplateParamStart) throw new ArgumentException(nameof(tTemplateParamStart));
		    if (linkText == null) throw new ArgumentNullException(nameof(linkText));
		    if (tTemplateParamEnd == null) throw new ArgumentNullException(nameof(tTemplateParamEnd));
		    if (tTemplateParamEnd.RawKind != (int)MediaWikiSyntaxKind.TTemplateParamEnd) throw new ArgumentException(nameof(tTemplateParamEnd));
		    return (WikiTemplateParamSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiTemplateParam((InternalSyntaxToken)tTemplateParamStart.Green, (Syntax.InternalSyntax.LinkTextGreen)linkText.Green, linkTextPart == null ? null : linkTextPart.Green, (InternalSyntaxToken)tTemplateParamEnd.Green).CreateRed();
		}
		
		public WikiTemplateParamSyntax WikiTemplateParam(SyntaxToken tTemplateParamStart, LinkTextSyntax linkText)
		{
			return this.WikiTemplateParam(tTemplateParamStart, linkText, null, this.Token(MediaWikiSyntaxKind.TTemplateParamEnd));
		}
		
		public NoWikiSyntax NoWiki(SyntaxToken tNoWiki)
		{
		    if (tNoWiki == null) throw new ArgumentNullException(nameof(tNoWiki));
		    if (tNoWiki.RawKind != (int)MediaWikiSyntaxKind.TNoWiki) throw new ArgumentException(nameof(tNoWiki));
		    return (NoWikiSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.NoWiki((InternalSyntaxToken)tNoWiki.Green).CreateRed();
		}
		
		public BarOrBarBarSyntax BarOrBarBar(SyntaxToken barOrBarBar)
		{
		    if (barOrBarBar == null) throw new ArgumentNullException(nameof(barOrBarBar));
		    return (BarOrBarBarSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.BarOrBarBar((InternalSyntaxToken)barOrBarBar.Green).CreateRed();
		}
		
		public LinkTextPartSyntax LinkTextPart(BarOrBarBarSyntax barOrBarBar, LinkTextSyntax linkText)
		{
		    if (barOrBarBar == null) throw new ArgumentNullException(nameof(barOrBarBar));
		    if (linkText == null) throw new ArgumentNullException(nameof(linkText));
		    return (LinkTextPartSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextPart((Syntax.InternalSyntax.BarOrBarBarGreen)barOrBarBar.Green, (Syntax.InternalSyntax.LinkTextGreen)linkText.Green).CreateRed();
		}
		
		public HtmlReferenceSyntax HtmlReference(SyntaxToken htmlReference)
		{
		    if (htmlReference == null) throw new ArgumentNullException(nameof(htmlReference));
		    return (HtmlReferenceSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlReference((InternalSyntaxToken)htmlReference.Green).CreateRed();
		}
		
		public HtmlCommentListSyntax HtmlCommentList(SyntaxNodeList<HtmlCommentSyntax> htmlComment)
		{
		    return (HtmlCommentListSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlCommentList(htmlComment == null ? null : htmlComment.Green).CreateRed();
		}
		
		public HtmlCommentListSyntax HtmlCommentList()
		{
			return this.HtmlCommentList(null);
		}
		
		public HtmlCommentSyntax HtmlComment(SyntaxToken tHtmlComment)
		{
		    if (tHtmlComment == null) throw new ArgumentNullException(nameof(tHtmlComment));
		    if (tHtmlComment.RawKind != (int)MediaWikiSyntaxKind.THtmlComment) throw new ArgumentException(nameof(tHtmlComment));
		    return (HtmlCommentSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlComment((InternalSyntaxToken)tHtmlComment.Green).CreateRed();
		}
		
		public HtmlStyleSyntax HtmlStyle(SyntaxToken tHtmlStyle)
		{
		    if (tHtmlStyle == null) throw new ArgumentNullException(nameof(tHtmlStyle));
		    if (tHtmlStyle.RawKind != (int)MediaWikiSyntaxKind.THtmlStyle) throw new ArgumentException(nameof(tHtmlStyle));
		    return (HtmlStyleSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlStyle((InternalSyntaxToken)tHtmlStyle.Green).CreateRed();
		}
		
		public HtmlScriptSyntax HtmlScript(SyntaxToken tHtmlScript)
		{
		    if (tHtmlScript == null) throw new ArgumentNullException(nameof(tHtmlScript));
		    if (tHtmlScript.RawKind != (int)MediaWikiSyntaxKind.THtmlScript) throw new ArgumentException(nameof(tHtmlScript));
		    return (HtmlScriptSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlScript((InternalSyntaxToken)tHtmlScript.Green).CreateRed();
		}
		
		public HtmlTagSyntax HtmlTag(HtmlTagOpenSyntax htmlTagOpen)
		{
		    if (htmlTagOpen == null) throw new ArgumentNullException(nameof(htmlTagOpen));
		    return (HtmlTagSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTag((Syntax.InternalSyntax.HtmlTagOpenGreen)htmlTagOpen.Green).CreateRed();
		}
		
		public HtmlTagSyntax HtmlTag(HtmlTagCloseSyntax htmlTagClose)
		{
		    if (htmlTagClose == null) throw new ArgumentNullException(nameof(htmlTagClose));
		    return (HtmlTagSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTag((Syntax.InternalSyntax.HtmlTagCloseGreen)htmlTagClose.Green).CreateRed();
		}
		
		public HtmlTagSyntax HtmlTag(HtmlTagEmptySyntax htmlTagEmpty)
		{
		    if (htmlTagEmpty == null) throw new ArgumentNullException(nameof(htmlTagEmpty));
		    return (HtmlTagSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTag((Syntax.InternalSyntax.HtmlTagEmptyGreen)htmlTagEmpty.Green).CreateRed();
		}
		
		public HtmlTagOpenSyntax HtmlTagOpen(SyntaxToken tTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute, WhitespaceListSyntax trailingWhitespace, SyntaxToken tTagEnd)
		{
		    if (tTagStart == null) throw new ArgumentNullException(nameof(tTagStart));
		    if (tTagStart.RawKind != (int)MediaWikiSyntaxKind.TTagStart) throw new ArgumentException(nameof(tTagStart));
		    if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
		    if (htmlTagName == null) throw new ArgumentNullException(nameof(htmlTagName));
		    if (trailingWhitespace == null) throw new ArgumentNullException(nameof(trailingWhitespace));
		    if (tTagEnd == null) throw new ArgumentNullException(nameof(tTagEnd));
		    if (tTagEnd.RawKind != (int)MediaWikiSyntaxKind.TTagEnd) throw new ArgumentException(nameof(tTagEnd));
		    return (HtmlTagOpenSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTagOpen((InternalSyntaxToken)tTagStart.Green, (Syntax.InternalSyntax.WhitespaceListGreen)leadingWhitespace.Green, (Syntax.InternalSyntax.HtmlTagNameGreen)htmlTagName.Green, htmlAttribute == null ? null : htmlAttribute.Green, (Syntax.InternalSyntax.WhitespaceListGreen)trailingWhitespace.Green, (InternalSyntaxToken)tTagEnd.Green).CreateRed();
		}
		
		public HtmlTagOpenSyntax HtmlTagOpen(SyntaxToken tTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, WhitespaceListSyntax trailingWhitespace, SyntaxToken tTagEnd)
		{
			return this.HtmlTagOpen(tTagStart, leadingWhitespace, htmlTagName, null, trailingWhitespace, tTagEnd);
		}
		
		public HtmlTagCloseSyntax HtmlTagClose(SyntaxToken tEndTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute, WhitespaceListSyntax trailingWhitespace, SyntaxToken tEndTagEnd)
		{
		    if (tEndTagStart == null) throw new ArgumentNullException(nameof(tEndTagStart));
		    if (tEndTagStart.RawKind != (int)MediaWikiSyntaxKind.TEndTagStart) throw new ArgumentException(nameof(tEndTagStart));
		    if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
		    if (htmlTagName == null) throw new ArgumentNullException(nameof(htmlTagName));
		    if (trailingWhitespace == null) throw new ArgumentNullException(nameof(trailingWhitespace));
		    if (tEndTagEnd == null) throw new ArgumentNullException(nameof(tEndTagEnd));
		    if (tEndTagEnd.RawKind != (int)MediaWikiSyntaxKind.TEndTagEnd) throw new ArgumentException(nameof(tEndTagEnd));
		    return (HtmlTagCloseSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTagClose((InternalSyntaxToken)tEndTagStart.Green, (Syntax.InternalSyntax.WhitespaceListGreen)leadingWhitespace.Green, (Syntax.InternalSyntax.HtmlTagNameGreen)htmlTagName.Green, htmlAttribute == null ? null : htmlAttribute.Green, (Syntax.InternalSyntax.WhitespaceListGreen)trailingWhitespace.Green, (InternalSyntaxToken)tEndTagEnd.Green).CreateRed();
		}
		
		public HtmlTagCloseSyntax HtmlTagClose(SyntaxToken tEndTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, WhitespaceListSyntax trailingWhitespace, SyntaxToken tEndTagEnd)
		{
			return this.HtmlTagClose(tEndTagStart, leadingWhitespace, htmlTagName, null, trailingWhitespace, tEndTagEnd);
		}
		
		public HtmlTagEmptySyntax HtmlTagEmpty(SyntaxToken tTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, SyntaxNodeList<HtmlAttributeSyntax> htmlAttribute, WhitespaceListSyntax trailingWhitespace, SyntaxToken tTagCloseEnd)
		{
		    if (tTagStart == null) throw new ArgumentNullException(nameof(tTagStart));
		    if (tTagStart.RawKind != (int)MediaWikiSyntaxKind.TTagStart) throw new ArgumentException(nameof(tTagStart));
		    if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
		    if (htmlTagName == null) throw new ArgumentNullException(nameof(htmlTagName));
		    if (trailingWhitespace == null) throw new ArgumentNullException(nameof(trailingWhitespace));
		    if (tTagCloseEnd == null) throw new ArgumentNullException(nameof(tTagCloseEnd));
		    if (tTagCloseEnd.RawKind != (int)MediaWikiSyntaxKind.TTagCloseEnd) throw new ArgumentException(nameof(tTagCloseEnd));
		    return (HtmlTagEmptySyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTagEmpty((InternalSyntaxToken)tTagStart.Green, (Syntax.InternalSyntax.WhitespaceListGreen)leadingWhitespace.Green, (Syntax.InternalSyntax.HtmlTagNameGreen)htmlTagName.Green, htmlAttribute == null ? null : htmlAttribute.Green, (Syntax.InternalSyntax.WhitespaceListGreen)trailingWhitespace.Green, (InternalSyntaxToken)tTagCloseEnd.Green).CreateRed();
		}
		
		public HtmlTagEmptySyntax HtmlTagEmpty(SyntaxToken tTagStart, WhitespaceListSyntax leadingWhitespace, HtmlTagNameSyntax htmlTagName, WhitespaceListSyntax trailingWhitespace)
		{
			return this.HtmlTagEmpty(tTagStart, leadingWhitespace, htmlTagName, null, trailingWhitespace, this.Token(MediaWikiSyntaxKind.TTagCloseEnd));
		}
		
		public HtmlAttributeWithValueSyntax HtmlAttributeWithValue(WhitespaceListSyntax leadingWhitespace, HtmlAttributeNameSyntax htmlAttributeName, WhitespaceListSyntax whitespaceBeforeEquals, SyntaxToken tAttributeEquals, WhitespaceListSyntax whitespaceAfterEquals, HtmlAttributeValueSyntax htmlAttributeValue)
		{
		    if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
		    if (htmlAttributeName == null) throw new ArgumentNullException(nameof(htmlAttributeName));
		    if (whitespaceBeforeEquals == null) throw new ArgumentNullException(nameof(whitespaceBeforeEquals));
		    if (tAttributeEquals == null) throw new ArgumentNullException(nameof(tAttributeEquals));
		    if (tAttributeEquals.RawKind != (int)MediaWikiSyntaxKind.TAttributeEquals) throw new ArgumentException(nameof(tAttributeEquals));
		    if (whitespaceAfterEquals == null) throw new ArgumentNullException(nameof(whitespaceAfterEquals));
		    if (htmlAttributeValue == null) throw new ArgumentNullException(nameof(htmlAttributeValue));
		    return (HtmlAttributeWithValueSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlAttributeWithValue((Syntax.InternalSyntax.WhitespaceListGreen)leadingWhitespace.Green, (Syntax.InternalSyntax.HtmlAttributeNameGreen)htmlAttributeName.Green, (Syntax.InternalSyntax.WhitespaceListGreen)whitespaceBeforeEquals.Green, (InternalSyntaxToken)tAttributeEquals.Green, (Syntax.InternalSyntax.WhitespaceListGreen)whitespaceAfterEquals.Green, (Syntax.InternalSyntax.HtmlAttributeValueGreen)htmlAttributeValue.Green).CreateRed();
		}
		
		public HtmlAttributeWithValueSyntax HtmlAttributeWithValue(WhitespaceListSyntax leadingWhitespace, HtmlAttributeNameSyntax htmlAttributeName, WhitespaceListSyntax whitespaceBeforeEquals, WhitespaceListSyntax whitespaceAfterEquals, HtmlAttributeValueSyntax htmlAttributeValue)
		{
			return this.HtmlAttributeWithValue(leadingWhitespace, htmlAttributeName, whitespaceBeforeEquals, this.Token(MediaWikiSyntaxKind.TAttributeEquals), whitespaceAfterEquals, htmlAttributeValue);
		}
		
		public HtmlAttributeWithNoValueSyntax HtmlAttributeWithNoValue(WhitespaceListSyntax leadingWhitespace, HtmlAttributeNameSyntax htmlAttributeName)
		{
		    if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
		    if (htmlAttributeName == null) throw new ArgumentNullException(nameof(htmlAttributeName));
		    return (HtmlAttributeWithNoValueSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlAttributeWithNoValue((Syntax.InternalSyntax.WhitespaceListGreen)leadingWhitespace.Green, (Syntax.InternalSyntax.HtmlAttributeNameGreen)htmlAttributeName.Green).CreateRed();
		}
		
		public HtmlAttributeNameSyntax HtmlAttributeName(SyntaxToken tTagName)
		{
		    if (tTagName == null) throw new ArgumentNullException(nameof(tTagName));
		    if (tTagName.RawKind != (int)MediaWikiSyntaxKind.TTagName) throw new ArgumentException(nameof(tTagName));
		    return (HtmlAttributeNameSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlAttributeName((InternalSyntaxToken)tTagName.Green).CreateRed();
		}
		
		public HtmlAttributeValueSyntax HtmlAttributeValue(SyntaxToken tAttributeValue)
		{
		    if (tAttributeValue == null) throw new ArgumentNullException(nameof(tAttributeValue));
		    if (tAttributeValue.RawKind != (int)MediaWikiSyntaxKind.TAttributeValue) throw new ArgumentException(nameof(tAttributeValue));
		    return (HtmlAttributeValueSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlAttributeValue((InternalSyntaxToken)tAttributeValue.Green).CreateRed();
		}
		
		public HtmlTagNameSyntax HtmlTagName(SyntaxToken tTagName)
		{
		    if (tTagName == null) throw new ArgumentNullException(nameof(tTagName));
		    if (tTagName.RawKind != (int)MediaWikiSyntaxKind.TTagName) throw new ArgumentException(nameof(tTagName));
		    return (HtmlTagNameSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTagName((InternalSyntaxToken)tTagName.Green).CreateRed();
		}
		
		public WhitespaceListSyntax WhitespaceList(SyntaxNodeList<WhitespaceSyntax> whitespace)
		{
		    return (WhitespaceListSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.WhitespaceList(whitespace == null ? null : whitespace.Green).CreateRed();
		}
		
		public WhitespaceListSyntax WhitespaceList()
		{
			return this.WhitespaceList(null);
		}
		
		public WhitespaceSyntax Whitespace(SyntaxToken whitespace)
		{
		    if (whitespace == null) throw new ArgumentNullException(nameof(whitespace));
		    return (WhitespaceSyntax)MediaWikiLanguage.Instance.InternalSyntaxFactory.Whitespace((InternalSyntaxToken)whitespace.Green).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(SpecialBlockOrParagraphSyntax),
				typeof(SpecialBlockWithCommentSyntax),
				typeof(SpecialBlockSyntax),
				typeof(HeadingSyntax),
				typeof(HeadingLevelSyntax),
				typeof(HorizontalRuleSyntax),
				typeof(CodeBlockSyntax),
				typeof(SpaceBlockSyntax),
				typeof(WikiListSyntax),
				typeof(ListItemSyntax),
				typeof(NormalListItemSyntax),
				typeof(DefinitionItemSyntax),
				typeof(WikiTableSyntax),
				typeof(TableCaptionSyntax),
				typeof(TableRowsSyntax),
				typeof(TableFirstRowSyntax),
				typeof(TableRowSyntax),
				typeof(TableColumnSyntax),
				typeof(TableSingleHeaderCellSyntax),
				typeof(TableHeaderCellsSyntax),
				typeof(TableSingleCellSyntax),
				typeof(TableCellsSyntax),
				typeof(TableCellSyntax),
				typeof(CellValueSyntax),
				typeof(ParagraphSyntax),
				typeof(TextLineInlineElementsWithCommentSyntax),
				typeof(TextLineCommentSyntax),
				typeof(TextElementsSyntax),
				typeof(InlineTextSyntax),
				typeof(InlineTextElementWithCommentSyntax),
				typeof(InlineTextElementSyntax),
				typeof(InlineTextElementsSyntax),
				typeof(DefinitionTextSyntax),
				typeof(DefinitionTextElementWithCommentSyntax),
				typeof(DefinitionTextElementSyntax),
				typeof(DefinitionTextElementsSyntax),
				typeof(HeadingTextSyntax),
				typeof(HeadingTextWithCommentSyntax),
				typeof(HeadingTextElementSyntax),
				typeof(HeadingTextElementsSyntax),
				typeof(CellTextSyntax),
				typeof(CellTextElementWithCommentSyntax),
				typeof(CellTextElementSyntax),
				typeof(CellTextElementsSyntax),
				typeof(LinkTextSyntax),
				typeof(LinkTextWithCommentSyntax),
				typeof(LinkTextElementSyntax),
				typeof(LinkTextElementsSyntax),
				typeof(WikiFormatSyntax),
				typeof(WikiLinkSyntax),
				typeof(WikiInternalLinkSyntax),
				typeof(WikiExternalLinkSyntax),
				typeof(WikiTemplateSyntax),
				typeof(WikiTemplateParamSyntax),
				typeof(NoWikiSyntax),
				typeof(BarOrBarBarSyntax),
				typeof(LinkTextPartSyntax),
				typeof(HtmlReferenceSyntax),
				typeof(HtmlCommentListSyntax),
				typeof(HtmlCommentSyntax),
				typeof(HtmlStyleSyntax),
				typeof(HtmlScriptSyntax),
				typeof(HtmlTagSyntax),
				typeof(HtmlTagOpenSyntax),
				typeof(HtmlTagCloseSyntax),
				typeof(HtmlTagEmptySyntax),
				typeof(HtmlAttributeWithValueSyntax),
				typeof(HtmlAttributeWithNoValueSyntax),
				typeof(HtmlAttributeNameSyntax),
				typeof(HtmlAttributeValueSyntax),
				typeof(HtmlTagNameSyntax),
				typeof(WhitespaceListSyntax),
				typeof(WhitespaceSyntax),
			};
		}
	}
}

