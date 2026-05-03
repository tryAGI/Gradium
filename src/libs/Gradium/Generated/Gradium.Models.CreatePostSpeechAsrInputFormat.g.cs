
#nullable enable

namespace Gradium
{
    /// <summary>
    /// 
    /// </summary>
    public enum CreatePostSpeechAsrInputFormat
    {
        /// <summary>
        /// 
        /// </summary>
        Opus,
        /// <summary>
        /// 
        /// </summary>
        Pcm,
        /// <summary>
        /// 
        /// </summary>
        Wav,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class CreatePostSpeechAsrInputFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this CreatePostSpeechAsrInputFormat value)
        {
            return value switch
            {
                CreatePostSpeechAsrInputFormat.Opus => "opus",
                CreatePostSpeechAsrInputFormat.Pcm => "pcm",
                CreatePostSpeechAsrInputFormat.Wav => "wav",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static CreatePostSpeechAsrInputFormat? ToEnum(string value)
        {
            return value switch
            {
                "opus" => CreatePostSpeechAsrInputFormat.Opus,
                "pcm" => CreatePostSpeechAsrInputFormat.Pcm,
                "wav" => CreatePostSpeechAsrInputFormat.Wav,
                _ => null,
            };
        }
    }
}