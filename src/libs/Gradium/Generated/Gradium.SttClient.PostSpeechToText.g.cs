
#nullable enable

namespace Gradium
{
    public partial class SttClient
    {


        private static readonly global::Gradium.EndPointSecurityRequirement s_PostSpeechToTextSecurityRequirement0 =
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
        private static readonly global::Gradium.EndPointSecurityRequirement[] s_PostSpeechToTextSecurityRequirements =
            new global::Gradium.EndPointSecurityRequirement[]
            {                s_PostSpeechToTextSecurityRequirement0,
            };
        partial void PreparePostSpeechToTextArguments(
            global::System.Net.Http.HttpClient httpClient,
            ref global::Gradium.PostSpeechToTextContentType? contentType,
            ref string? model,
            ref global::Gradium.PostSpeechToTextInputFormat? inputFormat,
            ref string? jsonConfig,
            byte[] request);
        partial void PreparePostSpeechToTextRequest(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpRequestMessage httpRequestMessage,
            global::Gradium.PostSpeechToTextContentType? contentType,
            string? model,
            global::Gradium.PostSpeechToTextInputFormat? inputFormat,
            string? jsonConfig,
            byte[] request);
        partial void ProcessPostSpeechToTextResponse(
            global::System.Net.Http.HttpClient httpClient,
            global::System.Net.Http.HttpResponseMessage httpResponseMessage);

