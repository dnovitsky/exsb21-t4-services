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
        public TestTask TestTaskType { get; set; }
        public Guid? StackTechnologyId { get; set; }
    }
    public enum TestTask
    {
        Other,
        TestTaskTemplate,
        TestTaskResult
    }
}
