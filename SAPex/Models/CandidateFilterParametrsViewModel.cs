using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SAPex.Models
{
    public class CandidateFilterParametrsViewModel
    {
        [FromHeader]
        public List<Guid>? Locations { get; set; } = null;

        [FromHeader]
        public List<Guid>? Mentors { get; set; } = null;

        [FromHeader]
        public List<Guid>? Sandboxes { get; set; } = null;

        [FromHeader]
        public List<Guid>? Statuses { get; set; } = null;
    }
}
