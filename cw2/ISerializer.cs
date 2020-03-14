using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cw2
{
    interface ISerializer<T>
    {
        void Serialize(T obj, Stream stream);
    }
}
