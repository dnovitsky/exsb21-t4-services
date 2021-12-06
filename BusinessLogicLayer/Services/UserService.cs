﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Service;
using DbMigrations.EntityModels;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserProfile profile = new UserProfile();

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserDtoModel> FindByIdAsync(Guid id)
        {
            try
            {
                UserEntityModel user = await unitOfWork.Users.FindByIdAsync(id);
                return profile.mapToDto(user);
            }
            catch
            {
                return null;
            }
        }

        public async Task<UserDtoModel> FindByIdConditionAsync(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression)
        {
            try
            {
                IEnumerable<UserFunctionalRoleEntityModel> interviewersId = await unitOfWork.UserFunctionalRoles.FindByConditionAsync(expression);
                UserEntityModel user = await unitOfWork.Users.FindByIdAsync(interviewersId.First().UserId);
                return profile.mapToDto(user);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserDtoModel>> FindAllByConditionAsync(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression)
        {

            IEnumerable<UserFunctionalRoleEntityModel> interviewersId = await unitOfWork.UserFunctionalRoles.FindByConditionAsync(expression);

            IList<UserEntityModel> userInterviewers = new List<UserEntityModel>();

            foreach (var interviewer in interviewersId)
            {
                UserEntityModel user = await unitOfWork.Users.FindByIdAsync(interviewer.UserId);
                userInterviewers.Add(user);
            }
            return profile.mapListToDto(userInterviewers);
        }

        public async Task<IEnumerable<UserDtoModel>> FindUsersAsync(Expression<Func<UserEntityModel, bool>> expression)
        {
            IEnumerable<UserEntityModel> userEM = await unitOfWork.Users.FindByConditionAsync(expression);
            return profile.mapListToDto(userEM);
        }

        public async Task<IEnumerable<UserDtoModel>> GetUsersBySandboxIdConditionFuncRole(Expression<Func<UserFunctionalRoleEntityModel, bool>> expression, Guid sandboxId)
        {

            IEnumerable<UserFunctionalRoleEntityModel> userFunctionalRoleListByCondition = await unitOfWork.UserFunctionalRoles.FindByConditionAsync(expression);
            IEnumerable<UserSandBoxEntityModel> userSandboxListBySandboxId = await unitOfWork.UserSandBoxes.FindByConditionAsync(x => x.SandBoxId == sandboxId);

            IList<UserEntityModel> usersByConditionBySandboxId = new List<UserEntityModel>();

            foreach ( var item in userSandboxListBySandboxId)
            {
                UserFunctionalRoleEntityModel UserFunctionalRole = userFunctionalRoleListByCondition.SingleOrDefault(x => x.UserId == item.UserId);
                if (UserFunctionalRole != null)
                {
                    UserEntityModel userEntity = await unitOfWork.Users.FindByIdAsync(UserFunctionalRole.UserId);
                    usersByConditionBySandboxId.Add(userEntity);
                }
            }

            return profile.mapListToDto(usersByConditionBySandboxId);
        }

        public async Task<IEnumerable<UserDtoModel>> FindByUserCandidateSandboxConditionAsync(
            Expression<Func<UserCandidateSandboxEntityModel, bool>> expression,
            string userFunctionalRoleName)
        {

            IEnumerable<UserCandidateSandboxEntityModel> usersCandidateSandbox = await unitOfWork.UserCandidateSandboxes.FindByConditionAsync(expression);
            IList<UserEntityModel> users = new List<UserEntityModel>();

            foreach (var item in usersCandidateSandbox)
            {
                IEnumerable<UserFunctionalRoleEntityModel> userFunctionalRoles = await unitOfWork.UserFunctionalRoles.FindByConditionAsync(x => x.UserId == item.UserId);

                if( userFunctionalRoles != null)
                {
                    UserFunctionalRoleEntityModel userFuncRole = userFunctionalRoles.Where(x => x.FunctionalRole.Name == userFunctionalRoleName).FirstOrDefault();
                    if (userFuncRole != null)
                    {
                        UserEntityModel user = await unitOfWork.Users.FindByIdAsync(item.UserId);
                        users.Add(user);
                    }
                }
                
            }

            return profile.mapListToDto(users);
        }
    }
}
