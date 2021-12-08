using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateProcessTestTaskEntityModel
    {
        public CandidateProcessTestTaskEntityModel() { }

        public CandidateProcessTestTaskEntityModel(Guid candidateProcessId, Guid testFileId, DateTime endTestDate)
        {
            CandidateProcessId = candidateProcessId;
            TestFileId = testFileId;
            SendTestDate = DateTime.Now;
            EndTestDate = endTestDate;
        }
        
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid CandidateProcessId { get; set; }
        public virtual CandidateProcesEntityModel СandidateProcess { get; set; }

        [Required]
        public Guid TestFileId { get; set; }
        public virtual FileEntityModel TestFile { get; set; }

        public Nullable<Guid> CandidateResponseTestFileId { get; set; } = null;
        public virtual FileEntityModel CandidateResponseTestFile { get; set; }

        public DateTime SendTestDate { get; set; } = DateTime.Now;

        public DateTime EndTestDate { get; set; }

        public string Token { get; set; } = "";
    }
}
