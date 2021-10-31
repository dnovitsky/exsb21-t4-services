using System.ComponentModel.DataAnnotations;
using System;

namespace SAPex.Models
{
    public abstract class AbstractNameViewModel: AbstractIdViewModel
    {
        public AbstractNameViewModel(Guid id, string name) : base(id)
        {
            this.name = name;
        }

        [Required]
        public string name { get; set; }
    }
}
