//Pliki do odczytu i zapisu sa argumentamii programu
//hashSet zle wykonuje metode equals i nie dodaje nowych elementow

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {

            //var pathOut = @"C:\Users\s18928\Desktop\cw2\log.txt";
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
                        //var path = @"C:\Users\s18928\Desktop\dane.csv";
                        var path = @"C:\Users\kasia\OneDrive\Pulpit\studia\IIrok\II_SEM\APBD\cw2\daneTest.csv";

                        var lines = File.ReadLines(path);

                        var hash = new HashSet<Student>(new OwnComparer());
                        var hashStudies = new HashSet<Studies>(new StudiesComparer());

                        foreach (var line in lines)
                        {
                            var data = line.Split(",");

                            Regex regex = new Regex("([ ],)+");

                            if (data.Length != 9 || regex.IsMatch(line) || line.Length <= 8)
                            {
                                w.Write(line + '\n');
                            }
                            else
                            {
                                var studies = new Studies(data[2], data[3]);
                                hashStudies.Add(studies);

                                var student = new Student(data[0], data[1], studies, data[4], DateTime.Parse(data[5]), data[6], data[7], data[8]);


                                if (!hash.Add(student))
                                    w.Write(line + '\n');

                            }

                        }

                        foreach (var i in hash)
                        {
                            Console.WriteLine(i);
                        }

                    }
                    catch (IOException e)
                    {
                        w.Write(e.Message);
                    }

                }


                // var today = DateTime.Today;
                // Console.WriteLine(today.ToShortDateString());

            }
        }
    }
}
