using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class StatusViewModel: AbstractNameViewModel
    {
        public StatusViewModel(Guid id, string name) : base(id, name) { }
    }
}
