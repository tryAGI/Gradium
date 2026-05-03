
#nullable enable

namespace Gradium
{
    public partial class SttClient
    {


        private static readonly global::Gradium.EndPointSecurityRequirement s_GetSpeechAsrSecurityRequirement0 =
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
        private static readonly global::Gradium.EndPointSecurityRequirement[] s_GetSpeechAsrSecurityRequirements =
            new global::Gradium.EndPointSecurityRequirement[]
            {                s_GetSpeechAsrSecurityRequirement0,
            };
        partial void PrepareGetSpeechAsrArguments(
            global::System.Net.Http.HttpClient httpClient);
        partial void PrepareGetSpeechAsrRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage);
        partial void ProcessGetSpeechAsrResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// STT WebSocket Stream<br/>
        /// Connect to this endpoint via WebSocket for real-time speech-to-text conversion with streaming audio input.<br/>
        /// **Connection URL:**<br/>
        /// ```<br/>
        /// wss://api.gradium.ai/api/speech/asr<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the WebSocket connection header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Reference<br/>
        /// | Direction | Message Type | Example |<br/>
        /// |-----------|-------------|---------|<br/>
        /// | 🔵⬆️ Client→Server | Setup (first) | `{"type": "setup", "model_name": "default", "input_format": "pcm"}` |<br/>
        /// | 🟢⬇️ Server→Client | Ready | `{"type": "ready", "request_id": "uuid", "model_name": "default", "sample_rate": 24000}` |<br/>
        /// | 🔵⬆️ Client→Server | Audio | `{"type": "audio", "audio": "base64..."}` |<br/>
        /// | 🟢⬇️ Server→Client | Text (result) | `{"type": "text", "text": "Hello world", "start_s": 0.5}` |<br/>
        /// | 🟢⬇️ Server→Client | VAD (activity) | `{"type": "step", "vad": [...], "step_idx": 5, "step_duration_s": 0.08}` |<br/>
        /// | 🟢⬇️ Server→Client | End Text | `{"type": "end_text", "stop_s": 2.5}` |<br/>
        /// | 🔵⬆️ Client→Server | Flush | `{"type": "flush", "flush_id": 1}` |<br/>
        /// | 🟢⬇️ Server→Client | Flushed | `{"type": "flushed", "flush_id": 1}` |<br/>
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
        ///   "input_format": "pcm"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "setup"<br/>
        /// - `model_name` (string, optional): The Speech-To-Text model to use (default: "default")<br/>
        /// - `input_format` (string, optional): Audio format (default: "wav"). One of "pcm", "pcm_8000", "pcm_16000", "pcm_22050", "pcm_24000", "pcm_44100", "pcm_48000", "wav", "opus", "ulaw_8000", "mulaw_8000", "alaw_8000".<br/>
        /// **Important:** This must be the very first message sent after connection. The server will close the connection if any other message is sent first.<br/>
        /// ---<br/>
        /// ### 2. Ready Message<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "ready",<br/>
        ///   "request_id": "550e8400-e29b-41d4-a716-446655440000",<br/>
        ///   "model_name": "default",<br/>
        ///   "sample_rate": 24000,<br/>
        ///   "frame_size": 1920,<br/>
        ///   "delay_in_frames": 0,<br/>
        ///   "text_stream_names": []<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "ready"<br/>
        /// - `request_id` (string): Unique identifier for the session<br/>
        /// - `model_name` (string): The Speech To Text model being used<br/>
        /// - `sample_rate` (integer): Expected sample rate in Hz (typically 24000)<br/>
        /// - `frame_size` (int): Number of samples by which the model processes data (typically 1920 which is equivalent to 80ms at 24kHz)<br/>
        /// - `delay_in_frames` (integer): Delay in audio frames for the model<br/>
        /// - `text_stream_names` (array): List of text stream names<br/>
        /// This message is sent by the server after receiving the setup message, indicating that the connection is ready to receive audio.<br/>
        /// ---<br/>
        /// ### 3. Audio Message<br/>
        /// **Direction:** Client → Server<br/>
        /// **Format:** JSON Object (with binary audio data)<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "audio",<br/>
        ///   "audio": "base64_encoded_audio_data..."<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "audio"<br/>
        /// - `audio` (string, required): Base64-encoded audio data<br/>
        /// **Audio Format Requirements (for PCM input):**<br/>
        /// - **Sample Rate**: 24000 Hz (24kHz)<br/>
        /// - **Format**: PCM (Pulse Code Modulation)<br/>
        /// - **Bit Depth**: 16-bit signed integer (little-endian)<br/>
        /// - **Channels**: Single channel (mono)<br/>
        /// - **Chunk Size**: Recommended 1920 samples per frame (80ms at 24kHz)<br/>
        /// When using `"wav"` input format, the audio must be a valid WAV file using<br/>
        /// PCM data (so `AudioFormat` = 1 in the WAV header). Supported bits per sample<br/>
        /// are 16, 24 and 32 bits.<br/>
        /// When using `"opus"` input format, the audio must be some ogg wrapped opus data<br/>
        /// stream.<br/>
        /// Send audio messages to be transcribed. You can send multiple audio messages in sequence. The server will stream text and VAD responses as it processes the audio.<br/>
        /// ---<br/>
        /// ### 4. Text Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "text",<br/>
        ///   "text": "Hello world",<br/>
        ///   "start_s": 0.5,<br/>
        ///   "stream_id": 0<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "text"<br/>
        /// - `text` (string): The transcribed text<br/>
        /// - `start_s` (float): Start time of the transcription in seconds<br/>
        /// - `stream_id` (integer or null): Stream identifier for tracking multiple concurrent streams<br/>
        /// Text messages contain the transcribed speech. Multiple text messages will be streamed as the audio is processed.<br/>
        /// ---<br/>
        /// ### 5. VAD Response (Voice Activity Detection)<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "step",<br/>
        ///   "vad": [<br/>
        ///     {<br/>
        ///       "horizon_s": 0.5,<br/>
        ///       "inactivity_prob": 0.05<br/>
        ///     },<br/>
        ///     {<br/>
        ///       "horizon_s": 1.0,<br/>
        ///       "inactivity_prob": 0.08<br/>
        ///     },<br/>
        ///     {<br/>
        ///       "horizon_s": 2.0,<br/>
        ///       "inactivity_prob": 0.12<br/>
        ///     }<br/>
        ///   ],<br/>
        ///   "step_idx": 5,<br/>
        ///   "step_duration_s": 0.08,<br/>
        ///   "total_duration_s": 0.4<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "step"<br/>
        /// - `vad` (array): List of VAD predictions with future horizons<br/>
        ///   - `horizon_s` (float): Lookahead duration in seconds<br/>
        ///   - `inactivity_prob` (float): Probability that voice activity has ended by this horizon in seconds.<br/>
        /// - `step_idx` (integer): The step index (increments every 80ms)<br/>
        /// - `step_duration_s` (float): Duration of this step in seconds (typically 0.08)<br/>
        /// - `total_duration_s` (float): Total duration of audio processed so far<br/>
        /// **VAD Interpretation:**<br/>
        /// - VAD messages are emitted every 80ms (one per audio frame)<br/>
        /// - Use the `inactivity_prob` value from the longest horizon to determine if the speaker has likely finished<br/>
        /// - Higher `inactivity_prob` values indicate higher confidence that speaking has ended<br/>
        /// - Recommended threshold: Use `vad[2]["inactivity_prob"]` (third prediction) as the turn-taking indicator<br/>
        /// ---<br/>
        /// ### 6. End Text Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "end_text",<br/>
        ///   "stop_s": 2.5,<br/>
        ///   "stream_id": 0<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "end_text"<br/>
        /// - `stop_s` (float): Stop time of last `text` message in seconds<br/>
        /// - `stream_id` (integer or null): Stream identifier<br/>
        /// Sent when the previous text segment has a finished and its end timestamp is<br/>
        /// available.<br/>
        /// ---<br/>
        /// ### 7. Flush Message<br/>
        /// **Direction:** Client → Server<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "flush",<br/>
        ///   "flush_id": 1<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "flush"<br/>
        /// - `flush_id` (integer, required): Identifier for this flush request, echoed back in the `flushed` reply.<br/>
        /// This message can be sent by the client to request the server to flush any<br/>
        /// buffered audio and return all outstanding text results immediately. The server<br/>
        /// will respond with a `flushed` message containing the same `flush_id` once the<br/>
        /// flush is complete.<br/>
        /// ### 8. End Of Stream<br/>
        /// **Direction:** Client → Server and Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "end_of_stream"<br/>
        /// }<br/>
        /// ```<br/>
        /// This message is sent by the client when it has finished sending audio. The server will then process any remaining audio and send back all outstanding text results, VAD information, and then an `end_of_stream` message before closing the connection.<br/>
        /// ---<br/>
        /// ## Error Handling<br/>
        /// When errors occur, the server sends an error message as JSON before closing the connection:<br/>
        /// **Error Message Format:**<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "error",<br/>
        ///   "message": "Error description explaining what went wrong",<br/>
        ///   "code": 1008<br/>
        /// }<br/>
        /// ```<br/>
        /// **Common Error Codes:**<br/>
        /// - `1008`: Policy Violation (e.g., invalid API key, missing setup message, invalid audio format)<br/>
        /// - `1011`: Internal Server Error (unexpected server-side error)<br/>
        /// ---<br/>
        /// ## Best Practices for STT<br/>
        /// 1. **Always send setup first**: The server expects a setup message immediately after connection<br/>
        /// 2. **Use correct audio format**: When using PCM, ensure audio is 24kHz PCM 16-bit mono<br/>
        /// 3. **Send appropriately sized chunks**: 1920 samples (80ms) per message is recommended<br/>
        /// 4. **Graceful shutdown**: Send `end_of_stream` when done to properly close the session<br/>
        /// 5. **VAD Threshold**: Our VAD provides estimated probabilities that the speaker would be silent for a fixed number of seconds in the future. The thresholds to trigger the end-of-the-turn decisions might be application-dependent; as a starting point we recommend looking at the horizon of 2s and trigger when the inactivity_prob is above 0.5: `turn_ended = msg["vad"][2]["inactivity_prob"] &gt; 0.5`.<br/>
        /// 5. **Acting on VAD**: Whenever you decide that the VAD probabilities warrant a decision to consider the turn ended, there is still up to `delay_in_frames` audio frames processed by the model. Instead of feeding silence from the speaker, the system can be made more reactive by flushing the remainder of the turn's transcript. For that, you can feed in `delay_in_frames` chunks of silence (vectors of zeros). If those are fed in faster than realtime, the API also has a possibility to process them faster, allowing a considerably more reactive turn-around.
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        /// <remarks>
        /// wscat -c "wss://api.gradium.ai/api/speech/asr" \<br/>
        ///   -H "x-api-key: your_api_key"<br/>
        /// # After connection, paste:<br/>
        /// # {"type":"setup","model_name":"default","input_format":"pcm"}
        /// </remarks>
        public async global::System.Threading.Tasks.Task GetSpeechAsrAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            PrepareArguments(
                client: HttpClient);
            PrepareGetSpeechAsrArguments(
                httpClient: HttpClient);


