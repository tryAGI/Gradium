#nullable enable

namespace Gradium.JsonConverters
{
    /// <inheritdoc />
    public sealed class LocalizeRequestTargetLanguageNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Gradium.LocalizeRequestTargetLanguage?>
    {
        /// <inheritdoc />
        public override global::Gradium.LocalizeRequestTargetLanguage? Read(
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
                        return global::Gradium.LocalizeRequestTargetLanguageExtensions.ToEnum(stringValue);
                    }

                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Gradium.LocalizeRequestTargetLanguage)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Gradium.LocalizeRequestTargetLanguage?);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Gradium.LocalizeRequestTargetLanguage? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Gradium.LocalizeRequestTargetLanguageExtensions.ToValueString(value.Value));
            }
        }
    }
}
