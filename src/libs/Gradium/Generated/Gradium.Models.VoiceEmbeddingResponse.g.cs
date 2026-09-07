
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
        /// The description the candidate was generated from.
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
        /// The description the candidate was generated from.
        /// </param>
        /// <param name="language"></param>
        /// <param name="createdAt"></param>
        /// <param name="expiresAt"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceEmbeddingResponse(
            string embeddingId,
            bool ready,
            string? prompt,
            string? language,
            global::System.DateTime? createdAt,
            global::System.DateTime? expiresAt)
        {
            this.EmbeddingId = embeddingId ?? throw new global::System.ArgumentNullException(nameof(embeddingId));
            this.Ready = ready;
            this.Prompt = prompt;
            this.Language = language;
            this.CreatedAt = createdAt;
            this.ExpiresAt = expiresAt;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceEmbeddingResponse" /> class.
        /// </summary>
        public VoiceEmbeddingResponse()
        {
        }

    }
}