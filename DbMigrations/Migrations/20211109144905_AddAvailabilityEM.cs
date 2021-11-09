using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class AddAvailabilityEM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_AvailabilityEntityModel_AvailabilityId",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailabilityEntityModel",
                table: "AvailabilityEntityModel");

            migrationBuilder.RenameTable(
                name: "AvailabilityEntityModel",
                newName: "Availabilities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Availabilities",
                table: "Availabilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Availabilities_AvailabilityId",
                table: "Candidates",
                column: "AvailabilityId",
                principalTable: "Availabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Availabilities_AvailabilityId",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Availabilities",
                table: "Availabilities");

            migrationBuilder.RenameTable(
                name: "Availabilities",
                newName: "AvailabilityEntityModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailabilityEntityModel",
                table: "AvailabilityEntityModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_AvailabilityEntityModel_AvailabilityId",
                table: "Candidates",
                column: "AvailabilityId",
                principalTable: "AvailabilityEntityModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
