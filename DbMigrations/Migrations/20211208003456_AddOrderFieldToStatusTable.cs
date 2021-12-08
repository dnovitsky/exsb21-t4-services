using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class AddOrderFieldToStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderLevel",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderLevel",
                table: "Statuses");
        }
    }
}
