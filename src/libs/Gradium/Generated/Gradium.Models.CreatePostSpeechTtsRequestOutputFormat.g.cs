
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Audio output format
    /// </summary>
    public enum CreatePostSpeechTtsRequestOutputFormat
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
    public static class CreatePostSpeechTtsRequestOutputFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this CreatePostSpeechTtsRequestOutputFormat value)
        {
            return value switch
            {
                CreatePostSpeechTtsRequestOutputFormat.Alaw8000 => "alaw_8000",
                CreatePostSpeechTtsRequestOutputFormat.Mulaw8000 => "mulaw_8000",
                CreatePostSpeechTtsRequestOutputFormat.Opus => "opus",
                CreatePostSpeechTtsRequestOutputFormat.Pcm => "pcm",
                CreatePostSpeechTtsRequestOutputFormat.Pcm16000 => "pcm_16000",
                CreatePostSpeechTtsRequestOutputFormat.Pcm22050 => "pcm_22050",
                CreatePostSpeechTtsRequestOutputFormat.Pcm24000 => "pcm_24000",
                CreatePostSpeechTtsRequestOutputFormat.Pcm44100 => "pcm_44100",
                CreatePostSpeechTtsRequestOutputFormat.Pcm48000 => "pcm_48000",
                CreatePostSpeechTtsRequestOutputFormat.Pcm8000 => "pcm_8000",
                CreatePostSpeechTtsRequestOutputFormat.Ulaw8000 => "ulaw_8000",
                CreatePostSpeechTtsRequestOutputFormat.Wav => "wav",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static CreatePostSpeechTtsRequestOutputFormat? ToEnum(string value)
        {
            return value switch
            {
                "alaw_8000" => CreatePostSpeechTtsRequestOutputFormat.Alaw8000,
                "mulaw_8000" => CreatePostSpeechTtsRequestOutputFormat.Mulaw8000,
                "opus" => CreatePostSpeechTtsRequestOutputFormat.Opus,
                "pcm" => CreatePostSpeechTtsRequestOutputFormat.Pcm,
                "pcm_16000" => CreatePostSpeechTtsRequestOutputFormat.Pcm16000,
                "pcm_22050" => CreatePostSpeechTtsRequestOutputFormat.Pcm22050,
                "pcm_24000" => CreatePostSpeechTtsRequestOutputFormat.Pcm24000,
                "pcm_44100" => CreatePostSpeechTtsRequestOutputFormat.Pcm44100,
                "pcm_48000" => CreatePostSpeechTtsRequestOutputFormat.Pcm48000,
                "pcm_8000" => CreatePostSpeechTtsRequestOutputFormat.Pcm8000,
                "ulaw_8000" => CreatePostSpeechTtsRequestOutputFormat.Ulaw8000,
                "wav" => CreatePostSpeechTtsRequestOutputFormat.Wav,
                _ => null,
            };
        }
    }
}