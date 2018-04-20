// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Utilities;

namespace DevToolsX.Documents.Compilers.SeleniumUI
{
    public class SeleniumUICompilationOptions : CompilationOptions, IEquatable<SeleniumUICompilationOptions>
    {
        // Defaults correspond to the compiler's defaults or indicate that the user did not specify when that is significant.
        // That's significant when one option depends on another's setting.
        public SeleniumUICompilationOptions(
            bool reportSuppressedDiagnostics = false,
            string scriptClassName = null,
            ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default,
            int warningLevel = 4,
            IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions = null,
            bool concurrentBuild = true,
            bool deterministic = false,
            SourceReferenceResolver sourceReferenceResolver = null,
            MetadataReferenceResolver metadataReferenceResolver = null)
            : this(reportSuppressedDiagnostics, scriptClassName,
                   generalDiagnosticOption, warningLevel,
                   specificDiagnosticOptions != null ? specificDiagnosticOptions.ToImmutableDictionary() : ImmutableDictionary<string, ReportDiagnostic>.Empty, 
                   concurrentBuild, deterministic,
                   sourceReferenceResolver: sourceReferenceResolver,
                   metadataReferenceResolver: metadataReferenceResolver,
                   referencesSupersedeLowerVersions: false)
        {
        }

        // Expects correct arguments.
        public SeleniumUICompilationOptions(
            bool reportSuppressedDiagnostics,
            string scriptClassName,
            ReportDiagnostic generalDiagnosticOption,
            int warningLevel,
            ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions,
            bool concurrentBuild,
            bool deterministic,
            SourceReferenceResolver sourceReferenceResolver,
            MetadataReferenceResolver metadataReferenceResolver,
            bool referencesSupersedeLowerVersions)
            : base(reportSuppressedDiagnostics, 
                  scriptClassName,
                  generalDiagnosticOption,
                  warningLevel,
                  specificDiagnosticOptions,
                  concurrentBuild,
                  deterministic,
                  sourceReferenceResolver,
                  metadataReferenceResolver, 
                  referencesSupersedeLowerVersions)
        {
        }

        private SeleniumUICompilationOptions(SeleniumUICompilationOptions other) : this(
            scriptClassName: other.ScriptClassName,
            generalDiagnosticOption: other.GeneralDiagnosticOption,
            warningLevel: other.WarningLevel,
            specificDiagnosticOptions: other.SpecificDiagnosticOptions,
            concurrentBuild: other.ConcurrentBuild,
            deterministic: other.Deterministic,
            sourceReferenceResolver: other.SourceReferenceResolver,
            metadataReferenceResolver: other.MetadataReferenceResolver,
            reportSuppressedDiagnostics: other.ReportSuppressedDiagnostics,
            referencesSupersedeLowerVersions: other.ReferencesSupersedeLowerVersions)
        {
        }

        public new SeleniumUICompilationOptions WithDeterministic(bool deterministic)
        {
            if (this.Deterministic == deterministic)
            {
                return this;
            }
            return new SeleniumUICompilationOptions(this) { Deterministic = deterministic };
        }

        public new SeleniumUICompilationOptions WithReferencesSupersedeLowerVersions(bool value)
        {
            if (this.ReferencesSupersedeLowerVersions == value)
            {
                return this;
            }
            return new SeleniumUICompilationOptions(this) { ReferencesSupersedeLowerVersions = value };
        }

        public new SeleniumUICompilationOptions WithGeneralDiagnosticOption(ReportDiagnostic generalDiagnosticOption)
        {
            if (this.GeneralDiagnosticOption == generalDiagnosticOption)
            {
                return this;
            }
            return new SeleniumUICompilationOptions(this) { GeneralDiagnosticOption = generalDiagnosticOption };
        }

        public new SeleniumUICompilationOptions WithMetadataReferenceResolver(MetadataReferenceResolver resolver)
        {
            if (this.MetadataReferenceResolver == resolver)
            {
                return this;
            }
            return new SeleniumUICompilationOptions(this) { MetadataReferenceResolver = resolver };
        }

        public new SeleniumUICompilationOptions WithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics)
        {
            if (this.ReportSuppressedDiagnostics == reportSuppressedDiagnostics)
            {
                return this;
            }
            return new SeleniumUICompilationOptions(this) { ReportSuppressedDiagnostics = reportSuppressedDiagnostics };
        }

        public new SeleniumUICompilationOptions WithSourceReferenceResolver(SourceReferenceResolver resolver)
        {
            if (this.SourceReferenceResolver == resolver)
            {
                return this;
            }
            return new SeleniumUICompilationOptions(this) { SourceReferenceResolver = resolver };
        }

        public new SeleniumUICompilationOptions WithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions)
        {
            return new SeleniumUICompilationOptions(this) { SpecificDiagnosticOptions = specificDiagnosticOptions != null ? specificDiagnosticOptions.ToImmutableDictionary() : ImmutableDictionary<string, ReportDiagnostic>.Empty };
        }

        public new SeleniumUICompilationOptions WithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions)
        {
            if (specificDiagnosticOptions == null)
            {
                specificDiagnosticOptions = ImmutableDictionary<string, ReportDiagnostic>.Empty;
            }

            if (this.SpecificDiagnosticOptions == specificDiagnosticOptions)
            {
                return this;
            }

            return new SeleniumUICompilationOptions(this) { SpecificDiagnosticOptions = specificDiagnosticOptions };
        }

        protected override CompilationOptions CommonWithDeterministic(bool deterministic)
        {
            return this.WithDeterministic(deterministic);
        }

        protected override CompilationOptions CommonWithReferencesSupersedeLowerVersions(bool value)
        {
            return this.CommonWithDeterministic(value);
        }

        protected override CompilationOptions CommonWithGeneralDiagnosticOption(ReportDiagnostic generalDiagnosticOption)
        {
            return this.WithGeneralDiagnosticOption(generalDiagnosticOption);
        }

        protected override CompilationOptions CommonWithMetadataReferenceResolver(MetadataReferenceResolver resolver)
        {
            return this.WithMetadataReferenceResolver(resolver);
        }

        protected override CompilationOptions CommonWithReportSuppressedDiagnostics(bool reportSuppressedDiagnostics)
        {
            return this.WithReportSuppressedDiagnostics(reportSuppressedDiagnostics);
        }

        protected override CompilationOptions CommonWithSourceReferenceResolver(SourceReferenceResolver resolver)
        {
            return this.WithSourceReferenceResolver(resolver);
        }

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(IEnumerable<KeyValuePair<string, ReportDiagnostic>> specificDiagnosticOptions)
        {
            return this.WithSpecificDiagnosticOptions(specificDiagnosticOptions);
        }

        protected override CompilationOptions CommonWithSpecificDiagnosticOptions(ImmutableDictionary<string, ReportDiagnostic> specificDiagnosticOptions)
        {
            return this.WithSpecificDiagnosticOptions(specificDiagnosticOptions);
        }

        public override Diagnostic FilterDiagnostic(Diagnostic diagnostic)
        {
            return diagnostic;
        }

        protected override ImmutableArray<string> GetImports()
        {
            return ImmutableArray<string>.Empty;
        }

        protected override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
        }

        public bool Equals(SeleniumUICompilationOptions other)
        {
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (!base.EqualsHelper(other))
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as SeleniumUICompilationOptions);
        }

        public override int GetHashCode()
        {
            return base.GetHashCodeHelper();
        }
    }
}

