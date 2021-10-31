using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class LanguageViewModel: AbstractNameViewModel
    {
        public LanguageViewModel(Guid id, string name) : base(id, name) { }
    }
}
