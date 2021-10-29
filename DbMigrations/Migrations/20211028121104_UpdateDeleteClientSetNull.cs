using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class UpdateDeleteClientSetNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidatesProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_CandidateSandboxes_CandidateSandboxId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_LanguageLevels_LanguageLevelsId",
                table: "UserLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSandBoxes_Users_UserEntityModelId",
                table: "UserSandBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTeams_UserSandBoxes_UserSandBoxEntityModelId",
                table: "UserTeams");

            migrationBuilder.DropIndex(
                name: "IX_UserTeams_UserSandBoxEntityModelId",
                table: "UserTeams");

            migrationBuilder.DropIndex(
                name: "IX_UserSandBoxes_UserEntityModelId",
                table: "UserSandBoxes");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguages_LanguageLevelsId",
                table: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CandidateSandboxId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_CandidatesProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "UserSandBoxEntityModelId",
                table: "UserTeams");

            migrationBuilder.DropColumn(
                name: "UserEntityModelId",
                table: "UserSandBoxes");

            migrationBuilder.DropColumn(
                name: "LanguageLevelsId",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "CandidateSandboxId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CandidatesProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageLevelId",
                table: "UserLanguages",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidateProccesId",
                table: "CandidateSandboxes",
                column: "CandidateProccesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProccesId",
                table: "CandidateSandboxes",
                column: "CandidateProccesId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_LanguageLevels_LanguageLevelId",
                table: "UserLanguages",
                column: "LanguageLevelId",
                principalTable: "LanguageLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLanguages_LanguageLevels_LanguageLevelId",
                table: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_UserLanguages_LanguageLevelId",
                table: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_CandidateProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.AddColumn<Guid>(
                name: "UserSandBoxEntityModelId",
                table: "UserTeams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserEntityModelId",
                table: "UserSandBoxes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LanguageLevelsId",
                table: "UserLanguages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateSandboxId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidatesProccesId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_UserSandBoxEntityModelId",
                table: "UserTeams",
                column: "UserSandBoxEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSandBoxes_UserEntityModelId",
                table: "UserSandBoxes",
                column: "UserEntityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageLevelsId",
                table: "UserLanguages",
                column: "LanguageLevelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CandidateSandboxId",
                table: "Teams",
                column: "CandidateSandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidatesProccesId",
                table: "CandidateSandboxes",
                column: "CandidatesProccesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidatesProccesId",
                table: "CandidateSandboxes",
                column: "CandidatesProccesId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_CandidateSandboxes_CandidateSandboxId",
                table: "Teams",
                column: "CandidateSandboxId",
                principalTable: "CandidateSandboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLanguages_LanguageLevels_LanguageLevelsId",
                table: "UserLanguages",
                column: "LanguageLevelsId",
                principalTable: "LanguageLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSandBoxes_Users_UserEntityModelId",
                table: "UserSandBoxes",
                column: "UserEntityModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTeams_UserSandBoxes_UserSandBoxEntityModelId",
                table: "UserTeams",
                column: "UserSandBoxEntityModelId",
                principalTable: "UserSandBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
