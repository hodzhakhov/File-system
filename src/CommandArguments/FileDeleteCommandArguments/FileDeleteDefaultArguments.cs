using FS.Paths;

namespace FS.CommandArguments.FileDeleteCommandArguments;

public record FileDeleteDefaultArguments(FileSystemPath Path) : FileDeleteArguments;
