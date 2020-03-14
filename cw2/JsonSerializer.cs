using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cw2
{
    class JsonSerializer<T> : ISerializer<T>
    {
        public void Serialize(T obj, Stream output)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (var writer = new StreamWriter(output))
            {
                using (var jsonTextWriter = new JsonTextWriter(writer))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    serializer.Serialize(jsonTextWriter, obj);
                }

            }
        }
    }
}
