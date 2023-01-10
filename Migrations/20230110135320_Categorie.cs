using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.Migrations
{
    public partial class Categorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "Bijuterie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categorii = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bijuterie_CategorieID",
                table: "Bijuterie",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bijuterie_Categorie_CategorieID",
                table: "Bijuterie",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bijuterie_Categorie_CategorieID",
                table: "Bijuterie");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Bijuterie_CategorieID",
                table: "Bijuterie");

            migrationBuilder.DropColumn(
                name: "CategorieID",
                table: "Bijuterie");
        }
    }
}
