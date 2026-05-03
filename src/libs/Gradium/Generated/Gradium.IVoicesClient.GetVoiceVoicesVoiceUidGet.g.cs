#nullable enable

namespace Gradium
{
    public partial interface IVoicesClient
    {
        /// <summary>
        /// Get Voice<br/>
        /// Get a voice by its UID. Optional org_uid and key_uid for access control.
        /// </summary>
        /// <param name="voiceUid"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.APIVoiceResponse> GetVoiceVoicesVoiceUidGetAsync(
            string voiceUid,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}