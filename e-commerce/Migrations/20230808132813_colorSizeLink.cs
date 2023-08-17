using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class colorSizeLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductStyleID",
                table: "ProductSize",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductStyleID",
                table: "ProductColor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductStyleID",
                table: "ProductSize",
                column: "ProductStyleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ProductStyleID",
                table: "ProductColor",
                column: "ProductStyleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_ProductStyle_ProductStyleID",
                table: "ProductColor",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_ProductStyle_ProductStyleID",
                table: "ProductSize",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_ProductStyle_ProductStyleID",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_ProductStyle_ProductStyleID",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductSize_ProductStyleID",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductColor_ProductStyleID",
                table: "ProductColor");

            migrationBuilder.DropColumn(
                name: "ProductStyleID",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "ProductStyleID",
                table: "ProductColor");
        }
    }
}
