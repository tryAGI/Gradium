
#nullable enable

namespace Gradium
{
    /// <summary>
    /// Advanced sampling options for voice generation. The defaults are tuned, so send only the keys you need.
    /// </summary>
    public sealed partial class VoiceGeneratorConfig
    {
        /// <summary>
        /// How closely the sampled voice follows the description. Higher is more literal and less varied.<br/>
        /// Default Value: 5F
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("cfg_scale")]
        public double? CfgScale { get; set; }

        /// <summary>
        /// Sampling steps. More steps takes more time.<br/>
        /// Default Value: 16
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("steps")]
        public int? Steps { get; set; }

        /// <summary>
        /// Fixes the noise draw. Unset by default.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("seed")]
        public int? Seed { get; set; }

        /// <summary>
        /// Target recording quality of the voice. Defaults to 3.1 for `en` and 3.0 for other languages.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("utmos_score")]
        public double? UtmosScore { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceGeneratorConfig" /> class.
        /// </summary>
        /// <param name="cfgScale">
        /// How closely the sampled voice follows the description. Higher is more literal and less varied.<br/>
        /// Default Value: 5F
        /// </param>
        /// <param name="steps">
        /// Sampling steps. More steps takes more time.<br/>
        /// Default Value: 16
        /// </param>
        /// <param name="seed">
        /// Fixes the noise draw. Unset by default.
        /// </param>
        /// <param name="utmosScore">
        /// Target recording quality of the voice. Defaults to 3.1 for `en` and 3.0 for other languages.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceGeneratorConfig(
            double? cfgScale,
            int? steps,
            int? seed,
            double? utmosScore)
        {
            this.CfgScale = cfgScale;
            this.Steps = steps;
            this.Seed = seed;
            this.UtmosScore = utmosScore;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceGeneratorConfig" /> class.
        /// </summary>
        public VoiceGeneratorConfig()
        {
        }

    }
}