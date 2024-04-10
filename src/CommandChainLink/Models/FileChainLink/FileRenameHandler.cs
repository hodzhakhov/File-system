using FS.ArgumentChainLink.Models.FileRenameArgumentChainLink;
using FS.CommandArguments.Builders.FileRenameArgumentsBuilders;
using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models.FileChainLink;

public class FileRenameHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "rename")
        {
            if (request.Next())
            {
                var argumentsBuilder = new FileRenameArgumentsBuilder();
                var fileRenamePathHandler = new FileRenamePathHandler();
                var fileRenameNameHandler = new FileRenameNameHandler();

                fileRenamePathHandler.AddNext(fileRenameNameHandler);
                fileRenamePathHandler.Handle(request, argumentsBuilder);

                if (!argumentsBuilder.RequiredFields())
                {
                    return new HandleResult.FailedHandle("Not all FileRename command arguments were provided");
                }

                return new HandleResult.SuccessHandle(new FileRenameDefaultCommand(argumentsBuilder.Build()));
            }
        }

        return Next?.Handle(request);
    }
}
