using FS.CommandArguments.Builders.ConnectArgumentsBuilders;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models.ConnectArgumentChainLink;

public class ConnectAddressHandler : ArgumentChainLinkBase<ConnectArgumentsBuilder>
{
    public override void Handle(RequestIterator request, ConnectArgumentsBuilder argumentsBuilder)
    {
        argumentsBuilder.AddAddress(request.Current());
        request.Next();

        Next?.Handle(request, argumentsBuilder);
    }
}
