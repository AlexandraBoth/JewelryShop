using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.Migrations
{
    public partial class CategorieNume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categorii",
                table: "Categorie",
                newName: "CategorieNume");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategorieNume",
                table: "Categorie",
                newName: "Categorii");
        }
    }
}
