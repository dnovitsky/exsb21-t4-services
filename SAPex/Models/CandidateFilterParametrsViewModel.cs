using System;

namespace SAPex.Models
{
    public class CandidateFilterParametrsViewModel
    {
        public CandidateFilterParametrsViewModel()
        {
            LocationId = null;
            MentorId = null;
            SandboxId = null;
            SearchingStatus = SearchStatus.None;
        }

        public CandidateFilterParametrsViewModel(Guid locationId, Guid mentorId, Guid sandboxId, SearchStatus searchStatus)
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
