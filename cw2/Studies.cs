using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    public class Studies
    {
        string name, mode;

        public Studies(string name, string mode)
        {
            this.name = name;
            this.mode = mode;
        }

        public override string ToString()
        {
            return $"{name}{" "}{mode}";
        }

        public string Name { get; set; }
        public string Mode { get; set; }
    }
}
