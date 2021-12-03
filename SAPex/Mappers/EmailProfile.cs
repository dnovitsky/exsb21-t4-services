using System;
using AutoMapper;
using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using SAPex.Models;

namespace SAPex.Mappers
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<EmailEntityModel, EmailDtoModel>();
            CreateMap<EmailDtoModel, EmailEntityModel>();

            CreateMap<EmailViewModel, EmailDtoModel>();
            CreateMap<EmailDtoModel, EmailViewModel>();
        }
    }
}
