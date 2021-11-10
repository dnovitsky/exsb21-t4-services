using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class update_CandidateSandboxes_table_key_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProcessId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_StackTechnologies_StackTechnologyId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "CandidateProccesId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "StackTechnologiesId",
                table: "CandidateSandboxes");

            migrationBuilder.AlterColumn<Guid>(
                name: "StackTechnologyId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateProcessId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProcessId",
                table: "CandidateSandboxes",
                column: "CandidateProcessId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_StackTechnologies_StackTechnologyId",
                table: "CandidateSandboxes",
                column: "StackTechnologyId",
                principalTable: "StackTechnologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProcessId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_StackTechnologies_StackTechnologyId",
                table: "CandidateSandboxes");

            migrationBuilder.AlterColumn<Guid>(
                name: "StackTechnologyId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateProcessId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateProccesId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StackTechnologiesId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
