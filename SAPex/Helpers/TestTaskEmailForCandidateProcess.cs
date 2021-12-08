using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using DbMigrations.EntityModels.DataTypes;

namespace SAPex.Helpers
{
    public class TestTaskEmailForCandidateProcess
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICandidateProcessTestTaskService _candidateProcessTestTaskService;
        private readonly ITestTaskTokenBusinessService _testTaskTokenService;
        private readonly ITestTaskRouteService _testTaskRouteService;
        private readonly IEmailBuilderService _emailBuilderService;
        private readonly IEmailService _emailService;
        private readonly IAppSettingService _appSettingService;
        private int _testTaskFileCategory = (int)BusinessLogicLayer.DtoModels.FileCategory.TestTaskTemplate;

        public TestTaskEmailForCandidateProcess(IUnitOfWork unitOfWork,
            ICandidateProcessTestTaskService candidateProcessTestTaskService,
            ITestTaskTokenBusinessService testTaskTokenService,
            ITestTaskRouteService testTaskRouteService,
            IEmailBuilderService emailBuilderService,
            IEmailService emailService,
            IAppSettingService appSettingService)
        {
            _unitOfWork = unitOfWork;
            _candidateProcessTestTaskService = candidateProcessTestTaskService;
            _testTaskTokenService = testTaskTokenService;
            _testTaskRouteService = testTaskRouteService;
            _emailBuilderService = emailBuilderService;
            _emailService = emailService;
            _appSettingService = appSettingService;
        }

        public async Task<bool> SendTestTaskEmailForCandidate(IList<Guid> processIds)
        {
            try
            {
                foreach (var processId in processIds)
                {
                    var isEmailSend = await GenerateCandidateTestTaskEmailData(processId);
                    if (!isEmailSend)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<bool> GenerateCandidateTestTaskEmailData(Guid processId)
        {
            try
            {
                var candidateProcess = await _unitOfWork.CandidateProcceses.FindByIdAsync(processId);
                var candidateSandbox = candidateProcess.CandidateSandbox;
                var candidate = candidateSandbox.Candidate;

                var testTaskDownloadUrl = await GetCurrentValueByNameFromAppSetting("TestTaskUrl");
                var testTaskUploadUrl = await GetCurrentValueByNameFromAppSetting("TestResultUrl");
                var testTaskLifeTime = await GetCurrentValueByNameFromAppSetting("TestTaskLifeTime");
                var sapexEmail = await GetCurrentValueByNameFromAppSetting("TestTasksSapexEmail");

                var candidateProcessTestTask = await CreateCandidateProcessTestTask(candidateProcess, testTaskLifeTime);

                _testTaskRouteService.Init(new TestTaskRoutModel()
                {
                    DownloadUrl = testTaskDownloadUrl,
                    UploadUrl = testTaskUploadUrl,
                    Token = candidateProcessTestTask.Token,
                });

                _emailBuilderService.Init(new EmailBodyBuilderModel()
                {
                    Name = await TemplateHelper.GenerateName(candidate),
                    SandboxName = candidateSandbox.Sandbox.Name,
                    TestTaskDownloadUrl = await _testTaskRouteService.GetDownloadUrl(),
                    TestTaskUploadUrl = await _testTaskRouteService.GetUploadPageUrl(),
                    TestTaskLifeTime = testTaskLifeTime,
                });

                await _emailService.CreateAsync(new EmailDtoModel()
                {
                    Id = Guid.NewGuid(),
                    EmailFrom = sapexEmail,
                    Head = await _emailBuilderService.BuildEmailSubject(),
                    Message = await _emailBuilderService.BuildEmailBody(),
                    EmailTo = candidate.Email,
                    Status = EmailStatusType.ReadyForSend,
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<CandidateProcessTestTaskDtoModel> CreateCandidateProcessTestTask(CandidateProcesEntityModel candidateProcess, string endTestDate)
        {
            try
            {
                List<FileEntityModel> files = (List<FileEntityModel>)await _unitOfWork.Files.GetAllAsync();
                var file = files.Count > 0 ? files.Find(x => (int)x.Category == _testTaskFileCategory) : null;
                var email = candidateProcess.CandidateSandbox.Candidate.Email;
                var token = _testTaskTokenService.GetToken(email, candidateProcess.Id);
                var startDate = DateTime.UtcNow;
                var endDate = startDate + TimeSpan.FromMilliseconds(startDate.Millisecond + double.Parse(endTestDate));

                var candidateProcessTestTask = await _candidateProcessTestTaskService.CreateCandidateProcessTestTaskAsync(new CandidateProcessTestTaskDtoModel(
                    candidateProcess.Id,
                    file.Id,
                    startDate,
                    endDate,
                    token));

                return candidateProcessTestTask;
            }
            catch
            {
                return null;
            }
        }

        private async Task<string> GetCurrentValueByNameFromAppSetting(string name)
        {
            var appSettings = (List<AppSettingDtoModel>)(await _appSettingService.FindAppSettingAsync(x => x.Name == name));
            return appSettings.Count > 0 ? appSettings[0].Value : null;
        }
    }
}
