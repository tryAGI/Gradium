
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class GeneratedEmbedding
    {
        /// <summary>
        /// Candidate id, prefixed `vox_emb_`. Pass it as `voice_id` to audition the candidate.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("embedding_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string EmbeddingId { get; set; }

        /// <summary>
        /// Whether the candidate has finished generating. Newly created candidates start as `false`.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("ready")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required bool Ready { get; set; }

        /// <summary>
        /// UTC time the candidate is removed, 30 days after creation. Cleared once you keep the candidate.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("expires_at")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratedEmbedding" /> class.
        /// </summary>
        /// <param name="embeddingId">
        /// Candidate id, prefixed `vox_emb_`. Pass it as `voice_id` to audition the candidate.
        /// </param>
        /// <param name="ready">
        /// Whether the candidate has finished generating. Newly created candidates start as `false`.
        /// </param>
        /// <param name="expiresAt">
        /// UTC time the candidate is removed, 30 days after creation. Cleared once you keep the candidate.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public GeneratedEmbedding(
            string embeddingId,
            bool ready,
            global::System.DateTime expiresAt)
        {
            this.EmbeddingId = embeddingId ?? throw new global::System.ArgumentNullException(nameof(embeddingId));
            this.Ready = ready;
            this.ExpiresAt = expiresAt;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratedEmbedding" /> class.
        /// </summary>
        public GeneratedEmbedding()
        {
        }

    }
}