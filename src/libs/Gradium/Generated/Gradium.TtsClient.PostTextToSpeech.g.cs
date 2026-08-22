
#nullable enable

namespace Gradium
{
    public partial class TtsClient
    {


        private static readonly global::Gradium.EndPointSecurityRequirement s_PostTextToSpeechSecurityRequirement0 =
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
        private static readonly global::Gradium.EndPointSecurityRequirement[] s_PostTextToSpeechSecurityRequirements =
            new global::Gradium.EndPointSecurityRequirement[]
            {                s_PostTextToSpeechSecurityRequirement0,
            };
        partial void PreparePostTextToSpeechArguments(
            global::System.Net.Http.HttpClient httpClient,
            global::Gradium.PostTextToSpeechRequest request);
        partial void PreparePostTextToSpeechRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Gradium.PostTextToSpeechRequest request);
        partial void ProcessPostTextToSpeechResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// TTS POST Endpoint<br/>
        /// Use this HTTP POST endpoint for simple, text-to-speech conversion. The audio<br/>
        /// data is sent back in a streaming way.<br/>
        /// **Endpoint URL:**<br/>
        /// ```<br/>
        /// https://api.gradium.ai/api/post/speech/tts<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the request header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Example<br/>
        /// ```bash<br/>
        /// curl -L -X POST https://api.gradium.ai/api/post/speech/tts \<br/>
        ///   -H "x-api-key: your_api_key" \<br/>
        ///   -H "Content-Type: application/json" \<br/>
        ///   -d '{"text": "Hello, this is a test of the text to speech system.", "voice_id": "YTpq7expH9539ERJ", "output_format": "wav", "only_audio": true}' \<br/>
        ///   &gt; output.wav<br/>
        /// ```<br/>
        /// ---<br/>
        /// ## Request Format<br/>
        /// **Method:** POST<br/>
        /// **Content-Type:** application/json<br/>
        /// **Request Body:**<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "text": "Hello, this is a test of the text to speech system.",<br/>
        ///   "voice_id": "YTpq7expH9539ERJ",<br/>
        ///   "output_format": "wav",<br/>
        ///   "json_config": "{}",<br/>
        ///   "only_audio": true<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `text` (string, required): The text to be converted to speech<br/>
        /// - `voice_id` (string, required): Voice ID from the library (e.g.,<br/>
        ///   "YTpq7expH9539ERJ") or a custom voice ID<br/>
        /// - `output_format` (string, required): Audio format - "wav", "pcm", or "opus"<br/>
        ///   (ogg wrapped opus data).<br/>
        /// - `json_config` (string, optional): Additional configuration in JSON string format (e.g., `{"padding_bonus": -1.2}`)<br/>
        /// - `model_name` (string, optional): The TTS model to use (default: "default")<br/>
        /// - `only_audio` (boolean, optional): When `true`, returns only the raw audio<br/>
        ///   bytes. When `false` or omitted, returns a stream of JSON messages containing<br/>
        ///   the audio and metadata. The format is the same as with the websocket endpoint.<br/>
        /// ---<br/>
        /// ## Response Format<br/>
        /// ### When `only_audio` is `true`<br/>
        /// The response body contains the raw audio bytes in the requested format. Save directly to a file:<br/>
        /// ```bash<br/>
        /// curl ... &gt; output.wav<br/>
        /// ```<br/>
        /// **Content-Type:** Depends on the output format:<br/>
        /// - `audio/wav` for WAV format<br/>
        /// - `audio/ogg` for Ogg wrapped Opus format<br/>
        /// - `audio/pcm` for PCM format<br/>
        /// ### When `only_audio` is `false` or omitted<br/>
        /// The response is a stream of JSON messages using the same format as the<br/>
        /// WebSocket endpoint. Read the body line-by-line until it closes — the<br/>
        /// body closing signals that synthesis is complete.<br/>
        /// ## Error Handling<br/>
        /// If the request fails before the response stream has started, the server<br/>
        /// responds with `HTTP 500` and a plain-text body. Two body shapes occur:<br/>
        /// - **Upstream errors** (with a numeric code) such as authentication<br/>
        ///   failures or worker-level rejections:<br/>
        ///   ```<br/>
        ///   error from server &lt;code&gt;: &lt;reason&gt;<br/>
        ///   ```<br/>
        ///   For example, a revoked or expired API key returns<br/>
        ///   `error from server 1008: API key is revoked or expired`.<br/>
        /// - **Proxy-level rejections** (e.g. unsupported `Content-Type`, malformed<br/>
        ///   request body) come back as raw error strings without the `error from<br/>
        ///   server` prefix.<br/>
        /// In both cases the body is plain text (not JSON). Errors that occur<br/>
        /// after the response stream has started (when `only_audio` is `false`)<br/>
        /// are surfaced as `{"type": "error", ...}` JSON messages within the<br/>
        /// stream rather than as a different HTTP status.<br/>
        /// ---<br/>
        /// ## When to Use POST vs WebSocket<br/>
        /// The POST endpoint is ideal for simple, text-to-speech generations.<br/>
        /// The main difference with the WebSocket endpoint is that the input is not<br/>
        /// handled in a streaming way; the entire text is sent in one request. The audio is<br/>
        /// still streamed back to the client, allowing for efficient handling of large<br/>
        /// audio outputs and lower latency.<br/>
        /// So if your use case involves sending complete text blocks and receiving audio<br/>
        /// responses, the POST endpoint is a straightforward choice. For more interactive<br/>
        /// or real-time applications where text input is streamed, the WebSocket endpoint<br/>
        /// is more suitable.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        /// <remarks>
        /// curl -L -X POST https://api.gradium.ai/api/post/speech/tts \<br/>
        ///   -H "x-api-key: your_api_key" \<br/>
        ///   -H "Content-Type: application/json" \<br/>
        ///   -d '{"text": "Hello, world!", "voice_id": "YTpq7expH9539ERJ", "output_format": "wav", "only_audio": true}' \<br/>
        ///   &gt; output.wav
        /// </remarks>
        public async global::System.Threading.Tasks.Task PostTextToSpeechAsync(

            global::Gradium.PostTextToSpeechRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            await PostTextToSpeechAsResponseAsync(

                request: request,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);
        }
        /// <summary>
        /// TTS POST Endpoint<br/>
        /// Use this HTTP POST endpoint for simple, text-to-speech conversion. The audio<br/>
        /// data is sent back in a streaming way.<br/>
        /// **Endpoint URL:**<br/>
        /// ```<br/>
        /// https://api.gradium.ai/api/post/speech/tts<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the request header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Example<br/>
        /// ```bash<br/>
        /// curl -L -X POST https://api.gradium.ai/api/post/speech/tts \<br/>
        ///   -H "x-api-key: your_api_key" \<br/>
        ///   -H "Content-Type: application/json" \<br/>
        ///   -d '{"text": "Hello, this is a test of the text to speech system.", "voice_id": "YTpq7expH9539ERJ", "output_format": "wav", "only_audio": true}' \<br/>
        ///   &gt; output.wav<br/>
        /// ```<br/>
        /// ---<br/>
        /// ## Request Format<br/>
        /// **Method:** POST<br/>
        /// **Content-Type:** application/json<br/>
        /// **Request Body:**<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "text": "Hello, this is a test of the text to speech system.",<br/>
        ///   "voice_id": "YTpq7expH9539ERJ",<br/>
        ///   "output_format": "wav",<br/>
        ///   "json_config": "{}",<br/>
        ///   "only_audio": true<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `text` (string, required): The text to be converted to speech<br/>
        /// - `voice_id` (string, required): Voice ID from the library (e.g.,<br/>
        ///   "YTpq7expH9539ERJ") or a custom voice ID<br/>
        /// - `output_format` (string, required): Audio format - "wav", "pcm", or "opus"<br/>
        ///   (ogg wrapped opus data).<br/>
        /// - `json_config` (string, optional): Additional configuration in JSON string format (e.g., `{"padding_bonus": -1.2}`)<br/>
        /// - `model_name` (string, optional): The TTS model to use (default: "default")<br/>
        /// - `only_audio` (boolean, optional): When `true`, returns only the raw audio<br/>
        ///   bytes. When `false` or omitted, returns a stream of JSON messages containing<br/>
        ///   the audio and metadata. The format is the same as with the websocket endpoint.<br/>
        /// ---<br/>
        /// ## Response Format<br/>
        /// ### When `only_audio` is `true`<br/>
        /// The response body contains the raw audio bytes in the requested format. Save directly to a file:<br/>
        /// ```bash<br/>
        /// curl ... &gt; output.wav<br/>
        /// ```<br/>
        /// **Content-Type:** Depends on the output format:<br/>
        /// - `audio/wav` for WAV format<br/>
        /// - `audio/ogg` for Ogg wrapped Opus format<br/>
        /// - `audio/pcm` for PCM format<br/>
        /// ### When `only_audio` is `false` or omitted<br/>
        /// The response is a stream of JSON messages using the same format as the<br/>
        /// WebSocket endpoint. Read the body line-by-line until it closes — the<br/>
        /// body closing signals that synthesis is complete.<br/>
        /// ## Error Handling<br/>
        /// If the request fails before the response stream has started, the server<br/>
        /// responds with `HTTP 500` and a plain-text body. Two body shapes occur:<br/>
        /// - **Upstream errors** (with a numeric code) such as authentication<br/>
        ///   failures or worker-level rejections:<br/>
        ///   ```<br/>
        ///   error from server &lt;code&gt;: &lt;reason&gt;<br/>
        ///   ```<br/>
        ///   For example, a revoked or expired API key returns<br/>
        ///   `error from server 1008: API key is revoked or expired`.<br/>
        /// - **Proxy-level rejections** (e.g. unsupported `Content-Type`, malformed<br/>
        ///   request body) come back as raw error strings without the `error from<br/>
        ///   server` prefix.<br/>
        /// In both cases the body is plain text (not JSON). Errors that occur<br/>
        /// after the response stream has started (when `only_audio` is `false`)<br/>
        /// are surfaced as `{"type": "error", ...}` JSON messages within the<br/>
        /// stream rather than as a different HTTP status.<br/>
        /// ---<br/>
        /// ## When to Use POST vs WebSocket<br/>
        /// The POST endpoint is ideal for simple, text-to-speech generations.<br/>
        /// The main difference with the WebSocket endpoint is that the input is not<br/>
        /// handled in a streaming way; the entire text is sent in one request. The audio is<br/>
        /// still streamed back to the client, allowing for efficient handling of large<br/>
        /// audio outputs and lower latency.<br/>
        /// So if your use case involves sending complete text blocks and receiving audio<br/>
        /// responses, the POST endpoint is a straightforward choice. For more interactive<br/>
        /// or real-time applications where text input is streamed, the WebSocket endpoint<br/>
        /// is more suitable.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        /// <remarks>
        /// curl -L -X POST https://api.gradium.ai/api/post/speech/tts \<br/>
        ///   -H "x-api-key: your_api_key" \<br/>
        ///   -H "Content-Type: application/json" \<br/>
        ///   -d '{"text": "Hello, world!", "voice_id": "YTpq7expH9539ERJ", "output_format": "wav", "only_audio": true}' \<br/>
        ///   &gt; output.wav
        /// </remarks>
        public async global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse> PostTextToSpeechAsResponseAsync(

            global::Gradium.PostTextToSpeechRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PreparePostTextToSpeechArguments(
                httpClient: HttpClient,
                request: request);


            var __authorizations = global::Gradium.EndPointSecurityResolver.ResolveAuthorizations(
                availableAuthorizations: Authorizations,
                securityRequirements: s_PostTextToSpeechSecurityRequirements,
                operationName: "PostTextToSpeechAsync");

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
                                path: "/post/speech/tts",
                                baseUri: HttpClient.BaseAddress);
                            var __path = __pathBuilder.ToString();
                __path = global::Gradium.AutoSDKRequestOptionsSupport.AppendQueryParameters(
                    path: __path,
                    clientParameters: Options.QueryParameters,
                    requestParameters: requestOptions?.QueryParameters);
                var __httpRequest = new global::System.Net.Http.HttpRequestMessage(
                    method: global::System.Net.Http.HttpMethod.Post,
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
                            var __httpRequestContentBody = request.ToJson(JsonSerializerContext);
                            var __httpRequestContent = new global::System.Net.Http.StringContent(
                                content: __httpRequestContentBody,
                                encoding: global::System.Text.Encoding.UTF8,
                                mediaType: "application/json");
                            __httpRequest.Content = __httpRequestContent;
                global::Gradium.AutoSDKRequestOptionsSupport.ApplyHeaders(
                    request: __httpRequest,
                    clientHeaders: Options.Headers,
                    requestHeaders: requestOptions?.Headers);

                PrepareRequest(
                    client: HttpClient,
                    request: __httpRequest);
                PreparePostTextToSpeechRequest(
                    httpClient: HttpClient,
                    httpRequestMessage: __httpRequest,
                    request: request);

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
                                operationId: "PostTextToSpeech",
                                methodName: "PostTextToSpeechAsync",
                                pathTemplate: "\"/post/speech/tts\"",
                                httpMethod: "POST",
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
                                operationId: "PostTextToSpeech",
                                methodName: "PostTextToSpeechAsync",
                                pathTemplate: "\"/post/speech/tts\"",
                                httpMethod: "POST",
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
                                operationId: "PostTextToSpeech",
                                methodName: "PostTextToSpeechAsync",
                                pathTemplate: "\"/post/speech/tts\"",
                                httpMethod: "POST",
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
                ProcessPostTextToSpeechResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "PostTextToSpeech",
                                methodName: "PostTextToSpeechAsync",
                                pathTemplate: "\"/post/speech/tts\"",
                                httpMethod: "POST",
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
                                operationId: "PostTextToSpeech",
                                methodName: "PostTextToSpeechAsync",
                                pathTemplate: "\"/post/speech/tts\"",
                                httpMethod: "POST",
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
                            if ((int)__response.StatusCode == 500)
                            {
                                string? __content_500 = null;
                                global::System.Exception? __exception_500 = null;
                                try
                                {
                                    if (__effectiveReadResponseAsString)
                                    {
                                        __content_500 = await __response.Content.ReadAsStringAsync(__effectiveCancellationToken).ConfigureAwait(false);
                                    }
                                    else
                                    {
                                        __content_500 = await __response.Content.ReadAsStringAsync(__effectiveCancellationToken).ConfigureAwait(false);
                                    }
                                }
                                catch (global::System.Exception __ex)
                                {
                                    __exception_500 = __ex;
                                }


                                throw global::Gradium.ApiException.Create(
                                    statusCode: __response.StatusCode,
                                    message: __content_500 ?? __response.ReasonPhrase ?? string.Empty,
                                    innerException: __exception_500,
                                    responseBody: __content_500,
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
        /// <summary>
        /// TTS POST Endpoint<br/>
        /// Use this HTTP POST endpoint for simple, text-to-speech conversion. The audio<br/>
        /// data is sent back in a streaming way.<br/>
        /// **Endpoint URL:**<br/>
        /// ```<br/>
        /// https://api.gradium.ai/api/post/speech/tts<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the request header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Example<br/>
        /// ```bash<br/>
        /// curl -L -X POST https://api.gradium.ai/api/post/speech/tts \<br/>
        ///   -H "x-api-key: your_api_key" \<br/>
        ///   -H "Content-Type: application/json" \<br/>
        ///   -d '{"text": "Hello, this is a test of the text to speech system.", "voice_id": "YTpq7expH9539ERJ", "output_format": "wav", "only_audio": true}' \<br/>
        ///   &gt; output.wav<br/>
        /// ```<br/>
        /// ---<br/>
        /// ## Request Format<br/>
        /// **Method:** POST<br/>
        /// **Content-Type:** application/json<br/>
        /// **Request Body:**<br/>
        /// ```json<br/>
        /// {<br/>
        ///   "text": "Hello, this is a test of the text to speech system.",<br/>
        ///   "voice_id": "YTpq7expH9539ERJ",<br/>
        ///   "output_format": "wav",<br/>
        ///   "json_config": "{}",<br/>
        ///   "only_audio": true<br/>
        /// }<br/>
        /// ```<br/>
        /// **Fields:**<br/>
        /// - `text` (string, required): The text to be converted to speech<br/>
        /// - `voice_id` (string, required): Voice ID from the library (e.g.,<br/>
        ///   "YTpq7expH9539ERJ") or a custom voice ID<br/>
        /// - `output_format` (string, required): Audio format - "wav", "pcm", or "opus"<br/>
        ///   (ogg wrapped opus data).<br/>
        /// - `json_config` (string, optional): Additional configuration in JSON string format (e.g., `{"padding_bonus": -1.2}`)<br/>
        /// - `model_name` (string, optional): The TTS model to use (default: "default")<br/>
        /// - `only_audio` (boolean, optional): When `true`, returns only the raw audio<br/>
        ///   bytes. When `false` or omitted, returns a stream of JSON messages containing<br/>
        ///   the audio and metadata. The format is the same as with the websocket endpoint.<br/>
        /// ---<br/>
        /// ## Response Format<br/>
        /// ### When `only_audio` is `true`<br/>
        /// The response body contains the raw audio bytes in the requested format. Save directly to a file:<br/>
        /// ```bash<br/>
        /// curl ... &gt; output.wav<br/>
        /// ```<br/>
        /// **Content-Type:** Depends on the output format:<br/>
        /// - `audio/wav` for WAV format<br/>
        /// - `audio/ogg` for Ogg wrapped Opus format<br/>
        /// - `audio/pcm` for PCM format<br/>
        /// ### When `only_audio` is `false` or omitted<br/>
        /// The response is a stream of JSON messages using the same format as the<br/>
        /// WebSocket endpoint. Read the body line-by-line until it closes — the<br/>
        /// body closing signals that synthesis is complete.<br/>
        /// ## Error Handling<br/>
        /// If the request fails before the response stream has started, the server<br/>
        /// responds with `HTTP 500` and a plain-text body. Two body shapes occur:<br/>
        /// - **Upstream errors** (with a numeric code) such as authentication<br/>
        ///   failures or worker-level rejections:<br/>
        ///   ```<br/>
        ///   error from server &lt;code&gt;: &lt;reason&gt;<br/>
        ///   ```<br/>
        ///   For example, a revoked or expired API key returns<br/>
        ///   `error from server 1008: API key is revoked or expired`.<br/>
        /// - **Proxy-level rejections** (e.g. unsupported `Content-Type`, malformed<br/>
        ///   request body) come back as raw error strings without the `error from<br/>
        ///   server` prefix.<br/>
        /// In both cases the body is plain text (not JSON). Errors that occur<br/>
        /// after the response stream has started (when `only_audio` is `false`)<br/>
        /// are surfaced as `{"type": "error", ...}` JSON messages within the<br/>
        /// stream rather than as a different HTTP status.<br/>
        /// ---<br/>
        /// ## When to Use POST vs WebSocket<br/>
        /// The POST endpoint is ideal for simple, text-to-speech generations.<br/>
        /// The main difference with the WebSocket endpoint is that the input is not<br/>
        /// handled in a streaming way; the entire text is sent in one request. The audio is<br/>
        /// still streamed back to the client, allowing for efficient handling of large<br/>
        /// audio outputs and lower latency.<br/>
        /// So if your use case involves sending complete text blocks and receiving audio<br/>
        /// responses, the POST endpoint is a straightforward choice. For more interactive<br/>
        /// or real-time applications where text input is streamed, the WebSocket endpoint<br/>
        /// is more suitable.
        /// </summary>
        /// <param name="text">
        /// The text to convert to speech
        /// </param>
        /// <param name="voiceId">
        /// Voice ID from the library or custom voice ID
        /// </param>
        /// <param name="outputFormat">
        /// Audio output format
        /// </param>
        /// <param name="onlyAudio">
        /// When true, returns raw audio bytes instead of JSON
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        public async global::System.Threading.Tasks.Task PostTextToSpeechAsync(
            string text,
            string voiceId,
            global::Gradium.PostTextToSpeechRequestOutputFormat outputFormat,
            bool? onlyAudio = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var __request = new global::Gradium.PostTextToSpeechRequest
            {
                Text = text,
                VoiceId = voiceId,
                OutputFormat = outputFormat,
                OnlyAudio = onlyAudio,
            };

            await PostTextToSpeechAsync(
                request: __request,
                requestOptions: requestOptions,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}