using Microsoft.EntityFrameworkCore.Migrations;

namespace Fruitify.Data.Migrations
{
    public partial class ProductPromoPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PromoPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromoPrice",
                table: "Products");
        }
    }
}
