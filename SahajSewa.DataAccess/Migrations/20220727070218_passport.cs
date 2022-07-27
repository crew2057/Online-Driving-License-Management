using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class passport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicantId",
                table: "Passports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Passports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Passports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IssuingOffice",
                table: "Passports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportNo",
                table: "Passports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PersonalNo",
                table: "Passports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PassportAvailability",
                table: "LicenseRegistrations",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "IssuingOffice",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "PassportNo",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "PersonalNo",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "PassportAvailability",
                table: "LicenseRegistrations");
        }
    }
}
