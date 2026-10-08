
#nullable enable

namespace Gradium
{
    /// <summary>
    /// What a localization request asked for. Set as `edit_language_config` when `kind` is `edit_language`.
    /// </summary>
    public sealed partial class LocalizeConfig
    {
        /// <summary>
        /// The source id as given. A loose reference: the source may have been deleted since.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("src_voice")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SrcVoice { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("src_language")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string SrcLanguage { get; set; }

        /// <summary>
        ///
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("target_language")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string TargetLanguage { get; set; }

        /// <summary>
        /// The accent as resolved, default applied.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("accent")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Accent { get; set; }

        /// <summary>
        /// The gender the caption used, or `null` for a gender-free caption.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("gender")]
        public global::Gradium.LocalizeConfigGender? Gender { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizeConfig" /> class.
        /// </summary>
        /// <param name="srcVoice">
        /// The source id as given. A loose reference: the source may have been deleted since.
        /// </param>
        /// <param name="srcLanguage"></param>
        /// <param name="targetLanguage"></param>
        /// <param name="accent">
        /// The accent as resolved, default applied.
        /// </param>
        /// <param name="gender">
        /// The gender the caption used, or `null` for a gender-free caption.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public LocalizeConfig(
            string srcVoice,
            string srcLanguage,
            string targetLanguage,
            string accent,
            global::Gradium.LocalizeConfigGender? gender)
        {
            this.SrcVoice = srcVoice ?? throw new global::System.ArgumentNullException(nameof(srcVoice));
            this.SrcLanguage = srcLanguage ?? throw new global::System.ArgumentNullException(nameof(srcLanguage));
            this.TargetLanguage = targetLanguage ?? throw new global::System.ArgumentNullException(nameof(targetLanguage));
            this.Accent = accent ?? throw new global::System.ArgumentNullException(nameof(accent));
            this.Gender = gender;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizeConfig" /> class.
        /// </summary>
        public LocalizeConfig()
        {
        }

    }
}