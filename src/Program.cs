using System;
using System.Collections.Generic;
using FS.CommandChainLink.Entities;
using FS.CommandChainLink.Models;
using FS.FileSystemContexts;
using FS.RequestIterators;
using FS.Results;

namespace FS;

public static class Program
{
    public static void Main()
    {
        ICommandChainLink connectHandler = HandlersBuilder.Build();

        IFileSystemContext fileSystem = new FileSystemContext();

        while (true)
        {
            string? input = Console.ReadLine();
            if (input is null) continue;

            if (input == "0") break;

            var request = new List<string>(input.Split(" "));
            var requestIterator = new RequestIterator(request);
            HandleResult? command = connectHandler.Handle(requestIterator);
            if (command is HandleResult.SuccessHandle successResult)
            {
                successResult.Command.Execute(fileSystem);
            }
            else if (command is HandleResult.FailedHandle failedResult)
            {
                Console.WriteLine(failedResult.Message);
            }
        }
    }
}
