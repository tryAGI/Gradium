
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Language spoken in the audio sample.
    /// </summary>
    public enum BodyCreateVoiceVoicesPostLanguage
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
    public static class BodyCreateVoiceVoicesPostLanguageExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this BodyCreateVoiceVoicesPostLanguage value)
        {
            return value switch
            {
                BodyCreateVoiceVoicesPostLanguage.De => "de",
                BodyCreateVoiceVoicesPostLanguage.En => "en",
                BodyCreateVoiceVoicesPostLanguage.Es => "es",
                BodyCreateVoiceVoicesPostLanguage.Fr => "fr",
                BodyCreateVoiceVoicesPostLanguage.Pt => "pt",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static BodyCreateVoiceVoicesPostLanguage? ToEnum(string value)
        {
            return value switch
            {
                "de" => BodyCreateVoiceVoicesPostLanguage.De,
                "en" => BodyCreateVoiceVoicesPostLanguage.En,
                "es" => BodyCreateVoiceVoicesPostLanguage.Es,
                "fr" => BodyCreateVoiceVoicesPostLanguage.Fr,
                "pt" => BodyCreateVoiceVoicesPostLanguage.Pt,
                _ => null,
            };
        }
    }
}