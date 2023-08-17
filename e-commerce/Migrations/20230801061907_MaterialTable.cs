using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class MaterialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothColor_Color_ColorID",
                table: "ClothColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothColor_Product_ProductID",
                table: "ClothColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothColor_User_UserID",
                table: "ClothColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothSize_Product_ProductID",
                table: "ClothSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothSize_Size_SizeID",
                table: "ClothSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothSize",
                table: "ClothSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothColor",
                table: "ClothColor");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ClothSize",
                newName: "ProductSize");

            migrationBuilder.RenameTable(
                name: "ClothColor",
                newName: "ProductColor");

            migrationBuilder.RenameIndex(
                name: "IX_ClothSize_SizeID",
                table: "ProductSize",
                newName: "IX_ProductSize_SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_ClothSize_ProductID",
                table: "ProductSize",
                newName: "IX_ProductSize_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ClothColor_UserID",
                table: "ProductColor",
                newName: "IX_ProductColor_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ClothColor_ProductID",
                table: "ProductColor",
                newName: "IX_ProductColor_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ClothColor_ColorID",
                table: "ProductColor",
                newName: "IX_ProductColor_ColorID");

            migrationBuilder.AddColumn<int>(
                name: "MaterialID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_MaterialID",
                table: "Product",
                column: "MaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Material_MaterialID",
                table: "Product",
                column: "MaterialID",
                principalTable: "Material",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Color_ColorID",
                table: "ProductColor",
                column: "ColorID",
                principalTable: "Color",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Product_ProductID",
                table: "ProductColor",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_User_UserID",
                table: "ProductColor",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Product_ProductID",
                table: "ProductSize",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Size_SizeID",
                table: "ProductSize",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Material_MaterialID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Color_ColorID",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Product_ProductID",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_User_UserID",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Product_ProductID",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Size_SizeID",
                table: "ProductSize");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Product_MaterialID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSize",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductColor",
                table: "ProductColor");

            migrationBuilder.DropColumn(
                name: "MaterialID",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ProductSize",
                newName: "ClothSize");

            migrationBuilder.RenameTable(
                name: "ProductColor",
                newName: "ClothColor");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_SizeID",
                table: "ClothSize",
                newName: "IX_ClothSize_SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_ProductID",
                table: "ClothSize",
                newName: "IX_ClothSize_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_UserID",
                table: "ClothColor",
                newName: "IX_ClothColor_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_ProductID",
                table: "ClothColor",
                newName: "IX_ClothColor_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductColor_ColorID",
                table: "ClothColor",
                newName: "IX_ClothColor_ColorID");

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothSize",
                table: "ClothSize",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothColor",
                table: "ClothColor",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothColor_Color_ColorID",
                table: "ClothColor",
                column: "ColorID",
                principalTable: "Color",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothColor_Product_ProductID",
                table: "ClothColor",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothColor_User_UserID",
                table: "ClothColor",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothSize_Product_ProductID",
                table: "ClothSize",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothSize_Size_SizeID",
                table: "ClothSize",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
