using System.Collections.Generic;

namespace Raindrop.Interpreter
{
    public class Method
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; }
        public List<string> Perms { get; set; } = new List<string>();
    }
}
