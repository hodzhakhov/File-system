using System;
using FS.CommandArguments.FileDeleteCommandArguments;
using FS.Paths;

namespace FS.CommandArguments.Builders.FileDeleteArgumentsBuilders;

public class FileDeleteArgumentsBuilder : IFileDeleteArgumentsBuilder
{
    private FileSystemPath? _path;

    public void AddPath(string path)
    {
        _path = new FileSystemPath(path);
    }

    public bool RequiredFields()
    {
        return _path is not null;
    }

    public FileDeleteDefaultArguments Build()
    {
        return new FileDeleteDefaultArguments(
            _path ?? throw new ArgumentNullException(nameof(_path)));
    }
}
