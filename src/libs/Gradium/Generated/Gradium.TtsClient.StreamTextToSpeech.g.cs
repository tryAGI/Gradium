
#nullable enable

namespace Gradium
{
    public partial class TtsClient
    {


        private static readonly global::Gradium.EndPointSecurityRequirement s_StreamTextToSpeechSecurityRequirement0 =
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
        private static readonly global::Gradium.EndPointSecurityRequirement[] s_StreamTextToSpeechSecurityRequirements =
            new global::Gradium.EndPointSecurityRequirement[]
            {                s_StreamTextToSpeechSecurityRequirement0,
            };
        partial void PrepareStreamTextToSpeechArguments(
            global::System.Net.Http.HttpClient httpClient);
        partial void PrepareStreamTextToSpeechRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage);
        partial void ProcessStreamTextToSpeechResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// TTS WebSocket Stream<br/>
        /// Connect to this endpoint via WebSocket for real-time text-to-speech conversion with low latency audio streaming.<br/>
        /// **Connection URL:**<br/>
        /// ```<br/>
        /// wss://api.gradium.ai/api/speech/tts<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the WebSocket connection header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Reference<br/>
        /// | Direction | Message Type | Example |<br/>
        /// |-----------|-------------|---------|<br/>
        /// | 🔵⬆️ Client→Server | Setup (first) | `{"type": "setup", "voice_id": "YTpq7expH9539ERJ", "model_name": "default", "output_format": "wav"}` |<br/>
        /// | 🟢⬇️ Server→Client | Ready | `{"type": "ready", "request_id": "uuid"}` |<br/>
        /// | 🔵⬆️ Client→Server | Text (stream) | `{"type": "text", "text": "Hello, world!"}` |<br/>
        /// | 🟢⬇️ Server→Client | Audio (stream) | `{"type": "audio", "audio": "base64..."}` |<br/>
        /// | 🟢⬇️ Server→Client | Text (stream) | `{"type": "text", "text": "Hello", "start_s": 0.2, "stop_s": 0.6}` |<br/>
        /// | 🔵⬆️ Client→Server | EndOfStream | `{"type": "end_of_stream"}` |<br/>
        /// | 🟢⬇️ Server→Client | AEndOfStream | `{"type": "end_of_stream"}` |<br/>
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
        ///   "voice_id": "YTpq7expH9539ERJ",<br/>
        ///   "output_format": "wav"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "setup"<br/>
        /// - `model_name` (string, optional): The TTS model to use (default: "default")<br/>
        /// - `voice_id` (string, required): Voice ID from the library (e.g., "YTpq7expH9539ERJ" for Emma's voice) or custom voice ID<br/>
        /// - `output_format` (string, optional): Audio format (default: "wav"). One of "wav", "pcm", "opus", "ulaw_8000", "mulaw_8000", "alaw_8000", "pcm_8000", "pcm_16000", "pcm_22050", "pcm_24000", "pcm_44100", "pcm_48000".<br/>
        /// **Important:** This must be the very first message sent after connection. The server will close the connection if any other message is sent first.<br/>
        /// ---<br/>
        /// ### 2. Ready Message<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "ready",<br/>
        ///   "request_id": "550e8400-e29b-41d4-a716-446655440000"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "ready"<br/>
        /// - `request_id` (string): Unique identifier for the session<br/>
        /// This message is sent by the server after receiving the setup message, indicating that the connection is ready to receive text messages.<br/>
        /// ---<br/>
        /// ### 3. Text Message (Subsequent Messages)<br/>
        /// **Direction:** Client → Server<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "text",<br/>
        ///   "text": "Hello, world!"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "text"<br/>
        /// - `text` (string, required): The text to be converted to speech<br/>
        /// Send text messages to be converted to speech. You can send multiple text messages in sequence. The server will stream audio back as it's generated.<br/>
        /// **Important: split on whitespace, not inside words or before punctuation.** When you send multiple text messages, the server inserts a single whitespace between the contents of consecutive messages. Sending `"foo"` followed by `"bar"` is therefore equivalent to sending `"foo bar"` (a whitespace is added between them), not `"foobar"`. Splitting a word across two messages will change its pronunciation. For the same reason, do not split trailing punctuation into its own message: sending `"foo"` followed by `"."` yields `"foo ."` rather than `"foo."`. Keep each message aligned to a whitespace boundary, with any trailing punctuation attached to the preceding word.<br/>
        /// ---<br/>
        /// ### 4. Audio Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "audio",<br/>
        ///   "audio": "base64_encoded_audio_data..."<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "audio"<br/>
        /// - `audio` (string): Base64-encoded audio data in the requested format<br/>
        /// When using `"pcm"` output format, the audio will adhere to the following<br/>
        /// specifications:<br/>
        /// - **Sample Rate**: 48000 Hz (48kHz)<br/>
        /// - **Format**: PCM (Pulse Code Modulation)<br/>
        /// - **Bit Depth**: 16-bit signed integer<br/>
        /// - **Channels**: Single channel (mono)<br/>
        /// - **Chunk Size**: 3840 samples per chunk (80ms at 48kHz)<br/>
        /// When using the `"wav"` output format, the audio chunks are in WAV format,<br/>
        /// at 48kHz, 16-bit signed integer mono.<br/>
        /// When using the `"opus"` output format, the audio chunks use the Opus codec<br/>
        /// wrapped in an Ogg container.<br/>
        /// Alternative output formats include `"ulaw_8000"`, `"alaw_8000"`, `"pcm_8000"`,<br/>
        /// `"pcm_16000"`, and `"pcm_24000"`.<br/>
        /// **Important:** Multiple audio messages will be streamed for each text message. Continue receiving until you detect the end of speech or receive a new message type.<br/>
        /// ---<br/>
        /// ### 5. Text Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "text",<br/>
        ///   "text": "Hello",<br/>
        ///   "start_s": 0.2,<br/>
        ///   "stop_s": 0.6<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "text"<br/>
        /// - `text` (string): The portion of text that has been generated into speech<br/>
        /// - `start_s` (float): Start time in seconds of this text segment in the audio<br/>
        /// - `stop_s` (float): Stop time in seconds of this text segment in the audio<br/>
        /// The server sends text messages back to indicate which parts of the input text<br/>
        /// have been processed into speech as well as the associated timestamps in the<br/>
        /// audio stream.<br/>
        /// ---<br/>
        /// ### 6. End Of Stream<br/>
        /// **Direction:** Client → Server and Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "end_of_stream",<br/>
        /// }<br/>
        /// ```<br/>
        /// This message is sent by the client when it has submitted all the text that it<br/>
        /// wants to be considered. The server will then send back all the remaining audio<br/>
        /// until all the text has been processed, then an `EndOfStream` message, and then<br/>
        /// closes the websocket connection.<br/>
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
        /// - `1008`: Policy Violation (e.g., invalid API key, missing setup message)<br/>
        /// - `1011`: Internal Server Error (unexpected server-side error)<br/>
        /// ---<br/>
        /// ## Best Practices<br/>
        /// 1. **Always send setup first**: The server expects a setup message immediately after connection<br/>
        /// 2. **Handle audio streaming**: Audio responses are streamed in chunks - buffer and process appropriately<br/>
        /// 3. **Implement reconnection logic**: Network issues happen - build in automatic reconnection with exponential backoff<br/>
        /// 4. **Monitor connection health**: Implement ping/pong or periodic checks to detect stale connections<br/>
        /// 5. **Graceful error handling**: Parse error messages and handle different error codes appropriately<br/>
        /// 6. **Reuse connections**: For multiple utterances, keep the connection alive and send multiple text messages<br/>
        /// 7. **Close cleanly**: Always close WebSocket connections properly when done<br/>
        /// ---
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        /// <remarks>
        /// wscat -c "wss://api.gradium.ai/api/speech/tts" \<br/>
        ///   -H "x-api-key: your_api_key"<br/>
        /// # After connection, paste:<br/>
        /// # {"type":"setup","voice_id":"YTpq7expH9539ERJ","model_name":"default","output_format":"wav"}<br/>
        /// # {"type":"text","text":"Hello, world!"}<br/>
        /// # {"type":"end_of_stream"}
        /// </remarks>
        public async global::System.Threading.Tasks.Task StreamTextToSpeechAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            await StreamTextToSpeechAsResponseAsync(
                requestOptions: requestOptions,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }
        /// <summary>
        /// TTS WebSocket Stream<br/>
        /// Connect to this endpoint via WebSocket for real-time text-to-speech conversion with low latency audio streaming.<br/>
        /// **Connection URL:**<br/>
        /// ```<br/>
        /// wss://api.gradium.ai/api/speech/tts<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the WebSocket connection header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Reference<br/>
        /// | Direction | Message Type | Example |<br/>
        /// |-----------|-------------|---------|<br/>
        /// | 🔵⬆️ Client→Server | Setup (first) | `{"type": "setup", "voice_id": "YTpq7expH9539ERJ", "model_name": "default", "output_format": "wav"}` |<br/>
        /// | 🟢⬇️ Server→Client | Ready | `{"type": "ready", "request_id": "uuid"}` |<br/>
        /// | 🔵⬆️ Client→Server | Text (stream) | `{"type": "text", "text": "Hello, world!"}` |<br/>
        /// | 🟢⬇️ Server→Client | Audio (stream) | `{"type": "audio", "audio": "base64..."}` |<br/>
        /// | 🟢⬇️ Server→Client | Text (stream) | `{"type": "text", "text": "Hello", "start_s": 0.2, "stop_s": 0.6}` |<br/>
        /// | 🔵⬆️ Client→Server | EndOfStream | `{"type": "end_of_stream"}` |<br/>
        /// | 🟢⬇️ Server→Client | AEndOfStream | `{"type": "end_of_stream"}` |<br/>
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
        ///   "voice_id": "YTpq7expH9539ERJ",<br/>
        ///   "output_format": "wav"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "setup"<br/>
        /// - `model_name` (string, optional): The TTS model to use (default: "default")<br/>
        /// - `voice_id` (string, required): Voice ID from the library (e.g., "YTpq7expH9539ERJ" for Emma's voice) or custom voice ID<br/>
        /// - `output_format` (string, optional): Audio format (default: "wav"). One of "wav", "pcm", "opus", "ulaw_8000", "mulaw_8000", "alaw_8000", "pcm_8000", "pcm_16000", "pcm_22050", "pcm_24000", "pcm_44100", "pcm_48000".<br/>
        /// **Important:** This must be the very first message sent after connection. The server will close the connection if any other message is sent first.<br/>
        /// ---<br/>
        /// ### 2. Ready Message<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "ready",<br/>
        ///   "request_id": "550e8400-e29b-41d4-a716-446655440000"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "ready"<br/>
        /// - `request_id` (string): Unique identifier for the session<br/>
        /// This message is sent by the server after receiving the setup message, indicating that the connection is ready to receive text messages.<br/>
        /// ---<br/>
        /// ### 3. Text Message (Subsequent Messages)<br/>
        /// **Direction:** Client → Server<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "text",<br/>
        ///   "text": "Hello, world!"<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string, required): Must be "text"<br/>
        /// - `text` (string, required): The text to be converted to speech<br/>
        /// Send text messages to be converted to speech. You can send multiple text messages in sequence. The server will stream audio back as it's generated.<br/>
        /// **Important: split on whitespace, not inside words or before punctuation.** When you send multiple text messages, the server inserts a single whitespace between the contents of consecutive messages. Sending `"foo"` followed by `"bar"` is therefore equivalent to sending `"foo bar"` (a whitespace is added between them), not `"foobar"`. Splitting a word across two messages will change its pronunciation. For the same reason, do not split trailing punctuation into its own message: sending `"foo"` followed by `"."` yields `"foo ."` rather than `"foo."`. Keep each message aligned to a whitespace boundary, with any trailing punctuation attached to the preceding word.<br/>
        /// ---<br/>
        /// ### 4. Audio Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "audio",<br/>
        ///   "audio": "base64_encoded_audio_data..."<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "audio"<br/>
        /// - `audio` (string): Base64-encoded audio data in the requested format<br/>
        /// When using `"pcm"` output format, the audio will adhere to the following<br/>
        /// specifications:<br/>
        /// - **Sample Rate**: 48000 Hz (48kHz)<br/>
        /// - **Format**: PCM (Pulse Code Modulation)<br/>
        /// - **Bit Depth**: 16-bit signed integer<br/>
        /// - **Channels**: Single channel (mono)<br/>
        /// - **Chunk Size**: 3840 samples per chunk (80ms at 48kHz)<br/>
        /// When using the `"wav"` output format, the audio chunks are in WAV format,<br/>
        /// at 48kHz, 16-bit signed integer mono.<br/>
        /// When using the `"opus"` output format, the audio chunks use the Opus codec<br/>
        /// wrapped in an Ogg container.<br/>
        /// Alternative output formats include `"ulaw_8000"`, `"alaw_8000"`, `"pcm_8000"`,<br/>
        /// `"pcm_16000"`, and `"pcm_24000"`.<br/>
        /// **Important:** Multiple audio messages will be streamed for each text message. Continue receiving until you detect the end of speech or receive a new message type.<br/>
        /// ---<br/>
        /// ### 5. Text Response<br/>
        /// **Direction:** Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "text",<br/>
        ///   "text": "Hello",<br/>
        ///   "start_s": 0.2,<br/>
        ///   "stop_s": 0.6<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `type` (string): Will be "text"<br/>
        /// - `text` (string): The portion of text that has been generated into speech<br/>
        /// - `start_s` (float): Start time in seconds of this text segment in the audio<br/>
        /// - `stop_s` (float): Stop time in seconds of this text segment in the audio<br/>
        /// The server sends text messages back to indicate which parts of the input text<br/>
        /// have been processed into speech as well as the associated timestamps in the<br/>
        /// audio stream.<br/>
        /// ---<br/>
        /// ### 6. End Of Stream<br/>
        /// **Direction:** Client → Server and Server → Client<br/>
        /// **Format:** JSON Object<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "type": "end_of_stream",<br/>
        /// }<br/>
        /// ```<br/>
        /// This message is sent by the client when it has submitted all the text that it<br/>
        /// wants to be considered. The server will then send back all the remaining audio<br/>
        /// until all the text has been processed, then an `EndOfStream` message, and then<br/>
        /// closes the websocket connection.<br/>
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
        /// - `1008`: Policy Violation (e.g., invalid API key, missing setup message)<br/>
        /// - `1011`: Internal Server Error (unexpected server-side error)<br/>
        /// ---<br/>
        /// ## Best Practices<br/>
        /// 1. **Always send setup first**: The server expects a setup message immediately after connection<br/>
        /// 2. **Handle audio streaming**: Audio responses are streamed in chunks - buffer and process appropriately<br/>
        /// 3. **Implement reconnection logic**: Network issues happen - build in automatic reconnection with exponential backoff<br/>
        /// 4. **Monitor connection health**: Implement ping/pong or periodic checks to detect stale connections<br/>
        /// 5. **Graceful error handling**: Parse error messages and handle different error codes appropriately<br/>
        /// 6. **Reuse connections**: For multiple utterances, keep the connection alive and send multiple text messages<br/>
        /// 7. **Close cleanly**: Always close WebSocket connections properly when done<br/>
        /// ---
        /// </summary>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        /// <remarks>
        /// wscat -c "wss://api.gradium.ai/api/speech/tts" \<br/>
        ///   -H "x-api-key: your_api_key"<br/>
        /// # After connection, paste:<br/>
        /// # {"type":"setup","voice_id":"YTpq7expH9539ERJ","model_name":"default","output_format":"wav"}<br/>
        /// # {"type":"text","text":"Hello, world!"}<br/>
        /// # {"type":"end_of_stream"}
        /// </remarks>
        public async global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse> StreamTextToSpeechAsResponseAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            PrepareArguments(
                client: HttpClient);
            PrepareStreamTextToSpeechArguments(
                httpClient: HttpClient);


            var __authorizations = global::Gradium.EndPointSecurityResolver.ResolveAuthorizations(
                availableAuthorizations: Authorizations,
                securityRequirements: s_StreamTextToSpeechSecurityRequirements,
                operationName: "StreamTextToSpeechAsync");

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
                                path: "/speech/tts",
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
                PrepareStreamTextToSpeechRequest(
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
                                operationId: "StreamTextToSpeech",
                                methodName: "StreamTextToSpeechAsync",
                                pathTemplate: "\"/speech/tts\"",
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
                                operationId: "StreamTextToSpeech",
                                methodName: "StreamTextToSpeechAsync",
                                pathTemplate: "\"/speech/tts\"",
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
                                operationId: "StreamTextToSpeech",
                                methodName: "StreamTextToSpeechAsync",
                                pathTemplate: "\"/speech/tts\"",
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
                ProcessStreamTextToSpeechResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "StreamTextToSpeech",
                                methodName: "StreamTextToSpeechAsync",
                                pathTemplate: "\"/speech/tts\"",
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
                                operationId: "StreamTextToSpeech",
                                methodName: "StreamTextToSpeechAsync",
                                pathTemplate: "\"/speech/tts\"",
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