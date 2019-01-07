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

        protected override void BeforeRun()
        {
            Console.WriteLine("Raindrop OS created by Krasno.");
            Engine en = new Engine();
            Process Bootstrap = new Process();
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
