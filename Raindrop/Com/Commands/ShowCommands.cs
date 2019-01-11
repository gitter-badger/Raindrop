using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com.Commands
{
    public class ShowCommands
    {
        public static string Name = "shwcmd";
        public static string Info = "Show all commands";
        public static bool NeedsParam = false;

        public static void Run()
        {
            foreach (var e in Kernel.CM.Commands)
            {
                if (e.NeedsParam)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{e.Name}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" - {e.Info}");
            }
        }
    }
}
