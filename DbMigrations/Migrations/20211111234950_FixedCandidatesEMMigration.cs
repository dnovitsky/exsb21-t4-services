using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class FixedCandidatesEMMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidateProjectRoles_CandidateProjectRoleId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                table: "CandidatesProcceses");

            migrationBuilder.AlterColumn<Guid>(
                name: "FeedbackId",
                table: "CandidatesProcceses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateProjectRoleId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidateProjectRoles_CandidateProjectRoleId",
                table: "CandidateSandboxes",
                column: "CandidateProjectRoleId",
                principalTable: "CandidateProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                table: "CandidatesProcceses",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidateProjectRoles_CandidateProjectRoleId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                table: "CandidatesProcceses");

            migrationBuilder.AlterColumn<Guid>(
                name: "FeedbackId",
                table: "CandidatesProcceses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TeamId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CandidateProjectRoleId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidateProjectRoles_CandidateProjectRoleId",
                table: "CandidateSandboxes",
                column: "CandidateProjectRoleId",
                principalTable: "CandidateProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                table: "CandidatesProcceses",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
