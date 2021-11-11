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
        public virtual UserEntityModel User { get; set; }
        public Guid StackTechnologyId { get; set; }
        public virtual StackTechnologyEntityModel StackTechnology { get; set; }
        
    }
}
