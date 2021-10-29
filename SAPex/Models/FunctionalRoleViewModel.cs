using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class FunctionalRoleViewModel: AbstractNameViewModel
    {
        public FunctionalRoleViewModel(Guid Id, string Name, string Access) : base(Id, Name)
        {
            this.Access = Access;
        }

        [Required]
        public string Access { get; set; }
    }
}
