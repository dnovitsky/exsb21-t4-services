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
        private readonly FeedbackMapper _mapper = new FeedbackMapper();

        public FeedbacksController(IFeedbackService service)
        {
            _feedbackService = service;
        }

        [HttpGet("candidateProcces/{candidateProccesId}")]
        public async Task<IActionResult> GetFeedbackOfCurrentProcces(Guid candidateProccesId)
        {
            IEnumerable<FeedbackViewModel> feedbacksVM = _mapper.ListDtoToListView(await _feedbackService.GetFeedbacksCandidateProcces(candidateProccesId));
            return await Task.FromResult(Ok(feedbacksVM));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserFeedbacks(Guid userId)
        {
            IEnumerable<FeedbackViewModel> feedbacksVM = _mapper.ListDtoToListView(await _feedbackService.GetFeedbacksOfUser(userId));
            return await Task.FromResult(Ok(feedbacksVM));
        }

        [HttpGet("candidateSandbox/{candidateSandboxId}")]
        public async Task<IActionResult> GetAllFeedbacksInCandidateSandbox(Guid candidateSandboxId)
        {
            IEnumerable<FeedbackViewModel> feedbacksVM = _mapper.ListDtoToListView(await _feedbackService.GetAllFeedbacksInCandidateSandbox(candidateSandboxId));
            return await Task.FromResult(Ok(feedbacksVM));
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
    }
}