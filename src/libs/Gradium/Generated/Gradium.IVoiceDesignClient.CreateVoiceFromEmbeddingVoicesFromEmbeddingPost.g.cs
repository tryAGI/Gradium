#nullable enable

namespace Gradium
{
    public partial interface IVoiceDesignClient
    {
        /// <summary>
        /// Create Voice From Candidate<br/>
        /// Keep a generated candidate as a permanent voice in your organization.<br/>
        /// The response field `uid` is the `voice_id` every other endpoint expects: the same value under two names. From here the voice behaves like any other Gradium voice, on one-shot Text-to-Speech, the streaming WebSockets and Speech-to-Speech.<br/>
        /// Keeping a candidate is free, since generation is already accounted for, and it clears the candidate's expiry. Store the `embedding_id` to `voice_id` mapping: keeping the same candidate twice returns `409`, and your own record is the cleanest way to find the voice you already made.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceFromEmbeddingResponse> CreateVoiceFromEmbeddingVoicesFromEmbeddingPostAsync(

            global::Gradium.VoiceFromEmbeddingCreate request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create Voice From Candidate<br/>
        /// Keep a generated candidate as a permanent voice in your organization.<br/>
        /// The response field `uid` is the `voice_id` every other endpoint expects: the same value under two names. From here the voice behaves like any other Gradium voice, on one-shot Text-to-Speech, the streaming WebSockets and Speech-to-Speech.<br/>
        /// Keeping a candidate is free, since generation is already accounted for, and it clears the candidate's expiry. Store the `embedding_id` to `voice_id` mapping: keeping the same candidate twice returns `409`, and your own record is the cleanest way to find the voice you already made.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.VoiceFromEmbeddingResponse>> CreateVoiceFromEmbeddingVoicesFromEmbeddingPostAsResponseAsync(

            global::Gradium.VoiceFromEmbeddingCreate request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create Voice From Candidate<br/>
        /// Keep a generated candidate as a permanent voice in your organization.<br/>
        /// The response field `uid` is the `voice_id` every other endpoint expects: the same value under two names. From here the voice behaves like any other Gradium voice, on one-shot Text-to-Speech, the streaming WebSockets and Speech-to-Speech.<br/>
        /// Keeping a candidate is free, since generation is already accounted for, and it clears the candidate's expiry. Store the `embedding_id` to `voice_id` mapping: keeping the same candidate twice returns `409`, and your own record is the cleanest way to find the voice you already made.
        /// </summary>
        /// <param name="voxiumEmbeddingId">
        /// Id of the candidate to keep, as returned by `POST /voice-generator/generate`.
        /// </param>
        /// <param name="name">
        /// A name for the voice.
        /// </param>
        /// <param name="description">
        /// An optional description of the voice.
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceFromEmbeddingResponse> CreateVoiceFromEmbeddingVoicesFromEmbeddingPostAsync(
            string voxiumEmbeddingId,
            string name,
            string? description = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}