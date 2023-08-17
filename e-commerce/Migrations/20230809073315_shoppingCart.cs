using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class shoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Order_OrderID",
                table: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "ShoppingCart",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_OrderID",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_User_UserID",
                table: "ShoppingCart",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_User_UserID",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "ShoppingCart",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_UserID",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_OrderID");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    isBought = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Order_OrderID",
                table: "ShoppingCart",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
