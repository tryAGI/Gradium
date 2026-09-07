#nullable enable

namespace Gradium
{
    public partial interface IVoiceDesignClient
    {
        /// <summary>
        /// List Voice Candidates<br/>
        /// Check whether a candidate is ready, or list the candidates belonging to the authenticated organization, newest first.<br/>
        /// Pass `embedding_id` to look up a single candidate. Omit it to page through all of them with `skip` and `limit`, which is also how you recover ids you did not store. A page shorter than `limit` is the last page.<br/>
        /// A lookup for an id this organization does not hold returns `200` with an empty `embeddings` list, so check the list before indexing into it.
        /// </summary>
        /// <param name="embeddingId"></param>
        /// <param name="skip">
        /// Default Value: 0
        /// </param>
        /// <param name="limit">
        /// Default Value: 100
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceEmbeddingListResponse> ListVoiceEmbeddingsVoiceGeneratorEmbeddingsGetAsync(
            string? embeddingId = default,
            int? skip = default,
            int? limit = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// List Voice Candidates<br/>
        /// Check whether a candidate is ready, or list the candidates belonging to the authenticated organization, newest first.<br/>
        /// Pass `embedding_id` to look up a single candidate. Omit it to page through all of them with `skip` and `limit`, which is also how you recover ids you did not store. A page shorter than `limit` is the last page.<br/>
        /// A lookup for an id this organization does not hold returns `200` with an empty `embeddings` list, so check the list before indexing into it.
        /// </summary>
        /// <param name="embeddingId"></param>
        /// <param name="skip">
        /// Default Value: 0
        /// </param>
        /// <param name="limit">
        /// Default Value: 100
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.VoiceEmbeddingListResponse>> ListVoiceEmbeddingsVoiceGeneratorEmbeddingsGetAsResponseAsync(
            string? embeddingId = default,
            int? skip = default,
            int? limit = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}