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
        private readonly ICandidateProcessTestTaskService _candidateProcessTestTaskService;
        private readonly IFileService _fileService;

        public TestResultsController(ICandidateService candidateservice,
            IFileService fileservice,
            ICandidateProcessTestTaskService candidateProcessTestTaskService)
        {
            _candidateservice = candidateservice;
            _fileService = fileservice;
            _candidateProcessTestTaskService = candidateProcessTestTaskService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadTestResultAsync([FromBody] TestResultsViewModel testResultsViewModel)
        {
            var fileId = testResultsViewModel.FileId;
            var token = testResultsViewModel.Token;

            var candidateprocesstasks = await _candidateProcessTestTaskService.GetCandidateProcessTestTasksAsync();
            var candidateprocesstask = candidateprocesstasks.Where(c => c != null && c.LinkDownloadToken == token).FirstOrDefault();

            if (candidateprocesstask == null)
            {
                return await Task.FromResult(NotFound());
            }

            if (candidateprocesstask.EndTestDate < DateTime.UtcNow)
            {
                return await Task.FromResult(BadRequest("The task has timed out"));
            }

            await _candidateProcessTestTaskService.AddCandidateResponseTestFileAsync(candidateprocesstask.Id, fileId);

            return await Task.FromResult(Ok());
        }
    }
}
