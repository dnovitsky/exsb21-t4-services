using BusinessLogicLayer.DtoModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class SandboxDtoModel : ItemDtoModel
    {
        public string Description { get; set; }

        public int MaxCandidates { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartRegistration { get; set; }

        public DateTime EndRegistration { get; set; }
        public StatusName Status { get; set; }
    }

    public enum StatusName { Draft, Active, Registration, Application, Inprogress, Archive };
}
