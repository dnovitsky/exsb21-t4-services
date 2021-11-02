﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SAPex.Models
{
    public class LanguageLevelViewModel: AbstractNameViewModel
    {
        public LanguageLevelViewModel() : base() { }
        public LanguageLevelViewModel(string name) : base(name) { }
    }
}