using FS.Paths;

namespace FS.CommandArguments.FileRenameCommandArguments;

public record FileRenameDefaultArguments(FileSystemPath Path, string Name) : FileRenameArguments;
