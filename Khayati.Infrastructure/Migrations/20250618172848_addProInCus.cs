using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class addProInCus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                table: "Embellishment");

            migrationBuilder.AddForeignKey(
                name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                table: "Embellishment",
                column: "EmbellishmentTypeId",
                principalTable: "EmbellishmentTypes",
                principalColumn: "EmbellishmentTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                table: "Embellishment");

            migrationBuilder.AddForeignKey(
                name: "FK_Embellishment_EmbellishmentTypes_EmbellishmentTypeId",
                table: "Embellishment",
                column: "EmbellishmentTypeId",
                principalTable: "EmbellishmentTypes",
                principalColumn: "EmbellishmentTypeId");
        }
    }
}
