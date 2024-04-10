using FS.CommandArguments.FileDeleteCommandArguments;
using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class FileDeleteDefaultCommand : ICommand
{
    private readonly FileDeleteDefaultArguments _arguments;

    public FileDeleteDefaultCommand(FileDeleteDefaultArguments arguments)
    {
        _arguments = arguments;
    }

    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        return fileSystem.FileSystem?.FileDelete(_arguments.Path.Value);
    }
}
