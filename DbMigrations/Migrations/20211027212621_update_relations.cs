using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class update_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_CandidateLanguages_CandidateLanguageId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_CandidatesProcceses_CandidatesProccesId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_CandidateTechSkills_CandidateTechSkillId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_Teams_TeamId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_Status_StatusId",
                table: "CandidatesProcceses");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_CandidatesProcceses_CandidatesProccesId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FunctionalRoles_UserRole_UserRoleId",
                table: "FunctionalRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageLevels_CandidateLanguages_CandidateLanguageId",
                table: "LanguageLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageLevels_UserLanguages_UserLanguageId",
                table: "LanguageLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_CandidateLanguages_CandidateLanguageId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_LanguageLevels_LanguageLevelId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_UserLanguages_UserLanguageId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Feedbacks_FeedbackId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sandboxes_CandidateSandboxes_CandidateSandboxId",
                table: "Sandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sandboxes_SandBoxTechSkills_SandBoxTechSkillId",
                table: "Sandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sandboxes_Teams_TeamId",
                table: "Sandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sandboxes_UserSandBoxes_UserSandBoxId",
                table: "Sandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_CandidateTechSkills_CandidateTechSkillId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Ratings_RatingId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SandBoxTechSkills_SandBoxTechSkillId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_UserTechSkill_UserTechSkillId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_UserTeams_UserTeamId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Feedbacks_FeedbackId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserLanguages_UserLanguageId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRole_UserRoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserSandBoxes_UserSandBoxId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTechSkill_UserTechSkillId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSandBoxes_UserTeams_UserTeamId",
                table: "UserSandBoxes");

            migrationBuilder.DropTable(
                name: "CandidateProjectRole");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserSandBoxes_UserTeamId",
                table: "UserSandBoxes");

            migrationBuilder.DropIndex(
                name: "IX_Users_FeedbackId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserLanguageId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserSandBoxId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTechSkillId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Teams_UserTeamId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CandidateTechSkillId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_RatingId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SandBoxTechSkillId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserTechSkillId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Sandboxes_CandidateSandboxId",
                table: "Sandboxes");

            migrationBuilder.DropIndex(
                name: "IX_Sandboxes_SandBoxTechSkillId",
                table: "Sandboxes");

            migrationBuilder.DropIndex(
                name: "IX_Sandboxes_TeamId",
                table: "Sandboxes");

            migrationBuilder.DropIndex(
                name: "IX_Sandboxes_UserSandBoxId",
                table: "Sandboxes");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_FeedbackId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Languages_CandidateLanguageId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageLevelId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_UserLanguageId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_LanguageLevels_CandidateLanguageId",
                table: "LanguageLevels");

            migrationBuilder.DropIndex(
                name: "IX_LanguageLevels_UserLanguageId",
                table: "LanguageLevels");

            migrationBuilder.DropIndex(
                name: "IX_FunctionalRoles_UserRoleId",
                table: "FunctionalRoles");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CandidatesProccesId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_CandidateProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_TeamId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_CandidateLanguageId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_CandidatesProccesId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_CandidateTechSkillId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "UserTeamId",
                table: "UserSandBoxes");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserLanguageId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSandBoxId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTechSkillId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTeamId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CandidateTechSkillId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SandBoxTechSkillId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserTechSkillId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CandidateSandboxId",
                table: "Sandboxes");

            migrationBuilder.DropColumn(
                name: "SandBoxTechSkillId",
                table: "Sandboxes");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Sandboxes");

            migrationBuilder.DropColumn(
                name: "UserSandBoxId",
                table: "Sandboxes");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "CandidateLanguageId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageLevelId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "UserLanguageId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "CandidateLanguageId",
                table: "LanguageLevels");

            migrationBuilder.DropColumn(
                name: "UserLanguageId",
                table: "LanguageLevels");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "FunctionalRoles");

            migrationBuilder.DropColumn(
                name: "CandidatesProccesId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CandidateLanguageId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CandidateTechSkillId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "CandidatesProccesId",
                table: "Candidates");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserTechSkill",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "UserTechSkill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserTechSkill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserTeams",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "UserTeams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserSandBoxId",
                table: "UserTeams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserSandBoxes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "SandBoxId",
                table: "UserSandBoxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserSandBoxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "UserSandBoxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserLanguages",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "UserLanguages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageLevelId",
                table: "UserLanguages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageLevelsId",
                table: "UserLanguages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserLanguages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "SandboxId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SandBoxTechSkills",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "SandboxId",
                table: "SandBoxTechSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "SandBoxTechSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sandboxes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Languages",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "LanguageLevels",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FunctionalRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CandidateTechSkills",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "CandidateTechSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SkillId",
                table: "CandidateTechSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StatusId",
                table: "CandidatesProcceses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CandidatesProcceses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "CandidatesProcceses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "CandidatesProcceses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateProccesId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateProjectRoleId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CandidatesProccesId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SandboxId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Candidates",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CandidateLanguages",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "CandidateLanguages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "CandidateLanguages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageLevelId",
                table: "CandidateLanguages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CandidateProjectRoleEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProjectRoleEntityModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEntityModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionalRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleEntityModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleEntityModel_FunctionalRoles_FunctionalRoleId",
                        column: x => x.FunctionalRoleId,
                        principalTable: "FunctionalRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleEntityModel_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTechSkill_SkillId",
                table: "UserTechSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTechSkill_UserId",
                table: "UserTechSkill",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_TeamId",
                table: "UserTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_UserSandBoxId",
                table: "UserTeams",
                column: "UserSandBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_SandBoxId",
                table: "UserSandBoxes",
                column: "SandBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_UserId",
                table: "UserSandBoxes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_UserRoleId",
                table: "UserSandBoxes",
                column: "UserRoleId");

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
                name: "IX_Teams_SandboxId",
                table: "Teams",
                column: "SandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_SandBoxTechSkills_SandboxId",
                table: "SandBoxTechSkills",
                column: "SandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_SandBoxTechSkills_SkillId",
                table: "SandBoxTechSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SkillId",
                table: "Ratings",
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
                name: "IX_CandidateTechSkills_CandidateId",
                table: "CandidateTechSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTechSkills_SkillId",
                table: "CandidateTechSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProcceses_CandidateId",
                table: "CandidatesProcceses",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProcceses_FeedbackId",
                table: "CandidatesProcceses",
                column: "FeedbackId");

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
                column: "TeamId",
                unique: true);

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
                name: "IX_UserRoleEntityModel_FunctionalRoleId",
                table: "UserRoleEntityModel",
                column: "FunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleEntityModel_UserId",
                table: "UserRoleEntityModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateLanguages_Candidates_CandidateId",
                table: "CandidateLanguages",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateLanguages_LanguageLevels_LanguageLevelId",
                table: "CandidateLanguages",
                column: "LanguageLevelId",
                principalTable: "LanguageLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateLanguages_Languages_LanguageId",
                table: "CandidateLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidateProjectRoleEntityModel_CandidateProjectRoleId",
                table: "CandidateSandboxes",
                column: "CandidateProjectRoleId",
                principalTable: "CandidateProjectRoleEntityModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidatesProccesId",
                table: "CandidateSandboxes",
                column: "CandidatesProccesId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_Sandboxes_SandboxId",
                table: "CandidateSandboxes",
                column: "SandboxId",
                principalTable: "Sandboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_Teams_TeamId",
                table: "CandidateSandboxes",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProcceses_Candidates_CandidateId",
                table: "CandidatesProcceses",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                table: "CandidatesProcceses",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProcceses_StatusEntityModel_StatusId",
                table: "CandidatesProcceses",
                column: "StatusId",
                principalTable: "StatusEntityModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechSkills_Candidates_CandidateId",
                table: "CandidateTechSkills",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateTechSkills_Skills_SkillId",
                table: "CandidateTechSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Ratings_RatingId",
                table: "Feedbacks",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_UserId",
                table: "Feedbacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Skills_SkillId",
                table: "Ratings",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SandBoxTechSkills_Sandboxes_SandboxId",
                table: "SandBoxTechSkills",
                column: "SandboxId",
                principalTable: "Sandboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SandBoxTechSkills_Skills_SkillId",
                table: "SandBoxTechSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Sandboxes_SandboxId",
                table: "Teams",
                column: "SandboxId",
                principalTable: "Sandboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_LanguageLevels_LanguageLevelsId",
                table: "UserLanguages",
                column: "LanguageLevelsId",
                principalTable: "LanguageLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_Languages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_Users_UserId",
                table: "UserLanguages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSandBoxes_Sandboxes_SandBoxId",
                table: "UserSandBoxes",
                column: "SandBoxId",
                principalTable: "Sandboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSandBoxes_UserRoleEntityModel_UserRoleId",
                table: "UserSandBoxes",
                column: "UserRoleId",
                principalTable: "UserRoleEntityModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSandBoxes_Users_UserId",
                table: "UserSandBoxes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_Teams_TeamId",
                table: "UserTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_UserSandBoxes_UserSandBoxId",
                table: "UserTeams",
                column: "UserSandBoxId",
                principalTable: "UserSandBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTechSkill_Skills_SkillId",
                table: "UserTechSkill",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTechSkill_Users_UserId",
                table: "UserTechSkill",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateLanguages_Candidates_CandidateId",
                table: "CandidateLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateLanguages_LanguageLevels_LanguageLevelId",
                table: "CandidateLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateLanguages_Languages_LanguageId",
                table: "CandidateLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidateProjectRoleEntityModel_CandidateProjectRoleId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidatesProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_Sandboxes_SandboxId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_Teams_TeamId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_Candidates_CandidateId",
                table: "CandidatesProcceses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                table: "CandidatesProcceses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_StatusEntityModel_StatusId",
                table: "CandidatesProcceses");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechSkills_Candidates_CandidateId",
                table: "CandidateTechSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateTechSkills_Skills_SkillId",
                table: "CandidateTechSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Ratings_RatingId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_UserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Skills_SkillId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_SandBoxTechSkills_Sandboxes_SandboxId",
                table: "SandBoxTechSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_SandBoxTechSkills_Skills_SkillId",
                table: "SandBoxTechSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Sandboxes_SandboxId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_LanguageLevels_LanguageLevelsId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_Languages_LanguageId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_Users_UserId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSandBoxes_Sandboxes_SandBoxId",
                table: "UserSandBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSandBoxes_UserRoleEntityModel_UserRoleId",
                table: "UserSandBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSandBoxes_Users_UserId",
                table: "UserSandBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_Teams_TeamId",
                table: "UserTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_UserSandBoxes_UserSandBoxId",
                table: "UserTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTechSkill_Skills_SkillId",
                table: "UserTechSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTechSkill_Users_UserId",
                table: "UserTechSkill");

            migrationBuilder.DropTable(
                name: "CandidateProjectRoleEntityModel");

            migrationBuilder.DropTable(
                name: "StatusEntityModel");

            migrationBuilder.DropTable(
                name: "UserRoleEntityModel");

            migrationBuilder.DropIndex(
                name: "IX_UserTechSkill_SkillId",
                table: "UserTechSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserTechSkill_UserId",
                table: "UserTechSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserTeams_TeamId",
                table: "UserTeams");

            migrationBuilder.DropIndex(
                name: "IX_UserTeams_UserSandBoxId",
                table: "UserTeams");

            migrationBuilder.DropIndex(
                name: "IX_UserSandBoxes_SandBoxId",
                table: "UserSandBoxes");

            migrationBuilder.DropIndex(
                name: "IX_UserSandBoxes_UserId",
                table: "UserSandBoxes");

            migrationBuilder.DropIndex(
                name: "IX_UserSandBoxes_UserRoleId",
                table: "UserSandBoxes");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguages_LanguageId",
                table: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguages_LanguageLevelsId",
                table: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguages_UserId",
                table: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Teams_SandboxId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_SandBoxTechSkills_SandboxId",
                table: "SandBoxTechSkills");

            migrationBuilder.DropIndex(
                name: "IX_SandBoxTechSkills_SkillId",
                table: "SandBoxTechSkills");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_SkillId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_RatingId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_CandidateTechSkills_CandidateId",
                table: "CandidateTechSkills");

            migrationBuilder.DropIndex(
                name: "IX_CandidateTechSkills_SkillId",
                table: "CandidateTechSkills");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesProcceses_CandidateId",
                table: "CandidatesProcceses");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesProcceses_FeedbackId",
                table: "CandidatesProcceses");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_CandidateProjectRoleId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_CandidatesProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_SandboxId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_TeamId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateLanguages_CandidateId",
                table: "CandidateLanguages");

            migrationBuilder.DropIndex(
                name: "IX_CandidateLanguages_LanguageId",
                table: "CandidateLanguages");

            migrationBuilder.DropIndex(
                name: "IX_CandidateLanguages_LanguageLevelId",
                table: "CandidateLanguages");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "UserTechSkill");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserTechSkill");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "UserTeams");

            migrationBuilder.DropColumn(
                name: "UserSandBoxId",
                table: "UserTeams");

            migrationBuilder.DropColumn(
                name: "SandBoxId",
                table: "UserSandBoxes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserSandBoxes");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "UserSandBoxes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageLevelId",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageLevelsId",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "SandboxId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "SandboxId",
                table: "SandBoxTechSkills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "SandBoxTechSkills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CandidateTechSkills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "CandidateTechSkills");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CandidatesProcceses");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "CandidatesProcceses");

            migrationBuilder.DropColumn(
                name: "CandidateProjectRoleId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "CandidatesProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "SandboxId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "CandidateLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "CandidateLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageLevelId",
                table: "CandidateLanguages");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserTechSkill",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserTeams",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserSandBoxes",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserTeamId",
                table: "UserSandBoxes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLanguageId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserSandBoxId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTechSkillId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserLanguages",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Teams",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserTeamId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CandidateTechSkillId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SandBoxTechSkillId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTechSkillId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SandBoxTechSkills",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Sandboxes",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CandidateSandboxId",
                table: "Sandboxes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SandBoxTechSkillId",
                table: "Sandboxes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Sandboxes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserSandBoxId",
                table: "Sandboxes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ratings",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Languages",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CandidateLanguageId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageLevelId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLanguageId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LanguageLevels",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CandidateLanguageId",
                table: "LanguageLevels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserLanguageId",
                table: "LanguageLevels",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FunctionalRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "FunctionalRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CandidatesProccesId",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CandidateTechSkills",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "CandidatesProcceses",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CandidatesProcceses",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "CandidateSandboxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateProccesId",
                table: "CandidateSandboxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CandidateSandboxes",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Candidates",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CandidateLanguageId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidateTechSkillId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidatesProccesId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CandidateLanguages",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "CandidateProjectRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateSandboxId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_UserTeamId",
                table: "UserSandBoxes",
                column: "UserTeamId");

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
                name: "IX_Teams_UserTeamId",
                table: "Teams",
                column: "UserTeamId");

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
                name: "IX_Ratings_FeedbackId",
                table: "Ratings",
                column: "FeedbackId");

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
                name: "IX_LanguageLevels_CandidateLanguageId",
                table: "LanguageLevels",
                column: "CandidateLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageLevels_UserLanguageId",
                table: "LanguageLevels",
                column: "UserLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionalRoles_UserRoleId",
                table: "FunctionalRoles",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CandidatesProccesId",
                table: "Feedbacks",
                column: "CandidatesProccesId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidateProccesId",
                table: "CandidateSandboxes",
                column: "CandidateProccesId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_TeamId",
                table: "CandidateSandboxes",
                column: "TeamId");

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
                name: "IX_CandidateProjectRole_CandidateSandboxId",
                table: "CandidateProjectRole",
                column: "CandidateSandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserSandBoxId",
                table: "UserRole",
                column: "UserSandBoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_CandidateLanguages_CandidateLanguageId",
                table: "Candidates",
                column: "CandidateLanguageId",
                principalTable: "CandidateLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_CandidatesProcceses_CandidatesProccesId",
                table: "Candidates",
                column: "CandidatesProccesId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_CandidateTechSkills_CandidateTechSkillId",
                table: "Candidates",
                column: "CandidateTechSkillId",
                principalTable: "CandidateTechSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProccesId",
                table: "CandidateSandboxes",
                column: "CandidateProccesId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_Teams_TeamId",
                table: "CandidateSandboxes",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProcceses_Status_StatusId",
                table: "CandidatesProcceses",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_CandidatesProcceses_CandidatesProccesId",
                table: "Feedbacks",
                column: "CandidatesProccesId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FunctionalRoles_UserRole_UserRoleId",
                table: "FunctionalRoles",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageLevels_CandidateLanguages_CandidateLanguageId",
                table: "LanguageLevels",
                column: "CandidateLanguageId",
                principalTable: "CandidateLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageLevels_UserLanguages_UserLanguageId",
                table: "LanguageLevels",
                column: "UserLanguageId",
                principalTable: "UserLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_CandidateLanguages_CandidateLanguageId",
                table: "Languages",
                column: "CandidateLanguageId",
                principalTable: "CandidateLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_LanguageLevels_LanguageLevelId",
                table: "Languages",
                column: "LanguageLevelId",
                principalTable: "LanguageLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_UserLanguages_UserLanguageId",
                table: "Languages",
                column: "UserLanguageId",
                principalTable: "UserLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Feedbacks_FeedbackId",
                table: "Ratings",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sandboxes_CandidateSandboxes_CandidateSandboxId",
                table: "Sandboxes",
                column: "CandidateSandboxId",
                principalTable: "CandidateSandboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sandboxes_SandBoxTechSkills_SandBoxTechSkillId",
                table: "Sandboxes",
                column: "SandBoxTechSkillId",
                principalTable: "SandBoxTechSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sandboxes_Teams_TeamId",
                table: "Sandboxes",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sandboxes_UserSandBoxes_UserSandBoxId",
                table: "Sandboxes",
                column: "UserSandBoxId",
                principalTable: "UserSandBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_CandidateTechSkills_CandidateTechSkillId",
                table: "Skills",
                column: "CandidateTechSkillId",
                principalTable: "CandidateTechSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Ratings_RatingId",
                table: "Skills",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SandBoxTechSkills_SandBoxTechSkillId",
                table: "Skills",
                column: "SandBoxTechSkillId",
                principalTable: "SandBoxTechSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_UserTechSkill_UserTechSkillId",
                table: "Skills",
                column: "UserTechSkillId",
                principalTable: "UserTechSkill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_UserTeams_UserTeamId",
                table: "Teams",
                column: "UserTeamId",
                principalTable: "UserTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Feedbacks_FeedbackId",
                table: "Users",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserLanguages_UserLanguageId",
                table: "Users",
                column: "UserLanguageId",
                principalTable: "UserLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRole_UserRoleId",
                table: "Users",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserSandBoxes_UserSandBoxId",
                table: "Users",
                column: "UserSandBoxId",
                principalTable: "UserSandBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTechSkill_UserTechSkillId",
                table: "Users",
                column: "UserTechSkillId",
                principalTable: "UserTechSkill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSandBoxes_UserTeams_UserTeamId",
                table: "UserSandBoxes",
                column: "UserTeamId",
                principalTable: "UserTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
