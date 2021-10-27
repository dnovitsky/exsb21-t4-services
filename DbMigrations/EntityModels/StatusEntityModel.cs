using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class StatusEntityModel
    {
        public StatusEntityModel()
        {
            CandidatesProcceses = new List<CandidateProccesEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<CandidateProccesEntityModel> CandidatesProcceses { get; set; }
    }
}
