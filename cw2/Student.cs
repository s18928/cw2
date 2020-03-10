using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2
{
    [Serializable]
    public class Student
    {

        string firstName, lastName, email, mothersName, fathersName;
        DateTime birthDate;

        Student(string firstName, string lastName, DateTime birthDate, string email, string mothersName, string fathersName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.email = email;
            this.mothersName = mothersName;
            this.fathersName = fathersName;
        }



        [XmlElement(ElementName = "InneNazwa")]
        public string Imie { get; set; }

        [XmlAttribute(AttributeName = "InnaNazwa")]
        //[JsonPropertyName("LastName")]
        public string Nazwisko { get; set; }

    }

}
