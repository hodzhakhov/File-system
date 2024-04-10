using FS.CommandChainLink.Entities;
using FS.CommandChainLink.Models.FileChainLink;
using FS.CommandChainLink.Models.TreeChainLink;

namespace FS.CommandChainLink.Models;

public static class HandlersBuilder
{
    public static ICommandChainLink Build()
    {
        var connectHandler = new ConnectHandler();
        var disconnectHandler = new DisconnectHandler();

        var treeGotoHandler = new TreeGotoHandler();
        var treeListHandler = new TreeListHandler();
        treeGotoHandler.AddNext(treeListHandler);

        var treeHandler = new TreeHandler(treeGotoHandler);

        var fileShowHandler = new FileShowHandler();
        var fileMoveHandler = new FileMoveHandler();
        var fileCopyHandler = new FileCopyHandler();
        var fileDeleteHandler = new FileDeleteHandler();
        var fileRenameHandler = new FileRenameHandler();
        fileShowHandler.AddNext(fileMoveHandler);
        fileShowHandler.AddNext(fileCopyHandler);
        fileShowHandler.AddNext(fileDeleteHandler);
        fileShowHandler.AddNext(fileRenameHandler);

        var fileHandler = new FileHandler(fileShowHandler);

        connectHandler.AddNext(disconnectHandler);
        connectHandler.AddNext(treeHandler);
        connectHandler.AddNext(fileHandler);

        return connectHandler;
    }
}
