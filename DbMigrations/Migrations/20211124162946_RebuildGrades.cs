using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class RebuildGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminGrade",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "InterviewerGrade",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "MentoreGrade",
                table: "Feedbacks");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Feedbacks");

            migrationBuilder.AddColumn<int>(
                name: "AdminGrade",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewerGrade",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentoreGrade",
                table: "Feedbacks",
                type: "int",
                nullable: true);
        }
    }
}
