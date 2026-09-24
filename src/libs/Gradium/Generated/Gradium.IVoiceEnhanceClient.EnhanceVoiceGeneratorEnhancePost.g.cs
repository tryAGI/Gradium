#nullable enable

namespace Gradium
{
    public partial interface IVoiceEnhanceClient
    {
        /// <summary>
        /// Enhance Voice<br/>
        /// Voice Enhance is in beta: output quality will keep improving.<br/>
        /// Clean up an existing voice without changing its language or who is speaking: the same speaker comes back as new candidates with background noise reduced and a quality target applied. The source can be a flagship voice, one of your clones, a converted candidate or a `vox_emb_` candidate; it is never modified. The body is `src_voice` and `n_samples` only.<br/>
        /// Each request creates `n_samples` new candidates that behave exactly like Voice Design candidates and list as `kind: enhance` with `enhance_config` filled. Poll `GET /voice-generator/embeddings` until `ready` (typically fifteen to twenty seconds), audition them with `POST /post/speech/tts` and keep one with `POST /voices/from-embedding`.<br/>
        /// The request is validated before anything is queued. The source needs a `language` (a source without one returns `409`; set it with `PUT /voices/{voice_uid}` first), a candidate source must be ready, and pro clones are not accepted.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceGenerationResponse> EnhanceVoiceGeneratorEnhancePostAsync(

            global::Gradium.EnhanceRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Enhance Voice<br/>
        /// Voice Enhance is in beta: output quality will keep improving.<br/>
        /// Clean up an existing voice without changing its language or who is speaking: the same speaker comes back as new candidates with background noise reduced and a quality target applied. The source can be a flagship voice, one of your clones, a converted candidate or a `vox_emb_` candidate; it is never modified. The body is `src_voice` and `n_samples` only.<br/>
        /// Each request creates `n_samples` new candidates that behave exactly like Voice Design candidates and list as `kind: enhance` with `enhance_config` filled. Poll `GET /voice-generator/embeddings` until `ready` (typically fifteen to twenty seconds), audition them with `POST /post/speech/tts` and keep one with `POST /voices/from-embedding`.<br/>
        /// The request is validated before anything is queued. The source needs a `language` (a source without one returns `409`; set it with `PUT /voices/{voice_uid}` first), a candidate source must be ready, and pro clones are not accepted.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.VoiceGenerationResponse>> EnhanceVoiceGeneratorEnhancePostAsResponseAsync(

            global::Gradium.EnhanceRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Enhance Voice<br/>
        /// Voice Enhance is in beta: output quality will keep improving.<br/>
        /// Clean up an existing voice without changing its language or who is speaking: the same speaker comes back as new candidates with background noise reduced and a quality target applied. The source can be a flagship voice, one of your clones, a converted candidate or a `vox_emb_` candidate; it is never modified. The body is `src_voice` and `n_samples` only.<br/>
        /// Each request creates `n_samples` new candidates that behave exactly like Voice Design candidates and list as `kind: enhance` with `enhance_config` filled. Poll `GET /voice-generator/embeddings` until `ready` (typically fifteen to twenty seconds), audition them with `POST /post/speech/tts` and keep one with `POST /voices/from-embedding`.<br/>
        /// The request is validated before anything is queued. The source needs a `language` (a source without one returns `409`; set it with `PUT /voices/{voice_uid}` first), a candidate source must be ready, and pro clones are not accepted.
        /// </summary>
        /// <param name="srcVoice">
        /// The voice to enhance: a voice id (your clone, a converted candidate or a flagship voice) or a `vox_emb_` candidate id. It keeps its language and is not modified.
        /// </param>
        /// <param name="nSamples">
        /// Number of candidates to produce. All candidates in one request are variations of the same speaker.<br/>
        /// Default Value: 1
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceGenerationResponse> EnhanceVoiceGeneratorEnhancePostAsync(
            string srcVoice,
            int? nSamples = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}