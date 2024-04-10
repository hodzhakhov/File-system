using FS.CommandArguments.FileShowCommandArguments;
using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class FileShowDefaultCommand : ICommand
{
    private readonly FileShowDefaultArguments _arguments;

    public FileShowDefaultCommand(FileShowDefaultArguments arguments)
    {
        _arguments = arguments;
    }

    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        return fileSystem.FileSystem?.FileShow(_arguments.Path.Value, _arguments.Mode.Value);
    }
}
