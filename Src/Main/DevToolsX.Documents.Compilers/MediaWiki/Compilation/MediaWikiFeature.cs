// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsX.Documents.Compilers.MediaWiki
{
    public enum MediaWikiFeature
    {
        None
    }

    public static partial class MediaWikiFeatureExtensions
    {
        internal static string RequiredFeature(this MediaWikiFeature feature)
        {
            switch (feature)
            {
                default:
                    return null;
            }
        }

        internal static LanguageVersion RequiredVersion(this MediaWikiFeature feature)
        {
            switch (feature)
            {
                case MediaWikiFeature.None:
                    return LanguageVersion.MediaWiki1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(feature), "Unexpected value: "+feature);
            }
        }
    }

}

