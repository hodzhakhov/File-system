namespace FS.CommandArguments.Builders.FileShowArgumentsBuilders;

public interface IFileShowArgumentsBuilder
{
    void AddPath(string path);
    void AddMode(string mode);
    bool RequiredFields();
}
