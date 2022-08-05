using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LicenseRegistrationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LicenseRegistrationId",
                table: "AspNetUsers",
                column: "LicenseRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LicenseRegistrations_LicenseRegistrationId",
                table: "AspNetUsers",
                column: "LicenseRegistrationId",
                principalTable: "LicenseRegistrations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LicenseRegistrations_LicenseRegistrationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LicenseRegistrationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LicenseRegistrationId",
                table: "AspNetUsers");
        }
    }
}
