using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateProcessTestTaskDtoModel
    {
        public CandidateProcessTestTaskDtoModel() { }

        public CandidateProcessTestTaskDtoModel(Guid candidateProcessId, Guid testFileId, DateTime endTestDate, string token = "")
        {
            CandidateProcessId = candidateProcessId;
            TestFileId = testFileId;
            EndTestDate = endTestDate;
            Token = token;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CandidateProcessId { get; set; }

        public Guid TestFileId { get; set; }

        public Nullable<Guid> CandidateResponseTestFileId { get; set; } = null;

        public DateTime SendTestDate { get; set; } = DateTime.Now;

        public DateTime EndTestDate { get; set; }

        public string Token { get; set; } = "";
    }
}
