#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class TTSApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"tts", @"TTS endpoint commands.");
                         command.Subcommands.Add(TtsPostTextToSpeechCommandApiCommand.Create());
                         command.Subcommands.Add(TtsStreamTextToSpeechCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}