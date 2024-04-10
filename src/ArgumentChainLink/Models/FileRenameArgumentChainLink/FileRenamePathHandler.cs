using FS.CommandArguments.Builders.FileRenameArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileRenameArgumentChainLink;

public class FileRenamePathHandler : ArgumentChainLinkBase<FileRenameArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileRenameArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddPath(request.Current());
        request.Next();

        Next?.Handle(request, argumentsBuilder);
    }
}
