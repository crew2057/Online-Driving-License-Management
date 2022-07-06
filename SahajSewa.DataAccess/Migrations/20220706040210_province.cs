using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class province : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Zones_ZoneId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Zones_ZoneId",
                table: "Offices");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.RenameColumn(
                name: "ZoneId",
                table: "Offices",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Offices_ZoneId",
                table: "Offices",
                newName: "IX_Offices_ProvinceId");

            migrationBuilder.RenameColumn(
                name: "ZoneId",
                table: "Districts",
                newName: "ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_ZoneId",
                table: "Districts",
                newName: "IX_Districts_ProvinceId");

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Provinces_ProvinceId",
                table: "Districts",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Provinces_ProvinceId",
                table: "Offices",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Provinces_ProvinceId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Provinces_ProvinceId",
                table: "Offices");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "Offices",
                newName: "ZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_Offices_ProvinceId",
                table: "Offices",
                newName: "IX_Offices_ZoneId");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "Districts",
                newName: "ZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                newName: "IX_Districts_ZoneId");

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Zones_ZoneId",
                table: "Districts",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Zones_ZoneId",
                table: "Offices",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
