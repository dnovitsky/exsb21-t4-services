using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class InitAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTable");

            migrationBuilder.CreateTable(
                name: "CandidateLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateTechSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTechSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SandBoxTechSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SandBoxTechSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTechSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTechSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidatesProcceses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatesProcceses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatesProcceses_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateLanguageId = table.Column<int>(type: "int", nullable: true),
                    UserLanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageLevels_CandidateLanguages_CandidateLanguageId",
                        column: x => x.CandidateLanguageId,
                        principalTable: "CandidateLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguageLevels_UserLanguages_UserLanguageId",
                        column: x => x.UserLanguageId,
                        principalTable: "UserLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_UserTeams_UserTeamId",
                        column: x => x.UserTeamId,
                        principalTable: "UserTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSandBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSandBoxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSandBoxes_UserTeams_UserTeamId",
                        column: x => x.UserTeamId,
                        principalTable: "UserTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateLanguageId = table.Column<int>(type: "int", nullable: true),
                    CandidateTechSkillId = table.Column<int>(type: "int", nullable: true),
                    CandidatesProccesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_CandidateLanguages_CandidateLanguageId",
                        column: x => x.CandidateLanguageId,
                        principalTable: "CandidateLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_CandidatesProcceses_CandidatesProccesId",
                        column: x => x.CandidatesProccesId,
                        principalTable: "CandidatesProcceses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidates_CandidateTechSkills_CandidateTechSkillId",
                        column: x => x.CandidateTechSkillId,
                        principalTable: "CandidateTechSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidatesProccesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_CandidatesProcceses_CandidatesProccesId",
                        column: x => x.CandidatesProccesId,
                        principalTable: "CandidatesProcceses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageLevelId = table.Column<int>(type: "int", nullable: true),
                    CandidateLanguageId = table.Column<int>(type: "int", nullable: true),
                    UserLanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_CandidateLanguages_CandidateLanguageId",
                        column: x => x.CandidateLanguageId,
                        principalTable: "CandidateLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Languages_LanguageLevels_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Languages_UserLanguages_UserLanguageId",
                        column: x => x.UserLanguageId,
                        principalTable: "UserLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSandboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateProccesId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSandboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProccesId",
                        column: x => x.CandidateProccesId,
                        principalTable: "CandidatesProcceses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateSandboxes_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSandBoxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_UserSandBoxes_UserSandBoxId",
                        column: x => x.UserSandBoxId,
                        principalTable: "UserSandBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    FeedbackId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidateProjectRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateSandboxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProjectRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateProjectRole_CandidateSandboxes_CandidateSandboxId",
                        column: x => x.CandidateSandboxId,
                        principalTable: "CandidateSandboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sandboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCandidates = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateSandboxId = table.Column<int>(type: "int", nullable: true),
                    SandBoxTechSkillId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    UserSandBoxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sandboxes_CandidateSandboxes_CandidateSandboxId",
                        column: x => x.CandidateSandboxId,
                        principalTable: "CandidateSandboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sandboxes_SandBoxTechSkills_SandBoxTechSkillId",
                        column: x => x.SandBoxTechSkillId,
                        principalTable: "SandBoxTechSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sandboxes_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sandboxes_UserSandBoxes_UserSandBoxId",
                        column: x => x.UserSandBoxId,
                        principalTable: "UserSandBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FunctionalRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunctionalRoles_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackId = table.Column<int>(type: "int", nullable: true),
                    UserLanguageId = table.Column<int>(type: "int", nullable: true),
                    UserRoleId = table.Column<int>(type: "int", nullable: true),
                    UserSandBoxId = table.Column<int>(type: "int", nullable: true),
                    UserTechSkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserLanguages_UserLanguageId",
                        column: x => x.UserLanguageId,
                        principalTable: "UserLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserSandBoxes_UserSandBoxId",
                        column: x => x.UserSandBoxId,
                        principalTable: "UserSandBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserTechSkill_UserTechSkillId",
                        column: x => x.UserTechSkillId,
                        principalTable: "UserTechSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateTechSkillId = table.Column<int>(type: "int", nullable: true),
                    RatingId = table.Column<int>(type: "int", nullable: true),
                    SandBoxTechSkillId = table.Column<int>(type: "int", nullable: true),
                    UserTechSkillId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_CandidateTechSkills_CandidateTechSkillId",
                        column: x => x.CandidateTechSkillId,
                        principalTable: "CandidateTechSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_SandBoxTechSkills_SandBoxTechSkillId",
                        column: x => x.SandBoxTechSkillId,
                        principalTable: "SandBoxTechSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_UserTechSkill_UserTechSkillId",
                        column: x => x.UserTechSkillId,
                        principalTable: "UserTechSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProjectRole_CandidateSandboxId",
                table: "CandidateProjectRole",
                column: "CandidateSandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CandidateLanguageId",
                table: "Candidates",
                column: "CandidateLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CandidatesProccesId",
                table: "Candidates",
                column: "CandidatesProccesId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CandidateTechSkillId",
                table: "Candidates",
                column: "CandidateTechSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidateProccesId",
                table: "CandidateSandboxes",
                column: "CandidateProccesId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_TeamId",
                table: "CandidateSandboxes",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProcceses_StatusId",
                table: "CandidatesProcceses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CandidatesProccesId",
                table: "Feedbacks",
                column: "CandidatesProccesId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalRoles_UserRoleId",
                table: "FunctionalRoles",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageLevels_CandidateLanguageId",
                table: "LanguageLevels",
                column: "CandidateLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageLevels_UserLanguageId",
                table: "LanguageLevels",
                column: "UserLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CandidateLanguageId",
                table: "Languages",
                column: "CandidateLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageLevelId",
                table: "Languages",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_UserLanguageId",
                table: "Languages",
                column: "UserLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FeedbackId",
                table: "Ratings",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Sandboxes_CandidateSandboxId",
                table: "Sandboxes",
                column: "CandidateSandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Sandboxes_SandBoxTechSkillId",
                table: "Sandboxes",
                column: "SandBoxTechSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Sandboxes_TeamId",
                table: "Sandboxes",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Sandboxes_UserSandBoxId",
                table: "Sandboxes",
                column: "UserSandBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CandidateTechSkillId",
                table: "Skills",
                column: "CandidateTechSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_RatingId",
                table: "Skills",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SandBoxTechSkillId",
                table: "Skills",
                column: "SandBoxTechSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserTechSkillId",
                table: "Skills",
                column: "UserTechSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UserTeamId",
                table: "Teams",
                column: "UserTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserSandBoxId",
                table: "UserRole",
                column: "UserSandBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FeedbackId",
                table: "Users",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLanguageId",
                table: "Users",
                column: "UserLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserSandBoxId",
                table: "Users",
                column: "UserSandBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTechSkillId",
                table: "Users",
                column: "UserTechSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_UserTeamId",
                table: "UserSandBoxes",
                column: "UserTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateProjectRole");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "FunctionalRoles");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Sandboxes");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LanguageLevels");

            migrationBuilder.DropTable(
                name: "CandidateSandboxes");

            migrationBuilder.DropTable(
                name: "CandidateTechSkills");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "SandBoxTechSkills");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserTechSkill");

            migrationBuilder.DropTable(
                name: "CandidateLanguages");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "UserSandBoxes");

            migrationBuilder.DropTable(
                name: "CandidatesProcceses");

            migrationBuilder.DropTable(
                name: "UserTeams");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.Id);
                });
        }
    }
}
