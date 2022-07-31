using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labote.Core.Migrations
{
    public partial class mmfsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisysRecordDeviceValues");

            migrationBuilder.DropTable(
                name: "AnalisysRecordSampleExaminationResultValues");

            migrationBuilder.DropTable(
                name: "Chemical");

            migrationBuilder.DropTable(
                name: "CurrentCustomerBankAccountInfos");

            migrationBuilder.DropTable(
                name: "CurrentCustomerContactInfos");

            migrationBuilder.DropTable(
                name: "DeviceResultValueSampleUnitReferences");

            migrationBuilder.DropTable(
                name: "LaboratoryDevices");

            migrationBuilder.DropTable(
                name: "LaboratoryUsers");

            migrationBuilder.DropTable(
                name: "SampleExaminationDevice");

            migrationBuilder.DropTable(
                name: "SampleExaminationPriceCurrencies");

            migrationBuilder.DropTable(
                name: "SampleExaminationSampleAccepts");

            migrationBuilder.DropTable(
                name: "DeviceResultValueTypes");

            migrationBuilder.DropTable(
                name: "AnalisysRecords");

            migrationBuilder.DropTable(
                name: "SampleExaminationResultValueTypes");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "AnalisysCreateRecords");

            migrationBuilder.DropTable(
                name: "SampleExaminations");

            migrationBuilder.DropTable(
                name: "SampleAccepts");

            migrationBuilder.DropTable(
                name: "CurrentCustomers");

            migrationBuilder.DropTable(
                name: "Laboratories");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleTypeId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CargoDriverUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaboteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    LaboteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "UserAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Langitude = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<long>(type: "bigint", nullable: false),
                    LaboteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddress_AspNetUsers_LaboteUserId",
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KmPrice = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    OrdererName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderLongitude = table.Column<long>(type: "bigint", nullable: false),
                    SenderLatitude = table.Column<long>(type: "bigint", nullable: false),
                    SenderDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecieverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecieverAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecieverLongitude = table.Column<long>(type: "bigint", nullable: false),
                    RecieverLatitude = table.Column<long>(type: "bigint", nullable: false),
                    RecieverDistrict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOneDirectory = table.Column<bool>(type: "bit", nullable: false),
                    DelyveryDelayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelayDate = table.Column<bool>(type: "bit", nullable: false),
                    CargoType = table.Column<int>(type: "int", nullable: false),
                    CargoSendType = table.Column<int>(type: "int", nullable: false),
                    CargoStatusType = table.Column<int>(type: "int", nullable: false),
                    CargoDriverUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CargoSenderUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VehicleTypeId",
                table: "AspNetUsers",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoDriverUsers_LaboteUserId",
                table: "CargoDriverUsers",
                column: "LaboteUserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CargoSenderUsers_LaboteUserId",
                table: "CargoSenderUsers",
                column: "LaboteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_LaboteUserId",
                table: "UserAddress",
                column: "LaboteUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_VehicleTypes_VehicleTypeId",
                table: "AspNetUsers",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_VehicleTypes_VehicleTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "CargoDriverUsers");

            migrationBuilder.DropTable(
                name: "CargoSenderUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VehicleTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CurrentCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LogoImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_UserTopics_UserTopicId",
                        column: x => x.UserTopicId,
                        principalTable: "UserTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratories_UserTopics_UserTopicId",
                        column: x => x.UserTopicId,
                        principalTable: "UserTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentCustomerBankAccountInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankMerchant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentCustomerBankAccountInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentCustomerBankAccountInfos_CurrentCustomers_CurrentCustomerId",
                        column: x => x.CurrentCustomerId,
                        principalTable: "CurrentCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentCustomerContactInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MailAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailAddress3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentCustomerContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentCustomerContactInfos_CurrentCustomers_CurrentCustomerId",
                        column: x => x.CurrentCustomerId,
                        principalTable: "CurrentCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceResultValueSampleUnitReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MeasureUnitSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasureUnitType = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementUnitLongName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceResultValueSampleUnitReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceResultValueSampleUnitReferences_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeviceResultValueTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MeasureUnitSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasureUnitType = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementUnitLongName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceResultValueTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceResultValueTypes_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chemical",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LaboratoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chemical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chemical_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LaboratoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryDevices_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryDevices_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LaboratoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LaboteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryUsers_AspNetUsers_LaboteUserId",
                        column: x => x.LaboteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryUsers_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SampleAccepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcceptedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmToGetLaboratoryUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveyToLaboratoeyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LaboratoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaboteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleAcceptBringingType = table.Column<int>(type: "int", nullable: false),
                    SampleAcceptPackaging = table.Column<int>(type: "int", nullable: false),
                    SampleAcceptStatus = table.Column<int>(type: "int", nullable: false),
                    SampleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleReturnType = table.Column<int>(type: "int", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleAccepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleAccepts_AspNetUsers_ConfirmToGetLaboratoryUserId",
                        column: x => x.ConfirmToGetLaboratoryUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleAccepts_AspNetUsers_LaboteUserId",
                        column: x => x.LaboteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleAccepts_CurrentCustomers_CurrentCustomerId",
                        column: x => x.CurrentCustomerId,
                        principalTable: "CurrentCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SampleAccepts_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SampleExaminations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LaboratoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleExaminations_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SampleExaminations_UserTopics_UserTopicId",
                        column: x => x.UserTopicId,
                        principalTable: "UserTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysCreateRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalysisStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    LaboteUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SampleAcceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysCreateRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysCreateRecords_AspNetUsers_LaboteUserId",
                        column: x => x.LaboteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalisysCreateRecords_SampleAccepts_SampleAcceptId",
                        column: x => x.SampleAcceptId,
                        principalTable: "SampleAccepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleExaminationDevice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    SampleExaminationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleExaminationDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleExaminationDevice_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SampleExaminationDevice_SampleExaminations_SampleExaminationId",
                        column: x => x.SampleExaminationId,
                        principalTable: "SampleExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleExaminationPriceCurrencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SampleExaminationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleExaminationPriceCurrencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleExaminationPriceCurrencies_SampleExaminations_SampleExaminationId",
                        column: x => x.SampleExaminationId,
                        principalTable: "SampleExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleExaminationResultValueTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    MeasureUnitSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasureUnitType = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementUnitLongName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleExaminationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleExaminationResultValueTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleExaminationResultValueTypes_SampleExaminations_SampleExaminationId",
                        column: x => x.SampleExaminationId,
                        principalTable: "SampleExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleExaminationSampleAccepts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    SampleAcceptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SampleExaminationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleExaminationSampleAccepts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleExaminationSampleAccepts_SampleAccepts_SampleAcceptId",
                        column: x => x.SampleAcceptId,
                        principalTable: "SampleAccepts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SampleExaminationSampleAccepts_SampleExaminations_SampleExaminationId",
                        column: x => x.SampleExaminationId,
                        principalTable: "SampleExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalisysCreateRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysRecords_AnalisysCreateRecords_AnalisysCreateRecordId",
                        column: x => x.AnalisysCreateRecordId,
                        principalTable: "AnalisysCreateRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysRecordDeviceValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalisysRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeviceResultValueTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    SampleExaminationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysRecordDeviceValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysRecordDeviceValues_AnalisysRecords_AnalisysRecordId",
                        column: x => x.AnalisysRecordId,
                        principalTable: "AnalisysRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalisysRecordDeviceValues_DeviceResultValueTypes_DeviceResultValueTypeId",
                        column: x => x.DeviceResultValueTypeId,
                        principalTable: "DeviceResultValueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalisysRecordDeviceValues_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnalisysRecordDeviceValues_SampleExaminations_SampleExaminationId",
                        column: x => x.SampleExaminationId,
                        principalTable: "SampleExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnalisysRecordSampleExaminationResultValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalisysRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    SampleExaminationResultValueTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisysRecordSampleExaminationResultValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalisysRecordSampleExaminationResultValues_AnalisysRecords_AnalisysRecordId",
                        column: x => x.AnalisysRecordId,
                        principalTable: "AnalisysRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalisysRecordSampleExaminationResultValues_SampleExaminationResultValueTypes_SampleExaminationResultValueTypeId",
                        column: x => x.SampleExaminationResultValueTypeId,
                        principalTable: "SampleExaminationResultValueTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysCreateRecords_LaboteUserId",
                table: "AnalisysCreateRecords",
                column: "LaboteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysCreateRecords_SampleAcceptId",
                table: "AnalisysCreateRecords",
                column: "SampleAcceptId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysRecordDeviceValues_AnalisysRecordId",
                table: "AnalisysRecordDeviceValues",
                column: "AnalisysRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysRecordDeviceValues_DeviceId",
                table: "AnalisysRecordDeviceValues",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysRecordDeviceValues_DeviceResultValueTypeId",
                table: "AnalisysRecordDeviceValues",
                column: "DeviceResultValueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysRecordDeviceValues_SampleExaminationId",
                table: "AnalisysRecordDeviceValues",
                column: "SampleExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysRecords_AnalisysCreateRecordId",
                table: "AnalisysRecords",
                column: "AnalisysCreateRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysRecordSampleExaminationResultValues_AnalisysRecordId",
                table: "AnalisysRecordSampleExaminationResultValues",
                column: "AnalisysRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalisysRecordSampleExaminationResultValues_SampleExaminationResultValueTypeId",
                table: "AnalisysRecordSampleExaminationResultValues",
                column: "SampleExaminationResultValueTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Chemical_LaboratoryId",
                table: "Chemical",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentCustomerBankAccountInfos_CurrentCustomerId",
                table: "CurrentCustomerBankAccountInfos",
                column: "CurrentCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentCustomerContactInfos_CurrentCustomerId",
                table: "CurrentCustomerContactInfos",
                column: "CurrentCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceResultValueSampleUnitReferences_DeviceId",
                table: "DeviceResultValueSampleUnitReferences",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceResultValueTypes_DeviceId",
                table: "DeviceResultValueTypes",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserTopicId",
                table: "Devices",
                column: "UserTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratories_UserTopicId",
                table: "Laboratories",
                column: "UserTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryDevices_DeviceId",
                table: "LaboratoryDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryDevices_LaboratoryId",
                table: "LaboratoryDevices",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryUsers_LaboratoryId",
                table: "LaboratoryUsers",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryUsers_LaboteUserId",
                table: "LaboratoryUsers",
                column: "LaboteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleAccepts_ConfirmToGetLaboratoryUserId",
                table: "SampleAccepts",
                column: "ConfirmToGetLaboratoryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleAccepts_CurrentCustomerId",
                table: "SampleAccepts",
                column: "CurrentCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleAccepts_LaboratoryId",
                table: "SampleAccepts",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleAccepts_LaboteUserId",
                table: "SampleAccepts",
                column: "LaboteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleExaminationDevice_DeviceId",
                table: "SampleExaminationDevice",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleExaminationDevice_SampleExaminationId",
                table: "SampleExaminationDevice",
                column: "SampleExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleExaminationPriceCurrencies_SampleExaminationId",
                table: "SampleExaminationPriceCurrencies",
                column: "SampleExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleExaminationResultValueTypes_SampleExaminationId",
                table: "SampleExaminationResultValueTypes",
                column: "SampleExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleExaminations_LaboratoryId",
                table: "SampleExaminations",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleExaminations_UserTopicId",
                table: "SampleExaminations",
                column: "UserTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleExaminationSampleAccepts_SampleAcceptId",
                table: "SampleExaminationSampleAccepts",
                column: "SampleAcceptId");

            migrationBuilder.CreateIndex(
                name: "IX_SampleExaminationSampleAccepts_SampleExaminationId",
                table: "SampleExaminationSampleAccepts",
                column: "SampleExaminationId");
        }
    }
}
