using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labote.Core.Migrations
{
    public partial class fsdfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "CargoDriverUsers");

            migrationBuilder.DropTable(
                name: "CargoSenderUsers");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CargoDriverUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LaboteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoDriverUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoDriverUsers_AspNetUsers_LaboteUserId",
                        column: x => x.LaboteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CargoSenderUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LaboteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoSenderUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CargoSenderUsers_AspNetUsers_LaboteUserId",
                        column: x => x.LaboteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    KmPrice = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoDriverUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CargoSendType = table.Column<int>(type: "int", nullable: false),
                    CargoSenderUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoStatusType = table.Column<int>(type: "int", nullable: false),
                    CargoType = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DelyveryDelayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelayDate = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsOneDirectory = table.Column<bool>(type: "bit", nullable: false),
                    OrdererName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RecieverAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecieverDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecieverLatitude = table.Column<long>(type: "bigint", nullable: false),
                    RecieverLongitude = table.Column<long>(type: "bigint", nullable: false),
                    RecieverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderLatitude = table.Column<long>(type: "bigint", nullable: false),
                    SenderLongitude = table.Column<long>(type: "bigint", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_CargoDriverUsers_CargoDriverUserId",
                        column: x => x.CargoDriverUserId,
                        principalTable: "CargoDriverUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cargos_CargoSenderUsers_CargoSenderUserId",
                        column: x => x.CargoSenderUserId,
                        principalTable: "CargoSenderUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargos_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CargoDriverUsers_LaboteUserId",
                table: "CargoDriverUsers",
                column: "LaboteUserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CargoSenderUsers_LaboteUserId",
                table: "CargoSenderUsers",
                column: "LaboteUserId");
        }
    }
}
