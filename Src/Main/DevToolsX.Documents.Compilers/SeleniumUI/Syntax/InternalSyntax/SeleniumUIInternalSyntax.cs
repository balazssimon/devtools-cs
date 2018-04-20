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

namespace DevToolsX.Documents.Compilers.SeleniumUI.Syntax.InternalSyntax
{
    internal abstract class SeleniumUIGreenNode : InternalSyntaxNode
    {
        public SeleniumUIGreenNode(SeleniumUISyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, 0, diagnostics, annotations)
        {
        }

        public SeleniumUISyntaxKind Kind
        {
            get { return (SeleniumUISyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return SeleniumUILanguage.Instance; }
        }
    }

    internal class SeleniumUIGreenTrivia : InternalSyntaxTrivia
    {
        public SeleniumUIGreenTrivia(SeleniumUISyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, text, diagnostics, annotations)
        {
        }

        public SeleniumUISyntaxKind Kind
        {
            get { return (SeleniumUISyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return SeleniumUILanguage.Instance; }
        }

        public override SyntaxTrivia CreateRed(SyntaxToken parent, int position, int index)
        {
            return new SeleniumUISyntaxTrivia(this, parent, position, index);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new SeleniumUIGreenTrivia(this.Kind, this.Text, diagnostics, this.GetAnnotations());
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new SeleniumUIGreenTrivia(this.Kind, this.Text, this.GetDiagnostics(), annotations);
        }
    }

	public class SeleniumUIGreenToken : InternalSyntaxToken
	{
		public SeleniumUIGreenToken(SeleniumUISyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
		    : base((int)kind, diagnostics, annotations)
		{
		}
	
	    public SeleniumUIGreenToken(SeleniumUISyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base((int)kind, fullWidth, diagnostics, annotations)
	    {
	    }
	
	    public SeleniumUISyntaxKind Kind
		{
		    get { return (SeleniumUISyntaxKind)base.RawKind; }
		}
	
		public virtual SeleniumUISyntaxKind ContextualKind
		{
		    get { return this.Kind; }
		}
	
	    public override string Text
	    {
	        get
	        {
	            return SeleniumUILanguage.Instance.SyntaxFacts.GetText(this.Kind);
	        }
	    }
	
	    public override Language Language
	    {
	        get { return SeleniumUILanguage.Instance; }
	    }
	
	    public override SyntaxToken CreateRed(SyntaxNode parent, int position, int index)
	    {
	        return new SeleniumUISyntaxToken(this, parent, position, index);
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
	        return new SeleniumUIGreenToken(this.Kind, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SeleniumUIGreenToken(this.Kind, diagnostics, this.GetAnnotations());
	    }
	
	    internal static SeleniumUIGreenToken Create(SeleniumUISyntaxKind kind)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!SeleniumUILanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid token kind '{0}'. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	
	            return CreateMissing(kind, null, null);
	        }
	
	        return s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	    }
	
	    internal static SeleniumUIGreenToken Create(SeleniumUISyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!SeleniumUILanguage.Instance.SyntaxFacts.IsToken(kind))
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
	            else if (trailing == SeleniumUILanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	            else if (trailing == SeleniumUILanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	        }
	
	        if (leading == SeleniumUILanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == SeleniumUILanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	        }
	
	        return new SyntaxTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static SeleniumUIGreenToken CreateMissing(SeleniumUISyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static readonly SeleniumUISyntaxKind FirstTokenWithWellKnownText = SeleniumUISyntaxKind.KParent;
	    internal static readonly SeleniumUISyntaxKind LastTokenWithWellKnownText = SeleniumUISyntaxKind.LComment_Star;
	
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly SeleniumUIGreenToken[] s_tokensWithNoTrivia = new SeleniumUIGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SeleniumUIGreenToken[] s_tokensWithElasticTrivia = new SeleniumUIGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SeleniumUIGreenToken[] s_tokensWithSingleTrailingSpace = new SeleniumUIGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SeleniumUIGreenToken[] s_tokensWithSingleTrailingCRLF = new SeleniumUIGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	
	    static SeleniumUIGreenToken()
	    {
	        for (var kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SeleniumUIGreenToken(kind, null, null);
	            s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, SeleniumUILanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, SeleniumUILanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, null, null);
	            s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, SeleniumUILanguage.Instance.InternalSyntaxFactory.Space, null, null);
	            s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, SeleniumUILanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed, null, null);
	        }
	    }
	
	    internal static IEnumerable<SeleniumUIGreenToken> GetWellKnownTokens()
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
	
	    internal static SeleniumUIGreenToken WithText(SeleniumUISyntaxKind kind, string text)
	    {
	        return new SyntaxTokenWithText(kind, text, null, null);
	    }
	
	    internal static SeleniumUIGreenToken WithText(SeleniumUISyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	
	    internal static SeleniumUIGreenToken WithText(SeleniumUISyntaxKind kind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (valueText == text)
	        {
	            return WithText(kind, leading, text, trailing);
	        }
	
	        return new SyntaxTokenWithTextAndTrivia(kind, text, valueText, leading, trailing, null, null);
	    }
	
	    internal static SeleniumUIGreenToken WithValue<T>(SeleniumUISyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value, null, null);
	    }
	
	    internal static SeleniumUIGreenToken WithValue<T>(SeleniumUISyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing, null, null);
	    }
	
