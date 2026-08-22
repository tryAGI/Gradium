#nullable enable

namespace Gradium
{
    public partial interface ISttClient
    {
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
        global::System.Collections.Generic.IAsyncEnumerable<string> PostSpeechToTextAsync(

            byte[] request,
            global::Gradium.PostSpeechToTextContentType? contentType = default,
            string? model = default,
            global::Gradium.PostSpeechToTextInputFormat? inputFormat = default,
            string? jsonConfig = default,
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}