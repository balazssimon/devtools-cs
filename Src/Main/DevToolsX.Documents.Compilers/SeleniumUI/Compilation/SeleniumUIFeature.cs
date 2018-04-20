// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX.Documents.Compilers.SeleniumUI
{
    public enum SeleniumUIFeature
    {
        None
    }

    public static partial class SeleniumUIFeatureExtensions
    {
        internal static string RequiredFeature(this SeleniumUIFeature feature)
        {
            switch (feature)
            {
                default:
                    return null;
            }
        }

        internal static LanguageVersion RequiredVersion(this SeleniumUIFeature feature)
        {
            switch (feature)
            {
                case SeleniumUIFeature.None:
                    return LanguageVersion.SeleniumUI1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(feature), "Unexpected value: "+feature);
            }
        }
    }

}

