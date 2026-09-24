
#nullable enable

namespace Gradium
{
    /// <summary>
    /// How the candidate was made. `enhance_config` is set when `kind` is `enhance`.
    /// </summary>
    public enum VoiceEmbeddingResponseKind
    {
        /// <summary>
        ///
        /// </summary>
        Enhance,
        /// <summary>
        ///
        /// </summary>
        Generate,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class VoiceEmbeddingResponseKindExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this VoiceEmbeddingResponseKind value)
        {
            return value switch
            {
                VoiceEmbeddingResponseKind.Enhance => "enhance",
                VoiceEmbeddingResponseKind.Generate => "generate",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static VoiceEmbeddingResponseKind? ToEnum(string value)
        {
            return value switch
            {
                "enhance" => VoiceEmbeddingResponseKind.Enhance,
                "generate" => VoiceEmbeddingResponseKind.Generate,
                _ => null,
            };
        }
    }
}