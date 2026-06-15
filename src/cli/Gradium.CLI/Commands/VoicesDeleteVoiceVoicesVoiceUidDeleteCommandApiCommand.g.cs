#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoicesDeleteVoiceVoicesVoiceUidDeleteCommandApiCommand
{
    private static Argument<string> VoiceUid { get; } = new(
        name: @"voice-uid")
    {
        Description = @"",
    };

    public static Command Create()
    {
        var command = new Command(@"delete-voice-voices-voice-uid-delete", @"Delete Voice
Delete a voice by its UID.");
                        command.Arguments.Add(VoiceUid);


        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var voiceUid = parseResult.GetRequiredValue(VoiceUid);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                await client.Voices.DeleteVoiceVoicesVoiceUidDeleteAsync(
                                    voiceUid: voiceUid,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);

                                await CliRuntime.WriteSuccessAsync(parseResult, cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}