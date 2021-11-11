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
    public class StackTechnologyService : IStackTechnologyService
    {
        protected readonly StackTechnologyProfile profile;
        private readonly IUnitOfWork unitOfWork;

        public StackTechnologyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            profile = new StackTechnologyProfile();
        }

        public async Task<bool> AddStackTechnologyAsync(StackTechnologyDtoModel StackTechnologyDto)
        {
            try
            {
                StackTechnologyEntityModel StackTechnologyEM = profile.mapToEM(StackTechnologyDto);
                await Task.Run(() => unitOfWork.StackTechnologies.CreateAsync(StackTechnologyEM));
                unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DeleteStackTechnology(Guid id)
        {
            unitOfWork.StackTechnologies.Delete(id);
        }

        public async Task<StackTechnologyDtoModel> FindStackTechnologyByIdAsync(Guid id)
        {
            StackTechnologyEntityModel StackTechnologyEM = await unitOfWork.StackTechnologies.FindByIdAsync(id);
            StackTechnologyDtoModel StackTechnologyDto = profile.mapToDto(StackTechnologyEM);
            return StackTechnologyDto;
        }

        public async Task<IEnumerable<StackTechnologyDtoModel>> FindStackTechnologiesAsync(Expression<Func<StackTechnologyEntityModel, bool>> expression)
        {
            IEnumerable<StackTechnologyEntityModel> StackTechnologiesEM = await unitOfWork.StackTechnologies.FindByConditionAsync(expression);
            return profile.mapListToDto(StackTechnologiesEM);
        }

        public async Task<IEnumerable<StackTechnologyDtoModel>> GetAllStackTechnologiesAsync()
        {
            IEnumerable<StackTechnologyEntityModel> StackTechnologiesEM = await Task.Run(() => unitOfWork.StackTechnologies.GetAllAsync());
            return profile.mapListToDto(StackTechnologiesEM);
        }

        public void UpdateStackTechnology(StackTechnologyDtoModel StackTechnologyDto)
        {
            StackTechnologyEntityModel StackTechnologyEM = profile.mapToEM(StackTechnologyDto);
            unitOfWork.StackTechnologies.Update(StackTechnologyEM);
            unitOfWork.SaveAsync();
        }

        public void Dispose()
        {

        }
    }
}
