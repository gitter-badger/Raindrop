using Raindrop.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com.FileSystem
{
    public class Ls
    {
        public static string Name = "ls";
        public static string Info = "Shows all the files in the current directory";
        public static bool NeedsParam = false;

        public static void Run()
        {
            DirectoryListing.DispDirectories(Kernel.currentDirectory);
            DirectoryListing.DispFiles(Kernel.currentDirectory);
            Console.WriteLine();
        }
    }
}
