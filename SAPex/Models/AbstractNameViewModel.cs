﻿using System.ComponentModel.DataAnnotations;
using System;

namespace SAPex.Models
{
    public abstract class AbstractNameViewModel: AbstractIdViewModel
    {
        public AbstractNameViewModel() : base()
        {
            this.Name = "";
        }
        public AbstractNameViewModel(string name) : base()
        {
            this.Name = name;
        }

        [Required]
        public string Name { get; set; }
    }
}
