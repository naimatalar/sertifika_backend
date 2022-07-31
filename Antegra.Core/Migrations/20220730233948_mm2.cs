using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labote.Core.Migrations
{
    public partial class mm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "UserMenuModules");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "UserAddress");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MenuModules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorUserId",
                table: "UserMenuModules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorUserId",
                table: "UserAddress",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorUserId",
                table: "MenuModules",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
