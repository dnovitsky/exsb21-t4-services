using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserProfile userProfile = new();
        private readonly FeedbackProfile profile = new();
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

        public async Task<bool> UpdateFeedback(FeedbackDtoModel feedbackDto)
        {
            try
            {
                FeedbackEntityModel feedbackEM = profile.mapToEM(feedbackDto);
                unitOfWork.Feedbacks.Delete(feedbackEM.Id);
                await unitOfWork.Feedbacks.CreateAsync(feedbackEM);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
