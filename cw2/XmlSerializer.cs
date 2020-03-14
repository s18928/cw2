using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace cw2
{
    public class XmlSerializer<T> : ISerializer<T>
    {
        public void Serialize(T obj, Stream stream)
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            AddAuthorInfo(xmlSerializerNamespaces);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            //    , new XmlRootAttribute("uczelnia"));

            serializer.Serialize(stream, obj);//, xmlSerializerNamespaces);    
        }

        private static void AddAuthorInfo(XmlSerializerNamespaces xmlSerializerNamespaces)
        {
            xmlSerializerNamespaces.Add("CreatedAt", DateTime.Today.ToShortDateString());
            xmlSerializerNamespaces.Add("Author", "Katarzyna Kowalczyk");
        }
    }
}
