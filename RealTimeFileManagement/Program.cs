using System;
using System.IO;

namespace DirectoryWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the directory to watch:");
            string directory = Console.ReadLine();

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = directory;

            watcher.Filter = "*.*";

            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine();
            Console.WriteLine("Started monitoring on " + directory);
            Console.WriteLine();
            Console.WriteLine("Don't press any key to watch monitoring");
            Console.ReadKey();

            watcher.EnableRaisingEvents = false;
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"File {Path.GetFileName(e.FullPath)} was created.");
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"File {Path.GetFileName(e.FullPath)} was deleted.");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"File {Path.GetFileName(e.OldFullPath)} was renamed to {Path.GetFileName(e.FullPath)}.");
        }
    }
}