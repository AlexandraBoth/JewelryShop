using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.Migrations
{
    public partial class Colectie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColectieID",
                table: "Bijuterie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Colectie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colectie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bijuterie_ColectieID",
                table: "Bijuterie",
                column: "ColectieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bijuterie_Colectie_ColectieID",
                table: "Bijuterie",
                column: "ColectieID",
                principalTable: "Colectie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bijuterie_Colectie_ColectieID",
                table: "Bijuterie");

            migrationBuilder.DropTable(
                name: "Colectie");

            migrationBuilder.DropIndex(
                name: "IX_Bijuterie_ColectieID",
                table: "Bijuterie");

            migrationBuilder.DropColumn(
                name: "ColectieID",
                table: "Bijuterie");
        }
    }
}
