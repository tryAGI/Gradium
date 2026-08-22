
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Audio output format
    /// </summary>
    public enum PostTextToSpeechRequestOutputFormat
    {
        /// <summary>
        /// 
        /// </summary>
        Alaw8000,
        /// <summary>
        /// 
        /// </summary>
        Mulaw8000,
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
        Pcm16000,
        /// <summary>
        /// 
        /// </summary>
        Pcm22050,
        /// <summary>
        /// 
        /// </summary>
        Pcm24000,
        /// <summary>
        /// 
        /// </summary>
        Pcm44100,
        /// <summary>
        /// 
        /// </summary>
        Pcm48000,
        /// <summary>
        /// 
        /// </summary>
        Pcm8000,
        /// <summary>
        /// 
        /// </summary>
        Ulaw8000,
        /// <summary>
        /// 
        /// </summary>
        Wav,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class PostTextToSpeechRequestOutputFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this PostTextToSpeechRequestOutputFormat value)
        {
            return value switch
            {
                PostTextToSpeechRequestOutputFormat.Alaw8000 => "alaw_8000",
                PostTextToSpeechRequestOutputFormat.Mulaw8000 => "mulaw_8000",
                PostTextToSpeechRequestOutputFormat.Opus => "opus",
                PostTextToSpeechRequestOutputFormat.Pcm => "pcm",
                PostTextToSpeechRequestOutputFormat.Pcm16000 => "pcm_16000",
                PostTextToSpeechRequestOutputFormat.Pcm22050 => "pcm_22050",
                PostTextToSpeechRequestOutputFormat.Pcm24000 => "pcm_24000",
                PostTextToSpeechRequestOutputFormat.Pcm44100 => "pcm_44100",
                PostTextToSpeechRequestOutputFormat.Pcm48000 => "pcm_48000",
                PostTextToSpeechRequestOutputFormat.Pcm8000 => "pcm_8000",
                PostTextToSpeechRequestOutputFormat.Ulaw8000 => "ulaw_8000",
                PostTextToSpeechRequestOutputFormat.Wav => "wav",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static PostTextToSpeechRequestOutputFormat? ToEnum(string value)
        {
            return value switch
            {
                "alaw_8000" => PostTextToSpeechRequestOutputFormat.Alaw8000,
                "mulaw_8000" => PostTextToSpeechRequestOutputFormat.Mulaw8000,
                "opus" => PostTextToSpeechRequestOutputFormat.Opus,
                "pcm" => PostTextToSpeechRequestOutputFormat.Pcm,
                "pcm_16000" => PostTextToSpeechRequestOutputFormat.Pcm16000,
                "pcm_22050" => PostTextToSpeechRequestOutputFormat.Pcm22050,
                "pcm_24000" => PostTextToSpeechRequestOutputFormat.Pcm24000,
                "pcm_44100" => PostTextToSpeechRequestOutputFormat.Pcm44100,
                "pcm_48000" => PostTextToSpeechRequestOutputFormat.Pcm48000,
                "pcm_8000" => PostTextToSpeechRequestOutputFormat.Pcm8000,
                "ulaw_8000" => PostTextToSpeechRequestOutputFormat.Ulaw8000,
                "wav" => PostTextToSpeechRequestOutputFormat.Wav,
                _ => null,
            };
        }
    }
}