using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookProgram.Migrations
{
    public partial class Foreign_Keys_And_NewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeacherName",
                table: "Hold",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "Hold",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoldID = table.Column<int>(type: "int", nullable: false),
                    BookListID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_BookList_BookListID",
                        column: x => x.BookListID,
                        principalTable: "BookList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Hold_HoldID",
                        column: x => x.HoldID,
                        principalTable: "Hold",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hold_HoldID",
                table: "Hold",
                column: "HoldID");

            migrationBuilder.CreateIndex(
                name: "IX_BookList_BookListID",
                table: "BookList",
                column: "BookListID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookListID",
                table: "Orders",
                column: "BookListID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_HoldID",
                table: "Orders",
                column: "HoldID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookList_BookList_BookListID",
                table: "BookList");

            migrationBuilder.DropForeignKey(
                name: "FK_Hold_Hold_HoldID",
                table: "Hold");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Hold_HoldID",
                table: "Hold");

            migrationBuilder.DropIndex(
                name: "IX_BookList_BookListID",
                table: "BookList");

            migrationBuilder.DropColumn(
                name: "HoldID",
                table: "Hold");

            migrationBuilder.DropColumn(
                name: "BookListID",
                table: "BookList");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherName",
                table: "Hold",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "Hold",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }
    }
}
