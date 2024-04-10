using FS.RequestIterators;
using FS.Results;

namespace FS.CommandChainLink.Entities;

public interface ICommandChainLink
{
    void AddNext(ICommandChainLink link);

    HandleResult? Handle(RequestIterator request);
}
