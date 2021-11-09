using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class AddAvailabilityEM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AvailabilityId",
                table: "Candidates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AvailabilityEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityEntityModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_AvailabilityId",
                table: "Candidates",
                column: "AvailabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AvailabilityEntityModel_AvailabilityId",
                table: "Candidates",
                column: "AvailabilityId",
                principalTable: "AvailabilityEntityModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AvailabilityEntityModel_AvailabilityId",
                table: "Candidates");

            migrationBuilder.DropTable(
                name: "AvailabilityEntityModel");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_AvailabilityId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "AvailabilityId",
                table: "Candidates");
        }
    }
}
