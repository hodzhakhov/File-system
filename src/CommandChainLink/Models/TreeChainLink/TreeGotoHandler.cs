using FS.ArgumentChainLink.Models.TreeGotoArgumentChainLink;
using FS.CommandArguments.Builders.TreeGotoArgumentsBuilders;
using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models.TreeChainLink;

public class TreeGotoHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "goto")
        {
            if (request.Next())
            {
                var argumentsBuilder = new TreeGotoArgumentsBuilder();
                var treeGotoPathHandler = new TreeGotoPathHandler();

                treeGotoPathHandler.Handle(request, argumentsBuilder);

                if (!argumentsBuilder.RequiredFields())
                {
                    return new HandleResult.FailedHandle("Not all TreeGoto command arguments were provided");
                }

                return new HandleResult.SuccessHandle(new TreeGotoDefaultCommand(argumentsBuilder.Build()));
            }
        }

        return Next?.Handle(request);
    }
}
