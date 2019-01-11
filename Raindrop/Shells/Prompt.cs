using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Shells
{
    public class Prompt : Shell
    {
        public string command;

        public override void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("$");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("krasno");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("rd-pc");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Kernel.currentDirectory.Remove(0, 2));
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var z = true;

            while (z)
            {
                command = Console.ReadLine();

                var e = Kernel.CM.Execute(command);

                z = !e;
            }
        }
    }
}
