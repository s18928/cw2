using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace cw2
{
    [Serializable]
    public class Student
    {

        string firstName, lastName, email, mothersName, fathersName, index;
        DateTime birthDate;
        Studies studies;

        [XmlAttribute(AttributeName = "Index")]
        public string Index { get => index; set => index = value; }

        [XmlElement(ElementName = "Name")]
        public string Name { get => firstName; set => firstName = value; }

        
        [JsonPropertyName("LastName")]
        public string LastName { get => lastName; set => lastName = value; }

        public string Email { get => email; set => email = value; }

        public string MothersName { get => mothersName; set => mothersName = value; }

        public string FathersName { get => fathersName; set => fathersName = value; }

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public Studies Studies { get => studies; set => studies = value; }


        

        public override string ToString()
        {
            return $"{firstName}{" "}{ lastName}{" "}{ studies}{" "}{ Index}{" "}{ birthDate}{" "}{ email}{" "}{ mothersName} {" "}{ fathersName}";
        }

    }

}
