// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;

namespace DevToolsX.Documents.Compilers.SeleniumUI
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public enum LanguageVersion
    {
        /// <summary>
        /// SeleniumUI language version 1.0.
        /// </summary>
        SeleniumUI1 = 1,
    }

    internal static partial class LanguageVersionExtensions
    {
        internal static bool IsValid(this LanguageVersion value)
        {
            return value >= LanguageVersion.SeleniumUI1 && value <= LanguageVersion.SeleniumUI1;
        }

        internal static object Localize(this LanguageVersion value)
        {
            return (int)value;
        }

        internal static SeleniumUIErrorCode GetErrorCode(this LanguageVersion version)
        {
            switch (version)
            {
                case LanguageVersion.SeleniumUI1:
                    return SeleniumUIErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(version), "Unexpected value: "+version);
            }
        }
    }
}

