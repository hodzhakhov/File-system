using System;
using System.IO;
using FS.Commands.TreeListCommand;
using FS.Commands.TreeListCommand.FileSystemElements;
using FS.Commands.TreeListCommand.Visitors;
using FS.FileSystems.Entities;
using FS.Paths;
using FS.Results;

namespace FS.FileSystems.Models;

public class FileSystem : IFileSystem
{
    private readonly FileSystemPath _currentPath;

    public FileSystem(FileSystemPath currentPath)
    {
        _currentPath = currentPath;
    }

    public CommandResult TreeList(int depth)
    {
        string path = _currentPath.Value + "\\";
        var fileSystemTree = new FileSystemTree();
        FileSystemDirectory? rootDirectory = fileSystemTree.CreateFileSystemTree(path, depth);

        var visitor = new Visitor(depth, 0);
        rootDirectory?.Accept(visitor);

        return new CommandResult.SuccessCommand();
    }

    public CommandResult FileShow(string path, string mode)
    {
        if (!Path.IsPathRooted(path))
        {
            path = _currentPath.Value + "\\" + path;
        }

        if (!File.Exists(path))
        {
            return new CommandResult.FailedCommand();
        }

        if (mode == "console")
        {
            string fileText = File.ReadAllText(path);
            Console.WriteLine(fileText);
        }

        return new CommandResult.SuccessCommand();
    }

    public CommandResult FileMove(string sourcePath, string destinationPath)
    {
        if (!Path.IsPathRooted(sourcePath))
        {
            sourcePath = _currentPath.Value + "\\" + sourcePath;
        }

        if (!File.Exists(sourcePath))
        {
            return new CommandResult.FailedCommand();
        }

        if (destinationPath == "\\")
        {
            destinationPath = _currentPath.Value + "\\";
        }
        else if (!Path.IsPathRooted(destinationPath))
        {
            destinationPath = _currentPath.Value + "\\" + destinationPath + "\\";
        }

        destinationPath += Path.GetFileName(sourcePath);

        File.Move(sourcePath, destinationPath, true);
        Console.WriteLine("File moved");

        return new CommandResult.SuccessCommand();
    }

    public CommandResult FileCopy(string sourcePath, string destinationPath)
    {
        if (!Path.IsPathRooted(sourcePath))
        {
            sourcePath = _currentPath.Value + "\\" + sourcePath;
        }

        if (!File.Exists(sourcePath))
        {
            return new CommandResult.FailedCommand();
        }

        if (destinationPath == "\\")
        {
            destinationPath = _currentPath.Value + "\\";
        }
        else if (!Path.IsPathRooted(destinationPath))
        {
            destinationPath = _currentPath.Value + "\\" + destinationPath + "\\";
        }

        destinationPath += Path.GetFileName(sourcePath);

        File.Copy(sourcePath, destinationPath, true);
        Console.WriteLine("File copied");

        return new CommandResult.SuccessCommand();
    }

    public CommandResult FileDelete(string path)
    {
        if (!Path.IsPathRooted(path))
        {
            path = _currentPath.Value + "\\" + path;
        }

        if (!File.Exists(path))
        {
            return new CommandResult.FailedCommand();
        }

        File.Delete(path);
        Console.WriteLine("File deleted");

        return new CommandResult.SuccessCommand();
    }

    public CommandResult FileRename(string path, string name)
    {
        if (!Path.IsPathRooted(path))
        {
            path = _currentPath.Value + "\\" + path;
        }

        if (!File.Exists(path))
        {
            return new CommandResult.FailedCommand();
        }

        name = Path.GetDirectoryName(path) + "\\" + name;

        File.Move(path, name, true);
        Console.WriteLine("File renamed");

        return new CommandResult.SuccessCommand();
    }
}
