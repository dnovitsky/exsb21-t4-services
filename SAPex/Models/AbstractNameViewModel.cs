using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public abstract class AbstractNameViewModel : AbstractIdViewModel
    {
        public AbstractNameViewModel()
            : base()
        {
            Name = string.Empty;
        }

        public AbstractNameViewModel(string name)
            : base()
        {
            Name = name;
        }

        public AbstractNameViewModel(Guid id, string name)
            : base(id)
        {
            Name = name;
        }

        [Required]
        public string Name { get; set; }
    }
}
