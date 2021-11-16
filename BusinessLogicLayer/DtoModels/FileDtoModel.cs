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
        public int AwsS3Id { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
