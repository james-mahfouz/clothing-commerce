using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class fixedcolorsandsizestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "ProductStyle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SizeID",
                table: "ProductStyle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductStyle_ColorID",
                table: "ProductStyle",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStyle_SizeID",
                table: "ProductStyle",
                column: "SizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStyle_Color_ColorID",
                table: "ProductStyle",
                column: "ColorID",
                principalTable: "Color",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStyle_Size_SizeID",
                table: "ProductStyle",
                column: "SizeID",
                principalTable: "Size",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStyle_Color_ColorID",
                table: "ProductStyle");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStyle_Size_SizeID",
                table: "ProductStyle");

            migrationBuilder.DropIndex(
                name: "IX_ProductStyle_ColorID",
                table: "ProductStyle");

            migrationBuilder.DropIndex(
                name: "IX_ProductStyle_SizeID",
                table: "ProductStyle");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "ProductStyle");

            migrationBuilder.DropColumn(
                name: "SizeID",
                table: "ProductStyle");

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorID = table.Column<int>(type: "int", nullable: false),
                    ProductStyleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductColor_Color_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Color",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColor_ProductStyle_ProductStyleID",
                        column: x => x.ProductStyleID,
                        principalTable: "ProductStyle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductStyleID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductSize_ProductStyle_ProductStyleID",
                        column: x => x.ProductStyleID,
                        principalTable: "ProductStyle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSize_Size_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Size",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ColorID",
                table: "ProductColor",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_ProductStyleID",
                table: "ProductColor",
                column: "ProductStyleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductStyleID",
                table: "ProductSize",
                column: "ProductStyleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_SizeID",
                table: "ProductSize",
                column: "SizeID");
        }
    }
}
