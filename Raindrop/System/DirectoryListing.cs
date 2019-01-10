using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Raindrop.System
{
    class DirectoryListing
    {
        /// <summary>
        /// Display directories of "directory"
        /// </summary>
        /// <param name="directory">Directory to show directories from</param>
        public static void DispDirectories(string directory)
        {
            foreach (string dir in Directory.GetDirectories(directory))
            {
                if (!dir.StartsWith("."))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(dir + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        /// <summary>
        /// Display hidden and normal directories of "directory"
        /// </summary>
        /// <param name="directory">Directory to show hidden and normal directories from</param>
        public static void DispHiddenDirectories(string directory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Display files of "directory"
        /// </summary>
        /// <param name="directory">Directory to show files from</param>
        public static void DispFiles(string directory)
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                Char formatDot = '.';
                string[] ext = file.Split(formatDot);
                string lastExt = ext[ext.Length - 1];

                // Display files that doesn't have a '.' before the name
                if (!file.StartsWith("."))
                {
                    if (lastExt == "conf")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(file + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (file.StartsWith("passwd"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(file + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (lastExt == "rd")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(file + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(file + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }

        /// <summary>
        /// Display hidden and normal files of "directory"
        /// </summary>
        /// <param name="directory">Directory to show hidden and normal files from</param>
        public static void DispHiddenFiles(string directory)
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                Char formatDot = '.';
                string[] ext = file.Split(formatDot);
                string lastExt = ext[ext.Length - 1];

                if (lastExt == "conf")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(file + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (file.StartsWith("passwd"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(file + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (file.StartsWith("."))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(file + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (lastExt == "rd")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(file + "\t");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(file + "\t");
                }
            }
        }
    }
}
