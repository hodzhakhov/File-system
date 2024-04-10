using FS.Commands.TreeListCommand.Visitors;

namespace FS.Commands.TreeListCommand.FileSystemElements;

public class FileSystemFile : IFileSystemElement
{
    public FileSystemFile(string? name)
    {
        Name = name;
    }

    public string? Name { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitFile(this);
    }
}
