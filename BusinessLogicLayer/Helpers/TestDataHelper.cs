using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DbMigrations.Data;
using DbMigrations.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class TestDataHelper
    {
        public static void InitTestData(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (AppDbContext db = new AppDbContext(options))
            {

                Guid SandboxId1 = Guid.NewGuid();
                Guid SandboxId2 = Guid.Parse("F158D307-DAB4-44E4-A148-B4E3D94B8447");
                Guid SandboxId3 = Guid.NewGuid();
                Guid SandboxId4 = Guid.NewGuid();
                Guid SandboxId5 = Guid.NewGuid();
                Guid SandboxId6 = Guid.NewGuid();
                Guid SandboxId7 = Guid.NewGuid();
                Guid SandboxId9 = Guid.NewGuid();
                Guid SandboxId10 = Guid.NewGuid();
                Guid SandboxId11= Guid.NewGuid();
                Guid SandboxId12 = Guid.NewGuid();
                Guid SandboxId13 = Guid.NewGuid();
                Guid SandboxId14 = Guid.NewGuid();
                Guid SandboxId15 = Guid.NewGuid();
                Guid SandboxId16 = Guid.NewGuid();
                Guid SandboxId17 = Guid.NewGuid();
                Guid SandboxId18 = Guid.NewGuid();
                Guid SandboxId19 = Guid.NewGuid();
                Guid SandboxId20 = Guid.NewGuid();
                Guid SandboxId21 = Guid.NewGuid();

                Guid LanguageId1 = Guid.Parse("4019D15B-37AD-4ABF-B5B3-2A57318608FE");
                Guid LanguageId2 = Guid.NewGuid();
                Guid LanguageId3 = Guid.Parse("D1A3C67B-DB05-4646-A9FE-9243DBD79489");
                Guid LanguageId4 = Guid.NewGuid();
                Guid LanguageId5 = Guid.NewGuid();

                Guid StackTechnologyId1 = Guid.NewGuid();
                Guid StackTechnologyId2 = Guid.NewGuid();
                Guid StackTechnologyId3 = Guid.Parse("D1D4E77B-B6D5-4B4D-9645-535C8B246189");
                Guid StackTechnologyId4 = Guid.NewGuid();
                Guid StackTechnologyId5 = Guid.NewGuid();

                Guid UserId1 = Guid.NewGuid();
                Guid UserId2 = Guid.NewGuid();
                Guid UserId3 = Guid.NewGuid();
                Guid UserId4 = Guid.NewGuid();
                Guid UserId5 = Guid.NewGuid();
                Guid UserId6 = Guid.NewGuid();
                Guid UserId7 = Guid.NewGuid();
                Guid UserId8 = Guid.NewGuid();
                Guid UserId9 = Guid.NewGuid();
                Guid UserId10 = Guid.NewGuid();
                Guid UserId11 = Guid.NewGuid();
                Guid UserId12 = Guid.NewGuid();
                Guid UserId13 = Guid.NewGuid();
                Guid UserId14 = Guid.NewGuid();
                Guid UserId15 = Guid.NewGuid();

                Guid languageLevelGuid1 = Guid.NewGuid();
                Guid languageLevelGuid2 = Guid.NewGuid();
                Guid languageLevelGuid3 = Guid.NewGuid();
                Guid languageLevelGuid4 = Guid.NewGuid();

                Guid skillGuid1 = Guid.NewGuid();
                Guid skillGuid2 = Guid.NewGuid();
                Guid skillGuid3 = Guid.NewGuid();

                Guid statusGuid1 = Guid.NewGuid();
                Guid statusGuid2 = Guid.NewGuid();
                Guid statusGuid3 = Guid.NewGuid();

                Guid availabilityType1 = Guid.NewGuid();
                Guid availabilityType2 = Guid.NewGuid();
                Guid availabilityType3 = Guid.Parse("276E9243-454C-48A0-A5D1-53558F0F80D0");

                Guid UserFunctionalRoleId1 = Guid.NewGuid();

                var locationId1 = Guid.NewGuid();
                var locationId2 = Guid.NewGuid();
                var locationId3 = Guid.NewGuid();
                var locationId4 = Guid.NewGuid();
                var locationId5 = Guid.NewGuid();
                var locationId6 = Guid.NewGuid();

                if (!db.Locations.Any())
                {
                    db.Locations.Add(new LocationEntityModel
                    {
                        Id = locationId1,
                        Name = "Minsk"
                    });
                    db.Locations.Add(new LocationEntityModel
                    {
                        Id = locationId2,
                        Name = "Gomel"
                    });
                    db.Locations.Add(new LocationEntityModel
                    {
                        Id = locationId3,
                        Name = "Brest"
                    });
                    db.Locations.Add(new LocationEntityModel
                    {
                        Id = locationId4,
                        Name = "Moscow"
                    });
                    db.Locations.Add(new LocationEntityModel
                    {
                        Id = locationId5,
                        Name = "Warsaw"
                    });
                    db.Locations.Add(new LocationEntityModel
                    {
                        Id = locationId6,
                        Name = "Kiev"
                    });
                    db.SaveChanges();
                }

                if (!db.Sandboxes.Any())
                {
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId1,
                        Name = ".Net & JS",
                        MaxCandidates = 60,
                        Description = "Two-month internship for aspiring students",
                        CreateDate = new DateTime(2021, 9, 1),
                        StartDate = new DateTime(2021, 10, 20),
                        EndDate = new DateTime(2021, 12, 10),
                        StartRegistration = new DateTime(2021, 10, 2),
                        EndRegistration = new DateTime(2021, 10, 18),
                        Status = StatusName.Active,
                    });;
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId2,
                        Name = "Python",
                        MaxCandidates = 22,
                        Description = "Junior python developers are welcome to take part in exadel trainee",
                        CreateDate = new DateTime(2021, 11, 1),
                        StartDate = new DateTime(2022, 1, 3),
                        EndDate = new DateTime(2022, 1, 30),
                        StartRegistration = new DateTime(2021, 12, 1),
                        EndRegistration = new DateTime(2021, 12, 28),
                        Status = StatusName.Active,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId3,
                        Name = "PHP",
                        MaxCandidates = 33,
                        Description = "PHP is a general - purpose scripting language especially suited to web development." +
                        "It was originally created by Danish - Canadian programmer Rasmus Lerdorf in 1994." +
                        "The PHP reference implementation is now produced by The PHP Group. ",
                        CreateDate = new DateTime(2021, 10, 1),
                        StartDate = new DateTime(2021, 12, 2),
                        EndDate = new DateTime(2021, 12, 30),
                        StartRegistration = new DateTime(2021, 11, 16),
                        EndRegistration = new DateTime(2021, 11, 25),
                        Status = StatusName.Active,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId4,
                        Name = "C++",
                        MaxCandidates = 45,
                        Description = "description C++",
                        CreateDate = new DateTime(2021, 5, 1),
                        StartDate = new DateTime(2021, 12, 6),
                        EndDate = new DateTime(2021, 12, 30),
                        StartRegistration = new DateTime(2021, 11, 4),
                        EndRegistration = new DateTime(2021, 11, 7),
                        Status = StatusName.Active,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId5,
                        Name = "QA",
                        MaxCandidates = 56,
                        Description = "description QA",
                        CreateDate = new DateTime(2021, 5, 1),
                        StartDate = new DateTime(2021, 11, 16),
                        EndDate = new DateTime(2021, 11, 30),
                        StartRegistration = new DateTime(2021, 10, 10),
                        EndRegistration = new DateTime(2021, 10, 15),
                        Status = StatusName.Active,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId6,
                        Name = "BA",
                        MaxCandidates = 62,
                        Description = "description BA",
                        CreateDate = new DateTime(2021, 6, 1),
                        StartDate = new DateTime(2021, 7, 2),
                        EndDate = new DateTime(2021, 7, 3),
                        StartRegistration = new DateTime(2021, 6, 4),
                        EndRegistration = new DateTime(2021, 6, 5),
                        Status = StatusName.Active,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId7,
                        Name = "Manager",
                        MaxCandidates = 77,
                        Description = "description Manager",
                        CreateDate = new DateTime(2021, 7, 1),
                        StartDate = new DateTime(2021, 7, 2),
                        EndDate = new DateTime(2021, 7, 3),
                        StartRegistration = new DateTime(2021, 7, 4),
                        EndRegistration = new DateTime(2021, 7, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId9,
                        Name = "Basic QA",
                        MaxCandidates = 81,
                        Description = "For candidates without work experience",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId10,
                        Name = "JS & Java Sandbox",
                        MaxCandidates = 81,
                        Description = "Backend, Frontend, FullStack",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId11,
                        Name = "Pascal",
                        MaxCandidates = 81,
                        Description = "Pascal is an imperative and procedural programming language, " +
                        "designed by Niklaus Wirth as a small, " +
                        "efficient language intended to encourage good programming practices",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId12,
                        Name = ".Net",
                        MaxCandidates = 81,
                        Description = "Only Backend",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId13,
                        Name = "HR trainee",
                        MaxCandidates = 81,
                        Description = "Improve your soft skills",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId14,
                        Name = "Angular + Js",
                        MaxCandidates = 81,
                        Description = "Busy work schedule",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId15,
                        Name = "Javascript Basics",
                        MaxCandidates = 81,
                        Description = "Only students",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId16,
                        Name = "BA + QA",
                        MaxCandidates = 81,
                        Description = "",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId17,
                        Name = "GO",
                        MaxCandidates = 81,
                        Description = "",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId18,
                        Name = "Assembler",
                        MaxCandidates = 81,
                        Description = "",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId19,
                        Name = "HR & BA & Ruby",
                        MaxCandidates = 81,
                        Description = "description",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId20,
                        Name = "C++",
                        MaxCandidates = 81,
                        Description = "For begginers",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = SandboxId21,
                        Name = "Java",
                        MaxCandidates = 81,
                        Description = "8 month trainee",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                    db.SaveChanges();
                }

                if (!db.AvailabilityTypes.Any())
                {
                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = availabilityType1,
                        Name = "Less than 4 hours",
                        OrderLevel = 0,
                    });

                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = availabilityType2,
                        Name = "4-6 hours",
                        OrderLevel = 1,
                    });

                    db.AvailabilityTypes.Add(new AvailabilityTypeEntityModel
                    {
                        Id = availabilityType3,
                        Name = "6-infinity hours",
                        OrderLevel = 2,
                    });
                    db.SaveChanges();
                }

                if (!db.LanguageLevels.Any())
                {
                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = languageLevelGuid1,
                        Name = "Beginner (A1)",
                        OrderLevel = 0,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = languageLevelGuid2,
                        Name = "Elementary (A2)",
                        OrderLevel = 1,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.Parse("B43BE624-15E2-4ED6-88A0-9E52DDF86C6B"),
                        Name = "Intermediate (B1)",
                        OrderLevel = 2,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = languageLevelGuid3,
                        Name = "Upper-Intermediate (B2)",
                        OrderLevel = 3,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = languageLevelGuid4,
                        Name = "Advanced (C1)",
                        OrderLevel = 4,
                    });

                    db.LanguageLevels.Add(new LanguageLevelEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Proficient (C2)",
                        OrderLevel = 5,
                    });
                    db.SaveChanges();
                }

                if (!db.Languages.Any())
                {
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = LanguageId1,
                        Name = "English"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = LanguageId2,
                        Name = "Russian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = LanguageId3,
                        Name = "Georgian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = LanguageId4,
                        Name = "Latvian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = LanguageId5,
                        Name = "Polish"
                    });
                    db.SaveChanges();
                }

                if (!db.StackTechnologies.Any())
                {
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = StackTechnologyId1,
                        Name = ".Net"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = StackTechnologyId2,
                        Name = "JS"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = StackTechnologyId3,
                        Name = "Java"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = StackTechnologyId4,
                        Name = "Devops"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = StackTechnologyId5,
                        Name = "Python"
                    });
                    db.SaveChanges();
                }

                if (!db.Statuses.Any())
                {
                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId1,
                        Name = "Jonh",
                        Surname = "Connor",
                        Email = "JohnConnor@gmail.com",
                        Password = "123456",
                        LocationId = locationId1,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId2,
                        Name = "Korben",
                        Surname = "Dallas",
                        Email = "Korben@gmail.com",
                        Password = "123456",
                        LocationId = locationId2,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId3,
                        Name = "Forrest",
                        Surname = "Gump",
                        Email = "Forrest@gmail.com",
                        Password = "123456",
                        LocationId = locationId3,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId4,
                        Name = "Jeffrey",
                        Surname = "Lebowski",
                        Email = "Jeffrey@gmail.com",
                        Password = "123456",
                        LocationId = locationId4,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId5,
                        Name = "Elen",
                        Surname = "Ripley",
                        Email = "Elen@gmail.com",
                        Password = "123456",
                        LocationId = locationId5,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId6,
                        Name = "John",
                        Surname = "Mclaughlin",
                        Email = "JohnMc@gmail.com",
                        Password = "123456",
                        LocationId = locationId6,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId7,
                        Name = "Tyler",
                        Surname = "Durden",
                        Email = "Tyler@gmail.com",
                        Password = "123456",
                        LocationId = locationId1,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId8,
                        Name = "Harry",
                        Surname = "Potter",
                        Email = "Harry@gmail.com",
                        Password = "123456",
                        LocationId = locationId2,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });

                    db.Users.Add(new UserEntityModel
                    {
                        Id = UserId9,
                        Name = "James",
                        Surname = "Bond",
                        Email = "James@gmail.com",
                        Password = "123456",
                        LocationId = locationId3,
                        Phone = "+998998756090",
                        Skype = "Skype:username"
                    });
                }
                db.SaveChanges();

                if (!db.SandboxStackTechnologies.Any())
                {
                    db.SandboxStackTechnologies.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId1,
                        StackTechnologyId = StackTechnologyId1
                    });

                    db.SandboxStackTechnologies.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId1,
                        StackTechnologyId = StackTechnologyId2
                    });

                    db.SandboxStackTechnologies.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId2,
                        StackTechnologyId = StackTechnologyId2
                    });

                    db.SandboxStackTechnologies.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId2,
                        StackTechnologyId = StackTechnologyId3
                    });

                    db.SandboxStackTechnologies.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId3,
                        StackTechnologyId = StackTechnologyId4
                    });
                    db.SaveChanges();

                }

                if (!db.SandboxLanguages.Any())
                {
                    db.SandboxLanguages.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId1,
                        LanguageId = LanguageId1
                    });

                    db.SandboxLanguages.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId1,
                        LanguageId = LanguageId2
                    });

                    db.SandboxLanguages.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId2,
                        LanguageId = LanguageId1
                    });

                    db.SandboxLanguages.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId2,
                        LanguageId = LanguageId3
                    });

                    db.SandboxLanguages.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId3,
                        LanguageId = LanguageId1
                    });

                    db.SandboxLanguages.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = SandboxId3,
                        LanguageId = LanguageId4
                    });
                }
                db.SaveChanges();

                if (!db.UserSandBoxes.Any())
                {
                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId1,
                        SandBoxId = SandboxId1,
                    });

                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId2,
                        SandBoxId = SandboxId1,
                    });

                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId3,
                        SandBoxId = SandboxId1,
                    });

                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId4,
                        SandBoxId = SandboxId1,
                    });

                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId5,
                        SandBoxId = SandboxId2,
                    });

                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId6,
                        SandBoxId = SandboxId2,
                    });

                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId7,
                        SandBoxId = SandboxId2,
                    });

                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId8,
                        SandBoxId = SandboxId3,
                    });

                    db.UserSandBoxes.Add(new UserSandBoxEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId9,
                        SandBoxId = SandboxId3,
                    });
                }
                db.SaveChanges();

                if (!db.Statuses.Any())
                {
                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = UserFunctionalRoleId1,
                        UserId = UserId1,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Mentor").FirstOrDefault().Id,
                    });

                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId2,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Interviewer").FirstOrDefault().Id,
                    });

                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId3,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Recruiter").FirstOrDefault().Id,
                    });

                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId4,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Mentor").FirstOrDefault().Id,
                    });

                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId5,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Interviewer").FirstOrDefault().Id,
                    });

                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId6,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Recruiter").FirstOrDefault().Id,
                    });

                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId7,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Mentor").FirstOrDefault().Id,
                    });

                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId8,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Interviewer").FirstOrDefault().Id,
                    });

                    db.UserFunctionalRoles.Add(new UserFunctionalRoleEntityModel
                    {
                        Id = new Guid(),
                        UserId = UserId9,
                        FunctionalRoleId = db.FunctionalRoles.Where(x => x.Name == "Recruiter").FirstOrDefault().Id,
                    });
                    db.SaveChanges();
                }

                if (!db.Statuses.Any())
                {
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = statusGuid1,
                        Name = "Draft"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rejected"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.Parse("406E7A53-C5EA-4F25-99A5-0EA3F25AF0BC"),
                        Name = "Need verification"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = statusGuid2,
                        Name = "Need a recruiter"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Interview Soft"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Interview Tech"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = statusGuid3,
                        Name = "Approved"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Questionable"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sandbox"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Final interview"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Enroll in the internship"
                    });
                    db.Statuses.Add(new StatusEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Recruit"
                    });
                    db.SaveChanges();
                }

                if (!db.Skills.Any())
                {
                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Angular"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Angular JS"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "React"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "CSS"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = skillGuid1,
                        Name = "JavaScript"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "TypeScript"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = skillGuid2,
                        Name = "GitHub"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = ".NET 5+"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = skillGuid3,
                        Name = ".NET Core"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "ASP.net"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Entity Framework"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "C#"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "MSSQL"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Docker"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Git"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "GitHub"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Visual Studio"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Visual Code"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "AWS"
                    });

                    db.Skills.Add(new SkillEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Azure"
                    });
                    db.SaveChanges();
                }
                
                var candidateLangId1 = Guid.NewGuid();
                var candidateLangId2 = Guid.NewGuid();
                var candidateLangId3 = Guid.NewGuid();

                var candidateId1 = Guid.NewGuid();
                var candidateId2 = Guid.NewGuid();
                var candidateId3 = Guid.NewGuid();

                var candidateTechSkillId1 = Guid.NewGuid();
                var candidateTechSkillId2 = Guid.NewGuid();
                var candidateTechSkillId3 = Guid.NewGuid();

                var candidateProcessId1 = Guid.NewGuid();
                var candidateProcessId2 = Guid.NewGuid();
                var candidateProcessId3 = Guid.NewGuid();

                var candidateSandboxId1 = Guid.NewGuid();
                var candidateSandboxId2 = Guid.NewGuid();
                var candidateSandboxId3 = Guid.NewGuid();

                if (!db.Candidates.Any())
                {
                    db.Candidates.Add(new CandidateEntityModel
                    {
                        Id = candidateId1,
                        Name = "Tom",
                        Surname = "Tomison",
                        Email = "Tom@tomomo.com",
                        LocationId = locationId3,
                        Skype = "skypeTom",
                        Phone = "+375441234567",
                        ProfessionaCertificates = "",
                        AdditionalSkills = ""
                    });
                    db.Candidates.Add(new CandidateEntityModel
                    {
                        Id = candidateId2,
                        Name = "Jim",
                        Surname = "Jimimison",
                        Email = "Jim@tomomo.com",
                        LocationId = locationId2,
                        Skype = "skypeTom",
                        Phone = "+375331234567",
                        ProfessionaCertificates = "",
                        AdditionalSkills = ""
                    });
                    db.Candidates.Add(new CandidateEntityModel
                    {
                        Id = candidateId3,
                        Name = "Goga",
                        Surname = "Gogison",
                        Email = "Goga@tomomo.com",
                        LocationId = locationId5,
                        Skype = "skypeTom",
                        Phone = "+375291234567",
                        ProfessionaCertificates = "",
                        AdditionalSkills = ""
                    });
                    db.SaveChanges();
                }

                if (!db.CandidateLanguages.Any())
                {
                    db.CandidateLanguages.Add(new CandidateLanguageEntityModel
                    {
                        Id = candidateLangId1,
                        CandidateId = candidateId1,
                        LanguageId = LanguageId1,
                        LanguageLevelId = languageLevelGuid2
                    });
                    db.CandidateLanguages.Add(new CandidateLanguageEntityModel
                    {
                        Id = candidateLangId2,
                        LanguageId = LanguageId3,
                        CandidateId = candidateId2,
                        LanguageLevelId = languageLevelGuid1
                    });
                    db.CandidateLanguages.Add(new CandidateLanguageEntityModel
                    {
                        Id = candidateLangId3,
                        LanguageId = LanguageId4,
                        CandidateId = candidateId3,
                        LanguageLevelId = languageLevelGuid3
                    });
                    db.SaveChanges();
                }

                if (!db.CandidateTechSkills.Any())
                {
                    db.CandidateTechSkills.Add(new CandidateTechSkillEntityModel
                    {
                        Id = candidateTechSkillId1,
                        SkillId = skillGuid1,
                        CandidateId = candidateId1,
                    });
                    db.CandidateTechSkills.Add(new CandidateTechSkillEntityModel
                    {
                        Id = candidateTechSkillId2,
                        SkillId = skillGuid2,
                        CandidateId = candidateId2,
                    });
                    db.CandidateTechSkills.Add(new CandidateTechSkillEntityModel
                    {
                        Id = candidateTechSkillId3,
                        SkillId = skillGuid3,
                        CandidateId = candidateId3,
                    });
                    db.SaveChanges();
                }

                var candidateProjectRolesId1 = Guid.NewGuid();
                var candidateProjectRolesId2 = Guid.NewGuid();
                var candidateProjectRolesId3 = Guid.NewGuid();

                if (!db.CandidateProjectRoles.Any())
                {
                    db.CandidateProjectRoles.Add(new CandidateProjectRoleEntityModel
                    {
                        Id = candidateProjectRolesId1,
                        Name = "Role 1"
                    });
                    db.CandidateProjectRoles.Add(new CandidateProjectRoleEntityModel
                    {
                        Id = candidateProjectRolesId2,
                        Name = "Role 1"
                    });
                    db.CandidateProjectRoles.Add(new CandidateProjectRoleEntityModel
                    {
                        Id = candidateProjectRolesId3,
                        Name = "Role 1"
                    });
                    db.SaveChanges();
                }

                if (!db.CandidateSandboxes.Any())
                {
                    db.CandidateSandboxes.Add(new CandidateSandboxEntityModel
                    {
                        Id = candidateSandboxId1,
                        SandboxId = SandboxId2,
                        CandidateId = candidateId3,
                        CandidateProjectRoleId = candidateProjectRolesId3,
                        TeamId = null,
                        StackTechnologyId = StackTechnologyId1,
                        Motivation = "Motivation 1",
                        TimeContact = "10:00",
                        IsJoinToExadel = true,
                        SandboxLanguageId = languageLevelGuid3,
                        IsAgreement = false,
                        AvailabilityTypeId = availabilityType3
                    });
                    db.CandidateSandboxes.Add(new CandidateSandboxEntityModel
                    {
                        Id = candidateSandboxId2,
                        SandboxId = SandboxId1,
                        CandidateId = candidateId1,
                        CandidateProjectRoleId = candidateProjectRolesId1,
                        TeamId = null,
                        StackTechnologyId = StackTechnologyId2,
                        Motivation = "Motivation 1",
                        TimeContact = "10:00",
                        IsJoinToExadel = true,
                        SandboxLanguageId = languageLevelGuid1,
                        IsAgreement = false,
                        AvailabilityTypeId = availabilityType2
                    });
                    db.CandidateSandboxes.Add(new CandidateSandboxEntityModel
                    {
                        Id = candidateSandboxId3,
                        SandboxId = SandboxId3,
                        CandidateId = candidateId2,
                        CandidateProjectRoleId = candidateProjectRolesId2,
                        TeamId = null,
                        StackTechnologyId = StackTechnologyId1,
                        Motivation = "Motivation 1",
                        TimeContact = "10:00",
                        IsJoinToExadel = true,
                        SandboxLanguageId = languageLevelGuid2,
                        IsAgreement = false,
                        AvailabilityTypeId = availabilityType1
                    });
                    db.SaveChanges();
                }

                if (!db.CandidatesProcceses.Any())
                {
                    db.CandidatesProcceses.Add(new CandidateProcesEntityModel
                    {
                        Id = candidateProcessId1,
                        StatusId = statusGuid1,
                        CandidateSandboxId = candidateSandboxId1,
                        TestResult = "",
                        CreateDate = DateTime.UtcNow
                    });
                    db.CandidatesProcceses.Add(new CandidateProcesEntityModel
                    {
                        Id = candidateProcessId2,
                        StatusId = statusGuid2,
                        CandidateSandboxId = candidateSandboxId2,
                        TestResult = "",
                        CreateDate = DateTime.UtcNow
                    });
                    db.CandidatesProcceses.Add(new CandidateProcesEntityModel
                    {
                        Id = candidateProcessId3,
                        StatusId = statusGuid3,
                        CandidateSandboxId = candidateSandboxId3,
                        TestResult = "",
                        CreateDate = DateTime.UtcNow
                    });
                    db.SaveChanges();
                }

                if (!db.Feedbacks.Any())
                {

                    UserEntityModel user1 = db.Users.Where(u => u.Email == "mentor@gmail.com").FirstOrDefault();

                    db.Feedbacks.Add(new FeedbackEntityModel
                    {
                        Id = Guid.NewGuid(),
                        UserId = user1.Id,
                        Author = $"{user1.Name} {user1.Surname}",
                        Grade = 7,
                        CreateDate = DateTime.UtcNow,
                        UserReview = "Good knowledge",
                        CandidateProccesId = candidateProcessId1
                    });

                    UserEntityModel user2 = db.Users.Where(u => u.Email == "interviewer.sapex.2021@gmail.com").FirstOrDefault();

                    db.Feedbacks.Add(new FeedbackEntityModel
                    {
                        Id = Guid.NewGuid(),
                        UserId = user2.Id,
                        Author = $"{user2.Name} {user2.Surname}",
                        Grade =3,
                        CreateDate = DateTime.UtcNow,
                        UserReview = "Sufficient level",
                        CandidateProccesId = candidateProcessId1
                    });

                    UserEntityModel user3 = db.Users.Where(u => u.Email == "recruiter@gmail.com").FirstOrDefault();

                    db.Feedbacks.Add(new FeedbackEntityModel
                    {
                        Id = Guid.NewGuid(),
                        UserId = user3.Id,
                        Author = $"{user3.Name} {user3.Surname}",
                        Grade = 50,
                        CreateDate = DateTime.UtcNow,
                        UserReview = "Next step",
                        CandidateProccesId = candidateProcessId1
                    });
                    db.SaveChanges();
                }

                if (!db.UserCandidateSandboxes.Any())
                {
                    db.UserCandidateSandboxes.Add(new UserCandidateSandboxEntityModel
                    {
                        Id = Guid.NewGuid(),
                        UserId = UserId3,
                        CandidateSandboxId = candidateSandboxId1
                    });

                    db.UserCandidateSandboxes.Add(new UserCandidateSandboxEntityModel
                    {
                        Id = Guid.NewGuid(),
                        UserId = UserId3,
                        CandidateSandboxId = candidateSandboxId2
                    });

                    db.UserCandidateSandboxes.Add(new UserCandidateSandboxEntityModel
                    {
                        Id = Guid.NewGuid(),
                        UserId = UserId3,
                        CandidateSandboxId = candidateSandboxId3
                    });
                    db.SaveChanges();
                }

                if (!db.AppSettings.Any())
                {
                    db.AppSettings.Add(new AppSettingEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestTaskUrl",
                        Value = "http://64.227.114.210:9090/api/testtasks"
                    });
                    db.AppSettings.Add(new AppSettingEntityModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestResultUrl",
                        Value = "localhost:4200/upload-files"
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
