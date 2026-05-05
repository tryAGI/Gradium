#nullable enable

namespace Gradium
{
    public partial interface IVoicesClient
    {
        /// <summary>
        /// Update Voice<br/>
        /// Update a voice by its UID.
        /// </summary>
        /// <param name="voiceUid"></param>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceResponse> UpdateVoiceVoicesVoiceUidPutAsync(
            string voiceUid,

            global::Gradium.VoiceUpdate request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Update Voice<br/>
        /// Update a voice by its UID.
        /// </summary>
        /// <param name="voiceUid"></param>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.VoiceResponse>> UpdateVoiceVoicesVoiceUidPutAsResponseAsync(
            string voiceUid,

            global::Gradium.VoiceUpdate request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Update Voice<br/>
        /// Update a voice by its UID.
        /// </summary>
        /// <param name="voiceUid"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="startS"></param>
        /// <param name="tags"></param>
        /// <param name="rank"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceResponse> UpdateVoiceVoicesVoiceUidPutAsync(
            string voiceUid,
            string? name = default,
            string? description = default,
            string? language = default,
            double? startS = default,
            global::System.Collections.Generic.IList<object>? tags = default,
            double? rank = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}