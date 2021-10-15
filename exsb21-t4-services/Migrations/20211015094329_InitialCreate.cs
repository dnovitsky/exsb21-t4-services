using Microsoft.EntityFrameworkCore.Migrations;

namespace exsb21_t4_services.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "migrationCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_migrationCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "migrationRegions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_migrationRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_migrationRegions_migrationCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "migrationCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_migrationRegions_CountryId",
                table: "migrationRegions",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "migrationRegions");

            migrationBuilder.DropTable(
                name: "migrationCountries");
        }
    }
}
