
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Language the voice will speak. Shapes the accent and the delivery.
    /// </summary>
    public enum VoiceGenerationRequestLanguage
    {
        /// <summary>
        ///
        /// </summary>
        De,
        /// <summary>
        ///
        /// </summary>
        En,
        /// <summary>
        ///
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
    public static class VoiceGenerationRequestLanguageExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this VoiceGenerationRequestLanguage value)
        {
            return value switch
            {
                VoiceGenerationRequestLanguage.De => "de",
                VoiceGenerationRequestLanguage.En => "en",
                VoiceGenerationRequestLanguage.Es => "es",
                VoiceGenerationRequestLanguage.Fr => "fr",
                VoiceGenerationRequestLanguage.Pt => "pt",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static VoiceGenerationRequestLanguage? ToEnum(string value)
        {
            return value switch
            {
                "de" => VoiceGenerationRequestLanguage.De,
                "en" => VoiceGenerationRequestLanguage.En,
                "es" => VoiceGenerationRequestLanguage.Es,
                "fr" => VoiceGenerationRequestLanguage.Fr,
                "pt" => VoiceGenerationRequestLanguage.Pt,
                _ => null,
            };
        }
    }
}