#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class S2sGetSpeechS2sCommandApiCommand
{


    public static Command Create()
    {
        var command = new Command(@"get-speech-s2s", @"S2S WebSocket Stream
Connect to this endpoint via WebSocket for real-time speech-to-speech: incoming audio is transcribed, optionally translated, and re-synthesized into speech.

**Connection URL:**

```
wss://api.gradium.ai/api/speech/s2s
```

**Authentication:**
Include your API key in the WebSocket connection header:
- Header: `x-api-key: your_api_key`

---

## Quick Reference

| Direction | Message Type | Example |
|-----------|-------------|---------|
| 🔵⬆️ Client→Server | Setup (first) | `{""type"": ""setup"", ""model_name"": ""default"", ""input_format"": ""pcm"", ""output_format"": ""pcm"", ""voice_id"": ""YTpq7expH9539ERJ""}` |
| 🟢⬇️ Server→Client | Ready | `{""type"": ""ready"", ""request_id"": ""uuid"", ""sample_rate"": 48000}` |
| 🔵⬆️ Client→Server | Audio | `{""type"": ""audio"", ""audio"": ""base64...""}` |
| 🟢⬇️ Server→Client | Text (stream) | `{""type"": ""text"", ""text"": ""Hello world"", ""start_s"": 0.5, ""stop_s"": 1.2}` |
| 🟢⬇️ Server→Client | Audio (stream) | `{""type"": ""audio"", ""audio"": ""base64...""}` |
| 🔵⬆️ Client→Server | EndOfStream | `{""type"": ""end_of_stream""}` |
| 🟢⬇️ Server→Client | EndOfStream | `{""type"": ""end_of_stream""}` |
| 🔴⬇️ Server→Client | Error | `{""type"": ""error"", ""message"": ""Error description"", ""code"": 1008}` |

---

## Message Types

### 1. Setup Message (First Message)

**Direction:** Client → Server
**Format:** JSON Object

```json
{
  ""type"": ""setup"",
  ""model_name"": ""default"",
  ""input_format"": ""pcm"",
  ""output_format"": ""pcm"",
  ""voice_id"": ""YTpq7expH9539ERJ""
}
```

**Fields:**
- `type` (string, required): Must be ""setup""
- `model_name` (string, optional): The speech-to-speech model to use (default: ""default"")
- `stt_model_name` (string, optional): The speech-to-text model used to transcribe the input
- `tts_model_name` (string, optional): The text-to-speech model used to synthesize the output
- `input_format` (string, optional): Input audio format (default: ""wav""). One of ""pcm"", ""pcm_8000"", ""pcm_16000"", ""pcm_22050"", ""pcm_24000"", ""pcm_44100"", ""pcm_48000"", ""wav"", ""opus"", ""ulaw_8000"", ""mulaw_8000"", ""alaw_8000"".
- `output_format` (string, optional): Output audio format (default: ""wav""). One of ""wav"", ""pcm"", ""opus"", ""ulaw_8000"", ""mulaw_8000"", ""alaw_8000"", ""pcm_8000"", ""pcm_16000"", ""pcm_22050"", ""pcm_24000"", ""pcm_44100"", ""pcm_48000"".
- `voice_id` (string, optional): Voice ID from the library used for the synthesized output
- `json_config` (object or string, optional): Advanced options. Set `target_language` to translate the speech (e.g. `{""target_language"": ""en""}`); omit it to keep the original language.

**Important:** This must be the very first message sent after connection. The server will close the connection if any other message is sent first.

---

### 2. Ready Message

**Direction:** Server → Client
**Format:** JSON Object

```json
{
  ""type"": ""ready"",
  ""request_id"": ""550e8400-e29b-41d4-a716-446655440000"",
  ""sample_rate"": 48000,
  ""frame_size"": 3840
}
```

**Fields:**
- `type` (string): Will be ""ready""
- `request_id` (string): Unique identifier for the session
- `sample_rate` (integer): Output sample rate in Hz
- `frame_size` (integer): Output frame size in samples

This message is sent by the server after receiving the setup message, indicating that the connection is ready to receive audio.

---

### 3. Audio Message

**Direction:** Client → Server
**Format:** JSON Object

```json
{
  ""type"": ""audio"",
  ""audio"": ""base64_encoded_audio_data...""
}
```

**Fields:**
- `type` (string, required): Must be ""audio""
- `audio` (string, required): Base64-encoded input audio chunk

**Audio Format Requirements (for PCM input):**
- **Sample Rate**: 24000 Hz (24kHz)
- **Format**: PCM (Pulse Code Modulation)
- **Bit Depth**: 16-bit signed integer (little-endian)
- **Channels**: Single channel (mono)
- **Chunk Size**: Recommended 1920 samples per frame (80ms at 24kHz)

Send audio messages to be converted. The server will stream back text and synthesized audio as it processes the input.

---

### 4. Text Response

**Direction:** Server → Client
**Format:** JSON Object

```json
{
  ""type"": ""text"",
  ""text"": ""Hello world"",
  ""start_s"": 0.5,
  ""stop_s"": 1.2,
  ""stream_id"": 0
}
```

**Fields:**
- `type` (string): Will be ""text""
- `text` (string): The transcribed (and translated, if `target_language` is set) text segment
- `start_s` (float): Start time of the segment in seconds
- `stop_s` (float): Stop time of the segment in seconds
- `stream_id` (integer or null): Stream identifier

---

### 5. Audio Response

**Direction:** Server → Client
**Format:** JSON Object

```json
{
  ""type"": ""audio"",
  ""audio"": ""base64_encoded_audio_data..."",
  ""start_s"": 0.0,
  ""stop_s"": 0.08,
  ""stream_id"": 0
}
```

**Fields:**
- `type` (string): Will be ""audio""
- `audio` (string): Base64-encoded output audio chunk in the requested format
- `start_s` (float): Start time of the chunk in seconds
- `stop_s` (float): Stop time of the chunk in seconds
- `stream_id` (integer or null): Stream identifier

When using `""pcm""` output format, the audio is 16-bit signed integer mono. The output sample rate is reported in the `ready` message.

---

### 6. End Of Stream

**Direction:** Client → Server and Server → Client
**Format:** JSON Object

```json
{
  ""type"": ""end_of_stream""
}
```

The client sends this when it has finished sending audio. The server then returns any remaining text and audio, an `end_of_stream` message, and closes the connection.

---

## Error Handling

When errors occur, the server sends an error message as JSON before closing the connection:

```json
{
  ""type"": ""error"",
  ""message"": ""Error description explaining what went wrong"",
  ""code"": 1008
}
```

**Common Error Codes:**
- `1008`: Policy Violation (e.g., invalid API key, missing setup message, invalid audio format)
- `1011`: Internal Server Error (unexpected server-side error)
");



        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {

                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                await client.S2s.GetSpeechS2sAsync(

                                    cancellationToken: cancellationToken).ConfigureAwait(false);

                                await CliRuntime.WriteSuccessAsync(parseResult, cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}