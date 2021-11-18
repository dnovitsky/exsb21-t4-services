using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly FeedbackProfile profile = new FeedbackProfile();
        private readonly CandidateProcessProfile processProfile = new();

        public FeedbackService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Guid> CreateFeedbackAsync(FeedbackDtoModel feedbackDto)
        {
            FeedbackEntityModel feedbackEM = profile.mapToEM(feedbackDto);
            feedbackEM = await unitOfWork.Feedbacks.CreateAsync(feedbackEM);
            await unitOfWork.SaveAsync();
            return feedbackEM.Id;
        }

        public async Task<FeedbackDtoModel> GetFeedbackByIdAsync(Guid feedbackId)
        {
            return profile.mapToDto(await unitOfWork.Feedbacks.FindByIdAsync(feedbackId));
        }

        public async Task<IEnumerable<FeedbackDtoModel>> GetFeedbacksCandidateProcces(Guid candidateProccesId)
        {
            return profile.mapListToDto(await unitOfWork.Feedbacks.FindByConditionAsync(f=>f.CandidateProccesId == candidateProccesId));
        }

        public async Task<IEnumerable<FeedbackDtoModel>> GetFeedbacksOfUser(Guid userId)
        {
            return profile.mapListToDto(await unitOfWork.Feedbacks.FindByConditionAsync(f => f.UserId == userId));
        }

        public async Task<IEnumerable<FeedbackDtoModel>> GetAllFeedbacksInCandidateSandbox(Guid candidateSandboxId)
        {
            IEnumerable<CandidateProcessDtoModel> candidateProcessesDto = processProfile.mapListToDto(await unitOfWork.CandidateProcceses.FindByConditionAsync(s => s.CandidateSandboxId == candidateSandboxId));
            IList<FeedbackDtoModel> feedbacksDto = new List<FeedbackDtoModel>();

            foreach(var candidateProcces in candidateProcessesDto)
            {
                IEnumerable <FeedbackDtoModel> feedbackDtos= profile.mapListToDto(await unitOfWork.Feedbacks.FindByConditionAsync(f => f.CandidateProccesId == candidateProcces.Id));
                
                foreach(var feedback in feedbackDtos)
                {
                    feedbacksDto.Add(feedback);
                }
            }

            return feedbacksDto;
        }
    }
}
