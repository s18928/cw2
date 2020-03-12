using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    class StudiesComparer : IEqualityComparer<Studies>
    {
        public bool Equals(Studies x, Studies y)
        {
            return StringComparer
                 .InvariantCultureIgnoreCase
                 .Equals($"{x.Name} {x.Mode}",
                         $"{y.Name} {y.Mode}");
        }

        public int GetHashCode(Studies obj)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .GetHashCode($"{obj.Name} {obj.Mode}");
        }
    }
}
