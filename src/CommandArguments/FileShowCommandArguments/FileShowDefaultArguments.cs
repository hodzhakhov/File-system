using FS.Modes;
using FS.Paths;

namespace FS.CommandArguments.FileShowCommandArguments;

public record FileShowDefaultArguments(FileSystemPath Path, Mode Mode) : FileShowArguments;
