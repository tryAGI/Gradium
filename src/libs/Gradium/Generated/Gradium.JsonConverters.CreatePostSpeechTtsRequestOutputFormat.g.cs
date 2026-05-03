#nullable enable

namespace Gradium.JsonConverters
{
    /// <inheritdoc />
    public sealed class CreatePostSpeechTtsRequestOutputFormatJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Gradium.CreatePostSpeechTtsRequestOutputFormat>
    {
        /// <inheritdoc />
        public override global::Gradium.CreatePostSpeechTtsRequestOutputFormat Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::Gradium.CreatePostSpeechTtsRequestOutputFormatExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Gradium.CreatePostSpeechTtsRequestOutputFormat)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Gradium.CreatePostSpeechTtsRequestOutputFormat);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Gradium.CreatePostSpeechTtsRequestOutputFormat value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Gradium.CreatePostSpeechTtsRequestOutputFormatExtensions.ToValueString(value));
        }
    }
}
