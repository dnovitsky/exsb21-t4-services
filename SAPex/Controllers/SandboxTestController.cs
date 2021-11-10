using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Services;
using DataAccessLayer.Service;
using DbMigrations.Data;
using DbMigrations.EntityModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using SAPex.Models;
using SAPex.Models.Validators;

namespace SAPex.Controllers
{
    [Route("api/sandbox/test")]
    [ApiController]
    public class SandboxTestController : ControllerBase
    {
        private readonly SandboxService _service;

        public SandboxTestController(AppDbContext context)
          : base()
        {
            _service = new SandboxService(new UnitOfWork(context)); // how to do via Startup ?
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            SandboxDtoModel dtoModel = await _service.FindSandboxByIdAsync(id); // on what level goes null check? it should go directly to db?
            SandboxTestViewModel viewModel = MapFromDtoToView(dtoModel);

            ValidationResult validationResult = new SandboxTestValidator().Validate(viewModel); // how to convert ValidationResult to IAction?

            return validationResult.IsValid ? await Task.FromResult(Ok(viewModel)) : await Task.FromResult(BadRequest()); // convert to json
        }

        [HttpGet]
        public async Task<IActionResult> GetByPage(int? page)
        {
            IEnumerable<SandboxDtoModel> dtoModels = await _service.GetAllSandboxesAsync(); // on what level goes null check? it should go directly to db?
            IEnumerable<SandboxTestViewModel> viewModels = MapListFromDtoToView(dtoModels);

            int pageSize = 2;
            int pageNumber = page ?? 1;

            return await Task.FromResult(Ok(viewModels.ToPagedList(pageNumber, pageSize)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SandboxTestViewModel requestData)
        {
            SandboxTestValidator validator = new SandboxTestValidator();
            ValidationResult validationResult = validator.Validate(requestData); // ? check if requestData already exists, do not push if true

            if (!validationResult.IsValid)
            {
                return await Task.FromResult(BadRequest());
            }

            await _service.AddSandboxAsync(MapFromViewToDto(requestData)); // where is check on already exists

            return await Task.FromResult(Ok()); // need message?
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] SandboxTestViewModel requestData) // ? id
        {
            SandboxTestValidator validator = new SandboxTestValidator();
            ValidationResult validationResult = validator.Validate(requestData); // check if already exists update

            if (!validationResult.IsValid)
            {
                return await Task.FromResult(BadRequest());
            }

            _service.UpdateSandbox(MapFromViewToDto(requestData)); // where goes check on exist

            return await Task.FromResult(Ok());
        }

        // where place it and if in BLL how?
        private SandboxTestViewModel MapFromDtoToView(SandboxDtoModel sandboxDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxDtoModel, SandboxTestViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            var mapper = new Mapper(config);

            SandboxTestViewModel sandbox = mapper.Map<SandboxDtoModel, SandboxTestViewModel>(sandboxDto);
            return sandbox;
        }

        private IEnumerable<SandboxTestViewModel> MapListFromDtoToView(IEnumerable<SandboxDtoModel> sandboxesDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxDtoModel, SandboxTestViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            var mapper = new Mapper(config);

            IList<SandboxTestViewModel> sandboxViewList = new List<SandboxTestViewModel>()
            {
                mapper.Map<SandboxDtoModel, SandboxTestViewModel>(sandboxesDto.FirstOrDefault()),
            };

            int i = 0;
            foreach (var sand in sandboxesDto)
            {
                if (i != 0)
                {
                    SandboxTestViewModel sandbox = mapper.Map<SandboxDtoModel, SandboxTestViewModel>(sand);
                    sandboxViewList.Add(sandbox);
                }

                i++;
            }

            return sandboxViewList;
        }

        private SandboxDtoModel MapFromViewToDto(SandboxTestViewModel sandboxView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxTestViewModel, SandboxDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            var mapper = new Mapper(config);

            SandboxDtoModel sandbox = mapper.Map<SandboxTestViewModel, SandboxDtoModel>(sandboxView);
            return sandbox;
        }

        // what is about delete?
    }
}
