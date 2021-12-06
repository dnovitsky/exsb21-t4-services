using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EmailBuilderService : IEmailBuilderService
    {
        private readonly ITestTaskRouteService _taskRouteService;
        private readonly ICandidateService _candidateService;
        private readonly ISandboxService _sandboxService;

        public EmailBuilderService(ITestTaskRouteService testTaskRouteService, ICandidateService candidateService, ISandboxService sandboxService)
        {
            _taskRouteService = testTaskRouteService;
            _candidateService = candidateService;
            _sandboxService = sandboxService;
        }
        public async Task<string> BuildEmailBody(Guid candidateId, Guid sandboxId)
        {
            string Header = $"\tHello dear {(await _candidateService.FindCandidateByIdAsync(candidateId)).Name} you have passed to the next stage of the sandbox: {(await _sandboxService.FindSandboxByIdAsync(sandboxId)).Name}.\n";
            string Text = $"\tIf u want to continue your adventure, you should download test task from" +
                $"\n{await _taskRouteService.GetDownloadUrl(candidateId)}" +
                $"\nWhen you will complete this task u should upload your solution at" +
                $"\n{await _taskRouteService.GetUploadPageUrl(candidateId)}" +
                $"\n You have {await _taskRouteService.GetTestTaskLifeTime()} to send us your solition!";
            string Signature = $"\nWith best withes your SAPex.";

            return Header + Text + Signature;
        }

        public async Task<string> BuildEmailSubject(Guid sandboxId)
        {
            string Subject = $"Test task in sandbox {(await _sandboxService.FindSandboxByIdAsync(sandboxId)).Name}.";

            return Subject;
        }
    }
}
