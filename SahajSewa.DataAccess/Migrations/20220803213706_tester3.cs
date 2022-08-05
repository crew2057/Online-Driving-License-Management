using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class tester3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LicenseAvailability",
                table: "LicenseRegistrations",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicenseAvailability",
                table: "LicenseRegistrations");
        }
    }
}
