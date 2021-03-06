using System;
using System.IO;
using System.Collections.Concurrent;

public class Program
{
    public static void Main(string[] Args)
    {
        if (Args.Length < 1)
        {
            Console.Error.WriteLine("Specify one dir on argument.");
            Environment.Exit(1);
        }

        string targetPath = Args[0];

        var fsw = new FileSystemWatcher(targetPath);
        fsw.IncludeSubdirectories = true;

        fsw.Created += EventHandler;
        fsw.Deleted += EventHandler;
        fsw.Changed += EventHandler;
        fsw.Renamed += (sender, args) =>
        {
            Console.WriteLine("\"{0}\", Renamed to \"{1}\"", args.OldName, args.Name);
        };

        fsw.Error += (s, args) =>
        {
            Console.Error.WriteLine("Error: {0}", args.ToString());
            Environment.Exit(1);
        };

        fsw.EnableRaisingEvents = true;
        Console.WriteLine("press enter to exit...");
        Console.ReadLine();
    }

    static void EventHandler(object sender, FileSystemEventArgs args)
    {
        Console.WriteLine("\"{0}\" {1}", args.Name, args.ChangeType);
    }
}

