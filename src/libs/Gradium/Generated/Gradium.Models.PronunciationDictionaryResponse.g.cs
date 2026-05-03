
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Pronunciation dictionary response schema.
    /// </summary>
    public sealed partial class PronunciationDictionaryResponse
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
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("uid")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Uid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("org_uid")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Guid OrgUid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("created_at")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.DateTime CreatedAt { get; set; }

        /// <summary>
        /// Default Value: []
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("rules")]
        public global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleResponse>? Rules { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationDictionaryResponse" /> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <param name="uid"></param>
        /// <param name="orgUid"></param>
        /// <param name="createdAt"></param>
        /// <param name="description"></param>
        /// <param name="rules">
        /// Default Value: []
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public PronunciationDictionaryResponse(
            string name,
            string language,
            string uid,
            global::System.Guid orgUid,
            global::System.DateTime createdAt,
            string? description,
            global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleResponse>? rules)
        {
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.Description = description;
            this.Language = language ?? throw new global::System.ArgumentNullException(nameof(language));
            this.Uid = uid ?? throw new global::System.ArgumentNullException(nameof(uid));
            this.OrgUid = orgUid;
            this.CreatedAt = createdAt;
            this.Rules = rules;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationDictionaryResponse" /> class.
        /// </summary>
        public PronunciationDictionaryResponse()
        {
        }
    }
}