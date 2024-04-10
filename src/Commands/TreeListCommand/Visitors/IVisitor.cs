using FS.Commands.TreeListCommand.FileSystemElements;

namespace FS.Commands.TreeListCommand.Visitors;

public interface IVisitor
{
    void VisitFile(FileSystemFile fileSystemFile);
    void VisitDirectory(FileSystemDirectory fileSystemDirectory);
}
