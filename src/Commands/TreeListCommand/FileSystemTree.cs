using System.IO;
using FS.Commands.TreeListCommand.FileSystemElements;

namespace FS.Commands.TreeListCommand;

public class FileSystemTree
{
    public FileSystemDirectory? CreateFileSystemTree(string path, int depth)
    {
        if (depth <= 0) return null;

        var rootDirectory = new FileSystemDirectory(Path.GetDirectoryName(path));
        foreach (string directoryPath in Directory.GetDirectories(path))
        {
            FileSystemDirectory? subDirectory = CreateFileSystemTree(directoryPath + "\\", depth - 1);
            if (subDirectory is not null)
                rootDirectory.AddChild(subDirectory);
        }

        foreach (string filePath in Directory.GetFiles(path))
        {
            var file = new FileSystemFile(Path.GetFileName(filePath));
            rootDirectory.AddChild(file);
        }

        return rootDirectory;
    }
}
