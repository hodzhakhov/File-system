using FS.CommandArguments.Builders.FileMoveArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileMoveArgumentChainLink;

public class FileMoveDestinationHandler : ArgumentChainLinkBase<FileMoveArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileMoveArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddDestinationPath(request.Current());
    }
}
