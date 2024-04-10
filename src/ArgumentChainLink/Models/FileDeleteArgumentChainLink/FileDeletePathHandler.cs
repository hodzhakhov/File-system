using FS.CommandArguments.Builders.FileDeleteArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileDeleteArgumentChainLink;

public class FileDeletePathHandler : ArgumentChainLinkBase<FileDeleteArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileDeleteArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddPath(request.Current());
    }
}
