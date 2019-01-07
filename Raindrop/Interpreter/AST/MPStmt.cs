using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Interpreter.AST
{
    public class MPStmt : Iast
    {
        public int ParameterID, MethodID;
        public string Value;
    }
}
