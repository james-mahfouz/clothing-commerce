using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class SizeAndColorProductRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothColor_Product_ProductId",
                table: "ClothColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothSize_Product_ClothID",
                table: "ClothSize");

            migrationBuilder.DropColumn(
                name: "ClothID",
                table: "ClothColor");

            migrationBuilder.RenameColumn(
                name: "ClothID",
                table: "ClothSize",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ClothSize_ClothID",
                table: "ClothSize",
                newName: "IX_ClothSize_ProductID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ClothColor",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ClothColor_ProductId",
                table: "ClothColor",
                newName: "IX_ClothColor_ProductID");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    SubCategoryID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_SubCategory_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryID",
                table: "ProductCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductID",
                table: "ProductCategory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_SubCategoryID",
                table: "ProductCategory",
                column: "SubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothColor_Product_ProductID",
                table: "ClothColor",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothSize_Product_ProductID",
                table: "ClothSize",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothColor_Product_ProductID",
                table: "ClothColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothSize_Product_ProductID",
                table: "ClothSize");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ClothSize",
                newName: "ClothID");

            migrationBuilder.RenameIndex(
                name: "IX_ClothSize_ProductID",
                table: "ClothSize",
                newName: "IX_ClothSize_ClothID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ClothColor",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ClothColor_ProductID",
                table: "ClothColor",
                newName: "IX_ClothColor_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "ClothID",
                table: "ClothColor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothColor_Product_ProductId",
                table: "ClothColor",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothSize_Product_ClothID",
                table: "ClothSize",
                column: "ClothID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
