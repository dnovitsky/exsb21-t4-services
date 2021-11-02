﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class AccessFormEntityModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid FormId { get; set; }
        public FormEntityModel Form { get; set; }

        [Required]
        public Guid AccessId { get; set; }
        public AccessEntityModel Access { get; set; }

        [Required]
        public Guid FunctionalRoleId { get; set; }
        public FunctionalRoleEntityModel FunctionalRole { get; set; }
    }
}