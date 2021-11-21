﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class SandboxViewModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MaxCandidates { get; set; }

        public string CreateDate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string StartRegistration { get; set; }

        public string EndRegistration { get; set; }

        public string Status { get; set; }

        public IEnumerable<StackTechnologyViewModel> StackTechnologies { get; set; }

        public IEnumerable<LanguageViewModel> Languages { get; set; }

        public IEnumerable<MentorViewModel> Mentors { get; set; }

        public IEnumerable<RecruiterViewModel> Recruiters { get; set; }

        public IEnumerable<InterviewerViewModel> Interviewers { get; set; }
    }
}
