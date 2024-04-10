namespace FS.CommandArguments.Builders.FileRenameArgumentsBuilders;

public interface IFileRenameArgumentsBuilder
{
    void AddPath(string path);
    void AddName(string name);
    bool RequiredFields();
}
