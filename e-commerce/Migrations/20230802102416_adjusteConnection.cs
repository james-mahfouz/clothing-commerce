using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class adjusteConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_User_UserID",
                table: "ProductColor");

            migrationBuilder.DropIndex(
                name: "IX_ProductColor_UserID",
                table: "ProductColor");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ProductColor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "ProductColor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_UserID",
                table: "ProductColor",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_User_UserID",
                table: "ProductColor",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID");
        }
    }
}
