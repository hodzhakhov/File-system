namespace FS.CommandArguments.Builders.ConnectArgumentsBuilders;

public interface IConnectArgumentsBuilder
{
    void AddAddress(string address);
    void AddMode(string mode);
    bool RequiredFields();
}
