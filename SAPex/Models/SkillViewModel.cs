using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class SkillViewModel: AbstractNameViewModel
    {
        public SkillViewModel(Guid id, string name) : base(id, name) { }
    }
}
