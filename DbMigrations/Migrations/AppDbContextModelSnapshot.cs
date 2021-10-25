﻿// <auto-generated />
using System;
using DbMigrations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DbMigrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DbMigrations.EntityModels.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CandidateLanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("CandidateTechSkillId")
                        .HasColumnType("int");

                    b.Property<int?>("CandidatesProccesId")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateLanguageId");

                    b.HasIndex("CandidateTechSkillId");

                    b.HasIndex("CandidatesProccesId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("CandidateLanguages");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateProjectRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateSandboxId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateSandboxId");

                    b.ToTable("CandidateProjectRole");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateSandbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateProccesId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateProccesId");

                    b.HasIndex("TeamId");

                    b.ToTable("CandidateSandboxes");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateTechSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("CandidateTechSkills");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidatesProcces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TestResult")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("CandidatesProcceses");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidatesProccesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserReview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidatesProccesId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.FunctionalRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("FunctionalRoles");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateLanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageLevelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserLanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateLanguageId");

                    b.HasIndex("LanguageLevelId");

                    b.HasIndex("UserLanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.LanguageLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserLanguageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateLanguageId");

                    b.HasIndex("UserLanguageId");

                    b.ToTable("LanguageLevels");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FeedbackId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.SandBoxTechSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("SandBoxTechSkills");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Sandbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateSandboxId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndRegistration")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxCandidates")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SandBoxTechSkillId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartRegistration")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("UserSandBoxId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateSandboxId");

                    b.HasIndex("SandBoxTechSkillId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserSandBoxId");

                    b.ToTable("Sandboxes");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateTechSkillId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RatingId")
                        .HasColumnType("int");

                    b.Property<int?>("SandBoxTechSkillId")
                        .HasColumnType("int");

                    b.Property<int?>("UserTechSkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateTechSkillId");

                    b.HasIndex("RatingId");

                    b.HasIndex("SandBoxTechSkillId");

                    b.HasIndex("UserTechSkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FeedbackId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserLanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserSandBoxId")
                        .HasColumnType("int");

                    b.Property<int?>("UserTechSkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackId");

                    b.HasIndex("UserLanguageId");

                    b.HasIndex("UserRoleId");

                    b.HasIndex("UserSandBoxId");

                    b.HasIndex("UserTechSkillId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("UserSandBoxId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserSandBoxId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserSandBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("UserTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTeamId");

                    b.ToTable("UserSandBoxes");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("UserTeams");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserTechSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("UserTechSkill");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Candidate", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.CandidateLanguage", null)
                        .WithMany("Candidates")
                        .HasForeignKey("CandidateLanguageId");

                    b.HasOne("DbMigrations.EntityModels.CandidateTechSkill", null)
                        .WithMany("Candidates")
                        .HasForeignKey("CandidateTechSkillId");

                    b.HasOne("DbMigrations.EntityModels.CandidatesProcces", null)
                        .WithMany("Candidates")
                        .HasForeignKey("CandidatesProccesId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateProjectRole", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.CandidateSandbox", null)
                        .WithMany("ProjectRoles")
                        .HasForeignKey("CandidateSandboxId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateSandbox", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.CandidatesProcces", "CandidateProcces")
                        .WithMany()
                        .HasForeignKey("CandidateProccesId");

                    b.HasOne("DbMigrations.EntityModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("CandidateProcces");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidatesProcces", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Feedback", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.CandidatesProcces", null)
                        .WithMany("Feedbacks")
                        .HasForeignKey("CandidatesProccesId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.FunctionalRole", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.UserRole", null)
                        .WithMany("FunctionalRoles")
                        .HasForeignKey("UserRoleId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Language", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.CandidateLanguage", null)
                        .WithMany("Languages")
                        .HasForeignKey("CandidateLanguageId");

                    b.HasOne("DbMigrations.EntityModels.LanguageLevel", "LanguageLevel")
                        .WithMany()
                        .HasForeignKey("LanguageLevelId");

                    b.HasOne("DbMigrations.EntityModels.UserLanguage", null)
                        .WithMany("Languages")
                        .HasForeignKey("UserLanguageId");

                    b.Navigation("LanguageLevel");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.LanguageLevel", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.CandidateLanguage", null)
                        .WithMany("LanguageLevels")
                        .HasForeignKey("CandidateLanguageId");

                    b.HasOne("DbMigrations.EntityModels.UserLanguage", null)
                        .WithMany("LanguageLevels")
                        .HasForeignKey("UserLanguageId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Rating", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.Feedback", null)
                        .WithMany("Ratings")
                        .HasForeignKey("FeedbackId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Sandbox", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.CandidateSandbox", null)
                        .WithMany("Sandboxes")
                        .HasForeignKey("CandidateSandboxId");

                    b.HasOne("DbMigrations.EntityModels.SandBoxTechSkill", null)
                        .WithMany("Languages")
                        .HasForeignKey("SandBoxTechSkillId");

                    b.HasOne("DbMigrations.EntityModels.Team", null)
                        .WithMany("Sandbox")
                        .HasForeignKey("TeamId");

                    b.HasOne("DbMigrations.EntityModels.UserSandBox", null)
                        .WithMany("SandBoxes")
                        .HasForeignKey("UserSandBoxId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Skill", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.CandidateTechSkill", null)
                        .WithMany("Skills")
                        .HasForeignKey("CandidateTechSkillId");

                    b.HasOne("DbMigrations.EntityModels.Rating", null)
                        .WithMany("Skills")
                        .HasForeignKey("RatingId");

                    b.HasOne("DbMigrations.EntityModels.SandBoxTechSkill", null)
                        .WithMany("Candidates")
                        .HasForeignKey("SandBoxTechSkillId");

                    b.HasOne("DbMigrations.EntityModels.UserTechSkill", null)
                        .WithMany("Skills")
                        .HasForeignKey("UserTechSkillId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Team", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.UserTeam", null)
                        .WithMany("Teams")
                        .HasForeignKey("UserTeamId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.User", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.Feedback", null)
                        .WithMany("Users")
                        .HasForeignKey("FeedbackId");

                    b.HasOne("DbMigrations.EntityModels.UserLanguage", null)
                        .WithMany("Users")
                        .HasForeignKey("UserLanguageId");

                    b.HasOne("DbMigrations.EntityModels.UserRole", null)
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId");

                    b.HasOne("DbMigrations.EntityModels.UserSandBox", null)
                        .WithMany("Users")
                        .HasForeignKey("UserSandBoxId");

                    b.HasOne("DbMigrations.EntityModels.UserTechSkill", null)
                        .WithMany("Users")
                        .HasForeignKey("UserTechSkillId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserRole", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.UserSandBox", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserSandBoxId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserSandBox", b =>
                {
                    b.HasOne("DbMigrations.EntityModels.UserTeam", null)
                        .WithMany("UserSandBoxes")
                        .HasForeignKey("UserTeamId");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateLanguage", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("LanguageLevels");

                    b.Navigation("Languages");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateSandbox", b =>
                {
                    b.Navigation("ProjectRoles");

                    b.Navigation("Sandboxes");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidateTechSkill", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.CandidatesProcces", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Feedback", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Rating", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.SandBoxTechSkill", b =>
                {
                    b.Navigation("Candidates");

                    b.Navigation("Languages");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.Team", b =>
                {
                    b.Navigation("Sandbox");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserLanguage", b =>
                {
                    b.Navigation("LanguageLevels");

                    b.Navigation("Languages");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserRole", b =>
                {
                    b.Navigation("FunctionalRoles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserSandBox", b =>
                {
                    b.Navigation("SandBoxes");

                    b.Navigation("UserRoles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserTeam", b =>
                {
                    b.Navigation("Teams");

                    b.Navigation("UserSandBoxes");
                });

            modelBuilder.Entity("DbMigrations.EntityModels.UserTechSkill", b =>
                {
                    b.Navigation("Skills");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
