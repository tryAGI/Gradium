#nullable enable

namespace Gradium.JsonConverters
{
    /// <inheritdoc />
    public sealed class BodyCreateVoiceVoicesPostLanguageNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Gradium.BodyCreateVoiceVoicesPostLanguage?>
    {
        /// <inheritdoc />
        public override global::Gradium.BodyCreateVoiceVoicesPostLanguage? Read(
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
                        return global::Gradium.BodyCreateVoiceVoicesPostLanguageExtensions.ToEnum(stringValue);
                    }

                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Gradium.BodyCreateVoiceVoicesPostLanguage)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Gradium.BodyCreateVoiceVoicesPostLanguage?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Gradium.BodyCreateVoiceVoicesPostLanguage? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Gradium.BodyCreateVoiceVoicesPostLanguageExtensions.ToValueString(value.Value));
            }
        }
    }
}
