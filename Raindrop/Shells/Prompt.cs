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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            command = Console.ReadLine();

            Kernel.CM.Execute(command);
        }
    }
}
