
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Language the candidates will speak. May equal the source language: that is an accent change.
    /// </summary>
    public enum LocalizeRequestTargetLanguage
    {
        /// <summary>
        ///
        /// </summary>
        De,
        /// <summary>
        /// that is an accent change.
        /// </summary>
        En,
        /// <summary>
        /// that is an accent change.
        /// </summary>
        Es,
        /// <summary>
        ///
        /// </summary>
        Fr,
        /// <summary>
        ///
        /// </summary>
        Pt,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class LocalizeRequestTargetLanguageExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this LocalizeRequestTargetLanguage value)
        {
            return value switch
            {
                LocalizeRequestTargetLanguage.De => "de",
                LocalizeRequestTargetLanguage.En => "en",
                LocalizeRequestTargetLanguage.Es => "es",
                LocalizeRequestTargetLanguage.Fr => "fr",
                LocalizeRequestTargetLanguage.Pt => "pt",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static LocalizeRequestTargetLanguage? ToEnum(string value)
        {
            return value switch
            {
                "de" => LocalizeRequestTargetLanguage.De,
                "en" => LocalizeRequestTargetLanguage.En,
                "es" => LocalizeRequestTargetLanguage.Es,
                "fr" => LocalizeRequestTargetLanguage.Fr,
                "pt" => LocalizeRequestTargetLanguage.Pt,
                _ => null,
            };
        }
    }
}