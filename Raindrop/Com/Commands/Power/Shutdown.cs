using System;
using Sys = Cosmos.System;

namespace Raindrop.Com.Commands.Power
{
    public static class Shutdown
    {
        public static string Name = "shutdown";
        public static string Info = "Shuts down the system";
        public static bool NeedsParam = false;

        public static void Run()
        {
            Kernel.running = false;
            Console.Clear();
            Console.WriteLine("Raindrop OS is shutting down...");
            Sys.Power.Shutdown();
        }
    }
}
