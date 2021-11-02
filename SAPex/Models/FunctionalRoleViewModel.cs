using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class FunctionalRoleViewModel: AbstractNameViewModel
    {
        public FunctionalRoleViewModel() : base()
        {
            this.access = "";
        }
        public FunctionalRoleViewModel(string name, string access) : base(name)
        {
            this.access = access;
        }

        [Required]
        public string access { get; set; }
    }
}
