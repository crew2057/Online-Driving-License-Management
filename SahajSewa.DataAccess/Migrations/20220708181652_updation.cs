using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class updation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_Offices_OfficeId",
                table: "LicenseRegistrations");

            migrationBuilder.RenameColumn(
                name: "OfficeId",
                table: "LicenseRegistrations",
                newName: "OfficeVisit");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseRegistrations_OfficeId",
                table: "LicenseRegistrations",
                newName: "IX_LicenseRegistrations_OfficeVisit");

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "LicenseRegistrations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DrivingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_Category",
                table: "LicenseRegistrations",
                column: "Category");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseRegistrations_DrivingCategories_Category",
                table: "LicenseRegistrations",
                column: "Category",
                principalTable: "DrivingCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseRegistrations_Offices_OfficeVisit",
                table: "LicenseRegistrations",
                column: "OfficeVisit",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_DrivingCategories_Category",
                table: "LicenseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_Offices_OfficeVisit",
                table: "LicenseRegistrations");

            migrationBuilder.DropTable(
                name: "DrivingCategories");

            migrationBuilder.DropIndex(
                name: "IX_LicenseRegistrations_Category",
                table: "LicenseRegistrations");

            migrationBuilder.RenameColumn(
                name: "OfficeVisit",
                table: "LicenseRegistrations",
                newName: "OfficeId");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseRegistrations_OfficeVisit",
                table: "LicenseRegistrations",
                newName: "IX_LicenseRegistrations_OfficeId");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "LicenseRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseRegistrations_Offices_OfficeId",
                table: "LicenseRegistrations",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
