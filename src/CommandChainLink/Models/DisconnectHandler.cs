using FS.Commands.Models;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models;

public class DisconnectHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "disconnect")
        {
            return new HandleResult.SuccessHandle(new DisconnectDefaultCommand());
        }

        return Next?.Handle(request);
    }
}
