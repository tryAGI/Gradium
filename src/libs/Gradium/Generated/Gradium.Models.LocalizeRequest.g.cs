
#nullable enable

namespace Gradium
{
    /// <summary>
    ///
    /// </summary>
    public sealed partial class LocalizeRequest
    {
        /// <summary>
        /// The voice to localize: a voice id (your clone, a converted candidate or a flagship voice) or a `vox_emb_` candidate id. The source is not modified.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("src_voice")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SrcVoice { get; set; }

        /// <summary>
        /// Language the candidates will speak. May equal the source language: that is an accent change.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("target_language")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Gradium.JsonConverters.LocalizeRequestTargetLanguageJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Gradium.LocalizeRequestTargetLanguage TargetLanguage { get; set; }

        /// <summary>
        /// One of the accents `GET /voice-generator/available-accents` lists for `target_language`, matched case-insensitively. Omitted: the first accent listed for that language.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("accent")]
        public string? Accent { get; set; }

        /// <summary>
        /// Opens the edit caption. Omitted: the source voice's gender tag, or the gender of the source candidate's own localization, or no gender. Clones and converted voices carry no tag, so send it for them.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("gender")]
        public global::Gradium.LocalizeRequestGender? Gender { get; set; }

        /// <summary>
        /// Number of candidates to produce. All candidates in one request are variations of the same localized speaker.<br/>
        /// Default Value: 1
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("n_samples")]
        public int? NSamples { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizeRequest" /> class.
        /// </summary>
        /// <param name="srcVoice">
        /// The voice to localize: a voice id (your clone, a converted candidate or a flagship voice) or a `vox_emb_` candidate id. The source is not modified.
        /// </param>
        /// <param name="targetLanguage">
        /// Language the candidates will speak. May equal the source language: that is an accent change.
        /// </param>
        /// <param name="accent">
        /// One of the accents `GET /voice-generator/available-accents` lists for `target_language`, matched case-insensitively. Omitted: the first accent listed for that language.
        /// </param>
        /// <param name="gender">
        /// Opens the edit caption. Omitted: the source voice's gender tag, or the gender of the source candidate's own localization, or no gender. Clones and converted voices carry no tag, so send it for them.
        /// </param>
        /// <param name="nSamples">
        /// Number of candidates to produce. All candidates in one request are variations of the same localized speaker.<br/>
        /// Default Value: 1
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public LocalizeRequest(
            string srcVoice,
            global::Gradium.LocalizeRequestTargetLanguage targetLanguage,
            string? accent,
            global::Gradium.LocalizeRequestGender? gender,
            int? nSamples)
        {
            this.SrcVoice = srcVoice ?? throw new global::System.ArgumentNullException(nameof(srcVoice));
            this.TargetLanguage = targetLanguage;
            this.Accent = accent;
            this.Gender = gender;
            this.NSamples = nSamples;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizeRequest" /> class.
        /// </summary>
        public LocalizeRequest()
        {
        }

    }
}