using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeadName { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public Department()
        {
            Employees = new List<Employee>();
        }
    }
}
