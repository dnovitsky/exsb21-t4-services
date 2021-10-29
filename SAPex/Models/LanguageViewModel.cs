using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class LanguageViewModel: AbstractNameViewModel
    {
        public LanguageViewModel(Guid Id, string Name) : base(Id, Name) { }
    }
}
