using FS.FileSystemContexts;
using FS.Results;

namespace FS.Commands.Entities;

public interface ICommand
{
    CommandResult? Execute(IFileSystemContext fileSystem);
}
