namespace FS.Results;

public abstract record CommandResult
{
    public sealed record SuccessCommand : CommandResult;

    public sealed record FailedCommand : CommandResult;
}
