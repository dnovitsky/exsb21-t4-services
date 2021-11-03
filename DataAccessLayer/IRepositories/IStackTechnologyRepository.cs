﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IStackTechnologyRepository
    {
        Task<IEnumerable<StackTechnologyEntityModel>> GetAllAsync();
        Task<IEnumerable<StackTechnologyEntityModel>> FindByConditionAsync(Expression<Func<StackTechnologyEntityModel, bool>> expression);
        Task<StackTechnologyEntityModel> FindByIdAsync(int id);
        void CreateAsync(StackTechnologyEntityModel item);
        void Update(StackTechnologyEntityModel item);
        void Delete(int id);
    }
}
