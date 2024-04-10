using FS.CommandArguments.ConnectCommandArguments;
using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class ConnectDefaultCommand : ICommand
{
    private readonly ConnectDefaultArguments _arguments;

    public ConnectDefaultCommand(ConnectDefaultArguments arguments)
    {
        _arguments = arguments;
    }

    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        if (_arguments.Mode.Value == "local")
        {
            return fileSystem.SetConnection(_arguments.Address);
        }

        return new CommandResult.FailedCommand();
    }
}
