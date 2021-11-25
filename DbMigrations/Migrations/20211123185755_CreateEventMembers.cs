using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class CreateEventMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_InterviewerId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "InterviewerId",
                table: "Events",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_InterviewerId",
                table: "Events",
                newName: "IX_Events_OwnerId");

            migrationBuilder.CreateTable(
                name: "EventMemberEntityModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMemberEntityModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventMemberEntityModel_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventMemberEntityModel_EventId",
                table: "EventMemberEntityModel",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_OwnerId",
                table: "Events",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_OwnerId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventMemberEntityModel");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Events",
                newName: "InterviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_OwnerId",
                table: "Events",
                newName: "IX_Events_InterviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_InterviewerId",
                table: "Events",
                column: "InterviewerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
