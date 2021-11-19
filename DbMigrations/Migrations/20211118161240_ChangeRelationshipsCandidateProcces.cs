using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class ChangeRelationshipsCandidateProcces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProcessId",
                table: "CandidateSandboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                table: "CandidatesProcceses");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesProcceses_FeedbackId",
                table: "CandidatesProcceses");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_CandidateProcessId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "CandidatesProcceses");

            migrationBuilder.DropColumn(
                name: "CandidateProcessId",
                table: "CandidateSandboxes");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateProccesId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateSandboxId",
                table: "CandidatesProcceses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CandidateProccesId",
                table: "Feedbacks",
                column: "CandidateProccesId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProcceses_CandidateSandboxId",
                table: "CandidatesProcceses",
                column: "CandidateSandboxId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProcceses_CandidateSandboxes_CandidateSandboxId",
                table: "CandidatesProcceses",
                column: "CandidateSandboxId",
                principalTable: "CandidateSandboxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_CandidatesProcceses_CandidateProccesId",
                table: "Feedbacks",
                column: "CandidateProccesId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesProcceses_CandidateSandboxes_CandidateSandboxId",
                table: "CandidatesProcceses");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_CandidatesProcceses_CandidateProccesId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CandidateProccesId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_CandidatesProcceses_CandidateSandboxId",
                table: "CandidatesProcceses");

            migrationBuilder.DropColumn(
                name: "CandidateProccesId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CandidateSandboxId",
                table: "CandidatesProcceses");

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "CandidatesProcceses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateProcessId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CandidatesProcceses_FeedbackId",
                table: "CandidatesProcceses",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_CandidateProcessId",
                table: "CandidateSandboxes",
                column: "CandidateProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_CandidatesProcceses_CandidateProcessId",
                table: "CandidateSandboxes",
                column: "CandidateProcessId",
                principalTable: "CandidatesProcceses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesProcceses_Feedbacks_FeedbackId",
                table: "CandidatesProcceses",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
