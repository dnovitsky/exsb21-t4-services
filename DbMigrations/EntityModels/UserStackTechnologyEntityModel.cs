using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class UserStackTechnologyEntityModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public UserEntityModel User { get; set; }
        public Guid StackTechnologyId { get; set; }
        public StackTechnologyEntityModel StackTechnology { get; set; }
        
    }
}
