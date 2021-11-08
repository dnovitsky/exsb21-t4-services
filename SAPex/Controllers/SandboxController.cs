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
    [Route("api/sandbox")]
    [ApiController]
    public class SandboxController : ControllerBase
    {
        private readonly SandboxService _service;

        // public SandboxController(SandboxService service)
        // {
        //    _service = service;
        // }

        public SandboxController(AppDbContext context)
          : base()
        {
            _service = new SandboxService(new UnitOfWork(context)); // how to do via Startup ?
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            SandboxDtoModel dtoModel = await _service.FindSandboxByIdAsync(id); // on what level goes null check? it should go directly to db?
            SandboxViewModel viewModel = MapFromDtoToView(dtoModel);

            ValidationResult validationResult = new SandboxValidator().Validate(viewModel); // how to convert ValidationResult to IAction?

            return validationResult.IsValid ? await Task.FromResult(Ok(viewModel)) : await Task.FromResult(BadRequest()); // convert to json
        }

        // [HttpGet]
        // public async Task<IActionResult> GetAll()
        // {
        //    IEnumerable<SandboxDtoModel> dtoModels = await _service.GetAllSandboxesAsync(); // on what level goes null check? it should go directly to db?
        //    IEnumerable<SandboxViewModel> viewModels = MapListFromDtoToView(dtoModels);

        // return await Task.FromResult(Ok(viewModels));
        // }

        [HttpGet]
        public async Task<IActionResult> GetByPage(int? page)
        {
            IEnumerable<SandboxDtoModel> dtoModels = await _service.GetAllSandboxesAsync(); // on what level goes null check? it should go directly to db?
            IEnumerable<SandboxViewModel> viewModels = MapListFromDtoToView(dtoModels);

            int pageSize = 2;
            int pageNumber = page ?? 1;

            return await Task.FromResult(Ok(viewModels.ToPagedList(pageNumber, pageSize)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SandboxViewModel requestData)
        {
            SandboxValidator validator = new SandboxValidator();
            ValidationResult validationResult = validator.Validate(requestData); // ? check if requestData already exists, do not push if true

            if (!validationResult.IsValid)
            {
                return await Task.FromResult(BadRequest());
            }

            await _service.AddSandboxAsync(MapFromViewToDto(requestData)); // where is check on already exists

            return await Task.FromResult(Ok()); // need message?
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] SandboxViewModel requestData) // ? id
        {
            SandboxValidator validator = new SandboxValidator();
            ValidationResult validationResult = validator.Validate(requestData); // check if already exists update

            if (!validationResult.IsValid)
            {
                return await Task.FromResult(BadRequest());
            }

            _service.UpdateSandbox(MapFromViewToDto(requestData)); // where goes check on exist

            return await Task.FromResult(Ok());
        }

        // where place it and if in BLL how?
        private SandboxViewModel MapFromDtoToView(SandboxDtoModel sandboxDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxDtoModel, SandboxViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            var mapper = new Mapper(config);

            SandboxViewModel sandbox = mapper.Map<SandboxDtoModel, SandboxViewModel>(sandboxDto);
            return sandbox;
        }

        private IEnumerable<SandboxViewModel> MapListFromDtoToView(IEnumerable<SandboxDtoModel> sandboxesDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxDtoModel, SandboxViewModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            var mapper = new Mapper(config);

            IList<SandboxViewModel> sandboxViewList = new List<SandboxViewModel>()
            {
                mapper.Map<SandboxDtoModel, SandboxViewModel>(sandboxesDto.FirstOrDefault()),
            };

            int i = 0;
            foreach (var sand in sandboxesDto)
            {
                if (i != 0)
                {
                    SandboxViewModel sandbox = mapper.Map<SandboxDtoModel, SandboxViewModel>(sand);
                    sandboxViewList.Add(sandbox);
                }

                i++;
            }

            return sandboxViewList;
        }

        private SandboxDtoModel MapFromViewToDto(SandboxViewModel sandboxView)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SandboxViewModel, SandboxDtoModel>()
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.Name)));

            var mapper = new Mapper(config);

            SandboxDtoModel sandbox = mapper.Map<SandboxViewModel, SandboxDtoModel>(sandboxView);
            return sandbox;
        }

        // what is about delete?
    }
}
