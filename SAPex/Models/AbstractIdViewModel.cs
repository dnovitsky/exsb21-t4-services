using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public abstract class AbstractIdViewModel
    {
        public AbstractIdViewModel(Guid id)
        {
            this.id = id;
        }

        [Key]
        public Guid id { get; set; }
    }
}
