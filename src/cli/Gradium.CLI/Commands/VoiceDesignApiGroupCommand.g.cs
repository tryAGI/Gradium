#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class VoiceDesignApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"voice-design", @"Voice Design endpoint commands.");
                         command.Subcommands.Add(VoiceDesignCreateVoiceFromEmbeddingVoicesFromEmbeddingPostCommandApiCommand.Create());
                         command.Subcommands.Add(VoiceDesignDeleteVoiceEmbeddingVoiceGeneratorEmbeddingsEmbeddingIdDeleteCommandApiCommand.Create());
                         command.Subcommands.Add(VoiceDesignGenerateVoiceVoiceGeneratorGeneratePostCommandApiCommand.Create());
                         command.Subcommands.Add(VoiceDesignListVoiceEmbeddingsVoiceGeneratorEmbeddingsGetCommandApiCommand.Create());
        return command;
    }
}