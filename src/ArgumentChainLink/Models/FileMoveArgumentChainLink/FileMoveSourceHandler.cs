using FS.CommandArguments.Builders.FileMoveArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileMoveArgumentChainLink;

public class FileMoveSourceHandler : ArgumentChainLinkBase<FileMoveArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileMoveArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddSourcePath(request.Current());
        request.Next();

        Next?.Handle(request, argumentsBuilder);
    }
}
