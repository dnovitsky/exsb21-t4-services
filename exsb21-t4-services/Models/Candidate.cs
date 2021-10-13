using System;
using System.Collections.Generic;

namespace exsb21_t4_services.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string CandidateSurname { get; set; }
        public int SpecialisationId { get; set; }
        public string Location { get; set; }
        public string Education { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Phone { get; set; }
        public List<Skill> Skills { get; set; }
        public int Status { get; set; }
        public Candidate()
        {
        }
    }
}
 