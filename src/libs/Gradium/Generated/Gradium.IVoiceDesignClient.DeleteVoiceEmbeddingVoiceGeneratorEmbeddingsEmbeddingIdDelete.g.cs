#nullable enable

namespace Gradium
{
    public partial interface IVoiceDesignClient
    {
        /// <summary>
        /// Delete Voice Candidate<br/>
        /// Remove a candidate you are not keeping. Candidates you leave alone are removed automatically after 30 days.<br/>
        /// Safe at any time: a voice kept from a candidate holds its own copy, so deleting the candidate leaves the voice untouched. An id that is already gone returns `404`, so treat cleanup as best effort.
        /// </summary>
        /// <param name="embeddingId"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task DeleteVoiceEmbeddingVoiceGeneratorEmbeddingsEmbeddingIdDeleteAsync(
            string embeddingId,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete Voice Candidate<br/>
        /// Remove a candidate you are not keeping. Candidates you leave alone are removed automatically after 30 days.<br/>
        /// Safe at any time: a voice kept from a candidate holds its own copy, so deleting the candidate leaves the voice untouched. An id that is already gone returns `404`, so treat cleanup as best effort.
        /// </summary>
        /// <param name="embeddingId"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse> DeleteVoiceEmbeddingVoiceGeneratorEmbeddingsEmbeddingIdDeleteAsResponseAsync(
            string embeddingId,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}