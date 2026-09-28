#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class MeteringApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"metering", @"metering endpoint commands.");
                         command.Subcommands.Add(MeteringGetCreditsUsagesCreditsGetCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}