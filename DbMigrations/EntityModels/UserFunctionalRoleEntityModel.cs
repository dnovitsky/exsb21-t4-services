﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DbMigrations.EntityModels
{
    public class UserFunctionalRoleEntityModel
    {
        public UserFunctionalRoleEntityModel()
        {
        
        }

        [Key]
        public Guid Id { get; set; }

        public Guid FunctionalRoleId { get; set; }
        public virtual FunctionalRoleEntityModel FunctionalRole { get; set; }
        public Guid UserId { get; set; }
        public virtual UserEntityModel User { get; set; }

    }
}
