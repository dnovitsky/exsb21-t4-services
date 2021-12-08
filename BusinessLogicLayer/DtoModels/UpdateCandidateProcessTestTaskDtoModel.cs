using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class UpdateCandidateProcessTestTaskDtoModel
    {
        public Nullable<Guid> TestFileId { get; set; } = null;

        public Nullable<Guid> CandidateResponseTestFileId { get; set; } = null;

        public Nullable<DateTime> EndTestDate { get; set; } = null;

        public string Token { get; set; } = "";
    }
}
