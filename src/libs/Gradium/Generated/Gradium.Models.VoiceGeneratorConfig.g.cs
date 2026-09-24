
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
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public VoiceGeneratorConfig(
            double? cfgScale)
        {
            this.CfgScale = cfgScale;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceGeneratorConfig" /> class.
        /// </summary>
        public VoiceGeneratorConfig()
        {
        }

    }
}