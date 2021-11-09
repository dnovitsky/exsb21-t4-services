﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class AvailabilityEntityModel
    {
        public AvailabilityEntityModel()
        {
            Candidates = new List<CandidateEntityModel>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IList<CandidateEntityModel> Candidates { get; set; }
    }
}
