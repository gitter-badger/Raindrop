using Raindrop.Shells;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Raindrop
{
    public class Kernel : Sys.Kernel
    {
        public static Shell current;
        public static CommandManager CM;
        public static bool running = true;

        public static string version = "0.0.1";
        public static string revision = "010920190552";

        protected override void BeforeRun()
        {
            try
            {
                CM = new CommandManager();
                Console.WriteLine("Raindrop OS created by Krasno.");
                //Console.Clear();
                current = new Prompt();
            }
            catch (Exception ex)
            {
                Crash.StopKernel(ex);
            }
        }

        protected override void Run()
        {
            try
            {
                current.Run();
            }
            catch (Exception ex)
            {
                Crash.StopKernel(ex);
            }
        }
    }
}
