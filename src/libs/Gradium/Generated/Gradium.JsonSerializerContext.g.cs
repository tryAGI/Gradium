
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::Gradium.JsonConverters.PostTextToSpeechRequestOutputFormatJsonConverter),

            typeof(global::Gradium.JsonConverters.PostTextToSpeechRequestOutputFormatNullableJsonConverter),

            typeof(global::Gradium.JsonConverters.PostSpeechToTextContentTypeJsonConverter),

            typeof(global::Gradium.JsonConverters.PostSpeechToTextContentTypeNullableJsonConverter),

            typeof(global::Gradium.JsonConverters.PostSpeechToTextInputFormatJsonConverter),

            typeof(global::Gradium.JsonConverters.PostSpeechToTextInputFormatNullableJsonConverter),

            typeof(global::Gradium.JsonConverters.AnyOfJsonConverter<string, int?>),

            typeof(global::Gradium.JsonConverters.AnyOfJsonConverter<string, bool?, object>),

            typeof(global::Gradium.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.APIVoiceResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(object))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(double))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Gradium.ExportedTag>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.ExportedTag))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.BodyCreateVoiceVoicesPost))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(byte[]))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.CreditsSummary))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.DateTime))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.HTTPValidationError))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Gradium.ValidationError>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.ValidationError))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PronunciationDictionaryCreate))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleCreate>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PronunciationRuleCreate))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PronunciationDictionaryListResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Gradium.PronunciationDictionaryResponse>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PronunciationDictionaryResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Guid))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleResponse>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PronunciationRuleResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PronunciationDictionaryUpdate))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Gradium.AnyOf<string, int?>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.AnyOf<string, int?>), TypeInfoPropertyName = "AnyOfStringInt322")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.VoiceCreateResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.VoiceResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.VoiceUpdate))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<object>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.AnyOf<string, bool?, object>), TypeInfoPropertyName = "AnyOfStringBooleanObject2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PostTextToSpeechRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PostTextToSpeechRequestOutputFormat), TypeInfoPropertyName = "PostTextToSpeechRequestOutputFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PostSpeechToTextContentType), TypeInfoPropertyName = "PostSpeechToTextContentType2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Gradium.PostSpeechToTextInputFormat), TypeInfoPropertyName = "PostSpeechToTextInputFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.IList<global::Gradium.APIVoiceResponse>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Gradium.ExportedTag>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Gradium.ValidationError>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Gradium.PronunciationRuleCreate>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Gradium.PronunciationDictionaryResponse>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Gradium.PronunciationRuleResponse>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Gradium.AnyOf<string, int?>>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<object>))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::System.Collections.Generic.List<global::Gradium.APIVoiceResponse>))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}