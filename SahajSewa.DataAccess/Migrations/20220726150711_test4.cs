using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "License",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LicenseRegistration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "License",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LicenseRegistration",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Passport",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }
    }
}
