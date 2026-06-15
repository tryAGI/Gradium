#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class S2SApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"s2-s", @"S2S endpoint commands.");
                         command.Subcommands.Add(S2sGetSpeechS2sCommandApiCommand.Create());
        return command;
    }
}