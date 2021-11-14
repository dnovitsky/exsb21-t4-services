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
using AutoMapper;
using DataAccessLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.Services
{
    public class SandboxStackTechnologyService : ISandboxStackTechnologyService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SandboxStackTechnologyProfile profile = new();

        public SandboxStackTechnologyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddSandboxStackTechnologyAsync(SandboxStackTechnologyDtoModel sandboxStackTechnologyDto)
        {
            try
            {
                SandboxStackTechnologyEntityModel sandboxStackTechnologyEM = profile.mapToEM(sandboxStackTechnologyDto);
                await unitOfWork.SandboxStackTechnologies.CreateAsync(sandboxStackTechnologyEM);
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
