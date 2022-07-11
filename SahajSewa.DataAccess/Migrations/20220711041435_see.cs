using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class see : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_Licenses_LicenseId",
                table: "LicenseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_Passports_PassportId",
                table: "LicenseRegistrations");

            migrationBuilder.AlterColumn<int>(
                name: "PassportId",
                table: "LicenseRegistrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LicenseId",
                table: "LicenseRegistrations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseRegistrations_Licenses_LicenseId",
                table: "LicenseRegistrations",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseRegistrations_Passports_PassportId",
                table: "LicenseRegistrations",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_Licenses_LicenseId",
                table: "LicenseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_Passports_PassportId",
                table: "LicenseRegistrations");

            migrationBuilder.AlterColumn<int>(
                name: "PassportId",
                table: "LicenseRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LicenseId",
                table: "LicenseRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseRegistrations_Licenses_LicenseId",
                table: "LicenseRegistrations",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseRegistrations_Passports_PassportId",
                table: "LicenseRegistrations",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
