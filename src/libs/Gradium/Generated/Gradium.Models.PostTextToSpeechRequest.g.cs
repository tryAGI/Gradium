
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class PostTextToSpeechRequest
    {
        /// <summary>
        /// The text to convert to speech
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("text")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Text { get; set; }

        /// <summary>
        /// Voice ID from the library or custom voice ID
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("voice_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string VoiceId { get; set; }

        /// <summary>
        /// Audio output format
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("output_format")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Gradium.JsonConverters.PostTextToSpeechRequestOutputFormatJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Gradium.PostTextToSpeechRequestOutputFormat OutputFormat { get; set; }

        /// <summary>
        /// When true, returns raw audio bytes instead of JSON
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("only_audio")]
        public bool? OnlyAudio { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PostTextToSpeechRequest" /> class.
        /// </summary>
        /// <param name="text">
        /// The text to convert to speech
        /// </param>
        /// <param name="voiceId">
        /// Voice ID from the library or custom voice ID
        /// </param>
        /// <param name="outputFormat">
        /// Audio output format
        /// </param>
        /// <param name="onlyAudio">
        /// When true, returns raw audio bytes instead of JSON
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public PostTextToSpeechRequest(
            string text,
            string voiceId,
            global::Gradium.PostTextToSpeechRequestOutputFormat outputFormat,
            bool? onlyAudio)
        {
            this.Text = text ?? throw new global::System.ArgumentNullException(nameof(text));
            this.VoiceId = voiceId ?? throw new global::System.ArgumentNullException(nameof(voiceId));
            this.OutputFormat = outputFormat;
            this.OnlyAudio = onlyAudio;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostTextToSpeechRequest" /> class.
        /// </summary>
        public PostTextToSpeechRequest()
        {
        }

    }
}