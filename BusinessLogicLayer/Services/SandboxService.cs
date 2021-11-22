using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using AutoMapper;
using BusinessLogicLayer.Mapping;

namespace BusinessLogicLayer.Services
{
    public class SandboxService : ISandboxService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SandboxProfile profile;
        private readonly InputParametrsProfile inputParametrsProfile;
        private readonly FilterParametrsProfile filterParametrsProfile;
        
        public SandboxService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.profile = new SandboxProfile();
            inputParametrsProfile = new InputParametrsProfile();
            filterParametrsProfile = new FilterParametrsProfile();
        }

        public async Task<Guid> AddSandboxAsync(SandboxDtoModel sandboxDto)
        {
            SandboxEntityModel sandbox = profile.mapToEM(sandboxDto);
            SandboxEntityModel a = await unitOfWork.Sandboxes.CreateAsync(sandbox);
            await unitOfWork.SaveAsync();
            return a.Id;
        }
        public async Task<SandboxDtoModel> FindSandboxByIdAsync(Guid id)
        {
            SandboxEntityModel sandboxEM = await unitOfWork.Sandboxes.FindByIdAsync(id);
            SandboxDtoModel sandboxDto = profile.mapToDto(sandboxEM);
            return sandboxDto;
        }

        public async Task<IEnumerable<SandboxDtoModel>> FindSandBoxesAsync(Expression<Func<SandboxEntityModel, bool>> expression)
        {
            IEnumerable<SandboxEntityModel> sandboxList = await unitOfWork.Sandboxes.FindByConditionAsync(expression);
            
            return profile.mapListToDto(sandboxList);

        }

        public async Task<IEnumerable<SandboxDtoModel>> GetAllSandboxesAsync()
        {
            IEnumerable<SandboxEntityModel> sandboxList = await unitOfWork.Sandboxes.GetAllAsync();
            return profile.mapListToDto(sandboxList);
        }

        public async Task<PagedList<SandboxDtoModel>> GetPagedSandboxesAsync(InputParametrsDtoModel parametrs, FilterParametrsDtoModel filterParametrs)
        {
            PagedList<SandboxEntityModel> sandboxList = await unitOfWork.Sandboxes.GetPagedAsync(
                inputParametrsProfile.MapFromDtoToEntity(parametrs),
                filterParametrsProfile.MapFromDtoToDal(filterParametrs));
            PagedList<SandboxDtoModel> sandboxDtoList = new PagedList<SandboxDtoModel>
            {
                PageList = profile.mapListToDto(sandboxList.PageList),
                TotalPages = sandboxList.TotalPages,
                CurrentPage = sandboxList.CurrentPage
            };

            return sandboxDtoList;
        }

        public void UpdateSandbox(SandboxDtoModel sandboxDto)
        {
                SandboxEntityModel sandbox = profile.mapToEM(sandboxDto);
                unitOfWork.Sandboxes.Update(sandbox);
                unitOfWork.Save();
        }

        public void DeleteSandbox(Guid id)
        {
            unitOfWork.Sandboxes.Delete(id);
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

    }
}
