using System;
using FS.CommandArguments.FileMoveCommandArguments;
using FS.Paths;

namespace FS.CommandArguments.Builders.FileMoveArgumentsBuilders;

public class FileMoveArgumentsBuilder : IFileMoveArgumentsBuilder
{
    private FileSystemPath? _sourcePath;
    private FileSystemPath? _destinationPath;

    public void AddSourcePath(string sourcePath)
    {
        _sourcePath = new FileSystemPath(sourcePath);
    }

    public void AddDestinationPath(string destinationPath)
    {
        _destinationPath = new FileSystemPath(destinationPath);
    }

    public bool RequiredFields()
    {
        return _sourcePath is not null && _destinationPath is not null;
    }

    public FileMoveDefaultArguments Build()
    {
        return new FileMoveDefaultArguments(
            _sourcePath ?? throw new ArgumentNullException(nameof(_sourcePath)),
            _destinationPath ?? throw new ArgumentNullException(nameof(_destinationPath)));
    }
}
