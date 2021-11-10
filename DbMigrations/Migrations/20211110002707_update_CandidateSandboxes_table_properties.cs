using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class update_CandidateSandboxes_table_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_StackTechnologies_StackTechnologiesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_CandidateProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_StackTechnologiesId",
                table: "CandidateSandboxes");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateProcessId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StackTechnologyId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidateProcessId",
                table: "CandidateSandboxes",
                column: "CandidateProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_StackTechnologyId",
                table: "CandidateSandboxes",
                column: "StackTechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProcessId",
                table: "CandidateSandboxes",
                column: "CandidateProcessId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_StackTechnologies_StackTechnologyId",
                table: "CandidateSandboxes",
                column: "StackTechnologyId",
                principalTable: "StackTechnologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProcessId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_StackTechnologies_StackTechnologyId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_CandidateProcessId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_StackTechnologyId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "CandidateProcessId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "StackTechnologyId",
                table: "CandidateSandboxes");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidateProccesId",
                table: "CandidateSandboxes",
                column: "CandidateProccesId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_StackTechnologiesId",
                table: "CandidateSandboxes",
                column: "StackTechnologiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProccesId",
                table: "CandidateSandboxes",
                column: "CandidateProccesId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_StackTechnologies_StackTechnologiesId",
                table: "CandidateSandboxes",
                column: "StackTechnologiesId",
                principalTable: "StackTechnologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
