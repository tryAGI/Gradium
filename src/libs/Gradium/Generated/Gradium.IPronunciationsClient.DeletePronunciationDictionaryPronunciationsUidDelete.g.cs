#nullable enable

namespace Gradium
{
    public partial interface IPronunciationsClient
    {
        /// <summary>
        /// Delete Pronunciation Dictionary<br/>
        /// Delete a pronunciation dictionary by its UID.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task DeletePronunciationDictionaryPronunciationsUidDeleteAsync(
            string uid,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}