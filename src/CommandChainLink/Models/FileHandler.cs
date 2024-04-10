using FS.CommandChainLink.Entities;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models;

public class FileHandler : CommandChainLinkBase
{
    private readonly ICommandChainLink _fileChain;

    public FileHandler(ICommandChainLink fileChain)
    {
        _fileChain = fileChain;
    }

    public override HandleResult? Handle(RequestIterator request)
    {
        if (request.Current() == "file")
        {
            if (request.Next())
            {
                return _fileChain.Handle(request);
            }
        }

        return Next?.Handle(request);
    }
}
