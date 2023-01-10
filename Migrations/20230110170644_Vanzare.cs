using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.Migrations
{
    public partial class Vanzare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vanzari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembruID = table.Column<int>(type: "int", nullable: true),
                    BijuterieID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanzari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vanzari_Bijuterie_BijuterieID",
                        column: x => x.BijuterieID,
                        principalTable: "Bijuterie",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vanzari_Membru_MembruID",
                        column: x => x.MembruID,
                        principalTable: "Membru",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vanzari_BijuterieID",
                table: "Vanzari",
                column: "BijuterieID");

            migrationBuilder.CreateIndex(
                name: "IX_Vanzari_MembruID",
                table: "Vanzari",
                column: "MembruID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vanzari");

            migrationBuilder.DropTable(
                name: "Membru");
        }
    }
}
