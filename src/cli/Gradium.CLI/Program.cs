#nullable enable

using System.CommandLine;
using Gradium.CLI;
using Gradium.CLI.Commands;

var rootCommand = new RootCommand(@"CLI tool for the Gradium SDK.");
rootCommand.Options.Add(CliOptions.ApiKey);
rootCommand.Options.Add(CliOptions.BaseUrl);
rootCommand.Options.Add(CliOptions.Json);
rootCommand.Options.Add(CliOptions.Output);
rootCommand.Options.Add(CliOptions.OutputDirectory);
rootCommand.Subcommands.Add(AuthCommand.Create());
rootCommand.Subcommands.Add(MeteringApiGroupCommand.Create());
rootCommand.Subcommands.Add(PronunciationsApiGroupCommand.Create());
rootCommand.Subcommands.Add(STTApiGroupCommand.Create());
rootCommand.Subcommands.Add(TTSApiGroupCommand.Create());
rootCommand.Subcommands.Add(VoicesApiGroupCommand.Create());

return await rootCommand.Parse(args).InvokeAsync().ConfigureAwait(false);