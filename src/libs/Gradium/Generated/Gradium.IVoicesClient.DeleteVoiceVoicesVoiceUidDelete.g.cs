#nullable enable

namespace Gradium
{
    public partial interface IVoicesClient
    {
        /// <summary>
        /// Delete Voice<br/>
        /// Delete a voice by its UID.
        /// </summary>
        /// <param name="voiceUid"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task DeleteVoiceVoicesVoiceUidDeleteAsync(
            string voiceUid,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}