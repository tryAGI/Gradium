#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class TtsPostTextToSpeechCommandApiCommand
{
    private static Option<string> Text { get; } = new(
        name: @"--text")
    {
        Description = @"The text to convert to speech",
        Required = true,
    };

    private static Option<string> VoiceId { get; } = new(
        name: @"--voice-id")
    {
        Description = @"Voice ID from the library or custom voice ID",
        Required = true,
    };

    private static Option<global::Gradium.PostTextToSpeechRequestOutputFormat> OutputFormat { get; } = new(
        name: @"--output-format")
    {
        Description = @"Audio output format",
        Required = true,
    };

    private static Option<bool?> OnlyAudio { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--only-audio",
        description: @"When true, returns raw audio bytes instead of JSON");
      private static Option<string?> Input { get; } = new(@"--input")
      {
          Description = "Load request JSON from a file path, '-' for stdin, or an inline JSON object/array string.",
      };

      private static Option<string?> RequestJson { get; } = new(@"--request-json")
      {
          Description = "Request body as JSON.",
          Hidden = true,
      };

      private static Option<string?> RequestFile { get; } = new(@"--request-file")
      {
          Description = "Path to a JSON request file, or '-' for stdin.",
          Hidden = true,
      };

    public static Command Create()
    {
        var command = new Command(@"post-text-to-speech", @"TTS POST Endpoint
Use this HTTP POST endpoint for simple, text-to-speech conversion. The audio
data is sent back in a streaming way.

**Endpoint URL:**

```
https://api.gradium.ai/api/post/speech/tts
```

**Authentication:**
Include your API key in the request header:
- Header: `x-api-key: your_api_key`

---

## Quick Example

```bash
curl -L -X POST https://api.gradium.ai/api/post/speech/tts \
  -H ""x-api-key: your_api_key"" \
  -H ""Content-Type: application/json"" \
  -d '{""text"": ""Hello, this is a test of the text to speech system."", ""voice_id"": ""YTpq7expH9539ERJ"", ""output_format"": ""wav"", ""only_audio"": true}' \
  &gt; output.wav
```

---

## Request Format

**Method:** POST
**Content-Type:** application/json

**Request Body:**
```json
{
  ""text"": ""Hello, this is a test of the text to speech system."",
  ""voice_id"": ""YTpq7expH9539ERJ"",
  ""output_format"": ""wav"",
  ""json_config"": ""{}"",
  ""only_audio"": true
}
```

**Fields:**
- `text` (string, required): The text to be converted to speech
- `voice_id` (string, required): Voice ID from the library (e.g.,
  ""YTpq7expH9539ERJ"") or a custom voice ID
- `output_format` (string, required): Audio format - ""wav"", ""pcm"", or ""opus""
  (ogg wrapped opus data).
- `json_config` (string, optional): Additional configuration in JSON string format (e.g., `{""padding_bonus"": -1.2}`)
- `model_name` (string, optional): The TTS model to use (default: ""default"")
- `only_audio` (boolean, optional): When `true`, returns only the raw audio
  bytes. When `false` or omitted, returns a stream of JSON messages containing
  the audio and metadata. The format is the same as with the websocket endpoint.

---

## Response Format

### When `only_audio` is `true`

The response body contains the raw audio bytes in the requested format. Save directly to a file:

```bash
curl ... &gt; output.wav
```

**Content-Type:** Depends on the output format:
- `audio/wav` for WAV format
- `audio/ogg` for Ogg wrapped Opus format
- `audio/pcm` for PCM format

### When `only_audio` is `false` or omitted

The response is a stream of JSON messages using the same format as the
WebSocket endpoint. Read the body line-by-line until it closes — the
body closing signals that synthesis is complete.

## Error Handling

If the request fails before the response stream has started, the server
responds with `HTTP 500` and a plain-text body. Two body shapes occur:

- **Upstream errors** (with a numeric code) such as authentication
  failures or worker-level rejections:

  ```
  error from server &lt;code&gt;: &lt;reason&gt;
  ```

  For example, a revoked or expired API key returns
  `error from server 1008: API key is revoked or expired`.

- **Proxy-level rejections** (e.g. unsupported `Content-Type`, malformed
  request body) come back as raw error strings without the `error from
  server` prefix.

In both cases the body is plain text (not JSON). Errors that occur
after the response stream has started (when `only_audio` is `false`)
are surfaced as `{""type"": ""error"", ...}` JSON messages within the
stream rather than as a different HTTP status.

---

## When to Use POST vs WebSocket

The POST endpoint is ideal for simple, text-to-speech generations.
The main difference with the WebSocket endpoint is that the input is not
handled in a streaming way; the entire text is sent in one request. The audio is
still streamed back to the client, allowing for efficient handling of large
audio outputs and lower latency.

So if your use case involves sending complete text blocks and receiving audio
responses, the POST endpoint is a straightforward choice. For more interactive
or real-time applications where text input is streamed, the WebSocket endpoint
is more suitable.
");
                        command.Options.Add(Text);
                        command.Options.Add(VoiceId);
                        command.Options.Add(OutputFormat);
                        command.Options.Add(OnlyAudio);
          command.Options.Add(Input);
          command.Options.Add(RequestJson);
          command.Options.Add(RequestFile);
          command.Validators.Add(result =>
          {
              var hasInput = result.GetResult(Input) is not null;
              var hasRequestJson = result.GetResult(RequestJson) is not null;
              var hasRequestFile = result.GetResult(RequestFile) is not null;
              var specifiedCount = (hasInput ? 1 : 0) + (hasRequestJson ? 1 : 0) + (hasRequestFile ? 1 : 0);
              if (specifiedCount > 1)
              {
                  result.AddError(@"Specify at most one of --input, --request-json, or --request-file.");
              }
          });

        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Gradium.PostTextToSpeechRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Gradium.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var text = parseResult.GetRequiredValue(Text);
                        var voiceId = parseResult.GetRequiredValue(VoiceId);
                        var outputFormat = parseResult.GetRequiredValue(OutputFormat);
                        var onlyAudio = CliRuntime.WasSpecified(parseResult, OnlyAudio) ? parseResult.GetValue(OnlyAudio) : (__requestBase is { } __OnlyAudioBaseValue ? __OnlyAudioBaseValue.OnlyAudio : default);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                await client.Tts.PostTextToSpeechAsync(
                                    text: text,
                                    voiceId: voiceId,
                                    outputFormat: outputFormat,
                                    onlyAudio: onlyAudio,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);

                                await CliRuntime.WriteSuccessAsync(parseResult, cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}