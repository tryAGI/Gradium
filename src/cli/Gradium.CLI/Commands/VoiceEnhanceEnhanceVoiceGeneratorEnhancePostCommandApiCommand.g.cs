#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoiceEnhanceEnhanceVoiceGeneratorEnhancePostCommandApiCommand
{
    private static Option<string> SrcVoice { get; } = new(
        name: @"--src-voice")
    {
        Description = @"The voice to enhance: a voice id (your clone, a converted candidate or a flagship voice) or a `vox_emb_` candidate id. It keeps its language and is not modified.",
        Required = true,
    };

    private static Option<int?> NSamples { get; } = new(
        name: @"--n-samples")
    {
        Description = @"Number of candidates to produce. All candidates in one request are variations of the same speaker.",
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

                    private static string FormatResponse(ParseResult parseResult, global::Gradium.VoiceGenerationResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
                    {
                        string? text = null;
                        CustomizeResponseText(parseResult, value, ref text);
                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            return text;
                        }

                        var hints = new Dictionary<string, CliFormatHint>(StringComparer.OrdinalIgnoreCase)
                        {
                        };
                        CustomizeResponseFormatHints(hints);
                        return CliRuntime.FormatHumanReadable(value, context, truncateLongStrings, hints);
                    }

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Gradium.VoiceGenerationResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"enhance-voice-generator-enhance-post", @"Enhance Voice
Voice Enhance is in beta: output quality will keep improving.

Clean up an existing voice without changing its language or who is speaking: the same speaker comes back as new candidates with background noise reduced and a quality target applied. The source can be a flagship voice, one of your clones, a converted candidate or a `vox_emb_` candidate; it is never modified. The body is `src_voice` and `n_samples` only.

Each request creates `n_samples` new candidates that behave exactly like Voice Design candidates and list as `kind: enhance` with `enhance_config` filled. Poll `GET /voice-generator/embeddings` until `ready` (typically fifteen to twenty seconds), audition them with `POST /post/speech/tts` and keep one with `POST /voices/from-embedding`.

The request is validated before anything is queued. The source needs a `language` (a source without one returns `409`; set it with `PUT /voices/{voice_uid}` first), a candidate source must be ready, and pro clones are not accepted.");
                        command.Options.Add(SrcVoice);
                        command.Options.Add(NSamples);
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
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Gradium.EnhanceRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Gradium.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var srcVoice = parseResult.GetRequiredValue(SrcVoice);
                        var nSamples = CliRuntime.WasSpecified(parseResult, NSamples) ? parseResult.GetValue(NSamples) : (__requestBase is { } __NSamplesBaseValue ? __NSamplesBaseValue.NSamples : default);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.VoiceEnhance.EnhanceVoiceGeneratorEnhancePostAsync(
                                    srcVoice: srcVoice,
                                    nSamples: nSamples,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                if (!await CliRuntime.TryWriteOutputDirectoryAsync(
                                        parseResult,
                                        response,
                                        global::Gradium.SourceGenerationContext.Default,
                                        @"Embeddings",
                                        cancellationToken).ConfigureAwait(false))
                                {
                                await CliRuntime.WriteResponseAsync(
                                    parseResult,
                                    response,
                                    global::Gradium.SourceGenerationContext.Default,
                                    FormatResponse,
                                    cancellationToken).ConfigureAwait(false);
                                }
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}