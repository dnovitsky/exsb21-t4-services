using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateFilterParametrsDtoModel
    {
        public CandidateFilterParametrsDtoModel()
        {
            LocationId = null;
            MentorId = null;
            SandboxId = null;
            SearchingStatus = SearchStatus.None;
        }

        public CandidateFilterParametrsDtoModel(Guid locationId, Guid mentorId, Guid sandboxId, SearchStatus searchStatus)
        {
            LocationId = locationId;
            MentorId = mentorId;
            SandboxId = sandboxId;
            SearchingStatus = searchStatus;
        }

        public Guid? LocationId { get; set; }

        public Guid? MentorId { get; set; }

        public Guid? SandboxId { get; set; }

        public SearchStatus SearchingStatus { get; set; }
    }
}
