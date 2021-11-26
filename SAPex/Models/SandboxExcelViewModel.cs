using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class SandboxExcelViewModel
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string CreateDate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string StartRegistration { get; set; }

        public string EndRegistration { get; set; }

        public string StackTechnologies { get; set; }

        public string Languages { get; set; }

        public string Mentors { get; set; }

        public string Recruiters { get; set; }

        public string Interviewers { get; set; }
    }
}
