#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoiceDesignDeleteVoiceEmbeddingVoiceGeneratorEmbeddingsEmbeddingIdDeleteCommandApiCommand
{
    private static Argument<string> EmbeddingId { get; } = new(
        name: @"embedding-id")
    {
        Description = @"",
    };

    public static Command Create()
    {
        var command = new Command(@"delete-voice-embedding-voice-generator-embeddings-embedding-id-delete", @"Delete Voice Candidate
Remove a candidate you are not keeping. Candidates you leave alone are removed automatically after 30 days.

Safe at any time: a voice kept from a candidate holds its own copy, so deleting the candidate leaves the voice untouched. An id that is already gone returns `404`, so treat cleanup as best effort.");
                        command.Arguments.Add(EmbeddingId);


        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var embeddingId = parseResult.GetRequiredValue(EmbeddingId);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                await client.VoiceDesign.DeleteVoiceEmbeddingVoiceGeneratorEmbeddingsEmbeddingIdDeleteAsync(
                                    embeddingId: embeddingId,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);

                                await CliRuntime.WriteSuccessAsync(parseResult, cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}