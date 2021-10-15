using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEFMigrations
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Course { get; set; }
    }

    class University
    {
        public int Id { get; set; }

        //public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
