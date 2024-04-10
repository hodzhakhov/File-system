using FS.ArgumentChainLink.Models.TreeListArgumentChainLink;
using FS.CommandArguments.Builders.TreeListArgumentsBuilders;
using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models.TreeChainLink;

public class TreeListHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "list")
        {
            var argumentsBuilder = new TreeListArgumentsBuilder();
            var treeListDepthHandler = new TreeListDepthHandler();

            treeListDepthHandler.Handle(request, argumentsBuilder);

            return new HandleResult.SuccessHandle(new TreeListDefaultCommand(argumentsBuilder.Build()));
        }

        return Next?.Handle(request);
    }
}
