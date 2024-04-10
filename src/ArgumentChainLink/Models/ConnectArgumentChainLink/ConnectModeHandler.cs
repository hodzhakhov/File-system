using FS.CommandArguments.Builders.ConnectArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.ConnectArgumentChainLink;

public class ConnectModeHandler : ArgumentChainLinkBase<ConnectArgumentsBuilder>
{
    public override void Handle(RequestIterator request, ConnectArgumentsBuilder argumentsBuilder)
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
