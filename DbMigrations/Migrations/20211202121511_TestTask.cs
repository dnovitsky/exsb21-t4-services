using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class TestTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StackTechnologyId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestTaskType",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Files_StackTechnologyId",
                table: "Files",
                column: "StackTechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_StackTechnologies_StackTechnologyId",
                table: "Files",
                column: "StackTechnologyId",
                principalTable: "StackTechnologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_StackTechnologies_StackTechnologyId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_StackTechnologyId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "StackTechnologyId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "TestTaskType",
                table: "Files");
        }
    }
}
