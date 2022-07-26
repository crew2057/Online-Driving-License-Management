using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Licenses_LicenseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Passports_PassportId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LicenseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PassportId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantId",
                table: "LicenseRegistrations",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "LicenseRegistrations");

            migrationBuilder.DropColumn(
                name: "License",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LicenseRegistration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "LicenseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassportId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LicenseId",
                table: "AspNetUsers",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PassportId",
                table: "AspNetUsers",
                column: "PassportId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Licenses_LicenseId",
                table: "AspNetUsers",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Passports_PassportId",
                table: "AspNetUsers",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id");
        }
    }
}
