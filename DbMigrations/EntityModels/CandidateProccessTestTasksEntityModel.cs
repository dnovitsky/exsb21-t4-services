using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateProccessTestTasksEntityModel
    {
        public CandidateProccessTestTasksEntityModel(Guid candidateProcessId, Guid testFileId, DateTime endTestDate)
        {
            CandidateProcessId = candidateProcessId;
            TestFileId = testFileId;
            SendTestDate = DateTime.Now;
            EndTestDate = endTestDate;
        }
        
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CandidateProcessId { get; set; }
        public virtual CandidateProccesEntityModel СandidateProcess { get; set; }

        [Required]
        public Guid TestFileId { get; set; }
        public virtual FileEntityModel TestFile { get; set; }

        [Required]
        public  Nullable<Guid> CandidateRequestTestFileId { get; set; }
        public virtual FileEntityModel CandidateRequestTestFile { get; set; }

        public DateTime SendTestDate { get; set; }

        public DateTime EndTestDate { get; set; }

        public string LinkDownloadToken { get; set; }
    }
}
