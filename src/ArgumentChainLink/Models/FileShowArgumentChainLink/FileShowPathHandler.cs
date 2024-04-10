using FS.CommandArguments.Builders.FileShowArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileShowArgumentChainLink;

public class FileShowPathHandler : ArgumentChainLinkBase<FileShowArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileShowArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddPath(request.Current());
        request.Next();

        Next?.Handle(request, argumentsBuilder);
    }
}
