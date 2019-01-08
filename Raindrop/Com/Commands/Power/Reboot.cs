using System;
using Sys = Cosmos.System;

namespace Raindrop.Com.Commands.Power
{
    public class Reboot
    {
        public static string Name = "reboot";
        public static string Info = "Reboots the system";
        public static bool NeedsParam = false;

        public static void Run()
        {
            Kernel.running = false;
            Console.Clear();
            Console.WriteLine("Restarting Raindrop OS...");
            Sys.Power.Reboot();
        }
    }
}
