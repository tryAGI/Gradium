#nullable enable

namespace Gradium
{
    public partial interface IPronunciationsClient
    {
        /// <summary>
        /// Create Pronunciation Dictionary<br/>
        /// Create a pronunciation dictionary for the authenticated organization.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.PronunciationDictionaryResponse> CreatePronunciationDictionaryPronunciationsPostAsync(

            global::Gradium.PronunciationDictionaryCreate request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create Pronunciation Dictionary<br/>
        /// Create a pronunciation dictionary for the authenticated organization.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="rules">
        /// Default Value: []
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.PronunciationDictionaryResponse> CreatePronunciationDictionaryPronunciationsPostAsync(
            string name,
            string language,
            string? description = default,
            global::System.Collections.Generic.IList<global::Gradium.PronunciationRuleCreate>? rules = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}