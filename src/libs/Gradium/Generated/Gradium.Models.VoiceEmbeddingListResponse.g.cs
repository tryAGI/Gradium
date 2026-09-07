
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class VoiceEmbeddingListResponse
    {
        /// <summary>
        /// Matching candidates, newest first. An id this organization does not hold returns an empty list, so check the list before indexing into it.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("embeddings")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.IList<global::Gradium.VoiceEmbeddingResponse> Embeddings { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceEmbeddingListResponse" /> class.
        /// </summary>
        /// <param name="embeddings">
        /// Matching candidates, newest first. An id this organization does not hold returns an empty list, so check the list before indexing into it.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceEmbeddingListResponse(
            global::System.Collections.Generic.IList<global::Gradium.VoiceEmbeddingResponse> embeddings)
        {
            this.Embeddings = embeddings ?? throw new global::System.ArgumentNullException(nameof(embeddings));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceEmbeddingListResponse" /> class.
        /// </summary>
        public VoiceEmbeddingListResponse()
        {
        }

    }
}