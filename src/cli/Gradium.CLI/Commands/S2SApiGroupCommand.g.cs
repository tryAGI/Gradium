#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class S2SApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"s2-s", @"S2S endpoint commands.");
                         command.Subcommands.Add(S2sStreamSpeechToSpeechCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}