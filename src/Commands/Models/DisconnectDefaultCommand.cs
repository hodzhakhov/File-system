using FS.Commands.Entities;
using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Models;

public class DisconnectDefaultCommand : ICommand
{
    public CommandResult? Execute(IFileSystemContext fileSystem)
    {
        return fileSystem.RemoveConnection();
    }
}
