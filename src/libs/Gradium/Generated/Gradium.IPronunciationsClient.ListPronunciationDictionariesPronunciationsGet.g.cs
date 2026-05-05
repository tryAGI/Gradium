#nullable enable

namespace Gradium
{
    public partial interface IPronunciationsClient
    {
        /// <summary>
        /// List Pronunciation Dictionaries<br/>
        /// List pronunciation dictionaries for the authenticated organization.
        /// </summary>
        /// <param name="limit">
        /// Default Value: 100
        /// </param>
        /// <param name="offset">
        /// Default Value: 0
        /// </param>
        /// <param name="language"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.PronunciationDictionaryListResponse> ListPronunciationDictionariesPronunciationsGetAsync(
            int? limit = default,
            int? offset = default,
            string? language = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// List Pronunciation Dictionaries<br/>
        /// List pronunciation dictionaries for the authenticated organization.
        /// </summary>
        /// <param name="limit">
        /// Default Value: 100
        /// </param>
        /// <param name="offset">
        /// Default Value: 0
        /// </param>
        /// <param name="language"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.PronunciationDictionaryListResponse>> ListPronunciationDictionariesPronunciationsGetAsResponseAsync(
            int? limit = default,
            int? offset = default,
            string? language = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}