using Raindrop.Com;
using Raindrop.Com.Commands;
using Raindrop.Com.Commands.Power;
using Raindrop.Com.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raindrop
{
    public class CommandManager
    {
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
            Register(Cd.Name, Cd.Info, Cd.NeedsParam, () => Cd.Run(y.ToArray()[0]));
            Register(Ls.Name, Ls.Info, Ls.NeedsParam, () => Ls.Run());
            Register(Cat.Name, Cat.Info, Cat.NeedsParam, () => Cat.Run(y.ToArray()[0]));
            Register(Edit.Name, Edit.Info, Edit.NeedsParam, () => Edit.Run(y.ToArray()[0]));
            Register(Lspci.Name, Lspci.Info, Lspci.NeedsParam, () => Lspci.Run());
            Register(CTime.Name, CTime.Info, CTime.NeedsParam, () => CTime.Run());
            Register(MD5.Name, MD5.Info, MD5.NeedsParam, () => MD5.Run(y.ToArray()[0]));
            Register(SHA256.Name, SHA256.Info, SHA256.NeedsParam, () => SHA256.Run(y.ToArray()[0]));
            Register(Snake.Name, Snake.Info, Snake.NeedsParam, () => Snake.Run());
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
                //CustomConsole.WriteLineOK($"Registered '{cmd.Name}'");
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
                //CustomConsole.WriteLineOK($"Registered '{name}'");
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
            Command m = null;

            foreach (var x in Commands)
            {
                if (x.Name == c)
                {
                    m = x;
                }
            }

            if (m == null)
                CustomConsole.WriteLineError($"'{comd}' doesn't exist or isn't registered.");

            return m;

        }

        /// <summary>
        /// Executes a command
        /// </summary>
        /// <param name="c">Command name</param>
        public bool Execute(string c)
        {
            comd = "";
            y.Clear();
            //var z = Regex.Matches(c, "(\"[^\"]+\" |[^\\s\"]+)");        Regex not plugged in CosmosOS :(
            var z = Parse(c);
            for (var i = 0; i < z.Count; i++)
            {
                if (i == 0) comd = z[i].ToLowerInvariant();
                else y.Add(z[i]);
            }

            if (comd == "")
            {
                return false;
            }

            var cmd = GetCommand(comd);

            if (cmd != null)
            {
                try
                {
                    if (cmd.NeedsParam && y.Count == 0)
                    {
                        CustomConsole.WriteLineError("This command needs parameters");
                        comd = "";
                        return true;
                    }
                    else
                    {
                        cmd.Run.Invoke();
                        comd = "";
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Crash.StopKernel(ex);
                    return true;
                }
            }

            comd = "";
            return true;
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
