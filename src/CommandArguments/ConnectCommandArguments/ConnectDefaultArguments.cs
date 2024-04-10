using FS.Modes;
using FS.Paths;

namespace FS.CommandArguments.ConnectCommandArguments;

public record ConnectDefaultArguments(FileSystemPath Address, Mode Mode) : ConnectArguments;
