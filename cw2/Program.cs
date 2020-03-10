using System;
using System.Collections.Generic;
using System.IO;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {

            var pathOut = @"C:\Users\s18928\Desktop\cw2\log.txt";


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
                        var path = @"C:\Users\s18928\Desktop\dane.csv";

                        var lines = File.ReadLines(path);

                        var hash = new HashSet<Student>(new OwnComparer());

                        foreach (var line in lines)
                        {
                            var data = line.Split(",");
                            Console.WriteLine(line);

                            //if (data.Length != 9)
                            //    Console.WriteLine(line);
                            //else
                            //{

                            //    hash.Add(new Student(line[1], line[2], line[3], line[4], line[5], line[6], line[7], line[8], line[9]));
                            //}

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
