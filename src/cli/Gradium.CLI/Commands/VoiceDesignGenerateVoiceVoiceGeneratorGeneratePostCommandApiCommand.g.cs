#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoiceDesignGenerateVoiceVoiceGeneratorGeneratePostCommandApiCommand
{
    private static Option<string> Prompt { get; } = new(
        name: @"--prompt")
    {
        Description = @"The voice description, up to 500 characters. Must contain actual text, not only spaces.",
        Required = true,
    };

    private static Option<global::Gradium.VoiceGenerationRequestLanguage> Language { get; } = new(
        name: @"--language")
    {
        Description = @"Language the voice will speak. Shapes the accent and the delivery.",
        Required = true,
    };

    private static Option<int?> NSamples { get; } = new(
        name: @"--n-samples")
    {
        Description = @"Number of candidate voices to sample from the description. All candidates in one request are variations on the same character.",
    };

    private static Option<global::Gradium.VoiceGeneratorConfig?> JsonConfig { get; } = new(
        name: @"--json-config")
    {
        Description = @"Advanced sampling options.",
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
        var command = new Command(@"generate-voice-voice-generator-generate-post", @"Generate Voice Candidates
Sample candidate voices from a written description. No reference audio is involved.

Generation runs in the background, so the candidate ids come back immediately with `ready: false`. Poll `GET /voice-generator/embeddings` every two seconds until each is ready, which typically takes three to five seconds for three candidates.

Every request mints new ids, and the description is expanded before sampling, so the same description gives a fresh voice each time. Capture the ids from the response and carry them through the rest of the flow.");
                        command.Options.Add(Prompt);
                        command.Options.Add(Language);
                        command.Options.Add(NSamples);
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
              if (specifiedCount > 1)
              {
                  result.AddError(@"Specify at most one of --input, --request-json, or --request-file.");
              }
          });

        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Gradium.VoiceGenerationRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Gradium.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var prompt = parseResult.GetRequiredValue(Prompt);
                        var language = parseResult.GetRequiredValue(Language);
                        var nSamples = CliRuntime.WasSpecified(parseResult, NSamples) ? parseResult.GetValue(NSamples) : (__requestBase is { } __NSamplesBaseValue ? __NSamplesBaseValue.NSamples : default);
                        var jsonConfig = CliRuntime.WasSpecified(parseResult, JsonConfig) ? parseResult.GetValue(JsonConfig) : (__requestBase is { } __JsonConfigBaseValue ? __JsonConfigBaseValue.JsonConfig : default);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.VoiceDesign.GenerateVoiceVoiceGeneratorGeneratePostAsync(
                                    prompt: prompt,
                                    language: language,
                                    nSamples: nSamples,
                                    jsonConfig: jsonConfig,
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