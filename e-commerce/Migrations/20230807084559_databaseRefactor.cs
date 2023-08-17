using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class databaseRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLook_Product_ProductID",
                table: "ProductLook");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Product_ClothID",
                table: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "ProductSizeColor");

            migrationBuilder.RenameColumn(
                name: "ClothID",
                table: "ShoppingCart",
                newName: "ProductStyleID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_ClothID",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_ProductStyleID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductLook",
                newName: "ProductStyleID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLook_ProductID",
                table: "ProductLook",
                newName: "IX_ProductLook_ProductStyleID");

            migrationBuilder.CreateTable(
                name: "ProductStyle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStyle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductStyle_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStyle_ProductID",
                table: "ProductStyle",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLook_ProductStyle_ProductStyleID",
                table: "ProductLook",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_ProductStyle_ProductStyleID",
                table: "ShoppingCart",
                column: "ProductStyleID",
                principalTable: "ProductStyle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLook_ProductStyle_ProductStyleID",
                table: "ProductLook");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_ProductStyle_ProductStyleID",
                table: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "ProductStyle");

            migrationBuilder.RenameColumn(
                name: "ProductStyleID",
                table: "ShoppingCart",
                newName: "ClothID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_ProductStyleID",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_ClothID");

            migrationBuilder.RenameColumn(
                name: "ProductStyleID",
                table: "ProductLook",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductLook_ProductStyleID",
                table: "ProductLook",
                newName: "IX_ProductLook_ProductID");

            migrationBuilder.CreateTable(
                name: "ProductSizeColor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizeColor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductSizeColor_Color_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizeColor_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizeColor_Size_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Size",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeColor_ColorID",
                table: "ProductSizeColor",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeColor_ProductID",
                table: "ProductSizeColor",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizeColor_SizeID",
                table: "ProductSizeColor",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLook_Product_ProductID",
                table: "ProductLook",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Product_ClothID",
                table: "ShoppingCart",
                column: "ClothID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
