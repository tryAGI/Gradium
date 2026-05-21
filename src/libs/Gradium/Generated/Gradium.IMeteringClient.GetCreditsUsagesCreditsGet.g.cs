#nullable enable

namespace Gradium
{
    public partial interface IMeteringClient
    {
        /// <summary>
        /// Get Credits<br/>
        /// Get current credit balance for the authenticated user's subscription.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.CreditsSummary> GetCreditsUsagesCreditsGetAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Get Credits<br/>
        /// Get current credit balance for the authenticated user's subscription.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.CreditsSummary>> GetCreditsUsagesCreditsGetAsResponseAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}