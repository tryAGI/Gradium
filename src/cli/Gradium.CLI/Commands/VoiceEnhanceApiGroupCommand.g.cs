#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoiceEnhanceApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"voice-enhance", @"Voice Enhance endpoint commands.");
                         command.Subcommands.Add(VoiceEnhanceEnhanceVoiceGeneratorEnhancePostCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}