using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class SandboxTestViewModel
    {
        [DefaultValue(null)]
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public SandboxTestViewModel()
        {
            Name = string.Empty;
        }

        public SandboxTestViewModel(string name)
            : base()
        {
            Name = name;
        }
    }
}
