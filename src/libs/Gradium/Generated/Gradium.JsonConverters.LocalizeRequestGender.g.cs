#nullable enable

namespace Gradium.JsonConverters
{
    /// <inheritdoc />
    public sealed class LocalizeRequestGenderJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Gradium.LocalizeRequestGender>
    {
        /// <inheritdoc />
        public override global::Gradium.LocalizeRequestGender Read(
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
                        return global::Gradium.LocalizeRequestGenderExtensions.ToEnum(stringValue) ?? default;
                    }

                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Gradium.LocalizeRequestGender)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Gradium.LocalizeRequestGender);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Gradium.LocalizeRequestGender value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Gradium.LocalizeRequestGenderExtensions.ToValueString(value));
        }
    }
}
