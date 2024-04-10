using FS.Results;

namespace FS.FileSystems.Entities;

public interface IFileSystem
{
    CommandResult TreeList(int depth);
    CommandResult FileShow(string path, string mode);
    CommandResult FileMove(string sourcePath, string destinationPath);
    CommandResult FileCopy(string sourcePath, string destinationPath);
    CommandResult? FileDelete(string path);
    CommandResult FileRename(string path, string name);
}
