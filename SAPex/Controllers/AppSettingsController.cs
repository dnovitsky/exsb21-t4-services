using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Service;
using DbMigrations.Data;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SAPex.Mappers;
using SAPex.Models;
using SAPex.Models.Validators;

namespace SAPex.Controllers
{
    [Route("api/appsettings")]
    [ApiController]
    public class AppSettingsController : ControllerBase
    {
        private readonly IAppSettingService _appSettingService;
        private readonly AppSettingMapper _mapper = new AppSettingMapper();

        public AppSettingsController(IAppSettingService service, ITestTaskRouteService testt)
        {
            _appSettingService = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppSettingById(Guid id)
        {
            AppSettingDtoModel appSettingDto = await _appSettingService.FindAppSettingByIdAsync(id);

            if (appSettingDto == null)
            {
                return await Task.FromResult(NotFound());
            }

            return await Task.FromResult(Ok(_mapper.DtoToView(appSettingDto)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppSettings()
        {
            IEnumerable<AppSettingDtoModel> appSettingsDto = await _appSettingService.GetAllAppSettingAsync();
            return await Task.FromResult(Ok(_mapper.ListDtoToListView(appSettingsDto)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
           [FromBody] AppSettingViewModel appSettingViewModel)
        {
            Guid appSettingId = await _appSettingService.AddAppSettingAsync(_mapper.ViewToDto(appSettingViewModel));
            return await Task.FromResult(Ok(appSettingId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AppSettingViewModel appSettingViewModel)
        {
            appSettingViewModel.Id = id;

            _appSettingService.UpdateAppSetting(_mapper.ViewToDto(appSettingViewModel));

            return await Task.FromResult(Ok());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            AppSettingDtoModel appSettingDto = await _appSettingService.FindAppSettingByIdAsync(id);

            if (appSettingDto == null)
            {
                return await Task.FromResult(NotFound());
            }

            _appSettingService.Delete(id);

            return await Task.FromResult(Ok());
        }
    }
}
