// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;

namespace DevToolsX.Documents.Compilers.SeleniumUserInterface
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public enum LanguageVersion
    {
        /// <summary>
        /// SeleniumUserInterface language version 1.0.
        /// </summary>
        SeleniumUserInterface1 = 1,
    }

    internal static partial class LanguageVersionExtensions
    {
        internal static bool IsValid(this LanguageVersion value)
        {
            return value >= LanguageVersion.SeleniumUserInterface1 && value <= LanguageVersion.SeleniumUserInterface1;
        }

        internal static object Localize(this LanguageVersion value)
        {
            return (int)value;
        }

        internal static SeleniumUserInterfaceErrorCode GetErrorCode(this LanguageVersion version)
        {
            switch (version)
            {
                case LanguageVersion.SeleniumUserInterface1:
                    return SeleniumUserInterfaceErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(version), "Unexpected value: "+version);
            }
        }
    }
}

