namespace FS.CommandArguments.Builders.FileCopyArgumentsBuilders;

public interface IFileCopyArgumentsBuilder
{
    void AddSourcePath(string sourcePath);
    void AddDestinationPath(string destinationPath);
    bool RequiredFields();
}
