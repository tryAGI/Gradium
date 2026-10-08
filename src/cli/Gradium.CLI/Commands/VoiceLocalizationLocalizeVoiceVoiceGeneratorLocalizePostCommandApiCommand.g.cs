#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoiceLocalizationLocalizeVoiceVoiceGeneratorLocalizePostCommandApiCommand
{
    private static Option<string> SrcVoice { get; } = new(
        name: @"--src-voice")
    {
        Description = @"The voice to localize: a voice id (your clone, a converted candidate or a flagship voice) or a `vox_emb_` candidate id. The source is not modified.",
        Required = true,
    };

    private static Option<global::Gradium.LocalizeRequestTargetLanguage> TargetLanguage { get; } = new(
        name: @"--target-language")
    {
        Description = @"Language the candidates will speak. May equal the source language: that is an accent change.",
        Required = true,
    };

    private static Option<string?> Accent { get; } = new(
        name: @"--accent")
    {
        Description = @"One of the accents `GET /voice-generator/available-accents` lists for `target_language`, matched case-insensitively. Omitted: the first accent listed for that language.",
    };

    private static Option<global::Gradium.LocalizeRequestGender?> Gender { get; } = new(
        name: @"--gender")
    {
        Description = @"Opens the edit caption. Omitted: the source voice's gender tag, or the gender of the source candidate's own localization, or no gender. Clones and converted voices carry no tag, so send it for them.",
    };

    private static Option<int?> NSamples { get; } = new(
        name: @"--n-samples")
    {
        Description = @"Number of candidates to produce. All candidates in one request are variations of the same localized speaker.",
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


    static partial void CustomizeCommand(ref Command command);

    public static Command Create(string? commandName = null)
    {
        var command = new Command(commandName ?? @"localize-voice-voice-generator-localize-post", @"Localize Voice
Make an existing voice speak another language, or another accent of the same language, without changing who is speaking. The source can be a flagship voice, one of your clones, a converted candidate or a `vox_emb_` candidate; it is never modified.

Each request creates `n_samples` new candidates that behave exactly like Voice Design candidates: poll `GET /voice-generator/embeddings` until `ready` (typically two to eight seconds), audition them with `POST /post/speech/tts` using text in the target language, keep one with `POST /voices/from-embedding`.

The request is validated before anything is queued. A source with no `language` set returns `409`; set it with `PUT /voices/{voice_uid}` first. A candidate source must be ready. Pro clones cannot be localized.");
                        command.Options.Add(SrcVoice);
                        command.Options.Add(TargetLanguage);
                        command.Options.Add(Accent);
                        command.Options.Add(Gender);
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
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Gradium.LocalizeRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Gradium.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var srcVoice = parseResult.GetRequiredValue(SrcVoice);
                        var targetLanguage = parseResult.GetRequiredValue(TargetLanguage);
                        var accent = CliRuntime.WasSpecified(parseResult, Accent) ? parseResult.GetValue(Accent) : (__requestBase is { } __AccentBaseValue ? __AccentBaseValue.Accent : default);
                        var gender = CliRuntime.WasSpecified(parseResult, Gender) ? parseResult.GetValue(Gender) : (__requestBase is { } __GenderBaseValue ? __GenderBaseValue.Gender : default);
                        var nSamples = CliRuntime.WasSpecified(parseResult, NSamples) ? parseResult.GetValue(NSamples) : (__requestBase is { } __NSamplesBaseValue ? __NSamplesBaseValue.NSamples : default);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.VoiceLocalization.LocalizeVoiceVoiceGeneratorLocalizePostAsync(
                                    srcVoice: srcVoice,
                                    targetLanguage: targetLanguage,
                                    accent: accent,
                                    gender: gender,
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
        CustomizeCommand(ref command);
        return command;
    }
}