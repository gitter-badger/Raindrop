using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Interpreter.AST
{
    public class SetStmt : Iast
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public string RawID { get; set; }
    }
}
