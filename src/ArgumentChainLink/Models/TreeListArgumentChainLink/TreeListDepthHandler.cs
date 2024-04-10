using System.Globalization;
using FS.CommandArguments.Builders.TreeListArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.TreeListArgumentChainLink;

public class TreeListDepthHandler : ArgumentChainLinkBase<TreeListArgumentsBuilder>
{
    public override void Handle(RequestIterator request, TreeListArgumentsBuilder argumentsBuilder)
    {
        request.Reset();
        while (request.Next())
        {
            if (request.Current() == "-d")
            {
                request.Next();
                argumentsBuilder.AddDepth(int.Parse(request.Current(), CultureInfo.CurrentCulture));
                return;
            }
        }
    }
}
