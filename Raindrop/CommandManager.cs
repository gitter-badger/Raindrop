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
        //public Dictionary<string, Command> Commands = new Dictionary<string, Command>();
        public List<Command> Commands = new List<Command>();

        List<string> y = new List<string>();
        string comd;

        public CommandManager()
        {
            Console.WriteLine("Registering commands...");

            #region Command registering
            Register(Echo.Name, Echo.Info, Echo.NeedsParam, () => Echo.Run(y.ToArray()));
            Register(Shutdown.Name, Shutdown.Info, Shutdown.NeedsParam, () => Shutdown.Run());
            Register(ShowCommands.Name, ShowCommands.Info, ShowCommands.NeedsParam, () => ShowCommands.Run());
            Register(Reboot.Name, Reboot.Info, Reboot.NeedsParam, () => Reboot.Run());
            Register(Clear.Name, Clear.Info, Clear.NeedsParam, () => Clear.Run());
            #endregion

            CustomConsole.WriteLineOK("Command Manager initialized");
        }

        public void Register(Command cmd)
        {
            try
            {
                Commands.Add(cmd);
                CustomConsole.WriteLineOK($"Registered '{cmd.Name}'");
            }
            catch (Exception ex)
            {
                CustomConsole.WriteLineError($"Could not register '{cmd.Name}'. Error: {ex}");
            }
        }

        public void Register(string name, string info, bool needsparam, Action r)
        {
            try
            {
                var cmd = new Command(name, info, needsparam, r);
                Commands.Add(cmd);
                CustomConsole.WriteLineOK($"Registered '{name}'");
            }
            catch (Exception ex)
            {
                CustomConsole.WriteLineError($"Could not register '{name}'. Error: {ex}");
            }
        }

        public Command GetCommand(string c)
        {
            try
            {
                Command m = null;

                foreach (var x in Commands)
                {
                    if (x.Name == c)
                    {
                        m = x;
                    }
                }

                return m;
            }
            catch
            {
                CustomConsole.WriteLineError($"'{comd}' doesn't exist or isn't registered.");
                return null;
            }
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

            var cmd = GetCommand(comd);

            if (cmd != null)
            {
                try
                {
                    if (cmd.NeedsParam && y.Count == 0)
                    {
                        CustomConsole.WriteLineError("This command needs parameters");
                    }
                    else
                    {
                        cmd.Run.Invoke();
                    }
                }
                catch (Exception ex)
                {
                    Crash.StopKernel(ex);
                }
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
