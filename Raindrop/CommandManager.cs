using Raindrop.Com;
using Raindrop.Com.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Raindrop
{
    public class CommandManager
    {
        public List<string> Commands = new List<string>();

        List<string> y = new List<string>();
        string comd;

        public CommandManager()
        {
            Console.WriteLine("Registering commands...");

            #region Command registering
            Commands.Add("echo");
            #endregion

            CustomConsole.WriteLineOK("Command Manager initialized");
        }

        public void Execute(string c)
        {
            y.Clear();
            //var z = Regex.Matches(c, "(\"[^\"]+\" |[^\\s\"]+)");  Regex not plugged in CosmosOS :(
            var z = Parse(c);
            for (var i = 0; i < z.Count; i++)
            {
                if (i == 0) comd = z[i].ToLowerInvariant();
                else y.Add(z[i]);
            }
            if (Commands.Contains(comd))
                Yes();
            else
                throw new Exception($"Command '{comd}' doesn't exist or isn't registered.");
        }

        private void Yes()
        {
            switch (comd)
            {
                case "echo":
                    Echo.Run(y.ToArray());
                    break;
            }
        }

        List<string> Parse(string c)
        {
            var p = new List<string>();
            var q = c.Split('"');

            for (var i = 0; i < q.Length; i++)
            {
                var element = q[i];
                var s = i % 2 == 0
                     ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                     : new string[] { element };
                for (var f = 0; f < s.Length; f++)
                    p.Add(s[f]);
            }

            return p;
        }
    }
}
