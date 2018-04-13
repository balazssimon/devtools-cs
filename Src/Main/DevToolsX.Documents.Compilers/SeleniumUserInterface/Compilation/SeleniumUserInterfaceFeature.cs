// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface
{
    public enum SeleniumUserInterfaceFeature
    {
        None
    }

    public static partial class SeleniumUserInterfaceFeatureExtensions
    {
        internal static string RequiredFeature(this SeleniumUserInterfaceFeature feature)
        {
            switch (feature)
            {
                default:
                    return null;
            }
        }

        internal static LanguageVersion RequiredVersion(this SeleniumUserInterfaceFeature feature)
        {
            switch (feature)
            {
                case SeleniumUserInterfaceFeature.None:
                    return LanguageVersion.SeleniumUserInterface1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(feature), "Unexpected value: "+feature);
            }
        }
    }

}

