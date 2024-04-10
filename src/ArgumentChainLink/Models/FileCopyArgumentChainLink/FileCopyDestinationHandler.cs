using FS.CommandArguments.Builders.FileCopyArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileCopyArgumentChainLink;

public class FileCopyDestinationHandler : ArgumentChainLinkBase<FileCopyArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileCopyArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddDestinationPath(request.Current());
    }
}
