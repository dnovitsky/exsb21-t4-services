using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class SkillViewModel: AbstractNameViewModel
    {
        public SkillViewModel(Guid Id, string Name) : base(Id, Name) { }
    }
}
