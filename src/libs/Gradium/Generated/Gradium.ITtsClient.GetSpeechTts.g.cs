#nullable enable

namespace Gradium
{
    public partial interface ITtsClient
    {
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
        global::System.Threading.Tasks.Task GetSpeechTtsAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
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
        global::System.Threading.Tasks.Task<global::Gradium.AutoSDKHttpResponse> GetSpeechTtsAsResponseAsync(
            global::Gradium.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}