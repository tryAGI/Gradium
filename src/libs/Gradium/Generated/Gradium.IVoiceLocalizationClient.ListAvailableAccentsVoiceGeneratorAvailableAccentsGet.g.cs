#nullable enable

namespace Gradium
{
    public partial interface IVoiceLocalizationClient
    {
        /// <summary>
        /// List Available Accents<br/>
        /// The accents `POST /voice-generator/localize` can target, per language, in a fixed order. The first accent of each language is the default applied when a request omits `accent`.<br/>
        /// The list is the source of truth and can change: always read it from this endpoint rather than from a copy in documentation or code, then offer it to your users as a picker. Accents are matched case-insensitively and free-text accents are rejected with `422`. No rate limit or billing applies to this read.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AvailableAccentsResponse> ListAvailableAccentsVoiceGeneratorAvailableAccentsGetAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// List Available Accents<br/>
        /// The accents `POST /voice-generator/localize` can target, per language, in a fixed order. The first accent of each language is the default applied when a request omits `accent`.<br/>
        /// The list is the source of truth and can change: always read it from this endpoint rather than from a copy in documentation or code, then offer it to your users as a picker. Accents are matched case-insensitively and free-text accents are rejected with `422`. No rate limit or billing applies to this read.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.AvailableAccentsResponse>> ListAvailableAccentsVoiceGeneratorAvailableAccentsGetAsResponseAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}