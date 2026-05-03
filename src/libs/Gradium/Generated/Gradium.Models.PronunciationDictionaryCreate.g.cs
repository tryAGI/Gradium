
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Pronunciation dictionary create schema.
    /// </summary>
    public sealed partial class PronunciationDictionaryCreate
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("language")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Language { get; set; }

        /// <summary>
        /// Default Value: []
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("rules")]
        public global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleCreate>? Rules { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationDictionaryCreate" /> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="description"></param>
        /// <param name="rules">
        /// Default Value: []
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public PronunciationDictionaryCreate(
            string name,
            string language,
            string? description,
            global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleCreate>? rules)
        {
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.Description = description;
            this.Language = language ?? throw new global::System.ArgumentNullException(nameof(language));
            this.Rules = rules;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationDictionaryCreate" /> class.
        /// </summary>
        public PronunciationDictionaryCreate()
        {
        }
    }
}