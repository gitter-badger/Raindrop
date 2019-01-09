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
            Console.WriteLine(Yes());
        }

        public static string Yes()
        {
            var s = "";
            var q = Kernel.CM.Commands.Keys;

            foreach (var e in q)
            {
                s += $"{e}\n";
            }

            return s;
        }
    }
}
