using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class FileDtoModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public FileCategory Category { get; set; }

        public string CategoryName { get; set; }
        public Guid? StackTechnologyId { get; set; }
    }
    public enum FileCategory
    {
        Other,
        TestTaskTemplate,
        TestTaskResult
    }
}
