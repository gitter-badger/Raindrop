using Raindrop.Apps.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com.Commands
{
    public static class Snake
    {
        public static string Name = "snake";
        public static string Info = "Starts a new game of snake";
        public static bool NeedsParam = false;

        public static void Run()
        {
            var prgm = new PrgmSnake();
            prgm.Run();
        }
    }
}
