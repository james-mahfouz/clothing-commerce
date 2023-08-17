using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class ProductRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothColor_Cloth_ClothID",
                table: "ClothColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothSize_Cloth_ClothID",
                table: "ClothSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Cloth_ClothID",
                table: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Cloth");

            migrationBuilder.DropIndex(
                name: "IX_ClothColor_ClothID",
                table: "ClothColor");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ClothColor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Look = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    New = table.Column<bool>(type: "bit", nullable: false),
                    Sale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothColor_ProductId",
                table: "ClothColor",
                column: "ProductId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Product_ClothID",
                table: "ShoppingCart",
                column: "ClothID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClothColor_Product_ProductId",
                table: "ClothColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ClothSize_Product_ClothID",
                table: "ClothSize");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Product_ClothID",
                table: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_ClothColor_ProductId",
                table: "ClothColor");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ClothColor");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cloth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Look = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    New = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sale = table.Column<bool>(type: "bit", nullable: false),
                    Season = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cloth", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClothColor_ClothID",
                table: "ClothColor",
                column: "ClothID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClothColor_Cloth_ClothID",
                table: "ClothColor",
                column: "ClothID",
                principalTable: "Cloth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClothSize_Cloth_ClothID",
                table: "ClothSize",
                column: "ClothID",
                principalTable: "Cloth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Cloth_ClothID",
                table: "ShoppingCart",
                column: "ClothID",
                principalTable: "Cloth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
