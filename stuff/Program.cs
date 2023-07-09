using System;
using System.IO;
// welcomme to the pythonic os shell rewrite in c#

// this is charlie and i am learning c# so i can make the OpenStudio Corp vr game OpenNoteBlockStudioVR 


class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();

            var command = input.Split(' ')[0].ToLower();

            switch (command)
            {
                case "cd":
                    ChangeDirectory(input);
                    break;

                case "ls":
                    ListDirectory(input);
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }


    static void Welcome()
    { Console.WriteLine("welcome to the c# version of the PythonicOS shell!")}

    static void ChangeDirectory(string input)
    {
        var arguments = input.Split(' ')[1];

        try
        {
            Directory.SetCurrentDirectory(arguments);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error changing directory: {e.Message}");
        }
    }

    static void ListDirectory(string input)
    {
        var arguments = input.Split(' ').Length > 1 ? input.Split(' ')[1] : string.Empty;
        var directory = string.IsNullOrEmpty(arguments) ? Directory.GetCurrentDirectory() : arguments;

        try
        {
            var files = Directory.GetFiles(directory);
            var directories = Directory.GetDirectories(directory);

            Console.WriteLine("Files:");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("Directories:");
            foreach (var dir in directories)
            {
                Console.WriteLine(dir);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error listing directory: {e.Message}");
        }
    }
}
