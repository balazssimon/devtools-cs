// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;

namespace DevToolsX.Documents.Compilers.MediaWiki
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public enum LanguageVersion
    {
        /// <summary>
        /// MediaWiki language version 1.0.
        /// </summary>
        MediaWiki1 = 1,
    }

    internal static partial class LanguageVersionExtensions
    {
        internal static bool IsValid(this LanguageVersion value)
        {
            return value >= LanguageVersion.MediaWiki1 && value <= LanguageVersion.MediaWiki1;
        }

        internal static object Localize(this LanguageVersion value)
        {
            return (int)value;
        }

        internal static MediaWikiErrorCode GetErrorCode(this LanguageVersion version)
        {
            switch (version)
            {
                case LanguageVersion.MediaWiki1:
                    return MediaWikiErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(version), "Unexpected value: "+version);
            }
        }
    }
}

