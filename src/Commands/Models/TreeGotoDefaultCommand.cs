using FS.CommandArguments.TreeGotoCommandArguments;
using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class TreeGotoDefaultCommand : ICommand
{
    private readonly TreeGotoDefaultArguments _arguments;

    public TreeGotoDefaultCommand(TreeGotoDefaultArguments arguments)
    {
        _arguments = arguments;
    }

    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        return fileSystem.TreeGoto(_arguments.Path);
    }
}
