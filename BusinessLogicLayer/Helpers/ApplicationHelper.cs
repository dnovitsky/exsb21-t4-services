using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Helpers
{
    public class ApplicationHelper
    {
        private IUnitOfWork _unitOfWork;
        public ApplicationHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateDataAsync()
        {
            FunctionalRoleEntityModel functionalRole = new FunctionalRoleEntityModel
            {
                Name = "Manager"
            };

            await Task.Run(()=> _unitOfWork.FunctionalRoles.CreateAsync(functionalRole));
            await Task.Run(()=>_unitOfWork.SaveAsync());

            UserEntityModel user = new UserEntityModel
            {
                Name="Manager",
                Surname="Education",
                Email="manager@gmail.com",
                Password="manager123456",
                Skype="Skype",
                Phone="998877445566",
                Location="Minsk"
               
            };

            await Task.Run(() => _unitOfWork.Users.CreateAsync(user));
            await Task.Run(() => _unitOfWork.SaveAsync());
            return true;
        }

        public bool DeleteData()
        {
            return true;
        }


    }
}
