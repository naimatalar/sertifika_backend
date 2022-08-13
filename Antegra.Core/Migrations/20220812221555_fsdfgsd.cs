using Microsoft.EntityFrameworkCore.Migrations;

namespace Labote.Core.Migrations
{
    public partial class fsdfgsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarcodeNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CertificaNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyPhone",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdentityNo",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarcodeNumber",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificaNumber",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPhone",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityNo",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
