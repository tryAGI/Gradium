#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoicesCreateVoiceVoicesPostCommandApiCommand
{
    private static Argument<string> NameOption { get; } = new(
        name: @"name")
    {
        Description = @"",
    };

    private static Option<byte[]> AudioFile { get; } = new(
        name: @"--audio-file")
    {
        Description = @"",
        Required = true,
    };

    private static Option<string> AudioFilename { get; } = new(
        name: @"--audio-filename")
    {
        Description = @"",
        Required = true,
    };

    private static Option<string?> InputFormat { get; } = new(
        name: @"--input-format")
    {
        Description = @"Audio format. If omitted, inferred from the audio_file extension.",
    };

    private static Option<string?> DescriptionOption { get; } = new(
        name: @"--description")
    {
        Description = @"",
    };

    private static Option<string?> Language { get; } = new(
        name: @"--language")
    {
        Description = @"",
    };

    private static Option<double?> StartS { get; } = new(
        name: @"--start-s")
    {
        Description = @"",
    };

    private static Option<double?> TimeoutS { get; } = new(
        name: @"--timeout-s")
    {
        Description = @"",
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

                    private static string FormatResponse(ParseResult parseResult, global::Gradium.VoiceCreateResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Gradium.VoiceCreateResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"create-voice-voices-post", @"Create Voice
Create a new voice for an organization with audio file upload.");
                        command.Arguments.Add(NameOption);
                        command.Options.Add(AudioFile);
                        command.Options.Add(AudioFilename);
                        command.Options.Add(InputFormat);
                        command.Options.Add(DescriptionOption);
                        command.Options.Add(Language);
                        command.Options.Add(StartS);
                        command.Options.Add(TimeoutS);
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
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Gradium.BodyCreateVoiceVoicesPost>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Gradium.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var name = parseResult.GetRequiredValue(NameOption);
                        var audioFile = parseResult.GetRequiredValue(AudioFile);
                        var audioFilename = parseResult.GetRequiredValue(AudioFilename);
                        var inputFormat = CliRuntime.WasSpecified(parseResult, InputFormat) ? parseResult.GetValue(InputFormat) : __requestBase is not null ? __requestBase.InputFormat : default;
                        var description = CliRuntime.WasSpecified(parseResult, DescriptionOption) ? parseResult.GetValue(DescriptionOption) : __requestBase is not null ? __requestBase.Description : default;
                        var language = CliRuntime.WasSpecified(parseResult, Language) ? parseResult.GetValue(Language) : __requestBase is not null ? __requestBase.Language : default;
                        var startS = CliRuntime.WasSpecified(parseResult, StartS) ? parseResult.GetValue(StartS) : __requestBase is not null ? __requestBase.StartS : default;
                        var timeoutS = CliRuntime.WasSpecified(parseResult, TimeoutS) ? parseResult.GetValue(TimeoutS) : __requestBase is not null ? __requestBase.TimeoutS : default;
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Voices.CreateVoiceVoicesPostAsync(
                                    name: name,
                                    audioFile: audioFile,
                                    audioFilename: audioFilename,
                                    inputFormat: inputFormat,
                                    description: description,
                                    language: language,
                                    startS: startS,
                                    timeoutS: timeoutS,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                await CliRuntime.WriteResponseAsync(
                                    parseResult,
                                    response,
                                    global::Gradium.SourceGenerationContext.Default,
                                    FormatResponse,
                                    cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}