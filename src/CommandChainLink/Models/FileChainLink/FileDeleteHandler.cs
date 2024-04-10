using FS.ArgumentChainLink.Models.FileDeleteArgumentChainLink;
using FS.CommandArguments.Builders.FileDeleteArgumentsBuilders;
using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models.FileChainLink;

public class FileDeleteHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "delete")
        {
            if (request.Next())
            {
                var argumentsBuilder = new FileDeleteArgumentsBuilder();
                var fileDeletePathHandler = new FileDeletePathHandler();

                fileDeletePathHandler.Handle(request, argumentsBuilder);

                if (!argumentsBuilder.RequiredFields())
                {
                    return new HandleResult.FailedHandle("Not all FileDelete command arguments were provided");
                }

                return new HandleResult.SuccessHandle(new FileDeleteDefaultCommand(argumentsBuilder.Build()));
            }
        }

        return Next?.Handle(request);
    }
}
