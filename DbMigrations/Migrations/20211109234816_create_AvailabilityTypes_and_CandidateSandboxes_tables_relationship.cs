using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class create_AvailabilityTypes_and_CandidateSandboxes_tables_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AvailabilityTypeId",
                table: "CandidateSandboxes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSandboxes_AvailabilityTypeId",
                table: "CandidateSandboxes",
                column: "AvailabilityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSandboxes_AvailabilityTypes_AvailabilityTypeId",
                table: "CandidateSandboxes",
                column: "AvailabilityTypeId",
                principalTable: "AvailabilityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSandboxes_AvailabilityTypes_AvailabilityTypeId",
                table: "CandidateSandboxes");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSandboxes_AvailabilityTypeId",
                table: "CandidateSandboxes");

            migrationBuilder.DropColumn(
                name: "AvailabilityTypeId",
                table: "CandidateSandboxes");
        }
    }
}
