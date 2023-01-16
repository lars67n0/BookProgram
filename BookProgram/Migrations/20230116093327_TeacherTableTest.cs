using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookProgram.Migrations
{
    public partial class TeacherTableTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Hold",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hold_TeacherID",
                table: "Hold",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hold_Teacher_TeacherID",
                table: "Hold",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hold_Teacher_TeacherID",
                table: "Hold");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Hold_TeacherID",
                table: "Hold");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Hold");
        }
    }
}
