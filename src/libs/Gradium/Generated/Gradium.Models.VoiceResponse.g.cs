
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Schema for voice response data.
    /// </summary>
    public sealed partial class VoiceResponse
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
        [global::System.Text.Json.Serialization.JsonPropertyName("language")]
        public string? Language { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("start_s")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required double StartS { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stop_s")]
        public double? StopS { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("filename")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Filename { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("org_uid")]
        public global::System.Guid? OrgUid { get; set; }

        /// <summary>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("is_pending")]
        public bool? IsPending { get; set; }

        /// <summary>
        /// Default Value: true
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("has_audio")]
        public bool? HasAudio { get; set; }

        /// <summary>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("is_pro_clone")]
        public bool? IsProClone { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceResponse" /> class.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="name"></param>
        /// <param name="startS"></param>
        /// <param name="filename"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="stopS"></param>
        /// <param name="orgUid"></param>
        /// <param name="isPending">
        /// Default Value: false
        /// </param>
        /// <param name="hasAudio">
        /// Default Value: true
        /// </param>
        /// <param name="isProClone">
        /// Default Value: false
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceResponse(
            string uid,
            string name,
            double startS,
            string filename,
            string? description,
            string? language,
            double? stopS,
            global::System.Guid? orgUid,
            bool? isPending,
            bool? hasAudio,
            bool? isProClone)
        {
            this.Uid = uid ?? throw new global::System.ArgumentNullException(nameof(uid));
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.Description = description;
            this.Language = language;
            this.StartS = startS;
            this.StopS = stopS;
            this.Filename = filename ?? throw new global::System.ArgumentNullException(nameof(filename));
            this.OrgUid = orgUid;
            this.IsPending = isPending;
            this.HasAudio = hasAudio;
            this.IsProClone = isProClone;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceResponse" /> class.
        /// </summary>
        public VoiceResponse()
        {
        }

    }
}