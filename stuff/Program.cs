﻿using System;
using System.IO;
// welcomme to the pythonic os shell rewrite in c#

// this is charlie and i am learning c# so i can make the OpenStudio Corp vr game OpenNoteBlockStudioVR 


class Program
{
    
    static void Main()
    
    {
        Welcome();
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

                case "help":
                    help();
                    break;

                case "ls":
                    ListDirectory(input);
                    break;
                case "what":
                    what();
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
    { Console.WriteLine($"welcome to the OpenStudioIDE");
        Console.WriteLine("to get started just type help and then press enter!");
    
    }
    static void what()
    {
        Console.WriteLine("you might be wondering why an OpenSourceIDE has a custom shell?\n");
        Console.WriteLine("we wanted to make it feel close to the IDE's your fimalar with\n");
        Console.WriteLine("like visual studio\n");
        Console.WriteLine("or jetbrains rider\n");
        Console.WriteLine("this shell was passed down between projects\n");
        Console.WriteLine("it started as the PythonicOS Shell, then became the launcher shell then here we are at the IDE\n");
        Console.WriteLine("hopefully we dont have to move it again!\n");
     
    }
    static void help()
    {
        Console.WriteLine("cd: changes directory");
        Console.WriteLine("ls: list files in directory");
        //Console.WriteLine("exit: exits the shell!");
        //Console.WriteLine("what: it puts things on the screen?");
        //Console.WriteLine("cd: changes directory");
        //Console.WriteLine("cd: changes directory");
        //Console.WriteLine("cd: changes directory");

    }

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
