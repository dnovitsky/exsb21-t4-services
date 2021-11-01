﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public abstract class AbstractIdViewModel
    {
        [Key]
        [DefaultValue(null)]
        public Guid? id { get; set; }
    }
}
