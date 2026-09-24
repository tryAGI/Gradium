
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class EnhanceRequest
    {
        /// <summary>
        /// The voice to enhance: a voice id (your clone, a converted candidate or a flagship voice) or a `vox_emb_` candidate id. It keeps its language and is not modified.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("src_voice")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SrcVoice { get; set; }

        /// <summary>
        /// Number of candidates to produce. All candidates in one request are variations of the same speaker.<br/>
        /// Default Value: 1
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("n_samples")]
        public int? NSamples { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhanceRequest" /> class.
        /// </summary>
        /// <param name="srcVoice">
        /// The voice to enhance: a voice id (your clone, a converted candidate or a flagship voice) or a `vox_emb_` candidate id. It keeps its language and is not modified.
        /// </param>
        /// <param name="nSamples">
        /// Number of candidates to produce. All candidates in one request are variations of the same speaker.<br/>
        /// Default Value: 1
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public EnhanceRequest(
            string srcVoice,
            int? nSamples)
        {
            this.SrcVoice = srcVoice ?? throw new global::System.ArgumentNullException(nameof(srcVoice));
            this.NSamples = nSamples;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhanceRequest" /> class.
        /// </summary>
        public EnhanceRequest()
        {
        }

    }
}