using System;
using FS.CommandArguments.ConnectCommandArguments;
using FS.Modes;
using FS.Paths;

namespace FS.CommandArguments.Builders.ConnectArgumentsBuilders;

public class ConnectArgumentsBuilder : IConnectArgumentsBuilder
{
    private FileSystemPath? _address;
    private Mode? _mode;

    public void AddAddress(string address)
    {
        _address = new FileSystemPath(address);
    }

    public void AddMode(string mode)
    {
        _mode = new Mode(mode);
    }

    public bool RequiredFields()
    {
        return _address is not null && _mode is not null;
    }

    public ConnectDefaultArguments Build()
    {
        return new ConnectDefaultArguments(
            _address ?? throw new ArgumentNullException(nameof(_address)),
            _mode ?? throw new ArgumentNullException(nameof(_mode)));
    }
}
