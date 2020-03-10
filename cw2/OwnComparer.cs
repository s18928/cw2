using System;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    class OwnComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals($"{x.Imie} {x.Nazwisko}", $"");
        }

        public int GetHashCode(Student obj)
        {
           
            return StringComparer
                .InvariantCultureIgnoreCase
                .GetHashCode($"{obj.Imie} {obj.Nazwisko} ");
        }
    }

}
