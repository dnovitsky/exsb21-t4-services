using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CMContext db = new CMContext())
            {
                // создание и добавление моделей
                //Department d1 = new Department { Name = "HR" };
                //Department d2 = new Department { Name = "Support" };
                //db.Departments.Add(d1);
                //db.Departments.Add(d2);
                //db.SaveChanges();
                //Employee e1 = new Employee { Name = "Vadim", Age = 20, Position = "Junior support engineer", Department = d2 };
                //Employee e2 = new Employee { Name = "Tolya", Age = 45, Position = "Senior support engineer", Department = d2 };
                //Employee e3 = new Employee { Name = "Semen", Age = 53, Position = "Senior HR manager", Department = d1 };
                //Employee e4 = new Employee { Name = "Olga", Age = 50, Position = "Middle support engineer", Department = d2 };
                //Employee e5 = new Employee { Name = "Misha", Age = 44, Position = "Middle support engineer", Department = d2 };
                //Employee e6 = new Employee { Name = "Max", Age = 23, Position = "Middle HR manager", Department = d1 };
                //db.Employees.AddRange(new List<Employee> { e1, e2, e3, e4, e5, e6 });
                //db.SaveChanges();

                // вывод 
                foreach (Employee e in db.Employees.Include(e => e.Department))
                    Console.WriteLine("{0} - {1}", e.Name, e.Department != null ? e.Department.Name : "");
                Console.WriteLine();
                foreach (Department d in db.Departments.Include(d => d.Employees))
                {
                    Console.WriteLine("Отдел: {0}", d.Name);
                    foreach (Employee e in d.Employees)
                    {
                        Console.WriteLine("{0} - {1}", e.Name, e.Position);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
