#nullable enable

namespace Gradium
{
    public partial interface IVoiceLocalizationClient
    {
        /// <summary>
        /// Localize Voice<br/>
        /// Make an existing voice speak another language, or another accent of the same language, without changing who is speaking. The source can be a flagship voice, one of your clones, a converted candidate or a `vox_emb_` candidate; it is never modified.<br/>
        /// Each request creates `n_samples` new candidates that behave exactly like Voice Design candidates: poll `GET /voice-generator/embeddings` until `ready` (typically two to eight seconds), audition them with `POST /post/speech/tts` using text in the target language, keep one with `POST /voices/from-embedding`.<br/>
        /// The request is validated before anything is queued. A source with no `language` set returns `409`; set it with `PUT /voices/{voice_uid}` first. A candidate source must be ready. Pro clones cannot be localized.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceGenerationResponse> LocalizeVoiceVoiceGeneratorLocalizePostAsync(

            global::Gradium.LocalizeRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Localize Voice<br/>
        /// Make an existing voice speak another language, or another accent of the same language, without changing who is speaking. The source can be a flagship voice, one of your clones, a converted candidate or a `vox_emb_` candidate; it is never modified.<br/>
        /// Each request creates `n_samples` new candidates that behave exactly like Voice Design candidates: poll `GET /voice-generator/embeddings` until `ready` (typically two to eight seconds), audition them with `POST /post/speech/tts` using text in the target language, keep one with `POST /voices/from-embedding`.<br/>
        /// The request is validated before anything is queued. A source with no `language` set returns `409`; set it with `PUT /voices/{voice_uid}` first. A candidate source must be ready. Pro clones cannot be localized.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.VoiceGenerationResponse>> LocalizeVoiceVoiceGeneratorLocalizePostAsResponseAsync(

            global::Gradium.LocalizeRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Localize Voice<br/>
        /// Make an existing voice speak another language, or another accent of the same language, without changing who is speaking. The source can be a flagship voice, one of your clones, a converted candidate or a `vox_emb_` candidate; it is never modified.<br/>
        /// Each request creates `n_samples` new candidates that behave exactly like Voice Design candidates: poll `GET /voice-generator/embeddings` until `ready` (typically two to eight seconds), audition them with `POST /post/speech/tts` using text in the target language, keep one with `POST /voices/from-embedding`.<br/>
        /// The request is validated before anything is queued. A source with no `language` set returns `409`; set it with `PUT /voices/{voice_uid}` first. A candidate source must be ready. Pro clones cannot be localized.
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
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceGenerationResponse> LocalizeVoiceVoiceGeneratorLocalizePostAsync(
            string srcVoice,
            global::Gradium.LocalizeRequestTargetLanguage targetLanguage,
            string? accent = default,
            global::Gradium.LocalizeRequestGender? gender = default,
            int? nSamples = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}