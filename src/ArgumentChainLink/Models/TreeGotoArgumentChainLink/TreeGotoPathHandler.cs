using FS.CommandArguments.Builders.TreeGotoArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.TreeGotoArgumentChainLink;

public class TreeGotoPathHandler : ArgumentChainLinkBase<TreeGotoArgumentsBuilder>
{
    public override void Handle(RequestIterator request, TreeGotoArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddPath(request.Current());
    }
}
