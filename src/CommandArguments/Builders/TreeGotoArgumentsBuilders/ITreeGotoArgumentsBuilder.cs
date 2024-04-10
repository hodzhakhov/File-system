namespace FS.CommandArguments.Builders.TreeGotoArgumentsBuilders;

public interface ITreeGotoArgumentsBuilder
{
    void AddPath(string path);
    bool RequiredFields();
}
