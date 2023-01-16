using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookProgram.Migrations
{
    public partial class HoldFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Hold");

            migrationBuilder.AddColumn<int>(
                name: "EducationID",
                table: "Hold",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hold_EducationID",
                table: "Hold",
                column: "EducationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hold_Education_EducationID",
                table: "Hold",
                column: "EducationID",
                principalTable: "Education",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hold_Education_EducationID",
                table: "Hold");

            migrationBuilder.DropIndex(
                name: "IX_Hold_EducationID",
                table: "Hold");

            migrationBuilder.DropColumn(
                name: "EducationID",
                table: "Hold");

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Hold",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
