using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Interpreter.AST
{
    public class MethodStmt : Iast
    {
        public int ID { get; set; }
        public int Perams { get; set; }
        public string RawID { get; set; }
    }
}
