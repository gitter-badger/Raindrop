using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com.Commands
{
    public static class Echo
    {
        public static string Name = "echo";
        public static string Info = "Echoes back what you type in. echo @s";
        public static bool NeedsParam = true;

        public static void Run(string[] c)
        {
            Console.WriteLine(c[0]);
        }
    }
}
