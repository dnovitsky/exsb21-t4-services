using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public abstract class AbstractIdViewModel
    {
        public AbstractIdViewModel(Guid Id)
        {
            this.Id = Id;
        }

        [Key]
        public Guid Id { get; set; }
    }
}
