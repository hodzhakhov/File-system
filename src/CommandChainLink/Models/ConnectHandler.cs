using FS.ArgumentChainLink.Models.ConnectArgumentChainLink;
using FS.CommandArguments.Builders.ConnectArgumentsBuilders;
using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models;

public class ConnectHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "connect")
        {
            if (request.Next())
            {
                var argumentsBuilder = new ConnectArgumentsBuilder();
                var connectAddressHandler = new ConnectAddressHandler();
                var connectModeHandler = new ConnectModeHandler();

                connectAddressHandler.AddNext(connectModeHandler);
                connectAddressHandler.Handle(request, argumentsBuilder);

                if (!argumentsBuilder.RequiredFields())
                {
                    return new HandleResult.FailedHandle("Not all connect command arguments were provided");
                }

                return new HandleResult.SuccessHandle(new ConnectDefaultCommand(argumentsBuilder.Build()));
            }
        }

        return Next?.Handle(request);
    }
}
