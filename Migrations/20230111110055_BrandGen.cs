using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.Migrations
{
    public partial class BrandGen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gen",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gen",
                table: "Brand");
        }
    }
}
