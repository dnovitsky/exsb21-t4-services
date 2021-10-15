using System;
using System.Data.Entity;

namespace TestEFMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UniversityContext Db = new UniversityContext())
            {
                Student Stud1 = new Student { Name = "Maksim", Surname = "Pyatigorets" };

                Db.StudentsSet.Add(Stud1);
                Db.SaveChanges();
                Console.WriteLine("Student1 pushed");

                var AllStudents = Db.StudentsSet;

                foreach(Student St in AllStudents)
                {
                    Console.WriteLine("{0}.{1}- {2}", St.Id, St.Name, St.Surname);
                }
            }
            Console.Read();
        }
    }
}
