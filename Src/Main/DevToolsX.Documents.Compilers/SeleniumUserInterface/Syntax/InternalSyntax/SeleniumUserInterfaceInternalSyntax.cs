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

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.InternalSyntax
{
    internal abstract class SeleniumUserInterfaceGreenNode : InternalSyntaxNode
    {
        public SeleniumUserInterfaceGreenNode(SeleniumUserInterfaceSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, 0, diagnostics, annotations)
        {
        }

        public SeleniumUserInterfaceSyntaxKind Kind
        {
            get { return (SeleniumUserInterfaceSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return SeleniumUserInterfaceLanguage.Instance; }
        }
    }

    internal class SeleniumUserInterfaceGreenTrivia : InternalSyntaxTrivia
    {
        public SeleniumUserInterfaceGreenTrivia(SeleniumUserInterfaceSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
            : base((int)kind, text, diagnostics, annotations)
        {
        }

        public SeleniumUserInterfaceSyntaxKind Kind
        {
            get { return (SeleniumUserInterfaceSyntaxKind)base.RawKind; }
        }

        public override Language Language
        {
            get { return SeleniumUserInterfaceLanguage.Instance; }
        }

        public override SyntaxTrivia CreateRed(SyntaxToken parent, int position, int index)
        {
            return new SeleniumUserInterfaceSyntaxTrivia(this, parent, position, index);
        }

        public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
        {
            return new SeleniumUserInterfaceGreenTrivia(this.Kind, this.Text, diagnostics, this.GetAnnotations());
        }

        public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
        {
            return new SeleniumUserInterfaceGreenTrivia(this.Kind, this.Text, this.GetDiagnostics(), annotations);
        }
    }

	public class SeleniumUserInterfaceGreenToken : InternalSyntaxToken
	{
		public SeleniumUserInterfaceGreenToken(SeleniumUserInterfaceSyntaxKind kind, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
		    : base((int)kind, diagnostics, annotations)
		{
		}
	
	    public SeleniumUserInterfaceGreenToken(SeleniumUserInterfaceSyntaxKind kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base((int)kind, fullWidth, diagnostics, annotations)
	    {
	    }
	
	    public SeleniumUserInterfaceSyntaxKind Kind
		{
		    get { return (SeleniumUserInterfaceSyntaxKind)base.RawKind; }
		}
	
		public virtual SeleniumUserInterfaceSyntaxKind ContextualKind
		{
		    get { return this.Kind; }
		}
	
	    public override string Text
	    {
	        get
	        {
	            return SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.GetText(this.Kind);
	        }
	    }
	
	    public override Language Language
	    {
	        get { return SeleniumUserInterfaceLanguage.Instance; }
	    }
	
	    public override SyntaxToken CreateRed(SyntaxNode parent, int position, int index)
	    {
	        return new SeleniumUserInterfaceSyntaxToken(this, parent, position, index);
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
	        return new SeleniumUserInterfaceGreenToken(this.Kind, this.GetDiagnostics(), annotations);
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new SeleniumUserInterfaceGreenToken(this.Kind, diagnostics, this.GetAnnotations());
	    }
	
	    internal static SeleniumUserInterfaceGreenToken Create(SeleniumUserInterfaceSyntaxKind kind)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.IsToken(kind))
	            {
	                throw new ArgumentException(string.Format("Invalid token kind '{0}'. This method can only be used to create tokens.", kind), nameof(kind));
	            }
	
	            return CreateMissing(kind, null, null);
	        }
	
	        return s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	    }
	
	    internal static SeleniumUserInterfaceGreenToken Create(SeleniumUserInterfaceSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        if (kind < FirstTokenWithWellKnownText || kind > LastTokenWithWellKnownText)
	        {
	            if (!SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.IsToken(kind))
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
	            else if (trailing == SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Space)
	            {
	                return s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	            else if (trailing == SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed)
	            {
	                return s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText];
	            }
	        }
	
	        if (leading == SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace && trailing == SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace)
	        {
	            return s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText];
	        }
	
	        return new SyntaxTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static SeleniumUserInterfaceGreenToken CreateMissing(SeleniumUserInterfaceSyntaxKind kind, GreenNode leading, GreenNode trailing)
	    {
	        return new MissingTokenWithTrivia(kind, leading, trailing, null, null);
	    }
	
	    internal static readonly SeleniumUserInterfaceSyntaxKind FirstTokenWithWellKnownText = SeleniumUserInterfaceSyntaxKind.KParent;
	    internal static readonly SeleniumUserInterfaceSyntaxKind LastTokenWithWellKnownText = SeleniumUserInterfaceSyntaxKind.LComment_Star;
	
	    // TODO: eliminate the blank space before the first interesting element?
	    private static readonly SeleniumUserInterfaceGreenToken[] s_tokensWithNoTrivia = new SeleniumUserInterfaceGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SeleniumUserInterfaceGreenToken[] s_tokensWithElasticTrivia = new SeleniumUserInterfaceGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SeleniumUserInterfaceGreenToken[] s_tokensWithSingleTrailingSpace = new SeleniumUserInterfaceGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	    private static readonly SeleniumUserInterfaceGreenToken[] s_tokensWithSingleTrailingCRLF = new SeleniumUserInterfaceGreenToken[(int)LastTokenWithWellKnownText - (int)FirstTokenWithWellKnownText + 1];
	
	    static SeleniumUserInterfaceGreenToken()
	    {
	        for (var kind = FirstTokenWithWellKnownText; kind <= LastTokenWithWellKnownText; kind++)
	        {
	            s_tokensWithNoTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SeleniumUserInterfaceGreenToken(kind, null, null);
	            s_tokensWithElasticTrivia[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.ElasticZeroSpace, null, null);
	            s_tokensWithSingleTrailingSpace[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Space, null, null);
	            s_tokensWithSingleTrailingCRLF[(int)kind - (int)FirstTokenWithWellKnownText] = new SyntaxTokenWithTrivia(kind, null, SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.CarriageReturnLineFeed, null, null);
	        }
	    }
	
	    internal static IEnumerable<SeleniumUserInterfaceGreenToken> GetWellKnownTokens()
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
	
	    internal static SeleniumUserInterfaceGreenToken WithText(SeleniumUserInterfaceSyntaxKind kind, string text)
	    {
	        return new SyntaxTokenWithText(kind, text, null, null);
	    }
	
	    internal static SeleniumUserInterfaceGreenToken WithText(SeleniumUserInterfaceSyntaxKind kind, GreenNode leading, string text, GreenNode trailing)
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
	
	    internal static SeleniumUserInterfaceGreenToken WithText(SeleniumUserInterfaceSyntaxKind kind, GreenNode leading, string text, string valueText, GreenNode trailing)
	    {
	        if (valueText == text)
	        {
	            return WithText(kind, leading, text, trailing);
	        }
	
	        return new SyntaxTokenWithTextAndTrivia(kind, text, valueText, leading, trailing, null, null);
	    }
	
	    internal static SeleniumUserInterfaceGreenToken WithValue<T>(SeleniumUserInterfaceSyntaxKind kind, string text, T value)
	    {
	        return new SyntaxTokenWithValue<T>(kind, text, value, null, null);
	    }
	
	    internal static SeleniumUserInterfaceGreenToken WithValue<T>(SeleniumUserInterfaceSyntaxKind kind, GreenNode leading, string text, T value, GreenNode trailing)
	    {
	        return new SyntaxTokenWithValueAndTrivia<T>(kind, text, value, leading, trailing, null, null);
	    }
	
	    private class SyntaxTokenWithTrivia : SeleniumUserInterfaceGreenToken
	    {
	        protected readonly GreenNode LeadingField;
	        protected readonly GreenNode TrailingField;
	
	        internal SyntaxTokenWithTrivia(SeleniumUserInterfaceSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	        internal MissingTokenWithTrivia(SeleniumUserInterfaceSyntaxKind kind, GreenNode leading, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	    private class SyntaxTokenWithText : SeleniumUserInterfaceGreenToken
	    {
	        protected readonly string TextField;
	
	        internal SyntaxTokenWithText(SeleniumUserInterfaceSyntaxKind kind, string text, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	        internal SyntaxIdentifierExtended(SeleniumUserInterfaceSyntaxKind kind, string text, string valueText, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	
	        internal SyntaxTokenWithTextAndTrailingTrivia(SeleniumUserInterfaceSyntaxKind kind, string text, GreenNode trailing, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            SeleniumUserInterfaceSyntaxKind kind,
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
	
	    private class SyntaxTokenWithValue<T> : SeleniumUserInterfaceGreenToken
	    {
	        protected readonly string TextField;
	        protected readonly T ValueField;
	
	        internal SyntaxTokenWithValue(SeleniumUserInterfaceSyntaxKind kind, string text, T value, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
	            SeleniumUserInterfaceSyntaxKind kind,
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
	
	internal class MainGreen : SeleniumUserInterfaceGreenNode
	{
	    private PageGreen page;
	    private InternalSyntaxToken eof;
	
	    public MainGreen(SeleniumUserInterfaceSyntaxKind kind, PageGreen page, InternalSyntaxToken eof)
	        : base(kind, null, null)
	    {
			if (page != null)
			{
				this.AdjustFlagsAndWidth(page);
				this.page = page;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
	    public MainGreen(SeleniumUserInterfaceSyntaxKind kind, PageGreen page, InternalSyntaxToken eof, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (page != null)
			{
				this.AdjustFlagsAndWidth(page);
				this.page = page;
			}
			if (eof != null)
			{
				this.AdjustFlagsAndWidth(eof);
				this.eof = eof;
			}
	    }
	
		public override int SlotCount { get { return 2; } }
	
	    public PageGreen Page { get { return this.page; } }
	    public InternalSyntaxToken Eof { get { return this.eof; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.MainSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.page;
	            case 1: return this.eof;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new MainGreen(this.Kind, this.page, this.eof, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new MainGreen(this.Kind, this.page, this.eof, this.GetDiagnostics(), annotations);
	    }
	
	    public MainGreen Update(PageGreen page, InternalSyntaxToken eof)
	    {
	        if (this.page != page ||
				this.eof != eof)
	        {
	            GreenNode newNode = SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Main(page, eof);
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
	
	internal class PageGreen : SeleniumUserInterfaceGreenNode
	{
	    private InternalSyntaxToken kPage;
	    private NameGreen name;
	    private InternalSyntaxToken tOpenBrace;
	    private InternalSyntaxToken tCloseBrace;
	
	    public PageGreen(SeleniumUserInterfaceSyntaxKind kind, InternalSyntaxToken kPage, NameGreen name, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
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
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
	    public PageGreen(SeleniumUserInterfaceSyntaxKind kind, InternalSyntaxToken kPage, NameGreen name, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
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
			if (tOpenBrace != null)
			{
				this.AdjustFlagsAndWidth(tOpenBrace);
				this.tOpenBrace = tOpenBrace;
			}
			if (tCloseBrace != null)
			{
				this.AdjustFlagsAndWidth(tCloseBrace);
				this.tCloseBrace = tCloseBrace;
			}
	    }
	
		public override int SlotCount { get { return 4; } }
	
	    public InternalSyntaxToken KPage { get { return this.kPage; } }
	    public NameGreen Name { get { return this.name; } }
	    public InternalSyntaxToken TOpenBrace { get { return this.tOpenBrace; } }
	    public InternalSyntaxToken TCloseBrace { get { return this.tCloseBrace; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.PageSyntax(this, parent, position);
	    }
	
	    public override GreenNode GetSlot(int index)
	    {
	        switch (index)
	        {
	            case 0: return this.kPage;
	            case 1: return this.name;
	            case 2: return this.tOpenBrace;
	            case 3: return this.tCloseBrace;
	            default: return null;
	        }
	    }
	
	    public override GreenNode WithDiagnostics(DiagnosticInfo[] diagnostics)
	    {
	        return new PageGreen(this.Kind, this.kPage, this.name, this.tOpenBrace, this.tCloseBrace, diagnostics, this.GetAnnotations());
	    }
	
	    public override GreenNode WithAnnotations(SyntaxAnnotation[] annotations)
	    {
	        return new PageGreen(this.Kind, this.kPage, this.name, this.tOpenBrace, this.tCloseBrace, this.GetDiagnostics(), annotations);
	    }
	
	    public PageGreen Update(InternalSyntaxToken kPage, NameGreen name, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace)
	    {
	        if (this.kPage != kPage ||
				this.name != name ||
				this.tOpenBrace != tOpenBrace ||
				this.tCloseBrace != tCloseBrace)
	        {
	            GreenNode newNode = SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Page(kPage, name, tOpenBrace, tCloseBrace);
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
	
	internal class NameGreen : SeleniumUserInterfaceGreenNode
	{
	    private InternalSyntaxToken identifier;
	
	    public NameGreen(SeleniumUserInterfaceSyntaxKind kind, InternalSyntaxToken identifier)
	        : base(kind, null, null)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
	    public NameGreen(SeleniumUserInterfaceSyntaxKind kind, InternalSyntaxToken identifier, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
	        : base(kind, diagnostics, annotations)
	    {
			if (identifier != null)
			{
				this.AdjustFlagsAndWidth(identifier);
				this.identifier = identifier;
			}
	    }
	
		public override int SlotCount { get { return 1; } }
	
	    public InternalSyntaxToken Identifier { get { return this.identifier; } }
	
	    public override SyntaxNode CreateRed(SyntaxNode parent, int position)
	    {
	        return new global::DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax.NameSyntax(this, parent, position);
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
	
	    public NameGreen Update(InternalSyntaxToken identifier)
	    {
	        if (this.identifier != identifier)
	        {
	            GreenNode newNode = SeleniumUserInterfaceLanguage.Instance.InternalSyntaxFactory.Name(identifier);
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

	internal class SeleniumUserInterfaceGreenFactory : InternalSyntaxFactory
	{
	    internal static readonly SeleniumUserInterfaceGreenFactory Instance = new SeleniumUserInterfaceGreenFactory();
	
		public new SeleniumUserInterfaceLanguage Language
		{
			get { return SeleniumUserInterfaceLanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
		public SeleniumUserInterfaceGreenTrivia Trivia(SeleniumUserInterfaceSyntaxKind kind, string text)
		{
		    return new SeleniumUserInterfaceGreenTrivia(kind, text, null, null);
		}
	
		public override InternalSyntaxTrivia Trivia(int kind, string text)
		{
		    return new SeleniumUserInterfaceGreenTrivia((SeleniumUserInterfaceSyntaxKind)kind, text, null, null);
		}
	
		public SeleniumUserInterfaceGreenToken MissingToken(SeleniumUserInterfaceSyntaxKind kind)
		{
		    return SeleniumUserInterfaceGreenToken.CreateMissing(kind, null, null);
		}
	
		public override InternalSyntaxToken MissingToken(int kind)
		{
		    return SeleniumUserInterfaceGreenToken.CreateMissing((SeleniumUserInterfaceSyntaxKind)kind, null, null);
		}
	
		public SeleniumUserInterfaceGreenToken MissingToken(GreenNode leading, SeleniumUserInterfaceSyntaxKind kind, GreenNode trailing)
		{
		    return SeleniumUserInterfaceGreenToken.CreateMissing(kind, leading, trailing);
		}
	
		public override InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing)
		{
		    return SeleniumUserInterfaceGreenToken.CreateMissing((SeleniumUserInterfaceSyntaxKind)kind, leading, trailing);
		}
	
		public SeleniumUserInterfaceGreenToken Token(SeleniumUserInterfaceSyntaxKind kind)
		{
		    return SeleniumUserInterfaceGreenToken.Create(kind);
		}
	
		public override InternalSyntaxToken Token(int kind)
		{
		    return SeleniumUserInterfaceGreenToken.Create((SeleniumUserInterfaceSyntaxKind)kind);
		}
	
	    public SeleniumUserInterfaceGreenToken Token(GreenNode leading, SeleniumUserInterfaceSyntaxKind kind, GreenNode trailing)
		{
		    return SeleniumUserInterfaceGreenToken.Create(kind, leading, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing)
		{
		    return SeleniumUserInterfaceGreenToken.Create((SeleniumUserInterfaceSyntaxKind)kind, leading, trailing);
		}
	
	    public SeleniumUserInterfaceGreenToken Token(GreenNode leading, SeleniumUserInterfaceSyntaxKind kind, string text, GreenNode trailing)
		{
		    Debug.Assert(SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SeleniumUserInterfaceGreenToken.FirstTokenWithWellKnownText && kind <= SeleniumUserInterfaceGreenToken.LastTokenWithWellKnownText && text == defaultText
		        ? this.Token(leading, kind, trailing)
		        : SeleniumUserInterfaceGreenToken.WithText(kind, leading, text, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing)
	    {
	        return this.Token(leading, (SeleniumUserInterfaceSyntaxKind)kind, text, trailing);
	    }
	
	    public SeleniumUserInterfaceGreenToken Token(GreenNode leading, SeleniumUserInterfaceSyntaxKind kind, string text, string valueText, GreenNode trailing)
		{
		    Debug.Assert(SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SeleniumUserInterfaceGreenToken.FirstTokenWithWellKnownText && kind <= SeleniumUserInterfaceGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(valueText)
		        ? this.Token(leading, kind, trailing)
		        : SeleniumUserInterfaceGreenToken.WithValue(kind, leading, text, valueText, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing)
	    {
	        return this.Token(leading, (SeleniumUserInterfaceSyntaxKind)kind, text, valueText, trailing);
	    }
	
	    public SeleniumUserInterfaceGreenToken Token(GreenNode leading, SeleniumUserInterfaceSyntaxKind kind, string text, object value, GreenNode trailing)
		{
		    Debug.Assert(SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.IsToken(kind));
		    string defaultText = SeleniumUserInterfaceLanguage.Instance.SyntaxFacts.GetText(kind);
		    return kind >= SeleniumUserInterfaceGreenToken.FirstTokenWithWellKnownText && kind <= SeleniumUserInterfaceGreenToken.LastTokenWithWellKnownText && text == defaultText && defaultText.Equals(value)
		        ? this.Token(leading, kind, trailing)
		        : SeleniumUserInterfaceGreenToken.WithValue(kind, leading, text, value, trailing);
		}
	
	    public override InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing)
	    {
	        return this.Token(leading, (SeleniumUserInterfaceSyntaxKind)kind, text, value, trailing);
	    }
	
	    public SeleniumUserInterfaceGreenToken BadToken(GreenNode leading, string text, GreenNode trailing)
		{
		    return SeleniumUserInterfaceGreenToken.WithText(SeleniumUserInterfaceSyntaxKind.BadToken, leading, text, trailing);
		}
	
	
	    internal SeleniumUserInterfaceGreenToken Identifier(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.Identifier, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken Identifier(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.Identifier, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LInteger(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LInteger, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LInteger(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LInteger, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LDecimal(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LDecimal, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LDecimal(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LDecimal, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LScientific(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LScientific, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LScientific(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LScientific, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LRegularString(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LRegularString, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LRegularString(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LRegularString, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LUtf8Bom(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LUtf8Bom, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LUtf8Bom(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LUtf8Bom, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LWhiteSpace(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LWhiteSpace, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LWhiteSpace(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LWhiteSpace, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LCrLf(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LCrLf, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LCrLf(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LCrLf, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LLineEnd(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LLineEnd, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LLineEnd(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LLineEnd, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LSingleLineComment(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LSingleLineComment, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LSingleLineComment(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LSingleLineComment, text, value, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LComment(string text)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LComment, text, null);
	    }
	
	    internal SeleniumUserInterfaceGreenToken LComment(string text, object value)
	    {
	        return Token(null, SeleniumUserInterfaceSyntaxKind.LComment, text, value, null);
	    }
	
		public MainGreen Main(PageGreen page, InternalSyntaxToken eof, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (page == null) throw new ArgumentNullException(nameof(page));
				if (eof == null) throw new ArgumentNullException(nameof(eof));
				if (eof.RawKind != (int)SeleniumUserInterfaceSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUserInterfaceSyntaxKind.Main, page, eof, out hash);
			if (cached != null) return (MainGreen)cached;
			var result = new MainGreen(SeleniumUserInterfaceSyntaxKind.Main, page, eof);
			if (hash >= 0)
			{
				SyntaxNodeCache.AddNode(result, hash);
			}
			return result;
	    }
	
		public PageGreen Page(InternalSyntaxToken kPage, NameGreen name, InternalSyntaxToken tOpenBrace, InternalSyntaxToken tCloseBrace, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (kPage == null) throw new ArgumentNullException(nameof(kPage));
				if (kPage.RawKind != (int)SeleniumUserInterfaceSyntaxKind.KPage) throw new ArgumentException(nameof(kPage));
				if (name == null) throw new ArgumentNullException(nameof(name));
				if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
				if (tOpenBrace.RawKind != (int)SeleniumUserInterfaceSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
				if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
				if (tCloseBrace.RawKind != (int)SeleniumUserInterfaceSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
			}
	#endif
	        return new PageGreen(SeleniumUserInterfaceSyntaxKind.Page, kPage, name, tOpenBrace, tCloseBrace);
	    }
	
		public NameGreen Name(InternalSyntaxToken identifier, bool errorNode = false)
	    {
	#if DEBUG
			if (!errorNode)
			{
				if (identifier == null) throw new ArgumentNullException(nameof(identifier));
				if (identifier.RawKind != (int)SeleniumUserInterfaceSyntaxKind.Identifier) throw new ArgumentException(nameof(identifier));
			}
	#endif
			int hash;
			var cached = SyntaxNodeCache.TryGetNode((int)SeleniumUserInterfaceSyntaxKind.Name, identifier, out hash);
			if (cached != null) return (NameGreen)cached;
			var result = new NameGreen(SeleniumUserInterfaceSyntaxKind.Name, identifier);
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
				typeof(PageGreen),
				typeof(NameGreen),
			};
		}
	}
}

