using FS.CommandArguments.Builders.FileRenameArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileRenameArgumentChainLink;

public class FileRenameNameHandler : ArgumentChainLinkBase<FileRenameArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileRenameArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddName(request.Current());
    }
}
