#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class SttCreatePostSpeechAsrCommandApiCommand
{
    private static Option<global::Gradium.CreatePostSpeechAsrContentType?> ContentType { get; } = new(
        name: @"--content-type")
    {
        Description = @"Format of the audio in the request body. Defaults to audio/wav when omitted.",
    };

    private static Option<string?> Model { get; } = new(
        name: @"--model")
    {
        Description = @"Speech-to-Text model name.",
    };

    private static Option<global::Gradium.CreatePostSpeechAsrInputFormat?> InputFormat { get; } = new(
        name: @"--input-format")
    {
        Description = @"Overrides the audio format detected from Content-Type.",
    };

    private static Option<string?> JsonConfig { get; } = new(
        name: @"--json-config")
    {
        Description = @"JSON-encoded model configuration. Example: {""language"": ""en""}",
    };
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
        var command = new Command(@"create-post-speech-asr", @"STT POST Endpoint
Use this HTTP POST endpoint for simple, one-shot speech-to-text
transcription. Send the entire audio payload in the request body and receive
a stream of newline-delimited JSON (NDJSON) messages with the transcription
results.

**Endpoint URL:**

```
https://api.gradium.ai/api/post/speech/asr
```

**Authentication:**
Include your API key in the request header:
- Header: `x-api-key: your_api_key`

---

## Quick Example

```bash
curl -L -X POST https://api.gradium.ai/api/post/speech/asr \
  -H ""x-api-key: your_api_key"" \
  -H ""Content-Type: audio/wav"" \
  --data-binary @input.wav
```

With a language hint:

```bash
curl -L -X POST ""https://api.gradium.ai/api/post/speech/asr?json_config=%7B%22language%22%3A%22en%22%7D"" \
  -H ""x-api-key: your_api_key"" \
  -H ""Content-Type: audio/wav"" \
  --data-binary @input.wav
```

---

## Request Format

**Method:** POST
**Body:** Raw audio bytes (the full file).

The input audio format is selected from the `Content-Type` header:

| Content-Type | Audio Format |
|--------------|--------------|
| `audio/wav` (default if header is missing) | WAV (PCM data, 16/24/32-bit) |
| `audio/pcm` | Raw PCM, 24 kHz, 16-bit signed little-endian, mono |
| `audio/ogg` or `audio/opus` | Ogg-wrapped Opus |

**Query Parameters:**
- `model` (string, optional): The Speech-to-Text model to use (default: `default`).
- `input_format` (string, optional): Override the input format detected from
  `Content-Type`. One of `wav`, `pcm`, `opus`.
- `json_config` (string, optional): JSON-encoded model configuration. Common
  use case: pass a language hint, e.g. `{""language"": ""en""}`. The value should
  be URL-encoded when used as a query parameter.

---

## Response Format

**Content-Type:** `application/x-ndjson`

The response body is a stream of newline-delimited JSON messages. Each line
is a separate JSON object. Possible message types:

### `text` — transcribed text segment

```json
{""type"": ""text"", ""text"": ""Hello world"", ""start_s"": 0.5, ""stream_id"": 0}
```

- `text` (string): Transcribed text.
- `start_s` (float): Start time of the segment in seconds.
- `stream_id` (integer): Stream identifier when multiple text streams are in
  use (0 in single-stream transcription).

### `end_text` — segment boundary

```json
{""type"": ""end_text"", ""stop_s"": 2.5, ""stream_id"": 0}
```

- `stop_s` (float): End time of the previous `text` segment in seconds.
- `stream_id` (integer): Stream identifier.

### `error` — server-side error

```json
{""type"": ""error"", ""message"": ""Error description""}
```

If the transcription pipeline fails, the server emits an `error` message and
stops the stream.

---

## Reading the Stream

The response is streamed: read the body line-by-line and parse each line as
JSON. The body closes when transcription is complete.

```python
import json
import requests

with open(""input.wav"", ""rb"") as f:
    audio = f.read()

with requests.post(
    ""https://api.gradium.ai/api/post/speech/asr"",
    data=audio,
    headers={
        ""x-api-key"": ""your_api_key"",
        ""Content-Type"": ""audio/wav"",
    },
    stream=True,
) as resp:
    resp.raise_for_status()
    transcript = []
    for line in resp.iter_lines(decode_unicode=True):
        if not line:
            continue
        msg = json.loads(line)
        if msg[""type""] == ""text"":
            transcript.append(msg[""text""])
        elif msg[""type""] == ""error"":
            raise RuntimeError(msg[""message""])
print("" "".join(transcript))
```

---

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
  server` prefix:

  ```
  unsupported content type for SST 'audio/mpeg'
  ```

In both cases the body is plain text (not JSON). Errors that occur
after the NDJSON stream has started are surfaced as
`{""type"": ""error"", ""message"": ""...""}` lines within the stream rather
than as a different HTTP status.

---

## When to Use POST vs WebSocket

The POST endpoint is ideal for one-shot transcription of complete audio
files already on disk or in memory. The audio is uploaded in a single
request, transcription runs, and the results are streamed back as NDJSON.

Use the [WebSocket endpoint](/api-reference/endpoint/stt-websocket) instead
when you need to:
- Stream audio as it is being captured (microphone, telephony).
- Receive partial transcripts and Voice Activity Detection (VAD) events in
  real time for turn-taking.
- Send a `flush` message to force the model to emit buffered text on demand.
");
                        command.Options.Add(ContentType);
                        command.Options.Add(Model);
                        command.Options.Add(InputFormat);
                        command.Options.Add(JsonConfig);
          command.Options.Add(Input);
          command.Options.Add(RequestJson);
          command.Options.Add(RequestFile);
          command.Validators.Add(result =>
          {
              var hasInput = result.GetResult(Input) is not null;
              var hasRequestJson = result.GetResult(RequestJson) is not null;
              var hasRequestFile = result.GetResult(RequestFile) is not null;
              var specifiedCount = (hasInput ? 1 : 0) + (hasRequestJson ? 1 : 0) + (hasRequestFile ? 1 : 0);
              if (specifiedCount != 1)
              {
                  result.AddError(@"Specify exactly one of --input, --request-json, or --request-file.");
              }
          });

        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var contentType = parseResult.GetValue(ContentType);
                        var model = parseResult.GetValue(Model);
                        var inputFormat = parseResult.GetValue(InputFormat);
                        var jsonConfig = parseResult.GetValue(JsonConfig);
                        var request = await CliRuntime.ReadRequestAsync<byte[]>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Gradium.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = client.Stt.CreatePostSpeechAsrAsync(
                                    contentType: contentType,
                                    model: model,
                                    inputFormat: inputFormat,
                                    jsonConfig: jsonConfig,
                                    request: request,
                                    cancellationToken: cancellationToken);

                                await foreach (var item in response.WithCancellation(cancellationToken).ConfigureAwait(false))
                                {
                                    await CliRuntime.WriteResponseLineAsync(
                                        parseResult,
                                        item,
                                        global::Gradium.SourceGenerationContext.Default,
                                        cancellationToken: cancellationToken).ConfigureAwait(false);
                                }
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}