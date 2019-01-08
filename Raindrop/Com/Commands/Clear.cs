using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com.Commands
{
    public static class Clear
    {
        public static string Name = "clear";
        public static string Info = "Clears the terminal";
        public static bool NeedsParam = false;

        public static void Run()
        {
            Console.ResetColor();
            Console.Clear();
        }
    }
}
