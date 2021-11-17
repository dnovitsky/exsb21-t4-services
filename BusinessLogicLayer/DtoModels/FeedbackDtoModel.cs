﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class FeedbackDtoModel
    {
        public Guid Id { get; set; }

        public UserDtoModel User { get; set; }

        public Guid RatingId { get; set; }

        public DateTime CreateDate { get; set; }
        public string UserReview { get; set; }
    }
}