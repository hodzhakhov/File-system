using FS.ArgumentChainLink.Models.FileCopyArgumentChainLink;
using FS.CommandArguments.Builders.FileCopyArgumentsBuilders;
using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models.FileChainLink;

public class FileCopyHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "copy")
        {
            if (request.Next())
            {
                var argumentsBuilder = new FileCopyArgumentsBuilder();
                var fileCopySourceHandler = new FileCopySourceHandler();
                var fileCopyDestinationHandler = new FileCopyDestinationHandler();

                fileCopySourceHandler.AddNext(fileCopyDestinationHandler);
                fileCopySourceHandler.Handle(request, argumentsBuilder);

                if (!argumentsBuilder.RequiredFields())
                {
                    return new HandleResult.FailedHandle("Not all FileCopy command arguments were provided");
                }

                return new HandleResult.SuccessHandle(new FileCopyDefaultCommand(argumentsBuilder.Build()));
            }
        }

        return Next?.Handle(request);
    }
}
