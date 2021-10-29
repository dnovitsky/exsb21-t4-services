using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class StatusViewModel: AbstractNameViewModel
    {
        public StatusViewModel(Guid Id, string Name) : base(Id, Name) { }
    }
}