        /// <summary>
        /// STT POST Endpoint<br/>
        /// Use this HTTP POST endpoint for simple, one-shot speech-to-text<br/>
        /// transcription. Send the entire audio payload in the request body and receive<br/>
        /// a stream of newline-delimited JSON (NDJSON) messages with the transcription<br/>
        /// results.<br/>
        /// **Endpoint URL:**<br/>
        /// ```<br/>
        /// https://api.gradium.ai/api/post/speech/asr<br/>
        /// ```<br/>
        /// **Authentication:**<br/>
        /// Include your API key in the request header:<br/>
        /// - Header: `x-api-key: your_api_key`<br/>
        /// ---<br/>
        /// ## Quick Example<br/>
        /// ```bash<br/>
        /// curl -L -X POST https://api.gradium.ai/api/post/speech/asr \<br/>
        ///   -H "x-api-key: your_api_key" \<br/>
        ///   -H "Content-Type: audio/wav" \<br/>
        ///   --data-binary @input.wav<br/>
        /// ```<br/>
        /// With a language hint:<br/>
        /// ```bash<br/>
        /// curl -L -X POST "https://api.gradium.ai/api/post/speech/asr?json_config=%7B%22language%22%3A%22en%22%7D" \<br/>
        ///   -H "x-api-key: your_api_key" \<br/>
        ///   -H "Content-Type: audio/wav" \<br/>
        ///   --data-binary @input.wav<br/>
        /// ```<br/>
        /// ---<br/>
        /// ## Request Format<br/>
        /// **Method:** POST<br/>
        /// **Body:** Raw audio bytes (the full file).<br/>
        /// The input audio format is selected from the `Content-Type` header:<br/>
        /// | Content-Type | Audio Format |<br/>
        /// |--------------|--------------|<br/>
        /// | `audio/wav` (default if header is missing) | WAV (PCM data, 16/24/32-bit) |<br/>
        /// | `audio/pcm` | Raw PCM, 24 kHz, 16-bit signed little-endian, mono |<br/>
        /// | `audio/ogg` or `audio/opus` | Ogg-wrapped Opus |<br/>
        /// **Query Parameters:**<br/>
        /// - `model` (string, optional): The Speech-to-Text model to use (default: `default`).<br/>
        /// - `input_format` (string, optional): Override the input format detected from<br/>
        ///   `Content-Type`. One of `wav`, `pcm`, `opus`.<br/>
        /// - `json_config` (string, optional): JSON-encoded model configuration. Common<br/>
        ///   use case: pass a language hint, e.g. `{"language": "en"}`. The value should<br/>
        ///   be URL-encoded when used as a query parameter.<br/>
        /// ---<br/>
        /// ## Response Format<br/>
        /// **Content-Type:** `application/x-ndjson`<br/>
        /// The response body is a stream of newline-delimited JSON messages. Each line<br/>
        /// is a separate JSON object. Possible message types:<br/>
        /// ### `text` — transcribed text segment<br/>
        /// ```json<br/>
        /// {"type": "text", "text": "Hello world", "start_s": 0.5, "stream_id": 0}<br/>
        /// ```<br/>
        /// - `text` (string): Transcribed text.<br/>
        /// - `start_s` (float): Start time of the segment in seconds.<br/>
        /// - `stream_id` (integer): Stream identifier when multiple text streams are in<br/>
        ///   use (0 in single-stream transcription).<br/>
        /// ### `end_text` — segment boundary<br/>
        /// ```json<br/>
        /// {"type": "end_text", "stop_s": 2.5, "stream_id": 0}<br/>
        /// ```<br/>
        /// - `stop_s` (float): End time of the previous `text` segment in seconds.<br/>
        /// - `stream_id` (integer): Stream identifier.<br/>
        /// ### `error` — server-side error<br/>
        /// ```json<br/>
        /// {"type": "error", "message": "Error description"}<br/>
        /// ```<br/>
        /// If the transcription pipeline fails, the server emits an `error` message and<br/>
        /// stops the stream.<br/>
        /// ---<br/>
        /// ## Reading the Stream<br/>
        /// The response is streamed: read the body line-by-line and parse each line as<br/>
        /// JSON. The body closes when transcription is complete.<br/>
        /// ```python<br/>
        /// import json<br/>
        /// import requests<br/>
        /// with open("input.wav", "rb") as f:<br/>
        ///     audio = f.read()<br/>
        /// with requests.post(<br/>
        ///     "https://api.gradium.ai/api/post/speech/asr",<br/>
        ///     data=audio,<br/>
        ///     headers={<br/>
        ///         "x-api-key": "your_api_key",<br/>
        ///         "Content-Type": "audio/wav",<br/>
        ///     },<br/>
        ///     stream=True,<br/>
        /// ) as resp:<br/>
        ///     resp.raise_for_status()<br/>
        ///     transcript = []<br/>
        ///     for line in resp.iter_lines(decode_unicode=True):<br/>
        ///         if not line:<br/>
        ///             continue<br/>
        ///         msg = json.loads(line)<br/>
        ///         if msg["type"] == "text":<br/>
        ///             transcript.append(msg["text"])<br/>
        ///         elif msg["type"] == "error":<br/>
        ///             raise RuntimeError(msg["message"])<br/>
        /// print(" ".join(transcript))<br/>
        /// ```<br/>
        /// ---<br/>
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
        ///   server` prefix:<br/>
        ///   ```<br/>
        ///   unsupported content type for SST 'audio/mpeg'<br/>
        ///   ```<br/>
        /// In both cases the body is plain text (not JSON). Errors that occur<br/>
        /// after the NDJSON stream has started are surfaced as<br/>
        /// `{"type": "error", "message": "..."}` lines within the stream rather<br/>
        /// than as a different HTTP status.<br/>
        /// ---<br/>
        /// ## When to Use POST vs WebSocket<br/>
        /// The POST endpoint is ideal for one-shot transcription of complete audio<br/>
        /// files already on disk or in memory. The audio is uploaded in a single<br/>
        /// request, transcription runs, and the results are streamed back as NDJSON.<br/>
        /// Use the [WebSocket endpoint](/api-reference/endpoint/stt-websocket) instead<br/>
        /// when you need to:<br/>
        /// - Stream audio as it is being captured (microphone, telephony).<br/>
        /// - Receive partial transcripts and Voice Activity Detection (VAD) events in<br/>
        ///   real time for turn-taking.<br/>
        /// - Send a `flush` message to force the model to emit buffered text on demand.
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="model">
        /// Default Value: default
        /// </param>
        /// <param name="inputFormat"></param>
        /// <param name="jsonConfig"></param>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Gradium.ApiException"></exception>
        /// <remarks>
        /// curl -L -X POST https://api.gradium.ai/api/post/speech/asr \<br/>
        ///   -H "x-api-key: your_api_key" \<br/>
        ///   -H "Content-Type: audio/wav" \<br/>
        ///   --data-binary @input.wav
        /// </remarks>
        public async global::System.Collections.Generic.IAsyncEnumerable<string> PostSpeechToTextAsync(

            byte[] request,
            global::Gradium.PostSpeechToTextContentType? contentType = default,
            string? model = default,
            global::Gradium.PostSpeechToTextInputFormat? inputFormat = default,
            string? jsonConfig = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            [global::System.Runtime.CompilerServices.EnumeratorCancellation] global::System.Threading.CancellationToken cancellationToken = default)
        {
            request = request ?? throw new global::System.ArgumentNullException(nameof(request));

            PrepareArguments(
                client: HttpClient);
            PreparePostSpeechToTextArguments(
                httpClient: HttpClient,
                contentType: ref contentType,
                model: ref model,
                inputFormat: ref inputFormat,
                jsonConfig: ref jsonConfig,
                request: request);


            var __authorizations = global::Gradium.EndPointSecurityResolver.ResolveAuthorizations(
                availableAuthorizations: Authorizations,
                securityRequirements: s_PostSpeechToTextSecurityRequirements,
                operationName: "PostSpeechToTextAsync");

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
                                path: "/post/speech/asr",
                                baseUri: HttpClient.BaseAddress);
                            __pathBuilder
                                .AddOptionalParameter("model", model)
                                .AddOptionalParameter("input_format", inputFormat?.ToValueString())
                                .AddOptionalParameter("json_config", jsonConfig)
                                ;
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

