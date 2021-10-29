using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public abstract class AbstractIdViewModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
