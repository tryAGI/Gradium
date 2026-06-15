#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class ApiCommand
{
    public static Command Create()
    {
        var command = new Command("api", "Generated endpoint commands.");

                         command.Subcommands.Add(MeteringApiGroupCommand.Create());
                         command.Subcommands.Add(PronunciationsApiGroupCommand.Create());
                         command.Subcommands.Add(STTApiGroupCommand.Create());
                         command.Subcommands.Add(TTSApiGroupCommand.Create());
                         command.Subcommands.Add(VoicesApiGroupCommand.Create());
        return command;
    }
}