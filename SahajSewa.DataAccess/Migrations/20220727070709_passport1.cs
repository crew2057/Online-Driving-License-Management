using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class passport1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IssuingOffice",
                table: "Passports",
                newName: "IssueOffice");

            migrationBuilder.AddColumn<string>(
                name: "PassportPhoto",
                table: "Passports",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassportPhoto",
                table: "Passports");

            migrationBuilder.RenameColumn(
                name: "IssueOffice",
                table: "Passports",
                newName: "IssuingOffice");
        }
    }
}
