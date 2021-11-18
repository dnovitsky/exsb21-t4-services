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

                Guid idSb1 = Guid.NewGuid();
                Guid idSb2 = Guid.Parse("F158D307-DAB4-44E4-A148-B4E3D94B8447");
                Guid idSb3 = Guid.NewGuid();
                Guid idSb4 = Guid.NewGuid();
                Guid idSb5 = Guid.NewGuid();
                Guid idSb6 = Guid.NewGuid();
                Guid idSb7 = Guid.NewGuid();
                Guid idSb8 = Guid.NewGuid();

                Guid idLg1 = Guid.Parse("4019D15B-37AD-4ABF-B5B3-2A57318608FE");
                Guid idLg2 = Guid.NewGuid();
                Guid idLg3 = Guid.Parse("D1A3C67B-DB05-4646-A9FE-9243DBD79489");
                Guid idLg4 = Guid.NewGuid();
                Guid idLg5 = Guid.NewGuid();

                Guid idSt1 = Guid.NewGuid();
                Guid idSt2 = Guid.NewGuid();
                Guid idSt3 = Guid.Parse("D1D4E77B-B6D5-4B4D-9645-535C8B246189");
                Guid idSt4 = Guid.NewGuid();
                Guid idSt5 = Guid.NewGuid();

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

                if (!db.Sandboxes.Any())
                {
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb1,
                        Name = ".Net & JS",
                        MaxCandidates = 10,
                        Description = "description .Net & JS",
                        CreateDate = new DateTime(2021, 10, 1),
                        StartDate = new DateTime(2021, 12, 2),
                        EndDate = new DateTime(2021, 12, 30),
                        StartRegistration = new DateTime(2021, 11, 11),
                        EndRegistration = new DateTime(2021, 11, 30),
                        Status = StatusName.Draft,
                    });;
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb2,
                        Name = "Python",
                        MaxCandidates = 22,
                        Description = "description Python",
                        CreateDate = new DateTime(2021, 11, 1),
                        StartDate = new DateTime(2021, 12, 3),
                        EndDate = new DateTime(2021, 12, 30),
                        StartRegistration = new DateTime(2021, 11, 25),
                        EndRegistration = new DateTime(2021, 11, 30),
                        Status = StatusName.Active,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb3,
                        Name = "PHP",
                        MaxCandidates = 33,
                        Description = "description PHP",
                        CreateDate = new DateTime(2021, 10, 1),
                        StartDate = new DateTime(2021, 12, 2),
                        EndDate = new DateTime(2021, 12, 30),
                        StartRegistration = new DateTime(2021, 11, 16),
                        EndRegistration = new DateTime(2021, 11, 25),
                        Status = StatusName.Active,
                    });
                    db.Sandboxes.Add(new SandboxEntityModel
                    {
                        Id = idSb4,
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
                        Id = idSb5,
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
                        Id = idSb6,
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
                        Id = idSb7,
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
                        Id = idSb8,
                        Name = "Devops",
                        MaxCandidates = 81,
                        Description = "description Devops",
                        CreateDate = new DateTime(2021, 8, 1),
                        StartDate = new DateTime(2021, 8, 2),
                        EndDate = new DateTime(2021, 8, 3),
                        StartRegistration = new DateTime(2021, 8, 4),
                        EndRegistration = new DateTime(2021, 8, 5),
                        Status = StatusName.Draft,
                    });
                }
                db.SaveChanges();

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
                }
                db.SaveChanges();

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

                }
                db.SaveChanges();

                if (!db.Languages.Any())
                {
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg1,
                        Name = "English"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg2,
                        Name = "Russian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg3,
                        Name = "Georgian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg4,
                        Name = "Latvian"
                    });
                    db.Languages.Add(new LanguageEntityModel
                    {
                        Id = idLg5,
                        Name = "Polish"
                    });
                }
                db.SaveChanges();

                if (!db.StackTechnologies.Any())
                {
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = idSt1,
                        Name = ".Net"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = idSt2,
                        Name = "JS"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = idSt3,
                        Name = "Java"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = idSt4,
                        Name = "Devops"
                    });
                    db.StackTechnologies.Add(new StackTechnologyEntityModel
                    {
                        Id = idSt5,
                        Name = "Python"
                    });
                }
                db.SaveChanges();

                if (!db.SandboxStackTechnologies.Any())
                {
                    db.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb1,
                        StackTechnologyId = idSt1
                    });

                    db.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb1,
                        StackTechnologyId = idSt2
                    });

                    db.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb2,
                        StackTechnologyId = idSt2
                    });

                    db.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb2,
                        StackTechnologyId = idSt3
                    });

                    db.Add(new SandboxStackTechnologyEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb3,
                        StackTechnologyId = idSt4
                    });

                }
                db.SaveChanges();

                if (!db.SandboxLanguages.Any())
                {
                    db.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb1,
                        LanguageId = idLg1
                    });

                    db.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb1,
                        LanguageId = idLg2
                    });

                    db.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb2,
                        LanguageId = idLg1
                    });

                    db.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb2,
                        LanguageId = idLg3
                    });

                    db.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb3,
                        LanguageId = idLg1
                    });

                    db.Add(new SandboxLanguageEntityModel
                    {
                        Id = Guid.NewGuid(),
                        SandboxId = idSb3,
                        LanguageId = idLg4
                    });
                }
                db.SaveChanges();

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
                }
                db.SaveChanges();

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
                }
                db.SaveChanges();
                
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
                        Location = "11",
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
                        Location = "11",
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
                        Location = "11",
                        Skype = "skypeTom",
                        Phone = "+375291234567",
                        ProfessionaCertificates = "",
                        AdditionalSkills = ""
                    });
                }
                db.SaveChanges();

                if (!db.CandidateLanguages.Any())
                {
                    db.CandidateLanguages.Add(new CandidateLanguageEntityModel
                    {
                        Id = candidateLangId1,
                        CandidateId = candidateId1,
                        LanguageId = idLg1,
                        LanguageLevelId = languageLevelGuid2
                    });
                    db.CandidateLanguages.Add(new CandidateLanguageEntityModel
                    {
                        Id = candidateLangId2,
                        LanguageId = idLg3,
                        CandidateId = candidateId2,
                        LanguageLevelId = languageLevelGuid1
                    });
                    db.CandidateLanguages.Add(new CandidateLanguageEntityModel
                    {
                        Id = candidateLangId3,
                        LanguageId = idLg4,
                        CandidateId = candidateId3,
                        LanguageLevelId = languageLevelGuid3
                    });
                }
                db.SaveChanges();

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
                }
                db.SaveChanges();

                if (!db.CandidatesProcceses.Any())
                {
                    db.CandidatesProcceses.Add(new CandidateProccesEntityModel
                    {
                        Id = candidateProcessId1,
                        StatusId = statusGuid1,
                        TestResult = "",
                        CreateDate = DateTime.Now,
                        FeedbackId = null
                    });
                    db.CandidatesProcceses.Add(new CandidateProccesEntityModel
                    {
                        Id = candidateProcessId2,
                        StatusId = statusGuid2,
                        TestResult = "",
                        CreateDate = DateTime.Now,
                        FeedbackId = null
                    });
                    db.CandidatesProcceses.Add(new CandidateProccesEntityModel
                    {
                        Id = candidateProcessId3,
                        StatusId = statusGuid3,
                        TestResult = "",
                        CreateDate = DateTime.Now,
                        FeedbackId = null
                    });
                }
                db.SaveChanges();

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
                }
                db.SaveChanges();

                if (!db.CandidateSandboxes.Any())
                {
                    db.CandidateSandboxes.Add(new CandidateSandboxEntityModel
                    {
                        Id = candidateSandboxId1,
                        SandboxId = idSb2,
                        CandidateId = candidateId3,
                        CandidateProjectRoleId = candidateProjectRolesId3,
                        TeamId = null,
                        StackTechnologyId = idSt1,
                        CandidateProcessId = candidateProcessId2,
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
                        SandboxId = idSb1,
                        CandidateId = candidateId1,
                        CandidateProjectRoleId = candidateProjectRolesId1,
                        TeamId = null,
                        StackTechnologyId = idSt2,
                        CandidateProcessId = candidateProcessId1,
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
                        SandboxId = idSb3,
                        CandidateId = candidateId2,
                        CandidateProjectRoleId = candidateProjectRolesId2,
                        TeamId = null,
                        StackTechnologyId = idSt1,
                        CandidateProcessId = candidateProcessId1,
                        Motivation = "Motivation 1",
                        TimeContact = "10:00",
                        IsJoinToExadel = true,
                        SandboxLanguageId = languageLevelGuid2,
                        IsAgreement = false,
                        AvailabilityTypeId = availabilityType1
                    });
                }
                db.SaveChanges();
            }
        }
    }
}
