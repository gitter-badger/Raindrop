using Raindrop.Com;
using Raindrop.Com.Commands;
using Raindrop.Com.Commands.Power;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raindrop
{
    public class CommandManager
    {
        public Dictionary<string, Command> Commands = new Dictionary<string, Command>();

        List<string> y = new List<string>();
        string comd;

        public CommandManager()
        {
            Console.WriteLine("Registering commands...");

            #region Command registering
            Register(new Command(Echo.Name, Echo.Info, Echo.NeedsParam,
                () => Echo.Run(y.ToArray())));

            Register(new Command(Shutdown.Name, Shutdown.Info, Shutdown.NeedsParam,
                () => Shutdown.Run()));

            Register(new Command(ShowCommands.Name, ShowCommands.Info, ShowCommands.NeedsParam,
                () => ShowCommands.Run()));

            Register(new Command(Reboot.Name, Reboot.Info, Reboot.NeedsParam,
                () => Reboot.Run()));

            Register(new Command(Clear.Name, Clear.Info, Clear.NeedsParam,
                () => Clear.Run()));
            #endregion

            CustomConsole.WriteLineOK("Command Manager initialized");
        }

        public void Register(Command cmd)
        {
            if (Commands.TryAdd(cmd.Name, cmd))
                CustomConsole.WriteLineOK($"Registered '{cmd.Name}'");
            else
                CustomConsole.WriteLineError($"Could not register '{cmd.Name}'");
        }

        public void Execute(string c)
        {
            y.Clear();
            //var z = Regex.Matches(c, "(\"[^\"]+\" |[^\\s\"]+)");        Regex not plugged in CosmosOS :(
            var z = Parse(c);
            for (var i = 0; i < z.Count; i++)
            {
                if (i == 0) comd = z[i].ToLowerInvariant();
                else y.Add(z[i]);
            }


            if (Commands.ContainsKey(comd))
            {
                CustomConsole.WriteLineError($"'{comd}' doesn't exist or isn't registered.");
                return;
            }

            try
            {
                if (Commands[comd].NeedsParam && y.Count == 0)
                {
                    CustomConsole.WriteLineError("This command needs parameters");
                }
                else
                {
                    Commands[comd].Run.Invoke();
                }
            }
            catch (Exception ex)
            {
                Crash.StopKernel(ex);
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
