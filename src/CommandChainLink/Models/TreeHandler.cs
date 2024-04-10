using FS.CommandChainLink.Entities;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models;

public class TreeHandler : CommandChainLinkBase
{
    private readonly ICommandChainLink _treeChain;

    public TreeHandler(ICommandChainLink fileChain)
    {
        _treeChain = fileChain;
    }

    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "tree")
        {
            if (request.Next())
            {
                return _treeChain.Handle(request);
            }
        }

        return Next?.Handle(request);
    }
}
