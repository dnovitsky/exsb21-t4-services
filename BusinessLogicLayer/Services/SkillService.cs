using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Interfaces;
using System.Linq.Expressions;
using DataAccessLayer.Service;

namespace BusinessLogicLayer.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SkillProfile profile = new SkillProfile();

        public SkillService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<SkillDtoModel> AddSkillAsync(SkillDtoModel skillDto)
        {
            SkillEntityModel skillEM = profile.mapToEM(skillDto);
            await unitOfWork.Skills.CreateAsync(skillEM);
            await unitOfWork.SaveAsync();
            var newSkillDto = profile.mapToDto(skillEM);
            return newSkillDto;
        }

        public async Task DeleteSkill(Guid id)
        {
            unitOfWork.Skills.Delete(id);
            await unitOfWork.SaveAsync();
        }

        public async Task<SkillDtoModel> FindSkillByIdAsync(Guid id)
        {
            SkillEntityModel skillEM = await unitOfWork.Skills.FindByIdAsync(id);
            SkillDtoModel skillDto = profile.mapToDto(skillEM);
            return skillDto;
        }

        public async Task<IEnumerable<SkillDtoModel>> FindSkillsAsync(Expression<Func<SkillEntityModel, bool>> expression)
        {
            IEnumerable<SkillEntityModel> skillsEM = await unitOfWork.Skills.FindByConditionAsync(expression);
            return profile.mapListToDto(skillsEM);
        }

        public async Task<IEnumerable<SkillDtoModel>> GetAllSkillsAsync()
        {
            IEnumerable<SkillEntityModel> skillsEM = await unitOfWork.Skills.GetAllAsync();
            return profile.mapListToDto(skillsEM);
        }

        public async Task<bool> UpdateSkill(SkillDtoModel skillDto)
        {
            try
            {
                SkillEntityModel skillEM = profile.mapToEM(skillDto);
                unitOfWork.Skills.Update(skillEM);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
