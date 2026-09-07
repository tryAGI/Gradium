
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class VoiceGenerationRequest
    {
        /// <summary>
        /// The voice description, up to 500 characters. Must contain actual text, not only spaces.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Prompt { get; set; }

        /// <summary>
        /// Language the voice will speak. Shapes the accent and the delivery.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("language")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Gradium.JsonConverters.VoiceGenerationRequestLanguageJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Gradium.VoiceGenerationRequestLanguage Language { get; set; }

        /// <summary>
        /// Number of candidate voices to sample from the description. All candidates in one request are variations on the same character.<br/>
        /// Default Value: 1
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("n_samples")]
        public int? NSamples { get; set; }

        /// <summary>
        /// Advanced sampling options.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("json_config")]
        public global::Gradium.VoiceGeneratorConfig? JsonConfig { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceGenerationRequest" /> class.
        /// </summary>
        /// <param name="prompt">
        /// The voice description, up to 500 characters. Must contain actual text, not only spaces.
        /// </param>
        /// <param name="language">
        /// Language the voice will speak. Shapes the accent and the delivery.
        /// </param>
        /// <param name="nSamples">
        /// Number of candidate voices to sample from the description. All candidates in one request are variations on the same character.<br/>
        /// Default Value: 1
        /// </param>
        /// <param name="jsonConfig">
        /// Advanced sampling options.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceGenerationRequest(
            string prompt,
            global::Gradium.VoiceGenerationRequestLanguage language,
            int? nSamples,
            global::Gradium.VoiceGeneratorConfig? jsonConfig)
        {
            this.Prompt = prompt ?? throw new global::System.ArgumentNullException(nameof(prompt));
            this.Language = language;
            this.NSamples = nSamples;
            this.JsonConfig = jsonConfig;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceGenerationRequest" /> class.
        /// </summary>
        public VoiceGenerationRequest()
        {
        }

    }
}