#nullable enable

namespace Gradium
{
    public partial interface IPronunciationsClient
    {
        /// <summary>
        /// Update Pronunciation Dictionary<br/>
        /// Update a pronunciation dictionary by its UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.PronunciationDictionaryResponse> UpdatePronunciationDictionaryPronunciationsUidPutAsync(
            string uid,

            global::Gradium.PronunciationDictionaryUpdate request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Update Pronunciation Dictionary<br/>
        /// Update a pronunciation dictionary by its UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.PronunciationDictionaryResponse>> UpdatePronunciationDictionaryPronunciationsUidPutAsResponseAsync(
            string uid,

            global::Gradium.PronunciationDictionaryUpdate request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Update Pronunciation Dictionary<br/>
        /// Update a pronunciation dictionary by its UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="rules"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.PronunciationDictionaryResponse> UpdatePronunciationDictionaryPronunciationsUidPutAsync(
            string uid,
            string? name = default,
            string? description = default,
            string? language = default,
            global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleCreate>? rules = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}