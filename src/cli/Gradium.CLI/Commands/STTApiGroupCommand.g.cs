#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class STTApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"stt", @"STT endpoint commands.");
                         command.Subcommands.Add(SttPostSpeechToTextCommandApiCommand.Create());
                         command.Subcommands.Add(SttStreamSpeechToTextCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}