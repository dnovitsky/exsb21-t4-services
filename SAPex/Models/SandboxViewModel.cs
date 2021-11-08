using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class SandboxViewModel
    {
        [DefaultValue(null)]
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public SandboxViewModel()
        {
            Name = string.Empty;
        }

        public SandboxViewModel(string name)
            : base()
        {
            Name = name;
        }
    }
}
