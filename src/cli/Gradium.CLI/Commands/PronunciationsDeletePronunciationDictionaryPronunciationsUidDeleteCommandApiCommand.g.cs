#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class PronunciationsDeletePronunciationDictionaryPronunciationsUidDeleteCommandApiCommand
{
    private static Argument<string> Uid { get; } = new(
        name: @"uid")
    {
        Description = @"",
    };

    public static Command Create()
    {
        var command = new Command(@"delete-pronunciation-dictionary-pronunciations-uid-delete", @"Delete Pronunciation Dictionary
Delete a pronunciation dictionary by its UID.");
                        command.Arguments.Add(Uid);


        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var uid = parseResult.GetRequiredValue(Uid);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                await client.Pronunciations.DeletePronunciationDictionaryPronunciationsUidDeleteAsync(
                                    uid: uid,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);

                                await CliRuntime.WriteSuccessAsync(parseResult, cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}