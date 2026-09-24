
#nullable enable

namespace Gradium
{
    /// <summary>
    /// What an enhance request asked for. Set when `kind` is `enhance`.
    /// </summary>
    public sealed partial class EnhanceConfig
    {
        /// <summary>
        /// The source id as given. A loose reference: the source may have been deleted since.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("src_voice")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SrcVoice { get; set; }

        /// <summary>
        /// The source voice's language, which the candidate keeps.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("src_language")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SrcLanguage { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhanceConfig" /> class.
        /// </summary>
        /// <param name="srcVoice">
        /// The source id as given. A loose reference: the source may have been deleted since.
        /// </param>
        /// <param name="srcLanguage">
        /// The source voice's language, which the candidate keeps.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public EnhanceConfig(
            string srcVoice,
            string srcLanguage)
        {
            this.SrcVoice = srcVoice ?? throw new global::System.ArgumentNullException(nameof(srcVoice));
            this.SrcLanguage = srcLanguage ?? throw new global::System.ArgumentNullException(nameof(srcLanguage));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhanceConfig" /> class.
        /// </summary>
        public EnhanceConfig()
        {
        }

    }
}