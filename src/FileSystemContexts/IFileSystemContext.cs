using FS.FileSystems.Entities;
using FS.Paths;
using FS.Results;

namespace FS.FileSystemContexts;

public interface IFileSystemContext
{
    public IFileSystem? FileSystem { get; }
    CommandResult? SetConnection(FileSystemPath path);
    CommandResult? RemoveConnection();
    CommandResult TreeGoto(FileSystemPath path);
}
