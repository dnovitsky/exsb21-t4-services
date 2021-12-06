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
            СandidateProccessTestTasks = new List<CandidateProcessTestTaskEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public FileCategory Category { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public virtual IList<CandidateProcessTestTaskEntityModel> СandidateProccessTestTasks { get; set; }

        public Guid? StackTechnologyId { get; set; }

        public virtual StackTechnologyEntityModel StackTechnology { get; set; }
    }
    public enum FileCategory
    {
        Other,
        TestTaskTemplate,
        TestTaskResult
    }
}
