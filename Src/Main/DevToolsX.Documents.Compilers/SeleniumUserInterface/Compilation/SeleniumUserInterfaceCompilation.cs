// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Threading;
using System.Diagnostics;
using MetaDslx.Core;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Utilities;
using DevToolsX.Documents.Compilers.SeleniumUserInterface.Syntax;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface
{
    public class SeleniumUserInterfaceCompilation : CompilationBase
    {
        protected SeleniumUserInterfaceCompilation(
            string name,
            CompilationOptions options,
            ImmutableArray<MetadataReference> references,
            Compilation previousSubmission,
            Type submissionReturnType,
            Type hostObjectType,
            bool isSubmission,
            ReferenceManager referenceManager,
            bool reuseReferenceManager,
            SyntaxAndDeclarationManager syntaxAndDeclarations,
            AsyncQueue<CompilationEvent> eventQueue = null) 
            : base(name, options, references, previousSubmission, submissionReturnType, hostObjectType,
                  isSubmission, referenceManager, reuseReferenceManager, syntaxAndDeclarations, eventQueue)
        {
        }

        public override bool IsCaseSensitive
        {
            get { return true; }
        }

        public override Language Language
        {
            get { return SeleniumUserInterfaceLanguage.Instance; }
        }

        public new SeleniumUserInterfaceCompilationOptions Options
        {
            get { return (SeleniumUserInterfaceCompilationOptions)base.Options; }
        }

        internal MutableModelGroup ModelGroupBuilder
        {
            get { return this.ModelGroupBuilderCore; }
        }

        internal MutableModel ModelBuilder
        {
            get { return this.ModelBuilderCore; }
        }

        internal ModelId ModelId
        {
            get { return this.ModelIdCore; }
        }

        protected override ISymbol CommonDynamicType
        {
            get { return null; }
        }

        protected override ISymbol CommonObjectType
        {
            get { return null; }
        }

        protected override CompilationBase Update(
            ReferenceManager referenceManager,
            bool reuseReferenceManager,
            SyntaxAndDeclarationManager syntaxAndDeclarations)
        {
            return new SeleniumUserInterfaceCompilation(
                this.CompilationName,
                this.Options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                referenceManager,
                reuseReferenceManager,
                syntaxAndDeclarations);
        }

        /// <summary>
        /// Create a duplicate of this compilation with different symbol instances.
        /// </summary>
        public new SeleniumUserInterfaceCompilation Clone()
        {
            return new SeleniumUserInterfaceCompilation(
                this.CompilationName,
                this.Options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                this.GetUnboundReferenceManager(),
                reuseReferenceManager: true,
                syntaxAndDeclarations: this.SyntaxAndDeclarations);
        }

        protected override Compilation CommonClone()
        {
            return this.Clone();
        }

        private static readonly SeleniumUserInterfaceCompilationOptions s_defaultOptions = new SeleniumUserInterfaceCompilationOptions();
        private static readonly SeleniumUserInterfaceCompilationOptions s_defaultSubmissionOptions = new SeleniumUserInterfaceCompilationOptions().WithReferencesSupersedeLowerVersions(true);

        /// <summary>
        /// Creates a new compilation from scratch. Methods such as AddSyntaxTrees or AddReferences
        /// on the returned object will allow to continue building up the Compilation incrementally.
        /// </summary>
        /// <param name="name">Simple compilation name.</param>
        /// <param name="syntaxTrees">The syntax trees with the source code for the new compilation.</param>
        /// <param name="references">The references for the new compilation.</param>
        /// <param name="options">The compiler options to use.</param>
        /// <returns>A new compilation.</returns>
        public static SeleniumUserInterfaceCompilation Create(
            string name,
            IEnumerable<SeleniumUserInterfaceSyntaxTree> syntaxTrees = null,
            IEnumerable<MetadataReference> references = null,
            SeleniumUserInterfaceCompilationOptions options = null)
        {
            return Create(
                name,
                options ?? s_defaultOptions,
                syntaxTrees,
                references,
                previousSubmission: null,
                returnType: null,
                hostObjectType: null,
                isSubmission: false);
        }

        /// <summary>
        /// Creates a new compilation that can be used in scripting.
        /// </summary>
        public static SeleniumUserInterfaceCompilation CreateScriptCompilation(
            string name,
            SeleniumUserInterfaceSyntaxTree syntaxTree = null,
            IEnumerable<MetadataReference> references = null,
            SeleniumUserInterfaceCompilationOptions options = null,
            SeleniumUserInterfaceCompilation previousScriptCompilation = null,
            Type returnType = null,
            Type globalsType = null)
        {
            ValidateScriptCompilationParameters(previousScriptCompilation, returnType, ref globalsType);

            return Create(
                name,
                options?.WithReferencesSupersedeLowerVersions(true) ?? s_defaultSubmissionOptions,
                (syntaxTree != null) ? new[] { syntaxTree } : EmptyCollections.Enumerable<SeleniumUserInterfaceSyntaxTree>(),
                references,
                previousScriptCompilation,
                returnType,
                globalsType,
                isSubmission: true);
        }

        private static SeleniumUserInterfaceCompilation Create(
            string name,
            SeleniumUserInterfaceCompilationOptions options,
            IEnumerable<SeleniumUserInterfaceSyntaxTree> syntaxTrees,
            IEnumerable<MetadataReference> references,
            SeleniumUserInterfaceCompilation previousSubmission,
            Type returnType,
            Type hostObjectType,
            bool isSubmission)
        {
            Debug.Assert(options != null);
            Debug.Assert(!isSubmission || options.ReferencesSupersedeLowerVersions);

            var validatedReferences = ValidateReferences<CompilationReference>(references);

            var compilation = new SeleniumUserInterfaceCompilation(
                name,
                options,
                validatedReferences,
                previousSubmission,
                returnType,
                hostObjectType,
                isSubmission,
                referenceManager: null,
                reuseReferenceManager: false,
                syntaxAndDeclarations: SyntaxAndDeclarationManager.Create(
                    ImmutableArray<SyntaxTree>.Empty,
                    options.ScriptClassName,
                    options.SourceReferenceResolver,
                    isSubmission));

            if (syntaxTrees != null)
            {
                compilation = compilation.AddSyntaxTrees(syntaxTrees);
            }

            return compilation;
        }

        public new SeleniumUserInterfaceCompilation AddReferences(params MetadataReference[] references)
        { 
            return (SeleniumUserInterfaceCompilation)base.AddReferences(references);
        }

        public new SeleniumUserInterfaceCompilation AddReferences(IEnumerable<MetadataReference> references)
        {
            return (SeleniumUserInterfaceCompilation)base.AddReferences(references);
        }

        public new SeleniumUserInterfaceCompilation RemoveReferences(params MetadataReference[] references)
        {
            return (SeleniumUserInterfaceCompilation)base.RemoveReferences(references);
        }

        public new SeleniumUserInterfaceCompilation RemoveReferences(IEnumerable<MetadataReference> references)
        {
            return (SeleniumUserInterfaceCompilation)base.RemoveReferences(references);
        }

        public new SeleniumUserInterfaceCompilation RemoveAllReferences()
        {
            return (SeleniumUserInterfaceCompilation)base.RemoveAllReferences();
        }

        public new SeleniumUserInterfaceCompilation AddSyntaxTrees(params SyntaxTree[] trees)
        {
            return (SeleniumUserInterfaceCompilation)base.AddSyntaxTrees(trees);
        }

        public new SeleniumUserInterfaceCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            return (SeleniumUserInterfaceCompilation)base.AddSyntaxTrees(trees);
        }

        public new SeleniumUserInterfaceCompilation RemoveSyntaxTrees(params SyntaxTree[] trees)
        {
            return (SeleniumUserInterfaceCompilation)base.RemoveSyntaxTrees(trees);
        }

        public new SeleniumUserInterfaceCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            return (SeleniumUserInterfaceCompilation)base.RemoveSyntaxTrees(trees);
        }

        public new SeleniumUserInterfaceCompilation RemoveAllSyntaxTrees()
        {
            return (SeleniumUserInterfaceCompilation)base.RemoveAllSyntaxTrees();
        }

        public new SeleniumUserInterfaceCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            return (SeleniumUserInterfaceCompilation)base.ReplaceSyntaxTree(oldTree, newTree);
        }

        protected override ISymbol CommonGetEntryPoint(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override ISymbol CommonGetSpecialType(Type specialType)
        {
            throw new NotImplementedException();
        }

        protected override ISymbol CommonGetTypeByMetadataName(string metadataName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new compilation with the specified name.
        /// </summary>
        public new SeleniumUserInterfaceCompilation WithCompilationName(string compilationName)
        {
            // Can't reuse references since the source assembly name changed and the referenced symbols might 
            // have internals-visible-to relationship with this compilation or they might had a circular reference 
            // to this compilation.
            return new SeleniumUserInterfaceCompilation(
                compilationName,
                this.Options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                this.GetUnboundReferenceManager(),
                reuseReferenceManager: this.CompilationName == compilationName,
                syntaxAndDeclarations: this.SyntaxAndDeclarations);
        }

        protected override Compilation CommonWithCompilationName(string compilationName)
        {
            return this.WithCompilationName(compilationName);
        }

        /// <summary>
        /// Returns a new compilation with a given event queue.
        /// </summary>
        public new SeleniumUserInterfaceCompilation WithEventQueue(AsyncQueue<CompilationEvent> eventQueue)
        {
            return new SeleniumUserInterfaceCompilation(
                this.CompilationName,
                this.Options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                this.GetUnboundReferenceManager(),
                reuseReferenceManager: true,
                syntaxAndDeclarations: this.SyntaxAndDeclarations,
                eventQueue: eventQueue);
        }

        protected override Compilation CommonWithEventQueue(AsyncQueue<CompilationEvent> eventQueue)
        {
            return this.WithEventQueue(eventQueue);
        }

        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        public SeleniumUserInterfaceCompilation WithOptions(SeleniumUserInterfaceCompilationOptions options)
        {
            var oldOptions = this.Options;
            bool reuseReferenceManager = oldOptions.CanReuseCompilationReferenceManager(options);
            bool reuseSyntaxAndDeclarationManager = oldOptions.ScriptClassName == options.ScriptClassName &&
                oldOptions.SourceReferenceResolver == options.SourceReferenceResolver;

            return new SeleniumUserInterfaceCompilation(
                this.CompilationName,
                options,
                this.ExternalReferences,
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                this.GetUnboundReferenceManager(),
                reuseReferenceManager,
                reuseSyntaxAndDeclarationManager ?
                    this.SyntaxAndDeclarations :
                    SyntaxAndDeclarationManager.Create(
                        this.SyntaxAndDeclarations.ExternalSyntaxTrees,
                        options.ScriptClassName,
                        options.SourceReferenceResolver,
                        this.SyntaxAndDeclarations.IsSubmission));
        }

        protected override Compilation CommonWithOptions(CompilationOptions options)
        {
            return this.WithOptions(options);
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <remarks>
        /// The new <see cref="SeleniumUserInterfaceCompilation"/> will query the given <see cref="MetadataReference"/> for the underlying 
        /// metadata as soon as the are needed. 
        /// 
        /// The new compilation uses whatever metadata is currently being provided by the <see cref="MetadataReference"/>.
        /// E.g. if the current compilation references a metadata file that has changed since the creation of the compilation
        /// the new compilation is going to use the updated version, while the current compilation will be using the previous (it doesn't change).
        /// </remarks>
        public new SeleniumUserInterfaceCompilation WithReferences(IEnumerable<MetadataReference> references)
        {
            // References might have changed, don't reuse reference manager.
            // Don't even reuse observed metadata - let the manager query for the metadata again.

            return new SeleniumUserInterfaceCompilation(
                this.CompilationName,
                this.Options,
                ValidateReferences<CompilationReference>(references),
                this.PreviousSubmission,
                this.SubmissionReturnType,
                this.HostObjectType,
                this.IsSubmission,
                referenceManager: null,
                reuseReferenceManager: false,
                syntaxAndDeclarations: this.SyntaxAndDeclarations);
        }

        protected override Compilation CommonWithReferences(IEnumerable<MetadataReference> newReferences)
        {
            return this.WithReferences(newReferences);
        }

        /// <summary>
        /// Returns a new compilation with the given compilation set as the previous submission.
        /// </summary>
        public SeleniumUserInterfaceCompilation WithScriptCompilationInfo(SeleniumUserInterfaceScriptCompilationInfo info)
        {
            if (info == ScriptCompilationInfo)
            {
                return this;
            }

            // Reference binding doesn't depend on previous submission so we can reuse it.

            return new SeleniumUserInterfaceCompilation(
                this.CompilationName,
                this.Options,
                this.ExternalReferences,
                info?.PreviousScriptCompilation,
                info?.ReturnType,
                info?.GlobalsType,
                info != null,
                this.GetUnboundReferenceManager(),
                reuseReferenceManager: true,
                syntaxAndDeclarations: this.SyntaxAndDeclarations);
        }

        protected override Compilation CommonWithScriptCompilationInfo(ScriptCompilationInfo info)
        {
            return this.WithScriptCompilationInfo(info);
        }

        public override bool HasCodeToEmit()
        {
            if (this.IsSubmission) return false;

            foreach (var syntaxTree in this.SyntaxTrees)
            {
                var root = syntaxTree.GetRoot();
                if (root.HasErrors)
                {
                    return false;
                }
            }

            return true;
        }

        public override bool HasSubmissionResult()
        {
            if (!this.IsSubmission) return false;

            // A submission may be empty or comprised of a single script file.
            var tree = this.SyntaxAndDeclarations.ExternalSyntaxTrees.SingleOrDefault();
            if (tree == null)
            {
                return false;
            }

            var root = tree.GetRoot();
            if (root.HasErrors)
            {
                return false;
            }

            return true;
        }

        public override bool IsAttributeType(ISymbol type)
        {
            throw new NotImplementedException();
        }

        public override bool IsSystemTypeReference(ISymbol type)
        {
            throw new NotImplementedException();
        }
    }
}

