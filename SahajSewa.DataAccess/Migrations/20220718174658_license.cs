using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class license : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Licenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DrivingCategoryId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "Licenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Licenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LicenseNo",
                table: "Licenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicensePhoto",
                table: "Licenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Licenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_DrivingCategoryId",
                table: "Licenses",
                column: "DrivingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_OfficeId",
                table: "Licenses",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_ProvinceId",
                table: "Licenses",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_DrivingCategories_DrivingCategoryId",
                table: "Licenses",
                column: "DrivingCategoryId",
                principalTable: "DrivingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Offices_OfficeId",
                table: "Licenses",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Provinces_ProvinceId",
                table: "Licenses",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_DrivingCategories_DrivingCategoryId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Offices_OfficeId",
                table: "Licenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Provinces_ProvinceId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_DrivingCategoryId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_OfficeId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_ProvinceId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "DrivingCategoryId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "LicenseNo",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "LicensePhoto",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Licenses");
        }
    }
}
