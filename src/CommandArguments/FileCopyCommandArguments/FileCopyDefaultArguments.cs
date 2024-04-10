using FS.Paths;

namespace FS.CommandArguments.FileCopyCommandArguments;

public record FileCopyDefaultArguments(FileSystemPath SourcePath, FileSystemPath DestinationPath) : FileCopyArguments;
