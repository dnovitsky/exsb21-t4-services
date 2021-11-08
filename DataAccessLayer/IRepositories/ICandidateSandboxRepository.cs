﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface ICandidateSandboxRepository
    {
        Task<IEnumerable<CandidateSandboxEntityModel>> GetAllAsync();
        Task<IEnumerable<CandidateSandboxEntityModel>> FindByConditionAsync(Expression<Func<CandidateSandboxEntityModel, bool>> expression);
        Task<CandidateSandboxEntityModel> FindByIdAsync(Guid id);
        void CreateAsync(CandidateSandboxEntityModel item);
        void Update(CandidateSandboxEntityModel item);
        void Delete(int id);
    }
}
