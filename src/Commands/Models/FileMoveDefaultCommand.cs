using FS.CommandArguments.FileMoveCommandArguments;
using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class FileMoveDefaultCommand : ICommand
{
    private readonly FileMoveDefaultArguments _arguments;

    public FileMoveDefaultCommand(FileMoveDefaultArguments arguments)
    {
        _arguments = arguments;
    }

    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        return fileSystem.FileSystem?.FileMove(_arguments.SourcePath.Value, _arguments.DestinationPath.Value);
    }
}
