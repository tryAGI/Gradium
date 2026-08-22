#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class TTSApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"tts", @"TTS endpoint commands.");
                         command.Subcommands.Add(TtsPostTextToSpeechCommandApiCommand.Create());
                         command.Subcommands.Add(TtsStreamTextToSpeechCommandApiCommand.Create());
        return command;
    }
}