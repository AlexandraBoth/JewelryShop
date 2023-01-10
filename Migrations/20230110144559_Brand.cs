using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.Migrations
{
    public partial class Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Bijuterie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bijuterie_BrandID",
                table: "Bijuterie",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bijuterie_Brand_BrandID",
                table: "Bijuterie",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bijuterie_Brand_BrandID",
                table: "Bijuterie");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Bijuterie_BrandID",
                table: "Bijuterie");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Bijuterie");
        }
    }
}
