﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbMigrations.EntityModels;

namespace DataAccessLayer.IRepositories
{
    public interface IAvailabilityTypeRepository
    {
        Task<IEnumerable<AvailabilityTypeEntityModel>> GetAllAsync();
        Task<IEnumerable<AvailabilityTypeEntityModel>> FindByConditionAsync(Expression<Func<AvailabilityTypeEntityModel, bool>> expression);
        Task<AvailabilityTypeEntityModel> FindByIdAsync(Guid id);
        void CreateAsync(AvailabilityTypeEntityModel item);
        void Update(AvailabilityTypeEntityModel item);
        void Delete(Guid id);
    }
}
