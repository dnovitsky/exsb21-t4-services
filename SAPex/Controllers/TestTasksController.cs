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
    [Route("api/testtasks")]
    [ApiController]
    public class TestTasksController : ControllerBase
    {
        private readonly ICandidateProcessTestTaskService _candidatettservise;

        public TestTasksController(ICandidateProcessTestTaskService service)
        {
            _candidatettservise = service;
        }

        [HttpGet("{token}")]
        public async Task<IActionResult> GetTestTask([FromRoute] string token)
        {
            var candidateprocesstasks = await _candidatettservise.GetCandidateProcessTestTasksAsync();

            var candidateprocesstask = candidateprocesstasks.Where(c => c != null && c.LinkDownloadToken == token).FirstOrDefault();

            if (candidateprocesstask == null)
            {
                return await Task.FromResult(NotFound());
            }

            if (candidateprocesstask.EndTestDate < DateTime.UtcNow)
            {
                return await Task.FromResult(BadRequest("The task has timed out"));
            }

            return RedirectToAction("DownloadFile", "Files", new { id = candidateprocesstask.TestFileId });
        }
    }
}
