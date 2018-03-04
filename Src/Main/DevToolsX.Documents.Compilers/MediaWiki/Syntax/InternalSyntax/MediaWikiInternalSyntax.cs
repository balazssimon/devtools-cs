// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;

namespace DevToolsX.Documents.Compilers.MediaWiki.Syntax.InternalSyntax
{
    internal abstract class MediaWikiGreenNode : InternalSyntaxNode
    {
        public MediaWikiGreenNode(MediaWikiSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, 0, diagnostics, annotations)
        {
        }

        public MediaWikiSyntaxKind Kind
        {
            get { return (MediaWikiSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return MediaWikiLanguage.Instance; }
        }
    }

    internal class MediaWikiGreenTrivia : InternalSyntaxTrivia
    {
        public MediaWikiGreenTrivia(MediaWikiSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, text, diagnostics, annotations)
        {
        }

        public MediaWikiSyntaxKind Kind
        {
            get { return (MediaWikiSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return MediaWikiLanguage.Instance; }
        }

        public override SyntaxTrivia CreateRed(SyntaxToken parent, int position, int index)
        {
            return new MediaWikiSyntaxTrivia(this, parent, position, index);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new MediaWikiGreenTrivia(this.Kind, this.Text, diagnostics, this.GetAnnotations());
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new MediaWikiGreenTrivia(this.Kind, this.Text, this.GetDiagnostics(), annotations);
        }
    }

	public class MediaWikiGreenToken : InternalSyntaxToken
	{
		public MediaWikiGreenToken(MediaWikiSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
		    : base((int)kind, diagnostics, annotations)
		{
		}
	
	    public MediaWikiGreenToken(MediaWikiSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base((int)kind, fullWidth, diagnostics, annotations)
	    {
	    }
	
	    public MediaWikiSyntaxKind Kind
		{
		    get { return (MediaWikiSyntaxKind)base.RawKind; }
		}
	
		public virtual MediaWikiSyntaxKind ContextualKind
		{
		    get { return this.Kind; }
		}
	
	    public override string Text
	    {
	        get
	        {
	            return MediaWikiLanguage.Instance.SyntaxFacts.GetText(this.Kind);
	        }
	    }
	
	    public override Language Language
	    {
	        get { return MediaWikiLanguage.Instance; }
	    }
	
	    public override SyntaxToken CreateRed(SyntaxNode parent, int position, int index)
	    {
	        return new MediaWikiSyntaxToken(this, parent, position, index);
	    }
	
	    public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	    {
	        return new SyntaxTokenWithTrivia(this.Kind, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	    }
	
	    public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	    {
	        return new SyntaxTokenWithTrivia(this.Kind, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MediaWikiGreenToken(this.Kind, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MediaWikiGreenToken(this.Kind, diagnostics, this.GetAnnotations());
	    }
	
	    internal static MediaWikiGreenToken Create(MediaWikiSyntaxKind kind)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!MediaWikiLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid token kind '{0}'. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	
	            return CreateMissing(kind, null, null);
	        }
	
	        return s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	    }
	
	    internal static MediaWikiGreenToken Create(MediaWikiSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!MediaWikiLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid token kind '{0}'. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	
	            return CreateMissing(kind, leading, trailing);
	        }
	
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	            else if (trailing == MediaWikiLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	            else if (trailing == MediaWikiLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	        }
	
	        if (leading == MediaWikiLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == MediaWikiLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	        }
	
	        return new SyntaxTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static MediaWikiGreenToken CreateMissing(MediaWikiSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static readonly MediaWikiSyntaxKind FirstTokenWithWellKnownText = MediaWikiSyntaxKind.TSpaceBlockStart;
	    internal static readonly MediaWikiSyntaxKind LastTokenWithWellKnownText = MediaWikiSyntaxKind.TTextLine_RefStart;
	
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly MediaWikiGreenToken[] s_tokensWithNoTrivia = new MediaWikiGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly MediaWikiGreenToken[] s_tokensWithElasticTrivia = new MediaWikiGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly MediaWikiGreenToken[] s_tokensWithSingleTrailingSpace = new MediaWikiGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly MediaWikiGreenToken[] s_tokensWithSingleTrailingCRLF = new MediaWikiGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	
	    static MediaWikiGreenToken()
	    {
	        for (var kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new MediaWikiGreenToken(kind, null, null);
	            s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, MediaWikiLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, MediaWikiLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, null, null);
	            s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, MediaWikiLanguage.Instance.InternalSyntaxFactory.Space, null, null);
	            s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, MediaWikiLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed, null, null);
	        }
	    }
	
	    internal static IEnumerable<MediaWikiGreenToken> GetWellKnownTokens()
	    {
	        foreach (var element in s_tokensWithNoTrivia)
	        {
	            if (element.Value != null)
	            {
	                yield return element;
	            }
	        }
	
	        foreach (var element in s_tokensWithElasticTrivia)
	        {
	            if (element.Value != null)
	            {
	                yield return element;
	            }
	        }
	
	        foreach (var element in s_tokensWithSingleTrailingSpace)
	        {
	            if (element.Value != null)
	            {
	                yield return element;
	            }
	        }
	
	        foreach (var element in s_tokensWithSingleTrailingCRLF)
	        {
	            if (element.Value != null)
	            {
	                yield return element;
	            }
	        }
	    }
	
	    internal static MediaWikiGreenToken WithText(MediaWikiSyntaxKind kind, string text)
	    {
	        return new SyntaxTokenWithText(kind, text, null, null);
	    }
	
	    internal static MediaWikiGreenToken WithText(MediaWikiSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
	    {
	        if (leading == null)
	        {
	            if (trailing == null)
	            {
	                return WithText(kind, text);
	            }
	            else
	            {
	                return new SyntaxTokenWithTextAndTrailingTrivia(kind, text, trailing, null, null);
	            }
	        }
	
	        return new SyntaxTokenWithTextAndTrivia(kind, text, text, leading, trailing, null, null);
	    }
	
	    internal static MediaWikiGreenToken WithText(MediaWikiSyntaxKind kind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (valueText == text)
	        {
	            return WithText(kind, leading, text, trailing);
	        }
	
	        return new SyntaxTokenWithTextAndTrivia(kind, text, valueText, leading, trailing, null, null);
	    }
	
	    internal static MediaWikiGreenToken WithValue<T>(MediaWikiSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value, null, null);
	    }
	
	    internal static MediaWikiGreenToken WithValue<T>(MediaWikiSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing, null, null);
	    }
	
	    private class SyntaxTokenWithTrivia : MediaWikiGreenToken
	    {
	        protected readonly GreenNode LeadingField;
	        protected readonly GreenNode TrailingField;
	
	        internal SyntaxTokenWithTrivia(MediaWikiSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, diagnostics, annotations)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                this.LeadingField = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                this.TrailingField = trailing;
	            }
	        }
	
	        public override GreenNode GetLeadingTrivia()
	        {
	            return this.LeadingField;
	        }
	
