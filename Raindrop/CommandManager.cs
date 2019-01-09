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

        /// <summary>
        /// Registers a command
        /// </summary>
        /// <param name="cmd">Command</param>
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

        /// <summary>
        /// Registers a command
        /// </summary>
        /// <param name="name">The command name (what will be called in the Terminal)</param>
        /// <param name="info">An short command description</param>
        /// <param name="needsparam">If the command needs parameters</param>
        /// <param name="r">The action that will be executed when the command is called</param>
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

        /// <summary>
        /// Gets the command from the list
        /// </summary>
        /// <param name="c">Command name</param>
        /// <returns></returns>
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

        /// <summary>
        /// Executes a command
        /// </summary>
        /// <param name="c">Command name</param>
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

        /// <summary>
        /// Parses the given line as a command
        /// </summary>
        /// <param name="c">Input</param>
        /// <returns>A list of whatever was typed</returns>
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
