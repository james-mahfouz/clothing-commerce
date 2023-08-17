using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce.Migrations
{
    public partial class TableNameAdjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_ClothID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_UserID",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Cloth");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_UserID",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_ClothID",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_ClothID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cloth",
                table: "Cloth",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Cloth_ClothID",
                table: "ShoppingCart",
                column: "ClothID",
                principalTable: "Cloth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ShoppingCart_Cloth_ClothID",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_User_UserID",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cloth",
                table: "Cloth");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Cloth",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_UserID",
                table: "Enrollment",
                newName: "IX_Enrollment_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_ClothID",
                table: "Enrollment",
                newName: "IX_Enrollment_ClothID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_ClothID",
                table: "Enrollment",
                column: "ClothID",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_UserID",
                table: "Enrollment",
                column: "UserID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
