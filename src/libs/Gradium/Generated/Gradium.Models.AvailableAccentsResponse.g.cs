
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class AvailableAccentsResponse
    {
        /// <summary>
        /// Language code to the accents a localization may target, in order. The first accent is the default when a request omits `accent`. The list is served live: read it from this endpoint rather than copying it from documentation.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("languages")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IList<string>> Languages { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableAccentsResponse" /> class.
        /// </summary>
        /// <param name="languages">
        /// Language code to the accents a localization may target, in order. The first accent is the default when a request omits `accent`. The list is served live: read it from this endpoint rather than copying it from documentation.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public AvailableAccentsResponse(
            global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.IList<string>> languages)
        {
            this.Languages = languages ?? throw new global::System.ArgumentNullException(nameof(languages));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableAccentsResponse" /> class.
        /// </summary>
        public AvailableAccentsResponse()
        {
        }

    }
}