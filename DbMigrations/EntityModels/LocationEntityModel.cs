using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class LocationEntityModel : NameEntityModel
    {
        public LocationEntityModel() : base()
        {
            Candidates = new List<CandidateEntityModel>();
            Users = new List<UserEntityModel>();
        }

        public LocationEntityModel(string name) : base(name)
        {
            Candidates = new List<CandidateEntityModel>();
            Users = new List<UserEntityModel>();
        }

        public virtual IList<CandidateEntityModel> Candidates { get; set; }
        public virtual IList<UserEntityModel> Users { get; set; }
    }
}
