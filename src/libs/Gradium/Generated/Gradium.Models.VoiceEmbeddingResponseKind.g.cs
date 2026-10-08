
#nullable enable

namespace Gradium
{
    /// <summary>
    /// How the candidate was made: `generate` for Voice Design, `edit_language` for Voice Localization, `enhance` for Voice Enhance. Exactly one of `generate_config`, `edit_language_config` and `enhance_config` is set: the one `kind` names.
    /// </summary>
    public enum VoiceEmbeddingResponseKind
    {
        /// <summary>
        /// `generate` for Voice Design, `edit_language` for Voice Localization, `enhance` for Voice Enhance. Exactly one of `generate_config`, `edit_language_config` and `enhance_config` is set: the one `kind` names.
        /// </summary>
        EditLanguage,
        /// <summary>
        /// `generate` for Voice Design, `edit_language` for Voice Localization, `enhance` for Voice Enhance. Exactly one of `generate_config`, `edit_language_config` and `enhance_config` is set: the one `kind` names.
        /// </summary>
        Enhance,
        /// <summary>
        /// `generate` for Voice Design, `edit_language` for Voice Localization, `enhance` for Voice Enhance. Exactly one of `generate_config`, `edit_language_config` and `enhance_config` is set: the one `kind` names.
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
                VoiceEmbeddingResponseKind.EditLanguage => "edit_language",
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
                "edit_language" => VoiceEmbeddingResponseKind.EditLanguage,
                "enhance" => VoiceEmbeddingResponseKind.Enhance,
                "generate" => VoiceEmbeddingResponseKind.Generate,
                _ => null,
            };
        }
    }
}