using System;
using FS.CommandArguments.FileShowCommandArguments;
using FS.Modes;
using FS.Paths;

namespace FS.CommandArguments.Builders.FileShowArgumentsBuilders;

public class FileShowArgumentsBuilder : IFileShowArgumentsBuilder
{
    private FileSystemPath? _path;
    private Mode? _mode;

    public void AddPath(string path)
    {
        _path = new FileSystemPath(path);
    }

    public void AddMode(string mode)
    {
        _mode = new Mode(mode);
    }

    public bool RequiredFields()
    {
        return _path is not null && _mode is not null;
    }

    public FileShowDefaultArguments Build()
    {
        return new FileShowDefaultArguments(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _mode ?? throw new ArgumentNullException(nameof(_mode)));
    }
}
