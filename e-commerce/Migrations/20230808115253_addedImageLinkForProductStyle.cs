using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class addedImageLinkForProductStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageLink",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageLink",
                table: "ProductStyle",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageLink",
                table: "ProductStyle");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageLink",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
