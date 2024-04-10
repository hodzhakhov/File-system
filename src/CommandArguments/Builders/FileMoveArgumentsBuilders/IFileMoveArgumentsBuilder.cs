namespace FS.CommandArguments.Builders.FileMoveArgumentsBuilders;

public interface IFileMoveArgumentsBuilder
{
    void AddSourcePath(string sourcePath);
    void AddDestinationPath(string destinationPath);
    bool RequiredFields();
}
