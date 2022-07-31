using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labote.Core.Migrations
{
    public partial class mmfsdffghf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_CargoSenderUsers_CargoSenderUserId",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_CargoDriverUserId",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_CargoSenderUserId",
                table: "Cargos");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleTypeId",
                table: "Cargos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_CargoDriverUserId",
                table: "Cargos",
                column: "CargoDriverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_CargoSenderUserId",
                table: "Cargos",
                column: "CargoSenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_VehicleTypeId",
                table: "Cargos",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_CargoSenderUsers_CargoSenderUserId",
                table: "Cargos",
                column: "CargoSenderUserId",
                principalTable: "CargoSenderUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_VehicleTypes_VehicleTypeId",
                table: "Cargos",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_CargoSenderUsers_CargoSenderUserId",
                table: "Cargos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_VehicleTypes_VehicleTypeId",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_CargoDriverUserId",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_CargoSenderUserId",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_VehicleTypeId",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Cargos");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_CargoDriverUserId",
                table: "Cargos",
                column: "CargoDriverUserId",
                unique: true,
                filter: "[CargoDriverUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_CargoSenderUserId",
                table: "Cargos",
                column: "CargoSenderUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_CargoSenderUsers_CargoSenderUserId",
                table: "Cargos",
                column: "CargoSenderUserId",
                principalTable: "CargoSenderUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
