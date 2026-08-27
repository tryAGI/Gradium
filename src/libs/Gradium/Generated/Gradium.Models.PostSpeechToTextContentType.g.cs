
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public enum PostSpeechToTextContentType
    {
        /// <summary>
        ///
        /// </summary>
        AudioOgg,
        /// <summary>
        ///
        /// </summary>
        AudioOpus,
        /// <summary>
        ///
        /// </summary>
        AudioPcm,
        /// <summary>
        ///
        /// </summary>
        AudioWav,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class PostSpeechToTextContentTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this PostSpeechToTextContentType value)
        {
            return value switch
            {
                PostSpeechToTextContentType.AudioOgg => "audio/ogg",
                PostSpeechToTextContentType.AudioOpus => "audio/opus",
                PostSpeechToTextContentType.AudioPcm => "audio/pcm",
                PostSpeechToTextContentType.AudioWav => "audio/wav",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static PostSpeechToTextContentType? ToEnum(string value)
        {
            return value switch
            {
                "audio/ogg" => PostSpeechToTextContentType.AudioOgg,
                "audio/opus" => PostSpeechToTextContentType.AudioOpus,
                "audio/pcm" => PostSpeechToTextContentType.AudioPcm,
                "audio/wav" => PostSpeechToTextContentType.AudioWav,
                _ => null,
            };
        }
    }
}