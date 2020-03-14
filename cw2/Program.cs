using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
using System.Text;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var path = "";
            var pathDes = "";
            string format = "";

            if (args.Length == 3)
            {
                path = args[0];
                pathDes = args[1];
                format = args[2];
            }
            else
            {
                path = @"C:\Users\kasia\OneDrive\Pulpit\studia\IIrok\II_SEM\APBD\cw2\dane.csv";
                pathDes = @"C:\Users\kasia\OneDrive\Pulpit\studia\IIrok\II_SEM\APBD\cw2\data.xml";
                format = "xml";
            }

            var pathOut = @"C:\Users\kasia\OneDrive\Pulpit\studia\IIrok\II_SEM\APBD\cw2\log.txt";


            if (File.Exists(pathOut))
            {
                File.Delete(pathOut);
            }

            using (FileStream fs = new FileStream(pathOut, FileMode.CreateNew))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {

                    try
                    {
                   
                        FileStream fileStream = new FileStream(pathDes, FileMode.Create);


                        var lines = File.ReadLines(path);

                        var hash = new HashSet<Student>(new OwnComparer());

                        var hashStudies = new HashSet<Studies>(new StudiesComparer());

                        foreach (var line in lines)
                        {
                            var data = line.Split(",");

                            Regex regex = new Regex("(,,)+");

                            if (data.Length != 9 || regex.IsMatch(line) || line.Length <= 8)
                            {
                                w.Write(line + '\n');
                            }
                            else
                            {
                                var studies = new Studies{
                                    Name = data[2], 
                                    Mode = data[3] 
                                };
                                hashStudies.Add(studies);

                                var student = new Student{
                                    Name = data[0], 
                                    LastName = data[1], 
                                    Studies = studies, 
                                    Index = data[4], 
                                    BirthDate = DateTime.Parse(data[5]), 
                                    Email = data[6], 
                                    MothersName = data[7], 
                                    FathersName = data[8]

                                };


                                if (!hash.Add(student))
                                    w.Write(line + '\n');

                            }

                        }

                        var university = new University
                        {
                            Students = hash
                        };

                        if (format == "xml")
                        {
                            SerializeData(university, new XmlSerializer<University>(), fileStream);
                            
                            
                        }
                        else if (format == "json")
                        {
                            SerializeData(university, new JsonSerializer<University>(), fileStream);
                        }
 

                    }
                    catch (IOException e)
                    {
                        w.Write(e.Message);
                    }

                }

            }
        }


        static void SerializeData(University hash, ISerializer<University> serializer, Stream output)
        {
            serializer.Serialize(hash, output);
        }
    }
}
