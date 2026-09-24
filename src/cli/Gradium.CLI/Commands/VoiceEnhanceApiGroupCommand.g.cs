#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class VoiceEnhanceApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"voice-enhance", @"Voice Enhance endpoint commands.");
                         command.Subcommands.Add(VoiceEnhanceEnhanceVoiceGeneratorEnhancePostCommandApiCommand.Create());
        return command;
    }
}