using FS.Commands.TreeListCommand.Visitors;

namespace FS.Commands.TreeListCommand.FileSystemElements;

public interface IFileSystemElement
{
    public string? Name { get; }
    void Accept(IVisitor visitor);
}
