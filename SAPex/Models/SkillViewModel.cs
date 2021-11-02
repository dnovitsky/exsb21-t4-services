using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class SkillViewModel: AbstractNameViewModel
    {
        public SkillViewModel() : base() { }
        public SkillViewModel(string name) : base(name) { }
    }
}
