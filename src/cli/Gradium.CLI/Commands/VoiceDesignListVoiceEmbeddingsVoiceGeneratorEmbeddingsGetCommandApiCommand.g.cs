#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoiceDesignListVoiceEmbeddingsVoiceGeneratorEmbeddingsGetCommandApiCommand
{
    private static Option<string?> EmbeddingId { get; } = new(
        name: @"--embedding-id")
    {
        Description = @"Look up a single candidate by id. Omit to list all candidates.",
    };

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

                    private static string FormatResponse(ParseResult parseResult, global::Gradium.VoiceEmbeddingListResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Gradium.VoiceEmbeddingListResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"list-voice-embeddings-voice-generator-embeddings-get", @"List Voice Candidates
Check whether a candidate is ready, or list the candidates belonging to the authenticated organization, newest first.

Pass `embedding_id` to look up a single candidate. Omit it to page through all of them with `skip` and `limit`, which is also how you recover ids you did not store. A page shorter than `limit` is the last page.

A lookup for an id this organization does not hold returns `200` with an empty `embeddings` list, so check the list before indexing into it.");
                        command.Options.Add(EmbeddingId);
                        command.Options.Add(Skip);
                        command.Options.Add(Limit);


        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var embeddingId = parseResult.GetValue(EmbeddingId);
                        var skip = parseResult.GetValue(Skip);
                        var limit = parseResult.GetValue(Limit);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.VoiceDesign.ListVoiceEmbeddingsVoiceGeneratorEmbeddingsGetAsync(
                                    embeddingId: embeddingId,
                                    skip: skip,
                                    limit: limit,
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