using System;
using FS.CommandArguments.FileRenameCommandArguments;
using FS.Paths;

namespace FS.CommandArguments.Builders.FileRenameArgumentsBuilders;

public class FileRenameArgumentsBuilder : IFileRenameArgumentsBuilder
{
    private FileSystemPath? _path;
    private string? _name;

    public void AddPath(string path)
    {
        _path = new FileSystemPath(path);
    }

    public void AddName(string name)
    {
        _name = name;
    }

    public bool RequiredFields()
    {
        return _path is not null && _name is not null;
    }

    public FileRenameDefaultArguments Build()
    {
        return new FileRenameDefaultArguments(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}
