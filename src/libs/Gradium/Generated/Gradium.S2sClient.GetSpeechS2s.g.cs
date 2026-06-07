
#nullable enable

namespace Gradium
{
    public partial class S2sClient
    {


        private static readonly global::Gradium.EndPointSecurityRequirement s_GetSpeechS2sSecurityRequirement0 =
            new global::Gradium.EndPointSecurityRequirement
            {
                Authorizations = new global::Gradium.EndPointAuthorizationRequirement[]
                {                    new global::Gradium.EndPointAuthorizationRequirement
                    {
                        Type = "ApiKey",
                        SchemeId = "ApikeyXApiKey",
                        Location = "Header",
                        Name = "x-api-key",
                        FriendlyName = "ApiKeyInHeader",
                    },
                },
            };
        private static readonly global::Gradium.EndPointSecurityRequirement[] s_GetSpeechS2sSecurityRequirements =
            new global::Gradium.EndPointSecurityRequirement[]
            {                s_GetSpeechS2sSecurityRequirement0,
            };
        partial void PrepareGetSpeechS2sArguments(
            global::System.Net.Http.HttpClient httpClient);
        partial void PrepareGetSpeechS2sRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage);
        partial void ProcessGetSpeechS2sResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// S2S WebSocket Stream<br/>
        /// Connect to this endpoint via WebSocket for real-time speech-to-speech: incoming audio is transcribed, optionally translated, and re-synthesized into speech.<br/>
        /// **Connection URL:**<br/>
        /// ```<br/>
        /// wss://api.gradium.ai/api/speech/s2s<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the WebSocket connection header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Reference<br/>
        /// | Direction | Message Type | Example |<br/>
        /// |-----------|-------------|---------|<br/>
        /// | 🔵⬆️ Client→Server | Setup (first) | `{"type": "setup", "model_name": "default", "input_format": "pcm", "output_format": "pcm", "voice_id": "YTpq7expH9539ERJ"}` |<br/>
        /// | 🟢⬇️ Server→Client | Ready | `{"type": "ready", "request_id": "uuid", "sample_rate": 48000}` |<br/>
        /// | 🔵⬆️ Client→Server | Audio | `{"type": "audio", "audio": "base64..."}` |<br/>
        /// | 🟢⬇️ Server→Client | Text (stream) | `{"type": "text", "text": "Hello world", "start_s": 0.5, "stop_s": 1.2}` |<br/>
        /// | 🟢⬇️ Server→Client | Audio (stream) | `{"type": "audio", "audio": "base64..."}` |<br/>
        /// | 🔵⬆️ Client→Server | EndOfStream | `{"type": "end_of_stream"}` |<br/>
        /// | 🟢⬇️ Server→Client | EndOfStream | `{"type": "end_of_stream"}` |<br/>
        /// | 🔴⬇️ Server→Client | Error | `{"type": "error", "message": "Error description", "code": 1008}` |<br/>
        /// ---<br/>
        /// ## Message Types<br/>
        /// ### 1. Setup Message (First Message)<br/>
        /// **Direction:** Client → Server<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "setup",<br/>
        ///   "model_name": "default",<br/>
        ///   "input_format": "pcm",<br/>
        ///   "output_format": "pcm",<br/>
        ///   "voice_id": "YTpq7expH9539ERJ"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "setup"<br/>
        /// - `model_name` (string, optional): The speech-to-speech model to use (default: "default")<br/>
        /// - `stt_model_name` (string, optional): The speech-to-text model used to transcribe the input<br/>
        /// - `tts_model_name` (string, optional): The text-to-speech model used to synthesize the output<br/>
        /// - `input_format` (string, optional): Input audio format (default: "wav"). One of "pcm", "pcm_8000", "pcm_16000", "pcm_22050", "pcm_24000", "pcm_44100", "pcm_48000", "wav", "opus", "ulaw_8000", "mulaw_8000", "alaw_8000".<br/>
        /// - `output_format` (string, optional): Output audio format (default: "wav"). One of "wav", "pcm", "opus", "ulaw_8000", "mulaw_8000", "alaw_8000", "pcm_8000", "pcm_16000", "pcm_22050", "pcm_24000", "pcm_44100", "pcm_48000".<br/>
        /// - `voice_id` (string, optional): Voice ID from the library used for the synthesized output<br/>
        /// - `json_config` (object or string, optional): Advanced options. Set `target_language` to translate the speech (e.g. `{"target_language": "en"}`); omit it to keep the original language.<br/>
        /// **Important:** This must be the very first message sent after connection. The server will close the connection if any other message is sent first.<br/>
        /// ---<br/>
        /// ### 2. Ready Message<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "ready",<br/>
        ///   "request_id": "550e8400-e29b-41d4-a716-446655440000",<br/>
        ///   "sample_rate": 48000,<br/>
        ///   "frame_size": 3840<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "ready"<br/>
        /// - `request_id` (string): Unique identifier for the session<br/>
        /// - `sample_rate` (integer): Output sample rate in Hz<br/>
        /// - `frame_size` (integer): Output frame size in samples<br/>
        /// This message is sent by the server after receiving the setup message, indicating that the connection is ready to receive audio.<br/>
        /// ---<br/>
        /// ### 3. Audio Message<br/>
        /// **Direction:** Client → Server<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "audio",<br/>
        ///   "audio": "base64_encoded_audio_data..."<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "audio"<br/>
        /// - `audio` (string, required): Base64-encoded input audio chunk<br/>
        /// **Audio Format Requirements (for PCM input):**<br/>
        /// - **Sample Rate**: 24000 Hz (24kHz)<br/>
        /// - **Format**: PCM (Pulse Code Modulation)<br/>
        /// - **Bit Depth**: 16-bit signed integer (little-endian)<br/>
        /// - **Channels**: Single channel (mono)<br/>
        /// - **Chunk Size**: Recommended 1920 samples per frame (80ms at 24kHz)<br/>
        /// Send audio messages to be converted. The server will stream back text and synthesized audio as it processes the input.<br/>
        /// ---<br/>
        /// ### 4. Text Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "text",<br/>
        ///   "text": "Hello world",<br/>
        ///   "start_s": 0.5,<br/>
        ///   "stop_s": 1.2,<br/>
        ///   "stream_id": 0<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "text"<br/>
        /// - `text` (string): The transcribed (and translated, if `target_language` is set) text segment<br/>
        /// - `start_s` (float): Start time of the segment in seconds<br/>
        /// - `stop_s` (float): Stop time of the segment in seconds<br/>
        /// - `stream_id` (integer or null): Stream identifier<br/>
        /// ---<br/>
        /// ### 5. Audio Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "audio",<br/>
        ///   "audio": "base64_encoded_audio_data...",<br/>
        ///   "start_s": 0.0,<br/>
        ///   "stop_s": 0.08,<br/>
        ///   "stream_id": 0<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "audio"<br/>
        /// - `audio` (string): Base64-encoded output audio chunk in the requested format<br/>
        /// - `start_s` (float): Start time of the chunk in seconds<br/>
        /// - `stop_s` (float): Stop time of the chunk in seconds<br/>
        /// - `stream_id` (integer or null): Stream identifier<br/>
        /// When using `"pcm"` output format, the audio is 16-bit signed integer mono. The output sample rate is reported in the `ready` message.<br/>
        /// ---<br/>
        /// ### 6. End Of Stream<br/>
        /// **Direction:** Client → Server and Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "end_of_stream"<br/>
        /// }<br/>
        /// ```<br/>
        /// The client sends this when it has finished sending audio. The server then returns any remaining text and audio, an `end_of_stream` message, and closes the connection.<br/>
        /// ---<br/>
        /// ## Error Handling<br/>
        /// When errors occur, the server sends an error message as JSON before closing the connection:<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "error",<br/>
        ///   "message": "Error description explaining what went wrong",<br/>
        ///   "code": 1008<br/>
        /// }<br/>
        /// ```<br/>
        /// **Common Error Codes:**<br/>
        /// - `1008`: Policy Violation (e.g., invalid API key, missing setup message, invalid audio format)<br/>
        /// - `1011`: Internal Server Error (unexpected server-side error)
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        /// <remarks>
        /// wscat -c "wss://api.gradium.ai/api/speech/s2s" \<br/>
        ///   -H "x-api-key: your_api_key"<br/>
        /// # After connection, paste:<br/>
        /// # {"type":"setup","model_name":"default","input_format":"pcm","output_format":"pcm","voice_id":"YTpq7expH9539ERJ","json_config":{"target_language":"en"}}
        /// </remarks>
        public async global::System.Threading.Tasks.Task GetSpeechS2sAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            await GetSpeechS2sAsResponseAsync(
                requestOptions: requestOptions,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }
        /// <summary>
        /// S2S WebSocket Stream<br/>
        /// Connect to this endpoint via WebSocket for real-time speech-to-speech: incoming audio is transcribed, optionally translated, and re-synthesized into speech.<br/>
        /// **Connection URL:**<br/>
        /// ```<br/>
        /// wss://api.gradium.ai/api/speech/s2s<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the WebSocket connection header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Reference<br/>
        /// | Direction | Message Type | Example |<br/>
        /// |-----------|-------------|---------|<br/>
        /// | 🔵⬆️ Client→Server | Setup (first) | `{"type": "setup", "model_name": "default", "input_format": "pcm", "output_format": "pcm", "voice_id": "YTpq7expH9539ERJ"}` |<br/>
        /// | 🟢⬇️ Server→Client | Ready | `{"type": "ready", "request_id": "uuid", "sample_rate": 48000}` |<br/>
        /// | 🔵⬆️ Client→Server | Audio | `{"type": "audio", "audio": "base64..."}` |<br/>
        /// | 🟢⬇️ Server→Client | Text (stream) | `{"type": "text", "text": "Hello world", "start_s": 0.5, "stop_s": 1.2}` |<br/>
        /// | 🟢⬇️ Server→Client | Audio (stream) | `{"type": "audio", "audio": "base64..."}` |<br/>
        /// | 🔵⬆️ Client→Server | EndOfStream | `{"type": "end_of_stream"}` |<br/>
        /// | 🟢⬇️ Server→Client | EndOfStream | `{"type": "end_of_stream"}` |<br/>
        /// | 🔴⬇️ Server→Client | Error | `{"type": "error", "message": "Error description", "code": 1008}` |<br/>
        /// ---<br/>
        /// ## Message Types<br/>
        /// ### 1. Setup Message (First Message)<br/>
        /// **Direction:** Client → Server<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "setup",<br/>
        ///   "model_name": "default",<br/>
        ///   "input_format": "pcm",<br/>
        ///   "output_format": "pcm",<br/>
        ///   "voice_id": "YTpq7expH9539ERJ"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "setup"<br/>
        /// - `model_name` (string, optional): The speech-to-speech model to use (default: "default")<br/>
        /// - `stt_model_name` (string, optional): The speech-to-text model used to transcribe the input<br/>
        /// - `tts_model_name` (string, optional): The text-to-speech model used to synthesize the output<br/>
        /// - `input_format` (string, optional): Input audio format (default: "wav"). One of "pcm", "pcm_8000", "pcm_16000", "pcm_22050", "pcm_24000", "pcm_44100", "pcm_48000", "wav", "opus", "ulaw_8000", "mulaw_8000", "alaw_8000".<br/>
        /// - `output_format` (string, optional): Output audio format (default: "wav"). One of "wav", "pcm", "opus", "ulaw_8000", "mulaw_8000", "alaw_8000", "pcm_8000", "pcm_16000", "pcm_22050", "pcm_24000", "pcm_44100", "pcm_48000".<br/>
        /// - `voice_id` (string, optional): Voice ID from the library used for the synthesized output<br/>
        /// - `json_config` (object or string, optional): Advanced options. Set `target_language` to translate the speech (e.g. `{"target_language": "en"}`); omit it to keep the original language.<br/>
        /// **Important:** This must be the very first message sent after connection. The server will close the connection if any other message is sent first.<br/>
        /// ---<br/>
        /// ### 2. Ready Message<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "ready",<br/>
        ///   "request_id": "550e8400-e29b-41d4-a716-446655440000",<br/>
        ///   "sample_rate": 48000,<br/>
        ///   "frame_size": 3840<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "ready"<br/>
        /// - `request_id` (string): Unique identifier for the session<br/>
        /// - `sample_rate` (integer): Output sample rate in Hz<br/>
        /// - `frame_size` (integer): Output frame size in samples<br/>
        /// This message is sent by the server after receiving the setup message, indicating that the connection is ready to receive audio.<br/>
        /// ---<br/>
        /// ### 3. Audio Message<br/>
        /// **Direction:** Client → Server<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "audio",<br/>
        ///   "audio": "base64_encoded_audio_data..."<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "audio"<br/>
        /// - `audio` (string, required): Base64-encoded input audio chunk<br/>
        /// **Audio Format Requirements (for PCM input):**<br/>
        /// - **Sample Rate**: 24000 Hz (24kHz)<br/>
        /// - **Format**: PCM (Pulse Code Modulation)<br/>
        /// - **Bit Depth**: 16-bit signed integer (little-endian)<br/>
        /// - **Channels**: Single channel (mono)<br/>
        /// - **Chunk Size**: Recommended 1920 samples per frame (80ms at 24kHz)<br/>
        /// Send audio messages to be converted. The server will stream back text and synthesized audio as it processes the input.<br/>
        /// ---<br/>
        /// ### 4. Text Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "text",<br/>
        ///   "text": "Hello world",<br/>
        ///   "start_s": 0.5,<br/>
        ///   "stop_s": 1.2,<br/>
        ///   "stream_id": 0<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "text"<br/>
        /// - `text` (string): The transcribed (and translated, if `target_language` is set) text segment<br/>
        /// - `start_s` (float): Start time of the segment in seconds<br/>
        /// - `stop_s` (float): Stop time of the segment in seconds<br/>
        /// - `stream_id` (integer or null): Stream identifier<br/>
        /// ---<br/>
        /// ### 5. Audio Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "audio",<br/>
        ///   "audio": "base64_encoded_audio_data...",<br/>
        ///   "start_s": 0.0,<br/>
        ///   "stop_s": 0.08,<br/>
        ///   "stream_id": 0<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "audio"<br/>
        /// - `audio` (string): Base64-encoded output audio chunk in the requested format<br/>
        /// - `start_s` (float): Start time of the chunk in seconds<br/>
        /// - `stop_s` (float): Stop time of the chunk in seconds<br/>
        /// - `stream_id` (integer or null): Stream identifier<br/>
        /// When using `"pcm"` output format, the audio is 16-bit signed integer mono. The output sample rate is reported in the `ready` message.<br/>
        /// ---<br/>
        /// ### 6. End Of Stream<br/>
        /// **Direction:** Client → Server and Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "end_of_stream"<br/>
        /// }<br/>
        /// ```<br/>
        /// The client sends this when it has finished sending audio. The server then returns any remaining text and audio, an `end_of_stream` message, and closes the connection.<br/>
        /// ---<br/>
        /// ## Error Handling<br/>
        /// When errors occur, the server sends an error message as JSON before closing the connection:<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "error",<br/>
        ///   "message": "Error description explaining what went wrong",<br/>
        ///   "code": 1008<br/>
        /// }<br/>
        /// ```<br/>
        /// **Common Error Codes:**<br/>
        /// - `1008`: Policy Violation (e.g., invalid API key, missing setup message, invalid audio format)<br/>
        /// - `1011`: Internal Server Error (unexpected server-side error)
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        /// <remarks>
        /// wscat -c "wss://api.gradium.ai/api/speech/s2s" \<br/>
        ///   -H "x-api-key: your_api_key"<br/>
        /// # After connection, paste:<br/>
        /// # {"type":"setup","model_name":"default","input_format":"pcm","output_format":"pcm","voice_id":"YTpq7expH9539ERJ","json_config":{"target_language":"en"}}
        /// </remarks>
        public async global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse> GetSpeechS2sAsResponseAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            PrepareArguments(
                client: HttpClient);
            PrepareGetSpeechS2sArguments(
                httpClient: HttpClient);


