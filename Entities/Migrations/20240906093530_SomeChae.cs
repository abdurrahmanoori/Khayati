using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class SomeChae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmbellishTypeName",
                table: "EmbellishTypes",
                newName: "EmblishTypeName");

            migrationBuilder.RenameColumn(
                name: "EmbellishTypeDiscription",
                table: "EmbellishTypes",
                newName: "EmblishTypeDiscription");

            migrationBuilder.RenameColumn(
                name: "EmbellishTypeId",
                table: "EmbellishTypes",
                newName: "EmblishTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmblishTypeName",
                table: "EmbellishTypes",
                newName: "EmbellishTypeName");

            migrationBuilder.RenameColumn(
                name: "EmblishTypeDiscription",
                table: "EmbellishTypes",
                newName: "EmbellishTypeDiscription");

            migrationBuilder.RenameColumn(
                name: "EmblishTypeId",
                table: "EmbellishTypes",
                newName: "EmbellishTypeId");
        }
    }
}
