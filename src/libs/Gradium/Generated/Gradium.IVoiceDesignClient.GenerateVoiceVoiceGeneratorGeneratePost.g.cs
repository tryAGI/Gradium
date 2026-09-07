#nullable enable

namespace Gradium
{
    public partial interface IVoiceDesignClient
    {
        /// <summary>
        /// Generate Voice Candidates<br/>
        /// Sample candidate voices from a written description. No reference audio is involved.<br/>
        /// Generation runs in the background, so the candidate ids come back immediately with `ready: false`. Poll `GET /voice-generator/embeddings` every two seconds until each is ready, which typically takes three to five seconds for three candidates.<br/>
        /// Every request mints new ids, and the description is expanded before sampling, so the same description gives a fresh voice each time. Capture the ids from the response and carry them through the rest of the flow.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceGenerationResponse> GenerateVoiceVoiceGeneratorGeneratePostAsync(

            global::Gradium.VoiceGenerationRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Generate Voice Candidates<br/>
        /// Sample candidate voices from a written description. No reference audio is involved.<br/>
        /// Generation runs in the background, so the candidate ids come back immediately with `ready: false`. Poll `GET /voice-generator/embeddings` every two seconds until each is ready, which typically takes three to five seconds for three candidates.<br/>
        /// Every request mints new ids, and the description is expanded before sampling, so the same description gives a fresh voice each time. Capture the ids from the response and carry them through the rest of the flow.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.VoiceGenerationResponse>> GenerateVoiceVoiceGeneratorGeneratePostAsResponseAsync(

            global::Gradium.VoiceGenerationRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Generate Voice Candidates<br/>
        /// Sample candidate voices from a written description. No reference audio is involved.<br/>
        /// Generation runs in the background, so the candidate ids come back immediately with `ready: false`. Poll `GET /voice-generator/embeddings` every two seconds until each is ready, which typically takes three to five seconds for three candidates.<br/>
        /// Every request mints new ids, and the description is expanded before sampling, so the same description gives a fresh voice each time. Capture the ids from the response and carry them through the rest of the flow.
        /// </summary>
        /// <param name="prompt">
        /// The voice description, up to 500 characters. Must contain actual text, not only spaces.
        /// </param>
        /// <param name="language">
        /// Language the voice will speak. Shapes the accent and the delivery.
        /// </param>
        /// <param name="nSamples">
        /// Number of candidate voices to sample from the description. All candidates in one request are variations on the same character.<br/>
        /// Default Value: 1
        /// </param>
        /// <param name="jsonConfig">
        /// Advanced sampling options.
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceGenerationResponse> GenerateVoiceVoiceGeneratorGeneratePostAsync(
            string prompt,
            global::Gradium.VoiceGenerationRequestLanguage language,
            int? nSamples = default,
            global::Gradium.VoiceGeneratorConfig? jsonConfig = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}