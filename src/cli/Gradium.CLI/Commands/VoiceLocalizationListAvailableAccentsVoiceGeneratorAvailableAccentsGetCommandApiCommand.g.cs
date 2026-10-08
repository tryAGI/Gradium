#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoiceLocalizationListAvailableAccentsVoiceGeneratorAvailableAccentsGetCommandApiCommand
{


                    private static string FormatResponse(ParseResult parseResult, global::Gradium.AvailableAccentsResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Gradium.AvailableAccentsResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    static partial void CustomizeCommand(ref Command command);

    public static Command Create(string? commandName = null)
    {
        var command = new Command(commandName ?? @"list-available-accents-voice-generator-available-accents-get", @"List Available Accents
The accents `POST /voice-generator/localize` can target, per language, in a fixed order. The first accent of each language is the default applied when a request omits `accent`.

The list is the source of truth and can change: always read it from this endpoint rather than from a copy in documentation or code, then offer it to your users as a picker. Accents are matched case-insensitively and free-text accents are rejected with `422`. No rate limit or billing applies to this read.");



        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {

                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.VoiceLocalization.ListAvailableAccentsVoiceGeneratorAvailableAccentsGetAsync(

                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                await CliRuntime.WriteResponseAsync(
                                    parseResult,
                                    response,
                                    global::Gradium.SourceGenerationContext.Default,
                                    FormatResponse,
                                    cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        CustomizeCommand(ref command);
        return command;
    }
}