            var __authorizations = global::Gradium.EndPointSecurityResolver.ResolveAuthorizations(
                availableAuthorizations: Authorizations,
                securityRequirements: s_GetSpeechS2sSecurityRequirements,
                operationName: "GetSpeechS2sAsync");

            using var __timeoutCancellationTokenSource = global::Gradium.AutoSDKRequestOptionsSupport.CreateTimeoutCancellationTokenSource(
                clientOptions: Options,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken);
            var __effectiveCancellationToken = __timeoutCancellationTokenSource?.Token ?? cancellationToken;
            var __effectiveReadResponseAsString = global::Gradium.AutoSDKRequestOptionsSupport.GetReadResponseAsString(
                clientOptions: Options,
                requestOptions: requestOptions,
                fallbackValue: ReadResponseAsString);
            var __maxAttempts = global::Gradium.AutoSDKRequestOptionsSupport.GetMaxAttempts(
                clientOptions: Options,
                requestOptions: requestOptions,
                supportsRetry: true);

            global::System.Net.Http.HttpRequestMessage __CreateHttpRequest()
            {

                            var __pathBuilder = new global::Gradium.PathBuilder(
                                path: "/speech/s2s",
                                baseUri: HttpClient.BaseAddress);
                            var __path = __pathBuilder.ToString();
                __path = global::Gradium.AutoSDKRequestOptionsSupport.AppendQueryParameters(
                    path: __path,
                    clientParameters: Options.QueryParameters,
                    requestParameters: requestOptions?.QueryParameters);
                var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                    method: global::System.Net.Http.HttpMethod.Get,
                    requestUri: new global::System.Uri(__path, global::System.UriKind.RelativeOrAbsolute));
#if NET6_0_OR_GREATER
                __httpRequest.Version = global::System.Net.HttpVersion.Version11;
                __httpRequest.VersionPolicy = global::System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher;
#endif

