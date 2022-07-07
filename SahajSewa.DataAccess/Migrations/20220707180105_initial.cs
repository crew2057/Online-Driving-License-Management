using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahajSewa.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bgroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pprovince = table.Column<int>(type: "int", nullable: false),
                    Pdistrict = table.Column<int>(type: "int", nullable: false),
                    Pvillage = table.Column<int>(type: "int", nullable: false),
                    Pward = table.Column<int>(type: "int", nullable: false),
                    Ptole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tprovince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tdistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tvillage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tward = table.Column<int>(type: "int", nullable: false),
                    Ttole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficeProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenFront = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitizenBack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailCount = table.Column<int>(type: "int", nullable: false),
                    WrittenResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseId = table.Column<int>(type: "int", nullable: false),
                    PassportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseRegistrations_Districts_Pdistrict",
                        column: x => x.Pdistrict,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseRegistrations_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseRegistrations_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseRegistrations_Passports_PassportId",
                        column: x => x.PassportId,
                        principalTable: "Passports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseRegistrations_Provinces_Pprovince",
                        column: x => x.Pprovince,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseRegistrations_Villages_Pvillage",
                        column: x => x.Pvillage,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_LicenseId",
                table: "LicenseRegistrations",
                column: "LicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_OfficeId",
                table: "LicenseRegistrations",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_PassportId",
                table: "LicenseRegistrations",
                column: "PassportId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_Pdistrict",
                table: "LicenseRegistrations",
                column: "Pdistrict");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_Pprovince",
                table: "LicenseRegistrations",
                column: "Pprovince");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRegistrations_Pvillage",
                table: "LicenseRegistrations",
                column: "Pvillage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseRegistrations");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Villages");
        }
    }
}
