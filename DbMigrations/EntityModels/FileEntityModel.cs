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
        [Key]
        public Guid Id { get; set; }

        [Required]
        public TestTask TestTaskType { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public Guid? StackTechnologyId { get; set; }

        public virtual StackTechnologyEntityModel StackTechnology { get; set; }
    }
    public enum TestTask
    {
        Other,
        TestTaskTemplate,
        TestTaskResult
    }
}
