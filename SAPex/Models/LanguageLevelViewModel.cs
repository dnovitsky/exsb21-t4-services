using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class LanguageLevelViewModel: AbstractNameViewModel
    {
        public LanguageLevelViewModel(Guid id, string name) : base(id, name) { }
    }
}
