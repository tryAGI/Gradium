
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class JsonSerializerContextTypes
    {
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, string>? StringStringDictionary { get; set; }

        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.Dictionary<string, object>? StringObjectDictionary { get; set; }

        /// <summary>
        /// Runtime object lists used by dynamic JSON payloads such as tool arguments.
        /// </summary>
        public global::System.Collections.Generic.List<object>? ObjectList { get; set; }

        /// <summary>
        ///
        /// </summary>
        public global::System.Text.Json.JsonElement? JsonElement { get; set; }

        /// <summary>
        ///
        /// </summary>
        public global::Gradium.APIVoiceResponse? Type0 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string? Type1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public object? Type2 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public double? Type3 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool? Type4 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.ExportedTag>? Type5 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.ExportedTag? Type6 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.BodyCreateVoiceVoicesPost? Type7 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public byte[]? Type8 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.BodyCreateVoiceVoicesPostLanguage? Type9 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.CreditsSummary? Type10 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? Type11 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.DateTime? Type12 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.HTTPValidationError? Type13 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.ValidationError>? Type14 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.ValidationError? Type15 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PronunciationDictionaryCreate? Type16 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleCreate>? Type17 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PronunciationRuleCreate? Type18 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PronunciationDictionaryListResponse? Type19 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.PronunciationDictionaryResponse>? Type20 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PronunciationDictionaryResponse? Type21 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Guid? Type22 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleResponse>? Type23 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PronunciationRuleResponse? Type24 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PronunciationDictionaryUpdate? Type25 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.AnyOf<string, int?>>? Type26 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.AnyOf<string, int?>? Type27 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceCreateResponse? Type28 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceResponse? Type29 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceUpdate? Type30 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<object>? Type31 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.AnyOf<string, bool?, object>? Type32 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceGeneratorConfig? Type33 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceGenerationRequest? Type34 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceGenerationRequestLanguage? Type35 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.GeneratedEmbedding? Type36 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceGenerationResponse? Type37 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.GeneratedEmbedding>? Type38 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceEmbeddingResponse? Type39 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceEmbeddingListResponse? Type40 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.VoiceEmbeddingResponse>? Type41 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceFromEmbeddingCreate? Type42 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.VoiceFromEmbeddingResponse? Type43 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PostTextToSpeechRequest? Type44 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PostTextToSpeechRequestOutputFormat? Type45 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PostSpeechToTextContentType? Type46 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::Gradium.PostSpeechToTextInputFormat? Type47 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.IList<global::Gradium.APIVoiceResponse>? Type48 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.ExportedTag>? ListType0 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.ValidationError>? ListType1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.PronunciationRuleCreate>? ListType2 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.PronunciationDictionaryResponse>? ListType3 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.PronunciationRuleResponse>? ListType4 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.AnyOf<string, int?>>? ListType5 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<object>? ListType6 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.GeneratedEmbedding>? ListType7 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.VoiceEmbeddingResponse>? ListType8 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public global::System.Collections.Generic.List<global::Gradium.APIVoiceResponse>? ListType9 { get; set; }
    }
}