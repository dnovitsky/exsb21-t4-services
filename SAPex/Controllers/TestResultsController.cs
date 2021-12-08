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
        private readonly IStatusService _statusService;
        private readonly ICandidateSandboxService _candidateSandboxService;

        public TestResultsController(ICandidateService candidateservice,
            IFileService fileservice,
            ICandidateProcessTestTaskService candidateProcessTestTaskService,
            IStatusService statusService,
            ICandidateSandboxService candidateSandboxService)
        {
            _candidateservice = candidateservice;
            _fileService = fileservice;
            _candidateProcessTestTaskService = candidateProcessTestTaskService;
            _statusService = statusService;
            _candidateSandboxService = candidateSandboxService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadTestResultAsync([FromBody] TestResultsViewModel testResultsViewModel)
        {
            var fileId = testResultsViewModel.FileId;
            var token = testResultsViewModel.Token;

            FileDtoModel fileDtoModel = await _fileService.FindFileByIdAsync(fileId);
            if (fileDtoModel == null)
            {
                return await Task.FromResult(NotFound());
            }

            StatusDtoModel status = await _statusService.FindStatusByConditionAsync(x => x.Name == "Need verification");
            var candidateprocesstasks = await _candidateProcessTestTaskService.GetCandidateProcessTestTasksAsync();
            var candidateprocesstask = candidateprocesstasks.Where(c => c != null && c.Token == token).FirstOrDefault();

            if (candidateprocesstask == null)
            {
                return await Task.FromResult(NotFound());
            }

            if (candidateprocesstask.EndTestDate < DateTime.UtcNow)
            {
                return await Task.FromResult(BadRequest("The task has timed out"));
            }

            Guid processId = candidateprocesstask.CandidateProcessId;
            var candidateSandbox = await _candidateSandboxService.GetByProccessIdAsync(processId);

            await _candidateservice.UpdateCandidateStatus(candidateSandbox.CandidateId, candidateSandbox.Id, status.Id);

            await _candidateProcessTestTaskService.AddCandidateResponseTestFileAsync(candidateprocesstask.Id, fileId);

            await _fileService.UpdateFileCategory(fileId, (int)FileCategory.TestTaskResult);

            return await Task.FromResult(Ok());
        }
    }
}
