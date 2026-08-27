
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Pronunciation dictionary list response schema.
    /// </summary>
    public sealed partial class PronunciationDictionaryListResponse
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("dictionaries")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::System.Collections.Generic.IList<global::Gradium.PronunciationDictionaryResponse> Dictionaries { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("total")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required int Total { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationDictionaryListResponse" /> class.
        /// </summary>
        /// <param name="dictionaries"></param>
        /// <param name="total"></param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public PronunciationDictionaryListResponse(
            global::System.Collections.Generic.IList<global::Gradium.PronunciationDictionaryResponse> dictionaries,
            int total)
        {
            this.Dictionaries = dictionaries ?? throw new global::System.ArgumentNullException(nameof(dictionaries));
            this.Total = total;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PronunciationDictionaryListResponse" /> class.
        /// </summary>
        public PronunciationDictionaryListResponse()
        {
        }

    }
}