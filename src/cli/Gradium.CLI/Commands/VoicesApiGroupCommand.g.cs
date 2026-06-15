#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class VoicesApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"voices", @"Voices endpoint commands.");
                         command.Subcommands.Add(VoicesCreateVoiceVoicesPostCommandApiCommand.Create());
                         command.Subcommands.Add(VoicesDeleteVoiceVoicesVoiceUidDeleteCommandApiCommand.Create());
                         command.Subcommands.Add(VoicesGetVoiceVoicesVoiceUidGetCommandApiCommand.Create());
                         command.Subcommands.Add(VoicesGetVoicesVoicesGetCommandApiCommand.Create());
                         command.Subcommands.Add(VoicesUpdateVoiceVoicesVoiceUidPutCommandApiCommand.Create());
        return command;
    }
}