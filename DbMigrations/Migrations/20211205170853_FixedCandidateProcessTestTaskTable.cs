using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class FixedCandidateProcessTestTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateProccessTestTasksEntityModel");

            migrationBuilder.CreateTable(
                name: "CandidateProccessTestTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateResponseTestFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SendTestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkDownloadToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProccessTestTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateProccessTestTasks_CandidatesProcceses_CandidateProcessId",
                        column: x => x.CandidateProcessId,
                        principalTable: "CandidatesProcceses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateProccessTestTasks_Files_CandidateResponseTestFileId",
                        column: x => x.CandidateResponseTestFileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidateProccessTestTasks_Files_TestFileId",
                        column: x => x.TestFileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProccessTestTasks_CandidateProcessId",
                table: "CandidateProccessTestTasks",
                column: "CandidateProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProccessTestTasks_CandidateResponseTestFileId",
                table: "CandidateProccessTestTasks",
                column: "CandidateResponseTestFileId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateProccessTestTasks_TestFileId",
                table: "CandidateProccessTestTasks",
                column: "TestFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateProccessTestTasks");

            migrationBuilder.CreateTable(
                name: "CandidateProccessTestTasksEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateRequestTestFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndTestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LinkDownloadToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendTestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
    }
}
