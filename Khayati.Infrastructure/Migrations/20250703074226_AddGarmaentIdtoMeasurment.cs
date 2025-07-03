using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khayati.Infrastructure.Migrations
{
    public partial class AddGarmaentIdtoMeasurment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GarmentId",
                table: "Measurements",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_GarmentId",
                table: "Measurements",
                column: "GarmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Garments_GarmentId",
                table: "Measurements",
                column: "GarmentId",
                principalTable: "Garments",
                principalColumn: "GarmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Garments_GarmentId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_GarmentId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "GarmentId",
                table: "Measurements");
        }
    }
}
