using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class CandidateFilterParametrsDtoModel
    {
        public List<Guid>? Locations { get; set; } = null;

        public List<Guid>? Mentors { get; set; } = null;

        public List<Guid>? Sandboxes { get; set; } = null;

        public List<Guid>? Statuses { get; set; } = null;
    }
}
