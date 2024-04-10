using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models;

public class DefaultHandler : CommandChainLinkBase
{
    public override HandleResult? Handle(RequestIterator request)
    {
        return new HandleResult.FailedHandle("Wrong request!");
    }
}