            if (contentType != default)
            {
                __httpRequest.Headers.TryAddWithoutValidation("Content-Type", contentType?.ToValueString() ?? string.Empty);
            }


                            var __httpRequestContent = new global::System.Net.Http.ByteArrayContent(request);
                            __httpRequestContent.Headers.ContentType = new global::System.Net.Http.Headers.MediaTypeHeaderValue("audio/wav");
                            __httpRequest.Content = __httpRequestContent;
                global::Gradium.AutoSDKRequestOptionsSupport.ApplyHeaders(
                    request: __httpRequest,
                    clientHeaders: Options.Headers,
                    requestHeaders: requestOptions?.Headers);

                PrepareRequest(
                    client: HttpClient,
                    request: __httpRequest);
                PreparePostSpeechToTextRequest(
                    httpClient: HttpClient,
                    httpRequestMessage: __httpRequest,
                    contentType: contentType,
                    model: model,
                    inputFormat: inputFormat,
                    jsonConfig: jsonConfig,
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
                                operationId: "PostSpeechToText",
                                methodName: "PostSpeechToTextAsync",
                                pathTemplate: "\"/post/speech/asr\"",
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
                completionOption: global::System.Net.Http.HttpCompletionOption.ResponseHeadersRead,
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
                                operationId: "PostSpeechToText",
                                methodName: "PostSpeechToTextAsync",
                                pathTemplate: "\"/post/speech/asr\"",
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
                                operationId: "PostSpeechToText",
                                methodName: "PostSpeechToTextAsync",
                                pathTemplate: "\"/post/speech/asr\"",
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
                ProcessPostSpeechToTextResponse(
                    httpClient: HttpClient,
                    httpResponseMessage: __response);
                if (__response.IsSuccessStatusCode)
                {
                    await global::Gradium.AutoSDKRequestOptionsSupport.OnAfterSuccessAsync(
                            clientOptions: Options,
                            context: global::Gradium.AutoSDKRequestOptionsSupport.CreateHookContext(
                                operationId: "PostSpeechToText",
                                methodName: "PostSpeechToTextAsync",
                                pathTemplate: "\"/post/speech/asr\"",
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
                                operationId: "PostSpeechToText",
                                methodName: "PostSpeechToTextAsync",
                                pathTemplate: "\"/post/speech/asr\"",
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

                            try
                            {
                                __response.EnsureSuccessStatusCode();
                            }
                            catch (global::System.Net.Http.HttpRequestException __ex)
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

                            using var __stream = await __response.Content.ReadAsStreamAsync(
                #if NET5_0_OR_GREATER
                                __effectiveCancellationToken
                #endif
                            ).ConfigureAwait(false);

                            using var __reader = new global::System.IO.StreamReader(__stream);

                            while (!__reader.EndOfStream && !__effectiveCancellationToken.IsCancellationRequested)
                            {
                                var __content = await __reader.ReadLineAsync().ConfigureAwait(false) ?? string.Empty;
                                if (global::System.String.IsNullOrWhiteSpace(__content))
                                {
                                    continue;
                                }

                                var __streamedResponse = (string?)global::System.Text.Json.JsonSerializer.Deserialize(__content, typeof(string), JsonSerializerContext) ??
                                                       throw global::Gradium.ApiException.Create(
                                                           statusCode: __response.StatusCode,
                                                           message: $"Response deserialization failed for \"{__content}\" ",
                                                           innerException: null,
                                                           responseBody: __content,
                                                           responseHeaders: global::System.Linq.Enumerable.ToDictionary(
                                                               __response.Headers,
                                                               h => h.Key,
                                                               h => h.Value));

                                yield return __streamedResponse;
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