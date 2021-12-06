using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class StatusEntityModel : NameEntityModel
    {
        public StatusEntityModel() : base()
        {
            CandidatesProcceses = new List<CandidateProcesEntityModel>();
        }

        public virtual IList<CandidateProcesEntityModel> CandidatesProcceses { get; set; }
    }
}
