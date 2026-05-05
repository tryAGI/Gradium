#nullable enable

namespace Gradium
{
    public partial interface IVoicesClient
    {
        /// <summary>
        /// Create Voice<br/>
        /// Create a new voice for an organization with audio file upload.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceCreateResponse> CreateVoiceVoicesPostAsync(

            global::Gradium.BodyCreateVoiceVoicesPost request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create Voice<br/>
        /// Create a new voice for an organization with audio file upload.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.VoiceCreateResponse>> CreateVoiceVoicesPostAsResponseAsync(

            global::Gradium.BodyCreateVoiceVoicesPost request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create Voice<br/>
        /// Create a new voice for an organization with audio file upload.
        /// </summary>
        /// <param name="audioFile"></param>
        /// <param name="audioFilename"></param>
        /// <param name="name"></param>
        /// <param name="inputFormat">
        /// Audio format. If omitted, inferred from the audio_file extension.
        /// </param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="startS">
        /// Default Value: 0
        /// </param>
        /// <param name="timeoutS">
        /// Default Value: 10
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceCreateResponse> CreateVoiceVoicesPostAsync(
            byte[] audioFile,
            string audioFilename,
            string name,
            string? inputFormat = default,
            string? description = default,
            string? language = default,
            double? startS = default,
            double? timeoutS = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);

        /// <summary>
        /// Create Voice<br/>
        /// Create a new voice for an organization with audio file upload.
        /// </summary>
        /// <param name="audioFile">
        /// The stream to send as the multipart 'audio_file' file part.
        /// </param>
        /// <param name="audioFilename"></param>
        /// <param name="name"></param>
        /// <param name="inputFormat">
        /// Audio format. If omitted, inferred from the audio_file extension.
        /// </param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="startS">
        /// Default Value: 0
        /// </param>
        /// <param name="timeoutS">
        /// Default Value: 10
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.VoiceCreateResponse> CreateVoiceVoicesPostAsync(
            global::System.IO.Stream audioFile,
            string audioFilename,
            string name,
            string? inputFormat = default,
            string? description = default,
            string? language = default,
            double? startS = default,
            double? timeoutS = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Create Voice<br/>
        /// Create a new voice for an organization with audio file upload.
        /// </summary>
        /// <param name="audioFile">
        /// The stream to send as the multipart 'audio_file' file part.
        /// </param>
        /// <param name="audioFilename"></param>
        /// <param name="name"></param>
        /// <param name="inputFormat">
        /// Audio format. If omitted, inferred from the audio_file extension.
        /// </param>
        /// <param name="description"></param>
        /// <param name="language"></param>
        /// <param name="startS">
        /// Default Value: 0
        /// </param>
        /// <param name="timeoutS">
        /// Default Value: 10
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse<global::Gradium.VoiceCreateResponse>> CreateVoiceVoicesPostAsResponseAsync(
            global::System.IO.Stream audioFile,
            string audioFilename,
            string name,
            string? inputFormat = default,
            string? description = default,
            string? language = default,
            double? startS = default,
            double? timeoutS = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}