using System;
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
        private readonly FeedbackMapper _mapper = new FeedbackMapper();

        public FeedbacksController(IFeedbackService service)
        {
            _feedbackService = service;
        }

        [HttpGet("feedback/{feedbackId}")]
        public async Task<IActionResult> GetFeedbackById(Guid feedbackId)
        {
            FeedbackViewModel feedbackVM = _mapper.DtoToView(await _feedbackService.GetFeedbackByIdAsync(feedbackId));
            return await Task.FromResult(Ok(feedbackVM));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FeedbackViewModel feedbackVM)
        {
            if (feedbackVM == null)
            {
                return await Task.FromResult(BadRequest());
            }

            // ValidationResult validationResult = new FeedbackValidator().Validate(feedbackVM);
            // if (!validationResult.IsValid)
            // {
            //    return await Task.FromResult(BadRequest());
            // }

            FeedbackDtoModel feedbackDto = _mapper.ViewToDto(feedbackVM);
            Guid feedbackId = await _feedbackService.CreateFeedbackAsync(feedbackDto);
            return await Task.FromResult(Ok(feedbackId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, string userReview)
        {
            FeedbackDtoModel feedbackDtoCheck = await _feedbackService.GetFeedbackByIdAsync(id);

            if (feedbackDtoCheck == null)
            {
                return await Task.FromResult(NotFound());
            }

            // ValidationResult validationResult = new FeedbackValidator().Validate(feedbackVM);
            // if (!validationResult.IsValid)
            // {
            //    return await Task.FromResult(BadRequest());
            // }

            FeedbackViewModel newFeedbackVM = new FeedbackViewModel
            {
                Id = id,
                UserId = feedbackDtoCheck.UserId,
                RatingId = feedbackDtoCheck.RatingId,
                CreateDate = DateTime.Now,
                UserReview = userReview,
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
