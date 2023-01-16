using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookProgram.Migrations
{
    public partial class OrderEdu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Hold_HoldID",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "HoldID",
                table: "Orders",
                newName: "EducationID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HoldID",
                table: "Orders",
                newName: "IX_Orders_EducationID");

            migrationBuilder.AlterColumn<string>(
                name: "OrderValue",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 4);

          

            

            

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Education_EducationID",
                table: "Orders",
                column: "EducationID",
                principalTable: "Education",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Education_EducationID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.RenameColumn(
                name: "EducationID",
                table: "Orders",
                newName: "HoldID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EducationID",
                table: "Orders",
                newName: "IX_Orders_HoldID");

            migrationBuilder.AlterColumn<int>(
                name: "OrderValue",
                table: "Orders",
                type: "int",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Hold_HoldID",
                table: "Orders",
                column: "HoldID",
                principalTable: "Hold",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
