using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAPex.Models;

namespace SAPex.Controllers
{
    [Route("api/testresults")]
    [ApiController]
    public class TestResultsController : ControllerBase
    {
        private readonly ICandidateService _candidateservice;
        private readonly IFileService _fileService;

        public TestResultsController(ICandidateService candidateservice, IFileService fileservice)
        {
            _candidateservice = candidateservice;
            _fileService = fileservice;
        }

        [HttpPost]
        public async Task<IActionResult> TestResultValidationAsync([FromQuery] TestResultsViewModel testResultsViewModel)
        {
            var candiddatesDto = await _candidateservice.GetAllCandidateAsync();
            var candidateDto = candiddatesDto.Where(c => c.Email == testResultsViewModel.Email).FirstOrDefault();
            var file = await _fileService.FindFileByIdAsync(testResultsViewModel.FileId);
            if (candidateDto != null && file != null)
            {
                return await Task.FromResult(Ok());
            }

            return await Task.FromResult(ValidationProblem());
        }
    }
}
