using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Interpreter.AST
{
    public class LogicStmt : Iast
    {
        public string Left { get; set; }
        public string Opcode { get; set; }
        public string Right { get; set; }

        public int ID { get; set; }
    }
}
