using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class test9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_Licenses_LicenseId",
                table: "LicenseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseRegistrations_Passports_PassportId",
                table: "LicenseRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_AspNetUsers_UserId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_Licenses_UserId",
                table: "Licenses");

            migrationBuilder.DropIndex(
                name: "IX_LicenseRegistrations_LicenseId",
                table: "LicenseRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_LicenseRegistrations_PassportId",
                table: "LicenseRegistrations");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "LicenseRegistrations");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "LicenseRegistrations");

            migrationBuilder.DropColumn(
                name: "TrailResult",
                table: "LicenseRegistrations");

            migrationBuilder.DropColumn(
                name: "WrittenResult",
                table: "LicenseRegistrations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Licenses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LicenseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassportId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "CheckBoxVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    LicenseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBoxVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckBoxVM_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LicenseId",
                table: "AspNetUsers",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PassportId",
                table: "AspNetUsers",
                column: "PassportId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBoxVM_LicenseId",
                table: "CheckBoxVM",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Licenses_LicenseId",
                table: "AspNetUsers",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Passports_PassportId",
                table: "AspNetUsers",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Licenses_LicenseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Passports_PassportId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CheckBoxVM");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LicenseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PassportId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LicenseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrailResult",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WrittenResult",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Licenses",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LicenseId",
                table: "LicenseRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassportId",
                table: "LicenseRegistrations",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Licenses_UserId",
                table: "Licenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_LicenseId",
                table: "LicenseRegistrations",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_PassportId",
                table: "LicenseRegistrations",
                column: "PassportId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_AspNetUsers_UserId",
                table: "Licenses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
