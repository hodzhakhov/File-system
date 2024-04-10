using FS.CommandArguments.TreeListCommandArguments;
using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class TreeListDefaultCommand : ICommand
{
    private readonly TreeListDefaultArguments _arguments;

    public TreeListDefaultCommand(TreeListDefaultArguments arguments)
    {
        _arguments = arguments;
    }

    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        return fileSystem.FileSystem?.TreeList(_arguments.Depth);
    }
}
