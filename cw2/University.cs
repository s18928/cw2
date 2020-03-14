using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace cw2
{
    
    [Serializable]
    [Newtonsoft.Json.JsonObject(Title = "University")]
    public class University
    {

        string author = "Katarzyna Kowalczyk";
        string createdAt = DateTime.Today.ToShortDateString();
        HashSet<Student> studenci;
        string name = "University";


        [XmlAttribute(AttributeName = "createdAt")]
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get => createdAt; set => createdAt = value; }

        [XmlAttribute(AttributeName = "author")]
        [JsonPropertyName("author")]
        public string Author { get => author; set => author = value; }

        [XmlElement(ElementName = "students")]
        public HashSet<Student> Students { get => studenci; set => studenci = value; }

    }
}
