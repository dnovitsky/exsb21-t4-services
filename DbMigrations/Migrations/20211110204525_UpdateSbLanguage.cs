using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class UpdateSbLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SandboxLanguages");

            migrationBuilder.DropColumn(
                name: "OrderLevel",
                table: "SandboxLanguages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SandboxLanguages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderLevel",
                table: "SandboxLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
