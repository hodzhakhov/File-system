using System;
using FS.CommandArguments.TreeGotoCommandArguments;
using FS.Paths;

namespace FS.CommandArguments.Builders.TreeGotoArgumentsBuilders;

public class TreeGotoArgumentsBuilder : ITreeGotoArgumentsBuilder
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

    public TreeGotoDefaultArguments Build()
    {
        return new TreeGotoDefaultArguments(
            _path ?? throw new ArgumentNullException(nameof(_path)));
    }
}
