using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class LanguageLevelViewModel: AbstractNameViewModel
    {
        public LanguageLevelViewModel(Guid Id, string Name) : base(Id, Name) { }
    }
}
