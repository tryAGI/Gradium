#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class STTApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"stt", @"STT endpoint commands.");
                         command.Subcommands.Add(SttCreatePostSpeechAsrCommandApiCommand.Create());
                         command.Subcommands.Add(SttGetSpeechAsrCommandApiCommand.Create());
        return command;
    }
}