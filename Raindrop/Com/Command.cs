using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com
{
    public class Command
    {
        public Action Run;
        public string Name;
        public string Info;
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
