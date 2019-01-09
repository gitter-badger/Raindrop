using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com
{
    public class Command
    {
        /// <summary>
        /// Action that the command will execute
        /// </summary>
        public Action Run;
        /// <summary>
        /// Name of the command (what it will be called in the Terminal)
        /// </summary>
        public string Name;
        /// <summary>
        /// A short description
        /// </summary>
        public string Info;
        /// <summary>
        /// If it needs parameters
        /// </summary>
        public bool NeedsParam;

        public Command(string _Name, string _Info, bool _NeedsParam, Action act)
        {
            Name = _Name;
            Info = _Info;
            NeedsParam = _NeedsParam;
            Run = act;
        }
    }
}
