using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class tester8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailResult",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WrittenResult",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TrailResult",
                table: "LicenseRegistrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WrittenResult",
                table: "LicenseRegistrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrailResult",
                table: "LicenseRegistrations");

            migrationBuilder.DropColumn(
                name: "WrittenResult",
                table: "LicenseRegistrations");

            migrationBuilder.AddColumn<string>(
                name: "TrailResult",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WrittenResult",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
