using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class CreateTableUserCandidateSandboxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCandidateSandboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateSandboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCandidateSandboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCandidateSandboxes_CandidateSandboxes_CandidateSandboxId",
                        column: x => x.CandidateSandboxId,
                        principalTable: "CandidateSandboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCandidateSandboxes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCandidateSandboxes_CandidateSandboxId",
                table: "UserCandidateSandboxes",
                column: "CandidateSandboxId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCandidateSandboxes_UserId",
                table: "UserCandidateSandboxes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCandidateSandboxes");
        }
    }
}
