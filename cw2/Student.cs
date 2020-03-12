using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2
{
    [Serializable]
    public class Student
    {

        string firstName, lastName, email, mothersName, fathersName, index;
        DateTime birthDate;
        Studies studies;

        public Student(string firstName, string lastName, Studies studies, string index, DateTime birthDate, string email, string mothersName, string fathersName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.email = email;
            this.mothersName = mothersName;
            this.fathersName = fathersName;
            this.index = index;
            this.studies = studies;
        }



        [XmlElement(ElementName = "InneNazwa")]
        public string Imie { get; set; }

        [XmlAttribute(AttributeName = "InnaNazwa")]
        //[JsonPropertyName("LastName")]
        public string Nazwisko { get; set; }


        public string Index { get; set; }

        public override string ToString()
        {
            return $"{firstName}{" "}{ lastName}{" "}{ studies}{" "}{ index}{" "}{ birthDate}{" "}{ email}{" "}{ mothersName} {" "}{ fathersName}";
        }

    }

}
