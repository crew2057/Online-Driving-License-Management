using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class tester2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "LicenseRegistrations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_ApplicantId",
                table: "LicenseRegistrations",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseRegistrations_AspNetUsers_ApplicantId",
                table: "LicenseRegistrations",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_AspNetUsers_ApplicantId",
                table: "LicenseRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_LicenseRegistrations_ApplicantId",
                table: "LicenseRegistrations");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "LicenseRegistrations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
