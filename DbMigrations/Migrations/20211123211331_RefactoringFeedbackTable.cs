using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class RefactoringFeedbackTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Ratings_RatingId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_RatingId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "RatingId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_RatingId",
                table: "Feedbacks",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SkillId",
                table: "Ratings",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Ratings_RatingId",
                table: "Feedbacks",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
