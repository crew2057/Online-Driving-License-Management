using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class license2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_DrivingCategories_DrivingCategoryId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_DrivingCategoryId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "DrivingCategoryId",
                table: "Licenses");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_CategoryId",
                table: "Licenses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_DrivingCategories_CategoryId",
                table: "Licenses",
                column: "CategoryId",
                principalTable: "DrivingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_DrivingCategories_CategoryId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_CategoryId",
                table: "Licenses");

            migrationBuilder.AddColumn<int>(
                name: "DrivingCategoryId",
                table: "Licenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_DrivingCategoryId",
                table: "Licenses",
                column: "DrivingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_DrivingCategories_DrivingCategoryId",
                table: "Licenses",
                column: "DrivingCategoryId",
                principalTable: "DrivingCategories",
                principalColumn: "Id");
        }
    }
}
