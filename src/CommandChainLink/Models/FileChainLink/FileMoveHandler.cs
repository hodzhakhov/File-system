using FS.ArgumentChainLink.Models.FileMoveArgumentChainLink;
using FS.CommandArguments.Builders.FileMoveArgumentsBuilders;
using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models.FileChainLink;

public class FileMoveHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "move")
        {
            if (request.Next())
            {
                var argumentsBuilder = new FileMoveArgumentsBuilder();
                var fileMoveSourceHandler = new FileMoveSourceHandler();
                var fileMoveDestinationHandler = new FileMoveDestinationHandler();

                fileMoveSourceHandler.AddNext(fileMoveDestinationHandler);
                fileMoveSourceHandler.Handle(request, argumentsBuilder);

                if (!argumentsBuilder.RequiredFields())
                {
                    return new HandleResult.FailedHandle("Not all FileMove command arguments were provided");
                }

                return new HandleResult.SuccessHandle(new FileMoveDefaultCommand(argumentsBuilder.Build()));
            }
        }

        return Next?.Handle(request);
    }
}
