using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskMover
{
    class Program
    {
        public static string RootFolderPath = @"C:\Users\janis\Downloads";

        static void Main(string[] args)
        {
            while (true)
            {
                string[] fileList = Directory.GetFiles(RootFolderPath);
                if (fileList.Length > 0)
                {
                    Console.WriteLine("Job started");
                    List<string> extensionList = new List<string>();
                    List<Thread> threadList = new List<Thread>();
                    foreach (var file in fileList)
                    {
                        var startofExt = file.LastIndexOf('.');
                        var ext = file.Substring(startofExt + 1);
                        if (!extensionList.Contains(ext))
                        {
                            extensionList.Add(ext);
                        }
                    }
                    Task.Run(async () =>
                    {
                        foreach (var extension in extensionList)
                        {
                            await MoveFiles(extension, fileList);
                        }
                    });
                    

                    foreach (var thred in threadList)
                    {
                        thred.Join();
                    }
                    Console.WriteLine("Job Complete");
                }
                Thread.Sleep(5000);
            }
        }

        public static async Task MoveFiles(string extension, string[] fileList)
        {
            var destinationPath = RootFolderPath + "\\" + extension;
            List<string> filesToBeMoved = fileList.Where(s => s.EndsWith(extension)).ToList();
            foreach (var file in filesToBeMoved)
            {
                string filename = GetFilename(file);
                if (!Directory.Exists(destinationPath))
                    Directory.CreateDirectory(destinationPath);
                using (Stream source = File.Open(file, FileMode.Open))
                {
                    using (Stream destination = File.Create(destinationPath))
                    {
                        await source.CopyToAsync(destination);
                    }
                }
            }
            Console.WriteLine(extension + " folder complete");
        }

        private static string GetFilename(string file)
        {
            return file.Substring(file.LastIndexOf("\\", StringComparison.Ordinal) + 1);
        }
    }
}
