using System.ComponentModel.DataAnnotations;
using System;

namespace SAPex.Models
{
    public abstract class AbstractNameViewModel: AbstractIdViewModel
    {
        public AbstractNameViewModel(Guid Id, string Name) : base(Id)
        {
            this.Name = Name;
        }

        [Required]
        public string Name { get; set; }
    }
}
