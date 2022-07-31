using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labote.Core.Migrations
{
    public partial class phoneconfirm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VehicleTypes_VehicleTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_VehicleTypes_VehicleTypeId",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VehicleTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleTypeId",
                table: "Cargos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneConfirmCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_VehicleTypes_VehicleTypeId",
                table: "Cargos",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_VehicleTypes_VehicleTypeId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "PhoneConfirmCode",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "VehicleTypeId",
                table: "Cargos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleTypeId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VehicleTypeId",
                table: "AspNetUsers",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VehicleTypes_VehicleTypeId",
                table: "AspNetUsers",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_VehicleTypes_VehicleTypeId",
                table: "Cargos",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
