
#nullable enable

namespace Gradium
{
    /// <summary>
    /// The response sent to the user in the API for external user.
    /// </summary>
    public sealed partial class APIVoiceResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("uid")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Uid { get; set; }

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
        [global::System.Text.Json.Serialization.JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("start_s")]
        public double? StartS { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("is_catalog")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required bool IsCatalog { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("is_pro_clone")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required bool IsProClone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        /// Default Value: []
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("tags")]
        public global::System.Collections.Generic.IList<global::Gradium.ExportedTag>? Tags { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="APIVoiceResponse" /> class.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="name"></param>
        /// <param name="isCatalog"></param>
        /// <param name="isProClone"></param>
        /// <param name="description"></param>
        /// <param name="filename"></param>
        /// <param name="startS"></param>
        /// <param name="language"></param>
        /// <param name="tags">
        /// Default Value: []
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public APIVoiceResponse(
            string uid,
            string name,
            bool isCatalog,
            bool isProClone,
            string? description,
            string? filename,
            double? startS,
            string? language,
            global::System.Collections.Generic.IList<global::Gradium.ExportedTag>? tags)
        {
            this.Uid = uid ?? throw new global::System.ArgumentNullException(nameof(uid));
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.Description = description;
            this.Filename = filename;
            this.StartS = startS;
            this.IsCatalog = isCatalog;
            this.IsProClone = isProClone;
            this.Language = language;
            this.Tags = tags;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="APIVoiceResponse" /> class.
        /// </summary>
        public APIVoiceResponse()
        {
        }

    }
}