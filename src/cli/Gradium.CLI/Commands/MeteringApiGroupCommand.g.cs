#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class MeteringApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"metering", @"metering endpoint commands.");
                         command.Subcommands.Add(MeteringGetCreditsUsagesCreditsGetCommandApiCommand.Create());
        return command;
    }
}