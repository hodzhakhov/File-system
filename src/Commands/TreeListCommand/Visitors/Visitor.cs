using System;
using FS.Commands.TreeListCommand.FileSystemElements;

namespace FS.Commands.TreeListCommand.Visitors;

public class Visitor : IVisitor
{
    private readonly int _depth;
    private readonly int _indent;

    public Visitor(int depth, int indent)
    {
        _depth = depth;
        _indent = indent;
    }

    public void VisitFile(FileSystemFile fileSystemFile)
    {
        PrintElement(fileSystemFile);
    }

    public void VisitDirectory(FileSystemDirectory fileSystemDirectory)
    {
        PrintElement(fileSystemDirectory);

        if (_depth > 0)
        {
            foreach (IFileSystemElement child in fileSystemDirectory.Children)
            {
                child.Accept(new Visitor(_depth - 1, _indent + 1));
            }
        }
    }

    private void PrintElement(IFileSystemElement element)
    {
        string indent = new('-', _indent);
        Console.WriteLine($"{indent}{element.Name}");
    }
}
