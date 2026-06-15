#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class TTSApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"tts", @"TTS endpoint commands.");
                         command.Subcommands.Add(TtsCreatePostSpeechTtsCommandApiCommand.Create());
                         command.Subcommands.Add(TtsGetSpeechTtsCommandApiCommand.Create());
        return command;
    }
}