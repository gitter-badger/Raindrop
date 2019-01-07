using Raindrop.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Raindrop
{
    public class Kernel : Sys.Kernel
    {
        public static List<KThread> Pool      = new List<KThread>();
        public static List<Process> Processes = new List<Process>();

        public static KThread currentThread;

        protected override void BeforeRun()
        {
            Console.WriteLine("Raindrop OS created by Krasno.");
            Engine en = new Engine();
            Process Bootstrap = new Process("");
        }

        protected override void Run()
        {
            // Step through every thread
            for (var i = 0; i < Pool.Count; i++)
            {
                currentThread = Pool[i];
                Pool[i].Step();
            }
        }
    }
}
