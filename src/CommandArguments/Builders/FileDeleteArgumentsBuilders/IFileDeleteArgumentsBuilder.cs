namespace FS.CommandArguments.Builders.FileDeleteArgumentsBuilders;

public interface IFileDeleteArgumentsBuilder
{
    void AddPath(string path);
    bool RequiredFields();
}
