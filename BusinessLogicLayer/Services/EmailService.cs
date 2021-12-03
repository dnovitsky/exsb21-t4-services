using System;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Service;

namespace BusinessLogicLayer.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
}
