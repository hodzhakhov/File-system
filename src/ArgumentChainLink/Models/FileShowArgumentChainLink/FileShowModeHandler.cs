using FS.CommandArguments.Builders.FileShowArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.FileShowArgumentChainLink;

public class FileShowModeHandler : ArgumentChainLinkBase<FileShowArgumentsBuilder>
{
    public override void Handle(RequestIterator request, FileShowArgumentsBuilder argumentsBuilder)
    {
        request.Reset();
        while (request.Next())
        {
            if (request.Current() == "-m")
            {
                request.Next();
                argumentsBuilder.AddMode(request.Current());
                return;
            }
        }
    }
}
