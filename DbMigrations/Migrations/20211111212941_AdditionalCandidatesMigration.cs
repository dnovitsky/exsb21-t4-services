using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class AdditionalCandidatesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "Education",
                table: "Candidates",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "CurrentJob",
                table: "CandidateSandboxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAgreement",
                table: "CandidateSandboxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsJoinToExadel",
                table: "CandidateSandboxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Motivation",
                table: "CandidateSandboxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SandboxLanguageId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TimeContact",
                table: "CandidateSandboxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalSkills",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessionaCertificates",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentJob",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "IsAgreement",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "IsJoinToExadel",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "Motivation",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "SandboxLanguageId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "TimeContact",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "AdditionalSkills",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "ProfessionaCertificates",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Candidates",
                newName: "Education");

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
