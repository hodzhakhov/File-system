using FS.CommandChainLink.Entities;
using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Models;

public abstract class CommandChainLinkBase : ICommandChainLink
{
    protected ICommandChainLink? Next { get; set; }

    public void AddNext(ICommandChainLink link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract HandleResult? Handle(RequestIterator request);
}
