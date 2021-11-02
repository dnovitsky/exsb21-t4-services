using System.ComponentModel.DataAnnotations;
using System;

namespace SAPex.Models
{
    public abstract class AbstractNameViewModel: AbstractIdViewModel
    {
        public AbstractNameViewModel() : base()
        {
            this.name = "";
        }
        public AbstractNameViewModel(string name) : base()
        {
            this.name = name;
        }

        [Required]
        public string name { get; set; }
    }
}
