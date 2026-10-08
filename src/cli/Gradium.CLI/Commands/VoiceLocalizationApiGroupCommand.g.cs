#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static partial class VoiceLocalizationApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"voice-localization", @"Voice Localization endpoint commands.");
                         command.Subcommands.Add(VoiceLocalizationListAvailableAccentsVoiceGeneratorAvailableAccentsGetCommandApiCommand.Create());
                         command.Subcommands.Add(VoiceLocalizationLocalizeVoiceVoiceGeneratorLocalizePostCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}