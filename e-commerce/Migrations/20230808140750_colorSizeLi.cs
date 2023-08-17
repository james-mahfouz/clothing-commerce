using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class colorSizeLi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLook_ProductStyle_ProductStyleID",
                table: "ProductLook");

            migrationBuilder.RenameColumn(
                name: "ProductStyleID",
                table: "ProductLook",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLook_ProductStyleID",
                table: "ProductLook",
                newName: "IX_ProductLook_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLook_Product_ProductID",
                table: "ProductLook",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLook_Product_ProductID",
                table: "ProductLook");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductLook",
                newName: "ProductStyleID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLook_ProductID",
                table: "ProductLook",
                newName: "IX_ProductLook_ProductStyleID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLook_ProductStyle_ProductStyleID",
                table: "ProductLook",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
