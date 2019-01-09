using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Shells
{
    public abstract class Shell
    {
        /// <summary>
        /// Method that is called every CPU cycle
        /// </summary>
        public abstract void Run();
    }
}
