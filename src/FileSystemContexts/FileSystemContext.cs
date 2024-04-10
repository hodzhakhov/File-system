using System.IO;
using FS.FileSystems.Entities;
using FS.FileSystems.Models;
using FS.Paths;
using FS.Results;

namespace FS.FileSystemContexts;

public class FileSystemContext : IFileSystemContext
{
    private FileSystemPath? _currentPath;
    public IFileSystem? FileSystem { get; private set; }

    public CommandResult? SetConnection(FileSystemPath path)
    {
        _currentPath = path;
        FileSystem = new FileSystem(_currentPath);

        return new CommandResult.SuccessCommand();
    }

    public CommandResult? RemoveConnection()
    {
        FileSystem = null;
        _currentPath = null;

        return new CommandResult.SuccessCommand();
    }

    public CommandResult TreeGoto(FileSystemPath path)
    {
        if (_currentPath is not null)
        {
            _currentPath = Path.IsPathRooted(path.Value)
                ? path
                : new FileSystemPath(_currentPath.Value + "\\" + path.Value);
            FileSystem = new FileSystem(_currentPath);

            return new CommandResult.SuccessCommand();
        }

        return new CommandResult.FailedCommand();
    }
}
