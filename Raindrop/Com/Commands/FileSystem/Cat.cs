using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Raindrop.Com.Commands
{
    public static class Cat
    {
        public static string Name = "cat";
        public static string Info = "Searches for a file";
        public static bool NeedsParam = true;

        public static void Run(string cat, short startIndex = 0, short count = 4)
        {
            try
            {
                string file = cat;
                if (cat.StartsWith("0:\\"))
                {
                    file = cat.Remove(startIndex, count);
                }
                if (File.Exists(Kernel.currentDirectory + file))
                {
                    foreach (string line in File.ReadAllLines(Kernel.currentDirectory + file))
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    CustomConsole.WriteLineError("This file doesn't exist");
                }
            }
            catch { }
        }
    }
}
