using FS.Paths;

namespace FS.CommandArguments.FileMoveCommandArguments;

public record FileMoveDefaultArguments(FileSystemPath SourcePath, FileSystemPath DestinationPath) : FileMoveArguments;
