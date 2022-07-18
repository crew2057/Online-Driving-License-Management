using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class license1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_DrivingCategories_DrivingCategoryId",
                table: "Licenses");

            migrationBuilder.AlterColumn<int>(
                name: "DrivingCategoryId",
                table: "Licenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_DrivingCategories_DrivingCategoryId",
                table: "Licenses",
                column: "DrivingCategoryId",
                principalTable: "DrivingCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_DrivingCategories_DrivingCategoryId",
                table: "Licenses");

            migrationBuilder.AlterColumn<int>(
                name: "DrivingCategoryId",
                table: "Licenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_DrivingCategories_DrivingCategoryId",
                table: "Licenses",
                column: "DrivingCategoryId",
                principalTable: "DrivingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
