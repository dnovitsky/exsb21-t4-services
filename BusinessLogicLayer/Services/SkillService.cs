﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Interfaces;
using System.Linq.Expressions;
using AutoMapper;
using DataAccessLayer.Service;

namespace BusinessLogicLayer.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SkillProfile profile;

        public SkillService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> AddSkillAsync(SkillDtoModel skillDto)
        {
            try
            {
                SkillEntityModel skillEM = profile.mapToEM(skillDto);
                await Task.Run(() => unitOfWork.Skills.CreateAsync(skillEM));
                unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DeleteSkill(int id)
        {
            unitOfWork.Skills.Delete(id);
        }

        public async Task<SkillDtoModel> FindSkillByIdAsync(int id)
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
            IEnumerable<SkillEntityModel> skillsEM = await Task.Run(() => unitOfWork.Skills.GetAllAsync());
            return profile.mapListToDto(skillsEM);
        }

        public void UpdateSkill(SkillDtoModel skillDto)
        {
            SkillEntityModel skillEM = profile.mapToEM(skillDto);
            unitOfWork.Skills.Update(skillEM);
            unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}