﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class StatusViewModel: AbstractNameViewModel
    {
        public StatusViewModel() : base() { }
        public StatusViewModel(string name) : base(name) { }
    }
}