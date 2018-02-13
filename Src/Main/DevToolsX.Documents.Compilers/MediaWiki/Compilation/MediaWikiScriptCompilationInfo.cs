// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;

namespace DevToolsX.Documents.Compilers.MediaWiki
{
    public class MediaWikiScriptCompilationInfo : ScriptCompilationInfo
    {
        public new MediaWikiCompilation PreviousScriptCompilation { get; }

        internal MediaWikiScriptCompilationInfo(MediaWikiCompilation previousCompilationOpt, Type returnType, Type globalsType)
            : base(returnType, globalsType)
        {
            Debug.Assert(previousCompilationOpt == null || previousCompilationOpt.HostObjectType == globalsType);

            PreviousScriptCompilation = previousCompilationOpt;
        }

        protected override Compilation CommonPreviousScriptCompilation => PreviousScriptCompilation;

        public MediaWikiScriptCompilationInfo WithPreviousScriptCompilation(MediaWikiCompilation compilation) =>
            (compilation == PreviousScriptCompilation) ? this : new MediaWikiScriptCompilationInfo(compilation, ReturnType, GlobalsType);

        protected override ScriptCompilationInfo CommonWithPreviousScriptCompilation(Compilation compilation) =>
            WithPreviousScriptCompilation((MediaWikiCompilation)compilation);
    }
}

