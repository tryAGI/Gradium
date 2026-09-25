
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Timestamps are UTC. Parse them as UTC whether or not a trailing `Z` is present.
    /// </summary>
    public sealed partial class VoiceEmbeddingResponse
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("embedding_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string EmbeddingId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("ready")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required bool Ready { get; set; }

        /// <summary>
        /// The description a Voice Design candidate was generated from. Empty for an enhanced candidate.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public global::System.DateTime? CreatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("expires_at")]
        public global::System.DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// How the candidate was made. `enhance_config` is set when `kind` is `enhance`.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("kind")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Gradium.JsonConverters.VoiceEmbeddingResponseKindJsonConverter))]
        public global::Gradium.VoiceEmbeddingResponseKind? Kind { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("enhance_config")]
        public global::Gradium.EnhanceConfig? EnhanceConfig { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceEmbeddingResponse" /> class.
        /// </summary>
        /// <param name="embeddingId"></param>
        /// <param name="ready"></param>
        /// <param name="prompt">
        /// The description a Voice Design candidate was generated from. Empty for an enhanced candidate.
        /// </param>
        /// <param name="language"></param>
        /// <param name="createdAt"></param>
        /// <param name="expiresAt"></param>
        /// <param name="kind">
        /// How the candidate was made. `enhance_config` is set when `kind` is `enhance`.
        /// </param>
        /// <param name="enhanceConfig"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceEmbeddingResponse(
            string embeddingId,
            bool ready,
            string? prompt,
            string? language,
            global::System.DateTime? createdAt,
            global::System.DateTime? expiresAt,
            global::Gradium.VoiceEmbeddingResponseKind? kind,
            global::Gradium.EnhanceConfig? enhanceConfig)
        {
            this.EmbeddingId = embeddingId ?? throw new global::System.ArgumentNullException(nameof(embeddingId));
            this.Ready = ready;
            this.Prompt = prompt;
            this.Language = language;
            this.CreatedAt = createdAt;
            this.ExpiresAt = expiresAt;
            this.Kind = kind;
            this.EnhanceConfig = enhanceConfig;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceEmbeddingResponse" /> class.
        /// </summary>
        public VoiceEmbeddingResponse()
        {
        }

    }
}