using FS.CommandArguments.FileCopyCommandArguments;
using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class FileCopyDefaultCommand : ICommand
{
    private readonly FileCopyDefaultArguments _arguments;

    public FileCopyDefaultCommand(FileCopyDefaultArguments arguments)
    {
        _arguments = arguments;
    }

    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        return fileSystem.FileSystem?.FileCopy(_arguments.SourcePath.Value, _arguments.DestinationPath.Value);
    }
}
