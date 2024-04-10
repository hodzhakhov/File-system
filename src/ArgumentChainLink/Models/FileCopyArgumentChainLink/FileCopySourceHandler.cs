using FS.CommandArguments.Builders.FileCopyArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileCopyArgumentChainLink;

public class FileCopySourceHandler : ArgumentChainLinkBase<FileCopyArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileCopyArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddSourcePath(request.Current());
        request.Next();

        Next?.Handle(request, argumentsBuilder);
    }
}
