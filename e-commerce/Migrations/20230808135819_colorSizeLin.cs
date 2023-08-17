using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class colorSizeLin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Product_ProductID",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_ProductStyle_ProductStyleID",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Product_ProductID",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_ProductStyle_ProductStyleID",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductSize_ProductID",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductColor_ProductID",
                table: "ProductColor");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductStyle");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ProductStyle");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProductColor");

            migrationBuilder.AlterColumn<int>(
                name: "ProductStyleID",
                table: "ProductSize",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductStyleID",
                table: "ProductColor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_ProductStyle_ProductStyleID",
                table: "ProductColor",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_ProductStyle_ProductStyleID",
                table: "ProductSize",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_ProductStyle_ProductStyleID",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_ProductStyle_ProductStyleID",
                table: "ProductSize");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ProductStyle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "ProductStyle",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductStyleID",
                table: "ProductSize",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ProductSize",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductStyleID",
                table: "ProductColor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ProductColor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductID",
                table: "ProductSize",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ProductID",
                table: "ProductColor",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Product_ProductID",
                table: "ProductColor",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_ProductStyle_ProductStyleID",
                table: "ProductColor",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Product_ProductID",
                table: "ProductSize",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_ProductStyle_ProductStyleID",
                table: "ProductSize",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID");
        }
    }
}
