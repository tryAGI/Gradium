
#nullable enable

namespace Gradium
{
    /// <summary>
    /// 
    /// </summary>
    public enum CreatePostSpeechAsrContentType
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
    public static class CreatePostSpeechAsrContentTypeExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this CreatePostSpeechAsrContentType value)
        {
            return value switch
            {
                CreatePostSpeechAsrContentType.AudioOgg => "audio/ogg",
                CreatePostSpeechAsrContentType.AudioOpus => "audio/opus",
                CreatePostSpeechAsrContentType.AudioPcm => "audio/pcm",
                CreatePostSpeechAsrContentType.AudioWav => "audio/wav",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static CreatePostSpeechAsrContentType? ToEnum(string value)
        {
            return value switch
            {
                "audio/ogg" => CreatePostSpeechAsrContentType.AudioOgg,
                "audio/opus" => CreatePostSpeechAsrContentType.AudioOpus,
                "audio/pcm" => CreatePostSpeechAsrContentType.AudioPcm,
                "audio/wav" => CreatePostSpeechAsrContentType.AudioWav,
                _ => null,
            };
        }
    }
}