	        public override GreenNode GetTrailingTrivia()
	        {
	            return this.TrailingField;
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, trivia, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class MissingTokenWithTrivia : SyntaxTokenWithTrivia
	    {
	        internal MissingTokenWithTrivia(MediaWikiSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, leading, trailing, diagnostics, annotations)
	        {
	            this.AddFlags(NodeFlags.IsMissing);
	        }
	
	        public override string Text
	        {
	            get { return string.Empty; }
	        }
	
	        public override object Value
	        {
	            get { return null; }
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new MissingTokenWithTrivia(this.Kind, trivia, this.TrailingField, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new MissingTokenWithTrivia(this.Kind, this.LeadingField, this.TrailingField, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithText : MediaWikiGreenToken
	    {
	        protected readonly string TextField;
	
	        internal SyntaxTokenWithText(MediaWikiSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text.Length, diagnostics, annotations)
	        {
	            this.TextField = text;
	        }
	
	        public override string Text
	        {
	            get { return this.TextField; }
	        }
	
	        public override object Value
	        {
	            get { return this.TextField; }
	        }
	
	        public override string ValueText
	        {
	            get { return this.TextField; }
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.TextField, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.TextField, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithText(this.Kind, this.Text, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithText(this.Kind, this.Text, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxIdentifierExtended : SyntaxTokenWithText
	    {
	        protected readonly string valueText;
	
	        internal SyntaxIdentifierExtended(MediaWikiSyntaxKind kind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            this.valueText = valueText;
	        }
	
	        public override string ValueText
	        {
	            get { return this.valueText; }
	        }
	
	        public override object Value
	        {
	            get { return this.valueText; }
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxIdentifierExtended(this.Kind, this.TextField, this.valueText, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxIdentifierExtended(this.Kind, this.TextField, this.valueText, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithTextAndTrailingTrivia : SyntaxTokenWithText
	    {
	        private readonly GreenNode _trailing;
	
	        internal SyntaxTokenWithTextAndTrailingTrivia(MediaWikiSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text, diagnostics, annotations)
	        {
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.TextField, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrailingTrivia(this.Kind, this.TextField, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithTextAndTrailingTrivia(this.Kind, this.TextField, _trailing, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithTextAndTrailingTrivia(this.Kind, this.TextField, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithTextAndTrivia : SyntaxIdentifierExtended
	    {
	        private readonly GreenNode _leading;
	        private readonly GreenNode _trailing;
	
	        internal SyntaxTokenWithTextAndTrivia(
	            MediaWikiSyntaxKind kind,
	            string text,
	            string valueText,
	            GreenNode leading,
	            GreenNode trailing,
	            DiagnosticInfo[] diagnostics,
	            SyntaxAnnotation[] annotations)
	            : base(kind, text, valueText, diagnostics, annotations)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                _leading = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	
	        public override GreenNode GetLeadingTrivia()
	        {
	            return _leading;
	        }
	
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, _leading, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, _leading, _trailing, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithTextAndTrivia(this.Kind, this.TextField, this.valueText, _leading, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithValue<T> : MediaWikiGreenToken
	    {
	        protected readonly string TextField;
	        protected readonly T ValueField;
	
	        internal SyntaxTokenWithValue(MediaWikiSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	            : base(kind, text.Length, diagnostics, annotations)
	        {
	            this.TextField = text;
	            this.ValueField = value;
	        }
	
	        public override string Text
	        {
	            get
	            {
	                return this.TextField;
	            }
	        }
	
	        public override object Value
	        {
	            get
	            {
	                return this.ValueField;
	            }
	        }
	
	        public override string ValueText
	        {
	            get
	            {
	                return Convert.ToString(this.ValueField, CultureInfo.InvariantCulture);
	            }
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, trivia, null, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, null, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithValue<T>(this.Kind, this.TextField, this.ValueField, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithValue<T>(this.Kind, this.TextField, this.ValueField, this.GetDiagnostics(), annotations);
	        }
	    }
	
	    private class SyntaxTokenWithValueAndTrivia<T> : SyntaxTokenWithValue<T>
	    {
	        private readonly GreenNode _leading;
	        private readonly GreenNode _trailing;
	
	        internal SyntaxTokenWithValueAndTrivia(
	            MediaWikiSyntaxKind kind,
	            string text,
	            T value,
	            GreenNode leading,
	            GreenNode trailing,
	            DiagnosticInfo[] diagnostics,
	            SyntaxAnnotation[] annotations)
	            : base(kind, text, value, diagnostics, annotations)
	        {
	            if (leading != null)
	            {
	                this.AdjustFlagsAndWidth(leading);
	                _leading = leading;
	            }
	            if (trailing != null)
	            {
	                this.AdjustFlagsAndWidth(trailing);
	                _trailing = trailing;
	            }
	        }
	
	        public override GreenNode GetLeadingTrivia()
	        {
	            return _leading;
	        }
	
	        public override GreenNode GetTrailingTrivia()
	        {
	            return _trailing;
	        }
	
	        public override InternalSyntaxToken WithLeadingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, trivia, _trailing, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override InternalSyntaxToken WithTrailingTrivia(GreenNode trivia)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, trivia, this.GetDiagnostics(), this.GetAnnotations());
	        }
	
	        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, _trailing, diagnostics, this.GetAnnotations());
	        }
	
	        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	        {
	            return new SyntaxTokenWithValueAndTrivia<T>(this.Kind, this.TextField, this.ValueField, _leading, _trailing, this.GetDiagnostics(), annotations);
	        }
	    }
	}
	
	internal class MainGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList specialBlockOrParagraph;
	    private InternalSyntaxToken eof;
	
	    public MainGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList specialBlockOrParagraph, InternalSyntaxToken eof)
	        : base(kind, null, null)
	    {
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
	    public MainGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList specialBlockOrParagraph, InternalSyntaxToken eof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList SpecialBlockOrParagraph { get { return this.specialBlockOrParagraph; } }
	    public InternalSyntaxToken Eof { get { return this.eof; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.MainSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.specialBlockOrParagraph;
	            case 1: return this.eof;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.specialBlockOrParagraph, this.eof, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.specialBlockOrParagraph, this.eof, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(InternalSyntaxNodeList specialBlockOrParagraph, InternalSyntaxToken eof)
	    {
	        if (this.specialBlockOrParagraph != specialBlockOrParagraph ||
				this.eof != eof)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.Main(specialBlockOrParagraph, eof);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SpecialBlockOrParagraphGreen : MediaWikiGreenNode
	{
	    private SpecialBlockWithCommentGreen specialBlockWithComment;
	    private ParagraphGreen paragraph;
	
	    public SpecialBlockOrParagraphGreen(MediaWikiSyntaxKind kind, SpecialBlockWithCommentGreen specialBlockWithComment, ParagraphGreen paragraph)
	        : base(kind, null, null)
	    {
			if (specialBlockWithComment != null)
			{
				this.AdjustFlagsAndWidth(specialBlockWithComment);
				this.specialBlockWithComment = specialBlockWithComment;
			}
			if (paragraph != null)
			{
				this.AdjustFlagsAndWidth(paragraph);
				this.paragraph = paragraph;
			}
	    }
	
	    public SpecialBlockOrParagraphGreen(MediaWikiSyntaxKind kind, SpecialBlockWithCommentGreen specialBlockWithComment, ParagraphGreen paragraph, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (specialBlockWithComment != null)
			{
				this.AdjustFlagsAndWidth(specialBlockWithComment);
				this.specialBlockWithComment = specialBlockWithComment;
			}
			if (paragraph != null)
			{
				this.AdjustFlagsAndWidth(paragraph);
				this.paragraph = paragraph;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public SpecialBlockWithCommentGreen SpecialBlockWithComment { get { return this.specialBlockWithComment; } }
	    public ParagraphGreen Paragraph { get { return this.paragraph; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.SpecialBlockOrParagraphSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.specialBlockWithComment;
	            case 1: return this.paragraph;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SpecialBlockOrParagraphGreen(this.Kind, this.specialBlockWithComment, this.paragraph, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SpecialBlockOrParagraphGreen(this.Kind, this.specialBlockWithComment, this.paragraph, this.GetDiagnostics(), annotations);
	    }
	
	    public SpecialBlockOrParagraphGreen Update(SpecialBlockWithCommentGreen specialBlockWithComment)
	    {
	        if (this.specialBlockWithComment != specialBlockWithComment)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlockOrParagraph(specialBlockWithComment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockOrParagraphGreen)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockOrParagraphGreen Update(ParagraphGreen paragraph)
	    {
	        if (this.paragraph != paragraph)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlockOrParagraph(paragraph);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockOrParagraphGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SpecialBlockWithCommentGreen : MediaWikiGreenNode
	{
	    private HtmlCommentListGreen leadingComment;
	    private SpecialBlockGreen specialBlock;
	    private HtmlCommentListGreen trailingComment;
	    private InternalSyntaxToken crlf;
	
	    public SpecialBlockWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, SpecialBlockGreen specialBlock, HtmlCommentListGreen trailingComment, InternalSyntaxToken crlf)
	        : base(kind, null, null)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (specialBlock != null)
			{
				this.AdjustFlagsAndWidth(specialBlock);
				this.specialBlock = specialBlock;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
	    }
	
	    public SpecialBlockWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, SpecialBlockGreen specialBlock, HtmlCommentListGreen trailingComment, InternalSyntaxToken crlf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (specialBlock != null)
			{
				this.AdjustFlagsAndWidth(specialBlock);
				this.specialBlock = specialBlock;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public HtmlCommentListGreen LeadingComment { get { return this.leadingComment; } }
	    public SpecialBlockGreen SpecialBlock { get { return this.specialBlock; } }
	    public HtmlCommentListGreen TrailingComment { get { return this.trailingComment; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.SpecialBlockWithCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingComment;
	            case 1: return this.specialBlock;
	            case 2: return this.trailingComment;
	            case 3: return this.crlf;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SpecialBlockWithCommentGreen(this.Kind, this.leadingComment, this.specialBlock, this.trailingComment, this.crlf, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SpecialBlockWithCommentGreen(this.Kind, this.leadingComment, this.specialBlock, this.trailingComment, this.crlf, this.GetDiagnostics(), annotations);
	    }
	
	    public SpecialBlockWithCommentGreen Update(HtmlCommentListGreen leadingComment, SpecialBlockGreen specialBlock, HtmlCommentListGreen trailingComment, InternalSyntaxToken crlf)
	    {
	        if (this.leadingComment != leadingComment ||
				this.specialBlock != specialBlock ||
				this.trailingComment != trailingComment ||
				this.crlf != crlf)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlockWithComment(leadingComment, specialBlock, trailingComment, crlf);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockWithCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SpecialBlockGreen : MediaWikiGreenNode
	{
	    private HeadingGreen heading;
	    private HorizontalRuleGreen horizontalRule;
	    private CodeBlockGreen codeBlock;
	    private WikiListGreen wikiList;
	    private WikiTableGreen wikiTable;
	
	    public SpecialBlockGreen(MediaWikiSyntaxKind kind, HeadingGreen heading, HorizontalRuleGreen horizontalRule, CodeBlockGreen codeBlock, WikiListGreen wikiList, WikiTableGreen wikiTable)
	        : base(kind, null, null)
	    {
			if (heading != null)
			{
				this.AdjustFlagsAndWidth(heading);
				this.heading = heading;
			}
			if (horizontalRule != null)
			{
				this.AdjustFlagsAndWidth(horizontalRule);
				this.horizontalRule = horizontalRule;
			}
			if (codeBlock != null)
			{
				this.AdjustFlagsAndWidth(codeBlock);
				this.codeBlock = codeBlock;
			}
			if (wikiList != null)
			{
				this.AdjustFlagsAndWidth(wikiList);
				this.wikiList = wikiList;
			}
			if (wikiTable != null)
			{
				this.AdjustFlagsAndWidth(wikiTable);
				this.wikiTable = wikiTable;
			}
	    }
	
	    public SpecialBlockGreen(MediaWikiSyntaxKind kind, HeadingGreen heading, HorizontalRuleGreen horizontalRule, CodeBlockGreen codeBlock, WikiListGreen wikiList, WikiTableGreen wikiTable, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (heading != null)
			{
				this.AdjustFlagsAndWidth(heading);
				this.heading = heading;
			}
			if (horizontalRule != null)
			{
				this.AdjustFlagsAndWidth(horizontalRule);
				this.horizontalRule = horizontalRule;
			}
			if (codeBlock != null)
			{
				this.AdjustFlagsAndWidth(codeBlock);
				this.codeBlock = codeBlock;
			}
			if (wikiList != null)
			{
				this.AdjustFlagsAndWidth(wikiList);
				this.wikiList = wikiList;
			}
			if (wikiTable != null)
			{
				this.AdjustFlagsAndWidth(wikiTable);
				this.wikiTable = wikiTable;
			}
	    }
	
		public override int SlotCount { get { return 5; } }
	
	    public HeadingGreen Heading { get { return this.heading; } }
	    public HorizontalRuleGreen HorizontalRule { get { return this.horizontalRule; } }
	    public CodeBlockGreen CodeBlock { get { return this.codeBlock; } }
	    public WikiListGreen WikiList { get { return this.wikiList; } }
	    public WikiTableGreen WikiTable { get { return this.wikiTable; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.SpecialBlockSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SpecialBlockGreen(this.Kind, this.heading, this.horizontalRule, this.codeBlock, this.wikiList, this.wikiTable, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SpecialBlockGreen(this.Kind, this.heading, this.horizontalRule, this.codeBlock, this.wikiList, this.wikiTable, this.GetDiagnostics(), annotations);
	    }
	
	    public SpecialBlockGreen Update(HeadingGreen heading)
	    {
	        if (this.heading != heading)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock(heading);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockGreen)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockGreen Update(HorizontalRuleGreen horizontalRule)
	    {
	        if (this.horizontalRule != horizontalRule)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock(horizontalRule);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockGreen)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockGreen Update(CodeBlockGreen codeBlock)
	    {
	        if (this.codeBlock != codeBlock)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock(codeBlock);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockGreen)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockGreen Update(WikiListGreen wikiList)
	    {
	        if (this.wikiList != wikiList)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock(wikiList);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockGreen)newNode;
	        }
	        return this;
	    }
	
	    public SpecialBlockGreen Update(WikiTableGreen wikiTable)
	    {
	        if (this.wikiTable != wikiTable)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpecialBlock(wikiTable);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpecialBlockGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HeadingGreen : MediaWikiGreenNode
	{
	    private HeadingLevelGreen headingStart;
	    private HeadingTextGreen headingText;
	    private HeadingLevelGreen headingEnd;
	    private InlineTextGreen inlineText;
	
	    public HeadingGreen(MediaWikiSyntaxKind kind, HeadingLevelGreen headingStart, HeadingTextGreen headingText, HeadingLevelGreen headingEnd, InlineTextGreen inlineText)
	        : base(kind, null, null)
	    {
			if (headingStart != null)
			{
				this.AdjustFlagsAndWidth(headingStart);
				this.headingStart = headingStart;
			}
			if (headingText != null)
			{
				this.AdjustFlagsAndWidth(headingText);
				this.headingText = headingText;
			}
			if (headingEnd != null)
			{
				this.AdjustFlagsAndWidth(headingEnd);
				this.headingEnd = headingEnd;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
	    public HeadingGreen(MediaWikiSyntaxKind kind, HeadingLevelGreen headingStart, HeadingTextGreen headingText, HeadingLevelGreen headingEnd, InlineTextGreen inlineText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (headingStart != null)
			{
				this.AdjustFlagsAndWidth(headingStart);
				this.headingStart = headingStart;
			}
			if (headingText != null)
			{
				this.AdjustFlagsAndWidth(headingText);
				this.headingText = headingText;
			}
			if (headingEnd != null)
			{
				this.AdjustFlagsAndWidth(headingEnd);
				this.headingEnd = headingEnd;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public HeadingLevelGreen HeadingStart { get { return this.headingStart; } }
	    public HeadingTextGreen HeadingText { get { return this.headingText; } }
	    public HeadingLevelGreen HeadingEnd { get { return this.headingEnd; } }
	    public InlineTextGreen InlineText { get { return this.inlineText; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HeadingSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HeadingGreen(this.Kind, this.headingStart, this.headingText, this.headingEnd, this.inlineText, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HeadingGreen(this.Kind, this.headingStart, this.headingText, this.headingEnd, this.inlineText, this.GetDiagnostics(), annotations);
	    }
	
	    public HeadingGreen Update(HeadingLevelGreen headingStart, HeadingTextGreen headingText, HeadingLevelGreen headingEnd, InlineTextGreen inlineText)
	    {
	        if (this.headingStart != headingStart ||
				this.headingText != headingText ||
				this.headingEnd != headingEnd ||
				this.inlineText != inlineText)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.Heading(headingStart, headingText, headingEnd, inlineText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HeadingLevelGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tHeading;
	
	    public HeadingLevelGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHeading)
	        : base(kind, null, null)
	    {
			if (tHeading != null)
			{
				this.AdjustFlagsAndWidth(tHeading);
				this.tHeading = tHeading;
			}
	    }
	
	    public HeadingLevelGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHeading, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tHeading != null)
			{
				this.AdjustFlagsAndWidth(tHeading);
				this.tHeading = tHeading;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken THeading { get { return this.tHeading; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HeadingLevelSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tHeading;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HeadingLevelGreen(this.Kind, this.tHeading, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HeadingLevelGreen(this.Kind, this.tHeading, this.GetDiagnostics(), annotations);
	    }
	
	    public HeadingLevelGreen Update(InternalSyntaxToken tHeading)
	    {
	        if (this.tHeading != tHeading)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingLevel(tHeading);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingLevelGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HorizontalRuleGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tHorizontalLine;
	    private InlineTextGreen inlineText;
	
	    public HorizontalRuleGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHorizontalLine, InlineTextGreen inlineText)
	        : base(kind, null, null)
	    {
			if (tHorizontalLine != null)
			{
				this.AdjustFlagsAndWidth(tHorizontalLine);
				this.tHorizontalLine = tHorizontalLine;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
	    public HorizontalRuleGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHorizontalLine, InlineTextGreen inlineText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tHorizontalLine != null)
			{
				this.AdjustFlagsAndWidth(tHorizontalLine);
				this.tHorizontalLine = tHorizontalLine;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken THorizontalLine { get { return this.tHorizontalLine; } }
	    public InlineTextGreen InlineText { get { return this.inlineText; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HorizontalRuleSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tHorizontalLine;
	            case 1: return this.inlineText;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HorizontalRuleGreen(this.Kind, this.tHorizontalLine, this.inlineText, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HorizontalRuleGreen(this.Kind, this.tHorizontalLine, this.inlineText, this.GetDiagnostics(), annotations);
	    }
	
	    public HorizontalRuleGreen Update(InternalSyntaxToken tHorizontalLine, InlineTextGreen inlineText)
	    {
	        if (this.tHorizontalLine != tHorizontalLine ||
				this.inlineText != inlineText)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HorizontalRule(tHorizontalLine, inlineText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HorizontalRuleGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CodeBlockGreen : MediaWikiGreenNode
	{
	    private InternalSeparatedSyntaxNodeList spaceBlock;
	
	    public CodeBlockGreen(MediaWikiSyntaxKind kind, InternalSeparatedSyntaxNodeList spaceBlock)
	        : base(kind, null, null)
	    {
			if (spaceBlock != null)
			{
				this.AdjustFlagsAndWidth(spaceBlock);
				this.spaceBlock = spaceBlock;
			}
	    }
	
	    public CodeBlockGreen(MediaWikiSyntaxKind kind, InternalSeparatedSyntaxNodeList spaceBlock, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (spaceBlock != null)
			{
				this.AdjustFlagsAndWidth(spaceBlock);
				this.spaceBlock = spaceBlock;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList SpaceBlock { get { return this.spaceBlock; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.CodeBlockSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.spaceBlock;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CodeBlockGreen(this.Kind, this.spaceBlock, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CodeBlockGreen(this.Kind, this.spaceBlock, this.GetDiagnostics(), annotations);
	    }
	
	    public CodeBlockGreen Update(InternalSeparatedSyntaxNodeList spaceBlock)
	    {
	        if (this.spaceBlock != spaceBlock)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.CodeBlock(spaceBlock);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CodeBlockGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class SpaceBlockGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tSpaceBlockStart;
	    private InlineTextGreen inlineText;
	
	    public SpaceBlockGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tSpaceBlockStart, InlineTextGreen inlineText)
	        : base(kind, null, null)
	    {
			if (tSpaceBlockStart != null)
			{
				this.AdjustFlagsAndWidth(tSpaceBlockStart);
				this.tSpaceBlockStart = tSpaceBlockStart;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
	    public SpaceBlockGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tSpaceBlockStart, InlineTextGreen inlineText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSpaceBlockStart != null)
			{
				this.AdjustFlagsAndWidth(tSpaceBlockStart);
				this.tSpaceBlockStart = tSpaceBlockStart;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TSpaceBlockStart { get { return this.tSpaceBlockStart; } }
	    public InlineTextGreen InlineText { get { return this.inlineText; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.SpaceBlockSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSpaceBlockStart;
	            case 1: return this.inlineText;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SpaceBlockGreen(this.Kind, this.tSpaceBlockStart, this.inlineText, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new SpaceBlockGreen(this.Kind, this.tSpaceBlockStart, this.inlineText, this.GetDiagnostics(), annotations);
	    }
	
	    public SpaceBlockGreen Update(InternalSyntaxToken tSpaceBlockStart, InlineTextGreen inlineText)
	    {
	        if (this.tSpaceBlockStart != tSpaceBlockStart ||
				this.inlineText != inlineText)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.SpaceBlock(tSpaceBlockStart, inlineText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SpaceBlockGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WikiListGreen : MediaWikiGreenNode
	{
	    private InternalSeparatedSyntaxNodeList listItem;
	
	    public WikiListGreen(MediaWikiSyntaxKind kind, InternalSeparatedSyntaxNodeList listItem)
	        : base(kind, null, null)
	    {
			if (listItem != null)
			{
				this.AdjustFlagsAndWidth(listItem);
				this.listItem = listItem;
			}
	    }
	
	    public WikiListGreen(MediaWikiSyntaxKind kind, InternalSeparatedSyntaxNodeList listItem, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (listItem != null)
			{
				this.AdjustFlagsAndWidth(listItem);
				this.listItem = listItem;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList ListItem { get { return this.listItem; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WikiListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.listItem;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WikiListGreen(this.Kind, this.listItem, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WikiListGreen(this.Kind, this.listItem, this.GetDiagnostics(), annotations);
	    }
	
	    public WikiListGreen Update(InternalSeparatedSyntaxNodeList listItem)
	    {
	        if (this.listItem != listItem)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiList(listItem);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ListItemGreen : MediaWikiGreenNode
	{
	    private NormalListItemGreen normalListItem;
	    private DefinitionItemGreen definitionItem;
	
	    public ListItemGreen(MediaWikiSyntaxKind kind, NormalListItemGreen normalListItem, DefinitionItemGreen definitionItem)
	        : base(kind, null, null)
	    {
			if (normalListItem != null)
			{
				this.AdjustFlagsAndWidth(normalListItem);
				this.normalListItem = normalListItem;
			}
			if (definitionItem != null)
			{
				this.AdjustFlagsAndWidth(definitionItem);
				this.definitionItem = definitionItem;
			}
	    }
	
	    public ListItemGreen(MediaWikiSyntaxKind kind, NormalListItemGreen normalListItem, DefinitionItemGreen definitionItem, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (normalListItem != null)
			{
				this.AdjustFlagsAndWidth(normalListItem);
				this.normalListItem = normalListItem;
			}
			if (definitionItem != null)
			{
				this.AdjustFlagsAndWidth(definitionItem);
				this.definitionItem = definitionItem;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public NormalListItemGreen NormalListItem { get { return this.normalListItem; } }
	    public DefinitionItemGreen DefinitionItem { get { return this.definitionItem; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.ListItemSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.normalListItem;
	            case 1: return this.definitionItem;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ListItemGreen(this.Kind, this.normalListItem, this.definitionItem, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ListItemGreen(this.Kind, this.normalListItem, this.definitionItem, this.GetDiagnostics(), annotations);
	    }
	
	    public ListItemGreen Update(NormalListItemGreen normalListItem)
	    {
	        if (this.normalListItem != normalListItem)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.ListItem(normalListItem);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ListItemGreen)newNode;
	        }
	        return this;
	    }
	
	    public ListItemGreen Update(DefinitionItemGreen definitionItem)
	    {
	        if (this.definitionItem != definitionItem)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.ListItem(definitionItem);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ListItemGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NormalListItemGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tListStart;
	    private InlineTextGreen inlineText;
	
	    public NormalListItemGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tListStart, InlineTextGreen inlineText)
	        : base(kind, null, null)
	    {
			if (tListStart != null)
			{
				this.AdjustFlagsAndWidth(tListStart);
				this.tListStart = tListStart;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
	    public NormalListItemGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tListStart, InlineTextGreen inlineText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tListStart != null)
			{
				this.AdjustFlagsAndWidth(tListStart);
				this.tListStart = tListStart;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TListStart { get { return this.tListStart; } }
	    public InlineTextGreen InlineText { get { return this.inlineText; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.NormalListItemSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tListStart;
	            case 1: return this.inlineText;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NormalListItemGreen(this.Kind, this.tListStart, this.inlineText, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NormalListItemGreen(this.Kind, this.tListStart, this.inlineText, this.GetDiagnostics(), annotations);
	    }
	
	    public NormalListItemGreen Update(InternalSyntaxToken tListStart, InlineTextGreen inlineText)
	    {
	        if (this.tListStart != tListStart ||
				this.inlineText != inlineText)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.NormalListItem(tListStart, inlineText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NormalListItemGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DefinitionItemGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tDefinitionStart;
	    private DefinitionTextGreen definitionText;
	    private InternalSyntaxToken tColon;
	    private InlineTextGreen inlineText;
	
	    public DefinitionItemGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tDefinitionStart, DefinitionTextGreen definitionText, InternalSyntaxToken tColon, InlineTextGreen inlineText)
	        : base(kind, null, null)
	    {
			if (tDefinitionStart != null)
			{
				this.AdjustFlagsAndWidth(tDefinitionStart);
				this.tDefinitionStart = tDefinitionStart;
			}
			if (definitionText != null)
			{
				this.AdjustFlagsAndWidth(definitionText);
				this.definitionText = definitionText;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
	    public DefinitionItemGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tDefinitionStart, DefinitionTextGreen definitionText, InternalSyntaxToken tColon, InlineTextGreen inlineText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tDefinitionStart != null)
			{
				this.AdjustFlagsAndWidth(tDefinitionStart);
				this.tDefinitionStart = tDefinitionStart;
			}
			if (definitionText != null)
			{
				this.AdjustFlagsAndWidth(definitionText);
				this.definitionText = definitionText;
			}
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TDefinitionStart { get { return this.tDefinitionStart; } }
	    public DefinitionTextGreen DefinitionText { get { return this.definitionText; } }
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public InlineTextGreen InlineText { get { return this.inlineText; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.DefinitionItemSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tDefinitionStart;
	            case 1: return this.definitionText;
	            case 2: return this.tColon;
	            case 3: return this.inlineText;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DefinitionItemGreen(this.Kind, this.tDefinitionStart, this.definitionText, this.tColon, this.inlineText, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DefinitionItemGreen(this.Kind, this.tDefinitionStart, this.definitionText, this.tColon, this.inlineText, this.GetDiagnostics(), annotations);
	    }
	
	    public DefinitionItemGreen Update(InternalSyntaxToken tDefinitionStart, DefinitionTextGreen definitionText, InternalSyntaxToken tColon, InlineTextGreen inlineText)
	    {
	        if (this.tDefinitionStart != tDefinitionStart ||
				this.definitionText != definitionText ||
				this.tColon != tColon ||
				this.inlineText != inlineText)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionItem(tDefinitionStart, definitionText, tColon, inlineText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionItemGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WikiTableGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTableStart;
	    private InlineTextGreen leadingInlineText;
	    private InternalSyntaxToken crlf;
	    private TableCaptionGreen tableCaption;
	    private TableRowsGreen tableRows;
	    private InternalSyntaxToken tTableEnd;
	    private InlineTextGreen trailingInlineText;
	
	    public WikiTableGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTableStart, InlineTextGreen leadingInlineText, InternalSyntaxToken crlf, TableCaptionGreen tableCaption, TableRowsGreen tableRows, InternalSyntaxToken tTableEnd, InlineTextGreen trailingInlineText)
	        : base(kind, null, null)
	    {
			if (tTableStart != null)
			{
				this.AdjustFlagsAndWidth(tTableStart);
				this.tTableStart = tTableStart;
			}
			if (leadingInlineText != null)
			{
				this.AdjustFlagsAndWidth(leadingInlineText);
				this.leadingInlineText = leadingInlineText;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (tableCaption != null)
			{
				this.AdjustFlagsAndWidth(tableCaption);
				this.tableCaption = tableCaption;
			}
			if (tableRows != null)
			{
				this.AdjustFlagsAndWidth(tableRows);
				this.tableRows = tableRows;
			}
			if (tTableEnd != null)
			{
				this.AdjustFlagsAndWidth(tTableEnd);
				this.tTableEnd = tTableEnd;
			}
			if (trailingInlineText != null)
			{
				this.AdjustFlagsAndWidth(trailingInlineText);
				this.trailingInlineText = trailingInlineText;
			}
	    }
	
	    public WikiTableGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTableStart, InlineTextGreen leadingInlineText, InternalSyntaxToken crlf, TableCaptionGreen tableCaption, TableRowsGreen tableRows, InternalSyntaxToken tTableEnd, InlineTextGreen trailingInlineText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTableStart != null)
			{
				this.AdjustFlagsAndWidth(tTableStart);
				this.tTableStart = tTableStart;
			}
			if (leadingInlineText != null)
			{
				this.AdjustFlagsAndWidth(leadingInlineText);
				this.leadingInlineText = leadingInlineText;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (tableCaption != null)
			{
				this.AdjustFlagsAndWidth(tableCaption);
				this.tableCaption = tableCaption;
			}
			if (tableRows != null)
			{
				this.AdjustFlagsAndWidth(tableRows);
				this.tableRows = tableRows;
			}
			if (tTableEnd != null)
			{
				this.AdjustFlagsAndWidth(tTableEnd);
				this.tTableEnd = tTableEnd;
			}
			if (trailingInlineText != null)
			{
				this.AdjustFlagsAndWidth(trailingInlineText);
				this.trailingInlineText = trailingInlineText;
			}
	    }
	
		public override int SlotCount { get { return 7; } }
	
	    public InternalSyntaxToken TTableStart { get { return this.tTableStart; } }
	    public InlineTextGreen LeadingInlineText { get { return this.leadingInlineText; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	    public TableCaptionGreen TableCaption { get { return this.tableCaption; } }
	    public TableRowsGreen TableRows { get { return this.tableRows; } }
	    public InternalSyntaxToken TTableEnd { get { return this.tTableEnd; } }
	    public InlineTextGreen TrailingInlineText { get { return this.trailingInlineText; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WikiTableSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTableStart;
	            case 1: return this.leadingInlineText;
	            case 2: return this.crlf;
	            case 3: return this.tableCaption;
	            case 4: return this.tableRows;
	            case 5: return this.tTableEnd;
	            case 6: return this.trailingInlineText;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WikiTableGreen(this.Kind, this.tTableStart, this.leadingInlineText, this.crlf, this.tableCaption, this.tableRows, this.tTableEnd, this.trailingInlineText, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WikiTableGreen(this.Kind, this.tTableStart, this.leadingInlineText, this.crlf, this.tableCaption, this.tableRows, this.tTableEnd, this.trailingInlineText, this.GetDiagnostics(), annotations);
	    }
	
	    public WikiTableGreen Update(InternalSyntaxToken tTableStart, InlineTextGreen leadingInlineText, InternalSyntaxToken crlf, TableCaptionGreen tableCaption, TableRowsGreen tableRows, InternalSyntaxToken tTableEnd, InlineTextGreen trailingInlineText)
	    {
	        if (this.tTableStart != tTableStart ||
				this.leadingInlineText != leadingInlineText ||
				this.crlf != crlf ||
				this.tableCaption != tableCaption ||
				this.tableRows != tableRows ||
				this.tTableEnd != tTableEnd ||
				this.trailingInlineText != trailingInlineText)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiTable(tTableStart, leadingInlineText, crlf, tableCaption, tableRows, tTableEnd, trailingInlineText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiTableGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableCaptionGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTableCaptionStart;
	    private InlineTextGreen inlineText;
	    private InternalSyntaxToken crlf;
	    private InternalSyntaxNodeList specialBlockOrParagraph;
	
	    public TableCaptionGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTableCaptionStart, InlineTextGreen inlineText, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	        : base(kind, null, null)
	    {
			if (tTableCaptionStart != null)
			{
				this.AdjustFlagsAndWidth(tTableCaptionStart);
				this.tTableCaptionStart = tTableCaptionStart;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
	    public TableCaptionGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTableCaptionStart, InlineTextGreen inlineText, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTableCaptionStart != null)
			{
				this.AdjustFlagsAndWidth(tTableCaptionStart);
				this.tTableCaptionStart = tTableCaptionStart;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TTableCaptionStart { get { return this.tTableCaptionStart; } }
	    public InlineTextGreen InlineText { get { return this.inlineText; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	    public InternalSyntaxNodeList SpecialBlockOrParagraph { get { return this.specialBlockOrParagraph; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableCaptionSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTableCaptionStart;
	            case 1: return this.inlineText;
	            case 2: return this.crlf;
	            case 3: return this.specialBlockOrParagraph;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableCaptionGreen(this.Kind, this.tTableCaptionStart, this.inlineText, this.crlf, this.specialBlockOrParagraph, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableCaptionGreen(this.Kind, this.tTableCaptionStart, this.inlineText, this.crlf, this.specialBlockOrParagraph, this.GetDiagnostics(), annotations);
	    }
	
	    public TableCaptionGreen Update(InternalSyntaxToken tTableCaptionStart, InlineTextGreen inlineText, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	    {
	        if (this.tTableCaptionStart != tTableCaptionStart ||
				this.inlineText != inlineText ||
				this.crlf != crlf ||
				this.specialBlockOrParagraph != specialBlockOrParagraph)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableCaption(tTableCaptionStart, inlineText, crlf, specialBlockOrParagraph);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableCaptionGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableRowsGreen : MediaWikiGreenNode
	{
	    private TableFirstRowGreen tableFirstRow;
	    private InternalSyntaxNodeList tableNonFirstRow;
	
	    public TableRowsGreen(MediaWikiSyntaxKind kind, TableFirstRowGreen tableFirstRow, InternalSyntaxNodeList tableNonFirstRow)
	        : base(kind, null, null)
	    {
			if (tableFirstRow != null)
			{
				this.AdjustFlagsAndWidth(tableFirstRow);
				this.tableFirstRow = tableFirstRow;
			}
			if (tableNonFirstRow != null)
			{
				this.AdjustFlagsAndWidth(tableNonFirstRow);
				this.tableNonFirstRow = tableNonFirstRow;
			}
	    }
	
	    public TableRowsGreen(MediaWikiSyntaxKind kind, TableFirstRowGreen tableFirstRow, InternalSyntaxNodeList tableNonFirstRow, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tableFirstRow != null)
			{
				this.AdjustFlagsAndWidth(tableFirstRow);
				this.tableFirstRow = tableFirstRow;
			}
			if (tableNonFirstRow != null)
			{
				this.AdjustFlagsAndWidth(tableNonFirstRow);
				this.tableNonFirstRow = tableNonFirstRow;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TableFirstRowGreen TableFirstRow { get { return this.tableFirstRow; } }
	    public InternalSyntaxNodeList TableNonFirstRow { get { return this.tableNonFirstRow; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableRowsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tableFirstRow;
	            case 1: return this.tableNonFirstRow;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableRowsGreen(this.Kind, this.tableFirstRow, this.tableNonFirstRow, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableRowsGreen(this.Kind, this.tableFirstRow, this.tableNonFirstRow, this.GetDiagnostics(), annotations);
	    }
	
	    public TableRowsGreen Update(TableFirstRowGreen tableFirstRow, InternalSyntaxNodeList tableNonFirstRow)
	    {
	        if (this.tableFirstRow != tableFirstRow ||
				this.tableNonFirstRow != tableNonFirstRow)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableRows(tableFirstRow, tableNonFirstRow);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableRowsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableFirstRowGreen : MediaWikiGreenNode
	{
	    private TableRowStartGreen tableRowStart;
	    private TableRowGreen tableRow;
	
	    public TableFirstRowGreen(MediaWikiSyntaxKind kind, TableRowStartGreen tableRowStart, TableRowGreen tableRow)
	        : base(kind, null, null)
	    {
			if (tableRowStart != null)
			{
				this.AdjustFlagsAndWidth(tableRowStart);
				this.tableRowStart = tableRowStart;
			}
			if (tableRow != null)
			{
				this.AdjustFlagsAndWidth(tableRow);
				this.tableRow = tableRow;
			}
	    }
	
	    public TableFirstRowGreen(MediaWikiSyntaxKind kind, TableRowStartGreen tableRowStart, TableRowGreen tableRow, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tableRowStart != null)
			{
				this.AdjustFlagsAndWidth(tableRowStart);
				this.tableRowStart = tableRowStart;
			}
			if (tableRow != null)
			{
				this.AdjustFlagsAndWidth(tableRow);
				this.tableRow = tableRow;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TableRowStartGreen TableRowStart { get { return this.tableRowStart; } }
	    public TableRowGreen TableRow { get { return this.tableRow; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableFirstRowSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tableRowStart;
	            case 1: return this.tableRow;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableFirstRowGreen(this.Kind, this.tableRowStart, this.tableRow, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableFirstRowGreen(this.Kind, this.tableRowStart, this.tableRow, this.GetDiagnostics(), annotations);
	    }
	
	    public TableFirstRowGreen Update(TableRowStartGreen tableRowStart, TableRowGreen tableRow)
	    {
	        if (this.tableRowStart != tableRowStart ||
				this.tableRow != tableRow)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableFirstRow(tableRowStart, tableRow);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableFirstRowGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableNonFirstRowGreen : MediaWikiGreenNode
	{
	    private TableRowStartGreen tableRowStart;
	    private TableRowGreen tableRow;
	
	    public TableNonFirstRowGreen(MediaWikiSyntaxKind kind, TableRowStartGreen tableRowStart, TableRowGreen tableRow)
	        : base(kind, null, null)
	    {
			if (tableRowStart != null)
			{
				this.AdjustFlagsAndWidth(tableRowStart);
				this.tableRowStart = tableRowStart;
			}
			if (tableRow != null)
			{
				this.AdjustFlagsAndWidth(tableRow);
				this.tableRow = tableRow;
			}
	    }
	
	    public TableNonFirstRowGreen(MediaWikiSyntaxKind kind, TableRowStartGreen tableRowStart, TableRowGreen tableRow, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tableRowStart != null)
			{
				this.AdjustFlagsAndWidth(tableRowStart);
				this.tableRowStart = tableRowStart;
			}
			if (tableRow != null)
			{
				this.AdjustFlagsAndWidth(tableRow);
				this.tableRow = tableRow;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TableRowStartGreen TableRowStart { get { return this.tableRowStart; } }
	    public TableRowGreen TableRow { get { return this.tableRow; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableNonFirstRowSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tableRowStart;
	            case 1: return this.tableRow;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableNonFirstRowGreen(this.Kind, this.tableRowStart, this.tableRow, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableNonFirstRowGreen(this.Kind, this.tableRowStart, this.tableRow, this.GetDiagnostics(), annotations);
	    }
	
	    public TableNonFirstRowGreen Update(TableRowStartGreen tableRowStart, TableRowGreen tableRow)
	    {
	        if (this.tableRowStart != tableRowStart ||
				this.tableRow != tableRow)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableNonFirstRow(tableRowStart, tableRow);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableNonFirstRowGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableRowStartGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTableRowStart;
	    private InlineTextGreen inlineText;
	    private InternalSyntaxToken crlf;
	
	    public TableRowStartGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTableRowStart, InlineTextGreen inlineText, InternalSyntaxToken crlf)
	        : base(kind, null, null)
	    {
			if (tTableRowStart != null)
			{
				this.AdjustFlagsAndWidth(tTableRowStart);
				this.tTableRowStart = tTableRowStart;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
	    }
	
	    public TableRowStartGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTableRowStart, InlineTextGreen inlineText, InternalSyntaxToken crlf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTableRowStart != null)
			{
				this.AdjustFlagsAndWidth(tTableRowStart);
				this.tTableRowStart = tTableRowStart;
			}
			if (inlineText != null)
			{
				this.AdjustFlagsAndWidth(inlineText);
				this.inlineText = inlineText;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TTableRowStart { get { return this.tTableRowStart; } }
	    public InlineTextGreen InlineText { get { return this.inlineText; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableRowStartSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTableRowStart;
	            case 1: return this.inlineText;
	            case 2: return this.crlf;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableRowStartGreen(this.Kind, this.tTableRowStart, this.inlineText, this.crlf, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableRowStartGreen(this.Kind, this.tTableRowStart, this.inlineText, this.crlf, this.GetDiagnostics(), annotations);
	    }
	
	    public TableRowStartGreen Update(InternalSyntaxToken tTableRowStart, InlineTextGreen inlineText, InternalSyntaxToken crlf)
	    {
	        if (this.tTableRowStart != tTableRowStart ||
				this.inlineText != inlineText ||
				this.crlf != crlf)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableRowStart(tTableRowStart, inlineText, crlf);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableRowStartGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableRowGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList tableColumn;
	
	    public TableRowGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList tableColumn)
	        : base(kind, null, null)
	    {
			if (tableColumn != null)
			{
				this.AdjustFlagsAndWidth(tableColumn);
				this.tableColumn = tableColumn;
			}
	    }
	
	    public TableRowGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList tableColumn, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tableColumn != null)
			{
				this.AdjustFlagsAndWidth(tableColumn);
				this.tableColumn = tableColumn;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList TableColumn { get { return this.tableColumn; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableRowSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tableColumn;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableRowGreen(this.Kind, this.tableColumn, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableRowGreen(this.Kind, this.tableColumn, this.GetDiagnostics(), annotations);
	    }
	
	    public TableRowGreen Update(InternalSyntaxNodeList tableColumn)
	    {
	        if (this.tableColumn != tableColumn)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableRow(tableColumn);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableRowGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableColumnGreen : MediaWikiGreenNode
	{
	    private TableSingleHeaderCellGreen tableSingleHeaderCell;
	    private TableHeaderCellsGreen tableHeaderCells;
	    private TableSingleCellGreen tableSingleCell;
	    private TableCellsGreen tableCells;
	
	    public TableColumnGreen(MediaWikiSyntaxKind kind, TableSingleHeaderCellGreen tableSingleHeaderCell, TableHeaderCellsGreen tableHeaderCells, TableSingleCellGreen tableSingleCell, TableCellsGreen tableCells)
	        : base(kind, null, null)
	    {
			if (tableSingleHeaderCell != null)
			{
				this.AdjustFlagsAndWidth(tableSingleHeaderCell);
				this.tableSingleHeaderCell = tableSingleHeaderCell;
			}
			if (tableHeaderCells != null)
			{
				this.AdjustFlagsAndWidth(tableHeaderCells);
				this.tableHeaderCells = tableHeaderCells;
			}
			if (tableSingleCell != null)
			{
				this.AdjustFlagsAndWidth(tableSingleCell);
				this.tableSingleCell = tableSingleCell;
			}
			if (tableCells != null)
			{
				this.AdjustFlagsAndWidth(tableCells);
				this.tableCells = tableCells;
			}
	    }
	
	    public TableColumnGreen(MediaWikiSyntaxKind kind, TableSingleHeaderCellGreen tableSingleHeaderCell, TableHeaderCellsGreen tableHeaderCells, TableSingleCellGreen tableSingleCell, TableCellsGreen tableCells, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tableSingleHeaderCell != null)
			{
				this.AdjustFlagsAndWidth(tableSingleHeaderCell);
				this.tableSingleHeaderCell = tableSingleHeaderCell;
			}
			if (tableHeaderCells != null)
			{
				this.AdjustFlagsAndWidth(tableHeaderCells);
				this.tableHeaderCells = tableHeaderCells;
			}
			if (tableSingleCell != null)
			{
				this.AdjustFlagsAndWidth(tableSingleCell);
				this.tableSingleCell = tableSingleCell;
			}
			if (tableCells != null)
			{
				this.AdjustFlagsAndWidth(tableCells);
				this.tableCells = tableCells;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public TableSingleHeaderCellGreen TableSingleHeaderCell { get { return this.tableSingleHeaderCell; } }
	    public TableHeaderCellsGreen TableHeaderCells { get { return this.tableHeaderCells; } }
	    public TableSingleCellGreen TableSingleCell { get { return this.tableSingleCell; } }
	    public TableCellsGreen TableCells { get { return this.tableCells; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableColumnSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableColumnGreen(this.Kind, this.tableSingleHeaderCell, this.tableHeaderCells, this.tableSingleCell, this.tableCells, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableColumnGreen(this.Kind, this.tableSingleHeaderCell, this.tableHeaderCells, this.tableSingleCell, this.tableCells, this.GetDiagnostics(), annotations);
	    }
	
	    public TableColumnGreen Update(TableSingleHeaderCellGreen tableSingleHeaderCell)
	    {
	        if (this.tableSingleHeaderCell != tableSingleHeaderCell)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableColumn(tableSingleHeaderCell);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableColumnGreen)newNode;
	        }
	        return this;
	    }
	
	    public TableColumnGreen Update(TableHeaderCellsGreen tableHeaderCells)
	    {
	        if (this.tableHeaderCells != tableHeaderCells)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableColumn(tableHeaderCells);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableColumnGreen)newNode;
	        }
	        return this;
	    }
	
	    public TableColumnGreen Update(TableSingleCellGreen tableSingleCell)
	    {
	        if (this.tableSingleCell != tableSingleCell)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableColumn(tableSingleCell);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableColumnGreen)newNode;
	        }
	        return this;
	    }
	
	    public TableColumnGreen Update(TableCellsGreen tableCells)
	    {
	        if (this.tableCells != tableCells)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableColumn(tableCells);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableColumnGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableSingleHeaderCellGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tExclamation;
	    private TableCellGreen tableCell;
	    private InternalSyntaxToken crlf;
	    private InternalSyntaxNodeList specialBlockOrParagraph;
	
	    public TableSingleHeaderCellGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tExclamation, TableCellGreen tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	        : base(kind, null, null)
	    {
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
			if (tableCell != null)
			{
				this.AdjustFlagsAndWidth(tableCell);
				this.tableCell = tableCell;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
	    public TableSingleHeaderCellGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tExclamation, TableCellGreen tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
			if (tableCell != null)
			{
				this.AdjustFlagsAndWidth(tableCell);
				this.tableCell = tableCell;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TExclamation { get { return this.tExclamation; } }
	    public TableCellGreen TableCell { get { return this.tableCell; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	    public InternalSyntaxNodeList SpecialBlockOrParagraph { get { return this.specialBlockOrParagraph; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableSingleHeaderCellSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tExclamation;
	            case 1: return this.tableCell;
	            case 2: return this.crlf;
	            case 3: return this.specialBlockOrParagraph;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableSingleHeaderCellGreen(this.Kind, this.tExclamation, this.tableCell, this.crlf, this.specialBlockOrParagraph, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableSingleHeaderCellGreen(this.Kind, this.tExclamation, this.tableCell, this.crlf, this.specialBlockOrParagraph, this.GetDiagnostics(), annotations);
	    }
	
	    public TableSingleHeaderCellGreen Update(InternalSyntaxToken tExclamation, TableCellGreen tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	    {
	        if (this.tExclamation != tExclamation ||
				this.tableCell != tableCell ||
				this.crlf != crlf ||
				this.specialBlockOrParagraph != specialBlockOrParagraph)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableSingleHeaderCell(tExclamation, tableCell, crlf, specialBlockOrParagraph);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableSingleHeaderCellGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableHeaderCellsGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tExclamation;
	    private InternalSeparatedSyntaxNodeList tableCell;
	    private InternalSyntaxToken crlf;
	    private InternalSyntaxNodeList specialBlockOrParagraph;
	
	    public TableHeaderCellsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tExclamation, InternalSeparatedSyntaxNodeList tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	        : base(kind, null, null)
	    {
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
			if (tableCell != null)
			{
				this.AdjustFlagsAndWidth(tableCell);
				this.tableCell = tableCell;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
	    public TableHeaderCellsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tExclamation, InternalSeparatedSyntaxNodeList tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tExclamation != null)
			{
				this.AdjustFlagsAndWidth(tExclamation);
				this.tExclamation = tExclamation;
			}
			if (tableCell != null)
			{
				this.AdjustFlagsAndWidth(tableCell);
				this.tableCell = tableCell;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TExclamation { get { return this.tExclamation; } }
	    public InternalSeparatedSyntaxNodeList TableCell { get { return this.tableCell; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	    public InternalSyntaxNodeList SpecialBlockOrParagraph { get { return this.specialBlockOrParagraph; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableHeaderCellsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tExclamation;
	            case 1: return this.tableCell;
	            case 2: return this.crlf;
	            case 3: return this.specialBlockOrParagraph;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableHeaderCellsGreen(this.Kind, this.tExclamation, this.tableCell, this.crlf, this.specialBlockOrParagraph, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableHeaderCellsGreen(this.Kind, this.tExclamation, this.tableCell, this.crlf, this.specialBlockOrParagraph, this.GetDiagnostics(), annotations);
	    }
	
	    public TableHeaderCellsGreen Update(InternalSyntaxToken tExclamation, InternalSeparatedSyntaxNodeList tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	    {
	        if (this.tExclamation != tExclamation ||
				this.tableCell != tableCell ||
				this.crlf != crlf ||
				this.specialBlockOrParagraph != specialBlockOrParagraph)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableHeaderCells(tExclamation, tableCell, crlf, specialBlockOrParagraph);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableHeaderCellsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableSingleCellGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tBar;
	    private TableCellGreen tableCell;
	    private InternalSyntaxToken crlf;
	    private InternalSyntaxNodeList specialBlockOrParagraph;
	
	    public TableSingleCellGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tBar, TableCellGreen tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	        : base(kind, null, null)
	    {
			if (tBar != null)
			{
				this.AdjustFlagsAndWidth(tBar);
				this.tBar = tBar;
			}
			if (tableCell != null)
			{
				this.AdjustFlagsAndWidth(tableCell);
				this.tableCell = tableCell;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
	    public TableSingleCellGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tBar, TableCellGreen tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tBar != null)
			{
				this.AdjustFlagsAndWidth(tBar);
				this.tBar = tBar;
			}
			if (tableCell != null)
			{
				this.AdjustFlagsAndWidth(tableCell);
				this.tableCell = tableCell;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TBar { get { return this.tBar; } }
	    public TableCellGreen TableCell { get { return this.tableCell; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	    public InternalSyntaxNodeList SpecialBlockOrParagraph { get { return this.specialBlockOrParagraph; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableSingleCellSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tBar;
	            case 1: return this.tableCell;
	            case 2: return this.crlf;
	            case 3: return this.specialBlockOrParagraph;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableSingleCellGreen(this.Kind, this.tBar, this.tableCell, this.crlf, this.specialBlockOrParagraph, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableSingleCellGreen(this.Kind, this.tBar, this.tableCell, this.crlf, this.specialBlockOrParagraph, this.GetDiagnostics(), annotations);
	    }
	
	    public TableSingleCellGreen Update(InternalSyntaxToken tBar, TableCellGreen tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	    {
	        if (this.tBar != tBar ||
				this.tableCell != tableCell ||
				this.crlf != crlf ||
				this.specialBlockOrParagraph != specialBlockOrParagraph)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableSingleCell(tBar, tableCell, crlf, specialBlockOrParagraph);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableSingleCellGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableCellsGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tBar;
	    private InternalSeparatedSyntaxNodeList tableCell;
	    private InternalSyntaxToken crlf;
	    private InternalSyntaxNodeList specialBlockOrParagraph;
	
	    public TableCellsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tBar, InternalSeparatedSyntaxNodeList tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	        : base(kind, null, null)
	    {
			if (tBar != null)
			{
				this.AdjustFlagsAndWidth(tBar);
				this.tBar = tBar;
			}
			if (tableCell != null)
			{
				this.AdjustFlagsAndWidth(tableCell);
				this.tableCell = tableCell;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
	    public TableCellsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tBar, InternalSeparatedSyntaxNodeList tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tBar != null)
			{
				this.AdjustFlagsAndWidth(tBar);
				this.tBar = tBar;
			}
			if (tableCell != null)
			{
				this.AdjustFlagsAndWidth(tableCell);
				this.tableCell = tableCell;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
			if (specialBlockOrParagraph != null)
			{
				this.AdjustFlagsAndWidth(specialBlockOrParagraph);
				this.specialBlockOrParagraph = specialBlockOrParagraph;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TBar { get { return this.tBar; } }
	    public InternalSeparatedSyntaxNodeList TableCell { get { return this.tableCell; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	    public InternalSyntaxNodeList SpecialBlockOrParagraph { get { return this.specialBlockOrParagraph; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableCellsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tBar;
	            case 1: return this.tableCell;
	            case 2: return this.crlf;
	            case 3: return this.specialBlockOrParagraph;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableCellsGreen(this.Kind, this.tBar, this.tableCell, this.crlf, this.specialBlockOrParagraph, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableCellsGreen(this.Kind, this.tBar, this.tableCell, this.crlf, this.specialBlockOrParagraph, this.GetDiagnostics(), annotations);
	    }
	
	    public TableCellsGreen Update(InternalSyntaxToken tBar, InternalSeparatedSyntaxNodeList tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph)
	    {
	        if (this.tBar != tBar ||
				this.tableCell != tableCell ||
				this.crlf != crlf ||
				this.specialBlockOrParagraph != specialBlockOrParagraph)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableCells(tBar, tableCell, crlf, specialBlockOrParagraph);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableCellsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TableCellGreen : MediaWikiGreenNode
	{
	    private CellAttributesGreen cellAttributes;
	    private CellTextGreen cellText;
	
	    public TableCellGreen(MediaWikiSyntaxKind kind, CellAttributesGreen cellAttributes, CellTextGreen cellText)
	        : base(kind, null, null)
	    {
			if (cellAttributes != null)
			{
				this.AdjustFlagsAndWidth(cellAttributes);
				this.cellAttributes = cellAttributes;
			}
			if (cellText != null)
			{
				this.AdjustFlagsAndWidth(cellText);
				this.cellText = cellText;
			}
	    }
	
	    public TableCellGreen(MediaWikiSyntaxKind kind, CellAttributesGreen cellAttributes, CellTextGreen cellText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (cellAttributes != null)
			{
				this.AdjustFlagsAndWidth(cellAttributes);
				this.cellAttributes = cellAttributes;
			}
			if (cellText != null)
			{
				this.AdjustFlagsAndWidth(cellText);
				this.cellText = cellText;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public CellAttributesGreen CellAttributes { get { return this.cellAttributes; } }
	    public CellTextGreen CellText { get { return this.cellText; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TableCellSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.cellAttributes;
	            case 1: return this.cellText;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TableCellGreen(this.Kind, this.cellAttributes, this.cellText, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TableCellGreen(this.Kind, this.cellAttributes, this.cellText, this.GetDiagnostics(), annotations);
	    }
	
	    public TableCellGreen Update(CellAttributesGreen cellAttributes, CellTextGreen cellText)
	    {
	        if (this.cellAttributes != cellAttributes ||
				this.cellText != cellText)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TableCell(cellAttributes, cellText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TableCellGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CellAttributesGreen : MediaWikiGreenNode
	{
	    private CellTextGreen cellText;
	    private InternalSyntaxToken tBar;
	
	    public CellAttributesGreen(MediaWikiSyntaxKind kind, CellTextGreen cellText, InternalSyntaxToken tBar)
	        : base(kind, null, null)
	    {
			if (cellText != null)
			{
				this.AdjustFlagsAndWidth(cellText);
				this.cellText = cellText;
			}
			if (tBar != null)
			{
				this.AdjustFlagsAndWidth(tBar);
				this.tBar = tBar;
			}
	    }
	
	    public CellAttributesGreen(MediaWikiSyntaxKind kind, CellTextGreen cellText, InternalSyntaxToken tBar, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (cellText != null)
			{
				this.AdjustFlagsAndWidth(cellText);
				this.cellText = cellText;
			}
			if (tBar != null)
			{
				this.AdjustFlagsAndWidth(tBar);
				this.tBar = tBar;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public CellTextGreen CellText { get { return this.cellText; } }
	    public InternalSyntaxToken TBar { get { return this.tBar; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.CellAttributesSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.cellText;
	            case 1: return this.tBar;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CellAttributesGreen(this.Kind, this.cellText, this.tBar, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CellAttributesGreen(this.Kind, this.cellText, this.tBar, this.GetDiagnostics(), annotations);
	    }
	
	    public CellAttributesGreen Update(CellTextGreen cellText, InternalSyntaxToken tBar)
	    {
	        if (this.cellText != cellText ||
				this.tBar != tBar)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.CellAttributes(cellText, tBar);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellAttributesGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ParagraphGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList textLine;
	
	    public ParagraphGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList textLine)
	        : base(kind, null, null)
	    {
			if (textLine != null)
			{
				this.AdjustFlagsAndWidth(textLine);
				this.textLine = textLine;
			}
	    }
	
	    public ParagraphGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList textLine, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (textLine != null)
			{
				this.AdjustFlagsAndWidth(textLine);
				this.textLine = textLine;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList TextLine { get { return this.textLine; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.ParagraphSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.textLine;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ParagraphGreen(this.Kind, this.textLine, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ParagraphGreen(this.Kind, this.textLine, this.GetDiagnostics(), annotations);
	    }
	
	    public ParagraphGreen Update(InternalSyntaxNodeList textLine)
	    {
	        if (this.textLine != textLine)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.Paragraph(textLine);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParagraphGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class TextLineGreen : MediaWikiGreenNode
	{
	
	    public TextLineGreen(MediaWikiSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class TextLineInlineElementsWithCommentGreen : TextLineGreen
	{
	    private HtmlCommentListGreen leadingComment;
	    private InternalSyntaxNodeList inlineTextElement;
	    private HtmlCommentListGreen trailingComment;
	    private InternalSyntaxToken crlf;
	
	    public TextLineInlineElementsWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, InternalSyntaxNodeList inlineTextElement, HtmlCommentListGreen trailingComment, InternalSyntaxToken crlf)
	        : base(kind, null, null)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (inlineTextElement != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElement);
				this.inlineTextElement = inlineTextElement;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
	    }
	
	    public TextLineInlineElementsWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, InternalSyntaxNodeList inlineTextElement, HtmlCommentListGreen trailingComment, InternalSyntaxToken crlf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (inlineTextElement != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElement);
				this.inlineTextElement = inlineTextElement;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public HtmlCommentListGreen LeadingComment { get { return this.leadingComment; } }
	    public InternalSyntaxNodeList InlineTextElement { get { return this.inlineTextElement; } }
	    public HtmlCommentListGreen TrailingComment { get { return this.trailingComment; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TextLineInlineElementsWithCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingComment;
	            case 1: return this.inlineTextElement;
	            case 2: return this.trailingComment;
	            case 3: return this.crlf;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TextLineInlineElementsWithCommentGreen(this.Kind, this.leadingComment, this.inlineTextElement, this.trailingComment, this.crlf, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TextLineInlineElementsWithCommentGreen(this.Kind, this.leadingComment, this.inlineTextElement, this.trailingComment, this.crlf, this.GetDiagnostics(), annotations);
	    }
	
	    public TextLineInlineElementsWithCommentGreen Update(HtmlCommentListGreen leadingComment, InternalSyntaxNodeList inlineTextElement, HtmlCommentListGreen trailingComment, InternalSyntaxToken crlf)
	    {
	        if (this.leadingComment != leadingComment ||
				this.inlineTextElement != inlineTextElement ||
				this.trailingComment != trailingComment ||
				this.crlf != crlf)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextLineInlineElementsWithComment(leadingComment, inlineTextElement, trailingComment, crlf);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextLineInlineElementsWithCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TextLineCommentGreen : TextLineGreen
	{
	    private HtmlCommentListGreen htmlCommentList;
	    private InternalSyntaxToken crlf;
	
	    public TextLineCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen htmlCommentList, InternalSyntaxToken crlf)
	        : base(kind, null, null)
	    {
			if (htmlCommentList != null)
			{
				this.AdjustFlagsAndWidth(htmlCommentList);
				this.htmlCommentList = htmlCommentList;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
	    }
	
	    public TextLineCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen htmlCommentList, InternalSyntaxToken crlf, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (htmlCommentList != null)
			{
				this.AdjustFlagsAndWidth(htmlCommentList);
				this.htmlCommentList = htmlCommentList;
			}
			if (crlf != null)
			{
				this.AdjustFlagsAndWidth(crlf);
				this.crlf = crlf;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public HtmlCommentListGreen HtmlCommentList { get { return this.htmlCommentList; } }
	    public InternalSyntaxToken CRLF { get { return this.crlf; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TextLineCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.htmlCommentList;
	            case 1: return this.crlf;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TextLineCommentGreen(this.Kind, this.htmlCommentList, this.crlf, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TextLineCommentGreen(this.Kind, this.htmlCommentList, this.crlf, this.GetDiagnostics(), annotations);
	    }
	
	    public TextLineCommentGreen Update(HtmlCommentListGreen htmlCommentList, InternalSyntaxToken crlf)
	    {
	        if (this.htmlCommentList != htmlCommentList ||
				this.crlf != crlf)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextLineComment(htmlCommentList, crlf);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextLineCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TextElementsGreen : MediaWikiGreenNode
	{
	    private WikiFormatGreen wikiFormat;
	    private WikiLinkGreen wikiLink;
	    private WikiTemplateGreen wikiTemplate;
	    private WikiTemplateParamGreen wikiTemplateParam;
	    private NoWikiGreen noWiki;
	    private HtmlReferenceGreen htmlReference;
	    private HtmlStyleGreen htmlStyle;
	    private HtmlScriptGreen htmlScript;
	    private HtmlTagGreen htmlTag;
	
	    public TextElementsGreen(MediaWikiSyntaxKind kind, WikiFormatGreen wikiFormat, WikiLinkGreen wikiLink, WikiTemplateGreen wikiTemplate, WikiTemplateParamGreen wikiTemplateParam, NoWikiGreen noWiki, HtmlReferenceGreen htmlReference, HtmlStyleGreen htmlStyle, HtmlScriptGreen htmlScript, HtmlTagGreen htmlTag)
	        : base(kind, null, null)
	    {
			if (wikiFormat != null)
			{
				this.AdjustFlagsAndWidth(wikiFormat);
				this.wikiFormat = wikiFormat;
			}
			if (wikiLink != null)
			{
				this.AdjustFlagsAndWidth(wikiLink);
				this.wikiLink = wikiLink;
			}
			if (wikiTemplate != null)
			{
				this.AdjustFlagsAndWidth(wikiTemplate);
				this.wikiTemplate = wikiTemplate;
			}
			if (wikiTemplateParam != null)
			{
				this.AdjustFlagsAndWidth(wikiTemplateParam);
				this.wikiTemplateParam = wikiTemplateParam;
			}
			if (noWiki != null)
			{
				this.AdjustFlagsAndWidth(noWiki);
				this.noWiki = noWiki;
			}
			if (htmlReference != null)
			{
				this.AdjustFlagsAndWidth(htmlReference);
				this.htmlReference = htmlReference;
			}
			if (htmlStyle != null)
			{
				this.AdjustFlagsAndWidth(htmlStyle);
				this.htmlStyle = htmlStyle;
			}
			if (htmlScript != null)
			{
				this.AdjustFlagsAndWidth(htmlScript);
				this.htmlScript = htmlScript;
			}
			if (htmlTag != null)
			{
				this.AdjustFlagsAndWidth(htmlTag);
				this.htmlTag = htmlTag;
			}
	    }
	
	    public TextElementsGreen(MediaWikiSyntaxKind kind, WikiFormatGreen wikiFormat, WikiLinkGreen wikiLink, WikiTemplateGreen wikiTemplate, WikiTemplateParamGreen wikiTemplateParam, NoWikiGreen noWiki, HtmlReferenceGreen htmlReference, HtmlStyleGreen htmlStyle, HtmlScriptGreen htmlScript, HtmlTagGreen htmlTag, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (wikiFormat != null)
			{
				this.AdjustFlagsAndWidth(wikiFormat);
				this.wikiFormat = wikiFormat;
			}
			if (wikiLink != null)
			{
				this.AdjustFlagsAndWidth(wikiLink);
				this.wikiLink = wikiLink;
			}
			if (wikiTemplate != null)
			{
				this.AdjustFlagsAndWidth(wikiTemplate);
				this.wikiTemplate = wikiTemplate;
			}
			if (wikiTemplateParam != null)
			{
				this.AdjustFlagsAndWidth(wikiTemplateParam);
				this.wikiTemplateParam = wikiTemplateParam;
			}
			if (noWiki != null)
			{
				this.AdjustFlagsAndWidth(noWiki);
				this.noWiki = noWiki;
			}
			if (htmlReference != null)
			{
				this.AdjustFlagsAndWidth(htmlReference);
				this.htmlReference = htmlReference;
			}
			if (htmlStyle != null)
			{
				this.AdjustFlagsAndWidth(htmlStyle);
				this.htmlStyle = htmlStyle;
			}
			if (htmlScript != null)
			{
				this.AdjustFlagsAndWidth(htmlScript);
				this.htmlScript = htmlScript;
			}
			if (htmlTag != null)
			{
				this.AdjustFlagsAndWidth(htmlTag);
				this.htmlTag = htmlTag;
			}
	    }
	
		public override int SlotCount { get { return 9; } }
	
	    public WikiFormatGreen WikiFormat { get { return this.wikiFormat; } }
	    public WikiLinkGreen WikiLink { get { return this.wikiLink; } }
	    public WikiTemplateGreen WikiTemplate { get { return this.wikiTemplate; } }
	    public WikiTemplateParamGreen WikiTemplateParam { get { return this.wikiTemplateParam; } }
	    public NoWikiGreen NoWiki { get { return this.noWiki; } }
	    public HtmlReferenceGreen HtmlReference { get { return this.htmlReference; } }
	    public HtmlStyleGreen HtmlStyle { get { return this.htmlStyle; } }
	    public HtmlScriptGreen HtmlScript { get { return this.htmlScript; } }
	    public HtmlTagGreen HtmlTag { get { return this.htmlTag; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.TextElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
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
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TextElementsGreen(this.Kind, this.wikiFormat, this.wikiLink, this.wikiTemplate, this.wikiTemplateParam, this.noWiki, this.htmlReference, this.htmlStyle, this.htmlScript, this.htmlTag, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TextElementsGreen(this.Kind, this.wikiFormat, this.wikiLink, this.wikiTemplate, this.wikiTemplateParam, this.noWiki, this.htmlReference, this.htmlStyle, this.htmlScript, this.htmlTag, this.GetDiagnostics(), annotations);
	    }
	
	    public TextElementsGreen Update(WikiFormatGreen wikiFormat)
	    {
	        if (this.wikiFormat != wikiFormat)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(wikiFormat);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsGreen Update(WikiLinkGreen wikiLink)
	    {
	        if (this.wikiLink != wikiLink)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(wikiLink);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsGreen Update(WikiTemplateGreen wikiTemplate)
	    {
	        if (this.wikiTemplate != wikiTemplate)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(wikiTemplate);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsGreen Update(WikiTemplateParamGreen wikiTemplateParam)
	    {
	        if (this.wikiTemplateParam != wikiTemplateParam)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(wikiTemplateParam);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsGreen Update(NoWikiGreen noWiki)
	    {
	        if (this.noWiki != noWiki)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(noWiki);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsGreen Update(HtmlReferenceGreen htmlReference)
	    {
	        if (this.htmlReference != htmlReference)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(htmlReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsGreen Update(HtmlStyleGreen htmlStyle)
	    {
	        if (this.htmlStyle != htmlStyle)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(htmlStyle);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsGreen Update(HtmlScriptGreen htmlScript)
	    {
	        if (this.htmlScript != htmlScript)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(htmlScript);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	
	    public TextElementsGreen Update(HtmlTagGreen htmlTag)
	    {
	        if (this.htmlTag != htmlTag)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.TextElements(htmlTag);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TextElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InlineTextGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList inlineTextElementWithComment;
	    private HtmlCommentListGreen trailingComment;
	
	    public InlineTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList inlineTextElementWithComment, HtmlCommentListGreen trailingComment)
	        : base(kind, null, null)
	    {
			if (inlineTextElementWithComment != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElementWithComment);
				this.inlineTextElementWithComment = inlineTextElementWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
	    public InlineTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList inlineTextElementWithComment, HtmlCommentListGreen trailingComment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (inlineTextElementWithComment != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElementWithComment);
				this.inlineTextElementWithComment = inlineTextElementWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList InlineTextElementWithComment { get { return this.inlineTextElementWithComment; } }
	    public HtmlCommentListGreen TrailingComment { get { return this.trailingComment; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InlineTextSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.inlineTextElementWithComment;
	            case 1: return this.trailingComment;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InlineTextGreen(this.Kind, this.inlineTextElementWithComment, this.trailingComment, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InlineTextGreen(this.Kind, this.inlineTextElementWithComment, this.trailingComment, this.GetDiagnostics(), annotations);
	    }
	
	    public InlineTextGreen Update(InternalSyntaxNodeList inlineTextElementWithComment, HtmlCommentListGreen trailingComment)
	    {
	        if (this.inlineTextElementWithComment != inlineTextElementWithComment ||
				this.trailingComment != trailingComment)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineText(inlineTextElementWithComment, trailingComment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InlineTextElementWithCommentGreen : MediaWikiGreenNode
	{
	    private HtmlCommentListGreen leadingComment;
	    private InlineTextElementGreen inlineTextElement;
	
	    public InlineTextElementWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, InlineTextElementGreen inlineTextElement)
	        : base(kind, null, null)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (inlineTextElement != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElement);
				this.inlineTextElement = inlineTextElement;
			}
	    }
	
	    public InlineTextElementWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, InlineTextElementGreen inlineTextElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (inlineTextElement != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElement);
				this.inlineTextElement = inlineTextElement;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public HtmlCommentListGreen LeadingComment { get { return this.leadingComment; } }
	    public InlineTextElementGreen InlineTextElement { get { return this.inlineTextElement; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InlineTextElementWithCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingComment;
	            case 1: return this.inlineTextElement;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InlineTextElementWithCommentGreen(this.Kind, this.leadingComment, this.inlineTextElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InlineTextElementWithCommentGreen(this.Kind, this.leadingComment, this.inlineTextElement, this.GetDiagnostics(), annotations);
	    }
	
	    public InlineTextElementWithCommentGreen Update(HtmlCommentListGreen leadingComment, InlineTextElementGreen inlineTextElement)
	    {
	        if (this.leadingComment != leadingComment ||
				this.inlineTextElement != inlineTextElement)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineTextElementWithComment(leadingComment, inlineTextElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextElementWithCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InlineTextElementGreen : MediaWikiGreenNode
	{
	    private TextElementsGreen textElements;
	    private InlineTextElementsGreen inlineTextElements;
	
	    public InlineTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, InlineTextElementsGreen inlineTextElements)
	        : base(kind, null, null)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (inlineTextElements != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElements);
				this.inlineTextElements = inlineTextElements;
			}
	    }
	
	    public InlineTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, InlineTextElementsGreen inlineTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (inlineTextElements != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElements);
				this.inlineTextElements = inlineTextElements;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TextElementsGreen TextElements { get { return this.textElements; } }
	    public InlineTextElementsGreen InlineTextElements { get { return this.inlineTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InlineTextElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.textElements;
	            case 1: return this.inlineTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InlineTextElementGreen(this.Kind, this.textElements, this.inlineTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InlineTextElementGreen(this.Kind, this.textElements, this.inlineTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public InlineTextElementGreen Update(TextElementsGreen textElements)
	    {
	        if (this.textElements != textElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineTextElement(textElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public InlineTextElementGreen Update(InlineTextElementsGreen inlineTextElements)
	    {
	        if (this.inlineTextElements != inlineTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineTextElement(inlineTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class InlineTextElementsGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken inlineTextElements;
	
	    public InlineTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken inlineTextElements)
	        : base(kind, null, null)
	    {
			if (inlineTextElements != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElements);
				this.inlineTextElements = inlineTextElements;
			}
	    }
	
	    public InlineTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken inlineTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (inlineTextElements != null)
			{
				this.AdjustFlagsAndWidth(inlineTextElements);
				this.inlineTextElements = inlineTextElements;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken InlineTextElements { get { return this.inlineTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.InlineTextElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.inlineTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new InlineTextElementsGreen(this.Kind, this.inlineTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new InlineTextElementsGreen(this.Kind, this.inlineTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public InlineTextElementsGreen Update(InternalSyntaxToken inlineTextElements)
	    {
	        if (this.inlineTextElements != inlineTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.InlineTextElements(inlineTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InlineTextElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DefinitionTextGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList definitionTextElementWithComment;
	    private HtmlCommentListGreen trailingComment;
	
	    public DefinitionTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList definitionTextElementWithComment, HtmlCommentListGreen trailingComment)
	        : base(kind, null, null)
	    {
			if (definitionTextElementWithComment != null)
			{
				this.AdjustFlagsAndWidth(definitionTextElementWithComment);
				this.definitionTextElementWithComment = definitionTextElementWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
	    public DefinitionTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList definitionTextElementWithComment, HtmlCommentListGreen trailingComment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (definitionTextElementWithComment != null)
			{
				this.AdjustFlagsAndWidth(definitionTextElementWithComment);
				this.definitionTextElementWithComment = definitionTextElementWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList DefinitionTextElementWithComment { get { return this.definitionTextElementWithComment; } }
	    public HtmlCommentListGreen TrailingComment { get { return this.trailingComment; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.DefinitionTextSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.definitionTextElementWithComment;
	            case 1: return this.trailingComment;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DefinitionTextGreen(this.Kind, this.definitionTextElementWithComment, this.trailingComment, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DefinitionTextGreen(this.Kind, this.definitionTextElementWithComment, this.trailingComment, this.GetDiagnostics(), annotations);
	    }
	
	    public DefinitionTextGreen Update(InternalSyntaxNodeList definitionTextElementWithComment, HtmlCommentListGreen trailingComment)
	    {
	        if (this.definitionTextElementWithComment != definitionTextElementWithComment ||
				this.trailingComment != trailingComment)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionText(definitionTextElementWithComment, trailingComment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DefinitionTextElementWithCommentGreen : MediaWikiGreenNode
	{
	    private HtmlCommentListGreen leadingComment;
	    private DefinitionTextElementGreen definitionTextElement;
	
	    public DefinitionTextElementWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, DefinitionTextElementGreen definitionTextElement)
	        : base(kind, null, null)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (definitionTextElement != null)
			{
				this.AdjustFlagsAndWidth(definitionTextElement);
				this.definitionTextElement = definitionTextElement;
			}
	    }
	
	    public DefinitionTextElementWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, DefinitionTextElementGreen definitionTextElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (definitionTextElement != null)
			{
				this.AdjustFlagsAndWidth(definitionTextElement);
				this.definitionTextElement = definitionTextElement;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public HtmlCommentListGreen LeadingComment { get { return this.leadingComment; } }
	    public DefinitionTextElementGreen DefinitionTextElement { get { return this.definitionTextElement; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.DefinitionTextElementWithCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingComment;
	            case 1: return this.definitionTextElement;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DefinitionTextElementWithCommentGreen(this.Kind, this.leadingComment, this.definitionTextElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DefinitionTextElementWithCommentGreen(this.Kind, this.leadingComment, this.definitionTextElement, this.GetDiagnostics(), annotations);
	    }
	
	    public DefinitionTextElementWithCommentGreen Update(HtmlCommentListGreen leadingComment, DefinitionTextElementGreen definitionTextElement)
	    {
	        if (this.leadingComment != leadingComment ||
				this.definitionTextElement != definitionTextElement)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionTextElementWithComment(leadingComment, definitionTextElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextElementWithCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DefinitionTextElementGreen : MediaWikiGreenNode
	{
	    private TextElementsGreen textElements;
	    private DefinitionTextElementsGreen definitionTextElements;
	
	    public DefinitionTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, DefinitionTextElementsGreen definitionTextElements)
	        : base(kind, null, null)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (definitionTextElements != null)
			{
				this.AdjustFlagsAndWidth(definitionTextElements);
				this.definitionTextElements = definitionTextElements;
			}
	    }
	
	    public DefinitionTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, DefinitionTextElementsGreen definitionTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (definitionTextElements != null)
			{
				this.AdjustFlagsAndWidth(definitionTextElements);
				this.definitionTextElements = definitionTextElements;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TextElementsGreen TextElements { get { return this.textElements; } }
	    public DefinitionTextElementsGreen DefinitionTextElements { get { return this.definitionTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.DefinitionTextElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.textElements;
	            case 1: return this.definitionTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DefinitionTextElementGreen(this.Kind, this.textElements, this.definitionTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DefinitionTextElementGreen(this.Kind, this.textElements, this.definitionTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public DefinitionTextElementGreen Update(TextElementsGreen textElements)
	    {
	        if (this.textElements != textElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionTextElement(textElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public DefinitionTextElementGreen Update(DefinitionTextElementsGreen definitionTextElements)
	    {
	        if (this.definitionTextElements != definitionTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionTextElement(definitionTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DefinitionTextElementsGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken definitionTextElements;
	
	    public DefinitionTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken definitionTextElements)
	        : base(kind, null, null)
	    {
			if (definitionTextElements != null)
			{
				this.AdjustFlagsAndWidth(definitionTextElements);
				this.definitionTextElements = definitionTextElements;
			}
	    }
	
	    public DefinitionTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken definitionTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (definitionTextElements != null)
			{
				this.AdjustFlagsAndWidth(definitionTextElements);
				this.definitionTextElements = definitionTextElements;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken DefinitionTextElements { get { return this.definitionTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.DefinitionTextElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.definitionTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DefinitionTextElementsGreen(this.Kind, this.definitionTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DefinitionTextElementsGreen(this.Kind, this.definitionTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public DefinitionTextElementsGreen Update(InternalSyntaxToken definitionTextElements)
	    {
	        if (this.definitionTextElements != definitionTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.DefinitionTextElements(definitionTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefinitionTextElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HeadingTextGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList headingTextWithComment;
	    private HtmlCommentListGreen trailingComment;
	
	    public HeadingTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList headingTextWithComment, HtmlCommentListGreen trailingComment)
	        : base(kind, null, null)
	    {
			if (headingTextWithComment != null)
			{
				this.AdjustFlagsAndWidth(headingTextWithComment);
				this.headingTextWithComment = headingTextWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
	    public HeadingTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList headingTextWithComment, HtmlCommentListGreen trailingComment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (headingTextWithComment != null)
			{
				this.AdjustFlagsAndWidth(headingTextWithComment);
				this.headingTextWithComment = headingTextWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList HeadingTextWithComment { get { return this.headingTextWithComment; } }
	    public HtmlCommentListGreen TrailingComment { get { return this.trailingComment; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HeadingTextSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.headingTextWithComment;
	            case 1: return this.trailingComment;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HeadingTextGreen(this.Kind, this.headingTextWithComment, this.trailingComment, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HeadingTextGreen(this.Kind, this.headingTextWithComment, this.trailingComment, this.GetDiagnostics(), annotations);
	    }
	
	    public HeadingTextGreen Update(InternalSyntaxNodeList headingTextWithComment, HtmlCommentListGreen trailingComment)
	    {
	        if (this.headingTextWithComment != headingTextWithComment ||
				this.trailingComment != trailingComment)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingText(headingTextWithComment, trailingComment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HeadingTextWithCommentGreen : MediaWikiGreenNode
	{
	    private HtmlCommentListGreen leadingComment;
	    private HeadingTextElementGreen headingTextElement;
	
	    public HeadingTextWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, HeadingTextElementGreen headingTextElement)
	        : base(kind, null, null)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (headingTextElement != null)
			{
				this.AdjustFlagsAndWidth(headingTextElement);
				this.headingTextElement = headingTextElement;
			}
	    }
	
	    public HeadingTextWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, HeadingTextElementGreen headingTextElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (headingTextElement != null)
			{
				this.AdjustFlagsAndWidth(headingTextElement);
				this.headingTextElement = headingTextElement;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public HtmlCommentListGreen LeadingComment { get { return this.leadingComment; } }
	    public HeadingTextElementGreen HeadingTextElement { get { return this.headingTextElement; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HeadingTextWithCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingComment;
	            case 1: return this.headingTextElement;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HeadingTextWithCommentGreen(this.Kind, this.leadingComment, this.headingTextElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HeadingTextWithCommentGreen(this.Kind, this.leadingComment, this.headingTextElement, this.GetDiagnostics(), annotations);
	    }
	
	    public HeadingTextWithCommentGreen Update(HtmlCommentListGreen leadingComment, HeadingTextElementGreen headingTextElement)
	    {
	        if (this.leadingComment != leadingComment ||
				this.headingTextElement != headingTextElement)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingTextWithComment(leadingComment, headingTextElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextWithCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HeadingTextElementGreen : MediaWikiGreenNode
	{
	    private TextElementsGreen textElements;
	    private HeadingTextElementsGreen headingTextElements;
	
	    public HeadingTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, HeadingTextElementsGreen headingTextElements)
	        : base(kind, null, null)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (headingTextElements != null)
			{
				this.AdjustFlagsAndWidth(headingTextElements);
				this.headingTextElements = headingTextElements;
			}
	    }
	
	    public HeadingTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, HeadingTextElementsGreen headingTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (headingTextElements != null)
			{
				this.AdjustFlagsAndWidth(headingTextElements);
				this.headingTextElements = headingTextElements;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TextElementsGreen TextElements { get { return this.textElements; } }
	    public HeadingTextElementsGreen HeadingTextElements { get { return this.headingTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HeadingTextElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.textElements;
	            case 1: return this.headingTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HeadingTextElementGreen(this.Kind, this.textElements, this.headingTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HeadingTextElementGreen(this.Kind, this.textElements, this.headingTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public HeadingTextElementGreen Update(TextElementsGreen textElements)
	    {
	        if (this.textElements != textElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingTextElement(textElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public HeadingTextElementGreen Update(HeadingTextElementsGreen headingTextElements)
	    {
	        if (this.headingTextElements != headingTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingTextElement(headingTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HeadingTextElementsGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken headingTextElements;
	
	    public HeadingTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken headingTextElements)
	        : base(kind, null, null)
	    {
			if (headingTextElements != null)
			{
				this.AdjustFlagsAndWidth(headingTextElements);
				this.headingTextElements = headingTextElements;
			}
	    }
	
	    public HeadingTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken headingTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (headingTextElements != null)
			{
				this.AdjustFlagsAndWidth(headingTextElements);
				this.headingTextElements = headingTextElements;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken HeadingTextElements { get { return this.headingTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HeadingTextElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.headingTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HeadingTextElementsGreen(this.Kind, this.headingTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HeadingTextElementsGreen(this.Kind, this.headingTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public HeadingTextElementsGreen Update(InternalSyntaxToken headingTextElements)
	    {
	        if (this.headingTextElements != headingTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HeadingTextElements(headingTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HeadingTextElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CellTextGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList cellTextElementWithComment;
	    private HtmlCommentListGreen trailingComment;
	
	    public CellTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList cellTextElementWithComment, HtmlCommentListGreen trailingComment)
	        : base(kind, null, null)
	    {
			if (cellTextElementWithComment != null)
			{
				this.AdjustFlagsAndWidth(cellTextElementWithComment);
				this.cellTextElementWithComment = cellTextElementWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
	    public CellTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList cellTextElementWithComment, HtmlCommentListGreen trailingComment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (cellTextElementWithComment != null)
			{
				this.AdjustFlagsAndWidth(cellTextElementWithComment);
				this.cellTextElementWithComment = cellTextElementWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList CellTextElementWithComment { get { return this.cellTextElementWithComment; } }
	    public HtmlCommentListGreen TrailingComment { get { return this.trailingComment; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.CellTextSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.cellTextElementWithComment;
	            case 1: return this.trailingComment;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CellTextGreen(this.Kind, this.cellTextElementWithComment, this.trailingComment, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CellTextGreen(this.Kind, this.cellTextElementWithComment, this.trailingComment, this.GetDiagnostics(), annotations);
	    }
	
	    public CellTextGreen Update(InternalSyntaxNodeList cellTextElementWithComment, HtmlCommentListGreen trailingComment)
	    {
	        if (this.cellTextElementWithComment != cellTextElementWithComment ||
				this.trailingComment != trailingComment)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.CellText(cellTextElementWithComment, trailingComment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CellTextElementWithCommentGreen : MediaWikiGreenNode
	{
	    private HtmlCommentListGreen leadingComment;
	    private CellTextElementGreen cellTextElement;
	
	    public CellTextElementWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, CellTextElementGreen cellTextElement)
	        : base(kind, null, null)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (cellTextElement != null)
			{
				this.AdjustFlagsAndWidth(cellTextElement);
				this.cellTextElement = cellTextElement;
			}
	    }
	
	    public CellTextElementWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, CellTextElementGreen cellTextElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (cellTextElement != null)
			{
				this.AdjustFlagsAndWidth(cellTextElement);
				this.cellTextElement = cellTextElement;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public HtmlCommentListGreen LeadingComment { get { return this.leadingComment; } }
	    public CellTextElementGreen CellTextElement { get { return this.cellTextElement; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.CellTextElementWithCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingComment;
	            case 1: return this.cellTextElement;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CellTextElementWithCommentGreen(this.Kind, this.leadingComment, this.cellTextElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CellTextElementWithCommentGreen(this.Kind, this.leadingComment, this.cellTextElement, this.GetDiagnostics(), annotations);
	    }
	
	    public CellTextElementWithCommentGreen Update(HtmlCommentListGreen leadingComment, CellTextElementGreen cellTextElement)
	    {
	        if (this.leadingComment != leadingComment ||
				this.cellTextElement != cellTextElement)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.CellTextElementWithComment(leadingComment, cellTextElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextElementWithCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CellTextElementGreen : MediaWikiGreenNode
	{
	    private TextElementsGreen textElements;
	    private CellTextElementsGreen cellTextElements;
	
	    public CellTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, CellTextElementsGreen cellTextElements)
	        : base(kind, null, null)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (cellTextElements != null)
			{
				this.AdjustFlagsAndWidth(cellTextElements);
				this.cellTextElements = cellTextElements;
			}
	    }
	
	    public CellTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, CellTextElementsGreen cellTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (cellTextElements != null)
			{
				this.AdjustFlagsAndWidth(cellTextElements);
				this.cellTextElements = cellTextElements;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TextElementsGreen TextElements { get { return this.textElements; } }
	    public CellTextElementsGreen CellTextElements { get { return this.cellTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.CellTextElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.textElements;
	            case 1: return this.cellTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CellTextElementGreen(this.Kind, this.textElements, this.cellTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CellTextElementGreen(this.Kind, this.textElements, this.cellTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public CellTextElementGreen Update(TextElementsGreen textElements)
	    {
	        if (this.textElements != textElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.CellTextElement(textElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public CellTextElementGreen Update(CellTextElementsGreen cellTextElements)
	    {
	        if (this.cellTextElements != cellTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.CellTextElement(cellTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class CellTextElementsGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken cellTextElements;
	
	    public CellTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken cellTextElements)
	        : base(kind, null, null)
	    {
			if (cellTextElements != null)
			{
				this.AdjustFlagsAndWidth(cellTextElements);
				this.cellTextElements = cellTextElements;
			}
	    }
	
	    public CellTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken cellTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (cellTextElements != null)
			{
				this.AdjustFlagsAndWidth(cellTextElements);
				this.cellTextElements = cellTextElements;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken CellTextElements { get { return this.cellTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.CellTextElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.cellTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new CellTextElementsGreen(this.Kind, this.cellTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new CellTextElementsGreen(this.Kind, this.cellTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public CellTextElementsGreen Update(InternalSyntaxToken cellTextElements)
	    {
	        if (this.cellTextElements != cellTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.CellTextElements(cellTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CellTextElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LinkTextGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList linkTextWithComment;
	    private HtmlCommentListGreen trailingComment;
	
	    public LinkTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList linkTextWithComment, HtmlCommentListGreen trailingComment)
	        : base(kind, null, null)
	    {
			if (linkTextWithComment != null)
			{
				this.AdjustFlagsAndWidth(linkTextWithComment);
				this.linkTextWithComment = linkTextWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
	    public LinkTextGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList linkTextWithComment, HtmlCommentListGreen trailingComment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (linkTextWithComment != null)
			{
				this.AdjustFlagsAndWidth(linkTextWithComment);
				this.linkTextWithComment = linkTextWithComment;
			}
			if (trailingComment != null)
			{
				this.AdjustFlagsAndWidth(trailingComment);
				this.trailingComment = trailingComment;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList LinkTextWithComment { get { return this.linkTextWithComment; } }
	    public HtmlCommentListGreen TrailingComment { get { return this.trailingComment; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.LinkTextSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.linkTextWithComment;
	            case 1: return this.trailingComment;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LinkTextGreen(this.Kind, this.linkTextWithComment, this.trailingComment, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LinkTextGreen(this.Kind, this.linkTextWithComment, this.trailingComment, this.GetDiagnostics(), annotations);
	    }
	
	    public LinkTextGreen Update(InternalSyntaxNodeList linkTextWithComment, HtmlCommentListGreen trailingComment)
	    {
	        if (this.linkTextWithComment != linkTextWithComment ||
				this.trailingComment != trailingComment)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkText(linkTextWithComment, trailingComment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LinkTextWithCommentGreen : MediaWikiGreenNode
	{
	    private HtmlCommentListGreen leadingComment;
	    private LinkTextElementGreen linkTextElement;
	
	    public LinkTextWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, LinkTextElementGreen linkTextElement)
	        : base(kind, null, null)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (linkTextElement != null)
			{
				this.AdjustFlagsAndWidth(linkTextElement);
				this.linkTextElement = linkTextElement;
			}
	    }
	
	    public LinkTextWithCommentGreen(MediaWikiSyntaxKind kind, HtmlCommentListGreen leadingComment, LinkTextElementGreen linkTextElement, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingComment != null)
			{
				this.AdjustFlagsAndWidth(leadingComment);
				this.leadingComment = leadingComment;
			}
			if (linkTextElement != null)
			{
				this.AdjustFlagsAndWidth(linkTextElement);
				this.linkTextElement = linkTextElement;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public HtmlCommentListGreen LeadingComment { get { return this.leadingComment; } }
	    public LinkTextElementGreen LinkTextElement { get { return this.linkTextElement; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.LinkTextWithCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingComment;
	            case 1: return this.linkTextElement;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LinkTextWithCommentGreen(this.Kind, this.leadingComment, this.linkTextElement, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LinkTextWithCommentGreen(this.Kind, this.leadingComment, this.linkTextElement, this.GetDiagnostics(), annotations);
	    }
	
	    public LinkTextWithCommentGreen Update(HtmlCommentListGreen leadingComment, LinkTextElementGreen linkTextElement)
	    {
	        if (this.leadingComment != leadingComment ||
				this.linkTextElement != linkTextElement)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextWithComment(leadingComment, linkTextElement);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextWithCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LinkTextElementGreen : MediaWikiGreenNode
	{
	    private TextElementsGreen textElements;
	    private LinkTextElementsGreen linkTextElements;
	
	    public LinkTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, LinkTextElementsGreen linkTextElements)
	        : base(kind, null, null)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (linkTextElements != null)
			{
				this.AdjustFlagsAndWidth(linkTextElements);
				this.linkTextElements = linkTextElements;
			}
	    }
	
	    public LinkTextElementGreen(MediaWikiSyntaxKind kind, TextElementsGreen textElements, LinkTextElementsGreen linkTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (textElements != null)
			{
				this.AdjustFlagsAndWidth(textElements);
				this.textElements = textElements;
			}
			if (linkTextElements != null)
			{
				this.AdjustFlagsAndWidth(linkTextElements);
				this.linkTextElements = linkTextElements;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TextElementsGreen TextElements { get { return this.textElements; } }
	    public LinkTextElementsGreen LinkTextElements { get { return this.linkTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.LinkTextElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.textElements;
	            case 1: return this.linkTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LinkTextElementGreen(this.Kind, this.textElements, this.linkTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LinkTextElementGreen(this.Kind, this.textElements, this.linkTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public LinkTextElementGreen Update(TextElementsGreen textElements)
	    {
	        if (this.textElements != textElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextElement(textElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextElementGreen)newNode;
	        }
	        return this;
	    }
	
	    public LinkTextElementGreen Update(LinkTextElementsGreen linkTextElements)
	    {
	        if (this.linkTextElements != linkTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextElement(linkTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LinkTextElementsGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken linkTextElements;
	
	    public LinkTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken linkTextElements)
	        : base(kind, null, null)
	    {
			if (linkTextElements != null)
			{
				this.AdjustFlagsAndWidth(linkTextElements);
				this.linkTextElements = linkTextElements;
			}
	    }
	
	    public LinkTextElementsGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken linkTextElements, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (linkTextElements != null)
			{
				this.AdjustFlagsAndWidth(linkTextElements);
				this.linkTextElements = linkTextElements;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken LinkTextElements { get { return this.linkTextElements; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.LinkTextElementsSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.linkTextElements;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LinkTextElementsGreen(this.Kind, this.linkTextElements, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LinkTextElementsGreen(this.Kind, this.linkTextElements, this.GetDiagnostics(), annotations);
	    }
	
	    public LinkTextElementsGreen Update(InternalSyntaxToken linkTextElements)
	    {
	        if (this.linkTextElements != linkTextElements)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextElements(linkTextElements);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextElementsGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WikiFormatGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tFormat;
	
	    public WikiFormatGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tFormat)
	        : base(kind, null, null)
	    {
			if (tFormat != null)
			{
				this.AdjustFlagsAndWidth(tFormat);
				this.tFormat = tFormat;
			}
	    }
	
	    public WikiFormatGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tFormat, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tFormat != null)
			{
				this.AdjustFlagsAndWidth(tFormat);
				this.tFormat = tFormat;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TFormat { get { return this.tFormat; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WikiFormatSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tFormat;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WikiFormatGreen(this.Kind, this.tFormat, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WikiFormatGreen(this.Kind, this.tFormat, this.GetDiagnostics(), annotations);
	    }
	
	    public WikiFormatGreen Update(InternalSyntaxToken tFormat)
	    {
	        if (this.tFormat != tFormat)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiFormat(tFormat);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiFormatGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WikiLinkGreen : MediaWikiGreenNode
	{
	    private WikiInternalLinkGreen wikiInternalLink;
	    private WikiExternalLinkGreen wikiExternalLink;
	
	    public WikiLinkGreen(MediaWikiSyntaxKind kind, WikiInternalLinkGreen wikiInternalLink, WikiExternalLinkGreen wikiExternalLink)
	        : base(kind, null, null)
	    {
			if (wikiInternalLink != null)
			{
				this.AdjustFlagsAndWidth(wikiInternalLink);
				this.wikiInternalLink = wikiInternalLink;
			}
			if (wikiExternalLink != null)
			{
				this.AdjustFlagsAndWidth(wikiExternalLink);
				this.wikiExternalLink = wikiExternalLink;
			}
	    }
	
	    public WikiLinkGreen(MediaWikiSyntaxKind kind, WikiInternalLinkGreen wikiInternalLink, WikiExternalLinkGreen wikiExternalLink, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (wikiInternalLink != null)
			{
				this.AdjustFlagsAndWidth(wikiInternalLink);
				this.wikiInternalLink = wikiInternalLink;
			}
			if (wikiExternalLink != null)
			{
				this.AdjustFlagsAndWidth(wikiExternalLink);
				this.wikiExternalLink = wikiExternalLink;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public WikiInternalLinkGreen WikiInternalLink { get { return this.wikiInternalLink; } }
	    public WikiExternalLinkGreen WikiExternalLink { get { return this.wikiExternalLink; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WikiLinkSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.wikiInternalLink;
	            case 1: return this.wikiExternalLink;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WikiLinkGreen(this.Kind, this.wikiInternalLink, this.wikiExternalLink, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WikiLinkGreen(this.Kind, this.wikiInternalLink, this.wikiExternalLink, this.GetDiagnostics(), annotations);
	    }
	
	    public WikiLinkGreen Update(WikiInternalLinkGreen wikiInternalLink)
	    {
	        if (this.wikiInternalLink != wikiInternalLink)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiLink(wikiInternalLink);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiLinkGreen)newNode;
	        }
	        return this;
	    }
	
	    public WikiLinkGreen Update(WikiExternalLinkGreen wikiExternalLink)
	    {
	        if (this.wikiExternalLink != wikiExternalLink)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiLink(wikiExternalLink);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiLinkGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WikiInternalLinkGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tLinkStart;
	    private LinkTextGreen linkText;
	    private InternalSyntaxNodeList linkTextPart;
	    private InternalSyntaxToken tLinkEnd;
	
	    public WikiInternalLinkGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tLinkStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tLinkEnd)
	        : base(kind, null, null)
	    {
			if (tLinkStart != null)
			{
				this.AdjustFlagsAndWidth(tLinkStart);
				this.tLinkStart = tLinkStart;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
			if (linkTextPart != null)
			{
				this.AdjustFlagsAndWidth(linkTextPart);
				this.linkTextPart = linkTextPart;
			}
			if (tLinkEnd != null)
			{
				this.AdjustFlagsAndWidth(tLinkEnd);
				this.tLinkEnd = tLinkEnd;
			}
	    }
	
	    public WikiInternalLinkGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tLinkStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tLinkEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tLinkStart != null)
			{
				this.AdjustFlagsAndWidth(tLinkStart);
				this.tLinkStart = tLinkStart;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
			if (linkTextPart != null)
			{
				this.AdjustFlagsAndWidth(linkTextPart);
				this.linkTextPart = linkTextPart;
			}
			if (tLinkEnd != null)
			{
				this.AdjustFlagsAndWidth(tLinkEnd);
				this.tLinkEnd = tLinkEnd;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TLinkStart { get { return this.tLinkStart; } }
	    public LinkTextGreen LinkText { get { return this.linkText; } }
	    public InternalSyntaxNodeList LinkTextPart { get { return this.linkTextPart; } }
	    public InternalSyntaxToken TLinkEnd { get { return this.tLinkEnd; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WikiInternalLinkSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tLinkStart;
	            case 1: return this.linkText;
	            case 2: return this.linkTextPart;
	            case 3: return this.tLinkEnd;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WikiInternalLinkGreen(this.Kind, this.tLinkStart, this.linkText, this.linkTextPart, this.tLinkEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WikiInternalLinkGreen(this.Kind, this.tLinkStart, this.linkText, this.linkTextPart, this.tLinkEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public WikiInternalLinkGreen Update(InternalSyntaxToken tLinkStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tLinkEnd)
	    {
	        if (this.tLinkStart != tLinkStart ||
				this.linkText != linkText ||
				this.linkTextPart != linkTextPart ||
				this.tLinkEnd != tLinkEnd)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiInternalLink(tLinkStart, linkText, linkTextPart, tLinkEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiInternalLinkGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WikiExternalLinkGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tExternalLinkStart;
	    private LinkTextGreen linkText;
	    private InternalSyntaxNodeList linkTextPart;
	    private InternalSyntaxToken tExternalLinkEnd;
	
	    public WikiExternalLinkGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tExternalLinkStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tExternalLinkEnd)
	        : base(kind, null, null)
	    {
			if (tExternalLinkStart != null)
			{
				this.AdjustFlagsAndWidth(tExternalLinkStart);
				this.tExternalLinkStart = tExternalLinkStart;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
			if (linkTextPart != null)
			{
				this.AdjustFlagsAndWidth(linkTextPart);
				this.linkTextPart = linkTextPart;
			}
			if (tExternalLinkEnd != null)
			{
				this.AdjustFlagsAndWidth(tExternalLinkEnd);
				this.tExternalLinkEnd = tExternalLinkEnd;
			}
	    }
	
	    public WikiExternalLinkGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tExternalLinkStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tExternalLinkEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tExternalLinkStart != null)
			{
				this.AdjustFlagsAndWidth(tExternalLinkStart);
				this.tExternalLinkStart = tExternalLinkStart;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
			if (linkTextPart != null)
			{
				this.AdjustFlagsAndWidth(linkTextPart);
				this.linkTextPart = linkTextPart;
			}
			if (tExternalLinkEnd != null)
			{
				this.AdjustFlagsAndWidth(tExternalLinkEnd);
				this.tExternalLinkEnd = tExternalLinkEnd;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TExternalLinkStart { get { return this.tExternalLinkStart; } }
	    public LinkTextGreen LinkText { get { return this.linkText; } }
	    public InternalSyntaxNodeList LinkTextPart { get { return this.linkTextPart; } }
	    public InternalSyntaxToken TExternalLinkEnd { get { return this.tExternalLinkEnd; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WikiExternalLinkSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tExternalLinkStart;
	            case 1: return this.linkText;
	            case 2: return this.linkTextPart;
	            case 3: return this.tExternalLinkEnd;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WikiExternalLinkGreen(this.Kind, this.tExternalLinkStart, this.linkText, this.linkTextPart, this.tExternalLinkEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WikiExternalLinkGreen(this.Kind, this.tExternalLinkStart, this.linkText, this.linkTextPart, this.tExternalLinkEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public WikiExternalLinkGreen Update(InternalSyntaxToken tExternalLinkStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tExternalLinkEnd)
	    {
	        if (this.tExternalLinkStart != tExternalLinkStart ||
				this.linkText != linkText ||
				this.linkTextPart != linkTextPart ||
				this.tExternalLinkEnd != tExternalLinkEnd)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiExternalLink(tExternalLinkStart, linkText, linkTextPart, tExternalLinkEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiExternalLinkGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WikiTemplateGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTemplateStart;
	    private LinkTextGreen linkText;
	    private InternalSyntaxNodeList linkTextPart;
	    private InternalSyntaxToken tTemplateEnd;
	
	    public WikiTemplateGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTemplateStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tTemplateEnd)
	        : base(kind, null, null)
	    {
			if (tTemplateStart != null)
			{
				this.AdjustFlagsAndWidth(tTemplateStart);
				this.tTemplateStart = tTemplateStart;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
			if (linkTextPart != null)
			{
				this.AdjustFlagsAndWidth(linkTextPart);
				this.linkTextPart = linkTextPart;
			}
			if (tTemplateEnd != null)
			{
				this.AdjustFlagsAndWidth(tTemplateEnd);
				this.tTemplateEnd = tTemplateEnd;
			}
	    }
	
	    public WikiTemplateGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTemplateStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tTemplateEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTemplateStart != null)
			{
				this.AdjustFlagsAndWidth(tTemplateStart);
				this.tTemplateStart = tTemplateStart;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
			if (linkTextPart != null)
			{
				this.AdjustFlagsAndWidth(linkTextPart);
				this.linkTextPart = linkTextPart;
			}
			if (tTemplateEnd != null)
			{
				this.AdjustFlagsAndWidth(tTemplateEnd);
				this.tTemplateEnd = tTemplateEnd;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TTemplateStart { get { return this.tTemplateStart; } }
	    public LinkTextGreen LinkText { get { return this.linkText; } }
	    public InternalSyntaxNodeList LinkTextPart { get { return this.linkTextPart; } }
	    public InternalSyntaxToken TTemplateEnd { get { return this.tTemplateEnd; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WikiTemplateSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTemplateStart;
	            case 1: return this.linkText;
	            case 2: return this.linkTextPart;
	            case 3: return this.tTemplateEnd;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WikiTemplateGreen(this.Kind, this.tTemplateStart, this.linkText, this.linkTextPart, this.tTemplateEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WikiTemplateGreen(this.Kind, this.tTemplateStart, this.linkText, this.linkTextPart, this.tTemplateEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public WikiTemplateGreen Update(InternalSyntaxToken tTemplateStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tTemplateEnd)
	    {
	        if (this.tTemplateStart != tTemplateStart ||
				this.linkText != linkText ||
				this.linkTextPart != linkTextPart ||
				this.tTemplateEnd != tTemplateEnd)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiTemplate(tTemplateStart, linkText, linkTextPart, tTemplateEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiTemplateGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WikiTemplateParamGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTemplateParamStart;
	    private LinkTextGreen linkText;
	    private InternalSyntaxNodeList linkTextPart;
	    private InternalSyntaxToken tTemplateParamEnd;
	
	    public WikiTemplateParamGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTemplateParamStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tTemplateParamEnd)
	        : base(kind, null, null)
	    {
			if (tTemplateParamStart != null)
			{
				this.AdjustFlagsAndWidth(tTemplateParamStart);
				this.tTemplateParamStart = tTemplateParamStart;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
			if (linkTextPart != null)
			{
				this.AdjustFlagsAndWidth(linkTextPart);
				this.linkTextPart = linkTextPart;
			}
			if (tTemplateParamEnd != null)
			{
				this.AdjustFlagsAndWidth(tTemplateParamEnd);
				this.tTemplateParamEnd = tTemplateParamEnd;
			}
	    }
	
	    public WikiTemplateParamGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTemplateParamStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tTemplateParamEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTemplateParamStart != null)
			{
				this.AdjustFlagsAndWidth(tTemplateParamStart);
				this.tTemplateParamStart = tTemplateParamStart;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
			if (linkTextPart != null)
			{
				this.AdjustFlagsAndWidth(linkTextPart);
				this.linkTextPart = linkTextPart;
			}
			if (tTemplateParamEnd != null)
			{
				this.AdjustFlagsAndWidth(tTemplateParamEnd);
				this.tTemplateParamEnd = tTemplateParamEnd;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken TTemplateParamStart { get { return this.tTemplateParamStart; } }
	    public LinkTextGreen LinkText { get { return this.linkText; } }
	    public InternalSyntaxNodeList LinkTextPart { get { return this.linkTextPart; } }
	    public InternalSyntaxToken TTemplateParamEnd { get { return this.tTemplateParamEnd; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WikiTemplateParamSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTemplateParamStart;
	            case 1: return this.linkText;
	            case 2: return this.linkTextPart;
	            case 3: return this.tTemplateParamEnd;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WikiTemplateParamGreen(this.Kind, this.tTemplateParamStart, this.linkText, this.linkTextPart, this.tTemplateParamEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WikiTemplateParamGreen(this.Kind, this.tTemplateParamStart, this.linkText, this.linkTextPart, this.tTemplateParamEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public WikiTemplateParamGreen Update(InternalSyntaxToken tTemplateParamStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tTemplateParamEnd)
	    {
	        if (this.tTemplateParamStart != tTemplateParamStart ||
				this.linkText != linkText ||
				this.linkTextPart != linkTextPart ||
				this.tTemplateParamEnd != tTemplateParamEnd)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WikiTemplateParam(tTemplateParamStart, linkText, linkTextPart, tTemplateParamEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WikiTemplateParamGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NoWikiGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tNoWiki;
	
	    public NoWikiGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tNoWiki)
	        : base(kind, null, null)
	    {
			if (tNoWiki != null)
			{
				this.AdjustFlagsAndWidth(tNoWiki);
				this.tNoWiki = tNoWiki;
			}
	    }
	
	    public NoWikiGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tNoWiki, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tNoWiki != null)
			{
				this.AdjustFlagsAndWidth(tNoWiki);
				this.tNoWiki = tNoWiki;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TNoWiki { get { return this.tNoWiki; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.NoWikiSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tNoWiki;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NoWikiGreen(this.Kind, this.tNoWiki, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NoWikiGreen(this.Kind, this.tNoWiki, this.GetDiagnostics(), annotations);
	    }
	
	    public NoWikiGreen Update(InternalSyntaxToken tNoWiki)
	    {
	        if (this.tNoWiki != tNoWiki)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.NoWiki(tNoWiki);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NoWikiGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class BarOrBarBarGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken barOrBarBar;
	
	    public BarOrBarBarGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken barOrBarBar)
	        : base(kind, null, null)
	    {
			if (barOrBarBar != null)
			{
				this.AdjustFlagsAndWidth(barOrBarBar);
				this.barOrBarBar = barOrBarBar;
			}
	    }
	
	    public BarOrBarBarGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken barOrBarBar, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (barOrBarBar != null)
			{
				this.AdjustFlagsAndWidth(barOrBarBar);
				this.barOrBarBar = barOrBarBar;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken BarOrBarBar { get { return this.barOrBarBar; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.BarOrBarBarSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.barOrBarBar;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new BarOrBarBarGreen(this.Kind, this.barOrBarBar, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new BarOrBarBarGreen(this.Kind, this.barOrBarBar, this.GetDiagnostics(), annotations);
	    }
	
	    public BarOrBarBarGreen Update(InternalSyntaxToken barOrBarBar)
	    {
	        if (this.barOrBarBar != barOrBarBar)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.BarOrBarBar(barOrBarBar);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BarOrBarBarGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LinkTextPartGreen : MediaWikiGreenNode
	{
	    private BarOrBarBarGreen barOrBarBar;
	    private LinkTextGreen linkText;
	
	    public LinkTextPartGreen(MediaWikiSyntaxKind kind, BarOrBarBarGreen barOrBarBar, LinkTextGreen linkText)
	        : base(kind, null, null)
	    {
			if (barOrBarBar != null)
			{
				this.AdjustFlagsAndWidth(barOrBarBar);
				this.barOrBarBar = barOrBarBar;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
	    }
	
	    public LinkTextPartGreen(MediaWikiSyntaxKind kind, BarOrBarBarGreen barOrBarBar, LinkTextGreen linkText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (barOrBarBar != null)
			{
				this.AdjustFlagsAndWidth(barOrBarBar);
				this.barOrBarBar = barOrBarBar;
			}
			if (linkText != null)
			{
				this.AdjustFlagsAndWidth(linkText);
				this.linkText = linkText;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public BarOrBarBarGreen BarOrBarBar { get { return this.barOrBarBar; } }
	    public LinkTextGreen LinkText { get { return this.linkText; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.LinkTextPartSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.barOrBarBar;
	            case 1: return this.linkText;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LinkTextPartGreen(this.Kind, this.barOrBarBar, this.linkText, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LinkTextPartGreen(this.Kind, this.barOrBarBar, this.linkText, this.GetDiagnostics(), annotations);
	    }
	
	    public LinkTextPartGreen Update(BarOrBarBarGreen barOrBarBar, LinkTextGreen linkText)
	    {
	        if (this.barOrBarBar != barOrBarBar ||
				this.linkText != linkText)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.LinkTextPart(barOrBarBar, linkText);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LinkTextPartGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlReferenceGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken htmlReference;
	
	    public HtmlReferenceGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken htmlReference)
	        : base(kind, null, null)
	    {
			if (htmlReference != null)
			{
				this.AdjustFlagsAndWidth(htmlReference);
				this.htmlReference = htmlReference;
			}
	    }
	
	    public HtmlReferenceGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken htmlReference, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (htmlReference != null)
			{
				this.AdjustFlagsAndWidth(htmlReference);
				this.htmlReference = htmlReference;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken HtmlReference { get { return this.htmlReference; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlReferenceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.htmlReference;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlReferenceGreen(this.Kind, this.htmlReference, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlReferenceGreen(this.Kind, this.htmlReference, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlReferenceGreen Update(InternalSyntaxToken htmlReference)
	    {
	        if (this.htmlReference != htmlReference)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlReference(htmlReference);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlReferenceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlCommentListGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList htmlComment;
	
	    public HtmlCommentListGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList htmlComment)
	        : base(kind, null, null)
	    {
			if (htmlComment != null)
			{
				this.AdjustFlagsAndWidth(htmlComment);
				this.htmlComment = htmlComment;
			}
	    }
	
	    public HtmlCommentListGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList htmlComment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (htmlComment != null)
			{
				this.AdjustFlagsAndWidth(htmlComment);
				this.htmlComment = htmlComment;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList HtmlComment { get { return this.htmlComment; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlCommentListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.htmlComment;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlCommentListGreen(this.Kind, this.htmlComment, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlCommentListGreen(this.Kind, this.htmlComment, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlCommentListGreen Update(InternalSyntaxNodeList htmlComment)
	    {
	        if (this.htmlComment != htmlComment)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlCommentList(htmlComment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlCommentListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlCommentGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tHtmlComment;
	
	    public HtmlCommentGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHtmlComment)
	        : base(kind, null, null)
	    {
			if (tHtmlComment != null)
			{
				this.AdjustFlagsAndWidth(tHtmlComment);
				this.tHtmlComment = tHtmlComment;
			}
	    }
	
	    public HtmlCommentGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHtmlComment, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tHtmlComment != null)
			{
				this.AdjustFlagsAndWidth(tHtmlComment);
				this.tHtmlComment = tHtmlComment;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken THtmlComment { get { return this.tHtmlComment; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlCommentSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tHtmlComment;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlCommentGreen(this.Kind, this.tHtmlComment, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlCommentGreen(this.Kind, this.tHtmlComment, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlCommentGreen Update(InternalSyntaxToken tHtmlComment)
	    {
	        if (this.tHtmlComment != tHtmlComment)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlComment(tHtmlComment);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlCommentGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlStyleGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tHtmlStyle;
	
	    public HtmlStyleGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHtmlStyle)
	        : base(kind, null, null)
	    {
			if (tHtmlStyle != null)
			{
				this.AdjustFlagsAndWidth(tHtmlStyle);
				this.tHtmlStyle = tHtmlStyle;
			}
	    }
	
	    public HtmlStyleGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHtmlStyle, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tHtmlStyle != null)
			{
				this.AdjustFlagsAndWidth(tHtmlStyle);
				this.tHtmlStyle = tHtmlStyle;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken THtmlStyle { get { return this.tHtmlStyle; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlStyleSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tHtmlStyle;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlStyleGreen(this.Kind, this.tHtmlStyle, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlStyleGreen(this.Kind, this.tHtmlStyle, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlStyleGreen Update(InternalSyntaxToken tHtmlStyle)
	    {
	        if (this.tHtmlStyle != tHtmlStyle)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlStyle(tHtmlStyle);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlStyleGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlScriptGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tHtmlScript;
	
	    public HtmlScriptGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHtmlScript)
	        : base(kind, null, null)
	    {
			if (tHtmlScript != null)
			{
				this.AdjustFlagsAndWidth(tHtmlScript);
				this.tHtmlScript = tHtmlScript;
			}
	    }
	
	    public HtmlScriptGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tHtmlScript, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tHtmlScript != null)
			{
				this.AdjustFlagsAndWidth(tHtmlScript);
				this.tHtmlScript = tHtmlScript;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken THtmlScript { get { return this.tHtmlScript; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlScriptSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tHtmlScript;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlScriptGreen(this.Kind, this.tHtmlScript, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlScriptGreen(this.Kind, this.tHtmlScript, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlScriptGreen Update(InternalSyntaxToken tHtmlScript)
	    {
	        if (this.tHtmlScript != tHtmlScript)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlScript(tHtmlScript);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlScriptGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlTagGreen : MediaWikiGreenNode
	{
	    private HtmlTagOpenGreen htmlTagOpen;
	    private HtmlTagCloseGreen htmlTagClose;
	    private HtmlTagEmptyGreen htmlTagEmpty;
	
	    public HtmlTagGreen(MediaWikiSyntaxKind kind, HtmlTagOpenGreen htmlTagOpen, HtmlTagCloseGreen htmlTagClose, HtmlTagEmptyGreen htmlTagEmpty)
	        : base(kind, null, null)
	    {
			if (htmlTagOpen != null)
			{
				this.AdjustFlagsAndWidth(htmlTagOpen);
				this.htmlTagOpen = htmlTagOpen;
			}
			if (htmlTagClose != null)
			{
				this.AdjustFlagsAndWidth(htmlTagClose);
				this.htmlTagClose = htmlTagClose;
			}
			if (htmlTagEmpty != null)
			{
				this.AdjustFlagsAndWidth(htmlTagEmpty);
				this.htmlTagEmpty = htmlTagEmpty;
			}
	    }
	
	    public HtmlTagGreen(MediaWikiSyntaxKind kind, HtmlTagOpenGreen htmlTagOpen, HtmlTagCloseGreen htmlTagClose, HtmlTagEmptyGreen htmlTagEmpty, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (htmlTagOpen != null)
			{
				this.AdjustFlagsAndWidth(htmlTagOpen);
				this.htmlTagOpen = htmlTagOpen;
			}
			if (htmlTagClose != null)
			{
				this.AdjustFlagsAndWidth(htmlTagClose);
				this.htmlTagClose = htmlTagClose;
			}
			if (htmlTagEmpty != null)
			{
				this.AdjustFlagsAndWidth(htmlTagEmpty);
				this.htmlTagEmpty = htmlTagEmpty;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public HtmlTagOpenGreen HtmlTagOpen { get { return this.htmlTagOpen; } }
	    public HtmlTagCloseGreen HtmlTagClose { get { return this.htmlTagClose; } }
	    public HtmlTagEmptyGreen HtmlTagEmpty { get { return this.htmlTagEmpty; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlTagSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.htmlTagOpen;
	            case 1: return this.htmlTagClose;
	            case 2: return this.htmlTagEmpty;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlTagGreen(this.Kind, this.htmlTagOpen, this.htmlTagClose, this.htmlTagEmpty, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlTagGreen(this.Kind, this.htmlTagOpen, this.htmlTagClose, this.htmlTagEmpty, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlTagGreen Update(HtmlTagOpenGreen htmlTagOpen)
	    {
	        if (this.htmlTagOpen != htmlTagOpen)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTag(htmlTagOpen);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagGreen)newNode;
	        }
	        return this;
	    }
	
	    public HtmlTagGreen Update(HtmlTagCloseGreen htmlTagClose)
	    {
	        if (this.htmlTagClose != htmlTagClose)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTag(htmlTagClose);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagGreen)newNode;
	        }
	        return this;
	    }
	
	    public HtmlTagGreen Update(HtmlTagEmptyGreen htmlTagEmpty)
	    {
	        if (this.htmlTagEmpty != htmlTagEmpty)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTag(htmlTagEmpty);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlTagOpenGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTagStart;
	    private WhitespaceListGreen leadingWhitespace;
	    private HtmlTagNameGreen htmlTagName;
	    private InternalSyntaxNodeList htmlAttribute;
	    private WhitespaceListGreen trailingWhitespace;
	    private InternalSyntaxToken tTagEnd;
	
	    public HtmlTagOpenGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tTagEnd)
	        : base(kind, null, null)
	    {
			if (tTagStart != null)
			{
				this.AdjustFlagsAndWidth(tTagStart);
				this.tTagStart = tTagStart;
			}
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlTagName != null)
			{
				this.AdjustFlagsAndWidth(htmlTagName);
				this.htmlTagName = htmlTagName;
			}
			if (htmlAttribute != null)
			{
				this.AdjustFlagsAndWidth(htmlAttribute);
				this.htmlAttribute = htmlAttribute;
			}
			if (trailingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(trailingWhitespace);
				this.trailingWhitespace = trailingWhitespace;
			}
			if (tTagEnd != null)
			{
				this.AdjustFlagsAndWidth(tTagEnd);
				this.tTagEnd = tTagEnd;
			}
	    }
	
	    public HtmlTagOpenGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tTagEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTagStart != null)
			{
				this.AdjustFlagsAndWidth(tTagStart);
				this.tTagStart = tTagStart;
			}
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlTagName != null)
			{
				this.AdjustFlagsAndWidth(htmlTagName);
				this.htmlTagName = htmlTagName;
			}
			if (htmlAttribute != null)
			{
				this.AdjustFlagsAndWidth(htmlAttribute);
				this.htmlAttribute = htmlAttribute;
			}
			if (trailingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(trailingWhitespace);
				this.trailingWhitespace = trailingWhitespace;
			}
			if (tTagEnd != null)
			{
				this.AdjustFlagsAndWidth(tTagEnd);
				this.tTagEnd = tTagEnd;
			}
	    }
	
		public override int SlotCount { get { return 6; } }
	
	    public InternalSyntaxToken TTagStart { get { return this.tTagStart; } }
	    public WhitespaceListGreen LeadingWhitespace { get { return this.leadingWhitespace; } }
	    public HtmlTagNameGreen HtmlTagName { get { return this.htmlTagName; } }
	    public InternalSyntaxNodeList HtmlAttribute { get { return this.htmlAttribute; } }
	    public WhitespaceListGreen TrailingWhitespace { get { return this.trailingWhitespace; } }
	    public InternalSyntaxToken TTagEnd { get { return this.tTagEnd; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlTagOpenSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTagStart;
	            case 1: return this.leadingWhitespace;
	            case 2: return this.htmlTagName;
	            case 3: return this.htmlAttribute;
	            case 4: return this.trailingWhitespace;
	            case 5: return this.tTagEnd;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlTagOpenGreen(this.Kind, this.tTagStart, this.leadingWhitespace, this.htmlTagName, this.htmlAttribute, this.trailingWhitespace, this.tTagEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlTagOpenGreen(this.Kind, this.tTagStart, this.leadingWhitespace, this.htmlTagName, this.htmlAttribute, this.trailingWhitespace, this.tTagEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlTagOpenGreen Update(InternalSyntaxToken tTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tTagEnd)
	    {
	        if (this.tTagStart != tTagStart ||
				this.leadingWhitespace != leadingWhitespace ||
				this.htmlTagName != htmlTagName ||
				this.htmlAttribute != htmlAttribute ||
				this.trailingWhitespace != trailingWhitespace ||
				this.tTagEnd != tTagEnd)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTagOpen(tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagOpenGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlTagCloseGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tEndTagStart;
	    private WhitespaceListGreen leadingWhitespace;
	    private HtmlTagNameGreen htmlTagName;
	    private InternalSyntaxNodeList htmlAttribute;
	    private WhitespaceListGreen trailingWhitespace;
	    private InternalSyntaxToken tEndTagEnd;
	
	    public HtmlTagCloseGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tEndTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tEndTagEnd)
	        : base(kind, null, null)
	    {
			if (tEndTagStart != null)
			{
				this.AdjustFlagsAndWidth(tEndTagStart);
				this.tEndTagStart = tEndTagStart;
			}
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlTagName != null)
			{
				this.AdjustFlagsAndWidth(htmlTagName);
				this.htmlTagName = htmlTagName;
			}
			if (htmlAttribute != null)
			{
				this.AdjustFlagsAndWidth(htmlAttribute);
				this.htmlAttribute = htmlAttribute;
			}
			if (trailingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(trailingWhitespace);
				this.trailingWhitespace = trailingWhitespace;
			}
			if (tEndTagEnd != null)
			{
				this.AdjustFlagsAndWidth(tEndTagEnd);
				this.tEndTagEnd = tEndTagEnd;
			}
	    }
	
	    public HtmlTagCloseGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tEndTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tEndTagEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tEndTagStart != null)
			{
				this.AdjustFlagsAndWidth(tEndTagStart);
				this.tEndTagStart = tEndTagStart;
			}
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlTagName != null)
			{
				this.AdjustFlagsAndWidth(htmlTagName);
				this.htmlTagName = htmlTagName;
			}
			if (htmlAttribute != null)
			{
				this.AdjustFlagsAndWidth(htmlAttribute);
				this.htmlAttribute = htmlAttribute;
			}
			if (trailingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(trailingWhitespace);
				this.trailingWhitespace = trailingWhitespace;
			}
			if (tEndTagEnd != null)
			{
				this.AdjustFlagsAndWidth(tEndTagEnd);
				this.tEndTagEnd = tEndTagEnd;
			}
	    }
	
		public override int SlotCount { get { return 6; } }
	
	    public InternalSyntaxToken TEndTagStart { get { return this.tEndTagStart; } }
	    public WhitespaceListGreen LeadingWhitespace { get { return this.leadingWhitespace; } }
	    public HtmlTagNameGreen HtmlTagName { get { return this.htmlTagName; } }
	    public InternalSyntaxNodeList HtmlAttribute { get { return this.htmlAttribute; } }
	    public WhitespaceListGreen TrailingWhitespace { get { return this.trailingWhitespace; } }
	    public InternalSyntaxToken TEndTagEnd { get { return this.tEndTagEnd; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlTagCloseSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tEndTagStart;
	            case 1: return this.leadingWhitespace;
	            case 2: return this.htmlTagName;
	            case 3: return this.htmlAttribute;
	            case 4: return this.trailingWhitespace;
	            case 5: return this.tEndTagEnd;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlTagCloseGreen(this.Kind, this.tEndTagStart, this.leadingWhitespace, this.htmlTagName, this.htmlAttribute, this.trailingWhitespace, this.tEndTagEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlTagCloseGreen(this.Kind, this.tEndTagStart, this.leadingWhitespace, this.htmlTagName, this.htmlAttribute, this.trailingWhitespace, this.tEndTagEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlTagCloseGreen Update(InternalSyntaxToken tEndTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tEndTagEnd)
	    {
	        if (this.tEndTagStart != tEndTagStart ||
				this.leadingWhitespace != leadingWhitespace ||
				this.htmlTagName != htmlTagName ||
				this.htmlAttribute != htmlAttribute ||
				this.trailingWhitespace != trailingWhitespace ||
				this.tEndTagEnd != tEndTagEnd)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTagClose(tEndTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tEndTagEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagCloseGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlTagEmptyGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTagStart;
	    private WhitespaceListGreen leadingWhitespace;
	    private HtmlTagNameGreen htmlTagName;
	    private InternalSyntaxNodeList htmlAttribute;
	    private WhitespaceListGreen trailingWhitespace;
	    private InternalSyntaxToken tTagCloseEnd;
	
	    public HtmlTagEmptyGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tTagCloseEnd)
	        : base(kind, null, null)
	    {
			if (tTagStart != null)
			{
				this.AdjustFlagsAndWidth(tTagStart);
				this.tTagStart = tTagStart;
			}
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlTagName != null)
			{
				this.AdjustFlagsAndWidth(htmlTagName);
				this.htmlTagName = htmlTagName;
			}
			if (htmlAttribute != null)
			{
				this.AdjustFlagsAndWidth(htmlAttribute);
				this.htmlAttribute = htmlAttribute;
			}
			if (trailingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(trailingWhitespace);
				this.trailingWhitespace = trailingWhitespace;
			}
			if (tTagCloseEnd != null)
			{
				this.AdjustFlagsAndWidth(tTagCloseEnd);
				this.tTagCloseEnd = tTagCloseEnd;
			}
	    }
	
	    public HtmlTagEmptyGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tTagCloseEnd, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTagStart != null)
			{
				this.AdjustFlagsAndWidth(tTagStart);
				this.tTagStart = tTagStart;
			}
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlTagName != null)
			{
				this.AdjustFlagsAndWidth(htmlTagName);
				this.htmlTagName = htmlTagName;
			}
			if (htmlAttribute != null)
			{
				this.AdjustFlagsAndWidth(htmlAttribute);
				this.htmlAttribute = htmlAttribute;
			}
			if (trailingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(trailingWhitespace);
				this.trailingWhitespace = trailingWhitespace;
			}
			if (tTagCloseEnd != null)
			{
				this.AdjustFlagsAndWidth(tTagCloseEnd);
				this.tTagCloseEnd = tTagCloseEnd;
			}
	    }
	
		public override int SlotCount { get { return 6; } }
	
	    public InternalSyntaxToken TTagStart { get { return this.tTagStart; } }
	    public WhitespaceListGreen LeadingWhitespace { get { return this.leadingWhitespace; } }
	    public HtmlTagNameGreen HtmlTagName { get { return this.htmlTagName; } }
	    public InternalSyntaxNodeList HtmlAttribute { get { return this.htmlAttribute; } }
	    public WhitespaceListGreen TrailingWhitespace { get { return this.trailingWhitespace; } }
	    public InternalSyntaxToken TTagCloseEnd { get { return this.tTagCloseEnd; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlTagEmptySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTagStart;
	            case 1: return this.leadingWhitespace;
	            case 2: return this.htmlTagName;
	            case 3: return this.htmlAttribute;
	            case 4: return this.trailingWhitespace;
	            case 5: return this.tTagCloseEnd;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlTagEmptyGreen(this.Kind, this.tTagStart, this.leadingWhitespace, this.htmlTagName, this.htmlAttribute, this.trailingWhitespace, this.tTagCloseEnd, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlTagEmptyGreen(this.Kind, this.tTagStart, this.leadingWhitespace, this.htmlTagName, this.htmlAttribute, this.trailingWhitespace, this.tTagCloseEnd, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlTagEmptyGreen Update(InternalSyntaxToken tTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tTagCloseEnd)
	    {
	        if (this.tTagStart != tTagStart ||
				this.leadingWhitespace != leadingWhitespace ||
				this.htmlTagName != htmlTagName ||
				this.htmlAttribute != htmlAttribute ||
				this.trailingWhitespace != trailingWhitespace ||
				this.tTagCloseEnd != tTagCloseEnd)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTagEmpty(tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagCloseEnd);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagEmptyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal abstract class HtmlAttributeGreen : MediaWikiGreenNode
	{
	
	    public HtmlAttributeGreen(MediaWikiSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
	    }
	}
	
	internal class HtmlAttributeWithValueGreen : HtmlAttributeGreen
	{
	    private WhitespaceListGreen leadingWhitespace;
	    private HtmlAttributeNameGreen htmlAttributeName;
	    private WhitespaceListGreen whitespaceBeforeEquals;
	    private InternalSyntaxToken tAttributeEquals;
	    private WhitespaceListGreen whitespaceAfterEquals;
	    private HtmlAttributeValueGreen htmlAttributeValue;
	
	    public HtmlAttributeWithValueGreen(MediaWikiSyntaxKind kind, WhitespaceListGreen leadingWhitespace, HtmlAttributeNameGreen htmlAttributeName, WhitespaceListGreen whitespaceBeforeEquals, InternalSyntaxToken tAttributeEquals, WhitespaceListGreen whitespaceAfterEquals, HtmlAttributeValueGreen htmlAttributeValue)
	        : base(kind, null, null)
	    {
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlAttributeName != null)
			{
				this.AdjustFlagsAndWidth(htmlAttributeName);
				this.htmlAttributeName = htmlAttributeName;
			}
			if (whitespaceBeforeEquals != null)
			{
				this.AdjustFlagsAndWidth(whitespaceBeforeEquals);
				this.whitespaceBeforeEquals = whitespaceBeforeEquals;
			}
			if (tAttributeEquals != null)
			{
				this.AdjustFlagsAndWidth(tAttributeEquals);
				this.tAttributeEquals = tAttributeEquals;
			}
			if (whitespaceAfterEquals != null)
			{
				this.AdjustFlagsAndWidth(whitespaceAfterEquals);
				this.whitespaceAfterEquals = whitespaceAfterEquals;
			}
			if (htmlAttributeValue != null)
			{
				this.AdjustFlagsAndWidth(htmlAttributeValue);
				this.htmlAttributeValue = htmlAttributeValue;
			}
	    }
	
	    public HtmlAttributeWithValueGreen(MediaWikiSyntaxKind kind, WhitespaceListGreen leadingWhitespace, HtmlAttributeNameGreen htmlAttributeName, WhitespaceListGreen whitespaceBeforeEquals, InternalSyntaxToken tAttributeEquals, WhitespaceListGreen whitespaceAfterEquals, HtmlAttributeValueGreen htmlAttributeValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlAttributeName != null)
			{
				this.AdjustFlagsAndWidth(htmlAttributeName);
				this.htmlAttributeName = htmlAttributeName;
			}
			if (whitespaceBeforeEquals != null)
			{
				this.AdjustFlagsAndWidth(whitespaceBeforeEquals);
				this.whitespaceBeforeEquals = whitespaceBeforeEquals;
			}
			if (tAttributeEquals != null)
			{
				this.AdjustFlagsAndWidth(tAttributeEquals);
				this.tAttributeEquals = tAttributeEquals;
			}
			if (whitespaceAfterEquals != null)
			{
				this.AdjustFlagsAndWidth(whitespaceAfterEquals);
				this.whitespaceAfterEquals = whitespaceAfterEquals;
			}
			if (htmlAttributeValue != null)
			{
				this.AdjustFlagsAndWidth(htmlAttributeValue);
				this.htmlAttributeValue = htmlAttributeValue;
			}
	    }
	
		public override int SlotCount { get { return 6; } }
	
	    public WhitespaceListGreen LeadingWhitespace { get { return this.leadingWhitespace; } }
	    public HtmlAttributeNameGreen HtmlAttributeName { get { return this.htmlAttributeName; } }
	    public WhitespaceListGreen WhitespaceBeforeEquals { get { return this.whitespaceBeforeEquals; } }
	    public InternalSyntaxToken TAttributeEquals { get { return this.tAttributeEquals; } }
	    public WhitespaceListGreen WhitespaceAfterEquals { get { return this.whitespaceAfterEquals; } }
	    public HtmlAttributeValueGreen HtmlAttributeValue { get { return this.htmlAttributeValue; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlAttributeWithValueSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingWhitespace;
	            case 1: return this.htmlAttributeName;
	            case 2: return this.whitespaceBeforeEquals;
	            case 3: return this.tAttributeEquals;
	            case 4: return this.whitespaceAfterEquals;
	            case 5: return this.htmlAttributeValue;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlAttributeWithValueGreen(this.Kind, this.leadingWhitespace, this.htmlAttributeName, this.whitespaceBeforeEquals, this.tAttributeEquals, this.whitespaceAfterEquals, this.htmlAttributeValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlAttributeWithValueGreen(this.Kind, this.leadingWhitespace, this.htmlAttributeName, this.whitespaceBeforeEquals, this.tAttributeEquals, this.whitespaceAfterEquals, this.htmlAttributeValue, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlAttributeWithValueGreen Update(WhitespaceListGreen leadingWhitespace, HtmlAttributeNameGreen htmlAttributeName, WhitespaceListGreen whitespaceBeforeEquals, InternalSyntaxToken tAttributeEquals, WhitespaceListGreen whitespaceAfterEquals, HtmlAttributeValueGreen htmlAttributeValue)
	    {
	        if (this.leadingWhitespace != leadingWhitespace ||
				this.htmlAttributeName != htmlAttributeName ||
				this.whitespaceBeforeEquals != whitespaceBeforeEquals ||
				this.tAttributeEquals != tAttributeEquals ||
				this.whitespaceAfterEquals != whitespaceAfterEquals ||
				this.htmlAttributeValue != htmlAttributeValue)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlAttributeWithValue(leadingWhitespace, htmlAttributeName, whitespaceBeforeEquals, tAttributeEquals, whitespaceAfterEquals, htmlAttributeValue);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlAttributeWithValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlAttributeWithNoValueGreen : HtmlAttributeGreen
	{
	    private WhitespaceListGreen leadingWhitespace;
	    private HtmlAttributeNameGreen htmlAttributeName;
	
	    public HtmlAttributeWithNoValueGreen(MediaWikiSyntaxKind kind, WhitespaceListGreen leadingWhitespace, HtmlAttributeNameGreen htmlAttributeName)
	        : base(kind, null, null)
	    {
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlAttributeName != null)
			{
				this.AdjustFlagsAndWidth(htmlAttributeName);
				this.htmlAttributeName = htmlAttributeName;
			}
	    }
	
	    public HtmlAttributeWithNoValueGreen(MediaWikiSyntaxKind kind, WhitespaceListGreen leadingWhitespace, HtmlAttributeNameGreen htmlAttributeName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (leadingWhitespace != null)
			{
				this.AdjustFlagsAndWidth(leadingWhitespace);
				this.leadingWhitespace = leadingWhitespace;
			}
			if (htmlAttributeName != null)
			{
				this.AdjustFlagsAndWidth(htmlAttributeName);
				this.htmlAttributeName = htmlAttributeName;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public WhitespaceListGreen LeadingWhitespace { get { return this.leadingWhitespace; } }
	    public HtmlAttributeNameGreen HtmlAttributeName { get { return this.htmlAttributeName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlAttributeWithNoValueSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.leadingWhitespace;
	            case 1: return this.htmlAttributeName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlAttributeWithNoValueGreen(this.Kind, this.leadingWhitespace, this.htmlAttributeName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlAttributeWithNoValueGreen(this.Kind, this.leadingWhitespace, this.htmlAttributeName, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlAttributeWithNoValueGreen Update(WhitespaceListGreen leadingWhitespace, HtmlAttributeNameGreen htmlAttributeName)
	    {
	        if (this.leadingWhitespace != leadingWhitespace ||
				this.htmlAttributeName != htmlAttributeName)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlAttributeWithNoValue(leadingWhitespace, htmlAttributeName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlAttributeWithNoValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlAttributeNameGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTagName;
	
	    public HtmlAttributeNameGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTagName)
	        : base(kind, null, null)
	    {
			if (tTagName != null)
			{
				this.AdjustFlagsAndWidth(tTagName);
				this.tTagName = tTagName;
			}
	    }
	
	    public HtmlAttributeNameGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTagName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTagName != null)
			{
				this.AdjustFlagsAndWidth(tTagName);
				this.tTagName = tTagName;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TTagName { get { return this.tTagName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlAttributeNameSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTagName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlAttributeNameGreen(this.Kind, this.tTagName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlAttributeNameGreen(this.Kind, this.tTagName, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlAttributeNameGreen Update(InternalSyntaxToken tTagName)
	    {
	        if (this.tTagName != tTagName)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlAttributeName(tTagName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlAttributeNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlAttributeValueGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tAttributeValue;
	
	    public HtmlAttributeValueGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tAttributeValue)
	        : base(kind, null, null)
	    {
			if (tAttributeValue != null)
			{
				this.AdjustFlagsAndWidth(tAttributeValue);
				this.tAttributeValue = tAttributeValue;
			}
	    }
	
	    public HtmlAttributeValueGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tAttributeValue, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tAttributeValue != null)
			{
				this.AdjustFlagsAndWidth(tAttributeValue);
				this.tAttributeValue = tAttributeValue;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TAttributeValue { get { return this.tAttributeValue; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlAttributeValueSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tAttributeValue;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlAttributeValueGreen(this.Kind, this.tAttributeValue, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlAttributeValueGreen(this.Kind, this.tAttributeValue, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlAttributeValueGreen Update(InternalSyntaxToken tAttributeValue)
	    {
	        if (this.tAttributeValue != tAttributeValue)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlAttributeValue(tAttributeValue);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlAttributeValueGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class HtmlTagNameGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken tTagName;
	
	    public HtmlTagNameGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTagName)
	        : base(kind, null, null)
	    {
			if (tTagName != null)
			{
				this.AdjustFlagsAndWidth(tTagName);
				this.tTagName = tTagName;
			}
	    }
	
	    public HtmlTagNameGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken tTagName, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tTagName != null)
			{
				this.AdjustFlagsAndWidth(tTagName);
				this.tTagName = tTagName;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TTagName { get { return this.tTagName; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.HtmlTagNameSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tTagName;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new HtmlTagNameGreen(this.Kind, this.tTagName, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new HtmlTagNameGreen(this.Kind, this.tTagName, this.GetDiagnostics(), annotations);
	    }
	
	    public HtmlTagNameGreen Update(InternalSyntaxToken tTagName)
	    {
	        if (this.tTagName != tTagName)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.HtmlTagName(tTagName);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HtmlTagNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WhitespaceListGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxNodeList whitespace;
	
	    public WhitespaceListGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList whitespace)
	        : base(kind, null, null)
	    {
			if (whitespace != null)
			{
				this.AdjustFlagsAndWidth(whitespace);
				this.whitespace = whitespace;
			}
	    }
	
	    public WhitespaceListGreen(MediaWikiSyntaxKind kind, InternalSyntaxNodeList whitespace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (whitespace != null)
			{
				this.AdjustFlagsAndWidth(whitespace);
				this.whitespace = whitespace;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxNodeList Whitespace { get { return this.whitespace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WhitespaceListSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.whitespace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WhitespaceListGreen(this.Kind, this.whitespace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WhitespaceListGreen(this.Kind, this.whitespace, this.GetDiagnostics(), annotations);
	    }
	
	    public WhitespaceListGreen Update(InternalSyntaxNodeList whitespace)
	    {
	        if (this.whitespace != whitespace)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.WhitespaceList(whitespace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhitespaceListGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class WhitespaceGreen : MediaWikiGreenNode
	{
	    private InternalSyntaxToken whitespace;
	
	    public WhitespaceGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken whitespace)
	        : base(kind, null, null)
	    {
			if (whitespace != null)
			{
				this.AdjustFlagsAndWidth(whitespace);
				this.whitespace = whitespace;
			}
	    }
	
	    public WhitespaceGreen(MediaWikiSyntaxKind kind, InternalSyntaxToken whitespace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (whitespace != null)
			{
				this.AdjustFlagsAndWidth(whitespace);
				this.whitespace = whitespace;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken Whitespace { get { return this.whitespace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.MediaWiki.Syntax.WhitespaceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.whitespace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new WhitespaceGreen(this.Kind, this.whitespace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new WhitespaceGreen(this.Kind, this.whitespace, this.GetDiagnostics(), annotations);
	    }
	
	    public WhitespaceGreen Update(InternalSyntaxToken whitespace)
	    {
	        if (this.whitespace != whitespace)
	        {
	            GreenNode newNode = MediaWikiLanguage.Instance.InternalSyntaxFactory.Whitespace(whitespace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhitespaceGreen)newNode;
	        }
	        return this;
	    }
	}

	internal class MediaWikiGreenFactory : InternalSyntaxFactory
	{
	    internal static readonly MediaWikiGreenFactory Instance = new MediaWikiGreenFactory();
	
		public new MediaWikiLanguage Language
		{
			get { return MediaWikiLanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
		public MediaWikiGreenTrivia Trivia(MediaWikiSyntaxKind kind, string text)
		{
		    return new MediaWikiGreenTrivia(kind, text, null, null);
		}
	
		public override InternalSyntaxTrivia Trivia(int kind, string text)
		{
		    return new MediaWikiGreenTrivia((MediaWikiSyntaxKind)kind, text, null, null);
		}
	
		public MediaWikiGreenToken MissingToken(MediaWikiSyntaxKind kind)
		{
		    return MediaWikiGreenToken.CreateMissing(kind, null, null);
		}
	
		public override InternalSyntaxToken MissingToken(int kind)
		{
		    return MediaWikiGreenToken.CreateMissing((MediaWikiSyntaxKind)kind, null, null);
		}
	
		public MediaWikiGreenToken MissingToken(GreenNode leading, MediaWikiSyntaxKind kind, GreenNode trailing)
		{
		    return MediaWikiGreenToken.CreateMissing(kind, leading, trailing);
		}
	
		public override InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
		{
		    return MediaWikiGreenToken.CreateMissing((MediaWikiSyntaxKind)kind, leading, trailing);
		}
	
		public MediaWikiGreenToken Token(MediaWikiSyntaxKind kind)
		{
		    return MediaWikiGreenToken.Create(kind);
		}
	
		public override InternalSyntaxToken Token(int kind)
		{
		    return MediaWikiGreenToken.Create((MediaWikiSyntaxKind)kind);
		}
	
	    public MediaWikiGreenToken Token(GreenNode leading, MediaWikiSyntaxKind kind, GreenNode trailing)
		{
		    return MediaWikiGreenToken.Create(kind, leading, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
		{
		    return MediaWikiGreenToken.Create((MediaWikiSyntaxKind)kind, leading, trailing);
		}
	
	    public MediaWikiGreenToken Token(GreenNode leading, MediaWikiSyntaxKind kind, string text, GreenNode trailing)
		{
		    Debug.Assert(MediaWikiLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = MediaWikiLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= MediaWikiGreenToken.FirstTokenWithWellKnownText && kind <= MediaWikiGreenToken.LastTokenWithWellKnownText && text == defaultText
		        ? this.Token(leading, kind, trailing)
		        : MediaWikiGreenToken.WithText(kind, leading, text, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
	    {
	        return this.Token(leading, (MediaWikiSyntaxKind)kind, text, trailing);
	    }
	
	    public MediaWikiGreenToken Token(GreenNode leading, MediaWikiSyntaxKind kind, string text, string valueText, GreenNode trailing)
		{
		    Debug.Assert(MediaWikiLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = MediaWikiLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= MediaWikiGreenToken.FirstTokenWithWellKnownText && kind <= MediaWikiGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(valueText)
		        ? this.Token(leading, kind, trailing)
		        : MediaWikiGreenToken.WithValue(kind, leading, text, valueText, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
	    {
	        return this.Token(leading, (MediaWikiSyntaxKind)kind, text, valueText, trailing);
	    }
	
	    public MediaWikiGreenToken Token(GreenNode leading, MediaWikiSyntaxKind kind, string text, object value, GreenNode trailing)
		{
		    Debug.Assert(MediaWikiLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = MediaWikiLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= MediaWikiGreenToken.FirstTokenWithWellKnownText && kind <= MediaWikiGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
		        ? this.Token(leading, kind, trailing)
		        : MediaWikiGreenToken.WithValue(kind, leading, text, value, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
	    {
	        return this.Token(leading, (MediaWikiSyntaxKind)kind, text, value, trailing);
	    }
	
	    public MediaWikiGreenToken BadToken(GreenNode leading, string text, GreenNode trailing)
		{
		    return MediaWikiGreenToken.WithText(MediaWikiSyntaxKind.BadToken, leading, text, trailing);
		}
	
	
	    internal MediaWikiGreenToken THorizontalLine(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.THorizontalLine, text, null);
	    }
	
	    internal MediaWikiGreenToken THorizontalLine(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.THorizontalLine, text, value, null);
	    }
	
	    internal MediaWikiGreenToken THeading(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.THeading, text, null);
	    }
	
	    internal MediaWikiGreenToken THeading(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.THeading, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TDefinitionStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TDefinitionStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TDefinitionStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TDefinitionStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TListStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TListStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TListStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TListStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TTableStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTableStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TTableStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTableStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TFormat(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TFormat, text, null);
	    }
	
	    internal MediaWikiGreenToken TFormat(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TFormat, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TLinkStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TLinkStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TLinkStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TLinkStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TExternalLinkStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TExternalLinkStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TExternalLinkStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TExternalLinkStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TTemplateParamStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTemplateParamStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TTemplateParamStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTemplateParamStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TTemplateStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTemplateStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TTemplateStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTemplateStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken THtmlComment(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.THtmlComment, text, null);
	    }
	
	    internal MediaWikiGreenToken THtmlComment(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.THtmlComment, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TNoWiki(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TNoWiki, text, null);
	    }
	
	    internal MediaWikiGreenToken TNoWiki(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TNoWiki, text, value, null);
	    }
	
	    internal MediaWikiGreenToken THtmlScript(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.THtmlScript, text, null);
	    }
	
	    internal MediaWikiGreenToken THtmlScript(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.THtmlScript, text, value, null);
	    }
	
	    internal MediaWikiGreenToken THtmlStyle(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.THtmlStyle, text, null);
	    }
	
	    internal MediaWikiGreenToken THtmlStyle(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.THtmlStyle, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TEndTagStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TEndTagStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TEndTagStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TEndTagStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TTagStart(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTagStart, text, null);
	    }
	
	    internal MediaWikiGreenToken TTagStart(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTagStart, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TNormalText(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TNormalText, text, null);
	    }
	
	    internal MediaWikiGreenToken TNormalText(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TNormalText, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TComma(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TComma, text, null);
	    }
	
	    internal MediaWikiGreenToken TComma(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TComma, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TWhiteSpace(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TWhiteSpace, text, null);
	    }
	
	    internal MediaWikiGreenToken TWhiteSpace(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TWhiteSpace, text, value, null);
	    }
	
	    internal MediaWikiGreenToken UTF8BOM(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.UTF8BOM, text, null);
	    }
	
	    internal MediaWikiGreenToken UTF8BOM(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.UTF8BOM, text, value, null);
	    }
	
	    internal MediaWikiGreenToken CRLF(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.CRLF, text, null);
	    }
	
	    internal MediaWikiGreenToken CRLF(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.CRLF, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TBar(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TBar, text, null);
	    }
	
	    internal MediaWikiGreenToken TBar(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TBar, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TApos(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TApos, text, null);
	    }
	
	    internal MediaWikiGreenToken TApos(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TApos, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TSpecialChars(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TSpecialChars, text, null);
	    }
	
	    internal MediaWikiGreenToken TSpecialChars(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TSpecialChars, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TEntityRef(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TEntityRef, text, null);
	    }
	
	    internal MediaWikiGreenToken TEntityRef(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TEntityRef, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TCharRef(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TCharRef, text, null);
	    }
	
	    internal MediaWikiGreenToken TCharRef(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TCharRef, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TTagEnd(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTagEnd, text, null);
	    }
	
	    internal MediaWikiGreenToken TTagEnd(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTagEnd, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TTagName(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTagName, text, null);
	    }
	
	    internal MediaWikiGreenToken TTagName(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TTagName, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TAttributeValue(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TAttributeValue, text, null);
	    }
	
	    internal MediaWikiGreenToken TAttributeValue(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TAttributeValue, text, value, null);
	    }
	
	    internal MediaWikiGreenToken TEndTagEnd(string text)
	    {
	        return Token(null, MediaWikiSyntaxKind.TEndTagEnd, text, null);
	    }
	
	    internal MediaWikiGreenToken TEndTagEnd(string text, object value)
	    {
	        return Token(null, MediaWikiSyntaxKind.TEndTagEnd, text, value, null);
	    }
	
		public MainGreen Main(InternalSyntaxNodeList specialBlockOrParagraph, InternalSyntaxToken eof, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (eof == null) throw new ArgumentNullException(nameof(eof));
				if (eof.RawKind != (int)MediaWikiSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.Main, specialBlockOrParagraph, eof, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(MediaWikiSyntaxKind.Main, specialBlockOrParagraph, eof);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SpecialBlockOrParagraphGreen SpecialBlockOrParagraph(SpecialBlockWithCommentGreen specialBlockWithComment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (specialBlockWithComment == null) throw new ArgumentNullException(nameof(specialBlockWithComment));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.SpecialBlockOrParagraph, specialBlockWithComment, out hash);
			if (cached != null) return (SpecialBlockOrParagraphGreen)cached;
			var result = new SpecialBlockOrParagraphGreen(MediaWikiSyntaxKind.SpecialBlockOrParagraph, specialBlockWithComment, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SpecialBlockOrParagraphGreen SpecialBlockOrParagraph(ParagraphGreen paragraph, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (paragraph == null) throw new ArgumentNullException(nameof(paragraph));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.SpecialBlockOrParagraph, paragraph, out hash);
			if (cached != null) return (SpecialBlockOrParagraphGreen)cached;
			var result = new SpecialBlockOrParagraphGreen(MediaWikiSyntaxKind.SpecialBlockOrParagraph, null, paragraph);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SpecialBlockWithCommentGreen SpecialBlockWithComment(HtmlCommentListGreen leadingComment, SpecialBlockGreen specialBlock, HtmlCommentListGreen trailingComment, InternalSyntaxToken crlf, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
				if (specialBlock == null) throw new ArgumentNullException(nameof(specialBlock));
				if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
	        return new SpecialBlockWithCommentGreen(MediaWikiSyntaxKind.SpecialBlockWithComment, leadingComment, specialBlock, trailingComment, crlf);
	    }
	
		public SpecialBlockGreen SpecialBlock(HeadingGreen heading, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (heading == null) throw new ArgumentNullException(nameof(heading));
			}
	#endif
			return new SpecialBlockGreen(MediaWikiSyntaxKind.SpecialBlock, heading, null, null, null, null);
	    }
	
		public SpecialBlockGreen SpecialBlock(HorizontalRuleGreen horizontalRule, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (horizontalRule == null) throw new ArgumentNullException(nameof(horizontalRule));
			}
	#endif
			return new SpecialBlockGreen(MediaWikiSyntaxKind.SpecialBlock, null, horizontalRule, null, null, null);
	    }
	
		public SpecialBlockGreen SpecialBlock(CodeBlockGreen codeBlock, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (codeBlock == null) throw new ArgumentNullException(nameof(codeBlock));
			}
	#endif
			return new SpecialBlockGreen(MediaWikiSyntaxKind.SpecialBlock, null, null, codeBlock, null, null);
	    }
	
		public SpecialBlockGreen SpecialBlock(WikiListGreen wikiList, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (wikiList == null) throw new ArgumentNullException(nameof(wikiList));
			}
	#endif
			return new SpecialBlockGreen(MediaWikiSyntaxKind.SpecialBlock, null, null, null, wikiList, null);
	    }
	
		public SpecialBlockGreen SpecialBlock(WikiTableGreen wikiTable, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (wikiTable == null) throw new ArgumentNullException(nameof(wikiTable));
			}
	#endif
			return new SpecialBlockGreen(MediaWikiSyntaxKind.SpecialBlock, null, null, null, null, wikiTable);
	    }
	
		public HeadingGreen Heading(HeadingLevelGreen headingStart, HeadingTextGreen headingText, HeadingLevelGreen headingEnd, InlineTextGreen inlineText, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (headingStart == null) throw new ArgumentNullException(nameof(headingStart));
				if (headingText == null) throw new ArgumentNullException(nameof(headingText));
				if (headingEnd == null) throw new ArgumentNullException(nameof(headingEnd));
			}
	#endif
	        return new HeadingGreen(MediaWikiSyntaxKind.Heading, headingStart, headingText, headingEnd, inlineText);
	    }
	
		public HeadingLevelGreen HeadingLevel(InternalSyntaxToken tHeading, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tHeading == null) throw new ArgumentNullException(nameof(tHeading));
				if (tHeading.RawKind != (int)MediaWikiSyntaxKind.THeading) throw new ArgumentException(nameof(tHeading));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HeadingLevel, tHeading, out hash);
			if (cached != null) return (HeadingLevelGreen)cached;
			var result = new HeadingLevelGreen(MediaWikiSyntaxKind.HeadingLevel, tHeading);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HorizontalRuleGreen HorizontalRule(InternalSyntaxToken tHorizontalLine, InlineTextGreen inlineText, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tHorizontalLine == null) throw new ArgumentNullException(nameof(tHorizontalLine));
				if (tHorizontalLine.RawKind != (int)MediaWikiSyntaxKind.THorizontalLine) throw new ArgumentException(nameof(tHorizontalLine));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HorizontalRule, tHorizontalLine, inlineText, out hash);
			if (cached != null) return (HorizontalRuleGreen)cached;
			var result = new HorizontalRuleGreen(MediaWikiSyntaxKind.HorizontalRule, tHorizontalLine, inlineText);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CodeBlockGreen CodeBlock(InternalSeparatedSyntaxNodeList spaceBlock, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.CodeBlock, spaceBlock, out hash);
			if (cached != null) return (CodeBlockGreen)cached;
			var result = new CodeBlockGreen(MediaWikiSyntaxKind.CodeBlock, spaceBlock);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public SpaceBlockGreen SpaceBlock(InternalSyntaxToken tSpaceBlockStart, InlineTextGreen inlineText, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSpaceBlockStart == null) throw new ArgumentNullException(nameof(tSpaceBlockStart));
				if (tSpaceBlockStart.RawKind != (int)MediaWikiSyntaxKind.TSpaceBlockStart) throw new ArgumentException(nameof(tSpaceBlockStart));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.SpaceBlock, tSpaceBlockStart, inlineText, out hash);
			if (cached != null) return (SpaceBlockGreen)cached;
			var result = new SpaceBlockGreen(MediaWikiSyntaxKind.SpaceBlock, tSpaceBlockStart, inlineText);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WikiListGreen WikiList(InternalSeparatedSyntaxNodeList listItem, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.WikiList, listItem, out hash);
			if (cached != null) return (WikiListGreen)cached;
			var result = new WikiListGreen(MediaWikiSyntaxKind.WikiList, listItem);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ListItemGreen ListItem(NormalListItemGreen normalListItem, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (normalListItem == null) throw new ArgumentNullException(nameof(normalListItem));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.ListItem, normalListItem, out hash);
			if (cached != null) return (ListItemGreen)cached;
			var result = new ListItemGreen(MediaWikiSyntaxKind.ListItem, normalListItem, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ListItemGreen ListItem(DefinitionItemGreen definitionItem, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (definitionItem == null) throw new ArgumentNullException(nameof(definitionItem));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.ListItem, definitionItem, out hash);
			if (cached != null) return (ListItemGreen)cached;
			var result = new ListItemGreen(MediaWikiSyntaxKind.ListItem, null, definitionItem);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NormalListItemGreen NormalListItem(InternalSyntaxToken tListStart, InlineTextGreen inlineText, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tListStart == null) throw new ArgumentNullException(nameof(tListStart));
				if (tListStart.RawKind != (int)MediaWikiSyntaxKind.TListStart) throw new ArgumentException(nameof(tListStart));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.NormalListItem, tListStart, inlineText, out hash);
			if (cached != null) return (NormalListItemGreen)cached;
			var result = new NormalListItemGreen(MediaWikiSyntaxKind.NormalListItem, tListStart, inlineText);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DefinitionItemGreen DefinitionItem(InternalSyntaxToken tDefinitionStart, DefinitionTextGreen definitionText, InternalSyntaxToken tColon, InlineTextGreen inlineText, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tDefinitionStart == null) throw new ArgumentNullException(nameof(tDefinitionStart));
				if (tDefinitionStart.RawKind != (int)MediaWikiSyntaxKind.TDefinitionStart) throw new ArgumentException(nameof(tDefinitionStart));
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)MediaWikiSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (inlineText == null) throw new ArgumentNullException(nameof(inlineText));
			}
	#endif
	        return new DefinitionItemGreen(MediaWikiSyntaxKind.DefinitionItem, tDefinitionStart, definitionText, tColon, inlineText);
	    }
	
		public WikiTableGreen WikiTable(InternalSyntaxToken tTableStart, InlineTextGreen leadingInlineText, InternalSyntaxToken crlf, TableCaptionGreen tableCaption, TableRowsGreen tableRows, InternalSyntaxToken tTableEnd, InlineTextGreen trailingInlineText, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTableStart == null) throw new ArgumentNullException(nameof(tTableStart));
				if (tTableStart.RawKind != (int)MediaWikiSyntaxKind.TTableStart) throw new ArgumentException(nameof(tTableStart));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
				if (tableRows == null) throw new ArgumentNullException(nameof(tableRows));
				if (tTableEnd == null) throw new ArgumentNullException(nameof(tTableEnd));
				if (tTableEnd.RawKind != (int)MediaWikiSyntaxKind.TTableEnd) throw new ArgumentException(nameof(tTableEnd));
			}
	#endif
	        return new WikiTableGreen(MediaWikiSyntaxKind.WikiTable, tTableStart, leadingInlineText, crlf, tableCaption, tableRows, tTableEnd, trailingInlineText);
	    }
	
		public TableCaptionGreen TableCaption(InternalSyntaxToken tTableCaptionStart, InlineTextGreen inlineText, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTableCaptionStart == null) throw new ArgumentNullException(nameof(tTableCaptionStart));
				if (tTableCaptionStart.RawKind != (int)MediaWikiSyntaxKind.TTableCaptionStart) throw new ArgumentException(nameof(tTableCaptionStart));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
	        return new TableCaptionGreen(MediaWikiSyntaxKind.TableCaption, tTableCaptionStart, inlineText, crlf, specialBlockOrParagraph);
	    }
	
		public TableRowsGreen TableRows(TableFirstRowGreen tableFirstRow, InternalSyntaxNodeList tableNonFirstRow, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tableFirstRow == null) throw new ArgumentNullException(nameof(tableFirstRow));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.TableRows, tableFirstRow, tableNonFirstRow, out hash);
			if (cached != null) return (TableRowsGreen)cached;
			var result = new TableRowsGreen(MediaWikiSyntaxKind.TableRows, tableFirstRow, tableNonFirstRow);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TableFirstRowGreen TableFirstRow(TableRowStartGreen tableRowStart, TableRowGreen tableRow, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tableRow == null) throw new ArgumentNullException(nameof(tableRow));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.TableFirstRow, tableRowStart, tableRow, out hash);
			if (cached != null) return (TableFirstRowGreen)cached;
			var result = new TableFirstRowGreen(MediaWikiSyntaxKind.TableFirstRow, tableRowStart, tableRow);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TableNonFirstRowGreen TableNonFirstRow(TableRowStartGreen tableRowStart, TableRowGreen tableRow, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tableRowStart == null) throw new ArgumentNullException(nameof(tableRowStart));
				if (tableRow == null) throw new ArgumentNullException(nameof(tableRow));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.TableNonFirstRow, tableRowStart, tableRow, out hash);
			if (cached != null) return (TableNonFirstRowGreen)cached;
			var result = new TableNonFirstRowGreen(MediaWikiSyntaxKind.TableNonFirstRow, tableRowStart, tableRow);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TableRowStartGreen TableRowStart(InternalSyntaxToken tTableRowStart, InlineTextGreen inlineText, InternalSyntaxToken crlf, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTableRowStart == null) throw new ArgumentNullException(nameof(tTableRowStart));
				if (tTableRowStart.RawKind != (int)MediaWikiSyntaxKind.TTableRowStart) throw new ArgumentException(nameof(tTableRowStart));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.TableRowStart, tTableRowStart, inlineText, crlf, out hash);
			if (cached != null) return (TableRowStartGreen)cached;
			var result = new TableRowStartGreen(MediaWikiSyntaxKind.TableRowStart, tTableRowStart, inlineText, crlf);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TableRowGreen TableRow(InternalSyntaxNodeList tableColumn, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.TableRow, tableColumn, out hash);
			if (cached != null) return (TableRowGreen)cached;
			var result = new TableRowGreen(MediaWikiSyntaxKind.TableRow, tableColumn);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TableColumnGreen TableColumn(TableSingleHeaderCellGreen tableSingleHeaderCell, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (tableSingleHeaderCell == null) throw new ArgumentNullException(nameof(tableSingleHeaderCell));
			}
	#endif
			return new TableColumnGreen(MediaWikiSyntaxKind.TableColumn, tableSingleHeaderCell, null, null, null);
	    }
	
		public TableColumnGreen TableColumn(TableHeaderCellsGreen tableHeaderCells, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (tableHeaderCells == null) throw new ArgumentNullException(nameof(tableHeaderCells));
			}
	#endif
			return new TableColumnGreen(MediaWikiSyntaxKind.TableColumn, null, tableHeaderCells, null, null);
	    }
	
		public TableColumnGreen TableColumn(TableSingleCellGreen tableSingleCell, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (tableSingleCell == null) throw new ArgumentNullException(nameof(tableSingleCell));
			}
	#endif
			return new TableColumnGreen(MediaWikiSyntaxKind.TableColumn, null, null, tableSingleCell, null);
	    }
	
		public TableColumnGreen TableColumn(TableCellsGreen tableCells, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (tableCells == null) throw new ArgumentNullException(nameof(tableCells));
			}
	#endif
			return new TableColumnGreen(MediaWikiSyntaxKind.TableColumn, null, null, null, tableCells);
	    }
	
		public TableSingleHeaderCellGreen TableSingleHeaderCell(InternalSyntaxToken tExclamation, TableCellGreen tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
				if (tExclamation.RawKind != (int)MediaWikiSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
				if (tableCell == null) throw new ArgumentNullException(nameof(tableCell));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
	        return new TableSingleHeaderCellGreen(MediaWikiSyntaxKind.TableSingleHeaderCell, tExclamation, tableCell, crlf, specialBlockOrParagraph);
	    }
	
		public TableHeaderCellsGreen TableHeaderCells(InternalSyntaxToken tExclamation, InternalSeparatedSyntaxNodeList tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
				if (tExclamation.RawKind != (int)MediaWikiSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
	        return new TableHeaderCellsGreen(MediaWikiSyntaxKind.TableHeaderCells, tExclamation, tableCell, crlf, specialBlockOrParagraph);
	    }
	
		public TableSingleCellGreen TableSingleCell(InternalSyntaxToken tBar, TableCellGreen tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tBar == null) throw new ArgumentNullException(nameof(tBar));
				if (tBar.RawKind != (int)MediaWikiSyntaxKind.TBar) throw new ArgumentException(nameof(tBar));
				if (tableCell == null) throw new ArgumentNullException(nameof(tableCell));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
	        return new TableSingleCellGreen(MediaWikiSyntaxKind.TableSingleCell, tBar, tableCell, crlf, specialBlockOrParagraph);
	    }
	
		public TableCellsGreen TableCells(InternalSyntaxToken tBar, InternalSeparatedSyntaxNodeList tableCell, InternalSyntaxToken crlf, InternalSyntaxNodeList specialBlockOrParagraph, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tBar == null) throw new ArgumentNullException(nameof(tBar));
				if (tBar.RawKind != (int)MediaWikiSyntaxKind.TBar) throw new ArgumentException(nameof(tBar));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
	        return new TableCellsGreen(MediaWikiSyntaxKind.TableCells, tBar, tableCell, crlf, specialBlockOrParagraph);
	    }
	
		public TableCellGreen TableCell(CellAttributesGreen cellAttributes, CellTextGreen cellText, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.TableCell, cellAttributes, cellText, out hash);
			if (cached != null) return (TableCellGreen)cached;
			var result = new TableCellGreen(MediaWikiSyntaxKind.TableCell, cellAttributes, cellText);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CellAttributesGreen CellAttributes(CellTextGreen cellText, InternalSyntaxToken tBar, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (cellText == null) throw new ArgumentNullException(nameof(cellText));
				if (tBar == null) throw new ArgumentNullException(nameof(tBar));
				if (tBar.RawKind != (int)MediaWikiSyntaxKind.TBar) throw new ArgumentException(nameof(tBar));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.CellAttributes, cellText, tBar, out hash);
			if (cached != null) return (CellAttributesGreen)cached;
			var result = new CellAttributesGreen(MediaWikiSyntaxKind.CellAttributes, cellText, tBar);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ParagraphGreen Paragraph(InternalSyntaxNodeList textLine, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.Paragraph, textLine, out hash);
			if (cached != null) return (ParagraphGreen)cached;
			var result = new ParagraphGreen(MediaWikiSyntaxKind.Paragraph, textLine);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TextLineInlineElementsWithCommentGreen TextLineInlineElementsWithComment(HtmlCommentListGreen leadingComment, InternalSyntaxNodeList inlineTextElement, HtmlCommentListGreen trailingComment, InternalSyntaxToken crlf, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
				if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
	        return new TextLineInlineElementsWithCommentGreen(MediaWikiSyntaxKind.TextLineInlineElementsWithComment, leadingComment, inlineTextElement, trailingComment, crlf);
	    }
	
		public TextLineCommentGreen TextLineComment(HtmlCommentListGreen htmlCommentList, InternalSyntaxToken crlf, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (htmlCommentList == null) throw new ArgumentNullException(nameof(htmlCommentList));
				if (crlf == null) throw new ArgumentNullException(nameof(crlf));
				if (crlf.RawKind != (int)MediaWikiSyntaxKind.CRLF) throw new ArgumentException(nameof(crlf));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.TextLineComment, htmlCommentList, crlf, out hash);
			if (cached != null) return (TextLineCommentGreen)cached;
			var result = new TextLineCommentGreen(MediaWikiSyntaxKind.TextLineComment, htmlCommentList, crlf);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TextElementsGreen TextElements(WikiFormatGreen wikiFormat, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (wikiFormat == null) throw new ArgumentNullException(nameof(wikiFormat));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, wikiFormat, null, null, null, null, null, null, null, null);
	    }
	
		public TextElementsGreen TextElements(WikiLinkGreen wikiLink, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (wikiLink == null) throw new ArgumentNullException(nameof(wikiLink));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, null, wikiLink, null, null, null, null, null, null, null);
	    }
	
		public TextElementsGreen TextElements(WikiTemplateGreen wikiTemplate, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (wikiTemplate == null) throw new ArgumentNullException(nameof(wikiTemplate));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, null, null, wikiTemplate, null, null, null, null, null, null);
	    }
	
		public TextElementsGreen TextElements(WikiTemplateParamGreen wikiTemplateParam, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (wikiTemplateParam == null) throw new ArgumentNullException(nameof(wikiTemplateParam));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, null, null, null, wikiTemplateParam, null, null, null, null, null);
	    }
	
		public TextElementsGreen TextElements(NoWikiGreen noWiki, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (noWiki == null) throw new ArgumentNullException(nameof(noWiki));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, null, null, null, null, noWiki, null, null, null, null);
	    }
	
		public TextElementsGreen TextElements(HtmlReferenceGreen htmlReference, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (htmlReference == null) throw new ArgumentNullException(nameof(htmlReference));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, null, null, null, null, null, htmlReference, null, null, null);
	    }
	
		public TextElementsGreen TextElements(HtmlStyleGreen htmlStyle, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (htmlStyle == null) throw new ArgumentNullException(nameof(htmlStyle));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, null, null, null, null, null, null, htmlStyle, null, null);
	    }
	
		public TextElementsGreen TextElements(HtmlScriptGreen htmlScript, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (htmlScript == null) throw new ArgumentNullException(nameof(htmlScript));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, null, null, null, null, null, null, null, htmlScript, null);
	    }
	
		public TextElementsGreen TextElements(HtmlTagGreen htmlTag, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (htmlTag == null) throw new ArgumentNullException(nameof(htmlTag));
			}
	#endif
			return new TextElementsGreen(MediaWikiSyntaxKind.TextElements, null, null, null, null, null, null, null, null, htmlTag);
	    }
	
		public InlineTextGreen InlineText(InternalSyntaxNodeList inlineTextElementWithComment, HtmlCommentListGreen trailingComment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.InlineText, inlineTextElementWithComment, trailingComment, out hash);
			if (cached != null) return (InlineTextGreen)cached;
			var result = new InlineTextGreen(MediaWikiSyntaxKind.InlineText, inlineTextElementWithComment, trailingComment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InlineTextElementWithCommentGreen InlineTextElementWithComment(HtmlCommentListGreen leadingComment, InlineTextElementGreen inlineTextElement, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
				if (inlineTextElement == null) throw new ArgumentNullException(nameof(inlineTextElement));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.InlineTextElementWithComment, leadingComment, inlineTextElement, out hash);
			if (cached != null) return (InlineTextElementWithCommentGreen)cached;
			var result = new InlineTextElementWithCommentGreen(MediaWikiSyntaxKind.InlineTextElementWithComment, leadingComment, inlineTextElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InlineTextElementGreen InlineTextElement(TextElementsGreen textElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (textElements == null) throw new ArgumentNullException(nameof(textElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.InlineTextElement, textElements, out hash);
			if (cached != null) return (InlineTextElementGreen)cached;
			var result = new InlineTextElementGreen(MediaWikiSyntaxKind.InlineTextElement, textElements, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InlineTextElementGreen InlineTextElement(InlineTextElementsGreen inlineTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (inlineTextElements == null) throw new ArgumentNullException(nameof(inlineTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.InlineTextElement, inlineTextElements, out hash);
			if (cached != null) return (InlineTextElementGreen)cached;
			var result = new InlineTextElementGreen(MediaWikiSyntaxKind.InlineTextElement, null, inlineTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public InlineTextElementsGreen InlineTextElements(InternalSyntaxToken inlineTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (inlineTextElements == null) throw new ArgumentNullException(nameof(inlineTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.InlineTextElements, inlineTextElements, out hash);
			if (cached != null) return (InlineTextElementsGreen)cached;
			var result = new InlineTextElementsGreen(MediaWikiSyntaxKind.InlineTextElements, inlineTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DefinitionTextGreen DefinitionText(InternalSyntaxNodeList definitionTextElementWithComment, HtmlCommentListGreen trailingComment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.DefinitionText, definitionTextElementWithComment, trailingComment, out hash);
			if (cached != null) return (DefinitionTextGreen)cached;
			var result = new DefinitionTextGreen(MediaWikiSyntaxKind.DefinitionText, definitionTextElementWithComment, trailingComment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DefinitionTextElementWithCommentGreen DefinitionTextElementWithComment(HtmlCommentListGreen leadingComment, DefinitionTextElementGreen definitionTextElement, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
				if (definitionTextElement == null) throw new ArgumentNullException(nameof(definitionTextElement));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.DefinitionTextElementWithComment, leadingComment, definitionTextElement, out hash);
			if (cached != null) return (DefinitionTextElementWithCommentGreen)cached;
			var result = new DefinitionTextElementWithCommentGreen(MediaWikiSyntaxKind.DefinitionTextElementWithComment, leadingComment, definitionTextElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DefinitionTextElementGreen DefinitionTextElement(TextElementsGreen textElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (textElements == null) throw new ArgumentNullException(nameof(textElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.DefinitionTextElement, textElements, out hash);
			if (cached != null) return (DefinitionTextElementGreen)cached;
			var result = new DefinitionTextElementGreen(MediaWikiSyntaxKind.DefinitionTextElement, textElements, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DefinitionTextElementGreen DefinitionTextElement(DefinitionTextElementsGreen definitionTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (definitionTextElements == null) throw new ArgumentNullException(nameof(definitionTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.DefinitionTextElement, definitionTextElements, out hash);
			if (cached != null) return (DefinitionTextElementGreen)cached;
			var result = new DefinitionTextElementGreen(MediaWikiSyntaxKind.DefinitionTextElement, null, definitionTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DefinitionTextElementsGreen DefinitionTextElements(InternalSyntaxToken definitionTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (definitionTextElements == null) throw new ArgumentNullException(nameof(definitionTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.DefinitionTextElements, definitionTextElements, out hash);
			if (cached != null) return (DefinitionTextElementsGreen)cached;
			var result = new DefinitionTextElementsGreen(MediaWikiSyntaxKind.DefinitionTextElements, definitionTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HeadingTextGreen HeadingText(InternalSyntaxNodeList headingTextWithComment, HtmlCommentListGreen trailingComment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HeadingText, headingTextWithComment, trailingComment, out hash);
			if (cached != null) return (HeadingTextGreen)cached;
			var result = new HeadingTextGreen(MediaWikiSyntaxKind.HeadingText, headingTextWithComment, trailingComment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HeadingTextWithCommentGreen HeadingTextWithComment(HtmlCommentListGreen leadingComment, HeadingTextElementGreen headingTextElement, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
				if (headingTextElement == null) throw new ArgumentNullException(nameof(headingTextElement));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HeadingTextWithComment, leadingComment, headingTextElement, out hash);
			if (cached != null) return (HeadingTextWithCommentGreen)cached;
			var result = new HeadingTextWithCommentGreen(MediaWikiSyntaxKind.HeadingTextWithComment, leadingComment, headingTextElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HeadingTextElementGreen HeadingTextElement(TextElementsGreen textElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (textElements == null) throw new ArgumentNullException(nameof(textElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HeadingTextElement, textElements, out hash);
			if (cached != null) return (HeadingTextElementGreen)cached;
			var result = new HeadingTextElementGreen(MediaWikiSyntaxKind.HeadingTextElement, textElements, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HeadingTextElementGreen HeadingTextElement(HeadingTextElementsGreen headingTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (headingTextElements == null) throw new ArgumentNullException(nameof(headingTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HeadingTextElement, headingTextElements, out hash);
			if (cached != null) return (HeadingTextElementGreen)cached;
			var result = new HeadingTextElementGreen(MediaWikiSyntaxKind.HeadingTextElement, null, headingTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HeadingTextElementsGreen HeadingTextElements(InternalSyntaxToken headingTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (headingTextElements == null) throw new ArgumentNullException(nameof(headingTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HeadingTextElements, headingTextElements, out hash);
			if (cached != null) return (HeadingTextElementsGreen)cached;
			var result = new HeadingTextElementsGreen(MediaWikiSyntaxKind.HeadingTextElements, headingTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CellTextGreen CellText(InternalSyntaxNodeList cellTextElementWithComment, HtmlCommentListGreen trailingComment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.CellText, cellTextElementWithComment, trailingComment, out hash);
			if (cached != null) return (CellTextGreen)cached;
			var result = new CellTextGreen(MediaWikiSyntaxKind.CellText, cellTextElementWithComment, trailingComment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CellTextElementWithCommentGreen CellTextElementWithComment(HtmlCommentListGreen leadingComment, CellTextElementGreen cellTextElement, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
				if (cellTextElement == null) throw new ArgumentNullException(nameof(cellTextElement));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.CellTextElementWithComment, leadingComment, cellTextElement, out hash);
			if (cached != null) return (CellTextElementWithCommentGreen)cached;
			var result = new CellTextElementWithCommentGreen(MediaWikiSyntaxKind.CellTextElementWithComment, leadingComment, cellTextElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CellTextElementGreen CellTextElement(TextElementsGreen textElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (textElements == null) throw new ArgumentNullException(nameof(textElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.CellTextElement, textElements, out hash);
			if (cached != null) return (CellTextElementGreen)cached;
			var result = new CellTextElementGreen(MediaWikiSyntaxKind.CellTextElement, textElements, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CellTextElementGreen CellTextElement(CellTextElementsGreen cellTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (cellTextElements == null) throw new ArgumentNullException(nameof(cellTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.CellTextElement, cellTextElements, out hash);
			if (cached != null) return (CellTextElementGreen)cached;
			var result = new CellTextElementGreen(MediaWikiSyntaxKind.CellTextElement, null, cellTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public CellTextElementsGreen CellTextElements(InternalSyntaxToken cellTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (cellTextElements == null) throw new ArgumentNullException(nameof(cellTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.CellTextElements, cellTextElements, out hash);
			if (cached != null) return (CellTextElementsGreen)cached;
			var result = new CellTextElementsGreen(MediaWikiSyntaxKind.CellTextElements, cellTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LinkTextGreen LinkText(InternalSyntaxNodeList linkTextWithComment, HtmlCommentListGreen trailingComment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (trailingComment == null) throw new ArgumentNullException(nameof(trailingComment));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.LinkText, linkTextWithComment, trailingComment, out hash);
			if (cached != null) return (LinkTextGreen)cached;
			var result = new LinkTextGreen(MediaWikiSyntaxKind.LinkText, linkTextWithComment, trailingComment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LinkTextWithCommentGreen LinkTextWithComment(HtmlCommentListGreen leadingComment, LinkTextElementGreen linkTextElement, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingComment == null) throw new ArgumentNullException(nameof(leadingComment));
				if (linkTextElement == null) throw new ArgumentNullException(nameof(linkTextElement));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.LinkTextWithComment, leadingComment, linkTextElement, out hash);
			if (cached != null) return (LinkTextWithCommentGreen)cached;
			var result = new LinkTextWithCommentGreen(MediaWikiSyntaxKind.LinkTextWithComment, leadingComment, linkTextElement);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LinkTextElementGreen LinkTextElement(TextElementsGreen textElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (textElements == null) throw new ArgumentNullException(nameof(textElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.LinkTextElement, textElements, out hash);
			if (cached != null) return (LinkTextElementGreen)cached;
			var result = new LinkTextElementGreen(MediaWikiSyntaxKind.LinkTextElement, textElements, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LinkTextElementGreen LinkTextElement(LinkTextElementsGreen linkTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (linkTextElements == null) throw new ArgumentNullException(nameof(linkTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.LinkTextElement, linkTextElements, out hash);
			if (cached != null) return (LinkTextElementGreen)cached;
			var result = new LinkTextElementGreen(MediaWikiSyntaxKind.LinkTextElement, null, linkTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LinkTextElementsGreen LinkTextElements(InternalSyntaxToken linkTextElements, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (linkTextElements == null) throw new ArgumentNullException(nameof(linkTextElements));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.LinkTextElements, linkTextElements, out hash);
			if (cached != null) return (LinkTextElementsGreen)cached;
			var result = new LinkTextElementsGreen(MediaWikiSyntaxKind.LinkTextElements, linkTextElements);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WikiFormatGreen WikiFormat(InternalSyntaxToken tFormat, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tFormat == null) throw new ArgumentNullException(nameof(tFormat));
				if (tFormat.RawKind != (int)MediaWikiSyntaxKind.TFormat) throw new ArgumentException(nameof(tFormat));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.WikiFormat, tFormat, out hash);
			if (cached != null) return (WikiFormatGreen)cached;
			var result = new WikiFormatGreen(MediaWikiSyntaxKind.WikiFormat, tFormat);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WikiLinkGreen WikiLink(WikiInternalLinkGreen wikiInternalLink, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (wikiInternalLink == null) throw new ArgumentNullException(nameof(wikiInternalLink));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.WikiLink, wikiInternalLink, out hash);
			if (cached != null) return (WikiLinkGreen)cached;
			var result = new WikiLinkGreen(MediaWikiSyntaxKind.WikiLink, wikiInternalLink, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WikiLinkGreen WikiLink(WikiExternalLinkGreen wikiExternalLink, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (wikiExternalLink == null) throw new ArgumentNullException(nameof(wikiExternalLink));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.WikiLink, wikiExternalLink, out hash);
			if (cached != null) return (WikiLinkGreen)cached;
			var result = new WikiLinkGreen(MediaWikiSyntaxKind.WikiLink, null, wikiExternalLink);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WikiInternalLinkGreen WikiInternalLink(InternalSyntaxToken tLinkStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tLinkEnd, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tLinkStart == null) throw new ArgumentNullException(nameof(tLinkStart));
				if (tLinkStart.RawKind != (int)MediaWikiSyntaxKind.TLinkStart) throw new ArgumentException(nameof(tLinkStart));
				if (linkText == null) throw new ArgumentNullException(nameof(linkText));
				if (tLinkEnd == null) throw new ArgumentNullException(nameof(tLinkEnd));
				if (tLinkEnd.RawKind != (int)MediaWikiSyntaxKind.TLinkEnd) throw new ArgumentException(nameof(tLinkEnd));
			}
	#endif
	        return new WikiInternalLinkGreen(MediaWikiSyntaxKind.WikiInternalLink, tLinkStart, linkText, linkTextPart, tLinkEnd);
	    }
	
		public WikiExternalLinkGreen WikiExternalLink(InternalSyntaxToken tExternalLinkStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tExternalLinkEnd, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tExternalLinkStart == null) throw new ArgumentNullException(nameof(tExternalLinkStart));
				if (tExternalLinkStart.RawKind != (int)MediaWikiSyntaxKind.TExternalLinkStart) throw new ArgumentException(nameof(tExternalLinkStart));
				if (linkText == null) throw new ArgumentNullException(nameof(linkText));
				if (tExternalLinkEnd == null) throw new ArgumentNullException(nameof(tExternalLinkEnd));
				if (tExternalLinkEnd.RawKind != (int)MediaWikiSyntaxKind.TExternalLinkEnd) throw new ArgumentException(nameof(tExternalLinkEnd));
			}
	#endif
	        return new WikiExternalLinkGreen(MediaWikiSyntaxKind.WikiExternalLink, tExternalLinkStart, linkText, linkTextPart, tExternalLinkEnd);
	    }
	
		public WikiTemplateGreen WikiTemplate(InternalSyntaxToken tTemplateStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tTemplateEnd, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTemplateStart == null) throw new ArgumentNullException(nameof(tTemplateStart));
				if (tTemplateStart.RawKind != (int)MediaWikiSyntaxKind.TTemplateStart) throw new ArgumentException(nameof(tTemplateStart));
				if (linkText == null) throw new ArgumentNullException(nameof(linkText));
				if (tTemplateEnd == null) throw new ArgumentNullException(nameof(tTemplateEnd));
				if (tTemplateEnd.RawKind != (int)MediaWikiSyntaxKind.TTemplateEnd) throw new ArgumentException(nameof(tTemplateEnd));
			}
	#endif
	        return new WikiTemplateGreen(MediaWikiSyntaxKind.WikiTemplate, tTemplateStart, linkText, linkTextPart, tTemplateEnd);
	    }
	
		public WikiTemplateParamGreen WikiTemplateParam(InternalSyntaxToken tTemplateParamStart, LinkTextGreen linkText, InternalSyntaxNodeList linkTextPart, InternalSyntaxToken tTemplateParamEnd, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTemplateParamStart == null) throw new ArgumentNullException(nameof(tTemplateParamStart));
				if (tTemplateParamStart.RawKind != (int)MediaWikiSyntaxKind.TTemplateParamStart) throw new ArgumentException(nameof(tTemplateParamStart));
				if (linkText == null) throw new ArgumentNullException(nameof(linkText));
				if (tTemplateParamEnd == null) throw new ArgumentNullException(nameof(tTemplateParamEnd));
				if (tTemplateParamEnd.RawKind != (int)MediaWikiSyntaxKind.TTemplateParamEnd) throw new ArgumentException(nameof(tTemplateParamEnd));
			}
	#endif
	        return new WikiTemplateParamGreen(MediaWikiSyntaxKind.WikiTemplateParam, tTemplateParamStart, linkText, linkTextPart, tTemplateParamEnd);
	    }
	
		public NoWikiGreen NoWiki(InternalSyntaxToken tNoWiki, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tNoWiki == null) throw new ArgumentNullException(nameof(tNoWiki));
				if (tNoWiki.RawKind != (int)MediaWikiSyntaxKind.TNoWiki) throw new ArgumentException(nameof(tNoWiki));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.NoWiki, tNoWiki, out hash);
			if (cached != null) return (NoWikiGreen)cached;
			var result = new NoWikiGreen(MediaWikiSyntaxKind.NoWiki, tNoWiki);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public BarOrBarBarGreen BarOrBarBar(InternalSyntaxToken barOrBarBar, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (barOrBarBar == null) throw new ArgumentNullException(nameof(barOrBarBar));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.BarOrBarBar, barOrBarBar, out hash);
			if (cached != null) return (BarOrBarBarGreen)cached;
			var result = new BarOrBarBarGreen(MediaWikiSyntaxKind.BarOrBarBar, barOrBarBar);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LinkTextPartGreen LinkTextPart(BarOrBarBarGreen barOrBarBar, LinkTextGreen linkText, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (barOrBarBar == null) throw new ArgumentNullException(nameof(barOrBarBar));
				if (linkText == null) throw new ArgumentNullException(nameof(linkText));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.LinkTextPart, barOrBarBar, linkText, out hash);
			if (cached != null) return (LinkTextPartGreen)cached;
			var result = new LinkTextPartGreen(MediaWikiSyntaxKind.LinkTextPart, barOrBarBar, linkText);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlReferenceGreen HtmlReference(InternalSyntaxToken htmlReference, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (htmlReference == null) throw new ArgumentNullException(nameof(htmlReference));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlReference, htmlReference, out hash);
			if (cached != null) return (HtmlReferenceGreen)cached;
			var result = new HtmlReferenceGreen(MediaWikiSyntaxKind.HtmlReference, htmlReference);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlCommentListGreen HtmlCommentList(InternalSyntaxNodeList htmlComment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlCommentList, htmlComment, out hash);
			if (cached != null) return (HtmlCommentListGreen)cached;
			var result = new HtmlCommentListGreen(MediaWikiSyntaxKind.HtmlCommentList, htmlComment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlCommentGreen HtmlComment(InternalSyntaxToken tHtmlComment, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tHtmlComment == null) throw new ArgumentNullException(nameof(tHtmlComment));
				if (tHtmlComment.RawKind != (int)MediaWikiSyntaxKind.THtmlComment) throw new ArgumentException(nameof(tHtmlComment));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlComment, tHtmlComment, out hash);
			if (cached != null) return (HtmlCommentGreen)cached;
			var result = new HtmlCommentGreen(MediaWikiSyntaxKind.HtmlComment, tHtmlComment);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlStyleGreen HtmlStyle(InternalSyntaxToken tHtmlStyle, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tHtmlStyle == null) throw new ArgumentNullException(nameof(tHtmlStyle));
				if (tHtmlStyle.RawKind != (int)MediaWikiSyntaxKind.THtmlStyle) throw new ArgumentException(nameof(tHtmlStyle));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlStyle, tHtmlStyle, out hash);
			if (cached != null) return (HtmlStyleGreen)cached;
			var result = new HtmlStyleGreen(MediaWikiSyntaxKind.HtmlStyle, tHtmlStyle);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlScriptGreen HtmlScript(InternalSyntaxToken tHtmlScript, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tHtmlScript == null) throw new ArgumentNullException(nameof(tHtmlScript));
				if (tHtmlScript.RawKind != (int)MediaWikiSyntaxKind.THtmlScript) throw new ArgumentException(nameof(tHtmlScript));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlScript, tHtmlScript, out hash);
			if (cached != null) return (HtmlScriptGreen)cached;
			var result = new HtmlScriptGreen(MediaWikiSyntaxKind.HtmlScript, tHtmlScript);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlTagGreen HtmlTag(HtmlTagOpenGreen htmlTagOpen, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (htmlTagOpen == null) throw new ArgumentNullException(nameof(htmlTagOpen));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlTag, htmlTagOpen, out hash);
			if (cached != null) return (HtmlTagGreen)cached;
			var result = new HtmlTagGreen(MediaWikiSyntaxKind.HtmlTag, htmlTagOpen, null, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlTagGreen HtmlTag(HtmlTagCloseGreen htmlTagClose, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (htmlTagClose == null) throw new ArgumentNullException(nameof(htmlTagClose));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlTag, htmlTagClose, out hash);
			if (cached != null) return (HtmlTagGreen)cached;
			var result = new HtmlTagGreen(MediaWikiSyntaxKind.HtmlTag, null, htmlTagClose, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlTagGreen HtmlTag(HtmlTagEmptyGreen htmlTagEmpty, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (htmlTagEmpty == null) throw new ArgumentNullException(nameof(htmlTagEmpty));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlTag, htmlTagEmpty, out hash);
			if (cached != null) return (HtmlTagGreen)cached;
			var result = new HtmlTagGreen(MediaWikiSyntaxKind.HtmlTag, null, null, htmlTagEmpty);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlTagOpenGreen HtmlTagOpen(InternalSyntaxToken tTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tTagEnd, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTagStart == null) throw new ArgumentNullException(nameof(tTagStart));
				if (tTagStart.RawKind != (int)MediaWikiSyntaxKind.TTagStart) throw new ArgumentException(nameof(tTagStart));
				if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
				if (htmlTagName == null) throw new ArgumentNullException(nameof(htmlTagName));
				if (trailingWhitespace == null) throw new ArgumentNullException(nameof(trailingWhitespace));
				if (tTagEnd == null) throw new ArgumentNullException(nameof(tTagEnd));
				if (tTagEnd.RawKind != (int)MediaWikiSyntaxKind.TTagEnd) throw new ArgumentException(nameof(tTagEnd));
			}
	#endif
	        return new HtmlTagOpenGreen(MediaWikiSyntaxKind.HtmlTagOpen, tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagEnd);
	    }
	
		public HtmlTagCloseGreen HtmlTagClose(InternalSyntaxToken tEndTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tEndTagEnd, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tEndTagStart == null) throw new ArgumentNullException(nameof(tEndTagStart));
				if (tEndTagStart.RawKind != (int)MediaWikiSyntaxKind.TEndTagStart) throw new ArgumentException(nameof(tEndTagStart));
				if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
				if (htmlTagName == null) throw new ArgumentNullException(nameof(htmlTagName));
				if (trailingWhitespace == null) throw new ArgumentNullException(nameof(trailingWhitespace));
				if (tEndTagEnd == null) throw new ArgumentNullException(nameof(tEndTagEnd));
				if (tEndTagEnd.RawKind != (int)MediaWikiSyntaxKind.TEndTagEnd) throw new ArgumentException(nameof(tEndTagEnd));
			}
	#endif
	        return new HtmlTagCloseGreen(MediaWikiSyntaxKind.HtmlTagClose, tEndTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tEndTagEnd);
	    }
	
		public HtmlTagEmptyGreen HtmlTagEmpty(InternalSyntaxToken tTagStart, WhitespaceListGreen leadingWhitespace, HtmlTagNameGreen htmlTagName, InternalSyntaxNodeList htmlAttribute, WhitespaceListGreen trailingWhitespace, InternalSyntaxToken tTagCloseEnd, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTagStart == null) throw new ArgumentNullException(nameof(tTagStart));
				if (tTagStart.RawKind != (int)MediaWikiSyntaxKind.TTagStart) throw new ArgumentException(nameof(tTagStart));
				if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
				if (htmlTagName == null) throw new ArgumentNullException(nameof(htmlTagName));
				if (trailingWhitespace == null) throw new ArgumentNullException(nameof(trailingWhitespace));
				if (tTagCloseEnd == null) throw new ArgumentNullException(nameof(tTagCloseEnd));
				if (tTagCloseEnd.RawKind != (int)MediaWikiSyntaxKind.TTagCloseEnd) throw new ArgumentException(nameof(tTagCloseEnd));
			}
	#endif
	        return new HtmlTagEmptyGreen(MediaWikiSyntaxKind.HtmlTagEmpty, tTagStart, leadingWhitespace, htmlTagName, htmlAttribute, trailingWhitespace, tTagCloseEnd);
	    }
	
		public HtmlAttributeWithValueGreen HtmlAttributeWithValue(WhitespaceListGreen leadingWhitespace, HtmlAttributeNameGreen htmlAttributeName, WhitespaceListGreen whitespaceBeforeEquals, InternalSyntaxToken tAttributeEquals, WhitespaceListGreen whitespaceAfterEquals, HtmlAttributeValueGreen htmlAttributeValue, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
				if (htmlAttributeName == null) throw new ArgumentNullException(nameof(htmlAttributeName));
				if (whitespaceBeforeEquals == null) throw new ArgumentNullException(nameof(whitespaceBeforeEquals));
				if (tAttributeEquals == null) throw new ArgumentNullException(nameof(tAttributeEquals));
				if (tAttributeEquals.RawKind != (int)MediaWikiSyntaxKind.TAttributeEquals) throw new ArgumentException(nameof(tAttributeEquals));
				if (whitespaceAfterEquals == null) throw new ArgumentNullException(nameof(whitespaceAfterEquals));
				if (htmlAttributeValue == null) throw new ArgumentNullException(nameof(htmlAttributeValue));
			}
	#endif
	        return new HtmlAttributeWithValueGreen(MediaWikiSyntaxKind.HtmlAttributeWithValue, leadingWhitespace, htmlAttributeName, whitespaceBeforeEquals, tAttributeEquals, whitespaceAfterEquals, htmlAttributeValue);
	    }
	
		public HtmlAttributeWithNoValueGreen HtmlAttributeWithNoValue(WhitespaceListGreen leadingWhitespace, HtmlAttributeNameGreen htmlAttributeName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (leadingWhitespace == null) throw new ArgumentNullException(nameof(leadingWhitespace));
				if (htmlAttributeName == null) throw new ArgumentNullException(nameof(htmlAttributeName));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlAttributeWithNoValue, leadingWhitespace, htmlAttributeName, out hash);
			if (cached != null) return (HtmlAttributeWithNoValueGreen)cached;
			var result = new HtmlAttributeWithNoValueGreen(MediaWikiSyntaxKind.HtmlAttributeWithNoValue, leadingWhitespace, htmlAttributeName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlAttributeNameGreen HtmlAttributeName(InternalSyntaxToken tTagName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTagName == null) throw new ArgumentNullException(nameof(tTagName));
				if (tTagName.RawKind != (int)MediaWikiSyntaxKind.TTagName) throw new ArgumentException(nameof(tTagName));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlAttributeName, tTagName, out hash);
			if (cached != null) return (HtmlAttributeNameGreen)cached;
			var result = new HtmlAttributeNameGreen(MediaWikiSyntaxKind.HtmlAttributeName, tTagName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlAttributeValueGreen HtmlAttributeValue(InternalSyntaxToken tAttributeValue, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tAttributeValue == null) throw new ArgumentNullException(nameof(tAttributeValue));
				if (tAttributeValue.RawKind != (int)MediaWikiSyntaxKind.TAttributeValue) throw new ArgumentException(nameof(tAttributeValue));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlAttributeValue, tAttributeValue, out hash);
			if (cached != null) return (HtmlAttributeValueGreen)cached;
			var result = new HtmlAttributeValueGreen(MediaWikiSyntaxKind.HtmlAttributeValue, tAttributeValue);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public HtmlTagNameGreen HtmlTagName(InternalSyntaxToken tTagName, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tTagName == null) throw new ArgumentNullException(nameof(tTagName));
				if (tTagName.RawKind != (int)MediaWikiSyntaxKind.TTagName) throw new ArgumentException(nameof(tTagName));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.HtmlTagName, tTagName, out hash);
			if (cached != null) return (HtmlTagNameGreen)cached;
			var result = new HtmlTagNameGreen(MediaWikiSyntaxKind.HtmlTagName, tTagName);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WhitespaceListGreen WhitespaceList(InternalSyntaxNodeList whitespace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.WhitespaceList, whitespace, out hash);
			if (cached != null) return (WhitespaceListGreen)cached;
			var result = new WhitespaceListGreen(MediaWikiSyntaxKind.WhitespaceList, whitespace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public WhitespaceGreen Whitespace(InternalSyntaxToken whitespace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (whitespace == null) throw new ArgumentNullException(nameof(whitespace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)MediaWikiSyntaxKind.Whitespace, whitespace, out hash);
			if (cached != null) return (WhitespaceGreen)cached;
			var result = new WhitespaceGreen(MediaWikiSyntaxKind.Whitespace, whitespace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
	    internal IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainGreen),
				typeof(SpecialBlockOrParagraphGreen),
				typeof(SpecialBlockWithCommentGreen),
				typeof(SpecialBlockGreen),
				typeof(HeadingGreen),
				typeof(HeadingLevelGreen),
				typeof(HorizontalRuleGreen),
				typeof(CodeBlockGreen),
				typeof(SpaceBlockGreen),
				typeof(WikiListGreen),
				typeof(ListItemGreen),
				typeof(NormalListItemGreen),
				typeof(DefinitionItemGreen),
				typeof(WikiTableGreen),
				typeof(TableCaptionGreen),
				typeof(TableRowsGreen),
				typeof(TableFirstRowGreen),
				typeof(TableNonFirstRowGreen),
				typeof(TableRowStartGreen),
				typeof(TableRowGreen),
				typeof(TableColumnGreen),
				typeof(TableSingleHeaderCellGreen),
				typeof(TableHeaderCellsGreen),
				typeof(TableSingleCellGreen),
				typeof(TableCellsGreen),
				typeof(TableCellGreen),
				typeof(CellAttributesGreen),
				typeof(ParagraphGreen),
				typeof(TextLineInlineElementsWithCommentGreen),
				typeof(TextLineCommentGreen),
				typeof(TextElementsGreen),
				typeof(InlineTextGreen),
				typeof(InlineTextElementWithCommentGreen),
				typeof(InlineTextElementGreen),
				typeof(InlineTextElementsGreen),
				typeof(DefinitionTextGreen),
				typeof(DefinitionTextElementWithCommentGreen),
				typeof(DefinitionTextElementGreen),
				typeof(DefinitionTextElementsGreen),
				typeof(HeadingTextGreen),
				typeof(HeadingTextWithCommentGreen),
				typeof(HeadingTextElementGreen),
				typeof(HeadingTextElementsGreen),
				typeof(CellTextGreen),
				typeof(CellTextElementWithCommentGreen),
				typeof(CellTextElementGreen),
				typeof(CellTextElementsGreen),
				typeof(LinkTextGreen),
				typeof(LinkTextWithCommentGreen),
				typeof(LinkTextElementGreen),
				typeof(LinkTextElementsGreen),
				typeof(WikiFormatGreen),
				typeof(WikiLinkGreen),
				typeof(WikiInternalLinkGreen),
				typeof(WikiExternalLinkGreen),
				typeof(WikiTemplateGreen),
				typeof(WikiTemplateParamGreen),
				typeof(NoWikiGreen),
				typeof(BarOrBarBarGreen),
				typeof(LinkTextPartGreen),
				typeof(HtmlReferenceGreen),
				typeof(HtmlCommentListGreen),
				typeof(HtmlCommentGreen),
				typeof(HtmlStyleGreen),
				typeof(HtmlScriptGreen),
				typeof(HtmlTagGreen),
				typeof(HtmlTagOpenGreen),
				typeof(HtmlTagCloseGreen),
				typeof(HtmlTagEmptyGreen),
				typeof(HtmlAttributeWithValueGreen),
				typeof(HtmlAttributeWithNoValueGreen),
				typeof(HtmlAttributeNameGreen),
				typeof(HtmlAttributeValueGreen),
				typeof(HtmlTagNameGreen),
				typeof(WhitespaceListGreen),
				typeof(WhitespaceGreen),
			};
		}
	}
}

