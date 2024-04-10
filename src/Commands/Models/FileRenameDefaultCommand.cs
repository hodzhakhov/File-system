using FS.CommandArguments.FileRenameCommandArguments;
using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class FileRenameDefaultCommand : ICommand
{
    private readonly FileRenameDefaultArguments _arguments;

    public FileRenameDefaultCommand(FileRenameDefaultArguments arguments)
    {
        _arguments = arguments;
    }

    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        return fileSystem.FileSystem?.FileRename(_arguments.Path.Value, _arguments.Name);
    }
}
