
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Language code to the accents a localization may target, in order. The first accent is the default when a request omits `accent`. The list is served live: read it from this endpoint rather than copying it from documentation.
    /// </summary>
    public sealed partial class AvailableAccentsResponseLanguages
    {

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

    }
}