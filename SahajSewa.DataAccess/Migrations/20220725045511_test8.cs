using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class test8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Licenses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_UserId",
                table: "Licenses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_AspNetUsers_UserId",
                table: "Licenses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_AspNetUsers_UserId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_UserId",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Licenses");
        }
    }
}
