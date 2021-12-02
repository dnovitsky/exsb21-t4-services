using DbMigrations.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class FileEntityModel
    {
        public FileEntityModel()
        {
            СandidateProccessTestTasks = new List<CandidateProccessTestTasksEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }


        [Required]
        public string FileName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public virtual IList<CandidateProccessTestTasksEntityModel> СandidateProccessTestTasks { get; set; }
    }
}
