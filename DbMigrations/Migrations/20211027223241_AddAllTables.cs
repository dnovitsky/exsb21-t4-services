﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class AddAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateProjectRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProjectRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FunctionalRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sandboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCandidates = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndRegistration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandboxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateLanguages_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateLanguages_LanguageLevels_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateTechSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTechSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateTechSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateTechSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SandBoxTechSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SandboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SandBoxTechSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SandBoxTechSkills_Sandboxes_SandboxId",
                        column: x => x.SandboxId,
                        principalTable: "Sandboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SandBoxTechSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageLevelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguages_LanguageLevels_LanguageLevelsId",
                        column: x => x.LanguageLevelsId,
                        principalTable: "LanguageLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionalRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_FunctionalRoles_FunctionalRoleId",
                        column: x => x.FunctionalRoleId,
                        principalTable: "FunctionalRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTechSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTechSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTechSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTechSkills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserReview = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSandBoxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SandBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEntityModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSandBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSandBoxes_Sandboxes_SandBoxId",
                        column: x => x.SandBoxId,
                        principalTable: "Sandboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSandBoxes_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSandBoxes_Users_UserEntityModelId",
                        column: x => x.UserEntityModelId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSandBoxes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesProcceses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesProcceses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatesProcceses_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatesProcceses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSandboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SandboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProccesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatesProccesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CandidateProjectRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSandboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSandboxes_CandidateProjectRoles_CandidateProjectRoleId",
                        column: x => x.CandidateProjectRoleId,
                        principalTable: "CandidateProjectRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSandboxes_CandidatesProcceses_CandidatesProccesId",
                        column: x => x.CandidatesProccesId,
                        principalTable: "CandidatesProcceses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateSandboxes_Sandboxes_SandboxId",
                        column: x => x.SandboxId,
                        principalTable: "Sandboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SandboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateSandboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_CandidateSandboxes_CandidateSandboxId",
                        column: x => x.CandidateSandboxId,
                        principalTable: "CandidateSandboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Sandboxes_SandboxId",
                        column: x => x.SandboxId,
                        principalTable: "Sandboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserSandBoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserSandBoxEntityModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeams_UserSandBoxes_UserSandBoxEntityModelId",
                        column: x => x.UserSandBoxEntityModelId,
                        principalTable: "UserSandBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTeams_UserSandBoxes_UserSandBoxId",
                        column: x => x.UserSandBoxId,
                        principalTable: "UserSandBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLanguages_CandidateId",
                table: "CandidateLanguages",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLanguages_LanguageId",
                table: "CandidateLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLanguages_LanguageLevelId",
                table: "CandidateLanguages",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidateProjectRoleId",
                table: "CandidateSandboxes",
                column: "CandidateProjectRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidatesProccesId",
                table: "CandidateSandboxes",
                column: "CandidatesProccesId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_SandboxId",
                table: "CandidateSandboxes",
                column: "SandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_TeamId",
                table: "CandidateSandboxes",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProcceses_CandidateId",
                table: "CandidatesProcceses",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProcceses_FeedbackId",
                table: "CandidatesProcceses",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProcceses_StatusId",
                table: "CandidatesProcceses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTechSkills_CandidateId",
                table: "CandidateTechSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTechSkills_SkillId",
                table: "CandidateTechSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RatingId",
                table: "Feedbacks",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SkillId",
                table: "Ratings",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SandBoxTechSkills_SandboxId",
                table: "SandBoxTechSkills",
                column: "SandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_SandBoxTechSkills_SkillId",
                table: "SandBoxTechSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CandidateSandboxId",
                table: "Teams",
                column: "CandidateSandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SandboxId",
                table: "Teams",
                column: "SandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageLevelsId",
                table: "UserLanguages",
                column: "LanguageLevelsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_UserId",
                table: "UserLanguages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_FunctionalRoleId",
                table: "UserRoles",
                column: "FunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_SandBoxId",
                table: "UserSandBoxes",
                column: "SandBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_UserEntityModelId",
                table: "UserSandBoxes",
                column: "UserEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_UserId",
                table: "UserSandBoxes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_UserRoleId",
                table: "UserSandBoxes",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_TeamId",
                table: "UserTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_UserSandBoxEntityModelId",
                table: "UserTeams",
                column: "UserSandBoxEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_UserSandBoxId",
                table: "UserTeams",
                column: "UserSandBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTechSkills_SkillId",
                table: "UserTechSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTechSkills_UserId",
                table: "UserTechSkills",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_Teams_TeamId",
                table: "CandidateSandboxes",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_Candidates_CandidateId",
                table: "CandidatesProcceses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidateProjectRoles_CandidateProjectRoleId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidatesProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_Sandboxes_SandboxId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Sandboxes_SandboxId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_Teams_TeamId",
                table: "CandidateSandboxes");

            migrationBuilder.DropTable(
                name: "CandidateLanguages");

            migrationBuilder.DropTable(
                name: "CandidateTechSkills");

            migrationBuilder.DropTable(
                name: "SandBoxTechSkills");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "UserTeams");

            migrationBuilder.DropTable(
                name: "UserTechSkills");

            migrationBuilder.DropTable(
                name: "LanguageLevels");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "UserSandBoxes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "FunctionalRoles");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "CandidateProjectRoles");

            migrationBuilder.DropTable(
                name: "CandidatesProcceses");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Sandboxes");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "CandidateSandboxes");
        }
    }
}
