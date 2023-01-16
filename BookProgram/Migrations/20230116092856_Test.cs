using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookProgram.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookList_BookList_BookListID",
                table: "BookList");

            migrationBuilder.DropForeignKey(
                name: "FK_Hold_Hold_HoldID",
                table: "Hold");

            migrationBuilder.DropIndex(
                name: "IX_Hold_HoldID",
                table: "Hold");

            migrationBuilder.DropIndex(
                name: "IX_BookList_BookListID",
                table: "BookList");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "HoldID",
                table: "Hold");

            migrationBuilder.DropColumn(
                name: "BookListID",
                table: "BookList");

            migrationBuilder.AddColumn<int>(
                name: "OrderValue",
                table: "Orders",
                type: "int",
                maxLength: 4,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderValue",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HoldID",
                table: "Hold",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookListID",
                table: "BookList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hold_HoldID",
                table: "Hold",
                column: "HoldID");

            migrationBuilder.CreateIndex(
                name: "IX_BookList_BookListID",
                table: "BookList",
                column: "BookListID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookList_BookList_BookListID",
                table: "BookList",
                column: "BookListID",
                principalTable: "BookList",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hold_Hold_HoldID",
                table: "Hold",
                column: "HoldID",
                principalTable: "Hold",
                principalColumn: "ID");
        }
    }
}
