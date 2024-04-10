using System.Collections.Generic;
using FS.Commands.TreeListCommand.Visitors;

namespace FS.Commands.TreeListCommand.FileSystemElements;

public class FileSystemDirectory : IFileSystemElement
{
    private readonly List<IFileSystemElement> _children = new List<IFileSystemElement>();

    public FileSystemDirectory(string? name)
    {
        Name = name;
    }

    public string? Name { get; }

    public IEnumerable<IFileSystemElement> Children => _children;

    public void AddChild(IFileSystemElement child)
    {
        _children.Add(child);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitDirectory(this);
    }
}
