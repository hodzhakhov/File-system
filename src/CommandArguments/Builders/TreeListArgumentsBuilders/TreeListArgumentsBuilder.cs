using FS.CommandArguments.TreeListCommandArguments;

namespace FS.CommandArguments.Builders.TreeListArgumentsBuilders;

public class TreeListArgumentsBuilder : ITreeListArgumentsBuilder
{
    private int _depth;

    public void AddDepth(int depth)
    {
        _depth = depth;
    }

    public TreeListDefaultArguments Build()
    {
        return new TreeListDefaultArguments(_depth == 0 ? 1 : _depth);
    }
}
