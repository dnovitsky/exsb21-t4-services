using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CandidateService : ICandidateService
    {
        protected readonly CandidateProfile profile;
        protected readonly LocationProfile locationProfile;
        private readonly IUnitOfWork unitOfWork;
        private readonly InputParametrsProfile inputParametrsProfile;
        private readonly CandidateFilterParametrsMapper candidateFilterParametrsProfile;

        public CandidateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.profile = new CandidateProfile(unitOfWork);
            inputParametrsProfile = new InputParametrsProfile();
            candidateFilterParametrsProfile = new CandidateFilterParametrsMapper();
            locationProfile = new LocationProfile();
        }
        public async Task<CandidateDtoModel> AddCandidateAsync(CreateCandidateDtoModel candidateDto)
        {
            try
            {
                var candidates = await unitOfWork.Candidates.FindByConditionAsync(x => x.Email == candidateDto.Email && x.Phone == candidateDto.PhoneNumber);
                if (candidates.Any())
                {
                    return await AddNewCandidateSandbox(candidates.FirstOrDefault(), candidateDto);
                }

                var location = await GetLocation(candidateDto);

                // var candidateEM = await unitOfWork.Candidates.CreateAsync(profile.MapNewCandidateToEM(location.Id, candidateDto));

                CandidateEntityModel candidateEM = await unitOfWork.Candidates.CreateAsync( new CandidateEntityModel()
                {
                    Id = Guid.NewGuid(),
                    Name = candidateDto.Name,
                    Surname = candidateDto.Surname,
                    Email = candidateDto.Email,
                    LocationId = location.Id,
                    Skype = candidateDto.Skype,
                    Phone = candidateDto.PhoneNumber,
                    ProfessionaCertificates = candidateDto.ProfessionaCertificates,
                    AdditionalSkills = candidateDto.AdditionalSkills,
                });

                if (candidateEM != null)
                {
                    await unitOfWork.SaveAsync();

                    var candidateSandBoxe = await CreateNewCandidateSandbox(candidateEM, candidateDto);

                    await CreateCandidateProcessForCandidateSandbox(candidateSandBoxe, candidateDto);
                    await CreateCandidateLanguage(candidateEM, candidateDto);

                    return profile.MapCandidateEMToCandidateDto(candidateEM);
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void DeleteCandidate(Guid id)
        {
            unitOfWork.Languages.Delete(id);
        }

        public async Task<CandidateDtoModel> FindCandidateByIdAsync(Guid id)
        {
            CandidateEntityModel candidateEM = await unitOfWork.Candidates.FindByIdAsync(id); 
            CandidateDtoModel candidateDto = profile.MapCandidateEMToCandidateDto(candidateEM);
            return candidateDto;
        }

        public async Task<IEnumerable<CandidateDtoModel>> FindCandidateAsync(Expression<Func<CandidateEntityModel, bool>> expression)
        {
            IEnumerable<CandidateEntityModel> candidateEM = await unitOfWork.Candidates.FindByConditionAsync(expression);
            return profile.MapCandidateEMListToCandidateDtoList(candidateEM);
        }

        public async Task<IEnumerable<CandidateDtoModel>> GetAllCandidateAsync()
        {
            IEnumerable<CandidateEntityModel> candidateEM = await unitOfWork.Candidates.GetAllAsync();
            return profile.MapCandidateEMListToCandidateDtoList(candidateEM);
        }

        public async Task<PagedList<CandidateDtoModel>> GetPagedCandidatesAsync(InputParametrsDtoModel parametrs, CandidateFilterParametrsDtoModel candidateFilterParametrs)
        {
            PagedList<CandidateEntityModel> candidateList = await unitOfWork.Candidates.GetPagedAsync(
                inputParametrsProfile.MapFromDtoToEntity(parametrs),
                candidateFilterParametrsProfile.MapFromDtoToEntity(candidateFilterParametrs));
            PagedList<CandidateDtoModel> sandboxDtoList = new PagedList<CandidateDtoModel>
            {
                PageList = profile.MapCandidateEMListToCandidateDtoList(candidateList.PageList),
                TotalPages = candidateList.TotalPages,
                CurrentPage = candidateList.CurrentPage,
                TotalPageItems = candidateList.TotalPageItems
            };

            return sandboxDtoList;
        }

        public async Task<bool> UpdateCandidateStatus(Guid candidateId, Guid candidateSandboxId, Guid newStatusId)
        {
            var candidateSandboxe = await unitOfWork.CandidateSandboxes.FindByIdAsync(candidateSandboxId);
            var status = await unitOfWork.Statuses.FindByIdAsync(newStatusId);

            if (candidateSandboxe != null && status != null && candidateSandboxe.CandidateId.Equals(candidateId))
            {
                var process = new CandidateProcesEntityModel();
                process.StatusId = newStatusId;
                process.CandidateSandboxId = candidateSandboxId;
                
                await unitOfWork.CandidateProcceses.CreateAsync(process);
                await unitOfWork.SaveAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<CandidateDtoModel>> GetCandidatesByUserIdAsync(Guid id)
        {
            IEnumerable<CandidateEntityModel> CandidatesEM = await Task.Run(() => unitOfWork.Candidates.GetByUserId(id));
            return profile.MapCandidateEMListToCandidateDtoList(CandidatesEM);
        }

        public async Task<IEnumerable<CandidateDtoModel>> GetCandidatesByUserIdSandboxIdAsync(Guid userId, Guid sandboxId)
        {
            IEnumerable<CandidateEntityModel> CandidatesEM = await Task.Run(() => unitOfWork.Candidates.GetByUserIdSandboxId(userId, sandboxId));
            return profile.MapCandidateEMListToCandidateDtoList(CandidatesEM);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private async Task<CandidateDtoModel> AddNewCandidateSandbox(CandidateEntityModel candidateEM, CreateCandidateDtoModel candidateDto)
        {
            var isCanAddNewSandbox = !candidateEM.CandidateSandboxes.Where(x => x.SandboxId.Equals(candidateDto.SandboxId)).Any();
            var sandbox = await unitOfWork.Sandboxes.FindByIdAsync(candidateDto.SandboxId);
            var currentDate = DateTime.Now;

            if (isCanAddNewSandbox && sandbox != null && currentDate <= sandbox.StartDate && currentDate <= sandbox.EndDate)
            {
                var candidateSandBoxe = await CreateNewCandidateSandbox(candidateEM, candidateDto);

                await CreateCandidateProcessForCandidateSandbox(candidateSandBoxe, candidateDto);

                return profile.MapCandidateEMToCandidateDto(candidateEM);
            }

                return null;
        }

        private async Task<CandidateSandboxEntityModel> CreateNewCandidateSandbox(CandidateEntityModel candidateEM, CreateCandidateDtoModel candidateDto)
        {
            var candidateSandBoxe = await unitOfWork.CandidateSandboxes.CreateAsync(profile.MapNewCandidateSandBoxToEM(candidateEM.Id, candidateDto));
            await unitOfWork.SaveAsync();

            return candidateSandBoxe;
        }

        private async Task<CandidateProcesEntityModel> CreateCandidateProcessForCandidateSandbox(CandidateSandboxEntityModel candidateSandBoxe, CreateCandidateDtoModel candidateDto)
        {
            var defaultStatuses = await unitOfWork.Statuses.FindByConditionAsync(x => x.Name == "Draft");
            StatusEntityModel defaultStatuse = defaultStatuses.FirstOrDefault();
            var candidateProcceses = await unitOfWork.CandidateProcceses.CreateAsync(profile.MapNewCandidateProcessEM(candidateSandBoxe.Id, defaultStatuse.Id, candidateDto));
            await unitOfWork.SaveAsync();

            return candidateProcceses;
        }

        private async Task<CandidateLanguageEntityModel> CreateCandidateLanguage(CandidateEntityModel candidateEM, CreateCandidateDtoModel candidateDto)
        {
            var defaultLanguages = await unitOfWork.Languages.FindByConditionAsync(x => x.Name == "English");
            LanguageEntityModel defaultLanguage = defaultLanguages.FirstOrDefault();
            var candidateLanguages = await unitOfWork.CandidateLanguages.CreateAsync(profile.MapNewCandidateLanguagesEM(candidateEM.Id, defaultLanguage.Id, candidateDto));
            await unitOfWork.SaveAsync();

            return candidateLanguages;
        }

        private async Task<LocationEntityModel> GetLocation(CreateCandidateDtoModel candidateDto)
        {
            var locations = await unitOfWork.Locations.FindByConditionAsync(x => x.Name == candidateDto.Location);
            LocationEntityModel location = null;

            if (locations.Any())
            {
                location = locations.FirstOrDefault();
            }
            else
            {
                location = new LocationEntityModel(candidateDto.Location.ToLower());
                await unitOfWork.Locations.CreateAsync(location);
                await unitOfWork.SaveAsync();
            }

            return location;
        }
    }
}
