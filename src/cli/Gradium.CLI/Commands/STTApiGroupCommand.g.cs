#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class STTApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"stt", @"STT endpoint commands.");
                         command.Subcommands.Add(SttPostSpeechToTextCommandApiCommand.Create());
                         command.Subcommands.Add(SttStreamSpeechToTextCommandApiCommand.Create());
        return command;
    }
}