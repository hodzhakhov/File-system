using FS.ArgumentChainLink.Models.FileShowArgumentChainLink;
using FS.CommandArguments.Builders.FileShowArgumentsBuilders;
using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models.FileChainLink;

public class FileShowHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "show")
        {
            if (request.Next())
            {
                var argumentsBuilder = new FileShowArgumentsBuilder();
                var fileShowPathHandler = new FileShowPathHandler();
                var fileShowModeHandler = new FileShowModeHandler();

                fileShowPathHandler.AddNext(fileShowModeHandler);
                fileShowPathHandler.Handle(request, argumentsBuilder);

                if (!argumentsBuilder.RequiredFields())
                {
                    return new HandleResult.FailedHandle("Not all FileShow command arguments were provided");
                }

                return new HandleResult.SuccessHandle(new FileShowDefaultCommand(argumentsBuilder.Build()));
            }
        }

        return Next?.Handle(request);
    }
}
