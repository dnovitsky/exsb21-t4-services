using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CandidateSandboxService : ICandidateSandboxService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CandidateSandboxProfile profile;

        public CandidateSandboxService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            profile = new CandidateSandboxProfile();
        }

        public async Task<CandidateSandboxEntityModel> GetByIdAsync(Guid id)
        {
            CandidateSandboxEntityModel candidateSandbox = await unitOfWork.CandidateSandboxes.FindByIdAsync(id);
            return candidateSandbox;
        }

        public async Task<CandidateSandboxEntityModel> GetByProccessIdAsync(Guid processId)
        {
            var candidateProccess = await unitOfWork.CandidateProcceses.FindByIdAsync(processId);
            CandidateSandboxEntityModel candidateSandbox = await unitOfWork.CandidateSandboxes.FindByIdAsync(candidateProccess.CandidateSandboxId);
            return candidateSandbox;
        }
    }
}
