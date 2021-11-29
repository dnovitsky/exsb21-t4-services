using DbMigrations.EntityModels;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Service;
using BusinessLogicLayer.DtoModels;
using System.Linq;
using Moq;
using SAPex.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Xunit;
using DataAccessLayer.IRepositories;

namespace BusinessLogicLayer.Tests
{
    public class SkillServiceTests
    {
        //Check GetAllSkillsAsync
        [Fact]
        public async Task IsGetAllSkillsAsyncReturnsEverything()
        {
            //Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(uow => uow.Skills.GetAllAsync()).Returns(GetTestSkills());
            ISkillService service = new SkillService(mock.Object);

            //Act
            var result = await service.GetAllSkillsAsync();

            // Assert
            var viewResult = Assert.IsType<List<SkillDtoModel>>(result);
            var model = Assert.IsAssignableFrom<List<SkillDtoModel>>(
                viewResult.AsEnumerable());
            Assert.Equal(4, model.Count());
        }

        //Check FindSkillByIdAsync
        [Fact]
        public async Task IsFindSkillByIdAsyncReturnsCurrentSkill()
        {
            //Arrange
            var list = await GetTestSkills();
            SkillEntityModel expectedSkill = list.ToList().FirstOrDefault();
            var asd = Task.Run(() => list.AsEnumerable().FirstOrDefault());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(uow  => uow.Skills.FindByIdAsync(expectedSkill.Id)).Returns(asd);
            ISkillService service = new SkillService(mock.Object);


            //Act
            var result = await service.FindSkillByIdAsync(expectedSkill.Id);

            // Assert
            var viewResult = Assert.IsType<SkillDtoModel>(result);
            var model = Assert.IsAssignableFrom<SkillDtoModel>(
                viewResult);
            Assert.Equal(expectedSkill.Name, model.Name);
            Assert.Equal(expectedSkill.Id, model.Id);
        }

        //Check FindSkillByIdAsync
        [Fact]
        public async Task IsFindSkillByConditionAsyncReturnsCurrentSkill()
        {
            //Arrange
            var list = await GetTestSkills();
            string expectedName = "SQL";
            List<SkillEntityModel> expectedSkills = new List<SkillEntityModel>();
            expectedSkills.Add(list.ToList().FirstOrDefault());
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(uow => uow.Skills.FindByConditionAsync(e=>e.Name == expectedName)).Returns(Task.Run(()=>expectedSkills as IEnumerable<SkillEntityModel>));
            ISkillService service = new SkillService(mock.Object);


            //Act
            var result = await service.FindSkillsAsync(e=>e.Name == expectedName);

            // Assert
            var viewResult = Assert.IsType<List<SkillDtoModel>>(result);
            var model = Assert.IsAssignableFrom<List<SkillDtoModel>>(
                viewResult);
            Assert.Equal(1, model.Count());
            Assert.Equal(expectedName, model.FirstOrDefault().Name);
        }

        //Check AddSkillAsync
        [Fact]
        public async Task IsAddSkillAsyncReturnsModelAndAddsSkill()
        {
            //Arrange
            var mock = new Mock<IUnitOfWork>();
            Guid id = Guid.NewGuid();
            var skillEM = new SkillEntityModel()
            {
                Id = id,
                Name = "JS.React"
            };
            var skillDto = new SkillDtoModel()
            {
                Id = id,
                Name = "JS.React"
            };
            mock.Setup(uow => uow.Skills.CreateAsync(skillEM));
            ISkillService service = new SkillService(mock.Object);

            //Act
            var result = await service.AddSkillAsync(skillDto);

            // Assert
            var viewResult = Assert.IsType<SkillDtoModel>(result);
            var model = Assert.IsAssignableFrom<SkillDtoModel>(viewResult);
            Assert.NotNull(model.Name);
            Assert.Equal(skillDto.Id, model.Id);
        }

        //Check UpdateSkill
        [Fact]
        public async Task IsUpdateSkillReturnsNewModel()
        {
            //Arrange
            var mock = new Mock<IUnitOfWork>();
            var list = await GetTestSkills();
            var skill = list.ToList().FirstOrDefault();
            var previousName = skill.Name;
            skill.Name = "UnitTest";
            var skillDto = new SkillDtoModel()
            {
                Id = skill.Id,
                Name = skill.Name
            };
            mock.Setup(uow => uow.Skills.Update(skill));
            ISkillService service = new SkillService(mock.Object);

            //Act
            var result = await service.AddSkillAsync(skillDto);

            // Assert
            var viewResult = Assert.IsType<SkillDtoModel>(result);
            var model = Assert.IsAssignableFrom<SkillDtoModel>(viewResult);
            Assert.NotNull(model.Name);
            Assert.NotEqual(model.Name, previousName);
        }


        //Check DeleteSkill
        [Fact]
        public async Task IsDeleteSkillRemovesModel()
        {
            //Arrange
            var mock = new Mock<IUnitOfWork>();
            var list = await GetTestSkills();
            var skill = list.ToList().FirstOrDefault();
            var id = skill.Id;
            mock.Setup(uow => uow.Skills.Delete(id));
            ISkillService service = new SkillService(mock.Object);

            //Act
            var result = await service.DeleteSkill(id);

            // Assert
            var viewResult = Assert.IsType<bool>(result);
            var model = Assert.IsAssignableFrom<bool>(viewResult);
            Assert.True(model);
        }

        private async Task<IEnumerable<SkillEntityModel>> GetTestSkills()
        {
            var skills = new List<SkillEntityModel>
            {
                new SkillEntityModel { Id=Guid.NewGuid(), Name="SQL"},
                new SkillEntityModel { Id=Guid.NewGuid(), Name="EF"},
                new SkillEntityModel { Id=Guid.NewGuid(), Name="BLL"},
                new SkillEntityModel { Id=Guid.NewGuid(), Name=".net"},
            };

            return skills;
        }
    }
}
