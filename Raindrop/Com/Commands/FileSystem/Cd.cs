using System;
using System.IO;

namespace Raindrop.Com.FileSystem
{
    public class Cd
    {
        public static string Name = "cd";
        public static string Info = "Switches the selected folder";
        public static bool NeedsParam = true;

        public static void Run(string cd, short startIndex = 0, short count = 3)
        {
            string dir = cd;
            if (cd.StartsWith("0:\\"))
            {
                dir = cd.Remove(startIndex, count);
            }

            try
            {
                if (dir == "..")
                {
                    Directory.SetCurrentDirectory(Kernel.currentDirectory);
                    var root = Kernel.vFS.GetDirectory(Kernel.currentDirectory);
                    if (Kernel.currentDirectory == Kernel.currentVolume)
                    {
                    }
                    else
                    {
                        Kernel.currentDirectory = root.mParent.mFullPath;
                    }
                }
                else if (dir == Kernel.currentVolume)
                {
                    Kernel.currentDirectory = Kernel.currentVolume;
                }
                else
                {
                    if (Directory.Exists(Kernel.currentDirectory + dir))
                    {
                        Directory.SetCurrentDirectory(Kernel.currentDirectory);
                        Kernel.currentDirectory = Kernel.currentDirectory + dir + @"\";
                    }
                    else if (File.Exists(Kernel.currentDirectory + dir))
                    {
                        Console.WriteLine("Error: This is a file.");
                    }
                    else
                    {
                        Console.WriteLine("This directory doesn't exist.");
                    }
                }
            }
            catch { }
        }
    }
}
