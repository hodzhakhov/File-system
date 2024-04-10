using FS.RequestIterators;

namespace FS.ArgumentChainLink.Entities;

public interface IArgumentChainLink<TBuilder>
{
    void AddNext(IArgumentChainLink<TBuilder> link);

    void Handle(RequestIterator request, TBuilder argumentsBuilder);
}
