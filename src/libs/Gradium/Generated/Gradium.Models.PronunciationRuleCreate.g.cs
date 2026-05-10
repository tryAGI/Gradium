
#nullable enable

namespace Gradium
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class PronunciationRuleCreate
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("original")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Original { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("rewrite")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Rewrite { get; set; }

        /// <summary>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("case_sensitive")]
        public bool? CaseSensitive { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationRuleCreate" /> class.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="rewrite"></param>
        /// <param name="caseSensitive">
        /// Default Value: false
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public PronunciationRuleCreate(
            string original,
            string rewrite,
            bool? caseSensitive)
        {
            this.Original = original ?? throw new global::System.ArgumentNullException(nameof(original));
            this.Rewrite = rewrite ?? throw new global::System.ArgumentNullException(nameof(rewrite));
            this.CaseSensitive = caseSensitive;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationRuleCreate" /> class.
        /// </summary>
        public PronunciationRuleCreate()
        {
        }

    }
}