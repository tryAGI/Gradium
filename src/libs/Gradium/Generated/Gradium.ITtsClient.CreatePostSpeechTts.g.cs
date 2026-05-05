#nullable enable

namespace Gradium
{
    public partial interface ITtsClient
    {
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
        global::System.Threading.Tasks.Task CreatePostSpeechTtsAsync(

            global::Gradium.CreatePostSpeechTtsRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
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
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse> CreatePostSpeechTtsAsResponseAsync(

            global::Gradium.CreatePostSpeechTtsRequest request,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
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
        global::System.Threading.Tasks.Task CreatePostSpeechTtsAsync(
            string text,
            string voiceId,
            global::Gradium.CreatePostSpeechTtsRequestOutputFormat outputFormat,
            bool? onlyAudio = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}