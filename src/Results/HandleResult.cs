using FS.Commands.Entities;

namespace FS.Results;

public abstract record HandleResult
{
    public sealed record SuccessHandle(ICommand Command) : HandleResult;

    public sealed record FailedHandle(string Message) : HandleResult;
}
