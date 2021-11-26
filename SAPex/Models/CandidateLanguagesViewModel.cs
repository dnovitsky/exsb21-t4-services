using System;

namespace SAPex.Models
{
    public class CandidateLanguagesViewModel
    {
        public Guid Id { get; set; }

        public LanguageViewModel Language { get; set; }

        public LanguageLevelViewModel LanguageLevel { get; set; }
    }
}
