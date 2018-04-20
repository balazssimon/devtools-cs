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

namespace DevToolsX.Documents.Compilers.SeleniumUI
{
    public class SeleniumUIScriptCompilationInfo : ScriptCompilationInfo
    {
        public new SeleniumUICompilation PreviousScriptCompilation { get; }

        internal SeleniumUIScriptCompilationInfo(SeleniumUICompilation previousCompilationOpt, Type returnType, Type globalsType)
            : base(returnType, globalsType)
        {
            Debug.Assert(previousCompilationOpt == null || previousCompilationOpt.HostObjectType == globalsType);

            PreviousScriptCompilation = previousCompilationOpt;
        }

        protected override Compilation CommonPreviousScriptCompilation => PreviousScriptCompilation;

        public SeleniumUIScriptCompilationInfo WithPreviousScriptCompilation(SeleniumUICompilation compilation) =>
            (compilation == PreviousScriptCompilation) ? this : new SeleniumUIScriptCompilationInfo(compilation, ReturnType, GlobalsType);

        protected override ScriptCompilationInfo CommonWithPreviousScriptCompilation(Compilation compilation) =>
            WithPreviousScriptCompilation((SeleniumUICompilation)compilation);
    }
}

