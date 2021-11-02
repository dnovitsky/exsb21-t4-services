using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public abstract class AbstractIdViewModel
    {
        [DefaultValue(null)]
        public Guid? Id { get; set; }
    }
}