            var __authorizations = global::Gradium.EndPointSecurityResolver.ResolveAuthorizations(
                availableAuthorizations: Authorizations,
                securityRequirements: s_GetSpeechAsrSecurityRequirements,
                operationName: "GetSpeechAsrAsync");

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
                                path: "/speech/asr",
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
                PrepareGetSpeechAsrRequest(
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
                                operationId: "getSpeechAsr",
                                methodName: "GetSpeechAsrAsync",
                                pathTemplate: "\"/speech/asr\"",
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
                        var __willRetry = __attempt < __maxAttempts && !__effectiveCancellationToken.IsCancellationRequested;
                        await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechAsr",
                                methodName: "GetSpeechAsrAsync",
                                pathTemplate: "\"/speech/asr\"",
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
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        if (!__willRetry)
                        {
                            throw;
                        }

                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::Gradium.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            clientOptions: Options,
                            requestOptions: requestOptions,
                            cancellationToken: __effectiveCancellationToken).ConfigureAwait(false);
                        continue;
                    }

                    if (__response != null &&
                        __attempt < __maxAttempts &&
                        global::Gradium.AutoSDKRequestOptionsSupport.ShouldRetryStatusCode(__response.StatusCode))
                    {
                        await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechAsr",
                                methodName: "GetSpeechAsrAsync",
                                pathTemplate: "\"/speech/asr\"",
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
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                        __response.Dispose();
                        __response = null;
                        __httpRequest.Dispose();
                        __httpRequest = null;
                        await global::Gradium.AutoSDKRequestOptionsSupport.DelayBeforeRetryAsync(
                            clientOptions: Options,
                            requestOptions: requestOptions,
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
                ProcessGetSpeechAsrResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechAsr",
                                methodName: "GetSpeechAsrAsync",
                                pathTemplate: "\"/speech/asr\"",
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
                                cancellationToken: __effectiveCancellationToken)).ConfigureAwait(false);
                }
                else
                {
                    await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterErrorAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "getSpeechAsr",
                                methodName: "GetSpeechAsrAsync",
                                pathTemplate: "\"/speech/asr\"",
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

                                throw new global::Gradium.ApiException(
                                    message: __content_101 ?? __response.ReasonPhrase ?? string.Empty,
                                    innerException: __exception_101,
                                    statusCode: __response.StatusCode)
                                {
                                    ResponseBody = __content_101,
                                    ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                        __response.Headers,
                                        h => h.Key,
                                        h => h.Value),
                                };
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

                                }
                                catch (global::System.Exception __ex)
                                {
                                    throw new global::Gradium.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
                                }
                            }
                            else
                            {
                                try
                                {
                                    __response.EnsureSuccessStatusCode();
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

                                    throw new global::Gradium.ApiException(
                                        message: __content ?? __response.ReasonPhrase ?? string.Empty,
                                        innerException: __ex,
                                        statusCode: __response.StatusCode)
                                    {
                                        ResponseBody = __content,
                                        ResponseHeaders = global::System.Linq.Enumerable.ToDictionary(
                                            __response.Headers,
                                            h => h.Key,
                                            h => h.Value),
                                    };
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