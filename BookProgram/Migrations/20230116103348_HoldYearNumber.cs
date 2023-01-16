using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookProgram.Migrations
{
    public partial class HoldYearNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "Semester",
                 columns: table => new
                 {
                     ID = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     EducationID = table.Column<int>(type: "int", nullable: false),
                     TeacherID = table.Column<int>(type: "int", nullable: false),
                     ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                     SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Semester", x => x.ID);
                     table.ForeignKey(
                         name: "FK_Semester_Education_EducationID",
                         column: x => x.EducationID,
                         principalTable: "Education",
                         principalColumn: "ID",
                         onDelete: ReferentialAction.Cascade);
                     table.ForeignKey(
                         name: "FK_Semester_Teacher_TeacherID",
                         column: x => x.TeacherID,
                         principalTable: "Teacher",
                         principalColumn: "ID",
                         onDelete: ReferentialAction.Cascade);
                 });

            migrationBuilder.CreateIndex(
                name: "IX_Semester_EducationID",
                table: "Semester",
                column: "EducationID");

            migrationBuilder.CreateIndex(
                name: "IX_Semester_TeacherID",
                table: "Semester",
                column: "TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
