﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;
using SAPex.Models.Validators;

namespace SAPex.Controllers
{
    [Route("api/feedbacks")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IUserService _userService;
        private readonly FeedbackMapper _mapper = new FeedbackMapper();

        public FeedbacksController(IFeedbackService service, IUserService userService)
        {
            _feedbackService = service;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedbackById(Guid id)
        {
            FeedbackViewModel feedbackVM = _mapper.DtoToView(await _feedbackService.GetFeedbackByIdAsync(id));
            return await Task.FromResult(Ok(feedbackVM));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FeedbackViewModel feedbackVM)
        {
            if (feedbackVM == null)
            {
                return await Task.FromResult(BadRequest());
            }

            UserDtoModel user = await _userService.FindByIdConditionAsync(u => u.UserId == feedbackVM.UserId);

            feedbackVM.CreateDate = DateTime.UtcNow;
            feedbackVM.Author = $"{user.Name} {user.Surname}";

            FeedbackDtoModel feedbackDto = _mapper.ViewToDto(feedbackVM);
            Guid feedbackId = await _feedbackService.CreateFeedbackAsync(feedbackDto);
            return await Task.FromResult(Ok(feedbackId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] FeedbackViewModel feedbackVM)
        {
            FeedbackDtoModel feedbackDtoCheck = await _feedbackService.GetFeedbackByIdAsync(id);

            if (feedbackDtoCheck == null)
            {
                return await Task.FromResult(NotFound());
            }

            UserDtoModel user = await _userService.FindByIdConditionAsync(u => u.UserId == feedbackDtoCheck.UserId);

            FeedbackViewModel newFeedbackVM = new FeedbackViewModel
            {
                Id = id,
                UserId = feedbackDtoCheck.UserId,
                Author = $"{user.Name} {user.Surname}",
                Grade = feedbackVM.Grade,
                CreateDate = DateTime.UtcNow,
                UserReview = feedbackVM.UserReview,
                CandidateProccesId = feedbackDtoCheck.CandidateProccesId,
            };

            FeedbackDtoModel feedbackDto = _mapper.ViewToDto(newFeedbackVM);
            bool check = await _feedbackService.UpdateFeedback(feedbackDto);

            if (check)
            {
                return await Task.FromResult(Ok($"Was Updated! Check by id: {id}"));
            }

            return await Task.FromResult(Ok("Doesn't update"));
        }
    }
}
