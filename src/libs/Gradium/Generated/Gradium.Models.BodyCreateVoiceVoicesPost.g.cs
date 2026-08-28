
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class BodyCreateVoiceVoicesPost
    {
        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("audio_file")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required byte[] AudioFile { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("audio_filename")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string AudioFilename { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("name")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Name { get; set; }

        /// <summary>
        /// Audio format. If omitted, inferred from the audio_file extension.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("input_format")]
        public string? InputFormat { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Language spoken in the audio sample.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("language")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Gradium.JsonConverters.BodyCreateVoiceVoicesPostLanguageJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Gradium.BodyCreateVoiceVoicesPostLanguage Language { get; set; }

        /// <summary>
        /// Default Value: 0
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("start_s")]
        public double? StartS { get; set; }

        /// <summary>
        /// Default Value: 10
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("timeout_s")]
        public double? TimeoutS { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyCreateVoiceVoicesPost" /> class.
        /// </summary>
        /// <param name="audioFile"></param>
        /// <param name="audioFilename"></param>
        /// <param name="name"></param>
        /// <param name="language">
        /// Language spoken in the audio sample.
        /// </param>
        /// <param name="inputFormat">
        /// Audio format. If omitted, inferred from the audio_file extension.
        /// </param>
        /// <param name="description"></param>
        /// <param name="startS">
        /// Default Value: 0
        /// </param>
        /// <param name="timeoutS">
        /// Default Value: 10
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public BodyCreateVoiceVoicesPost(
            byte[] audioFile,
            string audioFilename,
            string name,
            global::Gradium.BodyCreateVoiceVoicesPostLanguage language,
            string? inputFormat,
            string? description,
            double? startS,
            double? timeoutS)
        {
            this.AudioFile = audioFile ?? throw new global::System.ArgumentNullException(nameof(audioFile));
            this.AudioFilename = audioFilename ?? throw new global::System.ArgumentNullException(nameof(audioFilename));
            this.Name = name ?? throw new global::System.ArgumentNullException(nameof(name));
            this.InputFormat = inputFormat;
            this.Description = description;
            this.Language = language;
            this.StartS = startS;
            this.TimeoutS = timeoutS;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyCreateVoiceVoicesPost" /> class.
        /// </summary>
        public BodyCreateVoiceVoicesPost()
        {
        }

    }
}