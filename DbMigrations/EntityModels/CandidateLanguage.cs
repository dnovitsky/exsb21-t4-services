using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class CandidateLanguage
    {
        public int Id { get; set; }
        public List<Candidate> CandidateId { get; set; }
        public List<Language> LanguageId { get; set; }
        public int Level  { get; set; }
    }
}