            foreach (var __authorization in __authorizations)
            {
                if (__authorization.Type == "Http" ||
                    __authorization.Type == "OAuth2" ||
                    __authorization.Type == "OpenIdConnect")
                {
                    __httpRequest.Headers.Authorization = new global::System.Net.Http.Headers.AuthenticationHeaderValue(
                        scheme: __authorization.Name,
                        parameter: __authorization.Value);
                }
                else if (__authorization.Type == "ApiKey" &&
                         __authorization.Location == "Header")
                {
                    __httpRequest.Headers.Add(__authorization.Name, __authorization.Value);
                } 
            }
                global::Gradium.AutoSDKRequestOptionsSupport.ApplyHeaders(
                    request: __httpRequest,
                    clientHeaders: Options.Headers,
                    requestHeaders: requestOptions?.Headers);

                PrepareRequest(
                    client: HttpClient,
                    request: __httpRequest);
                PrepareGetSpeechS2sRequest(
                    httpClient: HttpClient,
                    httpRequestMessage: __httpRequest);

                return __httpRequest;
            }

            global::System.Net.Http.HttpRequestMessage? __httpRequest = null;
            global::System.Net.Http.HttpResponseMessage? __response = null;
            var __attemptNumber = 0;
            try
            {
                for (var __attempt = 1; __attempt <= __maxAttempts; __attempt++)
                {
                    __attemptNumber = __attempt;
                    __httpRequest = __CreateHttpRequest();
                    await global::Gradium.AutoSDKRequestOptionsSupport.OnBeforeRequestAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechS2s",
                                methodName: "GetSpeechS2sAsync",
                                pathTemplate: "\"/speech/s2s\"",
                                httpMethod: "GET",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                    try
                    {
                        __response = await HttpClient.SendAsync(
                request: __httpRequest,
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseContentRead,
                cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                    }
                    catch (global::System.Net.Http.HttpRequestException __exception)
                    {
                        var __retryDelay = global::Gradium.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: null,
                            attempt: __attempt);
                        var __willRetry = __attempt < __maxAttempts && !__effectiveCancellationToken.IsCancellationRequested;
                        await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechS2s",
                                methodName: "GetSpeechS2sAsync",
                                pathTemplate: "\"/speech/s2s\"",
                                httpMethod: "GET",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: null,
                                exception: __exception,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: __willRetry,
                                retryDelay: __willRetry ? __retryDelay : (global::System.TimeSpan?)null,
                                retryReason: "exception",
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        if (!__willRetry)
                        {
                            throw;
                        }

                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::Gradium.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    if (__response != null &&
                        __attempt < __maxAttempts &&
                        global::Gradium.AutoSDKRequestOptionsSupport.ShouldRetryStatusCode(__response.StatusCode))
                    {
                        var __retryDelay = global::Gradium.AutoSDKRequestOptionsSupport.GetRetryDelay(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            response: __response,
                            attempt: __attempt);
                        await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechS2s",
                                methodName: "GetSpeechS2sAsync",
                                pathTemplate: "\"/speech/s2s\"",
                                httpMethod: "GET",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attempt,
                                maxAttempts: __maxAttempts,
                                willRetry: true,
                                retryDelay: __retryDelay,
                                retryReason: "status:" + ((int)__response.StatusCode).ToString(global::System.Globalization.CultureInfo.InvariantCulture),
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        __response.Dispose();
                        __response = null;
                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::Gradium.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            retryDelay: __retryDelay,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    break;
                }

                if (__response == null)
                {
                    throw new global::System.InvalidOperationException("No response received.");
                }

                using (__response)
                {

                ProcessResponse(
                    client: HttpClient,
                    response: __response);
                ProcessGetSpeechS2sResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechS2s",
                                methodName: "GetSpeechS2sAsync",
                                pathTemplate: "\"/speech/s2s\"",
                                httpMethod: "GET",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechS2s",
                                methodName: "GetSpeechS2sAsync",
                                pathTemplate: "\"/speech/s2s\"",
                                httpMethod: "GET",
                                baseUri: BaseUri,
                                request: __httpRequest!,
                                response: __response,
                                exception: null,
                                clientOptions: Options,
                                requestOptions: requestOptions,
                                attempt: __attemptNumber,
                                maxAttempts: __maxAttempts,
                                willRetry: false,
                                retryDelay: null,
                                retryReason: global::System.String.Empty,
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }
                            // 
                            if ((int)__response.StatusCode == 101)
                            {
                                string? __content_101 = null;
                                global::System.Exception? __exception_101 = null;
                                try
                                {
                                    if (__effectiveReadResponseAsString)
                                    {
                                        __content_101 = await __response.Content.ReadAsStringAsync(__effectiveCancellationToken).ConfigureAwait(false);
                                    }
                                    else
                                    {
                                        __content_101 = await __response.Content.ReadAsStringAsync(__effectiveCancellationToken).ConfigureAwait(false);
                                    }
                                }
                                catch (global::System.Exception __ex)
                                {
                                    __exception_101 = __ex;
                                }


                                throw global::Gradium.ApiException.Create(
                                    statusCode: __response.StatusCode,
                                    message: __content_101 ?? __response.ReasonPhrase ?? string.Empty,
                                    innerException: __exception_101,
                                    responseBody: __content_101,
                                    responseHeaders: global::System.Linq.Enumerable.ToDictionary(
                                        __response.Headers,
                                        h => h.Key,
                                        h => h.Value));
                            }

                            if (__effectiveReadResponseAsString)
                            {
                                var __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                    __effectiveCancellationToken
                #endif
                                ).ConfigureAwait(false);

                                ProcessResponseContent(
                                    client: HttpClient,
                                    response: __response,
                                    content: ref __content);

                                try
                                {
                                    __response.EnsureSuccessStatusCode();

                return new global::Gradium.AutoSDKHttpResponse(
                                        statusCode: __response.StatusCode,
                                        headers: global::Gradium.AutoSDKHttpResponse.CreateHeaders(__response),
                                        requestUri: __response.RequestMessage?.RequestUri);
                                }
                                catch (global::System.Exception __ex)
                                {
                                    throw global::Gradium.ApiException.Create(
                                        statusCode: __response.StatusCode,
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        responseBody: __content,
                                        responseHeaders: global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value));
                                }
                            }
                            else
                            {
                                try
                                {
                                    __response.EnsureSuccessStatusCode();
                                    return new global::Gradium.AutoSDKHttpResponse(
                                        statusCode: __response.StatusCode,
                                        headers: global::Gradium.AutoSDKHttpResponse.CreateHeaders(__response),
                                        requestUri: __response.RequestMessage?.RequestUri);
                                }
                                catch (global::System.Exception __ex)
                                {
                                    string? __content = null;
                                    try
                                    {
                                        __content = await __response.Content.ReadAsStringAsync(
                #if NET5_0_OR_GREATER
                                            __effectiveCancellationToken
                #endif
                                        ).ConfigureAwait(false);
                                    }
                                    catch (global::System.Exception)
                                    {
                                    }

                                    throw global::Gradium.ApiException.Create(
                                        statusCode: __response.StatusCode,
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        responseBody: __content,
                                        responseHeaders: global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value));
                                }
                            }

                }
            }
            finally
            {
                __httpRequest?.Dispose();
            }
        }
    }
}