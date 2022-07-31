using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labote.Core.Migrations
{
    public partial class fsdfsyyy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_UserTopics_UserTopicId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserTopics_UserTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserTopics");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserTopicId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "UserTopicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserTopicId",
                table: "AspNetRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserTopicId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserTopicId",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTopics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTopicId",
                table: "AspNetUsers",
                column: "UserTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserTopicId",
                table: "AspNetRoles",
                column: "UserTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_UserTopics_UserTopicId",
                table: "AspNetRoles",
                column: "UserTopicId",
                principalTable: "UserTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserTopics_UserTopicId",
                table: "AspNetUsers",
                column: "UserTopicId",
                principalTable: "UserTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
