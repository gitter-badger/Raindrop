using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Interpreter
{
    public class Library
    {
        public string Name { get; set; }
        public Lib.Dictionary<string, Delegate> Functions = new Lib.Dictionary<string, Delegate>();
    }
}
