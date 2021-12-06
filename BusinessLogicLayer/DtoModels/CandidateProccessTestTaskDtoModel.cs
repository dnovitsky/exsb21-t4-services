using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateProccessTestTaskDtoModel
    {
        public CandidateProccessTestTaskDtoModel() { }

        public CandidateProccessTestTaskDtoModel(Guid candidateProcessId, Guid testFileId, DateTime endTestDate, string linkDownloadToken = "")
        {
            CandidateProcessId = candidateProcessId;
            TestFileId = testFileId;
            EndTestDate = endTestDate;
            LinkDownloadToken = linkDownloadToken;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CandidateProcessId { get; set; }

        public Guid TestFileId { get; set; }

        public Nullable<Guid> CandidateResponseTestFileId { get; set; } = null;

        public DateTime SendTestDate { get; set; } = DateTime.Now;

        public DateTime EndTestDate { get; set; }

        public string LinkDownloadToken { get; set; } = "";
    }
}
