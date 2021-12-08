using System;

namespace SAPex.Models
{
    public class CandidateProcessTestTasksViewModel
    {
        public Guid TestFileId { get; set; }

        public Guid? ResponseTestFileId { get; set; } = null;
    }
}
