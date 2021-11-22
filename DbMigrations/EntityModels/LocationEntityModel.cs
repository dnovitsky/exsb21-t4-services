using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class LocationEntityModel
    {
        public LocationEntityModel()
        {
            Candidates = new List<CandidateEntityModel>();
            Users = new List<UserEntityModel>();
        }

        public LocationEntityModel(string name)
        {
            Candidates = new List<CandidateEntityModel>();
            Users = new List<UserEntityModel>();
            Id = Guid.NewGuid();
            Name = name;
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IList<CandidateEntityModel> Candidates { get; set; }
        public virtual IList<UserEntityModel> Users { get; set; }
    }
}
