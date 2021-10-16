using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEFMig1.Migrations
{
    public partial class AddUniversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnivId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UnivId",
                table: "Students",
                column: "UnivId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Universities_UnivId",
                table: "Students",
                column: "UnivId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Universities_UnivId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Students_UnivId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UnivId",
                table: "Students");
        }
    }
}
