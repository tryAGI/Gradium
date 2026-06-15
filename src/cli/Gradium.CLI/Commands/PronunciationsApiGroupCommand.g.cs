#nullable enable

using System.CommandLine;

namespace Gradium.CLI.Commands;

internal static class PronunciationsApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"pronunciations", @"Pronunciations endpoint commands.");
                         command.Subcommands.Add(PronunciationsCreatePronunciationDictionaryPronunciationsPostCommandApiCommand.Create());
                         command.Subcommands.Add(PronunciationsDeletePronunciationDictionaryPronunciationsUidDeleteCommandApiCommand.Create());
                         command.Subcommands.Add(PronunciationsGetPronunciationDictionaryPronunciationsUidGetCommandApiCommand.Create());
                         command.Subcommands.Add(PronunciationsListPronunciationDictionariesPronunciationsGetCommandApiCommand.Create());
                         command.Subcommands.Add(PronunciationsUpdatePronunciationDictionaryPronunciationsUidPutCommandApiCommand.Create());
        return command;
    }
}