using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class AddCandidateProccessTestTasksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateProccessTestTasksEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateRequestTestFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SendTestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkDownloadToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProccessTestTasksEntityModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateProccessTestTasksEntityModel_CandidatesProcceses_CandidateProcessId",
                        column: x => x.CandidateProcessId,
                        principalTable: "CandidatesProcceses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateProccessTestTasksEntityModel_Files_CandidateRequestTestFileId",
                        column: x => x.CandidateRequestTestFileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateProccessTestTasksEntityModel_Files_TestFileId",
                        column: x => x.TestFileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProccessTestTasksEntityModel_CandidateProcessId",
                table: "CandidateProccessTestTasksEntityModel",
                column: "CandidateProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProccessTestTasksEntityModel_CandidateRequestTestFileId",
                table: "CandidateProccessTestTasksEntityModel",
                column: "CandidateRequestTestFileId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProccessTestTasksEntityModel_TestFileId",
                table: "CandidateProccessTestTasksEntityModel",
                column: "TestFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateProccessTestTasksEntityModel");
        }
    }
}
