
#nullable enable

namespace Gradium
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class VoiceCreateResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("uid")]
        public string? Uid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("error")]
        public string? Error { get; set; }

        /// <summary>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("was_updated")]
        public bool? WasUpdated { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceCreateResponse" /> class.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="error"></param>
        /// <param name="wasUpdated">
        /// Default Value: false
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceCreateResponse(
            string? uid,
            string? error,
            bool? wasUpdated)
        {
            this.Uid = uid;
            this.Error = error;
            this.WasUpdated = wasUpdated;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceCreateResponse" /> class.
        /// </summary>
        public VoiceCreateResponse()
        {
        }
    }
}