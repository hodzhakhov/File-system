using FS.ArgumentChainLink.Entities;
using FS.RequestIterators;

namespace FS.ArgumentChainLink.Models;

public abstract class ArgumentChainLinkBase<TBuilder> : IArgumentChainLink<TBuilder>
{
    protected IArgumentChainLink<TBuilder>? Next { get; set; }

    public void AddNext(IArgumentChainLink<TBuilder> link)
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

    public abstract void Handle(RequestIterator request, TBuilder argumentsBuilder);
}
