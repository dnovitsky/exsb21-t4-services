﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class StackTechnologyEntityModel
    {
        public StackTechnologyEntityModel()
        {
            CandidateSandboxes = new List<CandidateSandboxEntityModel>();
            SandboxStackTechnologies = new List<SandboxStackTechnologyEntityModel>();
            UserStackTechnologies = new List<UserStackTechnologyEntityModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<CandidateSandboxEntityModel> CandidateSandboxes { get; set; }
        public IList<SandboxStackTechnologyEntityModel> SandboxStackTechnologies { get; set; }
        public IList<UserStackTechnologyEntityModel> UserStackTechnologies { get; set; }
    }
}