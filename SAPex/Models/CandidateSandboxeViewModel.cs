using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class CandidateSandboxeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // ProjectRoles
        public List<dynamic> ProjectRoles { get; set; }

        // TeamId
        public dynamic Team { get; set; }

        public string Status { get; set; }

        public string TestResult { get; set; }

        // FeedbackList
        public List<dynamic> Feedbacks { get; set; }
    }
}
