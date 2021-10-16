using System;
using System.Collections.Generic;
using TestEFMig1.Models;

namespace TestEFMig1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppContextDb db = new AppContextDb())
            {
                Student Stud1 = new Student { Name = "Maksim", Surname = "Pyatigorets",Course = "4", City = "Minsk" };
                Student Stud2 = new Student { Name = "Lev", Surname = "Sinaev", Course = "4", City = "Minsk" };

                University Univ1 = new University { Name = "BSU" };

                db.Students.Add(Stud1);
                db.Students.Add(Stud2);

                db.Universities.Add(Univ1);

                db.SaveChanges();
                Console.WriteLine("Data pushed");
            }

            Console.Read();
        }
    }
}
