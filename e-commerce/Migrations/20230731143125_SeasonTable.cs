using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class SeasonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "SeasonID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_SeasonID",
                table: "Product",
                column: "SeasonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Season_SeasonID",
                table: "Product",
                column: "SeasonID",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Season_SeasonID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropIndex(
                name: "IX_Product_SeasonID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SeasonID",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
