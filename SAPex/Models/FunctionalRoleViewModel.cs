using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class FunctionalRoleViewModel: AbstractNameViewModel
    {
        public FunctionalRoleViewModel(Guid id, string name, string access) : base(id, name)
        {
            this.access = access;
        }

        [Required]
        public string access { get; set; }
    }
}
