
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Pronunciation dictionary update schema.
    /// </summary>
    public sealed partial class PronunciationDictionaryUpdate
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("rules")]
        public global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleCreate>? Rules { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationDictionaryUpdate" /> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="rules"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public PronunciationDictionaryUpdate(
            string? name,
            string? description,
            string? language,
            global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleCreate>? rules)
        {
            this.Name = name;
            this.Description = description;
            this.Language = language;
            this.Rules = rules;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationDictionaryUpdate" /> class.
        /// </summary>
        public PronunciationDictionaryUpdate()
        {
        }
    }
}