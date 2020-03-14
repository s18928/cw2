using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    public class Studies
    {
        string name, mode;

       

        public override string ToString()
        {
            return $"{name}{" "}{mode}";
        }

        public string Name { get => name; set => name = value; }
        public string Mode { get => mode; set => mode = value; }
    }
}
