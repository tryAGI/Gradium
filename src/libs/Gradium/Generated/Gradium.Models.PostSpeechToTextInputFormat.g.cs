
#nullable enable

namespace Gradium
{
    /// <summary>
    /// 
    /// </summary>
    public enum PostSpeechToTextInputFormat
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
    public static class PostSpeechToTextInputFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this PostSpeechToTextInputFormat value)
        {
            return value switch
            {
                PostSpeechToTextInputFormat.Opus => "opus",
                PostSpeechToTextInputFormat.Pcm => "pcm",
                PostSpeechToTextInputFormat.Wav => "wav",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static PostSpeechToTextInputFormat? ToEnum(string value)
        {
            return value switch
            {
                "opus" => PostSpeechToTextInputFormat.Opus,
                "pcm" => PostSpeechToTextInputFormat.Pcm,
                "wav" => PostSpeechToTextInputFormat.Wav,
                _ => null,
            };
        }
    }
}