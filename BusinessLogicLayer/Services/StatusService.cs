﻿using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class StatusService : IStatusService
    {
        protected readonly StatusProfile profile;
        private readonly IUnitOfWork unitOfWork;

        public StatusService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            profile = new StatusProfile();
        }

        public async Task<StatusDtoModel> FindStatusByIdAsync(Guid id)
        {
            StatusEntityModel statusEM = await unitOfWork.Statuses.FindByIdAsync(id);
            StatusDtoModel statusDto = profile.mapToDto(statusEM);
            return statusDto;
        }

        public async Task<IEnumerable<StatusDtoModel>> GetAllStatusesAsync()
        {
            IEnumerable<StatusEntityModel> statusesEM = await unitOfWork.Statuses.GetAllAsync();
            return profile.mapListToDto(statusesEM);
        }
    }
}