	    private class SyntaxTokenWithTrivia : SeleniumUIGreenToken
	    {
	        protected readonly GreenNode LeadingField;
	        protected readonly GreenNode TrailingField;
	
	        internal SyntaxTokenWithTrivia(SeleniumUISyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal MissingTokenWithTrivia(SeleniumUISyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	    private class SyntaxTokenWithText : SeleniumUIGreenToken
	    {
	        protected readonly string TextField;
	
	        internal SyntaxTokenWithText(SeleniumUISyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	        internal SyntaxIdentifierExtended(SeleniumUISyntaxKind kind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	        internal SyntaxTokenWithTextAndTrailingTrivia(SeleniumUISyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            SeleniumUISyntaxKind kind,
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
	
	    private class SyntaxTokenWithValue<T> : SeleniumUIGreenToken
	    {
	        protected readonly string TextField;
	        protected readonly T ValueField;
	
	        internal SyntaxTokenWithValue(SeleniumUISyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            SeleniumUISyntaxKind kind,
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
	
	internal class MainGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxNodeList _namespace;
	    private InternalSyntaxToken eof;
	
	    public MainGreen(SeleniumUISyntaxKind kind, InternalSyntaxNodeList _namespace, InternalSyntaxToken eof)
	        : base(kind, null, null)
	    {
			if (_namespace != null)
			{
				this.AdjustFlagsAndWidth(_namespace);
				this._namespace = _namespace;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
	    public MainGreen(SeleniumUISyntaxKind kind, InternalSyntaxNodeList _namespace, InternalSyntaxToken eof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (_namespace != null)
			{
				this.AdjustFlagsAndWidth(_namespace);
				this._namespace = _namespace;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxNodeList Namespace { get { return this._namespace; } }
	    public InternalSyntaxToken Eof { get { return this.eof; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.MainSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this._namespace;
	            case 1: return this.eof;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this._namespace, this.eof, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this._namespace, this.eof, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(InternalSyntaxNodeList _namespace, InternalSyntaxToken eof)
	    {
	        if (this._namespace != _namespace ||
				this.eof != eof)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Main(_namespace, eof);
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
	
	internal class NamespaceGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken kNamespace;
	    private QualifiedNameGreen qualifiedName;
	    private NamespaceBodyGreen namespaceBody;
	
	    public NamespaceGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
	        : base(kind, null, null)
	    {
			if (kNamespace != null)
			{
				this.AdjustFlagsAndWidth(kNamespace);
				this.kNamespace = kNamespace;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
	    public NamespaceGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kNamespace != null)
			{
				this.AdjustFlagsAndWidth(kNamespace);
				this.kNamespace = kNamespace;
			}
			if (qualifiedName != null)
			{
				this.AdjustFlagsAndWidth(qualifiedName);
				this.qualifiedName = qualifiedName;
			}
			if (namespaceBody != null)
			{
				this.AdjustFlagsAndWidth(namespaceBody);
				this.namespaceBody = namespaceBody;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KNamespace { get { return this.kNamespace; } }
	    public QualifiedNameGreen QualifiedName { get { return this.qualifiedName; } }
	    public NamespaceBodyGreen NamespaceBody { get { return this.namespaceBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.NamespaceSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kNamespace;
	            case 1: return this.qualifiedName;
	            case 2: return this.namespaceBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceGreen(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceGreen(this.Kind, this.kNamespace, this.qualifiedName, this.namespaceBody, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceGreen Update(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody)
	    {
	        if (this.kNamespace != kNamespace ||
				this.qualifiedName != qualifiedName ||
				this.namespaceBody != namespaceBody)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Namespace(kNamespace, qualifiedName, namespaceBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NamespaceBodyGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList declaration;
	    private InternalSyntaxToken tCloseBrace;
	
	    public NamespaceBodyGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration != null)
			{
				this.AdjustFlagsAndWidth(declaration);
				this.declaration = declaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public NamespaceBodyGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (declaration != null)
			{
				this.AdjustFlagsAndWidth(declaration);
				this.declaration = declaration;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList Declaration { get { return this.declaration; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.NamespaceBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.declaration;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.declaration, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NamespaceBodyGreen(this.Kind, this.tOpenBrace, this.declaration, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public NamespaceBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.declaration != declaration ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class DeclarationGreen : SeleniumUIGreenNode
	{
	    private TagGreen tag;
	    private PageGreen page;
	
	    public DeclarationGreen(SeleniumUISyntaxKind kind, TagGreen tag, PageGreen page)
	        : base(kind, null, null)
	    {
			if (tag != null)
			{
				this.AdjustFlagsAndWidth(tag);
				this.tag = tag;
			}
			if (page != null)
			{
				this.AdjustFlagsAndWidth(page);
				this.page = page;
			}
	    }
	
	    public DeclarationGreen(SeleniumUISyntaxKind kind, TagGreen tag, PageGreen page, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tag != null)
			{
				this.AdjustFlagsAndWidth(tag);
				this.tag = tag;
			}
			if (page != null)
			{
				this.AdjustFlagsAndWidth(page);
				this.page = page;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public TagGreen Tag { get { return this.tag; } }
	    public PageGreen Page { get { return this.page; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.DeclarationSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tag;
	            case 1: return this.page;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new DeclarationGreen(this.Kind, this.tag, this.page, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new DeclarationGreen(this.Kind, this.tag, this.page, this.GetDiagnostics(), annotations);
	    }
	
	    public DeclarationGreen Update(TagGreen tag)
	    {
	        if (this.tag != tag)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Declaration(tag);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationGreen)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationGreen Update(PageGreen page)
	    {
	        if (this.page != page)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Declaration(page);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TagGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken kTag;
	    private NameGreen name;
	    private TypeSpecifierGreen typeSpecifier;
	    private InternalSyntaxToken tSemicolon;
	
	    public TagGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken kTag, NameGreen name, TypeSpecifierGreen typeSpecifier, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (kTag != null)
			{
				this.AdjustFlagsAndWidth(kTag);
				this.kTag = kTag;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (typeSpecifier != null)
			{
				this.AdjustFlagsAndWidth(typeSpecifier);
				this.typeSpecifier = typeSpecifier;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public TagGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken kTag, NameGreen name, TypeSpecifierGreen typeSpecifier, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kTag != null)
			{
				this.AdjustFlagsAndWidth(kTag);
				this.kTag = kTag;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (typeSpecifier != null)
			{
				this.AdjustFlagsAndWidth(typeSpecifier);
				this.typeSpecifier = typeSpecifier;
			}
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken KTag { get { return this.kTag; } }
	    public NameGreen Name { get { return this.name; } }
	    public TypeSpecifierGreen TypeSpecifier { get { return this.typeSpecifier; } }
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.TagSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kTag;
	            case 1: return this.name;
	            case 2: return this.typeSpecifier;
	            case 3: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TagGreen(this.Kind, this.kTag, this.name, this.typeSpecifier, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TagGreen(this.Kind, this.kTag, this.name, this.typeSpecifier, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public TagGreen Update(InternalSyntaxToken kTag, NameGreen name, TypeSpecifierGreen typeSpecifier, InternalSyntaxToken tSemicolon)
	    {
	        if (this.kTag != kTag ||
				this.name != name ||
				this.typeSpecifier != typeSpecifier ||
				this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Tag(kTag, name, typeSpecifier, tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TagGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TypeSpecifierGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken tColon;
	    private QualifierGreen qualifier;
	
	    public TypeSpecifierGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tColon, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public TypeSpecifierGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tColon, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.TypeSpecifierSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tColon;
	            case 1: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TypeSpecifierGreen(this.Kind, this.tColon, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TypeSpecifierGreen(this.Kind, this.tColon, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public TypeSpecifierGreen Update(InternalSyntaxToken tColon, QualifierGreen qualifier)
	    {
	        if (this.tColon != tColon ||
				this.qualifier != qualifier)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.TypeSpecifier(tColon, qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeSpecifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class PageGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken kPage;
	    private NameGreen name;
	    private ElementBodyGreen elementBody;
	
	    public PageGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken kPage, NameGreen name, ElementBodyGreen elementBody)
	        : base(kind, null, null)
	    {
			if (kPage != null)
			{
				this.AdjustFlagsAndWidth(kPage);
				this.kPage = kPage;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (elementBody != null)
			{
				this.AdjustFlagsAndWidth(elementBody);
				this.elementBody = elementBody;
			}
	    }
	
	    public PageGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken kPage, NameGreen name, ElementBodyGreen elementBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kPage != null)
			{
				this.AdjustFlagsAndWidth(kPage);
				this.kPage = kPage;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (elementBody != null)
			{
				this.AdjustFlagsAndWidth(elementBody);
				this.elementBody = elementBody;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken KPage { get { return this.kPage; } }
	    public NameGreen Name { get { return this.name; } }
	    public ElementBodyGreen ElementBody { get { return this.elementBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.PageSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kPage;
	            case 1: return this.name;
	            case 2: return this.elementBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PageGreen(this.Kind, this.kPage, this.name, this.elementBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PageGreen(this.Kind, this.kPage, this.name, this.elementBody, this.GetDiagnostics(), annotations);
	    }
	
	    public PageGreen Update(InternalSyntaxToken kPage, NameGreen name, ElementBodyGreen elementBody)
	    {
	        if (this.kPage != kPage ||
				this.name != name ||
				this.elementBody != elementBody)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Page(kPage, name, elementBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PageGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElementGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken kElement;
	    private NameGreen name;
	    private TagSpecifierGreen tagSpecifier;
	    private LocatorSpecifierGreen locatorSpecifier;
	    private ElementBodyGreen elementBody;
	
	    public ElementGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken kElement, NameGreen name, TagSpecifierGreen tagSpecifier, LocatorSpecifierGreen locatorSpecifier, ElementBodyGreen elementBody)
	        : base(kind, null, null)
	    {
			if (kElement != null)
			{
				this.AdjustFlagsAndWidth(kElement);
				this.kElement = kElement;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tagSpecifier != null)
			{
				this.AdjustFlagsAndWidth(tagSpecifier);
				this.tagSpecifier = tagSpecifier;
			}
			if (locatorSpecifier != null)
			{
				this.AdjustFlagsAndWidth(locatorSpecifier);
				this.locatorSpecifier = locatorSpecifier;
			}
			if (elementBody != null)
			{
				this.AdjustFlagsAndWidth(elementBody);
				this.elementBody = elementBody;
			}
	    }
	
	    public ElementGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken kElement, NameGreen name, TagSpecifierGreen tagSpecifier, LocatorSpecifierGreen locatorSpecifier, ElementBodyGreen elementBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (kElement != null)
			{
				this.AdjustFlagsAndWidth(kElement);
				this.kElement = kElement;
			}
			if (name != null)
			{
				this.AdjustFlagsAndWidth(name);
				this.name = name;
			}
			if (tagSpecifier != null)
			{
				this.AdjustFlagsAndWidth(tagSpecifier);
				this.tagSpecifier = tagSpecifier;
			}
			if (locatorSpecifier != null)
			{
				this.AdjustFlagsAndWidth(locatorSpecifier);
				this.locatorSpecifier = locatorSpecifier;
			}
			if (elementBody != null)
			{
				this.AdjustFlagsAndWidth(elementBody);
				this.elementBody = elementBody;
			}
	    }
	
		public override int SlotCount { get { return 5; } }
	
	    public InternalSyntaxToken KElement { get { return this.kElement; } }
	    public NameGreen Name { get { return this.name; } }
	    public TagSpecifierGreen TagSpecifier { get { return this.tagSpecifier; } }
	    public LocatorSpecifierGreen LocatorSpecifier { get { return this.locatorSpecifier; } }
	    public ElementBodyGreen ElementBody { get { return this.elementBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.ElementSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kElement;
	            case 1: return this.name;
	            case 2: return this.tagSpecifier;
	            case 3: return this.locatorSpecifier;
	            case 4: return this.elementBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElementGreen(this.Kind, this.kElement, this.name, this.tagSpecifier, this.locatorSpecifier, this.elementBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElementGreen(this.Kind, this.kElement, this.name, this.tagSpecifier, this.locatorSpecifier, this.elementBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ElementGreen Update(InternalSyntaxToken kElement, NameGreen name, TagSpecifierGreen tagSpecifier, LocatorSpecifierGreen locatorSpecifier, ElementBodyGreen elementBody)
	    {
	        if (this.kElement != kElement ||
				this.name != name ||
				this.tagSpecifier != tagSpecifier ||
				this.locatorSpecifier != locatorSpecifier ||
				this.elementBody != elementBody)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Element(kElement, name, tagSpecifier, locatorSpecifier, elementBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class TagSpecifierGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken tColon;
	    private QualifierGreen qualifier;
	
	    public TagSpecifierGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tColon, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public TagSpecifierGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tColon, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tColon != null)
			{
				this.AdjustFlagsAndWidth(tColon);
				this.tColon = tColon;
			}
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TColon { get { return this.tColon; } }
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.TagSpecifierSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tColon;
	            case 1: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new TagSpecifierGreen(this.Kind, this.tColon, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new TagSpecifierGreen(this.Kind, this.tColon, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public TagSpecifierGreen Update(InternalSyntaxToken tColon, QualifierGreen qualifier)
	    {
	        if (this.tColon != tColon ||
				this.qualifier != qualifier)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.TagSpecifier(tColon, qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TagSpecifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class LocatorSpecifierGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken tAssign;
	    private StringGreen _string;
	
	    public LocatorSpecifierGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tAssign, StringGreen _string)
	        : base(kind, null, null)
	    {
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (_string != null)
			{
				this.AdjustFlagsAndWidth(_string);
				this._string = _string;
			}
	    }
	
	    public LocatorSpecifierGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tAssign, StringGreen _string, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tAssign != null)
			{
				this.AdjustFlagsAndWidth(tAssign);
				this.tAssign = tAssign;
			}
			if (_string != null)
			{
				this.AdjustFlagsAndWidth(_string);
				this._string = _string;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public InternalSyntaxToken TAssign { get { return this.tAssign; } }
	    public StringGreen String { get { return this._string; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.LocatorSpecifierSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tAssign;
	            case 1: return this._string;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new LocatorSpecifierGreen(this.Kind, this.tAssign, this._string, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new LocatorSpecifierGreen(this.Kind, this.tAssign, this._string, this.GetDiagnostics(), annotations);
	    }
	
	    public LocatorSpecifierGreen Update(InternalSyntaxToken tAssign, StringGreen _string)
	    {
	        if (this.tAssign != tAssign ||
				this._string != _string)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.LocatorSpecifier(tAssign, _string);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LocatorSpecifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ElementBodyGreen : SeleniumUIGreenNode
	{
	    private EmptyElementBodyGreen emptyElementBody;
	    private ChildElementsBodyGreen childElementsBody;
	
	    public ElementBodyGreen(SeleniumUISyntaxKind kind, EmptyElementBodyGreen emptyElementBody, ChildElementsBodyGreen childElementsBody)
	        : base(kind, null, null)
	    {
			if (emptyElementBody != null)
			{
				this.AdjustFlagsAndWidth(emptyElementBody);
				this.emptyElementBody = emptyElementBody;
			}
			if (childElementsBody != null)
			{
				this.AdjustFlagsAndWidth(childElementsBody);
				this.childElementsBody = childElementsBody;
			}
	    }
	
	    public ElementBodyGreen(SeleniumUISyntaxKind kind, EmptyElementBodyGreen emptyElementBody, ChildElementsBodyGreen childElementsBody, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (emptyElementBody != null)
			{
				this.AdjustFlagsAndWidth(emptyElementBody);
				this.emptyElementBody = emptyElementBody;
			}
			if (childElementsBody != null)
			{
				this.AdjustFlagsAndWidth(childElementsBody);
				this.childElementsBody = childElementsBody;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public EmptyElementBodyGreen EmptyElementBody { get { return this.emptyElementBody; } }
	    public ChildElementsBodyGreen ChildElementsBody { get { return this.childElementsBody; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.ElementBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.emptyElementBody;
	            case 1: return this.childElementsBody;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ElementBodyGreen(this.Kind, this.emptyElementBody, this.childElementsBody, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ElementBodyGreen(this.Kind, this.emptyElementBody, this.childElementsBody, this.GetDiagnostics(), annotations);
	    }
	
	    public ElementBodyGreen Update(EmptyElementBodyGreen emptyElementBody)
	    {
	        if (this.emptyElementBody != emptyElementBody)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.ElementBody(emptyElementBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementBodyGreen)newNode;
	        }
	        return this;
	    }
	
	    public ElementBodyGreen Update(ChildElementsBodyGreen childElementsBody)
	    {
	        if (this.childElementsBody != childElementsBody)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.ElementBody(childElementsBody);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class EmptyElementBodyGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken tSemicolon;
	
	    public EmptyElementBodyGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tSemicolon)
	        : base(kind, null, null)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
	    public EmptyElementBodyGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tSemicolon, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tSemicolon != null)
			{
				this.AdjustFlagsAndWidth(tSemicolon);
				this.tSemicolon = tSemicolon;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken TSemicolon { get { return this.tSemicolon; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.EmptyElementBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tSemicolon;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new EmptyElementBodyGreen(this.Kind, this.tSemicolon, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new EmptyElementBodyGreen(this.Kind, this.tSemicolon, this.GetDiagnostics(), annotations);
	    }
	
	    public EmptyElementBodyGreen Update(InternalSyntaxToken tSemicolon)
	    {
	        if (this.tSemicolon != tSemicolon)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.EmptyElementBody(tSemicolon);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EmptyElementBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class ChildElementsBodyGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxNodeList element;
	    private InternalSyntaxToken tCloseBrace;
	
	    public ChildElementsBodyGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList element, InternalSyntaxToken tCloseBrace)
	        : base(kind, null, null)
	    {
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (element != null)
			{
				this.AdjustFlagsAndWidth(element);
				this.element = element;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public ChildElementsBodyGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList element, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (element != null)
			{
				this.AdjustFlagsAndWidth(element);
				this.element = element;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		public override int SlotCount { get { return 3; } }
	
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxNodeList Element { get { return this.element; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.ChildElementsBodySyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.tOpenBrace;
	            case 1: return this.element;
	            case 2: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new ChildElementsBodyGreen(this.Kind, this.tOpenBrace, this.element, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new ChildElementsBodyGreen(this.Kind, this.tOpenBrace, this.element, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public ChildElementsBodyGreen Update(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList element, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.tOpenBrace != tOpenBrace ||
				this.element != element ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.ChildElementsBody(tOpenBrace, element, tCloseBrace);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ChildElementsBodyGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifiedNameGreen : SeleniumUIGreenNode
	{
	    private QualifierGreen qualifier;
	
	    public QualifiedNameGreen(SeleniumUISyntaxKind kind, QualifierGreen qualifier)
	        : base(kind, null, null)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
	    public QualifiedNameGreen(SeleniumUISyntaxKind kind, QualifierGreen qualifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (qualifier != null)
			{
				this.AdjustFlagsAndWidth(qualifier);
				this.qualifier = qualifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public QualifierGreen Qualifier { get { return this.qualifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.QualifiedNameSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.qualifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifiedNameGreen(this.Kind, this.qualifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifiedNameGreen(this.Kind, this.qualifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifiedNameGreen Update(QualifierGreen qualifier)
	    {
	        if (this.qualifier != qualifier)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.QualifiedName(qualifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class NameGreen : SeleniumUIGreenNode
	{
	    private IdentifierGreen identifier;
	
	    public NameGreen(SeleniumUISyntaxKind kind, IdentifierGreen identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(SeleniumUISyntaxKind kind, IdentifierGreen identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public IdentifierGreen Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.NameSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new NameGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new NameGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public NameGreen Update(IdentifierGreen identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Name(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class QualifierGreen : SeleniumUIGreenNode
	{
	    private InternalSeparatedSyntaxNodeList identifier;
	
	    public QualifierGreen(SeleniumUISyntaxKind kind, InternalSeparatedSyntaxNodeList identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public QualifierGreen(SeleniumUISyntaxKind kind, InternalSeparatedSyntaxNodeList identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSeparatedSyntaxNodeList Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.QualifierSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.identifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new QualifierGreen(this.Kind, this.identifier, this.GetDiagnostics(), annotations);
	    }
	
	    public QualifierGreen Update(InternalSeparatedSyntaxNodeList identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Qualifier(identifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class IdentifierGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken lIdentifier;
	
	    public IdentifierGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken lIdentifier)
	        : base(kind, null, null)
	    {
			if (lIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lIdentifier);
				this.lIdentifier = lIdentifier;
			}
	    }
	
	    public IdentifierGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken lIdentifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (lIdentifier != null)
			{
				this.AdjustFlagsAndWidth(lIdentifier);
				this.lIdentifier = lIdentifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken LIdentifier { get { return this.lIdentifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.IdentifierSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.lIdentifier;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new IdentifierGreen(this.Kind, this.lIdentifier, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new IdentifierGreen(this.Kind, this.lIdentifier, this.GetDiagnostics(), annotations);
	    }
	
	    public IdentifierGreen Update(InternalSyntaxToken lIdentifier)
	    {
	        if (this.lIdentifier != lIdentifier)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.Identifier(lIdentifier);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierGreen)newNode;
	        }
	        return this;
	    }
	}
	
	internal class StringGreen : SeleniumUIGreenNode
	{
	    private InternalSyntaxToken _string;
	
	    public StringGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken _string)
	        : base(kind, null, null)
	    {
			if (_string != null)
			{
				this.AdjustFlagsAndWidth(_string);
				this._string = _string;
			}
	    }
	
	    public StringGreen(SeleniumUISyntaxKind kind, InternalSyntaxToken _string, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (_string != null)
			{
				this.AdjustFlagsAndWidth(_string);
				this._string = _string;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken String { get { return this._string; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUI.Syntax.StringSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this._string;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new StringGreen(this.Kind, this._string, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new StringGreen(this.Kind, this._string, this.GetDiagnostics(), annotations);
	    }
	
	    public StringGreen Update(InternalSyntaxToken _string)
	    {
	        if (this._string != _string)
	        {
	            GreenNode newNode = SeleniumUILanguage.Instance.InternalSyntaxFactory.String(_string);
	            var diags = this.GetDiagnostics();
	            if (diags != null && diags.Length > 0)
	               newNode = newNode.WithDiagnostics(diags);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringGreen)newNode;
	        }
	        return this;
	    }
	}

	internal class SeleniumUIGreenFactory : InternalSyntaxFactory
	{
	    internal static readonly SeleniumUIGreenFactory Instance = new SeleniumUIGreenFactory();
	
		public new SeleniumUILanguage Language
		{
			get { return SeleniumUILanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
		public SeleniumUIGreenTrivia Trivia(SeleniumUISyntaxKind kind, string text)
		{
		    return new SeleniumUIGreenTrivia(kind, text, null, null);
		}
	
		public override InternalSyntaxTrivia Trivia(int kind, string text)
		{
		    return new SeleniumUIGreenTrivia((SeleniumUISyntaxKind)kind, text, null, null);
		}
	
		public SeleniumUIGreenToken MissingToken(SeleniumUISyntaxKind kind)
		{
		    return SeleniumUIGreenToken.CreateMissing(kind, null, null);
		}
	
		public override InternalSyntaxToken MissingToken(int kind)
		{
		    return SeleniumUIGreenToken.CreateMissing((SeleniumUISyntaxKind)kind, null, null);
		}
	
		public SeleniumUIGreenToken MissingToken(GreenNode leading, SeleniumUISyntaxKind kind, GreenNode trailing)
		{
		    return SeleniumUIGreenToken.CreateMissing(kind, leading, trailing);
		}
	
		public override InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
		{
		    return SeleniumUIGreenToken.CreateMissing((SeleniumUISyntaxKind)kind, leading, trailing);
		}
	
		public SeleniumUIGreenToken Token(SeleniumUISyntaxKind kind)
		{
		    return SeleniumUIGreenToken.Create(kind);
		}
	
		public override InternalSyntaxToken Token(int kind)
		{
		    return SeleniumUIGreenToken.Create((SeleniumUISyntaxKind)kind);
		}
	
	    public SeleniumUIGreenToken Token(GreenNode leading, SeleniumUISyntaxKind kind, GreenNode trailing)
		{
		    return SeleniumUIGreenToken.Create(kind, leading, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
		{
		    return SeleniumUIGreenToken.Create((SeleniumUISyntaxKind)kind, leading, trailing);
		}
	
	    public SeleniumUIGreenToken Token(GreenNode leading, SeleniumUISyntaxKind kind, string text, GreenNode trailing)
		{
		    Debug.Assert(SeleniumUILanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SeleniumUILanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SeleniumUIGreenToken.FirstTokenWithWellKnownText && kind <= SeleniumUIGreenToken.LastTokenWithWellKnownText && text == defaultText
		        ? this.Token(leading, kind, trailing)
		        : SeleniumUIGreenToken.WithText(kind, leading, text, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
	    {
	        return this.Token(leading, (SeleniumUISyntaxKind)kind, text, trailing);
	    }
	
	    public SeleniumUIGreenToken Token(GreenNode leading, SeleniumUISyntaxKind kind, string text, string valueText, GreenNode trailing)
		{
		    Debug.Assert(SeleniumUILanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SeleniumUILanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SeleniumUIGreenToken.FirstTokenWithWellKnownText && kind <= SeleniumUIGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(valueText)
		        ? this.Token(leading, kind, trailing)
		        : SeleniumUIGreenToken.WithValue(kind, leading, text, valueText, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
	    {
	        return this.Token(leading, (SeleniumUISyntaxKind)kind, text, valueText, trailing);
	    }
	
	    public SeleniumUIGreenToken Token(GreenNode leading, SeleniumUISyntaxKind kind, string text, object value, GreenNode trailing)
		{
		    Debug.Assert(SeleniumUILanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SeleniumUILanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SeleniumUIGreenToken.FirstTokenWithWellKnownText && kind <= SeleniumUIGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
		        ? this.Token(leading, kind, trailing)
		        : SeleniumUIGreenToken.WithValue(kind, leading, text, value, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
	    {
	        return this.Token(leading, (SeleniumUISyntaxKind)kind, text, value, trailing);
	    }
	
	    public SeleniumUIGreenToken BadToken(GreenNode leading, string text, GreenNode trailing)
		{
		    return SeleniumUIGreenToken.WithText(SeleniumUISyntaxKind.BadToken, leading, text, trailing);
		}
	
	
	    internal SeleniumUIGreenToken LIdentifier(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LIdentifier, text, null);
	    }
	
	    internal SeleniumUIGreenToken LIdentifier(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LIdentifier, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LInteger(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LInteger, text, null);
	    }
	
	    internal SeleniumUIGreenToken LInteger(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LInteger, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LDecimal(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LDecimal, text, null);
	    }
	
	    internal SeleniumUIGreenToken LDecimal(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LScientific(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LScientific, text, null);
	    }
	
	    internal SeleniumUIGreenToken LScientific(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LScientific, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LRegularString(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LRegularString, text, null);
	    }
	
	    internal SeleniumUIGreenToken LRegularString(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LUtf8Bom(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal SeleniumUIGreenToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LWhiteSpace(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal SeleniumUIGreenToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LCrLf(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LCrLf, text, null);
	    }
	
	    internal SeleniumUIGreenToken LCrLf(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LLineEnd(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LLineEnd, text, null);
	    }
	
	    internal SeleniumUIGreenToken LLineEnd(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LSingleLineComment(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal SeleniumUIGreenToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal SeleniumUIGreenToken LComment(string text)
	    {
	        return Token(null, SeleniumUISyntaxKind.LComment, text, null);
	    }
	
	    internal SeleniumUIGreenToken LComment(string text, object value)
	    {
	        return Token(null, SeleniumUISyntaxKind.LComment, text, value, null);
	    }
	
		public MainGreen Main(InternalSyntaxNodeList _namespace, InternalSyntaxToken eof, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (eof == null) throw new ArgumentNullException(nameof(eof));
				if (eof.RawKind != (int)SeleniumUISyntaxKind.Eof) throw new ArgumentException(nameof(eof));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.Main, _namespace, eof, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(SeleniumUISyntaxKind.Main, _namespace, eof);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceGreen Namespace(InternalSyntaxToken kNamespace, QualifiedNameGreen qualifiedName, NamespaceBodyGreen namespaceBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
				if (kNamespace.RawKind != (int)SeleniumUISyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
				if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
				if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.Namespace, kNamespace, qualifiedName, namespaceBody, out hash);
			if (cached != null) return (NamespaceGreen)cached;
			var result = new NamespaceGreen(SeleniumUISyntaxKind.Namespace, kNamespace, qualifiedName, namespaceBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NamespaceBodyGreen NamespaceBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList declaration, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SeleniumUISyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SeleniumUISyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.NamespaceBody, tOpenBrace, declaration, tCloseBrace, out hash);
			if (cached != null) return (NamespaceBodyGreen)cached;
			var result = new NamespaceBodyGreen(SeleniumUISyntaxKind.NamespaceBody, tOpenBrace, declaration, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeclarationGreen Declaration(TagGreen tag, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (tag == null) throw new ArgumentNullException(nameof(tag));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.Declaration, tag, out hash);
			if (cached != null) return (DeclarationGreen)cached;
			var result = new DeclarationGreen(SeleniumUISyntaxKind.Declaration, tag, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public DeclarationGreen Declaration(PageGreen page, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (page == null) throw new ArgumentNullException(nameof(page));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.Declaration, page, out hash);
			if (cached != null) return (DeclarationGreen)cached;
			var result = new DeclarationGreen(SeleniumUISyntaxKind.Declaration, null, page);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public TagGreen Tag(InternalSyntaxToken kTag, NameGreen name, TypeSpecifierGreen typeSpecifier, InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kTag == null) throw new ArgumentNullException(nameof(kTag));
				if (kTag.RawKind != (int)SeleniumUISyntaxKind.KTag) throw new ArgumentException(nameof(kTag));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SeleniumUISyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
	        return new TagGreen(SeleniumUISyntaxKind.Tag, kTag, name, typeSpecifier, tSemicolon);
	    }
	
		public TypeSpecifierGreen TypeSpecifier(InternalSyntaxToken tColon, QualifierGreen qualifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SeleniumUISyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.TypeSpecifier, tColon, qualifier, out hash);
			if (cached != null) return (TypeSpecifierGreen)cached;
			var result = new TypeSpecifierGreen(SeleniumUISyntaxKind.TypeSpecifier, tColon, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PageGreen Page(InternalSyntaxToken kPage, NameGreen name, ElementBodyGreen elementBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kPage == null) throw new ArgumentNullException(nameof(kPage));
				if (kPage.RawKind != (int)SeleniumUISyntaxKind.KPage) throw new ArgumentException(nameof(kPage));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (elementBody == null) throw new ArgumentNullException(nameof(elementBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.Page, kPage, name, elementBody, out hash);
			if (cached != null) return (PageGreen)cached;
			var result = new PageGreen(SeleniumUISyntaxKind.Page, kPage, name, elementBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ElementGreen Element(InternalSyntaxToken kElement, NameGreen name, TagSpecifierGreen tagSpecifier, LocatorSpecifierGreen locatorSpecifier, ElementBodyGreen elementBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kElement == null) throw new ArgumentNullException(nameof(kElement));
				if (kElement.RawKind != (int)SeleniumUISyntaxKind.KElement) throw new ArgumentException(nameof(kElement));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (locatorSpecifier == null) throw new ArgumentNullException(nameof(locatorSpecifier));
				if (elementBody == null) throw new ArgumentNullException(nameof(elementBody));
			}
	#endif
	        return new ElementGreen(SeleniumUISyntaxKind.Element, kElement, name, tagSpecifier, locatorSpecifier, elementBody);
	    }
	
		public TagSpecifierGreen TagSpecifier(InternalSyntaxToken tColon, QualifierGreen qualifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tColon == null) throw new ArgumentNullException(nameof(tColon));
				if (tColon.RawKind != (int)SeleniumUISyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
				if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.TagSpecifier, tColon, qualifier, out hash);
			if (cached != null) return (TagSpecifierGreen)cached;
			var result = new TagSpecifierGreen(SeleniumUISyntaxKind.TagSpecifier, tColon, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public LocatorSpecifierGreen LocatorSpecifier(InternalSyntaxToken tAssign, StringGreen _string, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
				if (tAssign.RawKind != (int)SeleniumUISyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
				if (_string == null) throw new ArgumentNullException(nameof(_string));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.LocatorSpecifier, tAssign, _string, out hash);
			if (cached != null) return (LocatorSpecifierGreen)cached;
			var result = new LocatorSpecifierGreen(SeleniumUISyntaxKind.LocatorSpecifier, tAssign, _string);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ElementBodyGreen ElementBody(EmptyElementBodyGreen emptyElementBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (emptyElementBody == null) throw new ArgumentNullException(nameof(emptyElementBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.ElementBody, emptyElementBody, out hash);
			if (cached != null) return (ElementBodyGreen)cached;
			var result = new ElementBodyGreen(SeleniumUISyntaxKind.ElementBody, emptyElementBody, null);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ElementBodyGreen ElementBody(ChildElementsBodyGreen childElementsBody, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
		        if (childElementsBody == null) throw new ArgumentNullException(nameof(childElementsBody));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.ElementBody, childElementsBody, out hash);
			if (cached != null) return (ElementBodyGreen)cached;
			var result = new ElementBodyGreen(SeleniumUISyntaxKind.ElementBody, null, childElementsBody);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public EmptyElementBodyGreen EmptyElementBody(InternalSyntaxToken tSemicolon, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
				if (tSemicolon.RawKind != (int)SeleniumUISyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.EmptyElementBody, tSemicolon, out hash);
			if (cached != null) return (EmptyElementBodyGreen)cached;
			var result = new EmptyElementBodyGreen(SeleniumUISyntaxKind.EmptyElementBody, tSemicolon);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public ChildElementsBodyGreen ChildElementsBody(InternalSyntaxToken tOpenBrace, InternalSyntaxNodeList element, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SeleniumUISyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SeleniumUISyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.ChildElementsBody, tOpenBrace, element, tCloseBrace, out hash);
			if (cached != null) return (ChildElementsBodyGreen)cached;
			var result = new ChildElementsBodyGreen(SeleniumUISyntaxKind.ChildElementsBody, tOpenBrace, element, tCloseBrace);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifiedNameGreen QualifiedName(QualifierGreen qualifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.QualifiedName, qualifier, out hash);
			if (cached != null) return (QualifiedNameGreen)cached;
			var result = new QualifiedNameGreen(SeleniumUISyntaxKind.QualifiedName, qualifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public NameGreen Name(IdentifierGreen identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(SeleniumUISyntaxKind.Name, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public QualifierGreen Qualifier(InternalSeparatedSyntaxNodeList identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.Qualifier, identifier, out hash);
			if (cached != null) return (QualifierGreen)cached;
			var result = new QualifierGreen(SeleniumUISyntaxKind.Qualifier, identifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public IdentifierGreen Identifier(InternalSyntaxToken lIdentifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (lIdentifier == null) throw new ArgumentNullException(nameof(lIdentifier));
				if (lIdentifier.RawKind != (int)SeleniumUISyntaxKind.LIdentifier) throw new ArgumentException(nameof(lIdentifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.Identifier, lIdentifier, out hash);
			if (cached != null) return (IdentifierGreen)cached;
			var result = new IdentifierGreen(SeleniumUISyntaxKind.Identifier, lIdentifier);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public StringGreen String(InternalSyntaxToken _string, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (_string == null) throw new ArgumentNullException(nameof(_string));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUISyntaxKind.String, _string, out hash);
			if (cached != null) return (StringGreen)cached;
			var result = new StringGreen(SeleniumUISyntaxKind.String, _string);
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
				typeof(NamespaceGreen),
				typeof(NamespaceBodyGreen),
				typeof(DeclarationGreen),
				typeof(TagGreen),
				typeof(TypeSpecifierGreen),
				typeof(PageGreen),
				typeof(ElementGreen),
				typeof(TagSpecifierGreen),
				typeof(LocatorSpecifierGreen),
				typeof(ElementBodyGreen),
				typeof(EmptyElementBodyGreen),
				typeof(ChildElementsBodyGreen),
				typeof(QualifiedNameGreen),
				typeof(NameGreen),
				typeof(QualifierGreen),
				typeof(IdentifierGreen),
				typeof(StringGreen),
			};
		}
	}
}

