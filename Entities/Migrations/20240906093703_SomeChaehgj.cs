using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class SomeChaehgj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Embellish_EmbellishTypes_EmbellishTypeId",
                table: "Embellish");

            migrationBuilder.RenameColumn(
                name: "EmbellishTypeId",
                table: "Embellish",
                newName: "EmblishTypeId");

            migrationBuilder.RenameColumn(
                name: "EmbelishName",
                table: "Embellish",
                newName: "EmblishName");

            migrationBuilder.RenameColumn(
                name: "EmbellishId",
                table: "Embellish",
                newName: "EmblishId");

            migrationBuilder.RenameIndex(
                name: "IX_Embellish_EmbellishTypeId",
                table: "Embellish",
                newName: "IX_Embellish_EmblishTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Embellish_EmbellishTypes_EmblishTypeId",
                table: "Embellish",
                column: "EmblishTypeId",
                principalTable: "EmbellishTypes",
                principalColumn: "EmblishTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Embellish_EmbellishTypes_EmblishTypeId",
                table: "Embellish");

            migrationBuilder.RenameColumn(
                name: "EmblishTypeId",
                table: "Embellish",
                newName: "EmbellishTypeId");

            migrationBuilder.RenameColumn(
                name: "EmblishName",
                table: "Embellish",
                newName: "EmbelishName");

            migrationBuilder.RenameColumn(
                name: "EmblishId",
                table: "Embellish",
                newName: "EmbellishId");

            migrationBuilder.RenameIndex(
                name: "IX_Embellish_EmblishTypeId",
                table: "Embellish",
                newName: "IX_Embellish_EmbellishTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Embellish_EmbellishTypes_EmbellishTypeId",
                table: "Embellish",
                column: "EmbellishTypeId",
                principalTable: "EmbellishTypes",
                principalColumn: "EmblishTypeId");
        }
    }
}
