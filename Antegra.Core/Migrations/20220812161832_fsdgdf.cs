using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labote.Core.Migrations
{
    public partial class fsdgdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddress_AspNetUsers_LaboteUserId",
                table: "UserAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress");

            migrationBuilder.RenameTable(
                name: "UserAddress",
                newName: "UserAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddress_LaboteUserId",
                table: "UserAddresses",
                newName: "IX_UserAddresses_LaboteUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarcodeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificaNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    Statu = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentFiles_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFiles_DocumentId",
                table: "DocumentFiles",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CompanyId",
                table: "Documents",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PersonId",
                table: "Documents",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProductId",
                table: "Documents",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_AspNetUsers_LaboteUserId",
                table: "UserAddresses",
                column: "LaboteUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_AspNetUsers_LaboteUserId",
                table: "UserAddresses");

            migrationBuilder.DropTable(
                name: "DocumentFiles");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAddresses",
                table: "UserAddresses");

            migrationBuilder.RenameTable(
                name: "UserAddresses",
                newName: "UserAddress");

            migrationBuilder.RenameIndex(
                name: "IX_UserAddresses_LaboteUserId",
                table: "UserAddress",
                newName: "IX_UserAddress_LaboteUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAddress",
                table: "UserAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddress_AspNetUsers_LaboteUserId",
                table: "UserAddress",
                column: "LaboteUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
