
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class VoiceFromEmbeddingCreate
    {
        /// <summary>
        /// Id of the candidate to keep, as returned by `POST /voice-generator/generate`.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("voxium_embedding_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string VoxiumEmbeddingId { get; set; }

        /// <summary>
        /// A name for the voice.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// An optional description of the voice.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceFromEmbeddingCreate" /> class.
        /// </summary>
        /// <param name="voxiumEmbeddingId">
        /// Id of the candidate to keep, as returned by `POST /voice-generator/generate`.
        /// </param>
        /// <param name="name">
        /// A name for the voice.
        /// </param>
        /// <param name="description">
        /// An optional description of the voice.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceFromEmbeddingCreate(
            string voxiumEmbeddingId,
            string name,
            string? description)
        {
            this.VoxiumEmbeddingId = voxiumEmbeddingId ?? throw new global::System.ArgumentNullException(nameof(voxiumEmbeddingId));
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceFromEmbeddingCreate" /> class.
        /// </summary>
        public VoiceFromEmbeddingCreate()
        {
        }

    }
}