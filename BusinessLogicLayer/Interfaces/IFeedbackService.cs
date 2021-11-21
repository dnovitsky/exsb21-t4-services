﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using System.Linq.Expressions;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFeedbackService
    {
        Task<Guid> CreateFeedbackAsync(FeedbackDtoModel feedbackDto); //+

        Task<FeedbackDtoModel> GetFeedbackByIdAsync(Guid feedbackId); //+

        Task<bool> UpdateFeedback(FeedbackDtoModel feedbackDto);
    }
}
