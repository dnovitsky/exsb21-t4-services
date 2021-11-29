using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class UpdatedCalendarEventEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventMemberEntityModel_Events_EventId",
                table: "EventMemberEntityModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventMemberEntityModel",
                table: "EventMemberEntityModel");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "EventMemberEntityModel");

            migrationBuilder.DropColumn(
                name: "ResponseStatus",
                table: "EventMemberEntityModel");

            migrationBuilder.RenameTable(
                name: "EventMemberEntityModel",
                newName: "EventMembers");

            migrationBuilder.RenameIndex(
                name: "IX_EventMemberEntityModel_EventId",
                table: "EventMembers",
                newName: "IX_EventMembers_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventMembers",
                table: "EventMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventMembers_Events_EventId",
                table: "EventMembers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventMembers_Events_EventId",
                table: "EventMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventMembers",
                table: "EventMembers");

            migrationBuilder.RenameTable(
                name: "EventMembers",
                newName: "EventMemberEntityModel");

            migrationBuilder.RenameIndex(
                name: "IX_EventMembers_EventId",
                table: "EventMemberEntityModel",
                newName: "IX_EventMemberEntityModel_EventId");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "EventMemberEntityModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ResponseStatus",
                table: "EventMemberEntityModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventMemberEntityModel",
                table: "EventMemberEntityModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventMemberEntityModel_Events_EventId",
                table: "EventMemberEntityModel",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
