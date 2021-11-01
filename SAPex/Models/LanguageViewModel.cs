using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class LanguageViewModel: AbstractNameViewModel
    {
        public LanguageViewModel() : base() { }
        public LanguageViewModel(string name) : base(name) { }
    }
}
