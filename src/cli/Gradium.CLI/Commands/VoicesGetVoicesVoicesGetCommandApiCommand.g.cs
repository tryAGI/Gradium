#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoicesGetVoicesVoicesGetCommandApiCommand
{
    private static Option<int?> Skip { get; } = new(
        name: @"--skip")
    {
        Description = @"",
    };

    private static Option<int?> Limit { get; } = new(
        name: @"--limit")
    {
        Description = @"",
    };

    private static Option<bool?> IncludeCatalog { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--include-catalog",
        description: @"Also return Gradium catalog voices. Your organization's own voices come first, then catalog voices by `rank`, lowest first, unranked last.");

    private static Option<string?> Locale { get; } = new(
        name: @"--locale")
    {
        Description = @"Only voices of this locale, e.g. `en-nz` or `fr-fr`.",
    };

    private static Option<string?> Gender { get; } = new(
        name: @"--gender")
    {
        Description = @"Only voices of this gender: `male`, `female` or `neutral`.",
    };

    private static Option<string?> UseCase { get; } = new(
        name: @"--use-case")
    {
        Description = @"Only voices tagged with this use case, e.g. `Customer Service`, `Conversational`, `Narration` or `Ads & Social Media`. URL-encode it (`Ads%20%26%20Social%20Media`).",
    };

                    private static string FormatResponse(ParseResult parseResult, global::System.Collections.Generic.IList<global::Gradium.APIVoiceResponse> value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::System.Collections.Generic.IList<global::Gradium.APIVoiceResponse> value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    static partial void CustomizeCommand(ref Command command);

    public static Command Create(string? commandName = null)
    {
        var command = new Command(commandName ?? @"get-voices-voices-get", @"Get Voices
List voices for the authenticated organization.");
                        command.Options.Add(Skip);
                        command.Options.Add(Limit);
                        command.Options.Add(IncludeCatalog);
                        command.Options.Add(Locale);
                        command.Options.Add(Gender);
                        command.Options.Add(UseCase);


        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var skip = parseResult.GetValue(Skip);
                        var limit = parseResult.GetValue(Limit);
                        var includeCatalog = parseResult.GetValue(IncludeCatalog);
                        var locale = parseResult.GetValue(Locale);
                        var gender = parseResult.GetValue(Gender);
                        var useCase = parseResult.GetValue(UseCase);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Voices.GetVoicesVoicesGetAsync(
                                    skip: skip,
                                    limit: limit,
                                    includeCatalog: includeCatalog,
                                    locale: locale,
                                    gender: gender,
                                    useCase: useCase,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                if (!await CliRuntime.TryWriteOutputDirectoryAsync(
                                        parseResult,
                                        response,
                                        global::Gradium.SourceGenerationContext.Default,
                                        @"$self",
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