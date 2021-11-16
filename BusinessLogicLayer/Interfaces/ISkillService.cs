using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Interfaces
{
    public interface ISkillService 
    {
        Task<SkillDtoModel> AddSkillAsync(SkillDtoModel skillDto);
        Task<IEnumerable<SkillDtoModel>> GetAllSkillsAsync();
        Task<IEnumerable<SkillDtoModel>> FindSkillsAsync(Expression<Func<SkillEntityModel, bool>> expression);
        Task<bool> UpdateSkill(SkillDtoModel skillDto);
        Task<SkillDtoModel> FindSkillByIdAsync(Guid id);
        Task DeleteSkill(Guid id);
    }
}
